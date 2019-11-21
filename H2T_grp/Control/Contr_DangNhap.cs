using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace H2T_grp
{
    class Contr_DangNhap
    {
        private string sMaNV;
        private string sPassword;

        public event err_DangNhapEventHandler err_DangNhap;
        public delegate void err_DangNhapEventHandler(string sMessage);

        public string MaNV
        {
            get
            {
                return sMaNV;
            }
            set
            {
                sMaNV = value;
            }
        }

        public string Password
        {
            get
            {
                return sPassword;
            }
            set
            {
                sPassword = value;
            }
        }

        public bool Test_Password(string sPass, string sAccount)
        {
            bool b = false;
            string str_MH;
            info_DangNhap objInfo = new info_DangNhap();
            Cls_EnDeCrypt objEnDe = new Cls_EnDeCrypt();

            objInfo.MaNV = sAccount;
            objInfo.getPassword();
            sPassword = objInfo.Password;
            str_MH = objEnDe.Encrypt(sPass, true);
            if (str_MH != sPassword)
            {
                b = false;
                if (err_DangNhap != null)
                {
                    err_DangNhap("Password wrong!.");
                }
            }
            else
            {
                b = true;
            }
            return b;
        }
        public string LoadUserID()
        {
            info_DangNhap objInfo = new info_DangNhap();
            return objInfo.getUserID();
        }
        public int LoadUser_CCode(string Manv, string ccode)
        {
            info_DangNhap objInfo = new info_DangNhap();
            DataSet ds = new DataSet();
            ds = objInfo.LoadUser_CCode(Manv, ccode);
            return int.Parse(ds.Tables[0].Rows[0][0].ToString());
        }

        public string Loadtranfer(string manv)
        {
            info_DangNhap objInfo = new info_DangNhap();
            string str = null;
            str = objInfo.gettranfer(manv);
            return str;
        }
    }
}
