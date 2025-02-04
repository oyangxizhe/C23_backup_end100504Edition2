using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace C23
{
    public partial class frmLogin : Form
    {
        public static string M_str_UserID;//记录登录用户编号
        public static string M_str_name;//记录登录用户名字
        public static string M_str_pwd;//记录登录用户密码
        public static string M_str_Depart;//记录登录用户的部门
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            opAndvalidate.cboxBind("select UName from tb_User", "tb_User", "UName", cboxUName);
     
         
        }

        private void cboxUName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataReader sqlread = boperate.getread("select UserID,UName,Depart from tb_User where UName='" + cboxUName.Text + "'");
            if (sqlread.Read())
            {
                labUserID.Text = sqlread["UserID"].ToString();
                labDepart.Text = sqlread["Depart"].ToString();
                M_str_UserID = labUserID.Text;
                M_str_Depart = labDepart.Text;
            }
            sqlread.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlDataReader sqlread = boperate.getread("select UName,UserPwd from tb_User where UName='" + cboxUName.Text.Trim() + "' and UserPwd='" + txtPwd.Text.Trim() + "'");
            sqlread.Read();
            if (sqlread.HasRows)
            {
                M_str_name = cboxUName.Text;
                M_str_pwd = txtPwd.Text.Trim();
                frmMain fmain = new frmMain();
                this.Hide();
               
                fmain.Show();
            }
            else
            {
                MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPwd.Text = "";
                cboxUName.Focus();
            }
            sqlread.Close();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    
    }
}
