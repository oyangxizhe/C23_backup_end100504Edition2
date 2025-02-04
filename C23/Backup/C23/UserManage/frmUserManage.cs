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
    public partial class frmUserManage : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected string M_str_sql = "select UserID as 用户编号,UName as 用户名称,UserPwd as 用户密码,Depart as 所属部门 from tb_User";
        protected string M_str_table = "tb_User";
        protected int M_int_judge,i;
       public static string[] inputgetOEName = new string[] { "","" };
        public frmUserManage()
        {
            InitializeComponent();
            this.cboxUName.Items.Add("");
        }
        private void frmUserManage_Load(object sender, EventArgs e)
        {
            BindData();
            dgvStateControl();

        }
        private void tsbtnLook_Click(object sender, EventArgs e)
        {
            try
            {
                if (tstxtKeyWord.Text == "")
                {
                    frmUserManage_Load(sender, e);
                }
                if (tscboxCondition.Text.Trim() == "用户编号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where UserID like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvUInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "用户名称")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where UName like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvUInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void dgvEditRight()
        {
            dgvUInfo.Enabled = true;
     

        }
        private void dgvUInfo_DoubleClick(object sender, EventArgs e)
        {
            if (dgvUInfo.Enabled == true)
            {
                 int indexNumber = dgvUInfo.CurrentCell.RowIndex;
                 string sendUserID, sendUName, sendDepart;
                 sendUserID = dgvUInfo.Rows[indexNumber].Cells[0].Value.ToString().Trim();
                 sendUName = dgvUInfo.Rows[indexNumber].Cells[1].Value.ToString().Trim();
                 sendDepart = dgvUInfo.Rows[indexNumber].Cells[3].Value.ToString().Trim();
                 string[] inputarry = new string[] { sendUserID,sendUName, sendDepart };
                    C23.UserManage.frmEditRight .getUserInfo[0]  = inputarry[0];
                    C23.UserManage.frmEditRight.getUserInfo[1] = inputarry[1];
                    C23.UserManage.frmEditRight.getUserInfo[2] = inputarry[2];
                    this.Close();
            }
        }  
        #region getEmployee
        private void cboxUName_DropDown(object sender, EventArgs e)
        {
            C23.EmployeeManage.frmEmployeeInfo frm = new C23.EmployeeManage.frmEmployeeInfo();
            frm.UserManage();
            frm.ShowDialog();
            setEmployeedata();
        }
        private void setEmployeedata()
        {
            this.cboxUName.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxUName.DroppedDown = false;//使组合框不显示其下拉部分
            cboxUName.Items[0] = inputgetOEName[0];
            txtDepart .Text = inputgetOEName[1];
            this.cboxUName.SelectedIndex = 0;
            this.cboxUName.IntegralHeight = true;//恢复默认值
       }
        #endregion
        #region BindData
        private void BindData()
        {
            dt = boperate.getdt(M_str_sql);
            dgvUInfo.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                tsbtnDel.Enabled = true;
            }
            else
            {
                tsbtnDel.Enabled = false;
            }

            for (i = 0; i < dgvUInfo.Columns.Count - 1; i++)
            {
                dgvUInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        #endregion
        #region dgvStateControl
        private void dgvStateControl()
        {
            int numCols = dgvUInfo.Columns.Count;
            for (i = 0; i < numCols; i++)
            {
                dgvUInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (i==3)
                {
                    dgvUInfo.Columns[i].Width = 200;
                }
                dgvUInfo.Columns[i].ReadOnly = true;   
            }
        }
        #endregion
        #region Add
        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            opAndvalidate.num("select Year,Month,UserID from tb_User", "select * from tb_User where Year='" + year +
                "' and Month='" + month + "'", "tb_User", "UserID", "UE", "0001", txtUserID);
            tsbtnSave.Enabled = true;
            M_int_judge = 0;
            ClearText();
        }
       #endregion
        public void ClearText()
        {
            cboxUName.Text = "";
            txtUserPwd.Text = "";
            txtDepart.Text = "";
        
        }
        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            tsbtnSave.Enabled = true;
            M_int_judge = 1;
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string varUserID, varUName,varPwd,varDepart;
            varUserID = txtUserID.Text.Trim();
            varUName = cboxUName.Text.Trim();
            varPwd = txtUserPwd.Text.Trim();
            varDepart = txtDepart.Text.Trim();
            if (M_int_judge == 0)
            {
                if (cboxUName.Text == "")
                {
                    MessageBox.Show("用户名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (txtDepart.Text == "")
                    {
                        MessageBox.Show("所属部门不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SqlDataReader sqlread = boperate.getread("select UName from tb_User where UName='" + varUName + "'");
                        sqlread.Read();
                        if (sqlread.HasRows)
                        {
                            MessageBox.Show("该用户已经存在,请重新输入");
                        }
                        else
                        {
                            boperate.getcom("insert into tb_User(Year,Month,UserID,UName,UserPwd,Depart) "
                                                  + "values('" + year + "','" + month + "','" + varUserID + "','" + varUName + "','" + varPwd + "','" + varDepart + "')");

                        }
                        sqlread.Close();
                    }
                }
                    frmUserManage_Load(sender, e);
                    tsbtnSave.Enabled = false;
                
            }
            if (M_int_judge == 1)
            {



                if (cboxUName.Text == "")
                {
                    MessageBox.Show("用户名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (txtDepart.Text == "")
                    {
                        MessageBox.Show("所属部门不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SqlDataReader sqlread = boperate.getread("select UName from tb_User where UName='" + varUName + "'");
                        sqlread.Read();
                        if (sqlread.HasRows)
                        {
                            MessageBox.Show("该用户已经存在,请重新输入");
                        }
                        else
                        {
                            boperate.getcom("update tb_User set UName='" + varUName + "',UserPwd='" + varPwd + "',Depart='" + varDepart +
                     "' where UserID='" + varUserID + "'");
                        }
                        sqlread.Close();
                    }
                }
                frmUserManage_Load(sender, e);
                tsbtnSave.Enabled = false;   
            }
        }

        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要删除该用户吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    boperate.getcom("delete from tb_User where UserID='" + Convert.ToString(dgvUInfo[0, dgvUInfo.CurrentCell.RowIndex].Value).Trim() + "'");
                    frmUserManage_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

     

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tsbtnSave.Enabled != true)
            {
                txtUserID.Text = Convert.ToString(dgvUInfo[0, dgvUInfo.CurrentCell.RowIndex].Value).Trim();
                cboxUName.Text = Convert.ToString(dgvUInfo[1, dgvUInfo.CurrentCell.RowIndex].Value).Trim();
                txtUserPwd.Text = Convert.ToString(dgvUInfo[2, dgvUInfo.CurrentCell.RowIndex].Value).Trim();
                txtDepart.Text = Convert.ToString(dgvUInfo[3, dgvUInfo.CurrentCell.RowIndex].Value).Trim();
            }
        }

        private void dgvUInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 把第4列显示*号，*号的个数和实际数据的长度相同
            if (e.ColumnIndex == 2)
            {
                if (e.Value != null && e.Value.ToString().Length > 0)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                }
            }

        }

      

       
    }
}
