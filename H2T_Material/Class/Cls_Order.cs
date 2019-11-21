using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace H2T_Material
{
    public class Cls_Order
    {
          static  Cls_FileINI cls = new Cls_FileINI();
          static  Cls_EnDeCrypt objEnDe = new Cls_EnDeCrypt();

        static string gsApplicationPath = Application.StartupPath;
        static string path = gsApplicationPath + "\\Extension\\WL.ini";
        static string path_Indo = gsApplicationPath + "\\Extension\\WLIndo.ini";
        static string path_FZ = gsApplicationPath + "\\Extension\\WLFZ.ini";
        static string path_KV = gsApplicationPath + "\\Extension\\WLKV.ini";

        public static string gsConnectionString = objEnDe.Decrypt(cls.ReadValue("system", "ConnectionString", path), true);
        public static string gsConnectionStringIndo = objEnDe.Decrypt(cls.ReadValue("system", "ConnectionString", path_Indo), true);
        public static string gsConnectionStringFZ = objEnDe.Decrypt(cls.ReadValue("system", "ConnectionString", path_FZ), true);
        public static string gsConnectionStringKV = objEnDe.Decrypt(cls.ReadValue("system", "ConnectionString", path_KV), true);

        #region cac phuong thuc lay du lieu
        //public static string gsConnectionString = "Data Source=server210;Initial Catalog=VNT86;User ID=sa;Password=Fdw24$110;Connect Timeout=3600000";
        public static SqlConnection gcnConnect = new SqlConnection();

        public bool ConnectDataBase()
        {
            bool connects = false;
            try
            {
                if (gcnConnect.State == ConnectionState.Open)
                    gcnConnect.Close();
                gcnConnect.ConnectionString = gsConnectionString;
                gcnConnect.Open();
                connects = true;
            }
            catch (Exception)
            {
                // MessageBox.Show("Lỗi");
                connects = false;
                    MessageBox.Show("Không vào được server.");
            }
            return connects;

        }
        public bool ConnectDataBaseIndo()
        {
            bool connects = false;
            try
            {
               if (gcnConnect.State == ConnectionState.Open)
                    gcnConnect.Close();
                gcnConnect.ConnectionString = gsConnectionStringIndo;
                gcnConnect.Open();
                connects = true;
            }
            catch (Exception)
            {
                // MessageBox.Show("Lỗi");
                connects = false;
                MessageBox.Show("Không vào được server.");
            }
            return connects;

        }
        public bool ConnectDataBaseFZ()
        {
            bool connects = false;
            try
            {
                if (gcnConnect.State == ConnectionState.Open)
                    gcnConnect.Close();
                gcnConnect.ConnectionString = gsConnectionStringFZ;
                gcnConnect.Open();
                connects = true;
            }
            catch (Exception)
            {
                // MessageBox.Show("Lỗi");
                connects = false;
                MessageBox.Show("Không vào được server.");
            }
            return connects;

        }
        public bool ConnectDataBaseKV()
        {
            bool connects = false;
            try
            {
                if (gcnConnect.State == ConnectionState.Open)
                    gcnConnect.Close();
                gcnConnect.ConnectionString = gsConnectionStringKV;
                gcnConnect.Open();
                connects = true;
            }
            catch (Exception)
            {
                // MessageBox.Show("Lỗi");
                connects = false;
                MessageBox.Show("Không vào được server.");
            }
            return connects;

        }
        public bool Exec_StoreProc(string sStoreProc, ArrayList _parasName, ArrayList _parasValue)
        {
            string sSql = null;
            SqlTransaction Trans = null;
            try
            {
                if (gcnConnect == null)
                {
                    return false;
                }
                else
                {
                    if (gcnConnect.State == ConnectionState.Closed)
                    {
                        gcnConnect.Open();
                    }
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = gcnConnect;
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sStoreProc;
                    sSql = cmd.CommandText + " ";
                    int i;
                    for (i = 0; i <= _parasValue.Count - 1; i++)
                    {
                        cmd.Parameters.Add(Convert.ToString(_parasName[i]), SqlDbType.NVarChar).Value = _parasValue[i];

                        sSql = sSql + _parasValue[i] + ",";
                    }
                    if (i > 0)
                    {
                        sSql = sSql.Substring(0, sSql.Length - 1);
                    }
                    Trans = gcnConnect.BeginTransaction();
                    cmd.Transaction = Trans;
                    cmd.ExecuteNonQuery();
                    Trans.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!" + ex.Message);
                Trans.Rollback();
                return false;
            }
        }
        public int Exec_StoreProcReturn(string sStoreProc, ArrayList _parasName, ArrayList _parasValue)
        {
            string sSql = null;
            SqlTransaction Trans = null;
            int h = 0;
            try
            {
                if (gcnConnect == null)
                {

                }
                else
                {
                    if (gcnConnect.State == ConnectionState.Closed)
                    {
                        gcnConnect.Open();
                    }
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = gcnConnect;
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sStoreProc;
                    sSql = cmd.CommandText + " ";
                    int i;

                    for (i = 0; i <= _parasValue.Count - 1; i++)
                    {
                        if (_parasValue[i].ToString() == "-1" && _parasName[i].ToString() == "@IsTrue")
                        {
                            SqlParameter outputParam = new SqlParameter(Convert.ToString(_parasName[i]), SqlDbType.Int);
                            outputParam.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(outputParam);
                        }
                        else
                        {
                            cmd.Parameters.Add(Convert.ToString(_parasName[i]), SqlDbType.NVarChar).Value = _parasValue[i];
                        }
                        sSql = sSql + _parasValue[i] + ",";
                    }
                    if (i > 0)
                    {
                        sSql = sSql.Substring(0, sSql.Length - 1);
                    }
                    Trans = gcnConnect.BeginTransaction();
                    cmd.Transaction = Trans;
                    h = cmd.ExecuteNonQuery();
                    Trans.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!" + ex.Message);
                Trans.Rollback();
                h = 0;
            }
            return h;
        }
        public DataSet Exec_StoreProc_dataset(string sStoreProc, ArrayList _parasName, ArrayList _parasValue)
        {
            string sSql = null;
            SqlTransaction Trans = null;
            DataSet ds = new DataSet();
            try
            {
                if (gcnConnect == null)
                {
                    return ds;
                }
                else
                {
                    if (gcnConnect.State == ConnectionState.Closed)
                    {
                        gcnConnect.Open();
                    }
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    cmd.Connection = gcnConnect;
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sStoreProc;
                    sSql = cmd.CommandText + " ";
                    int i;
                    for (i = 0; i <= _parasValue.Count - 1; i++)
                    {
                        cmd.Parameters.Add(Convert.ToString(_parasName[i]), SqlDbType.NVarChar).Value = _parasValue[i];

                        sSql = sSql + _parasValue[i] + ",";
                    }
                    if (i > 0)
                    {
                        sSql = sSql.Substring(0, sSql.Length - 1);
                    }
                    Trans = gcnConnect.BeginTransaction();
                    cmd.Transaction = Trans;
                    da.SelectCommand = cmd;
                    da.Fill(ds, "0");
                    //cmd.ExecuteNonQuery();
                    Trans.Commit();
                    return ds;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!" + ex.Message);
                Trans.Rollback();
                return ds;
                //return false;
            }
        }
        public DataSet Exec_StoreProc_dataset_sName(string sStoreProc, ArrayList _parasName, ArrayList _parasValue, string name)
        {
            string sSql = null;
            SqlTransaction Trans = null;
            DataSet ds = new DataSet();
            try
            {
                if (gcnConnect == null)
                {
                    return ds;
                }
                else
                {
                    if (gcnConnect.State == ConnectionState.Closed)
                    {
                        gcnConnect.Open();
                    }
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    cmd.Connection = gcnConnect;
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sStoreProc;
                    sSql = cmd.CommandText + "  ";
                    int i;
                    for (i = 0; i <= _parasValue.Count - 1; i++)
                    {
                        cmd.Parameters.Add(Convert.ToString(_parasName[i]), SqlDbType.NVarChar).Value = _parasValue[i];
                        sSql = sSql + _parasValue[i] + ",";
                    }
                    if (i > 0)
                    {
                        sSql = sSql.Substring(0, sSql.Length - 1);
                    }
                    Trans = mod_Material.gcnConnect.BeginTransaction();
                    cmd.Transaction = Trans;
                    da.SelectCommand = cmd;
                    da.Fill(ds, name);
                    Trans.Commit();
                    return ds;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Trans.Rollback();
                return ds;
            }
        }
        public bool Exec_StoreProc_pic(string sStoredProc, ArrayList _parasName, ArrayList _parasValue, Byte[] ChuKy)
        {
            string sSql = null;
            SqlTransaction Trans = null;
            try
            {
                if (gcnConnect == null)
                    return false;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = gcnConnect;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sStoredProc;

                sSql = cmd.CommandText + " ";
                for (int i = 0; i <= _parasValue.Count - 1; i++)
                {
                    if ((Convert.ToString(_parasName[i]).Equals("@ImgBarC")))
                    {
                        cmd.Parameters.Add("@ImgBarC", SqlDbType.Image).Value = ChuKy;
                    }
                    else
                    {
                        cmd.Parameters.Add(Convert.ToString(_parasName[i]), SqlDbType.NVarChar).Value = _parasValue[i];
                    }
                    //  sSql = sSql & _parasValue.Item(i) & ","
                    //cmd.Parameters.Add("@image", SqlDbType.Image).Value = buffer
                }

                Trans = gcnConnect.BeginTransaction();
                cmd.Transaction = Trans;
                cmd.ExecuteNonQuery();
                Trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
                Trans.Rollback();
                return false;
            }
        }
        public DataSet GetData(string sSql)
        {
            SqlDataAdapter daAdapter = new SqlDataAdapter();
            SqlCommand cmCommand = new SqlCommand();
            DataSet dsDataset = new DataSet();
            try
            {
                cmCommand.CommandText = sSql;
                cmCommand.CommandType = CommandType.Text;
                cmCommand.Connection = gcnConnect;
                cmCommand.CommandTimeout = 0;
                daAdapter.SelectCommand = cmCommand;
                daAdapter.Fill(dsDataset);
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hàm lấy dữ liệu!");
                //RaiseEvent err_ChietTinh("KhÃ´ng thá»±c hiá»‡n Ä‘Æ°á»£c.")
            }
            return dsDataset;
        }
        public bool IsEmpty(DataSet dataSet)
        {
            foreach (DataTable table in dataSet.Tables)
                if (table.Rows.Count != 0)
                    return false;
            return true;
        }
        public Boolean CheckExistData(string sSql)
        {
            SqlDataAdapter daAdapter = new SqlDataAdapter();
            SqlCommand cmCommand = new SqlCommand();
            DataSet dsDataset = new DataSet();
            try
            {
                cmCommand.CommandText = sSql;
                cmCommand.CommandType = CommandType.Text;
                cmCommand.Connection = gcnConnect;
                cmCommand.CommandTimeout = 0;
                daAdapter.SelectCommand = cmCommand;
                daAdapter.Fill(dsDataset);
                if (dsDataset.Tables[0].Rows.Count > 0 && this.IsEmpty(dsDataset) == false)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi hàm lấy dữ liệu!");
                //RaiseEvent err_ChietTinh("KhÃ´ng thá»±c hiá»‡n Ä‘Æ°á»£c.")
            }
            return false;
        }
        public bool ImportMDBSitetoBangSQL_T(string MDBPath, string str_Table, string site)
        {
            string sSql = null;
            SqlTransaction Trans = null;
            try
            {
                if (gcnConnect == null)
                {
                    return false;
                }
                else
                {
                    if (gcnConnect.State == ConnectionState.Closed)
                    {
                        gcnConnect.Open();
                    }

                    string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + MDBPath + "';Jet OLEDB:Database Password=fantachiro201204";

                    String[] str = str_Table.Split(new Char[] { '|' });

                    foreach (var item in str)
                    {
                        using (var sourceConnection = new OleDbConnection(connectionString))
                        {
                            sourceConnection.Open();

                            var commandSourceData = new OleDbCommand("SELECT * FROM " + item + ";", sourceConnection);
                            var reader = commandSourceData.ExecuteReader();

                            using (var destinationConnection = new SqlConnection(gsConnectionString))
                            {
                                destinationConnection.Open();

                                using (var bulkCopy = new SqlBulkCopy(destinationConnection))
                                {
                                    bulkCopy.DestinationTableName = "dbo." + item.Substring(0, 4) + site + "00" + "IET";
                                    try
                                    {
                                        bulkCopy.BulkCopyTimeout = 0;
                                        bulkCopy.WriteToServer(reader);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                        MessageBox.Show("Data " + item + "exist !");
                                    }
                                    finally
                                    {
                                        reader.Close();
                                        sourceConnection.Close();
                                        destinationConnection.Close();
                                    }
                                }

                            }
                        }
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!" + ex.Message);
                Trans.Rollback();
                return false;
            }
        }
        public bool Exec_SQL(string sql)
        {
            SqlTransaction Trans = null;
            if (gcnConnect.State == ConnectionState.Closed)
            {
                gcnConnect.Open();
            }
            try
            {
                if (gcnConnect == null)
                    return false;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 0;
                cmd.Connection = gcnConnect;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                Trans = mod_Material.gcnConnect.BeginTransaction();
                cmd.Transaction = Trans;
                cmd.ExecuteNonQuery();
                Trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Trans.Rollback();
                return false;
            }
        }
        public bool ImportMDBtoBangSQL_T(string MDBPath, string str_Table)
        {
            string sSql = null;
            SqlTransaction Trans = null;
            try
            {
                if (gcnConnect == null)
                {
                    return false;
                }
                else
                {
                    if (gcnConnect.State == ConnectionState.Closed)
                    {
                        gcnConnect.Open();
                    }

                    string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + MDBPath + "';Jet OLEDB:Database Password=fantachiro201204";

                    String[] str = str_Table.Split(new Char[] { '|' });

                    foreach (var item in str)
                    {
                        using (var sourceConnection = new OleDbConnection(connectionString))
                        {
                            sourceConnection.Open();

                            var commandSourceData = new OleDbCommand("SELECT * FROM " + item + ";", sourceConnection);
                            var reader = commandSourceData.ExecuteReader();

                            using (var destinationConnection = new SqlConnection(gsConnectionString))
                            {
                                destinationConnection.Open();

                                using (var bulkCopy = new SqlBulkCopy(destinationConnection))
                                {
                                    bulkCopy.DestinationTableName = "dbo." + item.Substring(0, 4) + "" + "00" + "T";
                                    try
                                    {
                                        bulkCopy.BulkCopyTimeout = 0;
                                        bulkCopy.WriteToServer(reader);
                                    }
                                    catch (Exception ex)
                                    {
                                        // MessageBox.Show(ex.Message);
                                        MessageBox.Show("Data " + item + "exist !");
                                    }
                                    finally
                                    {
                                        reader.Close();
                                        sourceConnection.Close();
                                        destinationConnection.Close();
                                    }
                                }

                            }
                        }
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!" + ex.Message);
                Trans.Rollback();
                return false;
            }
        }

        #endregion
    }
}
