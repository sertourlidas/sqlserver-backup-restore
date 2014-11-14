using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BackupRestoreToolkit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormLogin login = new FormLogin();
            if (login.ShowDialog() == DialogResult.OK)
                Application.Run(new MainForm(login.dbname));
        }
    }
}
