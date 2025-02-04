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
    public partial class frmEditRight : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected string M_str_sql = "select UserID as 用户编号,UName as 用户名称,RightName as 权限名称,"
            + "Depart as 所属部门 from tb_RightList ";
        protected string M_str_table = "tb_User";
        protected int M_int_judge, i;
        public  bool blInitial = true;
        public static string[] getUserInfo = new string[] { "", "","" };
        public frmEditRight()
        {
            InitializeComponent();
            this.cboxUserID.Items.Add("");
        }
       private void frmEditRight_Load(object sender, EventArgs e)
        {
            BindData();
            dgvStateControl();
            if (dt.Rows.Count > 0)
            {
                string selectedUserID = dt.Rows[0][0].ToString();//默认选中用户清单中的第一个用户
                string M_str_sql1 = "select UserID as 用户编号,UName as 用户名称,RightName as 权限名称,"
                    + "Depart as 所属部门 from tb_RightList where UserID='" + selectedUserID + "' ";

                DataTable dt2 = boperate.getdt(M_str_sql1);

                for (i = 0; i < dt2.Rows.Count; i++)//根据权限设置ListBox
                {
                    for (int j = 0; j < this.chkLst_Priority.Items.Count; j++)
                    {
                        if (this.chkLst_Priority.Items[j].ToString().Trim() == dt2.Rows[i][2].ToString().Trim())
                        {
                            this.chkLst_Priority.SetItemChecked(j, true);
                        }
                    }
                }
            }
        }
        #region BindData
        private void BindData()
        {
            dt = boperate.getdt(M_str_sql);
            dgvERInfo.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                tsbtnDel.Enabled = true;
            }
            else
            {
                tsbtnDel.Enabled = false;
            }

            for (i = 0; i < dgvERInfo.Columns.Count - 1; i++)
            {
                dgvERInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            }
        }
        #endregion
        #region dgvStateControl
        private void dgvStateControl()
        {
            int numCols = dgvERInfo.Columns.Count;
            for (i = 0; i < numCols; i++)
            {
                dgvERInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (i==2 || i == 3)
                {
                    dgvERInfo.Columns[i].Width = 150;
                }
               dgvERInfo.Columns[i].ReadOnly = true;     
            }
        }
        #endregion

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region UserInfo
        private void cboxUserID_DropDown(object sender, EventArgs e)
        {
            C23.UserManage.frmUserManage frm = new frmUserManage();
            frm.dgvEditRight();
            frm.ShowDialog();
            setUserID();
         }
        private void setUserID()
        {
            this.cboxUserID.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxUserID.DroppedDown = false;//使组合框不显示其下拉部分
            cboxUserID.Items[0] = getUserInfo[0];
            txtUName.Text = getUserInfo[1];
            txtDepart.Text = getUserInfo[2];
            this.cboxUserID.SelectedIndex = 0;
            this.cboxUserID.IntegralHeight = true;//恢复默认值
        }
        #endregion
        #region Add
        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chkLst_Priority.Items.Count; i++)
            {
                chkLst_Priority.SetItemChecked(i, false);
            }
            tsbtnSave.Enabled = true;
            M_int_judge = 0;
            ClearText();
        }
        #endregion
        public void ClearText()
        {
            cboxUserID.Text = "";
            txtUName.Text = "";
            txtDepart.Text = "";

        }
        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            tsbtnSave.Enabled = true;
            M_int_judge = 1;
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            string strCollected = string.Empty;
            string varUserID,varUName,varDepart;
             varUserID = cboxUserID.Text.Trim();
             varUName = txtUName.Text.Trim();
             varDepart = txtDepart.Text.Trim();
             #region Add
             if (M_int_judge == 0)
            {
                if (cboxUserID.Text == "")
                {
                    MessageBox.Show("用户编号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    for (i = 0; i < chkLst_Priority.Items.Count; i++)
                    {
                        if (chkLst_Priority.GetItemChecked(i))
                        {
                           
                                
                                string strPopedom = chkLst_Priority.Items[i].ToString();
                                string tempSendStrSQL = "insert tb_RightList (UserID,UName,RightName,Depart) values ('" + varUserID +
                                    "','" + varUName + "','" + strPopedom + "','" + varDepart + "' )";
                                boperate.getcom(tempSendStrSQL);        
                        }
                    }
                    frmEditRight_Load(sender, e);
                    tsbtnSave.Enabled = false;
                }

            }
             #endregion
             if (M_int_judge == 1)
            {
                if (cboxUserID.Text == "")
                {
                    MessageBox.Show("用户编号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                  frmEditRight_Load(sender, e);
                  tsbtnSave.Enabled = false;
                }
            }
        }
        #region Del
        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要删除该用户吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    boperate.getcom("delete from tb_RightList where UserID='" + Convert.ToString(dgvERInfo[0, dgvERInfo.CurrentCell.RowIndex].Value).Trim() + 
                        "' and RightName='"+Convert .ToString (dgvERInfo [2,dgvERInfo .CurrentCell .RowIndex ].Value ).Trim ()+"'");
                    frmEditRight_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Look
        private void tsbtnLook_Click(object sender, EventArgs e)
        {
            try
            {
                if (tstxtKeyWord.Text == "")
                {
                    frmEditRight_Load(sender, e);
                }
                if (tscboxCondition.Text.Trim() == "用户编号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where UserID like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvERInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "用户名称")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where UName like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvERInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        private void dgvERInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tsbtnSave.Enabled != true)
            {
                cboxUserID.Text = Convert.ToString(dgvERInfo[0, dgvERInfo.CurrentCell.RowIndex].Value).Trim();
                txtUName.Text = Convert.ToString(dgvERInfo[1, dgvERInfo.CurrentCell.RowIndex].Value).Trim();
                txtDepart.Text = Convert.ToString(dgvERInfo[3, dgvERInfo.CurrentCell.RowIndex].Value).Trim();
            }

        }
        #region Select
        private void Select_all_CheckedChanged(object sender, EventArgs e)
        {
            if (Select_all.Checked)
            {
                for (int j = 0; j < chkLst_Priority.Items.Count; j++)
                    chkLst_Priority.SetItemChecked(j, true);

            }
            else
            {
                for (int j = 0; j < chkLst_Priority.Items.Count; j++)
                    chkLst_Priority.SetItemChecked(j, false);

            }

        }
        #endregion
        #region chbInverse
        private void chbInverse_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chkLst_Priority.Items.Count; i++)
            {
                if (chkLst_Priority.GetItemChecked(i))
                {
                    chkLst_Priority.SetItemChecked(i, false);
                }
                else
                {
                    chkLst_Priority.SetItemChecked(i, true);
                }
            }
        }
        #endregion
        private void dgvERInfo_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.dgvERInfo .CurrentCell.RowIndex  >= this.dt.Rows.Count)//防止出现所选的用户不在数据表中的情况
            {
                return;
            }
            this.chkLst_Priority.Enabled = true;
            blInitial = true; //控制当【权限管理】窗体刚生成时和点击其他用户时使CheckedListBox控件中数据发生改变时不响应ItemCheck事件
            //以下代码实现的是当dataGrid中所选用户改变时，根据选中用户权限重新设置listBox的功能
            for (i = 0; i < this.chkLst_Priority.Items.Count; i++)//将listBox中所有权限设为未选中
            {
                this.chkLst_Priority.SetItemChecked(i, false);
            }
            int intRowNumber = this.dgvERInfo .CurrentCell.RowIndex ;
            string selectedUserID = this.dt.Rows[intRowNumber][0].ToString();
            string M_str_sql2 = "select UserID as 用户编号,UName as 用户名称,RightName as 权限名称,"
                 + "Depart as 所属部门 from tb_RightList where UserID='" + selectedUserID + "' ";
       
            DataTable dt3 = boperate.getdt(M_str_sql2);
            for (int i = 0; i < dt3.Rows.Count; i++)//重新设置listBox
            {
                for (int j = 0; j < this.chkLst_Priority.Items.Count; j++)
                {
                    if (this.chkLst_Priority.Items[j].ToString().Trim() == dt3.Rows[i][2].ToString().Trim())
                    {
                        this.chkLst_Priority.SetItemChecked(j, true);
                    }
                }
            }
            blInitial = false;

        }
 
    }
}
