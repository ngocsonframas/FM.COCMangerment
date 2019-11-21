using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace H2T_grp
{
    class info_DangNhap
    {
        //private string sMaNV;
        //private string sPassword;
        //private string sTranfer;

        // khai bao theo C#3.0
        public string MaNV { get; set; }
        public string Password { get; set; }
        public string Tranfer { get; set; }

        //public string MaNV
        //    {
        //        get { return sMaNV; }
        //        set { sMaNV = value; }
        //    }
        //public string Password
        //    {
        //        get { return sPassword; }
        //        set { sPassword = value; }
        //    }
        //public string Tranfer
        //    {
        //        get { return sTranfer; }
        //        set { sTranfer = value; }
        //    }

        public string getPassword()
        {
            string sSql = null;
            Cls_Main objCls = new Cls_Main();
            sSql = "select MatMa from DM_NhanVien where MaNV = '" + MaNV + "'";
            //Password = (string)objCls.GetData(sSql).Tables[0].Rows[0]["matma"];
            Password = (string)objCls.GetData_str(sSql);
            return Password;
        }
        public string gettranfer(string manv)
        {
            string sSql = null;
            Cls_Main objCls = new Cls_Main();
            sSql = "select tranfer from dm_nhanvien where manv = '" + manv + "'";
            //Tranfer = Convert.ToString(objCls.GetData(sSql).Tables[0].Rows[0]["tranfer"]);
            Tranfer = Convert.ToString(objCls.GetData(sSql));
            return Tranfer;
        }
        public string getUserID()
        {
            string sSql = null;
            Cls_Main objCls = new Cls_Main();
            sSql = "select user_name() as userid";
            //(string)objCls.GetData(sSql).Tables[0].Rows[0]["UserID"];
            return (string)objCls.GetData_str(sSql);
        }
        public DataSet LoadUser_CCode(string Manv, string ccode)
        {
            Cls_Main objCls = new Cls_Main();
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@MaNV");
            parasValue.Add(Manv);

            parasName.Add("@CCode");
            parasValue.Add(ccode);

            return objCls.modifyData_storedproc_ds("HT_USER_CCODE", parasName, parasValue);

            //string sSql = null;
            //sSql = "select user_name() as userid";
            ////(string)objCls.GetData(sSql).Tables[0].Rows[0]["UserID"];
            //return (string)objCls.GetData_str(sSql);
        }


    }
}
