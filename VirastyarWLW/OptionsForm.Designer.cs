namespace VirastyarWLW
{
    partial class OptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.groupBoxChars = new System.Windows.Forms.GroupBox();
            this.cbConvertShortHeYeToLong = new System.Windows.Forms.CheckBox();
            this.cbConvertLongHeYeToShort = new System.Windows.Forms.CheckBox();
            this.chkDoSpellCheck = new System.Windows.Forms.CheckBox();
            this.chkDoCharRefinement = new System.Windows.Forms.CheckBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.groupBoxChars.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlMain.Controls.Add(this.groupBoxChars);
            this.pnlMain.Controls.Add(this.chkDoSpellCheck);
            this.pnlMain.Controls.Add(this.chkDoCharRefinement);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(442, 170);
            this.pnlMain.TabIndex = 0;
            // 
            // groupBoxChars
            // 
            this.groupBoxChars.Controls.Add(this.cbConvertShortHeYeToLong);
            this.groupBoxChars.Controls.Add(this.cbConvertLongHeYeToShort);
            this.groupBoxChars.Enabled = false;
            this.groupBoxChars.Location = new System.Drawing.Point(12, 83);
            this.groupBoxChars.Name = "groupBoxChars";
            this.groupBoxChars.Size = new System.Drawing.Size(424, 82);
            this.groupBoxChars.TabIndex = 2;
            this.groupBoxChars.TabStop = false;
            // 
            // cbConvertShortHeYeToLong
            // 
            this.cbConvertShortHeYeToLong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbConvertShortHeYeToLong.AutoSize = true;
            this.cbConvertShortHeYeToLong.Checked = true;
            this.cbConvertShortHeYeToLong.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbConvertShortHeYeToLong.Location = new System.Drawing.Point(289, 47);
            this.cbConvertShortHeYeToLong.Name = "cbConvertShortHeYeToLong";
            this.cbConvertShortHeYeToLong.Size = new System.Drawing.Size(118, 17);
            this.cbConvertShortHeYeToLong.TabIndex = 10;
            this.cbConvertShortHeYeToLong.Text = "تبدیل «ـهٔ» به «ـه‌ی»";
            this.cbConvertShortHeYeToLong.UseVisualStyleBackColor = true;
            this.cbConvertShortHeYeToLong.Click += new System.EventHandler(this.ConvertHeYeToCheckBoxesClick);
            // 
            // cbConvertLongHeYeToShort
            // 
            this.cbConvertLongHeYeToShort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbConvertLongHeYeToShort.AutoSize = true;
            this.cbConvertLongHeYeToShort.Location = new System.Drawing.Point(289, 20);
            this.cbConvertLongHeYeToShort.Name = "cbConvertLongHeYeToShort";
            this.cbConvertLongHeYeToShort.Size = new System.Drawing.Size(118, 17);
            this.cbConvertLongHeYeToShort.TabIndex = 9;
            this.cbConvertLongHeYeToShort.Text = "تبدیل «ـه‌ی» به «ـهٔ»";
            this.cbConvertLongHeYeToShort.UseVisualStyleBackColor = true;
            this.cbConvertLongHeYeToShort.Click += new System.EventHandler(this.ConvertHeYeToCheckBoxesClick);
            // 
            // chkDoSpellCheck
            // 
            this.chkDoSpellCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDoSpellCheck.AutoSize = true;
            this.chkDoSpellCheck.Location = new System.Drawing.Point(309, 30);
            this.chkDoSpellCheck.Name = "chkDoSpellCheck";
            this.chkDoSpellCheck.Size = new System.Drawing.Size(112, 17);
            this.chkDoSpellCheck.TabIndex = 1;
            this.chkDoSpellCheck.Text = "متن را غلط‌یابی کن";
            this.chkDoSpellCheck.UseVisualStyleBackColor = true;
            // 
            // chkDoCharRefinement
            // 
            this.chkDoCharRefinement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDoCharRefinement.AutoSize = true;
            this.chkDoCharRefinement.Location = new System.Drawing.Point(264, 64);
            this.chkDoCharRefinement.Name = "chkDoCharRefinement";
            this.chkDoCharRefinement.Size = new System.Drawing.Size(157, 17);
            this.chkDoCharRefinement.TabIndex = 0;
            this.chkDoCharRefinement.Text = "کاراکترهای متن را اصلاح کن:";
            this.chkDoCharRefinement.UseVisualStyleBackColor = true;
            this.chkDoCharRefinement.CheckedChanged += new System.EventHandler(this.chkDoCharRefinement_CheckedChanged);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 170);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(442, 48);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(249, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "لغو";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(346, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "ذخیره";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(442, 218);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OptionsForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تنظمیات ";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.groupBoxChars.ResumeLayout(false);
            this.groupBoxChars.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkDoCharRefinement;
        private System.Windows.Forms.CheckBox chkDoSpellCheck;
        private System.Windows.Forms.GroupBox groupBoxChars;
        private System.Windows.Forms.CheckBox cbConvertShortHeYeToLong;
        private System.Windows.Forms.CheckBox cbConvertLongHeYeToShort;
    }
}