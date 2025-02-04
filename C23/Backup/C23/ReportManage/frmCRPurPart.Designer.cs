namespace C23.ReportManage
{
    partial class frmCRPurPart
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
            this.cboxCondition = new System.Windows.Forms.ComboBox();
            this.btnLook = new System.Windows.Forms.Button();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CRVPurPart = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(661, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(48, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cboxCondition
            // 
            this.cboxCondition.FormattingEnabled = true;
            this.cboxCondition.Items.AddRange(new object[] {
            "",
            "供运商编号",
            "供运商名称",
            "品号",
            "品名",
            "采购单号"});
            this.cboxCondition.Location = new System.Drawing.Point(106, 9);
            this.cboxCondition.Name = "cboxCondition";
            this.cboxCondition.Size = new System.Drawing.Size(121, 20);
            this.cboxCondition.TabIndex = 0;
            // 
            // btnLook
            // 
            this.btnLook.Location = new System.Drawing.Point(597, 6);
            this.btnLook.Name = "btnLook";
            this.btnLook.Size = new System.Drawing.Size(48, 23);
            this.btnLook.TabIndex = 2;
            this.btnLook.Text = "查询";
            this.btnLook.UseVisualStyleBackColor = true;
            this.btnLook.Click += new System.EventHandler(this.btnLook_Click);
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Location = new System.Drawing.Point(301, 8);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(258, 21);
            this.txtKeyWord.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "查询条件";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(254, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "关键字";
            // 
            // CRVPurPart
            // 
            this.CRVPurPart.ActiveViewIndex = -1;
            this.CRVPurPart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVPurPart.Location = new System.Drawing.Point(-2, 35);
            this.CRVPurPart.Name = "CRVPurPart";
            this.CRVPurPart.SelectionFormula = "";
            this.CRVPurPart.Size = new System.Drawing.Size(1272, 717);
            this.CRVPurPart.TabIndex = 27;
            this.CRVPurPart.ViewTimeSelectionFormula = "";
            // 
            // frmCRPurPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 750);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CRVPurPart);
            this.Controls.Add(this.btnLook);
            this.Controls.Add(this.txtKeyWord);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboxCondition);
            this.Name = "frmCRPurPart";
            this.Text = "采购明细表";
            this.Load += new System.EventHandler(this.frmCRPurPart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cboxCondition;
        private System.Windows.Forms.Button btnLook;
        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRVPurPart;

    }
}