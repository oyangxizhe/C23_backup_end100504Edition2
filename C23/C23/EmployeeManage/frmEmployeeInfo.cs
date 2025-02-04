using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace C23.EmployeeManage
{
    public partial class frmEmployeeInfo : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected string M_str_sql = "select EmployeeID as 员工编号,EName as 员工姓名,EDep as 所属部门,EPosition as 职务,"
            +"EGrade as 所属级别,EMaker as 制单人,EDate as 日期,ETime as 时间 from tb_EmployeeInfo";
        protected string M_str_table = "tb_EmployeeInfo";
        protected int M_int_judge,i;
        protected int select;
        public frmEmployeeInfo()
        {
            InitializeComponent();
        }
        private void dgvEmployeeInfo_DoubleClick(object sender, EventArgs e)
        {
            if (dgvEmployeeInfo.Enabled == true)
            {
                int indexNumber = dgvEmployeeInfo.CurrentCell.RowIndex;
                string sendEName = dgvEmployeeInfo.Rows[indexNumber].Cells[1].Value.ToString().Trim();
                string sendDepart = dgvEmployeeInfo.Rows[indexNumber].Cells[2].Value.ToString().Trim();
                string[] inputarry = new string[] {sendEName,sendDepart };
                if (select == 0)
                { 
                    C23.SellManage.frmOrders.inputgetOEName[0] = inputarry[0]; 
                }
                if (select == 1)
                {
                    C23.StockManage.frmStockTable.inputgetSEName[0] = inputarry[0];
                }
                if (select ==2)
                {
                    C23.SellManage.frmSellTable.getEmployeeInfo[0] = inputarry[0];
                }
                if (select == 3)
                {
                    C23.PUR.frmPurOrders.getEmployeeInfo[0] = inputarry[0];
                }
                if (select == 4)
                {
                    C23.StorageManage.frmGodE.inputgetSEName[0] = inputarry[0];
                }
                if (select == 5)
                {
                    C23.SellManage.frmOrdersT.inputgetOEName[0] = inputarry[0];
                }
                if (select == 6)
                {
                    C23.StockManage.frmStockTableT.inputgetSEName[0] = inputarry[0];
                }
                if (select == 7)
                {
                    C23.PUR.frmPurOrdersT.getEmployeeInfo[0] = inputarry[0];
                }
                if (select == 8)
                {
                    C23.SellManage.frmSellTableT.getEmployeeInfo[0] = inputarry[0];
                }
                if (select == 9)
                {
                    C23.StockManage.frmReturnT .inputgetSEName[0] = inputarry[0];
                }
                if (select == 10)
                {
                    C23.StockManage.frmReturn.inputgetSEName[0] = inputarry[0];
                }
                if (select == 11)
                {
                    C23.SellManage.frmSellReT.getEmployeeInfo[0] = inputarry[0];
                }
                if (select == 12)
                {
                    C23.SellManage.frmSellRe.getEmployeeInfo[0] = inputarry[0];
                }
                if (select == 13)
                {
                    C23.StorageManage.frmMateReT.inputgetSEName[0] = inputarry[0];
                }
                if (select == 14)
                {
                    C23.StorageManage.frmMateRe.inputgetSEName[0] = inputarry[0];
                }
                if (select == 15)
                {
                    C23.StorageManage.frmGodET.inputgetSEName[0] = inputarry[0];
                }
                if (select == 16)
                {
                    C23.UserManage.frmUserManage.inputgetOEName[0] = inputarry[0];
                    C23.UserManage.frmUserManage.inputgetOEName[1] = inputarry[1];
                }
                this.Close();
            }
        }
        public void dgvReadOnlyOrders()
        {
            dgvEmployeeInfo.Enabled = true;
            select = 0;

        }
        public void dgvReadOnlyStock()
        {
            dgvEmployeeInfo.Enabled = true;
            select = 1;
        }
        public void SellTable()
        {
            dgvEmployeeInfo.Enabled = true;
            select = 2;
        }
        public void dgvReadOnlyPur()
        {
            dgvEmployeeInfo.Enabled = true;
            select = 3;
        }
        public void GodE()
        {
            dgvEmployeeInfo.Enabled = true;
            select = 4;
        }
        public void dgvReadOnlyOrdersT()
        {
            dgvEmployeeInfo.Enabled = true;
            select = 5;

        }
        public void dgvReadOnlyStockT()
        {
            dgvEmployeeInfo.Enabled = true;
            select = 6;
        }
        public void dgvReadOnlyPurT()
        {
            dgvEmployeeInfo.Enabled = true;
            select = 7;
        }
        public void SellTableT()
        {
            dgvEmployeeInfo.Enabled = true;
            select = 8;
        }
        public void ReturnT()
        {
            dgvEmployeeInfo.Enabled = true;
            select = 9;
        }
        public void Return()
        {
            dgvEmployeeInfo.Enabled = true;
            select = 10;
        }
        public void SellReT()
        {
            dgvEmployeeInfo.Enabled = true;
            select = 11;
        }
        public void SellRe()
        {
            dgvEmployeeInfo.Enabled = true;
            select = 12;
        }
        public void MateReT()
        {
            dgvEmployeeInfo.Enabled = true;
            select = 13;
        }
        public void MateRe()
        {
            dgvEmployeeInfo.Enabled = true;
            select = 14;
        }
        public void GodET()
        {
            dgvEmployeeInfo.Enabled = true;
            select = 15;
        }
        public void UserManage()
        {
            dgvEmployeeInfo.Enabled = true;
            select = 16;
        }
        private void frmEmployeeInfo_Load(object sender, EventArgs e)
        {
            BindData();
            dgvStateControl();
         
        }
        private void BindData()
        {
            dt = boperate.getdt(M_str_sql);
            dgvEmployeeInfo.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                tsbtnDel.Enabled = true;
            }
            else
            {
                tsbtnDel.Enabled = false;
            }

            for (i = 0; i < dgvEmployeeInfo.Columns.Count - 1; i++)
            {
                dgvEmployeeInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            }
        }
        #region dgvStateControl
        private void dgvStateControl()
        {
            int numCols = dgvEmployeeInfo.Columns.Count;
            for (i = 0; i < numCols; i++)
            {
                dgvEmployeeInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvEmployeeInfo.Columns[i].ReadOnly = true;   

            }
        }
        #endregion
        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            opAndvalidate.num("select EYear,EMonth,EmployeeID from tb_EmployeeInfo", "select * from tb_EmployeeInfo where EYear='" + year +
                "' and EMonth='" + month + "'", "tb_EmployeeInfo", "EmployeeID", "EM", "0001", txtEmployeeID); 
            tsbtnSave.Enabled = true;
            txtEName.Text = "";
            M_int_judge = 0;
            ClearText();
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
            DateTime varDate1 = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            string varDate = varDate1.ToShortDateString();
            SqlDataReader sqlread = boperate.getread("select EName from tb_EmployeeInfo where EName='" + txtEName.Text.Trim() + "'");
            sqlread.Read();
            if (M_int_judge == 0)
            {
                if (txtEName.Text == "")
                {
                    MessageBox.Show("员工名不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }
                else if (sqlread.HasRows)
                {
                    MessageBox.Show("该员工姓名已经存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEName.Text = "";
                    txtEName.Focus();
                }
                else
                {
                    boperate.getcom("insert into tb_EmployeeInfo(EmployeeID,EName,EYear,EMonth,EDep,EPosition,EGrade,EMaker,EDate,ETime) values('"
                        + txtEmployeeID.Text.Trim() + "','" + txtEName.Text.Trim() + "','"+year +"','"+month +"','" + cboxEDep.Text.Trim() +
                        "','" + cboxEPosition.Text.Trim() + "','"+cboxEGrade.Text.Trim()+"','" + frmLogin.M_str_name + "','" +varDate  +
                        "','" + DateTime.Now.ToLongTimeString() + "')");
                    frmEmployeeInfo_Load(sender, e);
                    tsbtnSave.Enabled = false;
                }
            }
            sqlread.Close();
            if (M_int_judge == 1)
            {
                if (txtEName.Text == "")
                {
                    MessageBox.Show("员工姓名不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    boperate.getcom("update tb_EmployeeInfo set EName='" + txtEName.Text.Trim()
                        + "',EDep='" + cboxEDep.Text.Trim() + "',EPosition='" + cboxEPosition.Text.Trim()
                        + "', EGrade='"+cboxEGrade.Text.Trim()+"' where EmployeeID='" + txtEmployeeID.Text.Trim() + "'");
                    frmEmployeeInfo_Load(sender, e);
                    tsbtnSave.Enabled = false;
                }
            }  
        }

        private void tsbtnDel_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("确定要删除该条员工信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    boperate.getcom("delete from tb_EmployeeInfo where EmployeeID='" + Convert.ToString(dgvEmployeeInfo[0, dgvEmployeeInfo.CurrentCell.RowIndex].Value).Trim() + "'");
                    frmEmployeeInfo_Load(sender, e);     
                }
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
                    frmEmployeeInfo_Load(sender, e);
                }
                if (tscboxCondition.Text.Trim() == "员工编号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where EmployeeID like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvEmployeeInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "员工姓名")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where EName like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvEmployeeInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "所属部门")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where EDep like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvEmployeeInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "职务")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where EP like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvEmployeeInfo.DataSource = myds.Tables[0];
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
        public void ClearText()
        {
            txtEName.Text = "";
            cboxEDep.Text = "";
            cboxEPosition.Text = "";
            cboxEGrade.Text = "";
}

        private void dgvEmployeeInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtEmployeeID.Text = Convert.ToString(dgvEmployeeInfo[0, dgvEmployeeInfo.CurrentCell.RowIndex].Value).Trim();
            txtEName.Text = Convert.ToString(dgvEmployeeInfo[1, dgvEmployeeInfo.CurrentCell.RowIndex].Value).Trim();
            cboxEDep.Text = Convert.ToString(dgvEmployeeInfo[2, dgvEmployeeInfo.CurrentCell.RowIndex].Value).Trim();
            cboxEPosition.Text = Convert.ToString(dgvEmployeeInfo[3, dgvEmployeeInfo.CurrentCell.RowIndex].Value).Trim();
            cboxEGrade.Text = Convert.ToString(dgvEmployeeInfo[3, dgvEmployeeInfo.CurrentCell.RowIndex].Value).Trim();
         
            
            }

     

     
    
    }
}
