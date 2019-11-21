namespace H2T_grp
{
    partial class frm_Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Home));
            this.lblQTHT = new System.Windows.Forms.Label();
            this.lblThoat = new System.Windows.Forms.Label();
            this.lblKDKH = new System.Windows.Forms.Label();
            this.lblKT = new System.Windows.Forms.Label();
            this.lblUSER = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblQTHT
            // 
            this.lblQTHT.BackColor = System.Drawing.Color.Transparent;
            this.lblQTHT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblQTHT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblQTHT.Location = new System.Drawing.Point(456, 200);
            this.lblQTHT.Name = "lblQTHT";
            this.lblQTHT.Size = new System.Drawing.Size(64, 25);
            this.lblQTHT.TabIndex = 0;
            this.lblQTHT.Tag = "1";
            this.lblQTHT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblQTHT.Click += new System.EventHandler(this.lblQTHT_Click);
            this.lblQTHT.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblQTHT_MouseDown);
            // 
            // lblThoat
            // 
            this.lblThoat.BackColor = System.Drawing.Color.Transparent;
            this.lblThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblThoat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblThoat.Location = new System.Drawing.Point(532, 201);
            this.lblThoat.Name = "lblThoat";
            this.lblThoat.Size = new System.Drawing.Size(54, 22);
            this.lblThoat.TabIndex = 1;
            this.lblThoat.Tag = "4";
            this.lblThoat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblThoat.Click += new System.EventHandler(this.lblThoat_Click);
            // 
            // lblKDKH
            // 
            this.lblKDKH.BackColor = System.Drawing.Color.Transparent;
            this.lblKDKH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblKDKH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblKDKH.Location = new System.Drawing.Point(181, 66);
            this.lblKDKH.Name = "lblKDKH";
            this.lblKDKH.Size = new System.Drawing.Size(318, 23);
            this.lblKDKH.TabIndex = 2;
            this.lblKDKH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblKDKH.Click += new System.EventHandler(this.lblKDKH_Click);
            // 
            // lblKT
            // 
            this.lblKT.BackColor = System.Drawing.Color.Transparent;
            this.lblKT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblKT.Location = new System.Drawing.Point(184, 167);
            this.lblKT.Name = "lblKT";
            this.lblKT.Size = new System.Drawing.Size(303, 23);
            this.lblKT.TabIndex = 3;
            this.lblKT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblKT.Click += new System.EventHandler(this.lblKT_Click);
            // 
            // lblUSER
            // 
            this.lblUSER.BackColor = System.Drawing.Color.Transparent;
            this.lblUSER.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblUSER.Location = new System.Drawing.Point(184, 115);
            this.lblUSER.Name = "lblUSER";
            this.lblUSER.Size = new System.Drawing.Size(303, 23);
            this.lblUSER.TabIndex = 4;
            this.lblUSER.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUSER.Click += new System.EventHandler(this.lblUSER_Click);
            // 
            // frm_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(679, 343);
            this.Controls.Add(this.lblUSER);
            this.Controls.Add(this.lblKT);
            this.Controls.Add(this.lblKDKH);
            this.Controls.Add(this.lblThoat);
            this.Controls.Add(this.lblQTHT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Production Planning ";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.frm_Home_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblQTHT;
        private System.Windows.Forms.Label lblThoat;
        private System.Windows.Forms.Label lblKDKH;
        private System.Windows.Forms.Label lblKT;
        private System.Windows.Forms.Label lblUSER;
    }
}