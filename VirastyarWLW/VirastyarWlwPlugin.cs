using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WindowsLive.Writer.Api;
using System.Windows.Forms;
using SCICT.NLP.TextProofing.SpellChecker;
using SCICT.VirastyarInlineVerifiers;

namespace VirastyarWLW
{
    [WriterPluginAttribute(
        "8930534E-A5AA-4F20-8B78-AE6C0E425102",
        "Virastyar",
        ImagePath = "Virastyar.bmp",
        HasEditableOptions = true,
        PublisherUrl = "http://sharpedia.wordpress.com",
        Description = "Virastyar WLW Plugin for Editing Persian Texts.\r\n افزونهٔ ویراستیار برای اصلاح نگارش متون فارسی در برنامهٔ لایو-رایتر")]

    [InsertableContentSourceAttribute("ویرایش متن فارسی")]
    public class VirastyarWlwPlugin : ContentSource
    {
        // TODO
        private const string basePath = @"D:\Mehrdad\Works\Noor\Virastyar\virastyar@svn\Projects\SpellChecker\trunk\VirastyarWordAddin\VirastyarWordAddin\Resources";
        
        private PersianSpellChecker m_speller;

        private Options m_options;

        public override void Initialize(IProperties pluginOptions)
        {
            // This will set the Options property
            base.Initialize(pluginOptions);
            
            // And we'll use a wrapper instead 
            m_options = new Options(Options);

            #region Create SpellChecker

            var config = new SpellCheckerConfig();
            config.DicPath = Path.Combine(basePath, "dic.dat");
            config.StemPath = Path.Combine(basePath, "stem.dat");

            m_speller = new PersianSpellChecker(config);

            #endregion
        }

        public override void EditOptions(IWin32Window dialogOwner)
        {
            OptionsForm.ShowForm(dialogOwner, m_options);
        }

        public override DialogResult CreateContent(IWin32Window dialogOwner, ref string content)
        {
            var verifier = new SpellCheckerInlineVerifier(false, m_speller);
            var stringReplacement = new StringReplacement(content);

            foreach (var spellError in verifier.VerifyText(content))
            {
                bool shouldBreak = false;
                string replacementWord;
                string misspelledWord = content.Substring(spellError.Index, spellError.Length);
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

                if (shouldBreak)
                    break;
            }
            
            content = stringReplacement.Text;
            return DialogResult.OK;
        }
    }
}
