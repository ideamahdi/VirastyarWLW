using System;
using System.Windows.Forms;

namespace VirastyarWLW
{
    /// <summary>
    /// Dialog for showing errors and errors to user.
    /// </summary>
    public partial class SpellingErrorDialog : Form
    {
        #region Private Fields

        private string m_misspelledWord;

        #endregion

        #region Ctors

        public SpellingErrorDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates an instance of this class with the given paramters and shows it.
        /// </summary>
        /// <param name="misspelledWord">The misspelled word.</param>
        /// <param name="suggestions">Suggestions.</param>
        /// <param name="replacementWord">The replacement word.</param>
        /// <returns></returns>
        public static SpellDialogResult ShowForm(IWin32Window owner,
            string misspelledWord, string[] suggestions, out string replacementWord)
        {
            var dialog = new SpellingErrorDialog
                             {
                                 Suggestions = suggestions,
                                 MisspelledWord = misspelledWord,
                                 SpellDialogResult = SpellDialogResult.Cancel
                             };
            if (suggestions.Length > 0)
                dialog.ReplacementWord = suggestions[0];

            dialog.ShowDialog(owner);
            
            replacementWord = dialog.ReplacementWord;
            return dialog.SpellDialogResult;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the user decision
        /// </summary>
        public SpellDialogResult SpellDialogResult
        {
            get;
            private set;
        }

        private string[] m_suggestions;

        /// <summary>
        /// Gets the suggestions for this error
        /// </summary>
        public string[] Suggestions
        {
            get { return m_suggestions; }
            private set
            {
                m_suggestions = value;
                lstSuggestions.Items.Clear();
                if (m_suggestions != null && m_suggestions.Length > 0)
                {
                    lstSuggestions.Items.AddRange(m_suggestions);
                    lstSuggestions.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Gets the replacement word.
        /// </summary>
        public string ReplacementWord
        {
            get { return txtReplacement.Text; }
            private set { txtReplacement.Text = value; }
        }

        /// <summary>
        /// Gets the misspelled word.
        /// </summary>
        public string MisspelledWord
        {
            get { return m_misspelledWord; }
            private set
            {
                m_misspelledWord = value;
                txtMisspelledWord.Text = m_misspelledWord;
            }
        }

        #endregion

        #region Event Handlers

        private void lstSuggestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSuggestions.SelectedIndex > -1)
                txtReplacement.Text = lstSuggestions.SelectedItem.ToString();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            SpellDialogResult = VirastyarWLW.SpellDialogResult.Change;
            Close();
        }

        private void btnChangeAll_Click(object sender, EventArgs e)
        {
            SpellDialogResult = VirastyarWLW.SpellDialogResult.ChangeAll;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SpellDialogResult = VirastyarWLW.SpellDialogResult.Cancel;
            Close();
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            SpellDialogResult = VirastyarWLW.SpellDialogResult.Ignore;
            Close();
        }

        private void btnIgnoreAll_Click(object sender, EventArgs e)
        {
            SpellDialogResult = VirastyarWLW.SpellDialogResult.IgnoreAll;
            Close();
        }

        private void lstSuggestions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SpellDialogResult = VirastyarWLW.SpellDialogResult.Change;
            Close();
        }

        #endregion
    }

    #region SpellDialogResult

    public enum SpellDialogResult
    {
        Ignore,
        IgnoreAll,
        Change,
        ChangeAll,
        Cancel
    }

    #endregion
}