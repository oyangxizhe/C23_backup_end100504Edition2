using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace C23.BomManage
{
    public partial class frmWareInfo : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected string M_str_sql = "select WareID as 品号,WName as 品名,WSpec as 规格,WUnit as 单位,WMaker as 制单人,WDate as 日期,"
            +"WTime as 时间 from tb_WareInfo";
        protected string M_str_table = "tb_WareInfo";
        protected int M_int_judge,i;
        protected int getdata;
        
        public frmWareInfo()
        {
            InitializeComponent();
        }
        #region DoubleClick
        private void dgvWareInfo_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgvWareInfo.ReadOnly == true) //判断如果是在进货单中生成的窗体则不响应DataGrid的双击事件
            {
                int intCurrentRowNumber = this.dgvWareInfo.CurrentCell.RowIndex;
                string sendWareID, sendWareName,sendWSpec,sendWUnit;
                sendWareID = this.dgvWareInfo.Rows[intCurrentRowNumber].Cells[0].Value.ToString().Trim();
                sendWareName = this.dgvWareInfo.Rows[intCurrentRowNumber].Cells[1].Value.ToString().Trim();
                sendWSpec = this.dgvWareInfo.Rows[intCurrentRowNumber].Cells[2].Value.ToString().Trim();
                sendWUnit = this.dgvWareInfo.Rows[intCurrentRowNumber].Cells[3].Value.ToString().Trim();
                string[] sendArray = new string[] { sendWareID, sendWareName,sendWSpec,sendWUnit };
                if (getdata == 0)
                {
                    C23.StockManage.frmStockTable.inputTextDataWare[0] = sendArray[0];
                    C23.StockManage.frmStockTable.inputTextDataWare[1] = sendArray[1];
                    C23.StockManage.frmStockTable.inputTextDataWare[2] = sendArray[2];
                    C23.StockManage.frmStockTable.inputTextDataWare[3] = sendArray[3];
                }
                if (getdata == 1)
                {
                    C23.SellManage.frmOrders.inputdgvWare[0] = sendArray[0];
                    C23.SellManage.frmOrders.inputdgvWare[1] = sendArray[1];
                    C23.SellManage.frmOrders.inputdgvWare[2] = sendArray[2];
                    C23.SellManage.frmOrders.inputdgvWare[3] = sendArray[3];

                }
                if (getdata ==2)
                {
                    C23.SellManage.frmSellTable.inputTextDataWare[0] = sendArray[0];
                    C23.SellManage.frmSellTable.inputTextDataWare[1] = sendArray[1];
                    C23.SellManage.frmSellTable.inputTextDataWare[2] = sendArray[2];
                    C23.SellManage.frmSellTable.inputTextDataWare[3] = sendArray[3];
                }
                if (getdata == 3)
                {
                    C23.PUR.frmPurOrders.inputTextDataWare[0] = sendArray[0];
                    C23.PUR.frmPurOrders.inputTextDataWare[1] = sendArray[1];
                    C23.PUR.frmPurOrders.inputTextDataWare[2] = sendArray[2];
                    C23.PUR.frmPurOrders.inputTextDataWare[3] = sendArray[3];
                }
                if (getdata == 4)
                {
                    C23.StockManage.frmReturn.inputTextDataWare[0] = sendArray[0];
                    C23.StockManage.frmReturn.inputTextDataWare[1] = sendArray[1];
                    C23.StockManage.frmReturn.inputTextDataWare[2] = sendArray[2];
                    C23.StockManage.frmReturn.inputTextDataWare[3] = sendArray[3];
                }
                if (getdata == 5)
                {
                    C23.SellManage .frmSellRe .inputTextDataWare[0] = sendArray[0];
                    C23.SellManage .frmSellRe .inputTextDataWare[1] = sendArray[1];
                    C23.SellManage .frmSellRe .inputTextDataWare[2] = sendArray[2];
                    C23.SellManage .frmSellRe .inputTextDataWare[3] = sendArray[3];
                }
                if (getdata == 6)
                {
                    C23.StorageManage.frmGodE.inputTextDataWare[0] = sendArray[0];
                    C23.StorageManage.frmGodE.inputTextDataWare[1] = sendArray[1];
                    C23.StorageManage.frmGodE.inputTextDataWare[2] = sendArray[2];
                    C23.StorageManage.frmGodE.inputTextDataWare[3] = sendArray[3];
                }
                if (getdata == 7)
                {
                    C23.StorageManage.frmMateRe.inputTextDataWare[0] = sendArray[0];
                    C23.StorageManage.frmMateRe.inputTextDataWare[1] = sendArray[1];
                    C23.StorageManage.frmMateRe.inputTextDataWare[2] = sendArray[2];
                    C23.StorageManage.frmMateRe.inputTextDataWare[3] = sendArray[3];
                }
                if (getdata == 8)
                {
                    C23.SellManage.frmOrdersT.inputdgvWare[0] = sendArray[0];
                    C23.SellManage.frmOrdersT.inputdgvWare[1] = sendArray[1];
                    C23.SellManage.frmOrdersT.inputdgvWare[2] = sendArray[2];
                    C23.SellManage.frmOrdersT.inputdgvWare[3] = sendArray[3];

                }
                if (getdata == 9)
                {
                    C23.StockManage.frmStockTableT.inputTextDataWare[0] = sendArray[0];
                    C23.StockManage.frmStockTableT.inputTextDataWare[1] = sendArray[1];
                    C23.StockManage.frmStockTableT.inputTextDataWare[2] = sendArray[2];
                    C23.StockManage.frmStockTableT.inputTextDataWare[3] = sendArray[3];

                }
                if (getdata == 10)
                {
                    C23.PUR.frmPurOrdersT.inputTextDataWare[0] = sendArray[0];
                    C23.PUR.frmPurOrdersT.inputTextDataWare[1] = sendArray[1];
                    C23.PUR.frmPurOrdersT.inputTextDataWare[2] = sendArray[2];
                    C23.PUR.frmPurOrdersT.inputTextDataWare[3] = sendArray[3];
                }
                if (getdata == 11)
                {
                    C23.StockManage.frmReturnT.inputTextDataWare[0] = sendArray[0];
                    C23.StockManage.frmReturnT.inputTextDataWare[1] = sendArray[1];
                    C23.StockManage.frmReturnT.inputTextDataWare[2] = sendArray[2];
                    C23.StockManage.frmReturnT.inputTextDataWare[3] = sendArray[3];
                }
                if (getdata == 12)
                {
                    C23.SellManage.frmSellTableT.inputTextDataWare[0] = sendArray[0];
                    C23.SellManage.frmSellTableT.inputTextDataWare[1] = sendArray[1];
                    C23.SellManage.frmSellTableT.inputTextDataWare[2] = sendArray[2];
                    C23.SellManage.frmSellTableT.inputTextDataWare[3] = sendArray[3];
                }
                if (getdata == 13)
                {
                    C23.SellManage.frmSellReT.inputTextDataWare[0] = sendArray[0];
                    C23.SellManage.frmSellReT.inputTextDataWare[1] = sendArray[1];
                    C23.SellManage.frmSellReT.inputTextDataWare[2] = sendArray[2];
                    C23.SellManage.frmSellReT.inputTextDataWare[3] = sendArray[3];
                }
                if (getdata == 14)
                {
                    C23.StorageManage.frmMateReT.inputTextDataWare[0] = sendArray[0];
                    C23.StorageManage.frmMateReT.inputTextDataWare[1] = sendArray[1];
                    C23.StorageManage.frmMateReT.inputTextDataWare[2] = sendArray[2];
                    C23.StorageManage.frmMateReT.inputTextDataWare[3] = sendArray[3];
                }
                if (getdata == 15)
                {
                    C23.StorageManage.frmGodET.inputTextDataWare[0] = sendArray[0];
                    C23.StorageManage.frmGodET.inputTextDataWare[1] = sendArray[1];
                    C23.StorageManage.frmGodET.inputTextDataWare[2] = sendArray[2];
                    C23.StorageManage.frmGodET.inputTextDataWare[3] = sendArray[3];
                }
                this.Close();
            }
        }
        #endregion
        #region dgvReadOnly
        public  void StockTable()
        {
            this.dgvWareInfo.ReadOnly = true;
            getdata = 0;
        }
       
        public void dgvReadOnlyOrders()
        {
            this.dgvWareInfo.ReadOnly = true;
            getdata = 1;
        }
        public void SellTable()
        {
            this.dgvWareInfo.ReadOnly = true;
            getdata = 2;
        }
        public void PurOrders()
        {
            this.dgvWareInfo.ReadOnly = true;
            getdata = 3;
        }
        public void Return()
        {
            this.dgvWareInfo.ReadOnly = true;
            getdata = 4;
        }
        public void SellRe()
        {
            this.dgvWareInfo.ReadOnly = true;
            getdata = 5;
        }
        public void GodE()
        {
            this.dgvWareInfo.ReadOnly = true;
            getdata = 6;
        }
        public void MateRe()
        {
            this.dgvWareInfo.ReadOnly = true;
            getdata = 7;
        }
        public void dgvReadOnlyOrdersT()
        {
            this.dgvWareInfo.ReadOnly = true;
            getdata = 8;
        }
        public void dgvStockTableT()
        {
            this.dgvWareInfo.ReadOnly = true;
            getdata = 9;
        }
        public void PurOrdersT()
        {
            this.dgvWareInfo.ReadOnly = true;
            getdata = 10;
        }
        public void dgvReturnT()
        {
            this.dgvWareInfo.ReadOnly = true;
            getdata = 11;
        }
        public void SellTableT()
        {
            this.dgvWareInfo.ReadOnly = true;
            getdata = 12;
        }
        public void SellReT()
        {
            this.dgvWareInfo.ReadOnly = true;
            getdata = 13;
        }
        public void MateReT()
        {
            this.dgvWareInfo.ReadOnly = true;
            getdata = 14;
        }
        public void GodET()
        {
            this.dgvWareInfo.ReadOnly = true;
            getdata = 15;
        }
        #endregion
        private void frmWareInfo_Load(object sender, EventArgs e)
        {
            BindData();
            dgvStateControl();
        }
       
        #region BindData
        private void BindData()
        {
            dt = boperate.getdt(M_str_sql);
            dgvWareInfo.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                tsbtnDel.Enabled = true;
            }
            else
            {
                tsbtnDel.Enabled = false;
            }

            for (i = 0; i < dgvWareInfo.Columns.Count - 1; i++)
            {
                dgvWareInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        #endregion
        #region dgvStateControl
        private void dgvStateControl()
        {
            int numCols = dgvWareInfo.Columns.Count;
            for (i = 0; i < numCols; i++)
            {
                dgvWareInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (i==0 || i == 1)
                {
                    dgvWareInfo.Columns[i].Width = 200;
                }
                dgvWareInfo.Columns[i].ReadOnly = true;
            }
        }
        #endregion
        
        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
           
            tsbtnSave.Enabled = true;
            txtWName.Text = "";
            M_int_judge = 0;
            ClearText();
         
        }
        private void ClearText()
        {
            txtWareID.Text = "";
            txtWName.Text = "";
            txtWSpec.Text = "";
            cboxWUnit.Text = "";
            
        }

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            tsbtnSave.Enabled = true;
            M_int_judge = 1;
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            DateTime varDate1 = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            string varDate = varDate1.ToShortDateString();
            SqlDataReader sqlread = boperate.getread("select WareID from tb_WareInfo where WareID='" + txtWareID.Text.Trim() + "'");
            sqlread.Read();
            if (M_int_judge == 0)
            {
                if (txtWareID.Text == "")
                {
                    MessageBox.Show("品号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }
                else if (sqlread.HasRows)
                {
                    MessageBox.Show("该品号已经存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtWareID.Text = "";
                    txtWareID.Focus();
                }
                else
                {
                    boperate.getcom("insert into tb_WareInfo(WareID,WName,WSpec,WUnit,WMaker,WDate,WTime) values('"
                        + txtWareID.Text.Trim() + "','" + txtWName.Text.Trim() + "','" + txtWSpec.Text.Trim() +
                        "','" + cboxWUnit.Text.Trim() + "','" + frmLogin.M_str_name+"','"+varDate+
                        "','"+DateTime .Now .ToLongTimeString()+"')");
                    frmWareInfo_Load(sender, e);
                    tsbtnSave.Enabled = false;
                }
            }
            sqlread.Close();
            if (M_int_judge == 1)
            {
                if (txtWName.Text == "")
                {
                    MessageBox.Show("品名不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    boperate.getcom("update tb_WareInfo set WName='" + txtWName.Text.Trim()
                        + "',WSpec='" + txtWSpec.Text.Trim() + "',WUnit='"+cboxWUnit.Text .Trim ()
                        +"' where WareID='" + txtWareID.Text.Trim() + "'");
                    frmWareInfo_Load(sender, e);
                    tsbtnSave.Enabled = false;
                }
            }  
        }

        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要删除该条品号信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    boperate.getcom("delete from tb_WareInfo where WareID='" + Convert.ToString(dgvWareInfo[0, dgvWareInfo.CurrentCell.RowIndex].Value).Trim() + "'");
                    frmWareInfo_Load(sender, e);
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
                    frmWareInfo_Load(sender, e);
                }
                if (tscboxCondition.Text.Trim() == "品号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where WareID like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvWareInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "品名")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where WName like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvWareInfo.DataSource = myds.Tables[0];
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
        private void dgvWareInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtWareID.Text = Convert.ToString(dgvWareInfo[0, dgvWareInfo.CurrentCell.RowIndex].Value).Trim();
            txtWName.Text = Convert.ToString(dgvWareInfo[1, dgvWareInfo.CurrentCell.RowIndex].Value).Trim();
            txtWSpec.Text = Convert.ToString(dgvWareInfo[2, dgvWareInfo.CurrentCell.RowIndex].Value).Trim();
            cboxWUnit.Text = Convert.ToString(dgvWareInfo[3, dgvWareInfo.CurrentCell.RowIndex].Value).Trim();
        }
     
    }
}
