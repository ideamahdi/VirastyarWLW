using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WindowsLive.Writer.Api;
using System.Windows.Forms;
using SCICT.NLP.TextProofing.SpellChecker;
using SCICT.VirastyarInlineVerifiers;
using System.Reflection;

namespace VirastyarWLW
{
    [WriterPluginAttribute(
        "8930534E-A5AA-4F20-8B78-AE6C0E425102",
        "Virastyar",
        ImagePath = "Virastyar.bmp",
        PublisherUrl = "http://github.com/sharpedia",
        HasEditableOptions = true,
        Description = "Virastyar WLW Plugin for Editing Persian Texts.\r\n افزونهٔ ویراستیار برای اصلاح نگارش متون فارسی در برنامهٔ لایو-رایتر")]
    [InsertableContentSourceAttribute("ویرایش متن فارسی")]
    public class VirastyarWLWplugin : ContentSource
    {
        #region Private Fields

        private string m_basePath;
        private PersianSpellChecker m_speller;
        private Options m_options;
        private ResourceManager m_resourceManger;

        #endregion

        #region Initialization Methods

        public override void Initialize(IProperties pluginOptions)
        {
            // This will set the Options property
            base.Initialize(pluginOptions);

            // And we'll use a wrapper instead 
            m_options = new Options(Options);

            m_resourceManger = new ResourceManager(Assembly.GetAssembly(typeof(VirastyarWLWplugin)));

            #region Create SpellChecker

            CheckDependencies();

            var config = new SpellCheckerConfig();
            config.DicPath = Path.Combine(m_basePath, "Dic.dat");
            config.StemPath = Path.Combine(m_basePath, "Stem.dat");
            config.EditDistance = 2;
            config.SuggestionCount = 10;

            m_speller = new PersianSpellChecker(config);

            #endregion
        }

        private void CheckDependencies()
        {
            m_basePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "VirastyarWLW");

            m_resourceManger.CheckAndRestoreResource("Dic.dat", m_basePath);
            m_resourceManger.CheckAndRestoreResource("Stem.dat", m_basePath);
        }

        #endregion

        #region Plug-in Methods

        public override void EditOptions(IWin32Window dialogOwner)
        {
            OptionsForm.ShowForm(dialogOwner, m_options);
        }

        public override DialogResult CreateContent(IWin32Window dialogOwner, ref string content)
        {
            var verifier = new SpellCheckerInlineVerifier(false, m_speller);
            var stringReplacement = new StringReplacement(content);

            VerificationInstance prevSpellError = null;
            SpellDialogResult prevDialogResult = SpellDialogResult.Cancel;

            foreach (var spellError in verifier.VerifyText(content))
            {
                bool shouldBreak = false;
                bool shouldCheck = true;
                string misspelledWord = content.Substring(spellError.Index, spellError.Length);
                if (prevSpellError != null)
                {
                    if (prevSpellError.Index == spellError.Index &&
                        prevSpellError.Length == spellError.Length &&
                        (prevDialogResult == SpellDialogResult.Change || prevDialogResult == SpellDialogResult.ChangeAll))
                        shouldCheck = false;
                }

                if (shouldCheck)
                {
                    string replacementWord;
                    var dialogResult = SpellingErrorDialog.ShowForm(
                        dialogOwner, misspelledWord, spellError.Suggestions, out replacementWord);

                    switch (dialogResult)
                    {
                        case SpellDialogResult.Cancel:
                            shouldBreak = true;
                            break;
                        case SpellDialogResult.Change:
                            stringReplacement.Replace(spellError.Index, spellError.Length, replacementWord);
                            break;
                        case SpellDialogResult.ChangeAll:
                            stringReplacement.Replace(misspelledWord, replacementWord);
                            break;
                        case SpellDialogResult.Ignore:
                            break;
                        case SpellDialogResult.IgnoreAll:
                            m_speller.AddToIgnoreList(misspelledWord);
                            break;
                    }
                    prevDialogResult = dialogResult;
                }
                else
                {
                    prevDialogResult = SpellDialogResult.Ignore;
                }

                prevSpellError = spellError;

                if (shouldBreak)
                    break;
            }

            content = stringReplacement.Text;
            return DialogResult.OK;
        }

        #endregion
    }
}
