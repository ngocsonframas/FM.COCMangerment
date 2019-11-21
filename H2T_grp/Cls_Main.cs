using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace H2T_grp
{
    class Cls_Main
    {
        public event err_MainEventHandler err_Main;
        public delegate void err_MainEventHandler(string sMessage);

        public DataSet GetData(string sSql)
        {
            DataSet ds_return = null;
            SqlDataAdapter daAdapter = new SqlDataAdapter();
            SqlCommand cmCommand = new SqlCommand();
            DataSet dsDataset = new DataSet();
            try
            {
                cmCommand.CommandText = sSql;
                cmCommand.CommandType = CommandType.Text;
                cmCommand.Connection = Program.gcnConnect;
                daAdapter.SelectCommand = cmCommand;
                daAdapter.Fill(dsDataset);
                ds_return = dsDataset;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }
            return ds_return;

        }
        public object GetData_str(string sSql)
        {
            object str = null;
            SqlDataAdapter daAdapter = new SqlDataAdapter();
            SqlCommand cmCommand = new SqlCommand();
            DataSet dsDataset = new DataSet();
            try
            {
                cmCommand.CommandText = sSql;
                cmCommand.CommandType = CommandType.Text;
                cmCommand.Connection = Program.gcnConnect;
                daAdapter.SelectCommand = cmCommand;
                daAdapter.Fill(dsDataset);
                if (dsDataset.Tables[0].Rows.Count != 0)
                {
                    str = dsDataset.Tables[0].Rows[0][0];
                }
                else
                {
                    str = "";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }
            return str;

        }
        public bool Exec_StoreProc(string sStoredProc, ArrayList _parasName, ArrayList _parasValue)
        {
            string sSql = null;
            SqlTransaction Trans = null;
            try
            {
                if (Program.gcnConnect == null)
                    return false;
                if (Program.gcnConnect.State == ConnectionState.Closed)
                    Program.gcnConnect.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = Program.gcnConnect;
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sStoredProc;

                sSql = cmd.CommandText + " ";
                int i = 0;
                for (i = 0; i <= _parasValue.Count - 1; i++)
                {
                    cmd.Parameters.Add(Convert.ToString(_parasName[i]), SqlDbType.NVarChar).Value = _parasValue[i];
                    sSql = sSql + _parasValue[i] + ",";
                }
                if (i > 0)
                {
                    sSql = sSql.Substring(0, sSql.Length - 1);
                }
                Trans = Program.gcnConnect.BeginTransaction();
                cmd.Transaction = Trans;
                cmd.ExecuteNonQuery();
                Trans.Commit();
                return true;
            }
            catch (Exception)
            {
                //RaiseEvent err_ChietTinh("Lá»—i rá»“i. " & ex.Message)
                MessageBox.Show("Lỗi");
                //Trans.Rollback()
                return false;
            }
        }
        public bool Exec_StoreProc1(string sStoredProc, ArrayList _parasName, ArrayList _parasValue)
        {
            //ConnectDB()
            string sSql = null;
            SqlTransaction Trans = null;
            try
            {
                if (Program.gcnConnect.State == ConnectionState.Closed)
                {
                    Program.gcnConnect.Open();
                }
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.gcnConnect;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sStoredProc;

                sSql = cmd.CommandText + " ";
                for (int i = 0; i <= _parasValue.Count - 1; i++)
                {
                    cmd.Parameters.Add(Convert.ToString(_parasName[i]), SqlDbType.NVarChar).Value = _parasValue[i];
                    sSql = sSql + _parasValue[i] + ",";
                }

                Trans = Program.gcnConnect.BeginTransaction();
                cmd.Transaction = Trans;
                cmd.ExecuteNonQuery();
                Trans.Commit();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
                Trans.Rollback();
                return false;
            }
        }
        public bool modifyData_storedproc(string sStoredProc, ArrayList _parasName, ArrayList _parasValue)
        {
            DataSet dsKetQua = new DataSet();
            string ssql = null;
            try
            {
                if (Program.gcnConnect == null)
                    return false;
                if (Program.gcnConnect.State == ConnectionState.Closed)
                {
                    Program.gcnConnect.Open();
                }
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.gcnConnect;
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sStoredProc;
                cmd.CommandTimeout = 0;
                for (int i = 0; i <= _parasValue.Count - 1; i++)
                {
                    cmd.Parameters.Add(Convert.ToString(_parasName[i]), SqlDbType.NVarChar).Value = _parasValue[i];
                    ssql = ssql + "," + _parasValue[i];
                }
                //MsgBox(ssql)
                da.SelectCommand = cmd;
                da.Fill(dsKetQua);
                //MsgBox("Tác vụ thành công", MsgBoxStyle.Information, "Thông báo!")
                return true;
            }
            catch (Exception)
            {
                //MsgBox("System error", MsgBoxStyle.Information, "Cảnh Báo")
                MessageBox.Show("Lỗi");
                return false;
                //If Not (tran Is Nothing) Then tran.Rollback()
                //Return False
            }
            finally
            {
                // conn.Close()
            }
        }
        public DataSet modifyData_storedproc_ds(string sStoredProc, ArrayList _parasName, ArrayList _parasValue)
        {
            DataSet dsKetQua = new DataSet();
            string ssql = null;
            try
            {
                if (Program.gcnConnect.State == ConnectionState.Closed)
                {
                    Program.gcnConnect.Open();
                }
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Program.gcnConnect;
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sStoredProc;
                cmd.CommandTimeout = 0;
                int i = 0;
                for (i = 0; i <= _parasValue.Count - 1; i++)
                {
                    cmd.Parameters.Add(Convert.ToString(_parasName[i]), SqlDbType.NVarChar).Value = _parasValue[i];
                    ssql = ssql + _parasValue[i] + "," ;
                }
                if (i > 0)
                {
                    ssql = ssql.Substring(0, ssql.Length - 1);
                }
                //MsgBox(ssql)
                da.SelectCommand = cmd;
                da.Fill(dsKetQua);
                //MsgBox("Tác vụ thành công", MsgBoxStyle.Information, "Thông báo!")
                return dsKetQua;
            }
            catch (Exception)
            {
                //MsgBox("System error", MsgBoxStyle.Information, "Cảnh Báo")
                MessageBox.Show("Lỗi");
                dsKetQua = null;
                return dsKetQua;
                //If Not (tran Is Nothing) Then tran.Rollback()
                //Return False
            }
            finally
            {
                // conn.Close()
            }
        }
        public bool ConnectDataBase()
        {
            bool connects = false;
            try
            {
                if (Program.gcnConnect.State == ConnectionState.Open)
                    Program.gcnConnect.Close();
                Program.gcnConnect.ConnectionString = Program.gsConnectionString;
                Program.gcnConnect.Open();
                connects = true;
            }
            catch (Exception)
            {
                // MessageBox.Show("Lỗi");
                connects = false;
                if (err_Main != null)
                {
                    err_Main("Không vào được server.");
                }
            }
            return connects;

        }
        public object GetValue(string Table, string Field, string Con)
        {
            object ds_r = null;
            //int i = 0;
            DataSet rs = null;
            Program.gcnConnect = new SqlConnection(Program.gsConnectionString);
            string sqlString = "";
            sqlString = "Select * From " + Table + " Where " + Con;
            SqlDataAdapter da = new SqlDataAdapter(sqlString, Program.gcnConnect);
            rs = new DataSet();
            da.Fill(rs, "Data");
            foreach (DataRow r in rs.Tables["Data"].Rows)
            {
                ds_r = r[Field];
            }
            Program.gcnConnect.Close();
            return ds_r;
        }
        public object GetValue_SQL(string SQL, string Field)
        {
            object ds_r = null;
            // int i = 0;
            DataSet rs = null;
            Program.gcnConnect = new SqlConnection(Program.gsConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(SQL, Program.gcnConnect);
            rs = new DataSet();
            da.Fill(rs, "Data");
            foreach (DataRow r in rs.Tables["Data"].Rows)
            {
                ds_r = r[Field];
            }
            Program.gcnConnect.Close();
            return ds_r;
        }

        public bool DupValue(string Table, string Con)
        {
            bool b = false;
            try
            {
                // int i = 0;
                DataSet rs = null;
                Program.gcnConnect = new SqlConnection(Program.gsConnectionString);
                string sqlString = null;
                sqlString = "Select * From " + Table + " Where " + Con;
                SqlDataAdapter da = new SqlDataAdapter(sqlString, Program.gcnConnect);
                rs = new DataSet();
                da.Fill(rs, "Data");
                if (rs.Tables["Data"].Rows.Count > 0)
                {
                    b = true;
                }
                else
                {
                    b = false;
                }
                Program.gcnConnect.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }
            finally
            {
                Program.gcnConnect.Close();
            }
            return b;

        }
        public static bool exe_sql(string sql)
        {
            //string sSql = null;
            SqlTransaction Trans = null;

            if (Program.gcnConnect.State == ConnectionState.Closed)
            {
            }
            try
            {
                if (Program.gcnConnect == null)
                    return false;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 0;
                cmd.Connection = Program.gcnConnect;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                Trans = Program.gcnConnect.BeginTransaction();
                cmd.Transaction = Trans;
                cmd.ExecuteNonQuery();
                Trans.Commit();
                return true;
            }
            catch (Exception)
            {
                Trans.Rollback();
                return false;
            }
        }
    }
}
