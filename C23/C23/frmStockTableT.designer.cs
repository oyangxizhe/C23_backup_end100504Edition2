namespace C23.StockManage
{
    partial class frmStockTableT
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockTableT));
            this.bn = new System.Windows.Forms.BindingNavigator(this.components);
            this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnExit = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboxAcceptor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStokerName = new System.Windows.Forms.TextBox();
            this.txtStockID = new System.Windows.Forms.TextBox();
            this.cboxPur = new System.Windows.Forms.ComboBox();
            this.cboxStokerID = new System.Windows.Forms.ComboBox();
            this.dtpStockDate = new System.Windows.Forms.DateTimePicker();
            this.dgvStockInfo = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSTax = new System.Windows.Forms.TextBox();
            this.txtSNoTax = new System.Windows.Forms.TextBox();
            this.txtSTotalCount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bn)).BeginInit();
            this.bn.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // bn
            // 
            this.bn.AddNewItem = null;
            this.bn.CountItem = null;
            this.bn.DeleteItem = null;
            this.bn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAdd,
            this.toolStripSeparator1,
            this.tsbtnSave,
            this.toolStripSeparator3,
            this.tsbtnDel,
            this.toolStripSeparator2,
            this.tsbtnExit});
            this.bn.Location = new System.Drawing.Point(0, 0);
            this.bn.MoveFirstItem = null;
            this.bn.MoveLastItem = null;
            this.bn.MoveNextItem = null;
            this.bn.MovePreviousItem = null;
            this.bn.Name = "bn";
            this.bn.PositionItem = null;
            this.bn.Size = new System.Drawing.Size(1183, 25);
            this.bn.TabIndex = 0;
            this.bn.Text = "bindingNavigator1";
            // 
            // tsbtnAdd
            // 
            this.tsbtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAdd.Image")));
            this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAdd.Name = "tsbtnAdd";
            this.tsbtnAdd.Size = new System.Drawing.Size(23, 22);
            this.tsbtnAdd.Text = "新建";
            this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSave.Enabled = false;
            this.tsbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSave.Image")));
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(23, 22);
            this.tsbtnSave.Text = "保存";
            this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnDel
            // 
            this.tsbtnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnDel.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDel.Image")));
            this.tsbtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDel.Name = "tsbtnDel";
            this.tsbtnDel.Size = new System.Drawing.Size(23, 22);
            this.tsbtnDel.Text = "删除";
            this.tsbtnDel.Click += new System.EventHandler(this.tsbtnDel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnExit
            // 
            this.tsbtnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnExit.Image")));
            this.tsbtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnExit.Name = "tsbtnExit";
            this.tsbtnExit.Size = new System.Drawing.Size(23, 22);
            this.tsbtnExit.Text = "退出";
            this.tsbtnExit.Click += new System.EventHandler(this.tsbtnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.cboxAcceptor);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtStokerName);
            this.groupBox1.Controls.Add(this.txtStockID);
            this.groupBox1.Controls.Add(this.cboxPur);
            this.groupBox1.Controls.Add(this.cboxStokerID);
            this.groupBox1.Controls.Add(this.dtpStockDate);
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1183, 82);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "进货单信息";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(669, 59);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 40;
            this.label16.Text = "验收人";
            // 
            // cboxAcceptor
            // 
            this.cboxAcceptor.FormattingEnabled = true;
            this.cboxAcceptor.Location = new System.Drawing.Point(716, 49);
            this.cboxAcceptor.Name = "cboxAcceptor";
            this.cboxAcceptor.Size = new System.Drawing.Size(121, 20);
            this.cboxAcceptor.TabIndex = 39;
            this.cboxAcceptor.DropDown += new System.EventHandler(this.cboxAcceptor_DropDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(669, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 37;
            this.label5.Text = "采购员";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(316, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 36;
            this.label4.Text = "供运商名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 35;
            this.label3.Text = "供运商编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 34;
            this.label2.Text = "进货日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "进货单号";
            // 
            // txtStokerName
            // 
            this.txtStokerName.Location = new System.Drawing.Point(387, 50);
            this.txtStokerName.Name = "txtStokerName";
            this.txtStokerName.Size = new System.Drawing.Size(192, 21);
            this.txtStokerName.TabIndex = 33;
            // 
            // txtStockID
            // 
            this.txtStockID.Location = new System.Drawing.Point(133, 21);
            this.txtStockID.Name = "txtStockID";
            this.txtStockID.ReadOnly = true;
            this.txtStockID.Size = new System.Drawing.Size(121, 21);
            this.txtStockID.TabIndex = 29;
            // 
            // cboxPur
            // 
            this.cboxPur.FormattingEnabled = true;
            this.cboxPur.Location = new System.Drawing.Point(716, 23);
            this.cboxPur.Name = "cboxPur";
            this.cboxPur.Size = new System.Drawing.Size(121, 20);
            this.cboxPur.TabIndex = 38;
            this.cboxPur.DropDown += new System.EventHandler(this.cboxPur_DropDown);
            // 
            // cboxStokerID
            // 
            this.cboxStokerID.FormattingEnabled = true;
            this.cboxStokerID.Location = new System.Drawing.Point(387, 24);
            this.cboxStokerID.Name = "cboxStokerID";
            this.cboxStokerID.Size = new System.Drawing.Size(192, 20);
            this.cboxStokerID.TabIndex = 32;
            this.cboxStokerID.DropDown += new System.EventHandler(this.cboxStokerID_DropDown);
            // 
            // dtpStockDate
            // 
            this.dtpStockDate.Location = new System.Drawing.Point(133, 49);
            this.dtpStockDate.Name = "dtpStockDate";
            this.dtpStockDate.Size = new System.Drawing.Size(121, 21);
            this.dtpStockDate.TabIndex = 30;
            // 
            // dgvStockInfo
            // 
            this.dgvStockInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStockInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvStockInfo.Location = new System.Drawing.Point(-1, 116);
            this.dgvStockInfo.Name = "dgvStockInfo";
            this.dgvStockInfo.RowTemplate.Height = 23;
            this.dgvStockInfo.Size = new System.Drawing.Size(1183, 426);
            this.dgvStockInfo.TabIndex = 2;
            this.dgvStockInfo.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvStockInfo_RowsAdded);
            this.dgvStockInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockInfo_CellClick);
            this.dgvStockInfo.DataSourceChanged += new System.EventHandler(this.dgvStockInfo_DataSourceChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(964, 569);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 23;
            this.label9.Text = "合计税额:";
            this.label9.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(466, 569);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "合计不含税金额:";
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 569);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "合计金额:";
            this.label7.Visible = false;
            // 
            // txtSTax
            // 
            this.txtSTax.Location = new System.Drawing.Point(1029, 560);
            this.txtSTax.Name = "txtSTax";
            this.txtSTax.ReadOnly = true;
            this.txtSTax.Size = new System.Drawing.Size(100, 21);
            this.txtSTax.TabIndex = 26;
            this.txtSTax.Visible = false;
            // 
            // txtSNoTax
            // 
            this.txtSNoTax.Location = new System.Drawing.Point(567, 560);
            this.txtSNoTax.Name = "txtSNoTax";
            this.txtSNoTax.ReadOnly = true;
            this.txtSNoTax.Size = new System.Drawing.Size(100, 21);
            this.txtSNoTax.TabIndex = 25;
            this.txtSNoTax.Visible = false;
            // 
            // txtSTotalCount
            // 
            this.txtSTotalCount.Location = new System.Drawing.Point(103, 560);
            this.txtSTotalCount.Name = "txtSTotalCount";
            this.txtSTotalCount.ReadOnly = true;
            this.txtSTotalCount.Size = new System.Drawing.Size(100, 21);
            this.txtSTotalCount.TabIndex = 24;
            this.txtSTotalCount.Visible = false;
            // 
            // frmStockTableT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 584);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSTax);
            this.Controls.Add(this.txtSNoTax);
            this.Controls.Add(this.txtSTotalCount);
            this.Controls.Add(this.dgvStockInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bn);
            this.Name = "frmStockTableT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建进货单";
            this.Load += new System.EventHandler(this.frmStockTableT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bn)).EndInit();
            this.bn.ResumeLayout(false);
            this.bn.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvStockInfo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboxAcceptor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStokerName;
        private System.Windows.Forms.TextBox txtStockID;
        private System.Windows.Forms.ComboBox cboxPur;
        private System.Windows.Forms.ComboBox cboxStokerID;
        private System.Windows.Forms.DateTimePicker dtpStockDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSTax;
        private System.Windows.Forms.TextBox txtSNoTax;
        private System.Windows.Forms.TextBox txtSTotalCount;
        private System.Windows.Forms.ToolStripButton tsbtnAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnExit;
    }
}