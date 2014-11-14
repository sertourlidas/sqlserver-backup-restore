using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace BackupRestoreToolkit
{
    public static class DataAccess
    {
        public static string ConStr = @"Data Source=" +  Properties.Settings.Default["SqlServer"] +
            @";Initial Catalog=" + Properties.Settings.Default["sqlDatabase"] + ";" + Properties.Settings.Default["Authentication"];
        public static string ConStrMaster = @"Data Source=" + Properties.Settings.Default["SqlServer"] +
            @";Initial Catalog=master;" + Properties.Settings.Default["Authentication"];

        public static void refreshConnecttion()
        {
            ConStr = @"Data Source=" +  Properties.Settings.Default["SqlServer"] +
                    @";Initial Catalog=" + Properties.Settings.Default["sqlDatabase"] + ";" + Properties.Settings.Default["Authentication"];
            ConStrMaster = @"Data Source=" + Properties.Settings.Default["SqlServer"] +
                    @";Initial Catalog=master;" + Properties.Settings.Default["Authentication"];
        }

        public static Boolean checkConnection(string server, Boolean windowsLogin, string user, string password)
        {
            Boolean result = false;

            SqlConnection connMaster = new SqlConnection(@"Data Source=" + server + @";Initial Catalog=master;" + (windowsLogin ? "Integrated Security=True" : "User ID=" + user + ";Password=" + password));

            try
            {
                if (connMaster.State == ConnectionState.Closed)
                    connMaster.Open();

                result = true;
            }
            catch
            {
            }

            return result;
        }

        //public static void CreateDatabase(string dbName, string dtabase_MDF_Location)
        //{
        //    SqlConnection connMaster = new SqlConnection(ConStrMaster);

        //    try
        //    {
        //        string sqlQuery = string.Format("CREATE DATABASE {0} ON PRIMARY"
        //            + "(Name={0}, filename = '{1}\\{0}.mdf', size=3,filegrowth=10%)log on"
        //            + "(name={0}_log, filename='{1}\\{0}_log.ldf', size=3,"
        //            + "filegrowth=1)", dbName, dtabase_MDF_Location);

        //        if (connMaster.State == ConnectionState.Closed)
        //            connMaster.Open();

        //        SqlCommand com = new SqlCommand(sqlQuery, connMaster);
        //        com.ExecuteNonQuery();

        //    }
        //    catch (Exception ex)
        //    {
        //        //Log.AddLog(ex.ToString());
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        if (connMaster.State == ConnectionState.Open)
        //            connMaster.Close();
        //    }
        //}

        public static DataTable SelectMaster(string Table, string select, string where, string order)
        {
            refreshConnecttion();

            SqlConnection connMaster = new SqlConnection(ConStrMaster);

            DataTable dt = new DataTable();
            try
            {
                if (connMaster.State == ConnectionState.Closed)
                    connMaster.Open();
                SqlDataAdapter sda = new SqlDataAdapter(string.Format("select {1} from {0} {2} {3}", Table.Trim(), select.Trim(),
                    (where.Trim() == "" ? "" : "where " + where),
                    (order.Trim() == "" ? "" : "order by " + order)),
                    connMaster);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                //Log.AddLog(ex.ToString());
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connMaster.State == ConnectionState.Open)
                    connMaster.Close();
            }

            return dt;
        }

        public static void QueryMaster(string query)
        {
            refreshConnecttion();

            SqlConnection connMaster = new SqlConnection(ConStrMaster);

            try
            {
                if (connMaster.State == ConnectionState.Closed)
                    connMaster.Open();

                SqlCommand com = new SqlCommand(query, connMaster);
                com.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Log.AddLog(ex.ToString());
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connMaster.State == ConnectionState.Open)
                    connMaster.Close();
            }
        }

        public static void Query(string query)
        {
            refreshConnecttion();

            SqlConnection conn = new SqlConnection(ConStr);

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand com = new SqlCommand(query, conn);
                com.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Log.AddLog(ex.ToString());
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public static DataTable SelectTable(string Table, string select, string where, string order)
        {
            refreshConnecttion();

            SqlConnection conn = new SqlConnection(ConStr);

            DataTable dt = new DataTable();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(string.Format("select {1} from {0} {2} {3}", Table.Trim(), select.Trim(), 
                    (where.Trim() == "" ? "" : "where " + where), 
                    (order.Trim() == "" ? "" : "order by " + order)), 
                    conn);
                sda.Fill(dt);
            }
            catch
            {
                //Dont use throw new Exception
                //throw new Exception(ex.Message); 
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                if(conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return dt;
        }

        public static void DeleteRow(string Table, string where)
        {
            refreshConnecttion();

            SqlConnection conn = new SqlConnection(ConStr);

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand com = new SqlCommand(string.Format("Delete from {0} {1}", Table,
                    (where.Trim() == "" ? "" : "where " + where)), conn);
                com.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public static long InsertRow(string Table, string Fields, string Values)
        {
            refreshConnecttion();

            SqlConnection conn = new SqlConnection(ConStr);

            long ID = -1;
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand com = new SqlCommand(string.Format("Insert Into {0} ({1}) values ({2})", Table, Fields, Values), conn);
                com.ExecuteNonQuery();

                com = new SqlCommand(string.Format("select Max(ID) from {0}", Table), conn);
                ID = Convert.ToInt64(com.ExecuteScalar());

            }
            catch (Exception ex)
            {
                //Log.AddLog(ex.ToString());
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return ID;
        }

        public static void UpdateRow(string Table, string set, string where)
        {
            refreshConnecttion();

            SqlConnection conn = new SqlConnection(ConStr);

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand com = new SqlCommand(string.Format("Update {0} SET {1} {2}", Table, set,
                    (where.Trim() == "" ? "" : "where " + where)), conn);
                com.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Log.AddLog(ex.ToString());
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

    }
}
