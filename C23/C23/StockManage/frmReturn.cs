using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace C23.StockManage
{
    public partial class frmReturn : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected string M_str_sql = "select SN as 序号,ReturnID as 退货单号,WareID as 品号,WareName as 品名,Spec as 规格,Unit as 单位,"
            +"PurOrdersID as 采购单号,PurOrdersSN as 采购单序号,StockID as 进货单号,SCheckCount as 进货验收数量,ReCount as 退货数量,PUnitPrice as 采购单价,TaxRate as 税率,TotalCount as 金额,"
            + "NoTax as 不含税额,Tax as 税额,TNTotalCount as 合计金额,TNTax as 合计税额,TNNoTax as 合计不含税金额,StorageType as 仓库类型,"
            +"LocationName as 库位名称,StokerID as 供运商编号,StokerName as 供运商名称, ReDate as 退货日期,Pur as 采购员,Maker as 制单人,Date as 制单日期,"
            +"Time as 制单时间 from tb_Return";
        protected string M_str_table = "tb_Return";
        protected int i;
        public static string[] inputTextDataStoker = new string[] { "", "" };
        public static string[] inputTextDataWare = new string[] { "", "", "", "" };
        public static string[] inputTextDataStorage = new string[] { "" };
        public static string[] inputTextDataLocation = new string[] { "" };
        public static string[] inputgetSEName = new string[] { "" };
        public static string[] getStockInfo = new string[] { "", "", "", "", "", "", "", "", "", "", "",""};

        public frmReturn()
        {
             InitializeComponent();
             this.cboxPur.Items.Add("");
       }
        private void dgvReturnInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvReturnInfo.CurrentCell.ColumnIndex == 19)
            {
                C23.StorageManage.frmStorageInfo frm = new C23.StorageManage.frmStorageInfo();
                frm.dgvReturn();
                frm.ShowDialog();
                setStorageData();
            }
            if (dgvReturnInfo.CurrentCell.ColumnIndex == 20)
            {
                C23.StorageManage.frmLocationInfo frm = new C23.StorageManage.frmLocationInfo();
                frm.dgvReturn();
                frm.ShowDialog();
                setLocationData();
            }
            
            txtReturnID.Text = Convert.ToString(dgvReturnInfo[1, dgvReturnInfo.CurrentCell.RowIndex].Value).Trim();
            dtpReDate.Text = Convert.ToString(dgvReturnInfo[23, dgvReturnInfo.CurrentCell.RowIndex].Value).Trim();
            cboxStokerID.Text = Convert.ToString(dgvReturnInfo[21, dgvReturnInfo.CurrentCell.RowIndex].Value).Trim();
            txtStokerName.Text = Convert.ToString(dgvReturnInfo[22, dgvReturnInfo.CurrentCell.RowIndex].Value).Trim();
            cboxPur.Text = Convert.ToString(dgvReturnInfo[24, dgvReturnInfo.CurrentCell.RowIndex].Value).Trim();
            txtTotalCount.Text = Convert.ToString(dgvReturnInfo[16, dgvReturnInfo.CurrentCell.RowIndex].Value).Trim();
            txtTax.Text = Convert.ToString(dgvReturnInfo[17, dgvReturnInfo.CurrentCell.RowIndex].Value).Trim();
            txtNoTax.Text = Convert.ToString(dgvReturnInfo[18, dgvReturnInfo.CurrentCell.RowIndex].Value).Trim();
        }
        private void setStorageData()
        {
            dgvReturnInfo.Rows[dgvReturnInfo.CurrentCell.RowIndex].Cells[19].Value = inputTextDataStorage[0];

        }
        private void setLocationData()
        {
            dgvReturnInfo.Rows[dgvReturnInfo.CurrentCell.RowIndex].Cells[20].Value = inputTextDataLocation[0];
        }

      
      private void cboxReStokerID_DropDown(object sender, EventArgs e)
        {
            C23.PUR.frmStokerInfo frm = new C23.PUR.frmStokerInfo();
            frm.dgvReadOnlyRe();
            frm.ShowDialog();
            ComplexStokerInfo();
        }
        private void ComplexStokerInfo()
        {
            this.cboxStokerID.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxStokerID.DroppedDown = false;//使组合框不显示其下拉部分
            cboxStokerID.Items[0] = inputTextDataStoker[0];
            txtStokerName.Text = inputTextDataStoker[1];
            this.cboxStokerID.SelectedIndex = 0;
            this.cboxStokerID.IntegralHeight = true;//恢复默认值
        }
    private void frmReturn_Load(object sender, EventArgs e)
        {
            BindData();
            dgvStateControl();
        }
        #region BindData
        private void BindData()
        {
            dt = boperate.getdt(M_str_sql);

            dgvReturnInfo.DataSource = dt;

            for (i = 0; i < dgvReturnInfo.Columns.Count - 1; i++)
            {
                dgvReturnInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;



                if (i==2 || i == 10 || i == 11)
                {
                    dgvReturnInfo.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                }
            }


        }
        #endregion
        #region dgvStateControl
        private void dgvStateControl()
        {

            int numCols = dgvReturnInfo.Columns.Count;

            for (i = 0; i < numCols; i++)
            {

                dgvReturnInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (i == 0)
                {
                    dgvReturnInfo.Columns[i].Width = 60;

                }

                if (i != 2 && i != 8 && i != 10 && i != 11 && i != 19 && i != 20)
                {
                    dgvReturnInfo.Columns[i].ReadOnly = true;

                }


                if (i == 2 || i == 3 || i == 21 || i == 22)
                {
                    dgvReturnInfo.Columns[i].Width = 200;
                }

            }
        }
        #endregion

        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            frmReturnT frm = new frmReturnT() ;
            frm.ShowDialog();
            frmReturn_Load(sender, e);
         
          
        }

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            #region
            bn.Validate();
            string year, month;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            for (i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == "")
                {

                }
                else
                {
                    if (cboxStokerID.Text == "")
                    {
                        MessageBox.Show("供运商编号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (dt.Rows[i][2].ToString() == "")
                        {
                            MessageBox.Show("品号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (dt.Rows[i][10].ToString() == "")
                            {
                                MessageBox.Show("退货数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (dt.Rows[i][11].ToString() == "")
                                {
                                    MessageBox.Show("采购单价不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                else
                                {
                                    if (dt.Rows[i][19].ToString() == "")
                                    {
                                        MessageBox.Show("仓库类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        if (dt.Rows[i][20].ToString() == "")
                                        {
                                            MessageBox.Show("库位名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            string varSN = dt.Rows[i][0].ToString();
                                            string varID = txtReturnID.Text.Trim();
                                            string varWareID = dt.Rows[i][2].ToString();
                                            string varWareName = dt.Rows[i][3].ToString();
                                            string varSpec = dt.Rows[i][4].ToString();
                                            string varUnit = dt.Rows[i][5].ToString();
                                            string varPurOrdersID = dt.Rows[i][6].ToString();
                                            string varPurOrdersSN = dt.Rows[i][7].ToString();
                                            string varStockID = dt.Rows[i][8].ToString();
                                            string varSCheckCount = dt.Rows[i][9].ToString();
                                            decimal varReCount = Decimal.Parse(dt.Rows[i][10].ToString());
                                            decimal varPUnitPrice = Decimal.Parse(dt.Rows[i][11].ToString());
                                            decimal varTaxRate = 17;
                                            string varStorageType = dt.Rows[i][19].ToString();
                                            string varLocationName = dt.Rows[i][20].ToString();
                                            decimal varTTC = varReCount * varPUnitPrice;
                                            decimal varT = varTTC * varTaxRate / 100;
                                            decimal varNT = varTTC - varT;
                                            decimal var1 = (decimal)this.dt.Compute("SUM (金额)", "");
                                            decimal var2 = (decimal)this.dt.Compute("SUM(税额)", "");
                                            decimal var3 = (decimal)this.dt.Compute("SUM(不含税额)", "");
                                            string varStokerID = cboxStokerID.Text.Trim();
                                            string varStokerName = txtStokerName.Text.Trim();
                                            DateTime varReDate1 = Convert.ToDateTime(dtpReDate.Text.Trim());
                                            string varReDate = varReDate1.ToShortDateString();
                                            string varMaker = frmLogin.M_str_name;
                                            DateTime varDate1 = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                                            string varDate = varDate1.ToShortDateString();
                                            string varTime = DateTime.Now.ToLongTimeString();
                                            #region Return
                                            boperate.getcom("update tb_Return set WareID='" + varWareID + "',WareName='" + varWareName + "',Spec='" + varSpec +
                                                "',Unit='" + varUnit + "',PurOrdersID='"+varPurOrdersID+"',PurOrdersSN='"+varPurOrdersSN+"',StockID='" + varStockID + "',SCheckCount='" + varSCheckCount +
                                                "',ReCount='" + varReCount + "',PUnitPrice='" + varPUnitPrice + "',TaxRate='" + varTaxRate +
                                                "',TotalCount='" + varTTC + "',Tax='" + varT + "',NoTax='" + varNT + "',TNTotalCount='" + var1 + "',TNTax='" + var2 +
                                                "',TNNoTax='" + var3 + "',StokerID='" + varStokerID + "',StokerName='" + varStokerName +
                                                "',StorageType='" + varStorageType + "',LocationName='" + varLocationName + "',ReDate='" + varReDate +
                                                "',Maker='" + varMaker + "',Date='" + varDate + "',Time='" + varTime + "' where ReturnID ='" + varID + "' and  SN='" + varSN + "'");
                                            #endregion
                                          
                                            #region StorageCase
                                            SqlDataReader sqlread = boperate.getread("Select WareID,StorageType,LocationName,StorageCount from tb_StorageCase where WareID='" + varWareID +
                                                "' and StorageType='" + varStorageType + "' and LocationName='" + varLocationName + "'");
                                            SqlDataReader sqlread2 = boperate.getread("select ReCount,RootID,SN from tb_Inventory where RootID='" + varID + "' AND SN='" + varSN + "'");
                                            sqlread.Read();
                                            sqlread2.Read();
                                            if (sqlread.HasRows && sqlread2 .HasRows )
                                            {
                                                decimal vargetReCount = Convert.ToDecimal(sqlread2["ReCount"]);
                                                decimal vargetStorageCount = Convert.ToDecimal(sqlread["StorageCount"]);

                                                decimal varStorageCount, vart;

                                                if (varReCount > vargetReCount)
                                                {
                                                    vart = varReCount - vargetReCount;
                                                    varStorageCount = vargetStorageCount - vart;
                                                }
                                                else
                                                {
                                                    vart = vargetReCount - varReCount;
                                                    varStorageCount = vargetStorageCount + vart;
                                                }

                                                boperate.getcom("update tb_StorageCase  set StorageCount='" + varStorageCount +
                                                    "' where WareID='" + varWareID + "'and StorageType='" + varStorageType + "' and LocationName='" + varLocationName + "'");
                                            }
                                            else
                                            {

                                            }
                                            sqlread.Close();
                                            sqlread2.Close();
                                            #endregion
                                            #region AcPay
                                            SqlDataReader sqlreadupdate = boperate.getread("select TNTotalCount,TNNoTax,TNTax from tb_AcPay where StokerID='" + varStokerID + "'");
                                            SqlDataReader sqlreadupdate2 = boperate.getread("select TotalCount,NoTax,Tax,RootID,SN from tb_PayPart where RootID='"+varID + "'AND SN='"+varSN +"'");
                                            sqlreadupdate.Read();
                                            sqlreadupdate2.Read();
                                            if (sqlreadupdate.HasRows && sqlreadupdate2 .HasRows )
                                            {
                                                decimal vargetTNTotalCount = Convert.ToDecimal(sqlreadupdate["TNTotalCount"]);
                                                decimal vargetTNNoTax = Convert.ToDecimal(sqlreadupdate["TNNoTax"]);
                                                decimal vargetTNTax = Convert.ToDecimal(sqlreadupdate["TNTax"]);
                                                decimal vargetReTNTotalCount = Convert.ToDecimal(sqlreadupdate2["TotalCount"]);
                                                decimal vargetReTNNoTax = Convert.ToDecimal(sqlreadupdate2["NoTax"]);
                                                decimal vargetReTNTax = Convert.ToDecimal(sqlreadupdate2["Tax"]);
                                                decimal varupdateTotalCount, varupdateNoTax, varupdateTax;

                                                if (varTTC  > vargetReTNTotalCount)
                                                {
                                                    varupdateTotalCount = vargetTNTotalCount - (varTTC  - vargetReTNTotalCount);

                                                    varupdateTax = vargetTNTax - (varT - vargetReTNTax);
                                                    varupdateNoTax = varupdateTotalCount - varupdateTax;

                                                    boperate.getcom("update tb_AcPay set TNTotalCount='" + varupdateTotalCount + "',TNNoTax='" + varupdateNoTax +
                                                        "',TNTax='" + varupdateTax + "' where StokerID='" + varStokerID + "' ");

                                                }
                                                else
                                                {
                                                    varupdateTotalCount = vargetTNTotalCount + (vargetReTNTotalCount - varTTC );

                                                    varupdateTax = vargetTNTax + (vargetReTNTax - varT );
                                                    varupdateNoTax = varupdateTotalCount - varupdateTax;

                                                    boperate.getcom("update tb_AcPay set TNTotalCount='" + varupdateTotalCount + "',TNNoTax='" + varupdateNoTax +
                                                        "',TNTax='" + varupdateTax + "' where StokerID='" + varStokerID + "'");
                                                }

                                            }
                                            else
                                            {

                                            }
                                            sqlreadupdate.Close();
                                            sqlreadupdate2.Close();
                                            #endregion
                                            #region PayPart
                                            boperate.getcom("update tb_PayPart set WareID='" + varWareID + "',WareName='" + varWareName +
                                                "',StokerID='" + varStokerID + "',StokerName='" + varStokerName + "',ReCount='" + varReCount +
                                                "',PUnitPrice='" + varPUnitPrice + "',TaxRate='" + varTaxRate +
                                                "',TotalCount='" + varTTC + "',NoTax='" + varNT + "',Tax='" + varT + "',TNTotalCount='" + var1 + "',TNTax='" + var2 +
                                                "',TNNoTax='" + var3 + "',Date='" + varDate + "',Time='" + varTime + "' where RootID='" + varID + "' and SN='" + varSN + "'");


                                            #endregion


                                            #region Re
                                            decimal vargetTNReCount, varupdateTNReCount, vargetTNSCheckCount,vargetLastReCount;
                                            SqlDataReader sqlreadRe = boperate.getread("select PurOrdersID,PurOrdersSN,TNReCount from tb_TNRe where PurOrdersID='" + varPurOrdersID +
                                                "'and PurOrdersSN='" + varPurOrdersSN + "'");
                                            SqlDataReader sqlreadRe2 = boperate.getread("select ReCount,RootID,SN from tb_Inventory where RootID='" + varID + "' AND SN='" + varSN + "'");
                                            sqlreadRe.Read();
                                            sqlreadRe2.Read();
                                            if (sqlreadRe.HasRows && sqlreadRe2.HasRows)
                                            {
                                                vargetLastReCount = Convert.ToDecimal(sqlreadRe2["ReCount"]);
                                                vargetTNReCount = Convert.ToDecimal(sqlreadRe["TNReCount"]);
                                                if (varReCount > vargetLastReCount)
                                                {
                                                    varupdateTNReCount = vargetTNReCount + (varReCount - vargetLastReCount);
                                                }
                                                else
                                                {
                                                    varupdateTNReCount = vargetTNReCount - (vargetLastReCount - varReCount);
                                                }

                                                boperate.getcom("update tb_TNRe set TNReCount='" + varupdateTNReCount +
                                                    "' where PurOrdersID='" + varPurOrdersID + "' and PurOrdersSN='" + varPurOrdersSN + "'");
                                                #region Sc

                                                SqlDataReader sqlreadSc = boperate.getread("select PurOrdersID,PurOrdersSN,TNSCheckCount from tb_TNSC where PurOrdersID='" + varPurOrdersID +
                                                    "'and PurOrdersSN='" + varPurOrdersSN + "'");
                                                sqlreadSc.Read();

                                                if (sqlreadSc.HasRows)
                                                {
                                                    vargetTNSCheckCount = Convert.ToDecimal(sqlreadSc["TNSCheckCount"]);

                                                    #region USCount
                                                    SqlDataReader sqlreadus1 = boperate.getread("select PurOrdersID,SN,PCount from tb_PurOrders where PurOrdersID='" + varPurOrdersID +
                                                        "' and SN='" + varPurOrdersSN + "'");
                                                    sqlreadus1.Read();
                                                    if (sqlreadus1.HasRows)
                                                    {
                                                        decimal vargetPCount = Convert.ToDecimal(sqlreadus1["PCount"]);
                                                        decimal varupdateUSCount = vargetPCount - vargetTNSCheckCount + varupdateTNReCount;
                                                        decimal varupdateTNReaSCheckCount = vargetTNSCheckCount - varupdateTNReCount;
                                                        boperate.getcom("update tb_PurOrders set USCount='" + varupdateUSCount + "' where PurOrdersID='" + varPurOrdersID +
                                                            "' and SN='" + varPurOrdersSN + "' ");
                                                        boperate.getcom("update tb_POrdersSta set TNReCount='" + varupdateTNReCount + "',USCount='" + varupdateUSCount +
                                                         "',TNReaSCheckCount='" + varupdateTNReaSCheckCount + "' where PurOrdersID='" + varPurOrdersID + "'  and PurOrdersSN='" + varPurOrdersSN + "'");
                                                    }
                                                    else
                                                    {


                                                    }
                                                    sqlreadus1.Close();
                                                    #endregion



                                                }
                                                else
                                                {


                                                }
                                                sqlreadSc.Close();
                                                #endregion


                                            }
                                            else
                                            {

                                            }
                                            sqlreadRe.Close();
                                            sqlreadRe2.Close();
                                            #endregion
                                           #region Inventory
                                            boperate.getcom("update tb_Inventory set WareID='" + varWareID + "',WareName='" + varWareName +
                                                 "',Spec='" + varSpec + "',Unit='" + varUnit + "',ReCount='" + varReCount +
                                                 "',StorageType='" + varStorageType + "',LocationName='" + varLocationName +
                                                 "',Maker='" + varMaker + "',Date='" + varDate +
                                            "',Time='" + varTime + "' where RootID='" + varID + "' and SN='" + varSN + "'");
                                            #endregion
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            dt.Clear();
            frmReturn_Load(sender, e);
            tsbtnEdit.Enabled = false;
            tsbtnSave.Enabled = false;
            #endregion
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {

            #region
            bn.Validate();
            string year, month;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            for (i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == "")
                {

                }
                else
                {
                    if (cboxStokerID.Text == "")
                    {
                        MessageBox.Show("供运商编号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (dt.Rows[i][2].ToString() == "")
                        {
                            MessageBox.Show("品号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (dt.Rows[i][10].ToString() == "")
                            {
                                MessageBox.Show("退货数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (dt.Rows[i][11].ToString() == "")
                                {
                                    MessageBox.Show("采购单价不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                else
                                {
                                    if (dt.Rows[i][19].ToString() == "")
                                    {
                                        MessageBox.Show("仓库类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        if (dt.Rows[i][20].ToString() == "")
                                        {
                                            MessageBox.Show("库位名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            string varSN = dt.Rows[i][0].ToString();
                                            string varID = txtReturnID.Text.Trim();
                                            string varWareID = dt.Rows[i][2].ToString();
                                            string varWareName = dt.Rows[i][3].ToString();
                                            string varSpec = dt.Rows[i][4].ToString();
                                            string varUnit = dt.Rows[i][5].ToString();
                                            string varPurOrdersID = dt.Rows[i][6].ToString();
                                            string varPurOrdersSN = dt.Rows[i][7].ToString();
                                            string varStockID = dt.Rows[i][8].ToString();
                                            string varSCheckCount = dt.Rows[i][9].ToString();
                                            decimal varReCount = Decimal.Parse(dt.Rows[i][10].ToString());
                                            decimal varPUnitPrice = Decimal.Parse(dt.Rows[i][11].ToString());
                                            decimal varTaxRate = 17;
                                            string varStorageType = dt.Rows[i][19].ToString();
                                            string varLocationName = dt.Rows[i][20].ToString();
                                            decimal varTTC = varReCount * varPUnitPrice;
                                            decimal varT = varTTC * varTaxRate / 100;
                                            decimal varNT = varTTC - varT;
                                            decimal var1 = (decimal)this.dt.Compute("SUM (金额)", "");
                                            decimal var2 = (decimal)this.dt.Compute("SUM(税额)", "");
                                            decimal var3 = (decimal)this.dt.Compute("SUM(不含税额)", "");
                                            string varStokerID = cboxStokerID.Text.Trim();
                                            string varStokerName = txtStokerName.Text.Trim();
                                            DateTime varReDate1 = Convert.ToDateTime(dtpReDate.Text.Trim());
                                            string varReDate = varReDate1.ToShortDateString();
                                            string varMaker = frmLogin.M_str_name;
                                            DateTime varDate1 = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                                            string varDate = varDate1.ToShortDateString();
                                            string varTime = DateTime.Now.ToLongTimeString();
                                            #region Return
                                            boperate.getcom("update tb_Return set WareID='" + varWareID + "',WareName='" + varWareName + "',Spec='" + varSpec +
                                                "',Unit='" + varUnit + "',PurOrdersID='" + varPurOrdersID + "',PurOrdersSN='" + varPurOrdersSN + "',StockID='" + varStockID + "',SCheckCount='" + varSCheckCount +
                                                "',ReCount='" + varReCount + "',PUnitPrice='" + varPUnitPrice + "',TaxRate='" + varTaxRate +
                                                "',TotalCount='" + varTTC + "',Tax='" + varT + "',NoTax='" + varNT + "',TNTotalCount='" + var1 + "',TNTax='" + var2 +
                                                "',TNNoTax='" + var3 + "',StokerID='" + varStokerID + "',StokerName='" + varStokerName +
                                                "',StorageType='" + varStorageType + "',LocationName='" + varLocationName + "',ReDate='" + varReDate +
                                                "',Maker='" + varMaker + "',Date='" + varDate + "',Time='" + varTime + "' where ReturnID ='" + varID + "' and  SN='" + varSN + "'");
                                            #endregion

                                            #region StorageCase
                                            SqlDataReader sqlread = boperate.getread("Select WareID,StorageType,LocationName,StorageCount from tb_StorageCase where WareID='" + varWareID +
                                                "' and StorageType='" + varStorageType + "' and LocationName='" + varLocationName + "'");
                                            SqlDataReader sqlread2 = boperate.getread("select ReCount,RootID,SN from tb_Inventory where RootID='" + varID + "' AND SN='" + varSN + "'");
                                            sqlread.Read();
                                            sqlread2.Read();
                                            if (sqlread.HasRows && sqlread2.HasRows)
                                            {
                                                decimal vargetReCount = Convert.ToDecimal(sqlread2["ReCount"]);
                                                decimal vargetStorageCount = Convert.ToDecimal(sqlread["StorageCount"]);

                                                decimal varStorageCount, vart;

                                                if (varReCount > vargetReCount)
                                                {
                                                    vart = varReCount - vargetReCount;
                                                    varStorageCount = vargetStorageCount - vart;
                                                }
                                                else
                                                {
                                                    vart = vargetReCount - varReCount;
                                                    varStorageCount = vargetStorageCount + vart;
                                                }

                                                boperate.getcom("update tb_StorageCase  set StorageCount='" + varStorageCount +
                                                    "' where WareID='" + varWareID + "'and StorageType='" + varStorageType + "' and LocationName='" + varLocationName + "'");
                                            }
                                            else
                                            {

                                            }
                                            sqlread.Close();
                                            sqlread2.Close();
                                            #endregion
                                            #region AcPay
                                            SqlDataReader sqlreadupdate = boperate.getread("select TNTotalCount,TNNoTax,TNTax from tb_AcPay where StokerID='" + varStokerID + "'");
                                            SqlDataReader sqlreadupdate2 = boperate.getread("select TotalCount,NoTax,Tax,RootID,SN from tb_PayPart where RootID='" + varID + "'AND SN='" + varSN + "'");
                                            sqlreadupdate.Read();
                                            sqlreadupdate2.Read();
                                            if (sqlreadupdate.HasRows && sqlreadupdate2.HasRows)
                                            {
                                                decimal vargetTNTotalCount = Convert.ToDecimal(sqlreadupdate["TNTotalCount"]);
                                                decimal vargetTNNoTax = Convert.ToDecimal(sqlreadupdate["TNNoTax"]);
                                                decimal vargetTNTax = Convert.ToDecimal(sqlreadupdate["TNTax"]);
                                                decimal vargetReTNTotalCount = Convert.ToDecimal(sqlreadupdate2["TotalCount"]);
                                                decimal vargetReTNNoTax = Convert.ToDecimal(sqlreadupdate2["NoTax"]);
                                                decimal vargetReTNTax = Convert.ToDecimal(sqlreadupdate2["Tax"]);
                                                decimal varupdateTotalCount, varupdateNoTax, varupdateTax;

                                                if (varTTC > vargetReTNTotalCount)
                                                {
                                                    varupdateTotalCount = vargetTNTotalCount - (varTTC - vargetReTNTotalCount);

                                                    varupdateTax = vargetTNTax - (varT - vargetReTNTax);
                                                    varupdateNoTax = varupdateTotalCount - varupdateTax;

                                                    boperate.getcom("update tb_AcPay set TNTotalCount='" + varupdateTotalCount + "',TNNoTax='" + varupdateNoTax +
                                                        "',TNTax='" + varupdateTax + "' where StokerID='" + varStokerID + "' ");

                                                }
                                                else
                                                {
                                                    varupdateTotalCount = vargetTNTotalCount + (vargetReTNTotalCount - varTTC);

                                                    varupdateTax = vargetTNTax + (vargetReTNTax - varT);
                                                    varupdateNoTax = varupdateTotalCount - varupdateTax;

                                                    boperate.getcom("update tb_AcPay set TNTotalCount='" + varupdateTotalCount + "',TNNoTax='" + varupdateNoTax +
                                                        "',TNTax='" + varupdateTax + "' where StokerID='" + varStokerID + "'");
                                                }

                                            }
                                            else
                                            {

                                            }
                                            sqlreadupdate.Close();
                                            sqlreadupdate2.Close();
                                            #endregion
                                            #region PayPart
                                            boperate.getcom("update tb_PayPart set WareID='" + varWareID + "',WareName='" + varWareName +
                                                "',StokerID='" + varStokerID + "',StokerName='" + varStokerName + "',ReCount='" + varReCount +
                                                "',PUnitPrice='" + varPUnitPrice + "',TaxRate='" + varTaxRate +
                                                "',TotalCount='" + varTTC + "',NoTax='" + varNT + "',Tax='" + varT + "',TNTotalCount='" + var1 + "',TNTax='" + var2 +
                                                "',TNNoTax='" + var3 + "',Date='" + varDate + "',Time='" + varTime + "' where RootID='" + varID + "' and SN='" + varSN + "'");


                                            #endregion


                                            #region Re
                                            decimal vargetTNReCount, varupdateTNReCount, vargetTNSCheckCount, vargetLastReCount;
                                            SqlDataReader sqlreadRe = boperate.getread("select PurOrdersID,PurOrdersSN,TNReCount from tb_TNRe where PurOrdersID='" + varPurOrdersID +
                                                "'and PurOrdersSN='" + varPurOrdersSN + "'");
                                            SqlDataReader sqlreadRe2 = boperate.getread("select ReCount,RootID,SN from tb_Inventory where RootID='" + varID + "' AND SN='" + varSN + "'");
                                            sqlreadRe.Read();
                                            sqlreadRe2.Read();
                                            if (sqlreadRe.HasRows && sqlreadRe2.HasRows)
                                            {
                                                vargetLastReCount = Convert.ToDecimal(sqlreadRe2["ReCount"]);
                                                vargetTNReCount = Convert.ToDecimal(sqlreadRe["TNReCount"]);
                                                if (varReCount > vargetLastReCount)
                                                {
                                                    varupdateTNReCount = vargetTNReCount + (varReCount - vargetLastReCount);
                                                }
                                                else
                                                {
                                                    varupdateTNReCount = vargetTNReCount - (vargetLastReCount - varReCount);
                                                }

                                                boperate.getcom("update tb_TNRe set TNReCount='" + varupdateTNReCount +
                                                    "' where PurOrdersID='" + varPurOrdersID + "' and PurOrdersSN='" + varPurOrdersSN + "'");
                                                #region Sc

                                                SqlDataReader sqlreadSc = boperate.getread("select PurOrdersID,PurOrdersSN,TNSCheckCount from tb_TNSC where PurOrdersID='" + varPurOrdersID +
                                                    "'and PurOrdersSN='" + varPurOrdersSN + "'");
                                                sqlreadSc.Read();

                                                if (sqlreadSc.HasRows)
                                                {
                                                    vargetTNSCheckCount = Convert.ToDecimal(sqlreadSc["TNSCheckCount"]);

                                                    #region USCount
                                                    SqlDataReader sqlreadus1 = boperate.getread("select PurOrdersID,SN,PCount from tb_PurOrders where PurOrdersID='" + varPurOrdersID +
                                                        "' and SN='" + varPurOrdersSN + "'");
                                                    sqlreadus1.Read();
                                                    if (sqlreadus1.HasRows)
                                                    {
                                                        decimal vargetPCount = Convert.ToDecimal(sqlreadus1["PCount"]);
                                                        decimal varupdateUSCount = vargetPCount - vargetTNSCheckCount + varupdateTNReCount;
                                                        decimal varupdateTNReaSCheckCount = vargetTNSCheckCount - varupdateTNReCount;
                                                        boperate.getcom("update tb_PurOrders set USCount='" + varupdateUSCount + "' where PurOrdersID='" + varPurOrdersID +
                                                            "' and SN='" + varPurOrdersSN + "' ");
                                                        boperate.getcom("update tb_POrdersSta set TNReCount='" + varupdateTNReCount + "',USCount='" + varupdateUSCount +
                                                         "',TNReaSCheckCount='" + varupdateTNReaSCheckCount + "' where PurOrdersID='" + varPurOrdersID + "'  and PurOrdersSN='" + varPurOrdersSN + "'");
                                                    }
                                                    else
                                                    {


                                                    }
                                                    sqlreadus1.Close();
                                                    #endregion



                                                }
                                                else
                                                {


                                                }
                                                sqlreadSc.Close();
                                                #endregion


                                            }
                                            else
                                            {

                                            }
                                            sqlreadRe.Close();
                                            sqlreadRe2.Close();
                                            #endregion
                                            #region Inventory
                                            boperate.getcom("update tb_Inventory set WareID='" + varWareID + "',WareName='" + varWareName +
                                                 "',Spec='" + varSpec + "',Unit='" + varUnit + "',ReCount='" + varReCount +
                                                 "',StorageType='" + varStorageType + "',LocationName='" + varLocationName +
                                                 "',Maker='" + varMaker + "',Date='" + varDate +
                                            "',Time='" + varTime + "' where RootID='" + varID + "' and SN='" + varSN + "'");
                                            #endregion
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            dt.Clear();
            frmReturn_Load(sender, e);
            tsbtnEdit.Enabled = false;
            tsbtnSave.Enabled = false;
            #endregion
        }

        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要删除该条品号信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (dt.Rows.Count > 0)
                    {
                        boperate.getcom("delete tb_Return where ReturnID='" + dt.Rows[dgvReturnInfo.CurrentCell.RowIndex][1].ToString() +
                        "' AND SN='" + dt.Rows[dgvReturnInfo.CurrentCell.RowIndex][0].ToString() + "'");

                        boperate.getcom("delete tb_Inventory where RootID='" + dt.Rows[dgvReturnInfo.CurrentCell.RowIndex][1].ToString() +
                        "' AND SN='" + dt.Rows[dgvReturnInfo.CurrentCell.RowIndex][0].ToString() + "'");

                        boperate.getcom("delete tb_PayPart where RootID='" + dt.Rows[dgvReturnInfo.CurrentCell.RowIndex][1].ToString() +
                         "' AND SN='" + dt.Rows[dgvReturnInfo.CurrentCell.RowIndex][0].ToString() + "'");

                        boperate.getcom("delete tb_Verify where VerifyID='" + dt.Rows[dgvReturnInfo.CurrentCell.RowIndex][1].ToString() +
                     "' AND SN='" + dt.Rows[dgvReturnInfo.CurrentCell.RowIndex][0].ToString() + "'");

                        tsbtnEdit.Enabled = false;
                        tsbtnSave.Enabled = false;
                        tsbtnRefresh.Enabled = false;
                        tsbtnDel.Enabled = false;
                    }
                    frmReturn_Load(sender, e);
                    MessageBox.Show("数据已删除！如果该单号还有品号请刷新该单号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }


        }

        private void tsbtnLook_Click(object sender, EventArgs e)
        {
            tsbtnEdit.Enabled = true;
            tsbtnSave.Enabled = true;
            tsbtnDel.Enabled = true;
            tsbtnRefresh.Enabled = true;

            try
            {

                if (tstxtKeyWord.Text == "")
                {
                    tsbtnEdit.Enabled = false;
                    tsbtnSave.Enabled = false;
                    tsbtnDel.Enabled = false;
                    tsbtnRefresh.Enabled = false;
                    frmReturn_Load(sender, e);
                }
                if (tscboxCondition.Text.Trim() == "按退货单号")
                {
                    dt = boperate.getdt(M_str_sql + " where ReturnID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvReturnInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按编号")
                {
                    dt = boperate.getdt(M_str_sql + " where SN like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvReturnInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
              
                if (tscboxCondition.Text.Trim() == "按品号")
                {
                    dt = boperate.getdt(M_str_sql + " where WareID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvReturnInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按品名")
                {
                    dt = boperate.getdt(M_str_sql + " where WareName like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvReturnInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按供运商编号")
                {
                    dt = boperate.getdt(M_str_sql + " where StokerID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvReturnInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按供运商名称")
                {
                    dt = boperate.getdt(M_str_sql + " where StokerName like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvReturnInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按单据日期")
                {
                    dt = boperate.getdt(M_str_sql + " where Date='" + tstxtKeyWord.Text.Trim() + "'");
                    if (dt.Rows.Count > 0)
                        dgvReturnInfo.DataSource = dt;
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
            

        }

        private void tsbtnPrint_Click(object sender, EventArgs e)
        {
            C23.ReportManage.frmCRReturn FRM = new C23.ReportManage.frmCRReturn();
            FRM.Show();
        }

      private void dgvReturnInfo_DataSourceChanged(object sender, EventArgs e)
        {
            for (i = 0; i < dgvReturnInfo.Columns.Count; i++)
            {
                if (dgvReturnInfo.Columns[i].ValueType.ToString() == "System.Decimal")
                {
                    dgvReturnInfo.Columns[i].DefaultCellStyle.Format = "N";
                    dgvReturnInfo.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                }

            }
        }

        private void dgvReturnInfo_DoubleClick(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                if (dgvReturnInfo.CurrentCell.ColumnIndex == 1)
                {


                    SqlDataReader sqlread = boperate.getread("select VerifyID from tb_Verify where VerifyID='" + dt.Rows[dgvReturnInfo.CurrentCell.RowIndex][1].ToString() + "'");
                    sqlread.Read();
                    if (sqlread.HasRows)
                    {
                        MessageBox.Show("单据已被锁定");
                    }
                    else
                    {
                        tsbtnEdit.Enabled = true;
                        tsbtnSave.Enabled = true;
                        tsbtnRefresh.Enabled = true;
                        tsbtnDel.Enabled = true;
                        dt = boperate.getdt(M_str_sql + " where ReturnID like '%" + dt.Rows[dgvReturnInfo.CurrentCell.RowIndex][1].ToString() + "%'");
                        dgvReturnInfo.DataSource = dt;
                    }
                    sqlread.Close();
                }
            }
          if (dgvReturnInfo.CurrentCell.ColumnIndex == 2)
                {
                    C23.BomManage.frmWareInfo frm = new C23.BomManage.frmWareInfo();
                    frm.Return();
                    frm.ShowDialog();
                    setWareData();
                }
            
        }
        private void setWareData()
        {
            dgvReturnInfo[2, dgvReturnInfo.CurrentCell.RowIndex].Value = inputTextDataWare[0];
            dgvReturnInfo[3, dgvReturnInfo.CurrentCell.RowIndex].Value = inputTextDataWare[1];
            dgvReturnInfo[4, dgvReturnInfo.CurrentCell.RowIndex].Value = inputTextDataWare[2];
            dgvReturnInfo[5, dgvReturnInfo.CurrentCell.RowIndex].Value = inputTextDataWare[3];
        }
    
        #region Recall
        private void tsbtnRecall_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要撤消单据关联吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (dt.Rows.Count > 0)
                    {
                        boperate.getcom("delete tb_Verify where VerifyID='" + dt.Rows[dgvReturnInfo.CurrentCell.RowIndex][8].ToString() + "'");

                        tsbtnEdit.Enabled = false;
                        tsbtnSave.Enabled = false;
                        tsbtnRefresh.Enabled = false;
                        tsbtnDel.Enabled = false;

                    }
                    frmReturn_Load(sender, e);
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Verify
        private void tsbtnVerify_Click(object sender, EventArgs e)
        {
            try
            {

                if (dt.Rows.Count > 0)
                {
                    boperate.getcom("insert into tb_Verify (VerifyID) values ('" + dt.Rows[dgvReturnInfo.CurrentCell.RowIndex][8].ToString() + "')");

                    tsbtnEdit.Enabled = false;
                    tsbtnSave.Enabled = false;
                    tsbtnRefresh.Enabled = false;
                    tsbtnDel.Enabled = false;
                }
                frmReturn_Load(sender, e);
                MessageBox.Show("单据已关联！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }
        #endregion

       
        private void getEPurData()
        {
            this.cboxPur.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxPur.DroppedDown = false;//使组合框不显示其下拉部分
            this.cboxPur.Items[0] = inputgetSEName[0];
            this.cboxPur.SelectedIndex = 0;
            this.cboxPur.IntegralHeight = true;//恢复默认值
        }

        private void cboxPur_DropDown(object sender, EventArgs e)
        {
            C23.EmployeeManage.frmEmployeeInfo frm = new C23.EmployeeManage.frmEmployeeInfo();
            frm.Return();
            frm.ShowDialog();
            getEPurData();
        }

        private void tsbtnRLock_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要撤消单据锁定吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (dt.Rows.Count > 0)
                    {
                        boperate.getcom("delete tb_Verify where VerifyID='" + dt.Rows[dgvReturnInfo.CurrentCell.RowIndex][1].ToString() + "'");

                        tsbtnEdit.Enabled = false;
                        tsbtnSave.Enabled = false;
                        tsbtnRefresh.Enabled = false;
                        tsbtnDel.Enabled = false;

                    }
                    frmReturn_Load(sender, e);
                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void tsbtnLock_Click(object sender, EventArgs e)
        {
            try
            {

                if (dt.Rows.Count > 0)
                {
                    boperate.getcom("insert into tb_Verify (VerifyID) values ('" + dt.Rows[dgvReturnInfo.CurrentCell.RowIndex][1].ToString() + "')");

                    tsbtnEdit.Enabled = false;
                    tsbtnSave.Enabled = false;
                    tsbtnRefresh.Enabled = false;
                    tsbtnDel.Enabled = false;
                }
                frmReturn_Load(sender, e);
                MessageBox.Show("单据已锁定！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

       


    }
}
