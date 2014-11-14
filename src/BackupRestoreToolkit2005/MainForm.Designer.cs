namespace BackupRestoreToolkit
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonBackup = new System.Windows.Forms.Button();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBackup
            // 
            this.buttonBackup.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.buttonBackup.Image = global::BackupRestoreToolkit.Properties.Resources.database_down;
            this.buttonBackup.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buttonBackup.Location = new System.Drawing.Point(12, 14);
            this.buttonBackup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonBackup.Size = new System.Drawing.Size(300, 85);
            this.buttonBackup.TabIndex = 0;
            this.buttonBackup.Text = "پشتیبان گیری اطلاعات                                  ";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // buttonRestore
            // 
            this.buttonRestore.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.buttonRestore.Image = global::BackupRestoreToolkit.Properties.Resources.database_up;
            this.buttonRestore.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buttonRestore.Location = new System.Drawing.Point(12, 107);
            this.buttonRestore.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonRestore.Size = new System.Drawing.Size(300, 85);
            this.buttonRestore.TabIndex = 1;
            this.buttonRestore.Text = "بازیابی اطلاعات                       ";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 206);
            this.Controls.Add(this.buttonRestore);
            this.Controls.Add(this.buttonBackup);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ابزار نگهداری بانک اطلاعاتی ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.Button buttonRestore;
    }
}

