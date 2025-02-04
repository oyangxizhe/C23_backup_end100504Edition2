namespace C23.AccountManage
{
    partial class frmPayPart
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
            this.dgvInfo = new System.Windows.Forms.DataGridView();
            this.btnLook = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboxCondition = new System.Windows.Forms.ComboBox();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtKeyWord2 = new System.Windows.Forms.TextBox();
            this.txtKeyWord3 = new System.Windows.Forms.TextBox();
            this.txtKeyWord1 = new System.Windows.Forms.TextBox();
            this.cboxCondition2 = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboxCondition3 = new System.Windows.Forms.ComboBox();
            this.cboxCondition1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInfo
            // 
            this.dgvInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfo.Location = new System.Drawing.Point(0, 135);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.RowTemplate.Height = 23;
            this.dgvInfo.Size = new System.Drawing.Size(1183, 450);
            this.dgvInfo.TabIndex = 1;
            this.dgvInfo.DataSourceChanged += new System.EventHandler(this.dgvInfo_DataSourceChanged);
            // 
            // btnLook
            // 
            this.btnLook.Location = new System.Drawing.Point(696, 17);
            this.btnLook.Name = "btnLook";
            this.btnLook.Size = new System.Drawing.Size(48, 23);
            this.btnLook.TabIndex = 17;
            this.btnLook.Text = "查询";
            this.btnLook.UseVisualStyleBackColor = true;
            this.btnLook.Click += new System.EventHandler(this.btnLook_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(260, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "关键字三";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(272, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "关键字";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(53, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 15;
            this.label11.Text = "查询条件三";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(760, 17);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(48, 23);
            this.btnPrint.TabIndex = 21;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(832, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 14;
            this.label12.Text = "关键字二";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(824, 17);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(48, 23);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cboxCondition);
            this.groupBox3.Controls.Add(this.txtKeyWord);
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(577, 46);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "简单查询";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(65, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 2;
            this.label13.Text = "查询条件";
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
            "来源单号",
            "单据名称",
            "单据日期"});
            this.cboxCondition.Location = new System.Drawing.Point(124, 20);
            this.cboxCondition.Name = "cboxCondition";
            this.cboxCondition.Size = new System.Drawing.Size(121, 20);
            this.cboxCondition.TabIndex = 0;
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Location = new System.Drawing.Point(319, 19);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(258, 21);
            this.txtKeyWord.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(260, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 13;
            this.label14.Text = "关键字一";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(625, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 12;
            this.label15.Text = "查询条件二";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(53, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 11;
            this.label16.Text = "查询条件一";
            // 
            // txtKeyWord2
            // 
            this.txtKeyWord2.Location = new System.Drawing.Point(891, 17);
            this.txtKeyWord2.Name = "txtKeyWord2";
            this.txtKeyWord2.Size = new System.Drawing.Size(258, 21);
            this.txtKeyWord2.TabIndex = 7;
            // 
            // txtKeyWord3
            // 
            this.txtKeyWord3.Location = new System.Drawing.Point(319, 46);
            this.txtKeyWord3.Name = "txtKeyWord3";
            this.txtKeyWord3.Size = new System.Drawing.Size(258, 21);
            this.txtKeyWord3.TabIndex = 9;
            // 
            // txtKeyWord1
            // 
            this.txtKeyWord1.Location = new System.Drawing.Point(319, 18);
            this.txtKeyWord1.Name = "txtKeyWord1";
            this.txtKeyWord1.Size = new System.Drawing.Size(258, 21);
            this.txtKeyWord1.TabIndex = 5;
            // 
            // cboxCondition2
            // 
            this.cboxCondition2.FormattingEnabled = true;
            this.cboxCondition2.Items.AddRange(new object[] {
            "",
            "品号",
            "品名"});
            this.cboxCondition2.Location = new System.Drawing.Point(696, 18);
            this.cboxCondition2.Name = "cboxCondition2";
            this.cboxCondition2.Size = new System.Drawing.Size(121, 20);
            this.cboxCondition2.TabIndex = 6;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.txtKeyWord2);
            this.groupBox4.Controls.Add(this.txtKeyWord3);
            this.groupBox4.Controls.Add(this.txtKeyWord1);
            this.groupBox4.Controls.Add(this.cboxCondition2);
            this.groupBox4.Controls.Add(this.cboxCondition3);
            this.groupBox4.Controls.Add(this.cboxCondition1);
            this.groupBox4.Location = new System.Drawing.Point(0, 52);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1181, 77);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "高级查询";
            // 
            // cboxCondition3
            // 
            this.cboxCondition3.FormattingEnabled = true;
            this.cboxCondition3.Items.AddRange(new object[] {
            "",
            "来源单号",
            "单据名称"});
            this.cboxCondition3.Location = new System.Drawing.Point(124, 47);
            this.cboxCondition3.Name = "cboxCondition3";
            this.cboxCondition3.Size = new System.Drawing.Size(121, 20);
            this.cboxCondition3.TabIndex = 8;
            // 
            // cboxCondition1
            // 
            this.cboxCondition1.FormattingEnabled = true;
            this.cboxCondition1.Items.AddRange(new object[] {
            "",
            "供运商编号",
            "供运商名称"});
            this.cboxCondition1.Location = new System.Drawing.Point(124, 20);
            this.cboxCondition1.Name = "cboxCondition1";
            this.cboxCondition1.Size = new System.Drawing.Size(121, 20);
            this.cboxCondition1.TabIndex = 4;
            // 
            // frmPayPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 584);
            this.Controls.Add(this.btnLook);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dgvInfo);
            this.Name = "frmPayPart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "应付帐款明细";
            this.Load += new System.EventHandler(this.frmPayPart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInfo;
        private System.Windows.Forms.Button btnLook;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboxCondition;
        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtKeyWord2;
        private System.Windows.Forms.TextBox txtKeyWord3;
        private System.Windows.Forms.TextBox txtKeyWord1;
        private System.Windows.Forms.ComboBox cboxCondition2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboxCondition3;
        private System.Windows.Forms.ComboBox cboxCondition1;
    }
}