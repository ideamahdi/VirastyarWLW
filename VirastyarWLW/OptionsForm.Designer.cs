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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.chkDoPreSpellCheck = new System.Windows.Forms.CheckBox();
            this.groupBoxChars = new System.Windows.Forms.GroupBox();
            this.cbConvertShortHeYeToLong = new System.Windows.Forms.CheckBox();
            this.cbConvertLongHeYeToShort = new System.Windows.Forms.CheckBox();
            this.chkDoSpellCheck = new System.Windows.Forms.CheckBox();
            this.chkDoCharRefinement = new System.Windows.Forms.CheckBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMain.SuspendLayout();
            this.groupBoxChars.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlMain.Controls.Add(this.chkDoPreSpellCheck);
            this.pnlMain.Controls.Add(this.groupBoxChars);
            this.pnlMain.Controls.Add(this.chkDoSpellCheck);
            this.pnlMain.Controls.Add(this.chkDoCharRefinement);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(442, 161);
            this.pnlMain.TabIndex = 0;
            // 
            // chkDoPreSpellCheck
            // 
            this.chkDoPreSpellCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDoPreSpellCheck.AutoSize = true;
            this.chkDoPreSpellCheck.Checked = true;
            this.chkDoPreSpellCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDoPreSpellCheck.Location = new System.Drawing.Point(147, 110);
            this.chkDoPreSpellCheck.Name = "chkDoPreSpellCheck";
            this.chkDoPreSpellCheck.Size = new System.Drawing.Size(272, 17);
            this.chkDoPreSpellCheck.TabIndex = 3;
            this.chkDoPreSpellCheck.Text = "۲. به‌صورت خودکار پیش‌پردازش املاییِ متن را انجام بده";
            this.toolTip.SetToolTip(this.chkDoPreSpellCheck, "به‌صورت خودکار برخی اشکال‌های متن را برطرف می‌کند. به عنوان مثال:\r\n«می تواند» => " +
        "«می‌تواند»\r\n«کتاب ها» => «کتاب‌ها»");
            this.chkDoPreSpellCheck.UseVisualStyleBackColor = true;
            // 
            // groupBoxChars
            // 
            this.groupBoxChars.Controls.Add(this.cbConvertShortHeYeToLong);
            this.groupBoxChars.Controls.Add(this.cbConvertLongHeYeToShort);
            this.groupBoxChars.Enabled = false;
            this.groupBoxChars.Location = new System.Drawing.Point(12, 29);
            this.groupBoxChars.Name = "groupBoxChars";
            this.groupBoxChars.Size = new System.Drawing.Size(424, 75);
            this.groupBoxChars.TabIndex = 2;
            this.groupBoxChars.TabStop = false;
            // 
            // cbConvertShortHeYeToLong
            // 
            this.cbConvertShortHeYeToLong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbConvertShortHeYeToLong.AutoSize = true;
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
            this.cbConvertLongHeYeToShort.Checked = true;
            this.cbConvertLongHeYeToShort.CheckState = System.Windows.Forms.CheckState.Checked;
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
            this.chkDoSpellCheck.Checked = true;
            this.chkDoSpellCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDoSpellCheck.Location = new System.Drawing.Point(294, 133);
            this.chkDoSpellCheck.Name = "chkDoSpellCheck";
            this.chkDoSpellCheck.Size = new System.Drawing.Size(125, 17);
            this.chkDoSpellCheck.TabIndex = 1;
            this.chkDoSpellCheck.Text = "۳. متن را غلط‌یابی کن";
            this.toolTip.SetToolTip(this.chkDoSpellCheck, "پس از انجام مراحل بالا، اشکال‌های املایی را یافته و به کاربر اطلاع می‌دهد");
            this.chkDoSpellCheck.UseVisualStyleBackColor = true;
            // 
            // chkDoCharRefinement
            // 
            this.chkDoCharRefinement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDoCharRefinement.AutoSize = true;
            this.chkDoCharRefinement.Location = new System.Drawing.Point(178, 12);
            this.chkDoCharRefinement.Name = "chkDoCharRefinement";
            this.chkDoCharRefinement.Size = new System.Drawing.Size(241, 17);
            this.chkDoCharRefinement.TabIndex = 0;
            this.chkDoCharRefinement.Text = "۱. به‌صورت خودکار کاراکترهای متن را اصلاح کن:";
            this.toolTip.SetToolTip(this.chkDoCharRefinement, "کاراکترهای غیر استاندارد فارسی و نیم‌فاصله‌هایی که پشت سر هم درج شده باشند را اصل" +
        "اح می‌کند.");
            this.chkDoCharRefinement.UseVisualStyleBackColor = true;
            this.chkDoCharRefinement.CheckedChanged += new System.EventHandler(this.chkDoCharRefinement_CheckedChanged);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 161);
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
            // toolTip
            // 
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(442, 209);
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
        private System.Windows.Forms.CheckBox chkDoPreSpellCheck;
        private System.Windows.Forms.ToolTip toolTip;
    }
}