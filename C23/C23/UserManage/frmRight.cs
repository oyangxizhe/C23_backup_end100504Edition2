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
    public partial class frmRight : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected string M_str_sql = "select cast(0   as   bit)   as   复选框,RightID as 权限编号,RightName as 权限名称 from tb_Right";
        protected string M_str_table = "tb_Right";
        protected int M_int_judge, i;
        public frmRight()
        {
            InitializeComponent();
        }

        private void frmRight_Load(object sender, EventArgs e)
        {
            BindData();
            dgvStateControl();

        }
        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            tsbtnSave.Enabled = true;
            M_int_judge = 1;
        }
        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            opAndvalidate.num("select Year,Month,RightID from tb_Right", "select * from tb_Right where Year='" + year +
                "' and Month='" + month + "'", "tb_Right", "RightID", "RI", "0001", txtRightID);
            tsbtnSave.Enabled = true;
            M_int_judge = 0;
            ClearText();
        }
        #region BindData
        private void BindData()
        {
            dt = boperate.getdt(M_str_sql);
            dgvRInfo.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                tsbtnDel.Enabled = true;
            }
            else
            {
                tsbtnDel.Enabled = false;
            }

            for (i = 0; i <dgvRInfo.Columns.Count - 1; i++)
            {
                dgvRInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
              

            }
        }
        #endregion
        #region dgvStateControl
        private void dgvStateControl()
        {
            int numCols = dgvRInfo.Columns.Count;
            for (i = 0; i < numCols; i++)
            {
                dgvRInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (i == 0)
                {
                    dgvRInfo.Columns[i].Width = 60;
                }
                if (i==1 || i == 2)
                {
                    dgvRInfo.Columns[i].Width = 220;
                }
              
            }
        }
        #endregion
    
        public void ClearText()
        {
            
            txtRightName.Text = "";
       }
      
        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            string varRightID, varRightName;
             varRightID = txtRightID.Text.Trim();
             varRightName = txtRightName.Text.Trim();
            if (M_int_judge == 0)
            {
                if (txtRightName.Text == "")
                {
                    MessageBox.Show("权限名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                   
                    boperate.getcom("insert into tb_Right(Year,Month,RightID,RightName) "
                        + "values('" + year + "','" + month + "','" + varRightID + "','" + varRightName + "')");
                    frmRight_Load(sender, e);
                    tsbtnSave.Enabled = false;
                }
            }
            if (M_int_judge == 1)
            {
                if (txtRightName.Text == "")
                {
                    MessageBox.Show("权限名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    boperate.getcom("update tb_Right set RightName='" +varRightName + "'where RightID='" + varRightID + "'");
                    frmRight_Load(sender, e);
                    tsbtnSave.Enabled = false;
                }
            }
        }

        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要删除该权限吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    for (i = 0; i < dt.Rows.Count;i ++ )
                    {
                        if ((bool)dgvRInfo.Rows[i].Cells[0].EditedFormattedValue == true)
                        {
                            boperate.getcom("delete from tb_Right where RightID='" + Convert.ToString(dgvRInfo[1, dgvRInfo.CurrentCell.RowIndex].Value).Trim() + "'");
                        }

                    }
                }
                frmRight_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void tsbtnLook_Click(object sender, EventArgs e)
        {
            try
            {
                if (tstxtKeyWord.Text == "")
                {
                    frmRight_Load(sender, e);
                }
                if (tscboxCondition.Text.Trim() == "权限编号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where RightID like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvRInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "权限名称")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where RightName like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvRInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txtRightID.Text = Convert.ToString(dgvRInfo[1, dgvRInfo.CurrentCell.RowIndex].Value).Trim();
                txtRightName.Text = Convert.ToString(dgvRInfo[2, dgvRInfo.CurrentCell.RowIndex].Value).Trim();
              
            }
        }

      

       
    }
}
