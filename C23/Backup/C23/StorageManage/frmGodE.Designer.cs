namespace C23.StorageManage
{
    partial class frmGodE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGodE));
            this.bn = new System.Windows.Forms.BindingNavigator(this.components);
            this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tscboxCondition = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tstxtKeyWord = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnLook = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRLock = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnLock = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnExit = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxGoder = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboxAcceptor = new System.Windows.Forms.ComboBox();
            this.dtpGodEDate = new System.Windows.Forms.DateTimePicker();
            this.txtGodEID = new System.Windows.Forms.TextBox();
            this.dgvGOInfo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.bn)).BeginInit();
            this.bn.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGOInfo)).BeginInit();
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
            this.tsbtnPrint,
            this.toolStripSeparator8,
            this.tsbtnDel,
            this.toolStripSeparator4,
            this.toolStripLabel1,
            this.tscboxCondition,
            this.toolStripSeparator5,
            this.toolStripLabel2,
            this.tstxtKeyWord,
            this.toolStripSeparator6,
            this.tsbtnLook,
            this.toolStripSeparator7,
            this.tsbtnRLock,
            this.toolStripSeparator2,
            this.tsbtnLock,
            this.toolStripSeparator9,
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
            // tsbtnPrint
            // 
            this.tsbtnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnPrint.Image")));
            this.tsbtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPrint.Name = "tsbtnPrint";
            this.tsbtnPrint.Size = new System.Drawing.Size(23, 22);
            this.tsbtnPrint.Text = "打印";
            this.tsbtnPrint.Click += new System.EventHandler(this.tsbtnPrint_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnDel
            // 
            this.tsbtnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnDel.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDel.Image")));
            this.tsbtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDel.Name = "tsbtnDel";
            this.tsbtnDel.Size = new System.Drawing.Size(23, 22);
            this.tsbtnDel.Text = "删除";
            this.tsbtnDel.Visible = false;
            this.tsbtnDel.Click += new System.EventHandler(this.tsbtnDel_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel1.Text = "查询条件";
            // 
            // tscboxCondition
            // 
            this.tscboxCondition.Items.AddRange(new object[] {
            "按入库单号",
            "按入库日期",
            "按品号",
            "按品名"});
            this.tscboxCondition.Name = "tscboxCondition";
            this.tscboxCondition.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(41, 22);
            this.toolStripLabel2.Text = "关键字";
            // 
            // tstxtKeyWord
            // 
            this.tstxtKeyWord.Name = "tstxtKeyWord";
            this.tstxtKeyWord.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnLook
            // 
            this.tsbtnLook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnLook.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLook.Image")));
            this.tsbtnLook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLook.Name = "tsbtnLook";
            this.tsbtnLook.Size = new System.Drawing.Size(23, 22);
            this.tsbtnLook.Text = "查询";
            this.tsbtnLook.Click += new System.EventHandler(this.tsbtnLook_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnRLock
            // 
            this.tsbtnRLock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRLock.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRLock.Image")));
            this.tsbtnRLock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRLock.Name = "tsbtnRLock";
            this.tsbtnRLock.Size = new System.Drawing.Size(23, 22);
            this.tsbtnRLock.Text = "解锁";
            this.tsbtnRLock.Click += new System.EventHandler(this.tsbtnRLock_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnLock
            // 
            this.tsbtnLock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnLock.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLock.Image")));
            this.tsbtnLock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLock.Name = "tsbtnLock";
            this.tsbtnLock.Size = new System.Drawing.Size(23, 22);
            this.tsbtnLock.Text = "锁定";
            this.tsbtnLock.Click += new System.EventHandler(this.tsbtnLock_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
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
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboxGoder);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboxAcceptor);
            this.groupBox1.Controls.Add(this.dtpGodEDate);
            this.groupBox1.Controls.Add(this.txtGodEID);
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1183, 78);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "入库单信息";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(339, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "入库员";
            // 
            // cboxGoder
            // 
            this.cboxGoder.FormattingEnabled = true;
            this.cboxGoder.Location = new System.Drawing.Point(386, 18);
            this.cboxGoder.Name = "cboxGoder";
            this.cboxGoder.Size = new System.Drawing.Size(121, 20);
            this.cboxGoder.TabIndex = 23;
            this.cboxGoder.DropDown += new System.EventHandler(this.cboxGoder_DropDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(339, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "验收人";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "入库日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "入库单号";
            // 
            // cboxAcceptor
            // 
            this.cboxAcceptor.FormattingEnabled = true;
            this.cboxAcceptor.Location = new System.Drawing.Point(386, 45);
            this.cboxAcceptor.Name = "cboxAcceptor";
            this.cboxAcceptor.Size = new System.Drawing.Size(121, 20);
            this.cboxAcceptor.TabIndex = 3;
            this.cboxAcceptor.DropDown += new System.EventHandler(this.cboxAcceptor_DropDown);
            // 
            // dtpGodEDate
            // 
            this.dtpGodEDate.Location = new System.Drawing.Point(132, 45);
            this.dtpGodEDate.Name = "dtpGodEDate";
            this.dtpGodEDate.Size = new System.Drawing.Size(121, 21);
            this.dtpGodEDate.TabIndex = 2;
            // 
            // txtGodEID
            // 
            this.txtGodEID.Location = new System.Drawing.Point(132, 18);
            this.txtGodEID.Name = "txtGodEID";
            this.txtGodEID.ReadOnly = true;
            this.txtGodEID.Size = new System.Drawing.Size(121, 21);
            this.txtGodEID.TabIndex = 0;
            // 
            // dgvGOInfo
            // 
            this.dgvGOInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGOInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGOInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvGOInfo.Location = new System.Drawing.Point(0, 112);
            this.dgvGOInfo.Name = "dgvGOInfo";
            this.dgvGOInfo.RowTemplate.Height = 23;
            this.dgvGOInfo.Size = new System.Drawing.Size(1183, 426);
            this.dgvGOInfo.TabIndex = 2;
            this.dgvGOInfo.DoubleClick += new System.EventHandler(this.dgvGOInfo_DoubleClick);
            this.dgvGOInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGOInfo_CellClick);
            this.dgvGOInfo.DataSourceChanged += new System.EventHandler(this.dgvGOInfo_DataSourceChanged);
            // 
            // frmGodE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 584);
            this.Controls.Add(this.dgvGOInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bn);
            this.Name = "frmGodE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "录入入库单";
            this.Load += new System.EventHandler(this.frmGodE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bn)).EndInit();
            this.bn.ResumeLayout(false);
            this.bn.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGOInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpGodEDate;
        private System.Windows.Forms.TextBox txtGodEID;
        private System.Windows.Forms.DataGridView dgvGOInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxAcceptor;
        private System.Windows.Forms.ToolStripButton tsbtnAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnSave;
        private System.Windows.Forms.ToolStripButton tsbtnDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tscboxCondition;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tstxtKeyWord;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbtnLook;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tsbtnExit;
        private System.Windows.Forms.ToolStripButton tsbtnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboxGoder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnRLock;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnLock;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
    }
}