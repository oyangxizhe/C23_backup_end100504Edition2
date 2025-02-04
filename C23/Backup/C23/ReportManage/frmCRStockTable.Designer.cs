namespace C23.ReportManage
{
    partial class frmCRStockTable
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
            this.CRVStockTable = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cboxID = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(341, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(49, 23);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLook
            // 
            this.btnLook.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnLook.Location = new System.Drawing.Point(277, 1);
            this.btnLook.Name = "btnLook";
            this.btnLook.Size = new System.Drawing.Size(48, 23);
            this.btnLook.TabIndex = 16;
            this.btnLook.Text = "查询";
            this.btnLook.UseVisualStyleBackColor = true;
            this.btnLook.Click += new System.EventHandler(this.btnLook_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "进货单号";
            // 
            // CRVStockTable
            // 
            this.CRVStockTable.ActiveViewIndex = -1;
            this.CRVStockTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVStockTable.Location = new System.Drawing.Point(-1, 30);
            this.CRVStockTable.Name = "CRVStockTable";
            this.CRVStockTable.SelectionFormula = "";
            this.CRVStockTable.Size = new System.Drawing.Size(1271, 720);
            this.CRVStockTable.TabIndex = 14;
            this.CRVStockTable.ViewTimeSelectionFormula = "";
            // 
            // cboxID
            // 
            this.cboxID.FormattingEnabled = true;
            this.cboxID.Location = new System.Drawing.Point(98, 1);
            this.cboxID.Name = "cboxID";
            this.cboxID.Size = new System.Drawing.Size(164, 20);
            this.cboxID.TabIndex = 13;
            // 
            // frmCRStockTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 750);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLook);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CRVStockTable);
            this.Controls.Add(this.cboxID);
            this.Name = "frmCRStockTable";
            this.Text = "打印进货单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCRStockTable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLook;
        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVStockTable;
        private System.Windows.Forms.ComboBox cboxID;

    }
}