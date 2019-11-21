namespace H2T_grp
{
    partial class frm_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.staMain = new Xceed.SmartUI.Controls.StatusBar.SmartStatusBar();
            this.pnlUser = new Xceed.SmartUI.Controls.StatusBar.Panel();
            this.pnlPhongBan = new Xceed.SmartUI.Controls.StatusBar.Panel();
            this.pnlDate = new Xceed.SmartUI.Controls.StatusBar.Panel();
            this.pnlKetQua = new Xceed.SmartUI.Controls.StatusBar.Panel();
            this.mnuMain = new Xceed.SmartUI.Controls.MenuBar.SmartMenuBar();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel3 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.tol_New = new Xceed.SmartUI.Controls.ToolBar.Tool();
            this.tol_refresh = new Xceed.SmartUI.Controls.ToolBar.Tool();
            this.tol_Print = new Xceed.SmartUI.Controls.ToolBar.Tool();
            this.tol_out = new Xceed.SmartUI.Controls.ToolBar.Tool();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            ((System.ComponentModel.ISupportInitialize)(this.staMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel2.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel3.SuspendLayout();
            this.dockPanel3_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // staMain
            // 
            this.staMain.Items.AddRange(new Xceed.SmartUI.SmartItem[] {
            this.pnlUser,
            this.pnlPhongBan,
            this.pnlDate,
            this.pnlKetQua});
            this.staMain.Location = new System.Drawing.Point(195, 446);
            this.staMain.Name = "staMain";
            this.staMain.Size = new System.Drawing.Size(688, 23);
            this.staMain.TabIndex = 4;
            this.staMain.Text = "staMain";
            // 
            // pnlUser
            // 
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Tag = null;
            this.pnlUser.Text = "pnlUser";
            // 
            // pnlPhongBan
            // 
            this.pnlPhongBan.AccessibleDefaultActionDescription = "";
            this.pnlPhongBan.Name = "pnlPhongBan";
            this.pnlPhongBan.Tag = null;
            this.pnlPhongBan.Text = "pnlPhongBan";
            // 
            // pnlDate
            // 
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Tag = null;
            this.pnlDate.Text = "pnlDate";
            // 
            // pnlKetQua
            // 
            this.pnlKetQua.Name = "pnlKetQua";
            this.pnlKetQua.Tag = null;
            this.pnlKetQua.Text = "pnlKetQua";
            // 
            // mnuMain
            // 
            this.mnuMain.Location = new System.Drawing.Point(159, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(724, 26);
            this.mnuMain.TabIndex = 8;
            this.mnuMain.Text = "mnuMain";
            this.mnuMain.Visible = false;
            this.mnuMain.ItemClick += new Xceed.SmartUI.SmartItemClickEventHandler(this.mnuMain_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 0;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(883, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 469);
            this.barDockControlBottom.Size = new System.Drawing.Size(883, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 469);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(883, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 469);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel2,
            this.dockPanel1});
            this.dockManager1.MenuManager = this.barManager1;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel3});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dockPanel2.ID = new System.Guid("4225a601-d1d9-4672-8463-7efba32d409c");
            this.dockPanel2.Location = new System.Drawing.Point(-32768, -32768);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel2.SavedIndex = 0;
            this.dockPanel2.Size = new System.Drawing.Size(200, 200);
            this.dockPanel2.Text = "dockPanel2";
            this.dockPanel2.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(3, 22);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(194, 175);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("96d40dcc-803a-4135-ba97-cd33346ffece");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.Size = new System.Drawing.Size(200, 469);
            this.dockPanel1.Text = "dockPanel1";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(192, 442);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dockPanel3
            // 
            this.dockPanel3.Controls.Add(this.dockPanel3_Container);
            this.dockPanel3.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel3.ID = new System.Guid("b2867b5f-86f5-466a-8179-4b1c6794a9fb");
            this.dockPanel3.Location = new System.Drawing.Point(0, 0);
            this.dockPanel3.Name = "dockPanel3";
            this.dockPanel3.OriginalSize = new System.Drawing.Size(195, 200);
            this.dockPanel3.Size = new System.Drawing.Size(195, 469);
            this.dockPanel3.Text = "Toolbar";
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Controls.Add(this.navBarControl1);
            this.dockPanel3_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(187, 442);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = null;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandButtonMode = DevExpress.Utils.Controls.ExpandButtonMode.Inverted;
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 187;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.ExplorerBar;
            this.navBarControl1.Size = new System.Drawing.Size(187, 442);
            this.navBarControl1.TabIndex = 45;
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinExplorerBarViewInfoRegistrator("DevExpress Style");
            this.navBarControl1.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarControl1_LinkClicked);
            // 
            // tol_New
            // 
            this.tol_New.Image = global::H2T_grp.Properties.Resources.add;
            this.tol_New.Name = "tol_New";
            this.tol_New.Tag = null;
            this.tol_New.Text = "New";
            this.tol_New.Click += new Xceed.SmartUI.SmartItemClickEventHandler(this.tol_New_Click);
            // 
            // tol_refresh
            // 
            this.tol_refresh.Image = global::H2T_grp.Properties.Resources.refresh;
            this.tol_refresh.Name = "tol_refresh";
            this.tol_refresh.Tag = null;
            this.tol_refresh.Text = "Refresh";
            this.tol_refresh.Click += new Xceed.SmartUI.SmartItemClickEventHandler(this.tol_refresh_Click);
            // 
            // tol_Print
            // 
            this.tol_Print.Image = ((System.Drawing.Image)(resources.GetObject("tol_Print.Image")));
            this.tol_Print.Name = "tol_Print";
            this.tol_Print.Tag = null;
            this.tol_Print.Text = "Print";
            this.tol_Print.Click += new Xceed.SmartUI.SmartItemClickEventHandler(this.tol_Print_Click);
            // 
            // tol_out
            // 
            this.tol_out.Image = ((System.Drawing.Image)(resources.GetObject("tol_out.Image")));
            this.tol_out.Name = "tol_out";
            this.tol_out.Tag = null;
            this.tol_out.Text = "Exit";
            this.tol_out.Click += new Xceed.SmartUI.SmartItemClickEventHandler(this.tol_out_Click);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(883, 469);
            this.Controls.Add(this.staMain);
            this.Controls.Add(this.mnuMain);
            this.Controls.Add(this.dockPanel3);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Name = "frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COC Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Main_FormClosed);
            this.Load += new System.EventHandler(this.frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.staMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel3.ResumeLayout(false);
            this.dockPanel3_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Xceed.SmartUI.Controls.StatusBar.SmartStatusBar staMain;
        private Xceed.SmartUI.Controls.StatusBar.Panel pnlUser;
        private Xceed.SmartUI.Controls.StatusBar.Panel pnlPhongBan;
        private Xceed.SmartUI.Controls.StatusBar.Panel pnlDate;
        private Xceed.SmartUI.Controls.StatusBar.Panel pnlKetQua;
        private Xceed.SmartUI.Controls.MenuBar.SmartMenuBar mnuMain;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private Xceed.SmartUI.Controls.ToolBar.Tool tol_New;
        private Xceed.SmartUI.Controls.ToolBar.Tool tol_refresh;
        private Xceed.SmartUI.Controls.ToolBar.Tool tol_Print;
        private Xceed.SmartUI.Controls.ToolBar.Tool tol_out;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel3;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;


    }
}