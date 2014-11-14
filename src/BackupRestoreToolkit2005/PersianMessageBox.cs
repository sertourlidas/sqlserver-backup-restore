using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BackupRestoreToolkit
{
    public partial class PersianMessageBox : Form
    {
        Boolean Result = false;

        public PersianMessageBox()
        {
            InitializeComponent();
        }

        public Boolean Question(string Title, string Message)
        {
            Btn_No.Visible = true;
            Btn_Yes.Visible = true;
            Btn_Ok.Visible = false;

            this.Text = Title;
            lblMessage.Text = Message;
            lblMessage.Location = new Point(390 - lblMessage.Size.Width, lblMessage.Location.Y);

            pictureBox1.Image = global ::BackupRestoreToolkit.Properties.Resources.question;

            this.ShowDialog();
            return Result;
        }

        public Boolean Information(string Title, string Message)
        {
            Btn_No.Visible = false;
            Btn_Yes.Visible = false;
            Btn_Ok.Visible = true;

            this.Text = Title;
            lblMessage.Text = Message;
            lblMessage.Location = new Point(390 - lblMessage.Size.Width, lblMessage.Location.Y);

            pictureBox1.Image = global ::BackupRestoreToolkit.Properties.Resources.info;

            this.ShowDialog();
            return Result;
        }

        public Boolean Warning(string Title, string Message)
        {
            Btn_No.Visible = false;
            Btn_Yes.Visible = false;
            Btn_Ok.Visible = true;

            this.Text = Title;
            lblMessage.Text = Message;
            lblMessage.Location = new Point(390 - lblMessage.Size.Width, lblMessage.Location.Y);

            pictureBox1.Image = global ::BackupRestoreToolkit.Properties.Resources.importance;

            this.ShowDialog();
            return Result;
        }

        public Boolean Error(string Title, string Message)
        {
            Btn_No.Visible = false;
            Btn_Yes.Visible = false;
            Btn_Ok.Visible = true;

            this.Text = Title;
            lblMessage.Text = Message;
            lblMessage.Location = new Point(390 - lblMessage.Size.Width, lblMessage.Location.Y);

            if (lblMessage.Size.Width > 360)
            {
                this.Size = new Size(533 + (lblMessage.Size.Width - 360), this.Size.Height);
                lblMessage.Location = new Point(this.Size.Width - 140 - lblMessage.Size.Width, lblMessage.Location.Y);
                Btn_Ok.Location = new Point((this.Size.Width / 2) - 36, Btn_Ok.Location.Y);
            }

            pictureBox1.Image = global ::BackupRestoreToolkit.Properties.Resources.not_allow;

            this.ShowDialog();
            return Result;
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            Result = true;
            this.Close();
        }

        private void Btn_Yes_Click(object sender, EventArgs e)
        {
            Result = true;
            this.Close();
        }

        private void Btn_No_Click(object sender, EventArgs e)
        {
            Result = false;
            this.Close();
        }

    }
}
