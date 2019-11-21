using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H2T_Material
{
    public static class mod_Material
    {
        public static int gnPhanHanh;
        //quyen su dung tren menu : "VIEW" va "UPDATE"
        public static string gsRight;
        public static string gsConnectionString;
        public static System.Data.SqlClient.SqlConnection gcnConnect = new System.Data.SqlClient.SqlConnection();
        public static string gsAccount;
        //id cua user tren SQLServer
        public static string gsUserID;
        public static string gsUserName;
        //path chua hinh san pham tren server
        public static string gsSanPhamPath;
        //path chua nguon tren server de load exe chuong trinh
        public static string gsSourcePath;
        //duong dan file exe tren may client
        public static string gsApplicationPath;
        //format : dd/mm/yyyy la ngay cua server
        public static string gsDate;
        public static string gsTime;
        //ma phong ban
        public static int gnMaPB;
        //Khai bao so cua tung module
        public static string sQuanTriHT = "01"; // 01010000 ::01... : module Quan tri he thong
        public static string sKHSX = "02";
        public static string gsCompanyCode;
    }
}
