using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xceed.SmartUI.Controls.MenuBar;
using H2T_QuanTri;
using H2T_SHOWROOM;
using H2T_Material;
using H2T_Planning;
using DevExpress.XtraNavBar;
using H2T_BaseSys;
using System.Reflection;
using H2T_BaseSys.Common;

namespace H2T_grp
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            Xceed.SmartUI.Licenser.LicenseKey = "SUN35-LU1XR-A86X6-6HLA";
            InitializeComponent();
        }
        DevExpress.Utils.WaitDialogForm dlg = null;
        NavBarGroup group;
        private DateTime currentTimeLogin;
        private void frm_Main_Load(object sender, EventArgs e)
        {
            switch (Program.gnPhanHanh)
            {
                case 1:
                    pnlKetQua.Text = "ADMIN";
                    break;
                case 2:
                    pnlKetQua.Text = "USER";
                    break;
            }
            // LoadMenu();
            LoadMenuNavBar();
            Contr_frm_Main objctrl = new Contr_frm_Main();
            objctrl.LoadInfo(Program.gsAccount);
            Program.gsUserName = objctrl.sUserName;
            Program.gsDate = objctrl.sDate;
            Program.gsTime = objctrl.sTime;
            Program.gnMaPB = objctrl.nMaPB;
            pnlUser.Text = Program.gsUserName;
            pnlDate.Text = "Working Date : " + Program.gsDate + " - " + Program.gsTime;
            pnlPhongBan.Text = objctrl.sTenPB;
            currentTimeLogin = DateTime.Now;
        }
        #region loadmenu
        //private void LoadMenu()
        //{
        //    string sMenuName = null;
        //    string sClassName = null;
        //    string sFormName = null;
        //    string sRight = null;
        //    int nCapBac = 0;
        //    int nMenu1ID = 0;
        //    int nMenu2ID = 0;
        //    int nMenu3ID = 0;

        //    DataSet dsDataSet = new DataSet();
        //    Contr_frm_Main oCtrl_FrmMain = new Contr_frm_Main();

        //    dsDataSet = oCtrl_FrmMain.LoadMenu_ds(Program.gsAccount, Program.gnPhanHanh);
        //    //dsDataSet = oCtrl_FrmMain.MenuRows;
        //    if (dsDataSet.Tables[0].Rows.Count == 0)
        //    {

        //    }
        //    foreach (DataRow drDataRow in dsDataSet.Tables[0].Rows)
        //    {
        //        sMenuName = (string)drDataRow["TenMenu"];
        //        nCapBac = (int)drDataRow["CapBat"];
        //        sFormName = (string)drDataRow["TenForm"];
        //        sClassName = (string)drDataRow["TenClass"];
        //        sRight = (string)drDataRow["Quyen"];
        //        if (nCapBac == 1)
        //        {
        //            nMenu1ID += 1;
        //            nMenu2ID = 0;
        //            try
        //            {
        //                this.mnuMain.Items.Insert(nMenu1ID, new MainMenuItem(sMenuName));
        //            }
        //            catch (Exception)
        //            {
        //                MessageBox.Show("Lỗi insert Menu cấp I????!!!");
        //            }
        //        }
        //        else
        //        {
        //            if (nCapBac == 2)
        //            {
        //                nMenu2ID += 1;
        //                sFormName.Trim();
        //                if ((sFormName.Length) != 0)
        //                {
        //                    this.mnuMain.Items[nMenu1ID - 1].Items.Insert(nMenu2ID, new Xceed.SmartUI.Controls.MenuBar.MenuItem(sMenuName));
        //                    this.mnuMain.Items[nMenu1ID - 1].Items[nMenu2ID - 1].Key = sFormName + "@@" + sClassName + "$$" + sRight;
        //                }
        //                else
        //                {
        //                    nMenu3ID = 0;
        //                    this.mnuMain.Items[nMenu1ID - 1].Items.Insert(nMenu2ID, new PopupMenuItem(sMenuName));
        //                }
        //            }
        //            // menu cap bac 3
        //            else
        //            {
        //                nMenu3ID += 1;
        //                this.mnuMain.Items[nMenu1ID - 1].Items[nMenu2ID - 1].Items.Insert(nMenu3ID, new Xceed.SmartUI.Controls.MenuBar.MenuItem(sMenuName));
        //                this.mnuMain.Items[nMenu1ID - 1].Items[nMenu2ID - 1].Items[nMenu3ID - 1].Key = sFormName + "@@" + sClassName + "$$" + sRight;
        //            }
        //        }
        //    }
        //}
        #endregion
        private void LoadMenuNavBar()
        {
            string sMenuName = null;
            string sClassName = null;
            string sFormName = null;
            string sRight = null;
            int nCapBac = 0;
            int nMenu1ID = 0;
            int nMenu2ID = 0;
            int nMenu3ID = 0;

            DataSet dsDataSet = new DataSet();
            Contr_frm_Main oCtrl_FrmMain = new Contr_frm_Main();

            dsDataSet = oCtrl_FrmMain.LoadMenu_ds(Program.gsAccount, Program.gnPhanHanh);
            //dsDataSet = oCtrl_FrmMain.MenuRows;
            if (dsDataSet.Tables[0].Rows.Count == 0)
            {

            }
            foreach (DataRow drDataRow in dsDataSet.Tables[0].Rows)
            {
                sMenuName = (string)drDataRow["TenMenu"];
                nCapBac = (int)drDataRow["CapBat"];
                sFormName = (string)drDataRow["TenForm"];
                sClassName = (string)drDataRow["TenClass"];
                sRight = (string)drDataRow["Quyen"];
                if (nCapBac == 1)
                {
                    nMenu1ID += 1;
                    nMenu2ID = 0;
                    try
                    {
                        //this.mnuMain.Items.Insert(nMenu1ID, new MainMenuItem(sMenuName));
                        // Add NavBar group
                        group = navBarControl1.Groups.Add();
                        //' Set up the NavBar group caption
                        group.Caption = sMenuName;
                        group.Tag = sMenuName;
                        //Set up the NavBar group large image index
                        // group.LargeImageIndex = cInfo.ImageIndex;
                        // Tell to use small images for the NavBar Group items
                        group.GroupStyle = NavBarGroupStyle.SmallIconsText;
                        //Expand the group by default
                        group.Expanded = true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lỗi insert Menu cấp I????!!!");
                    }
                }
                else
                {
                    if (nCapBac == 2)
                    {
                        nMenu2ID += 1;
                        sFormName.Trim();
                        if ((sFormName.Length) != 0)
                        {
                            //  this.mnuMain.Items[nMenu1ID - 1].Items.Insert(nMenu2ID, new Xceed.SmartUI.Controls.MenuBar.MenuItem(sMenuName));
                            //   this.mnuMain.Items[nMenu1ID - 1].Items[nMenu2ID - 1].Key = sFormName + "@@" + sClassName + "$$" + sRight;
                            // Create NavBar item
                            NavBarItem item = navBarControl1.Items.Add();
                            // Set up the NavBar item caption
                            item.Caption = sMenuName;
                            item.Tag = sFormName + "@@" + sClassName + "$$" + sRight;
                            navBarControl1.BeginUpdate();
                            navBarControl1.Groups.Add(group);
                            group.ItemLinks.Add(item);
                            group.Expanded = true;
                            navBarControl1.EndUpdate();
                        }
                        else
                        {
                            nMenu3ID = 0;
                            // this.mnuMain.Items[nMenu1ID - 1].Items.Insert(nMenu2ID, new PopupMenuItem(sMenuName));
                        }
                    }
                    // menu cap bac 3
                    else
                    {
                        nMenu3ID += 1;
                        // this.mnuMain.Items[nMenu1ID - 1].Items[nMenu2ID - 1].Items.Insert(nMenu3ID, new Xceed.SmartUI.Controls.MenuBar.MenuItem(sMenuName));
                        // this.mnuMain.Items[nMenu1ID - 1].Items[nMenu2ID - 1].Items[nMenu3ID - 1].Key = sFormName + "@@" + sClassName + "$$" + sRight;
                    }
                }
            }
            // Specify the event handler which will be invoked when any link is clicked.
            //   navBarControl1.LinkClicked += new NavBarLinkEventHandler(navBarControl1_LinkClicked);
        }

        private void mnuMain_ItemClick(object sender, Xceed.SmartUI.SmartItemClickEventArgs e)
        {
            Cls_HamTuTao cls_Ham = new Cls_HamTuTao();
            string sFormName = null;
            string sClassName = null;
            int i = 0;
            int j = 0;

            i = e.Item.Key.IndexOf("@@");
            j = e.Item.Key.IndexOf("$$");
            sFormName = cls_Ham.Mid(e.Item.Key, 0, i);
            sClassName = cls_Ham.Mid(e.Item.Key, i + 2, j - i - 2);
            Program.gsRight = cls_Ham.Mid(e.Item.Key, j + 2, e.Item.Key.Length - j - 1);
            //this.AddOwnedForm()
            // childForm child = new childForm();
            //child.MdiParent = this; // this chính là parentForm
            ShowForm(sFormName, sClassName, this);
        }

        public  void ShowForm(string sFormName, string sClassName, Form frm)
        {
            Cls_HamTuTao cls_Ham = new Cls_HamTuTao();

            string str = cls_Ham.UCase(sClassName);
            //var Form = oProject  as Form;
            //Form Frm_return = null;
            switch (str)
            {
                #region module Quan tri he thong
                case "H2T_QUANTRI.CLS_QUANTRI":
                    Cls_QuanTri cls_quantri = new Cls_QuanTri();
                    cls_quantri.PhanHanh = Program.gnPhanHanh;
                    cls_quantri.Right = Program.gsRight;
                    cls_quantri.ConnectionString = Program.gsConnectionString;
                    cls_quantri.CnConnect = Program.gcnConnect;
                    cls_quantri.Account = Program.gsAccount;
                    cls_quantri.UserName = Program.gsUserName;
                    cls_quantri.SourcePath = Program.gsSourcePath;
                    cls_quantri.ApplicationPath = Program.gsApplicationPath;
                    cls_quantri.SanPhamPath = Program.gsSanPhamPath;
                    cls_quantri.GDate = Program.gsDate;
                    cls_quantri.GTime = Program.gsTime;
                    cls_quantri.UserID = Program.gsUserID;
                    cls_quantri.MaPB = Program.gnMaPB;
                    // cls_quantri.Frm = frm;
                    //cls_quantri.sFormName = sFormName;
                    this.ShowFrmProject("H2T_QUANTRI",sFormName);
                    break;
                #endregion
                #region module show room
                case "H2T_SHOWROOM.CLS_SHOWROOM":
                    Cls_ShowRoom Cls_ShowRoom = new Cls_ShowRoom();
                    Cls_ShowRoom.PhanHanh = Program.gnPhanHanh;
                    Cls_ShowRoom.Right = Program.gsRight;
                    Cls_ShowRoom.ConnectionString = Program.gsConnectionString;
                    Cls_ShowRoom.CnConnect = Program.gcnConnect;
                    Cls_ShowRoom.Account = Program.gsAccount;
                    Cls_ShowRoom.UserName = Program.gsUserName;
                    Cls_ShowRoom.SourcePath = Program.gsSourcePath;
                    Cls_ShowRoom.ApplicationPath = Program.gsApplicationPath;
                    Cls_ShowRoom.SanPhamPath = Program.gsSanPhamPath;
                    Cls_ShowRoom.GDate = Program.gsDate;
                    Cls_ShowRoom.GTime = Program.gsTime;
                    Cls_ShowRoom.UserID = Program.gsUserID;
                    Cls_ShowRoom.MaPB = Program.gnMaPB;
                    Cls_ShowRoom.gsCompanyCode = Program.gsCompanyCode;
                    // Cls_ShowRoom.Frm = frm;
                    //Cls_ShowRoom.sFormName = sFormName;
                    this.ShowFrmProject("H2T_SHOWROOM", sFormName);
                    break;
                #endregion
                #region module Material --> BoM +MRP
                case "H2T_MATERIAL.CLS_MATERIAL":
                    Cls_Material Cls_Material = new Cls_Material();
                    Cls_Material.PhanHanh = Program.gnPhanHanh;
                    Cls_Material.Right = Program.gsRight;
                    Cls_Material.ConnectionString = Program.gsConnectionString;
                    Cls_Material.CnConnect = Program.gcnConnect;
                    Cls_Material.Account = Program.gsAccount;
                    Cls_Material.UserName = Program.gsUserName;
                    Cls_Material.SourcePath = Program.gsSourcePath;
                    Cls_Material.ApplicationPath = Program.gsApplicationPath;
                    Cls_Material.SanPhamPath = Program.gsSanPhamPath;
                    Cls_Material.GDate = Program.gsDate;
                    Cls_Material.GTime = Program.gsTime;
                    Cls_Material.UserID = Program.gsUserID;
                    Cls_Material.MaPB = Program.gnMaPB;
                    Cls_Material.gsCompanyCode = Program.gsCompanyCode;
                    // Cls_ShowRoom.Frm = frm;
                    //Cls_ShowRoom.sFormName = sFormName;
                    this.ShowFrmProject("H2T_MATERIAL", sFormName);
                    break;
                #endregion
                #region module Planning --> Planning+ Stock
                case "H2T_PLANNING.CLS_PLANNING":
                    Cls_Planning Cls_Planning = new Cls_Planning();
                    Cls_Planning.PhanHanh = Program.gnPhanHanh;
                    Cls_Planning.Right = Program.gsRight;
                    Cls_Planning.ConnectionString = Program.gsConnectionString;
                    Cls_Planning.CnConnect = Program.gcnConnect;
                    Cls_Planning.Account = Program.gsAccount;
                    Cls_Planning.UserName = Program.gsUserName;
                    Cls_Planning.SourcePath = Program.gsSourcePath;
                    Cls_Planning.ApplicationPath = Program.gsApplicationPath;
                    Cls_Planning.SanPhamPath = Program.gsSanPhamPath;
                    Cls_Planning.GDate = Program.gsDate;
                    Cls_Planning.GTime = Program.gsTime;
                    Cls_Planning.UserID = Program.gsUserID;
                    Cls_Planning.MaPB = Program.gnMaPB;
                    Cls_Planning.gsCompanyCode = Program.gsCompanyCode;
                    // Cls_ShowRoom.Frm = frm;
                    //Cls_ShowRoom.sFormName = sFormName;
                    this.ShowFrmProject("H2T_PLANNING", sFormName);
                    break;
                #endregion
                //0--------------------------------------------
            }
        }
        // phan nay` leader se~ them vao` cac form ca`n thiet.
        public void ShowFrmProject(string ProjectName,string sFormName)
        {
            Boolean FLAG = false;
            Cls_HamTuTao cls_Ham = new Cls_HamTuTao();
            string str = cls_Ham.UCase(sFormName);

            bool activeForm = false;
            int mdiFormIndex = -1;
            foreach (Form frm in this.MdiChildren)
            {
                mdiFormIndex++;
                if (frm.Name.Trim().ToUpper() != sFormName.Trim().ToUpper())
                    continue;
                activeForm = true;
                break;
            }
            if (activeForm)
            {
                this.MdiChildren[mdiFormIndex].Activate();
            }
            else
            {
                if (sFormName.ToUpper() == "FRM_HOME")
                {
                    this.Close();
                    this.Dispose();
                     frm_Home   oForm = new frm_Home();
                    this.Close();
                           this.Dispose();
                          oForm.ShowDialog();
                         return;
                }
                if (sFormName.ToUpper() == "FRM_THOAT")
                {
                    this.Close();
                    this.Dispose();
                    return;
                }
                var fBase = CreateInstanceFormByProject(ProjectName, "", sFormName) as FrmBase;
                fBase.AddRightWhenShowForm(Program.gsRight);
                dlg = new DevExpress.Utils.WaitDialogForm("");
                fBase.MdiParent = this;
                fBase.WindowState = FormWindowState.Maximized;
                fBase.StartPosition = FormStartPosition.CenterScreen;
                fBase.Show();
                dlg.Close();
            }
            #region --
            //switch (str)
            //{

            //    case "FRM_HOME":
            //        oForm = new frm_Home();
            //        this.Close();
            //        this.Dispose();
            //        oForm.ShowDialog();
            //        return;
            //    case "FRM_NHANVIEN":
            //        oForm = new frm_NhanVien();
            //        break;
            //    case "FRM_MENU":
            //        oForm = new frm_Menu();
            //        break;
            //    case "FRM_NHOMSUDUNG":
            //        oForm = new frm_NhomSuDung();
            //        break;
            //    case "FRM_MENUNHANVIEN":
            //        oForm = new frm_MenuNhanVien();
            //        break;
            //    case "FRM_DOIPASSWORD":
            //        oForm = new frm_DoiPassword();
            //        break;
         
            //    case "FRM_NHAPHANG":
            //        oForm = new frm_NhapHang();
            //        break;
          
            //    //frm_PrintBarcode_Site.cs
            //    case "FRM_PRINTBARCODE_SITE":
            //        oForm = new frm_PrintBarcode_Site();
            //        //FLAG = true;
            //        break;
            //    //frm_ChangePrice
            //    case "FRM_CHANGEPRICE":
            //        oForm = new frm_ChangePrice();
            //        //FLAG = true;
            //        break;
            //    case "FRM_EXPORTSALEORDER" // Hoa viet cho nay 
            //    :

            //        //if (Program.gsCompanyCode == "01")
            //        //{
            //        //    return;
            //        //}
            //        ;// Bien Hoa khong su dung lay so lieu truc tiep tren server
            //        oForm = new frm_ExportSaleOrder();
            //        FLAG = true;
            //        break;
            //    //frm_ChangePrice
            //    case "FRM_CUSTOMER":
            //        oForm = new frm_Customer();
            //        //FLAG = true;
            //        break;
            //    case "SP_FRMTOOLING":
            //        oForm = new SP_FrmTooling();
            //        //FLAG = true;
            //        break;
            //    case "SP_TOOLINGCOLOR":
            //        oForm = new SP_ToolingColor();
            //        //FLAG = true;
            //        break;
            //    case "SP_TOOLINGSIZE":
            //        oForm = new SP_ToolingSize();
            //        //FLAG = true;
            //        break;
            //    //SP_FrmToolingOHeader
            //    case "SP_FRMTOOLINGOHEADER":
            //        oForm = new SP_FrmToolingOHeader();
            //        //FLAG = true;
            //        break;
            //    case "SP_FRMTOOLINGODETAIL":
            //        oForm = new SP_FrmToolingODetail();
            //        //FLAG = true;
            //        break;
            //    //SP_ReportSOList
            //    case "SP_REPORTSOLIST":
            //        oForm = new SP_ReportSOList();
            //        //FLAG = true;
            //        break;
            //    //SP_ReportSOHistoryList
            //    case "SP_REPORTSOHISTORYLIST":
            //        oForm = new SP_ReportSOHistoryList();
            //        //FLAG = true;
            //        break;
            //    case "SP_FORMMC":
            //        oForm = new SP_FormMC();
            //        //FLAG = true;
            //        break;
            //    case "FRM_THOAT":
            //        this.Close();
            //        this.Dispose();
            //        return;

            //}
            //oForm.MdiParent = this;
            //// oForm.Text = "Danh Mục Nhân Viên";
            //if (FLAG == true)
            //{
            //    oForm.WindowState = FormWindowState.Normal;
            //}
            //else
            //{
            //    oForm.WindowState = FormWindowState.Maximized;
            //} //Loading Data...", "Please Wait", new Size(100, 100), this
            //dlg = new DevExpress.Utils.WaitDialogForm("");
            ////dlg.Caption = "Loading Data...";
            //oForm.Show();
            //dlg.Close();
            #endregion

        }
        public Form CreateInstanceFormByProject(string projectName, string folderContainForm, string formName)
        {
            Type t;
            string appName = Assembly.GetEntryAssembly().GetName().Name;
            if (projectName != appName)
            {
                Assembly assemblyProject = Assembly.LoadFile(string.Format(@"{0}\{1}.dll", Application.StartupPath, projectName));
                if (string.IsNullOrEmpty(folderContainForm))
                {
                    t = assemblyProject.GetType(string.Format("{0}.{1}", projectName, formName), false, true);
                }
                else
                {
                    t = assemblyProject.GetType(string.Format("{0}.{1}.{2}", projectName, folderContainForm, formName), false, true);
                }

            }
            else
            {
                t = Type.GetType(string.IsNullOrEmpty(folderContainForm) ? formName : string.Format("{0}.{1}", folderContainForm, formName), false, true);
            }
            object objForm = Activator.CreateInstance(t);
            return objForm as Form;
        }
        //if (cls_Ham.UCase(sClassName) == "H2T.Cls_H2T")
        //{
        //    oProject.ShowForm(sFormName, frm);
        //}
        //else
        //{
        //    oProject.ShowForm(sFormName);
        //}
        //return oProject;

        private void tol_New_Click(object sender, Xceed.SmartUI.SmartItemClickEventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                try
                {
                    IChildFormInterface childform = (IChildFormInterface)this.ActiveMdiChild;
                    childform.NewData();
                }
                catch (Exception ex)
                {
                }
            }
        }
        private void tol_Filter_Click(object sender, Xceed.SmartUI.SmartItemClickEventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                try
                {
                    IChildFormInterface childform = (IChildFormInterface)this.ActiveMdiChild;
                    childform.FilterData();
                }
                catch (Exception ex)
                {
                }
            }
        }
        private void tol_refresh_Click(object sender, Xceed.SmartUI.SmartItemClickEventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                try
                {
                    IChildFormInterface childform = (IChildFormInterface)this.ActiveMdiChild;
                    childform.RefreshData();
                }
                catch (Exception ex)
                {
                }
            }
        }
        private void tol_Print_Click(object sender, Xceed.SmartUI.SmartItemClickEventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                try
                {
                    IChildFormInterface childform = (IChildFormInterface)this.ActiveMdiChild;
                    childform.PrintData();
                }
                catch (Exception ex)
                {
                }

            }
        }
        private void tol_out_Click(object sender, Xceed.SmartUI.SmartItemClickEventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                try
                {
                    IChildFormInterface childform = (IChildFormInterface)this.ActiveMdiChild;
                    childform.Out();
                }
                catch (Exception ex)
                {
                }

            }
            else
            {
                this.Close();
            }
        }

        private void frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            ////   this.barStaticI_CPU.Caption = string.Format("CPU Usage: {0}%",Convert.ToInt32(GetCPUCounter()));
            ////this.pn.Text = string.Format("Ram Usage [{0}]", ProcessGeneral.ConvertFileSizeToString(Program.GetRAMCounter(Program.GetProgramProcess())));
            //TimeSpan diff = DateTime.Now.Subtract(currentTimeLogin);
            //this.pnlPhongBan.Text = string.Format("Time Usage [{0}]", Program.GetUsageTimeProgram(Convert.ToInt32(diff.TotalSeconds)));
            //this.pnlDate.Text = String.Format("[{0:T}]", DateTime.Now);
        }

        private void navBarControl1_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Cls_HamTuTao cls_Ham = new Cls_HamTuTao();
            string sFormName = null;
            string sClassName = null;
            int i = 0;
            int j = 0;

            i = e.Link.Item.Tag.ToString().IndexOf("@@");
            j = e.Link.Item.Tag.ToString().IndexOf("$$");
            //i = e.Item.Key.IndexOf("@@");
            //j = e.Item.Key.IndexOf("$$");
            sFormName = cls_Ham.Mid(e.Link.Item.Tag.ToString(), 0, i);
            sClassName = cls_Ham.Mid(e.Link.Item.Tag.ToString(), i + 2, j - i - 2);
            Program.gsRight = cls_Ham.Mid(e.Link.Item.Tag.ToString(), j + 2, e.Link.Item.Tag.ToString().Length - j - 1);
            //this.AddOwnedForm()
            // childForm child = new childForm();
            //child.MdiParent = this; // this chính là parentForm
            ShowForm(sFormName, sClassName, this);
        }


    }
}
