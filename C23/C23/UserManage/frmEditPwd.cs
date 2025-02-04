using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace C23.UserManage
{
    public partial class frmEditPwd : Form
    {
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        public frmEditPwd()
        {
            InitializeComponent();
        }

        private void frmEditPwd_Load(object sender, EventArgs e)
        {
            txtUName.Text = frmLogin.M_str_name;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (txtFUNPwd.Text.Trim() != txtUNPwd.Text.Trim())
            {
                errorPrPwd.SetError(txtFUNPwd, "输入密码不一致！");
                MessageBox.Show("输入密码不一致", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (txtUOPwd.Text.Trim() != C23.frmLogin.M_str_pwd)
                {
                    MessageBox.Show("用户旧密码输入错误，请重新输入！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    boperate.getcom("update tb_User set UserPwd='" + txtUNPwd.Text.Trim() + "'where UName='" + txtUName.Text.Trim() + "'");
                    MessageBox.Show("密码修改成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
