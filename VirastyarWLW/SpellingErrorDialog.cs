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
        #region Ctors
        
        public SpellingErrorDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods

        public static SpellDialogResult ShowForm(IWin32Window owner,
            string misspelledWord, string[] suggestion, out string replaceWord)
        {
            var dialog = new SpellingErrorDialog();
            dialog.ShowDialog(owner);
            replaceWord = dialog.ReplaceWord;
            return dialog.SpellDialogResult;
        }

        #endregion

        #region Properties

        public SpellDialogResult SpellDialogResult
        {
            get;
            set;
        }

        public string[] Suggestions
        {
            get;
            set;
        }

        public string ReplaceWord
        {
            get;
            set;
        }

        #endregion

        #region Event Handlers

        private void SpellingErrorDialog_Load(object sender, EventArgs e)
        {
            lstSuggestions.Items.Clear();
            lstSuggestions.Items.AddRange(Suggestions);
        }

        private void lstSuggestions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion
    }

    public enum SpellDialogResult
    {
        Ignore,
        IgnoreAll,
        Change,
        ChangeAll,
        Cancel
    }
}
