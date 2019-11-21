using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace H2T_Material
{
    public class Inf_Order
    {
        Cls_Order cls = new Cls_Order();
        string sSql;

        public DataSet GetNgayServer()
        {
            sSql = "select GETDATE()";
            return cls.GetData(sSql);
        }
        public DataSet GetDateTimeGMTServer()
        {
            sSql = "SELECT left(CONVERT(VARCHAR(50), GETDATE(), 127),len(CONVERT(VARCHAR(50), GETDATE(), 127))-4)";
            return cls.GetData(sSql);
        }
        public DataSet LoadAccountNumber(string AccountNameText)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@NameText");
            parasValue.Add(AccountNameText);

            return cls.Exec_StoreProc_dataset("[SP_EXI_AccountInvList]", parasName, parasValue);
        }
        public DataSet LoadAccountByNumber(string AccountNumber)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@V_AccNo");
            parasValue.Add(AccountNumber);

            return cls.Exec_StoreProc_dataset("[SP_AccountInvList]", parasName, parasValue);
        }
        public DataSet LoadAccountByNumberV5(string T1Code, string FiscalYear, string CompanyCode)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@V_T1Code");
            parasValue.Add(T1Code);

            parasName.Add("@V_FiscalYear");
            parasValue.Add(FiscalYear);

            parasName.Add("@V_CompanyCode");
            parasValue.Add(CompanyCode);

            return cls.Exec_StoreProc_dataset("[SP_AccountInvListV5]", parasName, parasValue);
        }
        public DataSet LoadDelivery(string DeliveryText)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@NameText");
            parasValue.Add(DeliveryText);

            return cls.Exec_StoreProc_dataset("[SP_EXI_DeliveryInvList]", parasName, parasValue);
        }
        public DataSet LoadDeliveryNumber(string DeliveryNumber)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@V_AccNo");
            parasValue.Add(DeliveryNumber);

            return cls.Exec_StoreProc_dataset("[SP_DeliveryInvList]", parasName, parasValue);
        }
        public DataSet LoadDeliveryNumberV5(string DeliveryNumber, string FiscalYear, string CompanyCode)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@V_AccNo");
            parasValue.Add(DeliveryNumber);

            parasName.Add("@V_FiscalYear");
            parasValue.Add(FiscalYear);

            parasName.Add("@V_CompanyCode");
            parasValue.Add(CompanyCode);

            return cls.Exec_StoreProc_dataset("[SP_DeliveryInvListV5]", parasName, parasValue);
        }
        public DataSet LoadPaymentTerm(string PayTerm, string FiscalYear, string CompanyCode)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@V_PayNo");
            parasValue.Add(PayTerm);

            parasName.Add("@V_FiscalYear");
            parasValue.Add(FiscalYear);

            parasName.Add("@V_CompanyCode");
            parasValue.Add(CompanyCode);

            return cls.Exec_StoreProc_dataset("[SP_EXI_PaymentTermList]", parasName, parasValue);
        }
        public DataSet LoadProductCodeColor(string ProductIn,string Article)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@ProductIn");
            parasValue.Add(ProductIn);

            parasName.Add("@Article");
            parasValue.Add(Article);

            return cls.Exec_StoreProc_dataset("[SP_EXI_ProductCodeColorListV2]", parasName, parasValue);
        }
        public DataSet LoadProductCodeColorV5(string ProductIn, string Article,string Year,string CompanyCode)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@ProductIn");
            parasValue.Add(ProductIn);

            parasName.Add("@Article");
            parasValue.Add(Article);

            parasName.Add("@Year");
            parasValue.Add(Year);

            parasName.Add("@CompanyCode");
            parasValue.Add(CompanyCode);

            return cls.Exec_StoreProc_dataset("[SP_EXI_ProductCodeColorListV5]", parasName, parasValue);
        }
        public DataSet LoadCenterOCList(string ProductIn)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@V_ProductNo");
            parasValue.Add(ProductIn);

            return cls.Exec_StoreProc_dataset("[SP_EXI_CenterOCList]", parasName, parasValue);
        }
        public DataSet LoadCenterOCListV5Horizontal(string ProductIn,string year,string companyCode)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@V_ProductNo");
            parasValue.Add(ProductIn);

            parasName.Add("@Year");
            parasValue.Add(year);

            parasName.Add("@CompanyCode");
            parasValue.Add(companyCode);


            return cls.Exec_StoreProc_dataset("[SP_EXI_CenterOCListV5Horizontal]", parasName, parasValue);
        }
        public DataSet LoadSizeProductCodePrice(string ProductIn,string ColorIn,int vtsize)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@V_ProductNo");
            parasValue.Add(ProductIn);

            parasName.Add("@V_ColorCode");
            parasValue.Add(ColorIn);

            parasName.Add("@V_VtSize");
            parasValue.Add(vtsize);

            return cls.Exec_StoreProc_dataset("[SP_EXI_SizeProductColorPriceList]", parasName, parasValue);
        }
        public DataSet LoadSizeProductCodePriceV5Horizontal(string ProductIn, string ColorIn, int vtsize,string Year,string CompanyCode)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@V_ProductNo");
            parasValue.Add(ProductIn);

            parasName.Add("@V_ColorCode");
            parasValue.Add(ColorIn);

            parasName.Add("@V_VtSize");
            parasValue.Add(vtsize);

            parasName.Add("@Year");
            parasValue.Add(Year);

            parasName.Add("@CompanyCode");
            parasValue.Add(CompanyCode);

            return cls.Exec_StoreProc_dataset("[SP_EXI_SizeProductColorPriceListV5Horizontal]", parasName, parasValue);
        }
        public DataSet LoadSizeProductCodePriceHel(string ProductIn, string ColorIn, int vtsize)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@V_ProductNo");
            parasValue.Add(ProductIn);

            parasName.Add("@V_ColorCode");
            parasValue.Add(ColorIn);

            parasName.Add("@V_VtSize");
            parasValue.Add(vtsize);

            return cls.Exec_StoreProc_dataset("[SP_EXI_SizeProductColorPriceListHel]", parasName, parasValue);
        }
       
        public DataSet LoadSizeProductCodePriceSGAltHel(string ProductIn, string ColorIn, string SizeGroup)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@V_ProductNo");
            parasValue.Add(ProductIn);

            parasName.Add("@V_ColorCode");
            parasValue.Add(ColorIn);

            parasName.Add("@V_SizeG");
            parasValue.Add(SizeGroup);

            return cls.Exec_StoreProc_dataset("[SP_EXI_SizeProductColorPriceListSGAltHel]", parasName, parasValue);
        }
        public DataSet LoadSizeProductCodePriceSizeGAlt(string ProductIn, string ColorIn, string SizeG)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@V_ProductNo");
            parasValue.Add(ProductIn);

            parasName.Add("@V_ColorCode");
            parasValue.Add(ColorIn);

            parasName.Add("@V_SizeG");
            parasValue.Add(SizeG);

            return cls.Exec_StoreProc_dataset("[SP_EXI_SizeProductColorPriceListSizeGAlt]", parasName, parasValue);
        }
        public DataSet LoadSizeProductCodePriceSizeG(string ProductIn, string ColorIn, string SizeG)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@V_ProductNo");
            parasValue.Add(ProductIn);

            parasName.Add("@V_ColorCode");
            parasValue.Add(ColorIn);

            parasName.Add("@V_SizeG");
            parasValue.Add(SizeG);

            return cls.Exec_StoreProc_dataset("[SP_EXI_SizeProductColorPriceListSizeG]", parasName, parasValue);
        }
        public DataSet LoadSizeProductCodePriceSizeGHel(string ProductIn, string ColorIn, string SizeG)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@V_ProductNo");
            parasValue.Add(ProductIn);

            parasName.Add("@V_ColorCode");
            parasValue.Add(ColorIn);

            parasName.Add("@V_SizeG");
            parasValue.Add(SizeG);

            return cls.Exec_StoreProc_dataset("[SP_EXI_SizeProductColorPriceListSizeGHel]", parasName, parasValue);
        }
        public DataSet LoadSizeProductCodePriceSizeGAltHel(string ProductIn, string ColorIn, string SizeG)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@V_ProductNo");
            parasValue.Add(ProductIn);

            parasName.Add("@V_ColorCode");
            parasValue.Add(ColorIn);

            parasName.Add("@V_SizeG");
            parasValue.Add(SizeG);

            return cls.Exec_StoreProc_dataset("[SP_EXI_SizeProductColorPriceListSizeGAltHel]", parasName, parasValue);
        }
        public DataSet LoadSizeProductCodePriceVerticalSizeHel(string ProductIn, string ColorIn, string SizeG,string Year,string CompanyCode)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@V_ProductNo");
            parasValue.Add(ProductIn);

            parasName.Add("@V_ColorCode");
            parasValue.Add(ColorIn);

            parasName.Add("@V_SizeG");
            parasValue.Add(SizeG);

            parasName.Add("@Year");
            parasValue.Add(Year);

            parasName.Add("@CompanyCode");
            parasValue.Add(CompanyCode);


            return cls.Exec_StoreProc_dataset("[SP_EXI_SizeProductColorPriceListVerticalSizeHel]", parasName, parasValue);
        }
        public DataSet LoadSizeProductCodePriceGroupSizeHel(string ProductIn, string ColorIn, string SizeG, string Year, string CompanyCode)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@V_ProductNo");
            parasValue.Add(ProductIn);

            parasName.Add("@V_ColorCode");
            parasValue.Add(ColorIn);

            parasName.Add("@V_SizeG");
            parasValue.Add(SizeG);

            parasName.Add("@Year");
            parasValue.Add(Year);

            parasName.Add("@CompanyCode");
            parasValue.Add(CompanyCode);


            return cls.Exec_StoreProc_dataset("[SP_EXI_SizeProductColorPriceListGroupSizeHel]", parasName, parasValue);
        }
        public DataSet LoadSizeProductCodePriceVerticalSize(string ProductIn, string ColorIn, string SizeG, string Year, string CompanyCode)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@V_ProductNo");
            parasValue.Add(ProductIn);

            parasName.Add("@V_ColorCode");
            parasValue.Add(ColorIn);

            parasName.Add("@V_SizeG");
            parasValue.Add(SizeG);

            parasName.Add("@Year");
            parasValue.Add(Year);

            parasName.Add("@CompanyCode");
            parasValue.Add(CompanyCode);

            return cls.Exec_StoreProc_dataset("[SP_EXI_SizeProductColorPriceListVerticalSize]", parasName, parasValue);
        }
        public DataSet LoadSizeProductCodePriceGroupSize(string ProductIn, string ColorIn, string SizeG, string Year, string CompanyCode)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@V_ProductNo");
            parasValue.Add(ProductIn);

            parasName.Add("@V_ColorCode");
            parasValue.Add(ColorIn);

            parasName.Add("@V_SizeG");
            parasValue.Add(SizeG);

            parasName.Add("@Year");
            parasValue.Add(Year);

            parasName.Add("@CompanyCode");
            parasValue.Add(CompanyCode);

            return cls.Exec_StoreProc_dataset("[SP_EXI_SizeProductColorPriceListGroupSize]", parasName, parasValue);
        }
        public DataSet LoadShipBy(string ShipByIn)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@ShipByIn");
            parasValue.Add(ShipByIn);

            return cls.Exec_StoreProc_dataset("[SP_EXI_ShipBy]", parasName, parasValue);
        }
        public DataSet LoadIncoterm(string IncotermIn)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@IncotermIn");
            parasValue.Add(IncotermIn);

            return cls.Exec_StoreProc_dataset("[SP_EXI_Incoterm]", parasName, parasValue);
        }
        public DataSet LoadPaymentTermAcc(string Account)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@V_Account");
            parasValue.Add(Account);

            return cls.Exec_StoreProc_dataset("[SP_EXI_PaymentTermAccount]", parasName, parasValue);
        }
        public DataSet LoadPaymentTermAccV5(string Account,string year,string companycode)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@V_Account");
            parasValue.Add(Account);

            parasName.Add("@V_FiscalYear");
            parasValue.Add(year);

            parasName.Add("@V_CompanyCode");
            parasValue.Add(companycode);

            return cls.Exec_StoreProc_dataset("[SP_EXI_PaymentTermAccountV5]", parasName, parasValue);
        }
        public DataSet LoadAccount_DeliveryV5(string AccInvNum, string AccDeliNum,string Year, string CompanyCode)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@AccInvNum");
            parasValue.Add(AccInvNum);

            parasName.Add("@AccDeliNum");
            parasValue.Add(AccDeliNum);

            parasName.Add("@Year");
            parasValue.Add(Year);

            parasName.Add("@CompanyCode");
            parasValue.Add(CompanyCode);

            return cls.Exec_StoreProc_dataset("[SP_EXI_AccountInvDelveryListV5]", parasName, parasValue);
        }
        public DataSet LoadAccount_Delivery(string AccInvNum, string AccDeliNum)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@AccInvNum");
            parasValue.Add(AccInvNum);

            parasName.Add("@AccDeliNum");
            parasValue.Add(AccDeliNum);

            return cls.Exec_StoreProc_dataset("[SP_EXI_AccountInvDelveryList]", parasName, parasValue);
        }
        public DataSet LoadBoxTypeMainProduct(string MainProduct, string ArticleNumber)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@MainProduct");
            parasValue.Add(MainProduct);

            parasName.Add("@ArticleNumber");
            parasValue.Add(ArticleNumber);


            return cls.Exec_StoreProc_dataset("[SP_EXI_BoxTypeMainProductList]", parasName, parasValue);
        }
        public DataSet LoadBoxTypeMainProductv5(string MainProduct, string ArticleNumber,string year,string CompanyCode)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@MainProduct");
            parasValue.Add(MainProduct);

            parasName.Add("@ArticleNumber");
            parasValue.Add(ArticleNumber);

            parasName.Add("@Year");
            parasValue.Add(year);

            parasName.Add("@CompanyCode");
            parasValue.Add(CompanyCode);

            return cls.Exec_StoreProc_dataset("[SP_EXI_BoxTypeMainProductListV5]", parasName, parasValue);
        }
        public int UpdateMasterLine(string str, string FSYear,string CompanyCode)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();
            #region paramater

            parasName.Add("@V_SerialNo");
            parasValue.Add(str);

            parasName.Add("@FSYear");
            parasValue.Add(FSYear);

            parasName.Add("@CompanyCode");
            parasValue.Add(CompanyCode);

            parasName.Add("@IsTrue");
            parasValue.Add(-1);
            #endregion
            return cls.Exec_StoreProcReturn("[SP_EXI_UpdateFlagTotalNotCompiled]", parasName, parasValue);
        }
        public DataSet ExportETDTemplateAdidas(string OrderNumber, string Version,string FSYear,string CompanyCode)
        {
            ArrayList parasName = new ArrayList();
            ArrayList parasValue = new ArrayList();

            parasName.Add("@OrderNumberH");
            parasValue.Add(OrderNumber);

            parasName.Add("@Version");
            parasValue.Add(Version);

            parasName.Add("@FSYear");
            parasValue.Add(FSYear);

            parasName.Add("@CompanyCode");
            parasValue.Add(CompanyCode);

            return cls.Exec_StoreProc_dataset("[SP_EXI_ExportTemplateAdidas]", parasName, parasValue);
        }
    }
}
