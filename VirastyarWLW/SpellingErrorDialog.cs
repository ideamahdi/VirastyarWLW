using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VirastyarWLW
{
    public partial class SpellingErrorDialog : Form
    {
        #region Private Fields

        private string m_replaceWord;
        private string m_misspelledWord;

        #endregion

        #region Ctors

        public SpellingErrorDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods

        public static SpellDialogResult ShowForm(IWin32Window owner,
            string misspelledWord, string[] suggestions, out string replaceWord)
        {
            var dialog = new SpellingErrorDialog
                             {
                                 Suggestions = suggestions,
                                 MisspelledWord = misspelledWord,
                                 SpellDialogResult = SpellDialogResult.Cancel
                             };
            if (suggestions.Length > 0)
                dialog.ReplaceWord = suggestions[0];

            dialog.ShowDialog(owner);
            
            replaceWord = dialog.ReplaceWord;
            return dialog.SpellDialogResult;
        }

        #endregion

        #region Properties

        public SpellDialogResult SpellDialogResult
        {
            get;
            private set;
        }

        private string[] m_suggestions;

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

        public string ReplaceWord
        {
            get { return m_replaceWord; }
            private set
            {
                m_replaceWord = value;
                txtReplacement.Text = value;
            }
        }

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