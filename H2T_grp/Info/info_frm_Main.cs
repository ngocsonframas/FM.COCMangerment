using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace H2T_grp
{
    class info_frm_Main
    {
        public string sMaNV { get; set; }
        public int nPhanHanh { get; set; }

        public  DataSet getMenu()
        {
            Cls_Main obj_Main = new Cls_Main();
            String sSQL = "select TenMenu,CapBat,TenForm,TenClass,STT,Quyen from HT_F_LoadMenu('" + sMaNV + "'," + nPhanHanh + ")  order by STT";
            return obj_Main.GetData(sSQL);
        }
        public DataSet getInfo()
        {
            Cls_Main obj_Main = new Cls_Main();
            String sSQL = "select a.MaPB,b.TenPB, a.TenNV,REPLICATE('0',2 - len(cast(day(getdate()) as varchar))) + cast(day(getdate()) as varchar) " + " + '/' + REPLICATE('0',2 - len(cast(month(getdate()) as varchar))) + cast(month(getdate()) as varchar) " + " + '/' +  cast(year(getdate()) as varchar) as ngay,convert(varchar, getdate(), 114) as gio" + " from DM_NhanVien a inner join DM_PhongBan b on a.MaPB = b.MaPB where a.MaNV = '" + sMaNV + "'";
            return obj_Main.GetData(sSQL);
        }
    }
}
