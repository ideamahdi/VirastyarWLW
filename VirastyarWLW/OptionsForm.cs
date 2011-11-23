using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsLive.Writer.Api;

namespace VirastyarWLW
{
    /// <summary>
    /// Options dialog for the Plugin
    /// </summary>
    public partial class OptionsForm : Form
    {
        #region Private Fields

        private readonly Options m_options;

        #endregion

        #region Ctors

        public OptionsForm()
        {
            InitializeComponent();
        }

        public OptionsForm(Options options)
            : this()
        {
            m_options = options;
            UpdateUI();
        }

        #endregion

        #region Private Methods

        private void UpdateUI()
        {
            chkDoSpellCheck.Checked = m_options.DoSpellCheck;
            chkDoPreSpellCheck.Checked = m_options.DoPreSpellCheck;
            chkDoCharRefinement.Checked = m_options.DoCharRefinement;
            cbConvertLongHeYeToShort.Checked = m_options.ConvertLongHeYeToShort;
            cbConvertShortHeYeToLong.Checked = m_options.ConvertShortHeYeToLong;

            ConvertHeYeToCheckBoxesClick(cbConvertShortHeYeToLong, EventArgs.Empty);
        }

        private void UpdateConfig()
        {
            m_options.DoSpellCheck = chkDoSpellCheck.Checked;
            m_options.DoPreSpellCheck = chkDoPreSpellCheck.Checked;
            m_options.DoCharRefinement = chkDoCharRefinement.Checked;

            m_options.ConvertLongHeYeToShort = cbConvertLongHeYeToShort.Checked;
            m_options.ConvertShortHeYeToLong = cbConvertShortHeYeToLong.Checked;
        }

        #endregion

        #region Public Methods

        public static void ShowForm(IWin32Window dialogOwner, Options options)
        {
            var form = new OptionsForm(options);
            form.ShowDialog(dialogOwner);
        }

        #endregion

        #region Event Handlers

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateConfig();
        }

        private void chkDoCharRefinement_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxChars.Enabled = chkDoCharRefinement.Checked;
        }

        private void ConvertHeYeToCheckBoxesClick(object sender, EventArgs e)
        {
            var cbMain = sender as CheckBox;
            if (cbMain == null) return;

            if (!cbMain.Checked) // if it's been disabled then thre's no need to disable any other thing
                return;

            var cbsToChange = new[] { cbConvertLongHeYeToShort, cbConvertShortHeYeToLong };

            for (int i = 0; i < cbsToChange.Length; i++)
            {
                if (cbsToChange[i] != cbMain && cbsToChange[i].Checked)
                    cbsToChange[i].Checked = false;
            }
        }

        #endregion
    }
}
