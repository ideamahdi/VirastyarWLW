using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SCICT.NLP.Utility;
using SCICT.NLP.Utility.Parsers;
using WindowsLive.Writer.Api;
using System.Windows.Forms;
using SCICT.NLP.TextProofing.SpellChecker;
using SCICT.VirastyarInlineVerifiers;
using System.Reflection;
using SCICT.Utility.GUI;

namespace VirastyarWLW
{
    [WriterPluginAttribute(
        "8930534E-A5AA-4F20-8B78-AE6C0E425102",
        "Virastyar for WLW",
        ImagePath = "Virastyar.bmp",
        PublisherUrl = "http://github.com/sharpedia",
        HasEditableOptions = true,
        Description = "Virastyar WLW Plugin for editing Persian texts.\r\n افزونهٔ ویراستیار برای اصلاح نگارش متون فارسی در برنامهٔ لایو-رایتر")]
    [InsertableContentSourceAttribute("ویرایش متن فارسی")]
    public class VirastyarWLWplugin : ContentSource
    {
        #region Private Fields

        private string m_basePath;
        private PersianSpellChecker m_speller;
        private VerificationEngines m_engines;
        private InlineVerificationController m_controller;
        private Options m_options;
        private ResourceManager m_resourceManger;

        #endregion

        #region Initialization Methods

        /// <summary>
        /// Initializes the specified plugin options.
        /// </summary>
        /// <param name="pluginOptions">The plugin options.</param>
        public override void Initialize(IProperties pluginOptions)
        {
            // This will set the Options property
            base.Initialize(pluginOptions);

            // And we'll use a wrapper instead 
            m_options = new Options(Options);

            m_resourceManger = new ResourceManager(Assembly.GetAssembly(typeof(VirastyarWLWplugin)));

            #region Create SpellChecker

            CheckDependencies();

            m_engines = new VerificationEngines(
                Path.Combine(m_basePath, "Dic.dat"), 
                Path.Combine(m_basePath, "Stem.dat"), 
                null, null, null);

            m_controller = new InlineVerificationController(m_engines);
            m_speller = m_engines.GetSpellCheckerEngine();

            #endregion
        }

        /// <summary>
        /// Checks the dependencies.
        /// </summary>
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

        /// <summary>
        /// The main method of Plugin.
        /// </summary>
        /// <param name="content">The selected portion of the text.</param>
        /// <returns></returns>
        public override DialogResult CreateContent(IWin32Window dialogOwner, ref string content)
        {
            #region Zero-Length Selected Text
            if (content.Length == 0)
            {
                PersianMessageBox.Show(dialogOwner, "برای غلط‌یابی متن، ابتدا بخشی آن را انتخاب کنید", "انتخاب متن", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return DialogResult.Ignore;
            }
            #endregion

            string newContent = content;
            var msgs = new StringBuilder();
            try
            {
                string message;
                if (m_options.DoCharRefinement)
                {
                    newContent = RefineCharacters(newContent, out message);
                    msgs.AppendLine(message);
                }
                if (m_options.DoPreSpellCheck)
                {
                    newContent = PreSpellCheck(dialogOwner, newContent, out message);
                    msgs.Insert(0, string.Format("پیش‌پردازش املایی - {0}{1}{2}{1}", message, Environment.NewLine, new string('-', 20)));
                }
                if (m_options.DoSpellCheck)
                {
                    newContent = SpellCheck(dialogOwner, newContent, out message);
                    msgs.Insert(0, string.Format("{0}{1}{2}{1}", message, Environment.NewLine, new string('-', 20)));
                }
                content = newContent;
                PersianMessageBox.Show(dialogOwner, msgs.ToString(), "نتیجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // TODO: Send Error and DO NOT REPLACE USER TEXT
            }

            return DialogResult.OK;
        }

        #endregion

        #region Service Methods

        /// <summary>
        /// Checks the spelling of the given string.
        /// </summary>
        private string SpellCheck(IWin32Window dialogOwner, string content, out string message)
        {
            var verifier = new SpellCheckerInlineVerifier(false, m_speller);
            var stringReplacement = new StringReplacement(content);

            int errorCount = 0;
            foreach (var spellError in m_controller.RemoveConflicts(verifier.VerifyText(content)))
            {
                ++errorCount;

                bool shouldBreak = false;
                string misspelledWord = content.Substring(spellError.Index, spellError.Length);

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

                if (shouldBreak)
                    break;
            }

            message = string.Format("تعداد خطاهای املایی: {0}",  ParsingUtils.ConvertNumber2Persian(errorCount.ToString()));
            return stringReplacement.Text;
        }

        /// <summary>
        /// Refines and standardizes the characters of the given string.
        /// </summary>
        private string RefineCharacters(string content, out string message)
        {
            var verifier = new BatchCharacterRefinement();

            var res = verifier.PerformBatchCharacterRefinement(content, new char[] { },
                SCICT.NLP.Persian.FilteringCharacterCategory.ArabicDigit,
                true, true, m_options.ConvertShortHeYeToLong, m_options.ConvertLongHeYeToShort);

            message = res.Message;
            return res.Result;
        }

        private string PreSpellCheck(IWin32Window dialogOwner, string content, out string message)
        {
            var dialogResult = PersianMessageBox.Show(dialogOwner, 
                "ابتدا مرحلهٔ پیش‌پردازش املایی انجام شده و برخی از اشکال‌های متن به‌طور خودکار تصحیح خواهند شد." + Environment.NewLine +
                "این عملیات ممکن است کمی طول بکشد. آیا موافقید؟" + Environment.NewLine + Environment.NewLine +
                "از طریق تنظمیات می‌توانید این مرحله را فعال/غیرفعال کنید",
                "پیش‌پردازش املایی", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK)
            {
                var result = m_controller.BatchPreSpellCheck(content,
                    PreSpellCheckerUserOptions.RefinePrefix |
                    PreSpellCheckerUserOptions.RefineSuffix | 
                    PreSpellCheckerUserOptions.RefineBe);

                message = result.Message;
                return result.Result;
            }
            else
            {
                message = "";
                return content;
            }
        }
        #endregion
    }
}
