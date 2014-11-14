using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BackupRestoreToolkit
{
    public partial class MainForm : Form
    {
        string DBName = "";

        public MainForm(string dbname)
        {
            InitializeComponent();
            this.DBName = dbname;
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            FormBackupRestore frmBackupRestore = new FormBackupRestore(Mode.Backup, DBName);
            frmBackupRestore.ShowDialog();
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            FormBackupRestore frmBackupRestore = new FormBackupRestore(Mode.Restore, DBName);
            frmBackupRestore.ShowDialog();
        }
    }
}
