namespace C23.ReportManage
{
    partial class frmCRPurOrders
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLook = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CRVPurOrders = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cboxID = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(345, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(49, 23);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLook
            // 
            this.btnLook.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnLook.Location = new System.Drawing.Point(281, 1);
            this.btnLook.Name = "btnLook";
            this.btnLook.Size = new System.Drawing.Size(48, 23);
            this.btnLook.TabIndex = 11;
            this.btnLook.Text = "查询";
            this.btnLook.UseVisualStyleBackColor = true;
            this.btnLook.Click += new System.EventHandler(this.btnLook_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "采购单号";
            // 
            // CRVPurOrders
            // 
            this.CRVPurOrders.ActiveViewIndex = -1;
            this.CRVPurOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVPurOrders.Location = new System.Drawing.Point(-3, 30);
            this.CRVPurOrders.Name = "CRVPurOrders";
            this.CRVPurOrders.SelectionFormula = "";
            this.CRVPurOrders.Size = new System.Drawing.Size(1274, 720);
            this.CRVPurOrders.TabIndex = 9;
            this.CRVPurOrders.ViewTimeSelectionFormula = "";
            this.CRVPurOrders.Load += new System.EventHandler(this.CRVPurOrders_Load);
            // 
            // cboxID
            // 
            this.cboxID.FormattingEnabled = true;
            this.cboxID.Location = new System.Drawing.Point(102, 1);
            this.cboxID.Name = "cboxID";
            this.cboxID.Size = new System.Drawing.Size(164, 20);
            this.cboxID.TabIndex = 8;
            // 
            // frmCRPurOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 750);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLook);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CRVPurOrders);
            this.Controls.Add(this.cboxID);
            this.Name = "frmCRPurOrders";
            this.Text = "打印采购单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCRPurOrders_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLook;
        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVPurOrders;
        private System.Windows.Forms.ComboBox cboxID;


    }
}