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
    public partial class OptionsForm : Form
    {
        private Options m_options;

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

        private void UpdateUI()
        {
            chkDoSpellCheck.Checked = m_options.DoSpellCheck;
            chkDoCharRefinement.Checked = m_options.DoCharRefinement;
        }

        private void UpdateConfig()
        {
            m_options.DoSpellCheck = chkDoSpellCheck.Checked;
            m_options.DoCharRefinement = chkDoCharRefinement.Checked;
        }

        internal static void ShowForm(IWin32Window dialogOwner, Options options)
        {
            var form = new OptionsForm(options);
            form.ShowDialog(dialogOwner);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateConfig();
        }
    }
}
