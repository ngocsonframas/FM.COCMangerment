using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace H2T_grp
{
    class Contr_frm_Main
    {
        private DataSet ds_DataSet = new DataSet();
        public string sUserName { get; set; }
        public string sDate { get; set; }
        public string sTime { get; set; }
        public int nMaPB { get; set; }
        public string sTenPB { get; set; }
        public DataSet MenuRows { get; set; }


        public void LoadMenu(string sMaNV, int nPhanHanh)
        {
            info_frm_Main obj_info_Main = new info_frm_Main();
            obj_info_Main.nPhanHanh = nPhanHanh;
            obj_info_Main.sMaNV = sMaNV;
            ds_DataSet = obj_info_Main.getMenu();
        }

        public DataSet LoadMenu_ds(string sMaNV, int nPhanHanh)
        {
            info_frm_Main obj_info_Main = new info_frm_Main();
            obj_info_Main.nPhanHanh = nPhanHanh;
            obj_info_Main.sMaNV = sMaNV;
            ds_DataSet = obj_info_Main.getMenu();
            return ds_DataSet;
        }

        public void LoadInfo(string sMaNV)
        {
            DataSet ds = new DataSet();
            info_frm_Main obj_in_Main = new info_frm_Main();
            obj_in_Main.sMaNV = sMaNV;
            ds = obj_in_Main.getInfo();
            sUserName = (string)ds.Tables[0].Rows[0]["tennv"];
            sDate = (string)ds.Tables[0].Rows[0]["ngay"];
            sTime = String.Format((string)ds.Tables[0].Rows[0]["gio"], "hh:mm:ss");
            nMaPB = (int)ds.Tables[0].Rows[0]["MaPB"];
            sTenPB = (string)ds.Tables[0].Rows[0]["TenPB"];
        }

    }
}
