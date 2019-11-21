using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;

namespace H2T_Material
{
    public class Info_ItemColorSize
    {
        Cls_Material cls = new Cls_Material();
        string sSql;

        public DataSet GetNgayServer()
        {
            sSql = "select GETDATE()";
            return cls.GetData(sSql);
        }
        #region Form Item Color Size
        public DataSet GetDataItemCS(string ItemNo)
        {

            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@ItemNo");
            parasValue.Add(ItemNo);

            return cls.Exec_StoreProc_dataset("MM_ItemCSList", parasName, parasValue);
        }
        public DataSet GetDataItemCSPP(string ItemNo)
        {

            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@ItemNo");
            parasValue.Add(ItemNo);

            return cls.Exec_StoreProc_dataset("MM_ItemCSListPP", parasName, parasValue);
        }
        public DataSet GetDataMaterial(string ItemNo)
        {

            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@ItemNo");
            parasValue.Add(ItemNo);

            return cls.Exec_StoreProc_dataset("MM_MaterialList", parasName, parasValue);
        }
        public DataSet GetDataReferItemCS(int flag)
        {

            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@Flag");
            parasValue.Add(flag);

            return cls.Exec_StoreProc_dataset("MM_ItemWLList", parasName, parasValue);
        }
        public DataSet GetItemColorSizeCopy(int Kind)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@Kind");
            parasValue.Add(Kind);

            parasName.Add("@V_USERID");
            parasValue.Add(mod_Material.gsAccount);

            return cls.Exec_StoreProc_dataset("[usp_GetItemCSCopy]", parasName, parasValue);
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

        public DataSet GetCustomerName(string name)
        {
            sSql = "select CustomerID,Name,[Description] from SP_CustomerName where Name like '%" + name + "%'";
            return cls.GetData(sSql);
        }
        public int SaveItemColorSize(Cls_ItemColorSize clsICS)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();
            #region paramater
            parasName.Add("@Flag");
            parasValue.Add(clsICS.FlagICS);

            parasName.Add("@ID");
            parasValue.Add(clsICS.IDColorSize);

            parasName.Add("@ItemNo");
            parasValue.Add(clsICS.ItemNo);

            parasName.Add("@ItemName");
            parasValue.Add(clsICS.ItemName);

            parasName.Add("@ParentID");
            parasValue.Add(clsICS.ParentItem);

            parasName.Add("@CodeColorSize");
            parasValue.Add(clsICS.CodeColorSize);

            parasName.Add("@Kind");
            parasValue.Add(clsICS.Kind);

            parasName.Add("@ItemNoWL");
            parasValue.Add(clsICS.ItemNoWL);

            parasName.Add("@ColorNoWL");
            parasValue.Add(clsICS.ColorNoWL);

            parasName.Add("@SizeNoWL");
            parasValue.Add(clsICS.SizeNoWL);

            parasName.Add("@CycleTime");
            parasValue.Add(clsICS.CycleTime);

            parasName.Add("@IsTrue");
            parasValue.Add(-1);
            #endregion
            return cls.Exec_StoreProcReturn("MM_ItemCSSaveV2", parasName, parasValue);
        }
        #endregion
    }
}
