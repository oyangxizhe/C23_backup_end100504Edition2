namespace C23.AccountManage
{
    partial class frmReceivPart
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
            this.dgvReceivPartInfo = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxCondition = new System.Windows.Forms.ComboBox();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLook = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKeyWord2 = new System.Windows.Forms.TextBox();
            this.txtKeyWord3 = new System.Windows.Forms.TextBox();
            this.txtKeyWord1 = new System.Windows.Forms.TextBox();
            this.cboxCondition2 = new System.Windows.Forms.ComboBox();
            this.cboxCondition3 = new System.Windows.Forms.ComboBox();
            this.cboxCondition1 = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceivPartInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvReceivPartInfo
            // 
            this.dgvReceivPartInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReceivPartInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceivPartInfo.Location = new System.Drawing.Point(0, 136);
            this.dgvReceivPartInfo.Name = "dgvReceivPartInfo";
            this.dgvReceivPartInfo.RowTemplate.Height = 23;
            this.dgvReceivPartInfo.Size = new System.Drawing.Size(1183, 449);
            this.dgvReceivPartInfo.TabIndex = 10;
            this.dgvReceivPartInfo.DataSourceChanged += new System.EventHandler(this.dgvReceivPartInfo_DataSourceChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "查询条件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "关键字";
            // 
            // cboxCondition
            // 
            this.cboxCondition.FormattingEnabled = true;
            this.cboxCondition.Items.AddRange(new object[] {
            "",
            "客户编号",
            "客户名称",
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboxCondition);
            this.groupBox1.Controls.Add(this.txtKeyWord);
            this.groupBox1.Location = new System.Drawing.Point(0, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(577, 46);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "简单查询";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(823, 18);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(48, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLook
            // 
            this.btnLook.Location = new System.Drawing.Point(696, 18);
            this.btnLook.Name = "btnLook";
            this.btnLook.Size = new System.Drawing.Size(48, 23);
            this.btnLook.TabIndex = 2;
            this.btnLook.Text = "查询";
            this.btnLook.UseVisualStyleBackColor = true;
            this.btnLook.Click += new System.EventHandler(this.btnLook_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtKeyWord2);
            this.groupBox2.Controls.Add(this.txtKeyWord3);
            this.groupBox2.Controls.Add(this.txtKeyWord1);
            this.groupBox2.Controls.Add(this.cboxCondition2);
            this.groupBox2.Controls.Add(this.cboxCondition3);
            this.groupBox2.Controls.Add(this.cboxCondition1);
            this.groupBox2.Location = new System.Drawing.Point(0, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1181, 77);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "高级查询";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(260, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "关键字三";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "查询条件三";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(832, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "关键字二";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "关键字一";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(625, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "查询条件二";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "查询条件一";
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
            "客户编号",
            "客户名称"});
            this.cboxCondition1.Location = new System.Drawing.Point(124, 20);
            this.cboxCondition1.Name = "cboxCondition1";
            this.cboxCondition1.Size = new System.Drawing.Size(121, 20);
            this.cboxCondition1.TabIndex = 4;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(760, 18);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(48, 23);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmReceivPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 584);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLook);
            this.Controls.Add(this.dgvReceivPartInfo);
            this.Name = "frmReceivPart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "应收帐款明细";
            this.Load += new System.EventHandler(this.frmReceivPart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceivPartInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReceivPartInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxCondition;
        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKeyWord2;
        private System.Windows.Forms.TextBox txtKeyWord3;
        private System.Windows.Forms.TextBox txtKeyWord1;
        private System.Windows.Forms.ComboBox cboxCondition2;
        private System.Windows.Forms.ComboBox cboxCondition3;
        private System.Windows.Forms.ComboBox cboxCondition1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLook;
        private System.Windows.Forms.Button btnPrint;
    }
}