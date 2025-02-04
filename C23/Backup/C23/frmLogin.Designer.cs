namespace C23
{
    partial class frmLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cboxUName = new System.Windows.Forms.ComboBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.labURight = new System.Windows.Forms.Label();
            this.labDepart = new System.Windows.Forms.Label();
            this.labUserID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboxUName
            // 
            this.cboxUName.FormattingEnabled = true;
            this.cboxUName.Location = new System.Drawing.Point(101, 44);
            this.cboxUName.Name = "cboxUName";
            this.cboxUName.Size = new System.Drawing.Size(115, 20);
            this.cboxUName.TabIndex = 0;
            this.cboxUName.SelectedIndexChanged += new System.EventHandler(this.cboxUName_SelectedIndexChanged);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(101, 74);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(115, 21);
            this.txtPwd.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(54, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "用户名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(54, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "密  码:";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(90, 118);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "登陆";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(182, 118);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labURight
            // 
            this.labURight.AutoSize = true;
            this.labURight.Location = new System.Drawing.Point(204, 160);
            this.labURight.Name = "labURight";
            this.labURight.Size = new System.Drawing.Size(0, 12);
            this.labURight.TabIndex = 7;
            // 
            // labDepart
            // 
            this.labDepart.AutoSize = true;
            this.labDepart.Location = new System.Drawing.Point(99, 103);
            this.labDepart.Name = "labDepart";
            this.labDepart.Size = new System.Drawing.Size(0, 12);
            this.labDepart.TabIndex = 8;
            this.labDepart.Visible = false;
            // 
            // labUserID
            // 
            this.labUserID.AutoSize = true;
            this.labUserID.Location = new System.Drawing.Point(88, 160);
            this.labUserID.Name = "labUserID";
            this.labUserID.Size = new System.Drawing.Size(0, 12);
            this.labUserID.TabIndex = 9;
            this.labUserID.Visible = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 181);
            this.Controls.Add(this.labUserID);
            this.Controls.Add(this.labDepart);
            this.Controls.Add(this.labURight);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.cboxUName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "进销存管理系统登陆窗口";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboxUName;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label labURight;
        private System.Windows.Forms.Label labDepart;
        private System.Windows.Forms.Label labUserID;
    }
}

