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
    public partial class frmStorageInfo : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected string M_str_sql = "select StorageID as 仓库编号,StorageType as 仓库类型,SMaker as 制单人,SDate as 日期,"
            + "STime as 时间 from tb_StorageInfo";
        protected string M_str_table = "tb_StorageInfo";
        protected int M_int_judge,i;
        protected int select;
       
       
        public frmStorageInfo()
        {
            InitializeComponent();
        }
        private void dgvStorageInfo_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgvStorageInfo.ReadOnly == true) //判断如果是在进货单中生成的窗体则不响应DataGrid的双击事件
            {
                int intCurrentRowNumber = this.dgvStorageInfo.CurrentCell.RowIndex;
                string  sendSType;
             
                sendSType = this.dgvStorageInfo.Rows[intCurrentRowNumber].Cells[1].Value.ToString().Trim();
        
                string[] sendArray = new string[] { sendSType };
                if (select == 0)
                {
                    C23.StockManage.frmStockTable.inputTextDataStorage[0] = sendArray[0];
                }
              
                if (select == 1)
                {
                    C23.StockManage.frmReturn.inputTextDataStorage[0] = sendArray[0];
                }
                if (select == 2)
                {
                    C23.SellManage .frmSellReT .getStorageTypeInfo[0] = sendArray[0];
                }
                if (select == 3)
                {
                    C23.SellManage .frmSellRe .getStorageTypeInfo[0] = sendArray[0];
                }
                if (select == 4)
                {
                    C23.StorageManage.frmGodE.inputTextDataStorage[0] = sendArray[0];
                }
                if (select == 5)
                {
                    C23.StockManage.frmStockTableT.inputTextDataStorage[0] = sendArray[0];
                }
                if (select == 6)
                {
                    C23.StockManage.frmReturnT .inputTextDataStorage[0] = sendArray[0];
                }
                if (select == 7)
                {
                    C23.StorageManage.frmGodET.inputTextDataStorage[0] = sendArray[0];
                }
                this.Close();
            }
        }
        public void dgvStockTable()
        {
            this.dgvStorageInfo.ReadOnly = true;
            select = 0;
        }
    
        public void dgvReturn()
        {
            this.dgvStorageInfo.ReadOnly = true;
            select = 1;
        }
        public void SellReT()
        {
            this.dgvStorageInfo.ReadOnly = true;
            select = 2;
        }
        public void SellRe()
        {
            this.dgvStorageInfo.ReadOnly = true;
            select = 3;
        }
        public void GodE()
        {
            this.dgvStorageInfo.ReadOnly = true;
            select = 4;
        }
        public void dgvStockTableT()
        {
            this.dgvStorageInfo.ReadOnly = true;
            select = 5;
        }
        public void dgvReturnT()
        {
            this.dgvStorageInfo.ReadOnly = true;
            select = 6;
        }
        public void GodET()
        {
            this.dgvStorageInfo.ReadOnly = true;
            select = 7;
        }
        private void frmStorageInfo_Load(object sender, EventArgs e)
        {
            BindData();
            dgvStateControl();

        }
        private void BindData()
        {
            dt = boperate.getdt(M_str_sql);
            dgvStorageInfo.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                tsbtnDel.Enabled = true;
            }
            else
            {
                tsbtnDel.Enabled = false;
            }

            for (i = 0; i < dgvStorageInfo.Columns.Count - 1; i++)
            {
                dgvStorageInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            }
        }
        #region dgvStateControl
        private void dgvStateControl()
        {
            int numCols = dgvStorageInfo.Columns.Count;
            for (i = 0; i < numCols; i++)
            {
                dgvStorageInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvStorageInfo.Columns[i].ReadOnly = true;   

            }
        }
        #endregion
       private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            opAndvalidate.num("select SYear,SMonth,StorageID from tb_StorageInfo", "select * from tb_StorageInfo where SYear='" + year +
                "' and SMonth='" + month + "'", "tb_StorageInfo", "StorageID", "SR", "0001", txtStorageID);
            tsbtnSave.Enabled = true;
            txtStorageType.Text = "";
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
            SqlDataReader sqlread = boperate.getread("select StorageType from tb_StorageInfo where StorageType='" + txtStorageType.Text.Trim() + "'");
            sqlread.Read();
            if (M_int_judge == 0)
            {
                if (txtStorageType.Text == "")
                {
                    MessageBox.Show("仓库类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }
                else if (sqlread.HasRows)
                {
                    MessageBox.Show("该仓库类型已经存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStorageType.Text = "";
                    txtStorageType.Focus();
                }
                else
                {
                    boperate.getcom("insert into tb_StorageInfo(StorageID,SYear,SMonth,StorageType,SMaker,SDate,STime) values('"
                        + txtStorageID.Text.Trim() + "','"+year +"','"+month +"','" + txtStorageType.Text.Trim() +
                        "','" + frmLogin.M_str_name + "','" +varDate+ "','" + DateTime.Now.ToLongTimeString() + "')");
                    frmStorageInfo_Load(sender, e);
                    MessageBox.Show("仓库信息添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tsbtnSave.Enabled = false;
                }
            }
            sqlread.Close();
            if (M_int_judge == 1)
            {
                if (txtStorageType.Text == "")
                {
                    MessageBox.Show("仓库类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    boperate.getcom("update tb_StorageInfo set StorageID='" + txtStorageID.Text.Trim()
                        + "',StorageType='" + txtStorageType.Text.Trim() + 
                         "' where StorageID='" + txtStorageID.Text.Trim() + "'");
                    frmStorageInfo_Load(sender, e);
                    MessageBox.Show("仓库信息修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tsbtnSave.Enabled = false;
                }
            }
        }

        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要删除该条仓库信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    boperate.getcom("delete from tb_StorageInfo where StorageID='" + Convert.ToString(dgvStorageInfo[0, dgvStorageInfo.CurrentCell.RowIndex].Value).Trim() + "'");
                    frmStorageInfo_Load(sender, e);
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
                    frmStorageInfo_Load(sender, e);
                }
                if (tscboxCondition.Text.Trim() == "仓库编号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where StorageID like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvStorageInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "仓库类型")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where StorageType like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvStorageInfo.DataSource = myds.Tables[0];
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
        private void dgvStorageInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtStorageID.Text = Convert.ToString(dgvStorageInfo[0, dgvStorageInfo.CurrentCell.RowIndex].Value).Trim();
            txtStorageType.Text = Convert.ToString(dgvStorageInfo[1, dgvStorageInfo.CurrentCell.RowIndex].Value).Trim();
           
        }
        public void ClearText()
        {
            txtStorageType.Text = "";



        }


    }
}
