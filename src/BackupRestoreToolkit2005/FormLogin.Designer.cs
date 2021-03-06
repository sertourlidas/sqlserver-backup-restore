namespace BackupRestoreToolkit
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.panel2 = new System.Windows.Forms.Panel();
            this.rptImage = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.textSQLPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxSqlServer = new System.Windows.Forms.GroupBox();
            this.radioButtonServer = new System.Windows.Forms.RadioButton();
            this.groupBoxServer = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textSQLUsername = new System.Windows.Forms.TextBox();
            this.radioButtonWindows = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxDatabase = new System.Windows.Forms.ComboBox();
            this.textSqlServerName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rptImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBoxSqlServer.SuspendLayout();
            this.groupBoxServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.rptImage);
            this.panel2.Controls.Add(this.labelTitle);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(337, 64);
            this.panel2.TabIndex = 8;
            // 
            // rptImage
            // 
            this.rptImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rptImage.Image = ((System.Drawing.Image)(resources.GetObject("rptImage.Image")));
            this.rptImage.Location = new System.Drawing.Point(279, 3);
            this.rptImage.Name = "rptImage";
            this.rptImage.Size = new System.Drawing.Size(55, 55);
            this.rptImage.TabIndex = 3;
            this.rptImage.TabStop = false;
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.AutoSize = true;
            this.labelTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labelTitle.Location = new System.Drawing.Point(25, 36);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(250, 13);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "لطفاً اطلاعات سرور را براي ورود به سيستم  وارد کنيد";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(64, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "سيستم مدیریت پشتبان گیری";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.panel1.Location = new System.Drawing.Point(0, 288);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 49);
            this.panel1.TabIndex = 3;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(205, 8);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(85, 30);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "اتصال";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(114, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(23, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 30);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "تاييد";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // textSQLPassword
            // 
            this.textSQLPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textSQLPassword.Location = new System.Drawing.Point(10, 46);
            this.textSQLPassword.Name = "textSQLPassword";
            this.textSQLPassword.PasswordChar = '*';
            this.textSQLPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textSQLPassword.Size = new System.Drawing.Size(198, 21);
            this.textSQLPassword.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "رمز سرور :";
            // 
            // groupBoxSqlServer
            // 
            this.groupBoxSqlServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSqlServer.Controls.Add(this.radioButtonServer);
            this.groupBoxSqlServer.Controls.Add(this.groupBoxServer);
            this.groupBoxSqlServer.Controls.Add(this.radioButtonWindows);
            this.groupBoxSqlServer.Controls.Add(this.label3);
            this.groupBoxSqlServer.Controls.Add(this.comboBoxDatabase);
            this.groupBoxSqlServer.Controls.Add(this.textSqlServerName);
            this.groupBoxSqlServer.Controls.Add(this.label5);
            this.groupBoxSqlServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxSqlServer.Location = new System.Drawing.Point(10, 70);
            this.groupBoxSqlServer.Name = "groupBoxSqlServer";
            this.groupBoxSqlServer.Size = new System.Drawing.Size(318, 212);
            this.groupBoxSqlServer.TabIndex = 1;
            this.groupBoxSqlServer.TabStop = false;
            this.groupBoxSqlServer.Text = "سرور SQL";
            // 
            // radioButtonServer
            // 
            this.radioButtonServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonServer.AutoSize = true;
            this.radioButtonServer.Location = new System.Drawing.Point(173, 75);
            this.radioButtonServer.Name = "radioButtonServer";
            this.radioButtonServer.Size = new System.Drawing.Size(114, 17);
            this.radioButtonServer.TabIndex = 8;
            this.radioButtonServer.TabStop = true;
            this.radioButtonServer.Text = "ورود با کاربر سرور";
            this.radioButtonServer.UseVisualStyleBackColor = true;
            this.radioButtonServer.CheckedChanged += new System.EventHandler(this.radioButtonServer_CheckedChanged);
            // 
            // groupBoxServer
            // 
            this.groupBoxServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxServer.Controls.Add(this.textSQLPassword);
            this.groupBoxServer.Controls.Add(this.label6);
            this.groupBoxServer.Controls.Add(this.label2);
            this.groupBoxServer.Controls.Add(this.textSQLUsername);
            this.groupBoxServer.Enabled = false;
            this.groupBoxServer.Location = new System.Drawing.Point(14, 78);
            this.groupBoxServer.Name = "groupBoxServer";
            this.groupBoxServer.Size = new System.Drawing.Size(288, 81);
            this.groupBoxServer.TabIndex = 9;
            this.groupBoxServer.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "کاربر سرور :";
            // 
            // textSQLUsername
            // 
            this.textSQLUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textSQLUsername.Location = new System.Drawing.Point(10, 20);
            this.textSQLUsername.Name = "textSQLUsername";
            this.textSQLUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textSQLUsername.Size = new System.Drawing.Size(198, 21);
            this.textSQLUsername.TabIndex = 1;
            // 
            // radioButtonWindows
            // 
            this.radioButtonWindows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonWindows.AutoSize = true;
            this.radioButtonWindows.Checked = true;
            this.radioButtonWindows.Location = new System.Drawing.Point(169, 52);
            this.radioButtonWindows.Name = "radioButtonWindows";
            this.radioButtonWindows.Size = new System.Drawing.Size(119, 17);
            this.radioButtonWindows.TabIndex = 7;
            this.radioButtonWindows.TabStop = true;
            this.radioButtonWindows.Text = "ورود با کاربر ویندوز";
            this.radioButtonWindows.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "بانک :";
            // 
            // comboBoxDatabase
            // 
            this.comboBoxDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDatabase.FormattingEnabled = true;
            this.comboBoxDatabase.Location = new System.Drawing.Point(25, 178);
            this.comboBoxDatabase.Name = "comboBoxDatabase";
            this.comboBoxDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxDatabase.Size = new System.Drawing.Size(198, 21);
            this.comboBoxDatabase.TabIndex = 5;
            this.comboBoxDatabase.SelectedIndexChanged += new System.EventHandler(this.comboBoxDatabase_SelectedIndexChanged);
            // 
            // textSqlServerName
            // 
            this.textSqlServerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textSqlServerName.Location = new System.Drawing.Point(25, 20);
            this.textSqlServerName.Name = "textSqlServerName";
            this.textSqlServerName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textSqlServerName.Size = new System.Drawing.Size(198, 21);
            this.textSqlServerName.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AllowDrop = true;
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Location = new System.Drawing.Point(233, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "نام سرور :";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(337, 337);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBoxSqlServer);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ورود به نرم افزار";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rptImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBoxSqlServer.ResumeLayout(false);
            this.groupBoxSqlServer.PerformLayout();
            this.groupBoxServer.ResumeLayout(false);
            this.groupBoxServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textSQLPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBoxSqlServer;
        private System.Windows.Forms.TextBox textSqlServerName;
		private System.Windows.Forms.Label label5;
        protected System.Windows.Forms.PictureBox rptImage;
        protected System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ErrorProvider errorProvider;
        protected System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox textSQLUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxDatabase;
        private System.Windows.Forms.GroupBox groupBoxServer;
        private System.Windows.Forms.RadioButton radioButtonServer;
        private System.Windows.Forms.RadioButton radioButtonWindows;

    }
}