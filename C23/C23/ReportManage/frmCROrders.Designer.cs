namespace C23.ReportManage
{
    partial class frmCROrders
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
            this.cboxID = new System.Windows.Forms.ComboBox();
            this.CRVOrders = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLook = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboxID
            // 
            this.cboxID.FormattingEnabled = true;
            this.cboxID.Location = new System.Drawing.Point(102, 3);
            this.cboxID.Name = "cboxID";
            this.cboxID.Size = new System.Drawing.Size(164, 20);
            this.cboxID.TabIndex = 3;
            // 
            // CRVOrders
            // 
            this.CRVOrders.ActiveViewIndex = -1;
            this.CRVOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVOrders.Location = new System.Drawing.Point(-3, 32);
            this.CRVOrders.Name = "CRVOrders";
            this.CRVOrders.SelectionFormula = "";
            this.CRVOrders.Size = new System.Drawing.Size(1279, 720);
            this.CRVOrders.TabIndex = 4;
            this.CRVOrders.ViewTimeSelectionFormula = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "订单编号";
            // 
            // btnLook
            // 
            this.btnLook.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnLook.Location = new System.Drawing.Point(281, 3);
            this.btnLook.Name = "btnLook";
            this.btnLook.Size = new System.Drawing.Size(48, 23);
            this.btnLook.TabIndex = 6;
            this.btnLook.Text = "查询";
            this.btnLook.UseVisualStyleBackColor = true;
            this.btnLook.Click += new System.EventHandler(this.btnLook_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(345, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(49, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmCROrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 750);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLook);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CRVOrders);
            this.Controls.Add(this.cboxID);
            this.Name = "frmCROrders";
            this.Text = "打印客户订单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCROrders_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboxID;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVOrders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLook;
        private System.Windows.Forms.Button btnExit;

    }
}