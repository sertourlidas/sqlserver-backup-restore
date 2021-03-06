using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Security;
using System.Security.Cryptography;

namespace BackupRestoreToolkit
{

    public partial class FormLogin : Form
    {
        public string dbname = "";

        #region Constructor

        public FormLogin()
        {
            InitializeComponent();
        }

        #endregion

        #region Functional Method
         
        private bool validateInputs()
        {
            bool isCorrect = true;

            errorProvider.Clear();

            if (comboBoxDatabase.Text.Trim() == "")
            {
                errorProvider.SetError(comboBoxDatabase, "لطفاً نام بانک اطلاعاتی را وارد كنيد");
                isCorrect = false;
            }
            return (isCorrect);
        }

        private bool CheckConnection()
        {
            bool isCorrect = false;
            errorProvider.Clear();
            comboBoxDatabase.Items.Clear();
            Control errorControl = null;

            try
            {
                if (textSqlServerName.Text.Trim() == "")
                {
                    errorControl = textSqlServerName;
                    throw new Exception("نام سرور را وارد کنید");
                }
                if (radioButtonServer.Checked)
                {
                    if (textSQLUsername.Text.Trim() == "")
                    {
                        errorControl = textSQLUsername;
                        throw new Exception("نام کاربر را وارد کنید");
                    }

                    if (textSQLPassword.Text.Trim() == "")
                    {
                        errorControl = textSQLPassword;
                        throw new Exception("رمز کاربر را وارد کنید");
                    }
                }

                if (!DataAccess.checkConnection(textSqlServerName.Text.Trim(), radioButtonWindows.Checked, textSQLUsername.Text, textSQLPassword.Text))
                {
                    errorControl = btnConnect;
                    throw new Exception("نام سرور یا نام کاربر و یا رمز کاربر صحیح نمی باشد");
                }

                Application.DoEvents();
                isCorrect = true;

                Properties.Settings.Default["sqlServer"] = textSqlServerName.Text.Trim();
                Properties.Settings.Default["Authentication"] = (radioButtonWindows.Checked ?
                    "Integrated Security=True" : "User ID=" + textSQLUsername.Text.Trim() + ";Password=" + textSQLPassword.Text.Trim());
                Properties.Settings.Default["windowsLogin"] = radioButtonWindows.Checked;
                Properties.Settings.Default["sqlUsername"] = textSQLUsername.Text.Trim();
                Properties.Settings.Default["sqlPassword"] = textSQLPassword.Text.Trim();
                Properties.Settings.Default.Save();

                DataTable dt = DataAccess.SelectMaster("master.dbo.sysdatabases", "name", "", "name");
                foreach (DataRow drow in dt.Rows)
                {
                    comboBoxDatabase.Items.Add(drow["name"].ToString());
                }
            }
            catch (Exception ex)
            {

                errorProvider.SetError(errorControl, ex.Message);
            }
            return isCorrect;
        }
        #endregion

        #region Event Handlers

        private void btnConnect_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            Cursor = Cursors.WaitCursor;
            btnConnect.Enabled = false;
            try
            {
                if (CheckConnection())
                {
                    PersianMessageBox pm = new PersianMessageBox();
                    pm.Information("اتصال موفق", string.Format("اتصال با سرور '{0}' برقرار است", textSqlServerName.Text));
                }
            }
            catch (Exception ex)
            {
                //Log.AddLog(ex.ToString());
                throw ex;
            }
            finally
            {
                Cursor = Cursors.Default;
                btnConnect.Enabled = true;
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default["currentDirectory"] = Directory.GetCurrentDirectory();
                Properties.Settings.Default.Save();

                textSqlServerName.Text = Properties.Settings.Default["sqlServer"].ToString();
                radioButtonWindows.Checked = Convert.ToBoolean(Properties.Settings.Default["windowsLogin"]);
                radioButtonServer.Checked = !Convert.ToBoolean(Properties.Settings.Default["windowsLogin"]);
                if (radioButtonServer.Checked)
                {
                    textSQLUsername.Text = Properties.Settings.Default["sqlUsername"].ToString();
                    textSQLPassword.Text = Properties.Settings.Default["sqlPassword"].ToString();
                }

                if (DataAccess.checkConnection(textSqlServerName.Text.Trim(), radioButtonWindows.Checked, textSQLUsername.Text, textSQLPassword.Text))
                {
                    DataTable dt = DataAccess.SelectMaster("master.dbo.sysdatabases", "name", "", "name");
                    foreach (DataRow drow in dt.Rows)
                    {
                        comboBoxDatabase.Items.Add(drow["name"].ToString());
                        if (drow["name"].ToString() == Properties.Settings.Default["sqlDatabase"].ToString())
                            comboBoxDatabase.Text = drow["name"].ToString();
                    }
                }

            }
            catch /*(Exception ex)*/
            {
                //Log.AddLog(ex.ToString());
            }
        }

        //private void BuildDatabase()
        //{
        //    Boolean IsDataBaseExist = true;
        //    try
        //    {
        //        IsDataBaseExist = !(File.Exists("Sale-emptyDB.bak"));
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show("تنظیمات اولیه قابل بازیابی نیست");
        //        //Log.AddLog(ex.ToString());
        //        Close();
        //    }

        //    if (!IsDataBaseExist)
        //    {
        //        try
        //        {
        //            DataAccess.CreateDatabase("Sale", Properties.Settings.Default["currentDirectory"].ToString());
        //        }
        //        catch
        //        {
        //            //MessageBox.Show(ex.Message);
        //        }

        //        FormBackupRestore frmBackupRestore = new FormBackupRestore(Mode.Restore);
        //        frmBackupRestore.showMessage = false;
        //        frmBackupRestore.RestoreDb("Sale",
        //            Properties.Settings.Default["currentDirectory"].ToString() + @"\Sale-emptyDB.bak",
        //            Properties.Settings.Default["currentDirectory"].ToString());

        //        #region reopen killed sql connection - Must Exist, Don't Delete
        //        try
        //        {
        //            DataAccess.SelectTable("Tbl_User", "*", "", "");
        //        }
        //        catch
        //        { }
        //        #endregion

        //        //remove emptyDB backUp
        //        File.Delete("Sale-emptyDB.bak");
        //    }
        //}

        private void btnOk_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (validateInputs())
                {
                    Properties.Settings.Default["sqlDatabase"] = this.dbname = comboBoxDatabase.Text;
                    Properties.Settings.Default.Save();

                    this.DialogResult = DialogResult.OK;
                }

            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Cancel;
                errorProvider.SetError(btnOk, ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void radioButtonServer_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxServer.Enabled = radioButtonServer.Checked;
        }

        private void comboBoxDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbname = comboBoxDatabase.Items[comboBoxDatabase.SelectedIndex].ToString();
        }

        #endregion











    }
}