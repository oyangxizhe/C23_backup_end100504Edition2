using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace C23.StorageManage
{
    public partial class frmLocationInfo : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected string M_str_sql = "select LocationID as 库位编号,LName as 仓位名称,LMaker as 制单人,LDate as 日期,"
            + "LTime as 时间 from tb_LocationInfo";
        protected string M_str_table = "tb_LocationInfo";
        protected int M_int_judge,i;
        protected int select;
        public frmLocationInfo()
        {
            InitializeComponent();

        }
        private void dgvLocationInfo_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgvLocationInfo.ReadOnly == true) //判断如果是在进货单中生成的窗体则不响应DataGrid的双击事件
            {
                int intCurrentRowNumber = this.dgvLocationInfo.CurrentCell.RowIndex;
                string sendLName ;

                sendLName = this.dgvLocationInfo.Rows[intCurrentRowNumber].Cells[1].Value.ToString().Trim();

                string[] sendArray = new string[] { sendLName };
                if (select == 0)
                {
                    C23.StockManage.frmStockTable.inputTextDataLocation[0] = sendArray[0];
                }
               
                if (select == 2)
                {
                    C23.StockManage.frmReturn.inputTextDataLocation[0] = sendArray[0];
                }
                if (select == 3)
                {
                    C23.SellManage .frmSellReT.getLocationNameInfo[0] = sendArray[0];
                }
                if (select == 4)
                {
                    C23.SellManage.frmSellRe.getLocationNameInfo[0] = sendArray[0];
                }
                if (select == 5)
                {
                    C23.StorageManage.frmGodE.inputTextDataLocation[0] = sendArray[0];
                }
                if (select == 6)
                {
                    C23.StockManage.frmStockTableT.inputTextDataLocation[0] = sendArray[0];
                }
                if (select == 7)
                {
                    C23.StockManage.frmReturnT .inputTextDataLocation[0] = sendArray[0];
                }
                if (select == 8)
                {
                    C23.StorageManage.frmGodET.inputTextDataLocation[0] = sendArray[0];
                }
                this.Close();
            }
        }
        public void dgvStockTable()
        {
            this.dgvLocationInfo.ReadOnly = true;
            select = 0;
        }

        public void dgvReturn()
        {
            this.dgvLocationInfo.ReadOnly = true;
            select = 2;

        }
        public void SellReT()
        {
            this.dgvLocationInfo.ReadOnly = true;
            select = 3;

        }
        public void SellRe()
        {
            this.dgvLocationInfo.ReadOnly = true;
            select = 4;

        }
        public void GodE()
        {
            this.dgvLocationInfo.ReadOnly = true;
            select = 5;

        }
        public void dgvStockTableT()
        {
            this.dgvLocationInfo.ReadOnly = true;
            select = 6;
        }
        public void dgvReturnT()
        {
            this.dgvLocationInfo.ReadOnly = true;
            select = 7;
        }
        public void GodET()
        {
            this.dgvLocationInfo.ReadOnly = true;
            select = 8;
        }
      
         private void frmLocationInfo_Load(object sender, EventArgs e)
        {

            BindData();
            dgvStateControl();
        }
         private void BindData()
         {
             dt = boperate.getdt(M_str_sql);
             dgvLocationInfo.DataSource = dt;
             if (dt.Rows.Count > 0)
             {
                 tsbtnDel.Enabled = true;
             }
             else
             {
                 tsbtnDel.Enabled = false;
             }

             for (i = 0; i < dgvLocationInfo.Columns.Count - 1; i++)
             {
                 dgvLocationInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

             }
         }
         #region dgvStateControl
         private void dgvStateControl()
         {
             int numCols = dgvLocationInfo.Columns.Count;
             for (i = 0; i < numCols; i++)
             {
                 dgvLocationInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                 dgvLocationInfo.Columns[i].ReadOnly = true;   
             }
         }
        #endregion

         private void tsbtnAdd_Click(object sender, EventArgs e)
        {
           string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM"); 
            opAndvalidate.num("select LYear,LMonth,LocationID from tb_LocationInfo", "select * from tb_LocationInfo where LYear='" + year +
                "' and LMonth='" + month + "'", "tb_LocationInfo", "LocationID", "LC", "0001", txtLocationID);
            tsbtnSave.Enabled = true;
            txtLName.Text = "";
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
            SqlDataReader sqlread = boperate.getread("select LName from tb_LocationInfo where LName='" + txtLName.Text.Trim() + "'");
            sqlread.Read();
            if (M_int_judge == 0)
            {
                if (txtLName.Text == "")
                {
                    MessageBox.Show("库位名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }
                else if (sqlread.HasRows)
                {
                    MessageBox.Show("该库位名称已经存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLName.Text = "";
                    txtLName.Focus();
                }
                else
                {
                    boperate.getcom("insert into tb_LocationInfo(LocationID,LName,LYear,LMonth,LMaker,LDate,LTime) values('"
                        + txtLocationID.Text.Trim() + "','" + txtLName.Text.Trim() +
                        "','"+year +"','"+month +"','" + frmLogin.M_str_name + "','" + varDate  +
                        "','" + DateTime.Now.ToLongTimeString() + "')");
                    frmLocationInfo_Load(sender, e);
                    MessageBox.Show("库位信息添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tsbtnSave.Enabled = false;
                }
            }
            sqlread.Close();
            if (M_int_judge == 1)
            {
                if (txtLName.Text == "")
                {
                    MessageBox.Show("库位名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    boperate.getcom("update tb_LocationInfo set LocationID='" + txtLocationID.Text.Trim()
                        + "',LName='" + txtLName.Text.Trim() +
                         "' where LocationID='" + txtLocationID.Text.Trim() + "'");
                    frmLocationInfo_Load(sender, e);
                    MessageBox.Show("库位信息修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tsbtnSave.Enabled = false;
                }
            }
        }

        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要删除该条库位信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    boperate.getcom("delete from tb_LocationInfo where LocationID='" + Convert.ToString(dgvLocationInfo[0, dgvLocationInfo.CurrentCell.RowIndex].Value).Trim() + "'");
                    frmLocationInfo_Load(sender, e);
                    MessageBox.Show("删除数据成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    frmLocationInfo_Load(sender, e);
                }
                if (tscboxCondition.Text.Trim() == "库位编号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where LocationID like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvLocationInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "库位名称")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where LName like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvLocationInfo.DataSource = myds.Tables[0];
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
        private void dgvLocationInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtLocationID.Text = Convert.ToString(dgvLocationInfo[0, dgvLocationInfo.CurrentCell.RowIndex].Value).Trim();
            txtLName.Text = Convert.ToString(dgvLocationInfo[1, dgvLocationInfo.CurrentCell.RowIndex].Value).Trim();

        }
        public void ClearText()
        {
           
            txtLName.Text = "";



        }

   
    
    
    }
}
