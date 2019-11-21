using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace H2T_Material
{
    public class Info_BoM
    {
        Cls_Material cls = new Cls_Material();
        string sSql;

        public DataSet GetNgayServer()
        {
            sSql = "select GETDATE()";
            return cls.GetData(sSql);
        }
        #region Form BoM
        public DataSet GetDataBoMHeader(string ItemNo)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@ItemNo");
            parasValue.Add(ItemNo);

            return cls.Exec_StoreProc_dataset("MM_BoMListV1", parasName, parasValue);
        }
        public DataSet GetDataMaterial(string ItemNo)
        {

            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@ItemNo");
            parasValue.Add(ItemNo);

            return cls.Exec_StoreProc_dataset("MM_MaterialList", parasName, parasValue);
        }
        public DataSet GetBoMDetail(int BoMHID,string ItemNo)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@BoMHID");
            parasValue.Add(BoMHID);

            parasName.Add("@ItemNo");
            parasValue.Add(ItemNo);

            return cls.Exec_StoreProc_dataset("[MM_BoMDetailListV2]", parasName, parasValue);
        }
        public int DeleteItemCS(Cls_ItemColorSize clsItemCS)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@oNo");
            if (clsItemCS.FlagICS == 0)
            {
                parasValue.Add(clsItemCS.ItemNo);
            }
            else if (clsItemCS.FlagICS == 1)
            {
                parasValue.Add(clsItemCS.ColorID);
            }
            else if (clsItemCS.FlagICS == 2)
            {
                parasValue.Add(clsItemCS.SizeID);
            }

            parasName.Add("@flag");
            parasValue.Add(clsItemCS.FlagICS);

            parasName.Add("@IsTrue");
            parasValue.Add(-1);

            return cls.Exec_StoreProcReturn("[MM_ItemCSDel]", parasName, parasValue);
        }
        public int GetItemCSFrmWL(Cls_ItemColorSize clsItemCS)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@IsTrue");
            parasValue.Add(-1);

            return cls.Exec_StoreProcReturn("[MM_ItemCSSaveFrmWL]", parasName, parasValue);
        }
        public int GetMaterialFrmWL(Cls_ItemColorSize clsItemCS)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@IsTrue");
            parasValue.Add(-1);

            return cls.Exec_StoreProcReturn("[MM_MaterialSaveFrmWL]", parasName, parasValue);
        }
        public DataSet GetItemByID(string ItemNo)
        {
            sSql = "select ItemNo,ItemName from tblItem  where TypeID = 0 and ItemNo like '%" + ItemNo + "%'";
            return cls.GetData(sSql);
        }
        public DataSet GetItemByName(string ItemName)
        {
            sSql = "select ItemNo,ItemName from tblItem  where TypeID = 0 and ItemName like '%" + ItemName + "%'";
            return cls.GetData(sSql);
        }
        public DataSet GetColordlgByItem(string ItemNo,string ColorN)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@ItemNo");
            parasValue.Add(ItemNo);

            parasName.Add("@ColorName");
            parasValue.Add(ColorN);

            return cls.Exec_StoreProc_dataset("[MM_GetColordlgItem]", parasName, parasValue);
        }
        public DataSet GetMaterial()
        {
            sSql = "select ItemNo as MaterialNo,ItemName as MaterialName from tblItem  where TypeID = 1";
            return cls.GetData(sSql);
        }
        public DataSet SaveBoMHeader(Cls_BoM clsICS)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@BoMHID");
            parasValue.Add(clsICS.BoMHeaderID);

            parasName.Add("@Item");
            parasValue.Add(clsICS.ItemNo);

            parasName.Add("@TypeBoM");
            parasValue.Add(clsICS.TypeBoM);

            parasName.Add("@CreUser");
            parasValue.Add(clsICS.UserCre);

            return cls.Exec_StoreProc_dataset("[MM_SaveBoMH]", parasName, parasValue);
        }
        public int SaveBoMDetail(Cls_BoM clsB)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();
            #region paramater
            parasName.Add("@Level");
            parasValue.Add(clsB.level);

            parasName.Add("@CompItemID");
            parasValue.Add(clsB.CompItemID);

            parasName.Add("@BoMSizeID");
            parasValue.Add(clsB.BoMSizeID);

            parasName.Add("@BoMColorID");
            parasValue.Add(clsB.BoMColorID);

            parasName.Add("@ItemSizeID");
            parasValue.Add(clsB.ItemSizeID);

            parasName.Add("@ItemColorID");
            parasValue.Add(clsB.ItemColorID);

            parasName.Add("@ParentID");
            parasValue.Add(clsB.ParentID);

            parasName.Add("@MaterialNo");
            parasValue.Add(clsB.MaterialNo);

            parasName.Add("@Weight");
            parasValue.Add(clsB.Weight);

            parasName.Add("@WeightRunner");
            parasValue.Add(clsB.WeghitRunner);

            //parasName.Add("@DefectPercent");
            //parasValue.Add(clsB.DefectPercent);

            //parasName.Add("@RecycelPercent");
            //parasValue.Add(clsB.RecyclePercent);

            //parasName.Add("@CycelTimeMax");
            //parasValue.Add(clsB.CycleTimeMax);

            //parasName.Add("@MachineType");
            //parasValue.Add(clsB.MachineType);

            parasName.Add("@BomHID");
            parasValue.Add(clsB.BoMHeaderID);

            parasName.Add("@IsTrue");
            parasValue.Add(-1);
            #endregion
            return cls.Exec_StoreProcReturn("MM_SaveBoMDV2", parasName, parasValue);
        }
        public DataSet SaveBoMHeaderComp(Cls_BoM clsICS)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@BoMHID");
            parasValue.Add(clsICS.BoMHeaderID);

            parasName.Add("@Item");
            parasValue.Add(clsICS.ItemNo);

            parasName.Add("@ColorNo");
            parasValue.Add(clsICS.ColorNo);

            parasName.Add("@ItemColorID_H");
            parasValue.Add(clsICS.ItemColorID_Header);

            return cls.Exec_StoreProc_dataset("[SP_SaveBoMHCompV2.1]", parasName, parasValue);
        }
        public DataSet GetBoMIndex(string tablename,string Username)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@tblName");
            parasValue.Add(tablename);

            parasName.Add("@V_USERID");
            parasValue.Add(Username);

            return cls.Exec_StoreProc_dataset("[usp_GetTblIndex]", parasName, parasValue);
        }
        public DataSet GetSizedlg(string ItemNo)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@ItemNo");
            parasValue.Add(ItemNo);

            return cls.Exec_StoreProc_dataset("[MM_GetSizedlgBoM]", parasName, parasValue);
        }
        public DataSet GetSizedlgV1(string ItemNo)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@ItemNo");
            parasValue.Add(ItemNo);

            return cls.Exec_StoreProc_dataset("[MM_GetSizedlgBoMV1]", parasName, parasValue);
        }
        public DataSet GetColordlg(string ItemNo)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@ItemNo");
            parasValue.Add(ItemNo);

            return cls.Exec_StoreProc_dataset("[MM_GetColordlgBoM]", parasName, parasValue);
        }
        public DataSet GetColordlgV1(string ItemNo)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@ItemNo");
            parasValue.Add(ItemNo);

            return cls.Exec_StoreProc_dataset("[MM_GetColordlgBoMV1]", parasName, parasValue);
        }
        public DataSet GetMaterialdlg()
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@user");
            parasValue.Add(mod_Material.gsAccount);

            return cls.Exec_StoreProc_dataset("[MM_GetMaterialdlgBoM]", parasName, parasValue);
        }
        public DataSet GetMaterialdlgV1()
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@user");
            parasValue.Add(mod_Material.gsAccount);

            return cls.Exec_StoreProc_dataset("[MM_GetMaterialdlgBoMV1]", parasName, parasValue);
        }
        public DataSet GetComponentdlgV1(string ItemNo)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@ItemNo");
            parasValue.Add(ItemNo);

            return cls.Exec_StoreProc_dataset("[MM_GetCompdlgBoMV1]", parasName, parasValue);
        }
        #endregion
        #region MRP
        public DataSet GetGird(long OrderID, long ItemColorID)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@OrderID");
            parasValue.Add(OrderID);

            parasName.Add("@ItemColor_ID");
            parasValue.Add(ItemColorID);

            return cls.Exec_StoreProc_dataset("MM_MRPV1", parasName, parasValue);
        }
        public DataSet GetOrder_PoNum(string PONUm)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@PONum");
            parasValue.Add(PONUm);

            return cls.Exec_StoreProc_dataset("[MM_GetOrder_PONumV1]", parasName, parasValue);
        }
        public DataSet GetOrder_PoNumV(string PONUm)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@PONum");
            parasValue.Add(PONUm);

            return cls.Exec_StoreProc_dataset("[MM_GetOrder_PONumV2]", parasName, parasValue);
        }
        #endregion
    }
}
