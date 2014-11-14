using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management;
using Microsoft.SqlServer.Management.Common;
using System.Collections.Specialized;
using System.IO;

namespace BackupRestoreToolkit
{
    public partial class FormBackupRestore : Form
    {
        private SqlConnection sqlConn;
        private Server sqlServer;
        private string DBName = "";
        public Boolean showMessage = true;

        Mode mode;
        public FormBackupRestore(Mode mode, string dbname)
        {
            InitializeComponent();
            this.mode = mode;
            this.DBName = dbname;

            sqlConn = new SqlConnection(DataAccess.ConStrMaster);
            sqlServer = new Server(new ServerConnection(sqlConn));
        }

        private void FormBackupRestore_Load(object sender, EventArgs e)
        {
            //labelAppName.Text = Properties.Settings.Default["AppName"].ToString();

            if (mode == Mode.Backup)
            {
                this.pictureBox1.Image = global::BackupRestoreToolkit.Properties.Resources.database_down;
                this.Text = "پشتیبان گیری از بانک اطلاعاتی";
            }
            else
            {
                this.pictureBox1.Image = global::BackupRestoreToolkit.Properties.Resources.database_up;
                this.Text = "بازیابی به بانک اطلاعاتی";
            }
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            string LastBackupPath = Properties.Settings.Default["LastBackupPath"].ToString().Trim();
            if (LastBackupPath != "")
                saveFileDialog1.FileName = LastBackupPath;
            saveFileDialog1.FileName += (mode == Mode.Backup ? Calendar.getPersianDate(0, "-") + ".bak" : "");

            if (mode == Mode.Backup)
            {
                saveFileDialog1.Filter = "*.bak|*.bak";
                saveFileDialog1.Title = "ذخیره فایل پشتیبان";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = saveFileDialog1.FileName;
                    Properties.Settings.Default["LastBackupPath"] = saveFileDialog1.FileName.Substring(0, saveFileDialog1.FileName.LastIndexOf(@"\")+1);
                    Properties.Settings.Default.Save();
                }
            }
            else if (mode == Mode.Restore)
            {
                openFileDialog1.Filter = "*.bak|*.bak";
                openFileDialog1.Title = "بازیابی فایل پشتیبان";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = openFileDialog1.FileName;
                    Properties.Settings.Default["LastBackupPath"] = saveFileDialog1.FileName.Substring(0, saveFileDialog1.FileName.LastIndexOf(@"\")+1);
                    Properties.Settings.Default.Save();
                }
            }

            Directory.SetCurrentDirectory(Properties.Settings.Default["currentDirectory"].ToString());
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtPath.Text.Trim() != "")
            {
                if (mode == Mode.Backup)
                    BackupDb(DBName, txtPath.Text);
                else if (mode == Mode.Restore)
                {
                    //BackUp before every restore
                    showMessage = false;
                    BackupDb(DBName, Properties.Settings.Default["currentDirectory"].ToString() + @"\BackUp\" + Calendar.getPersianDate(0, "-") + ".bak");

                    showMessage = true;
                    RestoreDb(DBName, txtPath.Text + (mode == Mode.Backup ? ".bak" : ""));

                }
            }
            else
            {
                errorProvider.SetError(BtnSave, "لطفا یک فایل را انتخاب نمایید");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void BackupDb(string dbName, string backupSavePath)
        {
            Backup dbBackup = new Backup();

            this.Cursor = Cursors.WaitCursor;

            try
            {
                dbBackup.Action = BackupActionType.Database;
                dbBackup.Database = dbName;
                dbBackup.BackupSetName = string.Format("{0} backup set.", dbName);
                dbBackup.BackupSetDescription = string.Format("Database: {0}. Date: {1}.", dbName, DateTime.Now.ToString("dd.MM.yyyy hh:m"));
                dbBackup.MediaDescription = "Disk";

                BackupDeviceItem device = new BackupDeviceItem(backupSavePath, DeviceType.File);
                dbBackup.Devices.Add(device);

                //dbBackup.Incremental = true;
                
                dbBackup.Script(sqlServer);

                progBar.Visible = true;
                progBar.Value = 0;

                dbBackup.Complete += new ServerMessageEventHandler(dbBackup_Complete);
                dbBackup.PercentCompleteNotification = 10;
                dbBackup.PercentComplete += new PercentCompleteEventHandler(PercentComplete);

                dbBackup.SqlBackup(sqlServer);
            }
            catch /*(Exception ex)*/
            {
                dbBackup.Abort();
                //Log.AddLog(ex.ToString());
            }
            finally
            {
                sqlConn.Close();

                this.Cursor = Cursors.Default;
            }

            progBar.Visible = false;
        }

        void dbBackup_Complete(object sender, ServerMessageEventArgs e)
        {
            if (showMessage)
            {
                PersianMessageBox pm = new PersianMessageBox();
                pm.Information("توجه", "با موفقیت انجام شد");
            }
            Close();
        }

        void PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            if (progBar.Value < progBar.Maximum)
            {
                if ((progBar.Value + e.Percent) <= 100)
                {
                    progBar.Value += e.Percent;
                }
                else
                    progBar.Value = 100;
            }
        }

        public void RestoreDb(string dbName, string resotrFilePath/*, string dtabase_MDF_Location*/)
        {
            killOpenProcesses(dbName);

            Restore dbRestore = new Restore();

            this.Cursor = Cursors.WaitCursor;

            dbRestore.Database = dbName;
            dbRestore.Action = RestoreActionType.Database;
            dbRestore.ReplaceDatabase = true;

            try
            {
                BackupDeviceItem device = new BackupDeviceItem(resotrFilePath, DeviceType.File);
                dbRestore.Devices.Add(device);
                DataTable dtFiles = dbRestore.ReadFileList(sqlServer);
                string backupDbLogicalName = dtFiles.Rows[0]["LogicalName"].ToString();

                //RelocateFile dbRf = new RelocateFile(backupDbLogicalName, string.Format("{0}\\{1}.mdf", dtabase_MDF_Location, dbName));
                //RelocateFile logRf = new RelocateFile(string.Format("{0}_log", backupDbLogicalName), string.Format("{0}\\{1}_Log.ldf", dtabase_MDF_Location, dbName));
                //dbRestore.RelocateFiles.Add(dbRf);
                //dbRestore.RelocateFiles.Add(logRf);

                string sql = string.Empty;
                StringCollection scriptColl = dbRestore.Script(sqlServer);
                foreach (string str in scriptColl)
                {
                    sql += str;
                }

                progBar.Visible = true;
                progBar.Value = 0;

                dbRestore.Complete += new ServerMessageEventHandler(dbRestore_Complete);
                dbRestore.PercentComplete += new PercentCompleteEventHandler(PercentComplete);
                dbRestore.SqlRestore(sqlServer);
            }
            catch /*(Exception ex)*/
            {
                dbRestore.Abort();
                //Log.AddLog(ex.ToString());
            }
            finally
            {
                sqlConn.Close();

                this.Cursor = Cursors.Default;
            }

            progBar.Visible = false;
        }

        public void killOpenProcesses(string DBName)
        {
            DataTable processTable = DataAccess.SelectMaster("sysprocesses", "spid", "dbid =  DB_ID('" + DBName + "')", "");
            foreach (DataRow row in processTable.Rows)
            {
                try
                {
                    DataAccess.QueryMaster("KILL " + row["spid"].ToString());
                }
                catch 
                {
                }
            }
        }

        void dbRestore_Complete(object sender, ServerMessageEventArgs e)
        {
            if (showMessage)
            {
                PersianMessageBox pm = new PersianMessageBox();
                pm.Information("توجه", "با موفقیت انجام شد");
            }
            Close();
        }

    }

    public enum Mode
    {
        Backup,
        Restore
    }
}
