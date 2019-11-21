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
    public class Cls_Material
    {
        #region Property
        public int MaPB
        {
            get
            {
                return mod_Material.gnMaPB;
            }
            set
            {
                mod_Material.gnMaPB = value;
            }
        }
        // public static string gsCompanyCode;
        public string gsCompanyCode
        {
            get
            {
                return mod_Material.gsCompanyCode;
            }
            set
            {
                mod_Material.gsCompanyCode = value;
            }
        }
        public string UserID
        {
            get
            {
                return mod_Material.gsUserID;
            }
            set
            {
                mod_Material.gsUserID = value;
            }
        }
        public string GTime
        {
            get
            {
                return mod_Material.gsTime;
            }
            set
            {
                mod_Material.gsTime = value;
            }
        }
        public string GDate
        {
            get
            {
                return mod_Material.gsDate;
            }
            set
            {
                mod_Material.gsDate = value;
            }
        }
        public string ApplicationPath
        {
            get
            {
                return mod_Material.gsApplicationPath;
            }
            set
            {
                mod_Material.gsApplicationPath = value;
            }
        }
        public string SourcePath
        {
            get
            {
                return mod_Material.gsSourcePath;
            }
            set
            {
                mod_Material.gsSourcePath = value;
            }
        }
        public string UserName
        {
            get
            {
                return mod_Material.gsUserName;
            }
            set
            {
                mod_Material.gsUserName = value;
            }
        }
        public string Account
        {
            get
            {
                return mod_Material.gsAccount;
            }
            set
            {
                mod_Material.gsAccount = value;
            }
        }
        public SqlConnection CnConnect
        {
            get
            {
                return mod_Material.gcnConnect;
            }
            set
            {
                mod_Material.gcnConnect = value;
            }
        }
        public int PhanHanh
        {
            get
            {
                return mod_Material.gnPhanHanh;
            }
            set
            {
                mod_Material.gnPhanHanh = value;
            }
        }
        public string Right
        {
            get
            {
                return mod_Material.gsRight;
            }
            set
            {
                mod_Material.gsRight = value;
            }
        }
        public string SanPhamPath
        {
            get
            {
                return mod_Material.gsSanPhamPath;
            }
            set
            {
                mod_Material.gsSanPhamPath = value;
            }
        }
        public string ConnectionString
        {
            get
            {
                return mod_Material.gsConnectionString;
            }
            set
            {
                mod_Material.gsConnectionString = value;
            }
        }
        #endregion
        #region cac phuong thuc lay du lieu
        public bool Exec_StoreProc(string sStoreProc, ArrayList _parasName, ArrayList _parasValue)
        {
            string sSql = null;
            SqlTransaction Trans = null;
            try
            {
                if (mod_Material.gcnConnect == null)
                {
                    return false;
                }
                else
                {
                    if (mod_Material.gcnConnect.State == ConnectionState.Closed)
                    {
                        mod_Material.gcnConnect.Open();
                    }
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = mod_Material.gcnConnect;
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
                    Trans = mod_Material.gcnConnect.BeginTransaction();
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
                if (mod_Material.gcnConnect == null)
                {

                }
                else
                {
                    if (mod_Material.gcnConnect.State == ConnectionState.Closed)
                    {
                        mod_Material.gcnConnect.Open();
                    }
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = mod_Material.gcnConnect;
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sStoreProc;
                    sSql = cmd.CommandText + " ";
                    int i;

                    for (i = 0; i <= _parasValue.Count - 1; i++)
                    {
                        if (_parasValue[i].ToString() == "-1" && _parasName[i].ToString()=="@IsTrue")
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
                    Trans = mod_Material.gcnConnect.BeginTransaction();
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
                if (mod_Material.gcnConnect == null)
                {
                    return ds;
                }
                else
                {
                    if (mod_Material.gcnConnect.State == ConnectionState.Closed)
                    {
                        mod_Material.gcnConnect.Open();
                    }
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    cmd.Connection = mod_Material.gcnConnect;
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
                    Trans = mod_Material.gcnConnect.BeginTransaction();
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
                if (mod_Material.gcnConnect == null)
                {
                    return ds;
                }
                else
                {
                    if (mod_Material.gcnConnect.State == ConnectionState.Closed)
                    {
                        mod_Material.gcnConnect.Open();
                    }
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    cmd.Connection = mod_Material.gcnConnect;
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
                if (mod_Material.gcnConnect == null)
                    return false;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = mod_Material.gcnConnect;
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

                Trans = mod_Material.gcnConnect.BeginTransaction();
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
                cmCommand.Connection = mod_Material.gcnConnect;
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
                cmCommand.Connection = mod_Material.gcnConnect;
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
                if (mod_Material.gcnConnect == null)
                {
                    return false;
                }
                else
                {
                    if (mod_Material.gcnConnect.State == ConnectionState.Closed)
                    {
                        mod_Material.gcnConnect.Open();
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

                            using (var destinationConnection = new SqlConnection(mod_Material.gsConnectionString))
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
            if (mod_Material.gcnConnect.State == ConnectionState.Closed)
            {
                mod_Material.gcnConnect.Open();
            }
            try
            {
                if (mod_Material.gcnConnect == null)
                    return false;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 0;
                cmd.Connection = mod_Material.gcnConnect;
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
                if (mod_Material.gcnConnect == null)
                {
                    return false;
                }
                else
                {
                    if (mod_Material.gcnConnect.State == ConnectionState.Closed)
                    {
                        mod_Material.gcnConnect.Open();
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

                            using (var destinationConnection = new SqlConnection(mod_Material.gsConnectionString))
                            {
                                destinationConnection.Open();

                                using (var bulkCopy = new SqlBulkCopy(destinationConnection))
                                {
                                    bulkCopy.DestinationTableName = "dbo." + item.Substring(0, 4) + mod_Material.gsCompanyCode + "00" + "T";
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
