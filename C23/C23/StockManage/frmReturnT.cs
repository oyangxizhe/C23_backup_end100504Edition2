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
    public partial class frmReturnT : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected int  i;
 
        public static string[] inputTextDataStoker = new string[] { "", "" };
        public static string[] inputTextDataWare = new string[] { null, null, null, null };
        public static string[] inputTextDataStorage = new string[] { "" };
        public static string[] inputTextDataLocation = new string[] { "" };
        public static string[] inputDataGridArray = new string[] { null, null, null, null };
        public static string[] strpub = new string[] { null, null, null, null };
        public static string[] inputgetSEName = new string[] { "" };
        public static string[] getStockInfo = new string[] { "", "", "", "", "", "", "", "", "", "", "" ,"","","",""};

        public frmReturnT()
        {
            InitializeComponent();
            this.cboxStokerID.Items.Add("");
            this.cboxPur.Items.Add("");
        }

        private void frmReturnT_Load(object sender, EventArgs e)
        {
            BindData();
            dgvStateControl();
        }
        #region BindData
        private void BindData()
        {
            dt = total1();

            dgvReturnInfo.DataSource = dt;

            for (i = 0; i < dgvReturnInfo.Columns.Count - 1; i++)
            {
                dgvReturnInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;



                if (i==1 || i == 9 || i == 10 || i ==18 || i==19)
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

                if (i != 1 && i!=7 && i != 9 && i != 10 && i != 18 && i != 19)
                {
                    dgvReturnInfo.Columns[i].ReadOnly = true;

                }


                if (i == 1 || i == 2 || i == 20 || i == 21)
                {
                    dgvReturnInfo.Columns[i].Width = 200;
                }

            }
        }
        #endregion
     
        #region total1
        private DataTable total1()
        {
            dt = new DataTable();
            dt.Columns.Add("序号", typeof(string));
            dt.Columns.Add("品号", typeof(string));
            dt.Columns.Add("品名", typeof(string));
            dt.Columns.Add("规格", typeof(string));
            dt.Columns.Add("单位", typeof(string));
            dt.Columns.Add("采购单号", typeof(string));
            dt.Columns.Add("采购序号", typeof(string));
            dt.Columns.Add("进货单号", typeof(string));
            dt.Columns.Add("进货验收数量", typeof(string));
            dt.Columns.Add("退货数量", typeof(decimal ));
            dt.Columns.Add("采购单价", typeof(decimal));
            dt.Columns.Add("税率", typeof(decimal));
            dt.Columns.Add("金额", typeof(decimal), "退货数量*采购单价");
            dt.Columns.Add("税额", typeof(decimal), "金额*0.17");
            dt.Columns.Add("不含税额", typeof(decimal), "金额-税额");
            dt.Columns.Add("合计金额", typeof(decimal));
            dt.Columns.Add("合计税额", typeof(decimal));
            dt.Columns.Add("合计不含税金额", typeof(decimal));
            dt.Columns.Add("仓库类型", typeof(string));
            dt.Columns.Add("库位名称", typeof(string));
            dt.Columns.Add("供运商编号", typeof(string));
            dt.Columns.Add("供运商名称", typeof(string));
            dt.Columns.Add("退货日期", typeof(DateTime));
            dt.Columns.Add("制单人", typeof(char));
            dt.Columns.Add("制单日期", typeof(DateTime));
            dt.Columns.Add("制单时间", typeof(string));
            return dt;
        }
        #endregion
      
        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            opAndvalidate.num("select Year,Month,ReturnID from tb_Return", "select * from tb_Return where Year='" + year +
                "' and Month='" + month + "'", "tb_Return", "ReturnID", "RE", "0001", txtReturnID);
            tsbtnSave.Enabled = true;
            ClearText();
        }
        public void ClearText()
        {
            cboxPur.Text = "";
            cboxStokerID.Text = "";
            txtStokerName.Text = "";
        }
        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            #region Return
            string RootName = "退货单";
            bn.Validate();
            string year, month;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            SqlDataReader sqlread = boperate.getread("select VerifyID from tb_Verify where VerifyID='" + dt.Rows[dgvReturnInfo.CurrentCell.RowIndex][7].ToString() + "' ");
            sqlread.Read();
            if (sqlread.HasRows)
            {
                MessageBox.Show("此进货单号在退货单中已经存在,不要重复带入");
            }
            else
            {
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
                            if (dt.Rows[i][1].ToString() == "")
                            {
                                MessageBox.Show("品号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (dt.Rows[i][9].ToString() == "")
                                {
                                    MessageBox.Show("退货数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    if (dt.Rows[i][10].ToString() == "")
                                    {
                                        MessageBox.Show("采购单价不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                    else
                                    {
                                        if (dt.Rows[i][18].ToString() == "")
                                        {
                                            MessageBox.Show("仓库类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            if (dt.Rows[i][19].ToString() == "")
                                            {
                                                MessageBox.Show("库位名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            else
                                            {
                                                string varSN = dt.Rows[i][0].ToString();
                                                string varID = txtReturnID.Text;
                                                string varStokerID = cboxStokerID.Text.Trim();
                                                string varStokerName = txtStokerName.Text.Trim();
                                                DateTime varReDate1 = Convert.ToDateTime(dtpReDate.Text.Trim());
                                                string varReDate = varReDate1.ToShortDateString();
                                                string varWareID = dt.Rows[i][1].ToString();
                                                string varWareName = dt.Rows[i][2].ToString();
                                                string varSpec = dt.Rows[i][3].ToString();
                                                string varUnit = dt.Rows[i][4].ToString();
                                                string varPurOrdersID = dt.Rows[i][5].ToString();
                                                string varPurOrdersSN = dt.Rows[i][6].ToString();
                                                string varStockID = dt.Rows[i][7].ToString();
                                                string varSCheckCount = dt.Rows[i][8].ToString();
                                                decimal varReCount = Decimal.Parse(dt.Rows[i][9].ToString());
                                                decimal varPUnitPrice = Decimal.Parse(dt.Rows[i][10].ToString());
                                                decimal varTaxRate = 17;
                                                decimal varTTC = Decimal.Parse(dt.Rows[i][12].ToString());
                                                decimal varT = Decimal.Parse(dt.Rows[i][13].ToString());
                                                decimal varNT = Decimal.Parse(dt.Rows[i][14].ToString());
                                                decimal var1 = (decimal)this.dt.Compute("SUM (金额)", "");
                                                decimal var2 = (decimal)this.dt.Compute("SUM(税额)", "");
                                                decimal var3 = (decimal)this.dt.Compute("SUM(不含税额)", "");
                                                string varStorageType = dt.Rows[i][18].ToString();
                                                string varLocationName = dt.Rows[i][19].ToString();
                                                string varPur = cboxPur.Text.Trim();
                                                string varMaker = frmLogin.M_str_name;
                                                DateTime varDate1 = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                                                string varDate = varDate1.ToShortDateString();
                                                string varTime = DateTime.Now.ToLongTimeString();

                                                string varsendValues = "('" + varSN + "','" + varID + "','" + year + "','" + month +
                                            "','" + varWareID + "','" + varWareName + "','" + varSpec + "','" + varUnit + "','" + varSCheckCount +
                                            "','" + varReCount + "','" + varPUnitPrice + "','" + varTaxRate + "','" + varTTC + "','" + varT +
                                            "','" + varNT + "','" + var1 + "','" + var2 + "','" + var3 + "','"+varPurOrdersID +"','"+varPurOrdersSN+"','" + varStockID +
                                            "','" + varStorageType + "','" + varLocationName + "','" + varStokerID + "','" + varStokerName +
                                            "','" + varReDate + "','" + varPur + "','" + varMaker + "','" + varDate + "','" + varTime + "')";
                                                boperate.getcom("insert into tb_Return(SN,ReturnID,Year,Month,WareID,WareName,Spec,Unit,SCheckCount,"
                                                + "ReCount,PUnitPrice,TaxRate,TotalCount,Tax,NoTax,TNTotalCount,TNTax,TNNoTax,PurOrdersID,PurOrdersSN,StockID,StorageType,"
                                                + "LocationName,StokerID,StokerName,ReDate,Pur,Maker,Date,Time) values " + varsendValues);
                                                 #endregion
                                                if (varStockID != "")
                                                {
                                                    boperate.getcom("insert into tb_Verify(VerifyID) values ('" + varStockID + "')");
                                                 
                                                }
                                                boperate.getcom("insert into tb_Verify(VerifyID) values ('" + varID  + "')");

                                                #region StorageCase
                                                SqlDataReader sqlread1 = boperate.getread("Select WareID,StorageType,LocationName,StorageCount from tb_StorageCase where WareID='" + varWareID +
                                                     "' and StorageType='" + varStorageType + "' and LocationName='" + varLocationName + "'");
                                              
                                                sqlread1.Read();

                                                if (sqlread1.HasRows )
                                                {
                                                    decimal vargetStorageCount = Convert.ToDecimal(sqlread1["StorageCount"]);
                                                    decimal varStorageCount = vargetStorageCount - varReCount;
                                                    boperate.getcom("update tb_StorageCase set  StorageCount='" + varStorageCount +
                                                           "'where WareID='" + varWareID + "'and StorageType='" + varStorageType + "' and LocationName='" + varLocationName + "'");
                                                }
                                                else
                                                {

                                                }
                                                sqlread1.Close();
                                                #endregion
                                                #region Inventory
                                                boperate.getcom("insert into tb_Inventory(Year,Month,SN,RootID,RootName,WareID,WareName,Spec,Unit,ReCount,StorageType,"
                                                    + "LocationName,Maker,Date,Time) values ('" + year + "','" + month + "','" + varSN + "','" + varID + "','" + RootName +
                                                    "','" + varWareID + "','" + varWareName + "','" + varSpec +
                                                     "','" + varUnit + "','" + varReCount + "','" + varStorageType + "','" + varLocationName +
                                                     "','" + varMaker + "','" + varDate + "','" + varTime + "')");
                                                #endregion
                                                #region AcPay
                                                SqlDataReader sqlreadPay = boperate.getread("select TNTotalCount,TNNoTax,TNTax from tb_AcPay where StokerID='" + varStokerID + "'");
                                                sqlreadPay.Read();
                                                decimal vargetTotalCount, vargetTax, vargetNoTax;

                                                decimal varupdateTotalCount;
                                                decimal varupdateNoTax;
                                                decimal varupdateTax;

                                                if (sqlreadPay.HasRows)
                                                {
                                                    vargetTotalCount = Convert.ToDecimal(sqlreadPay["TNTotalCount"]);
                                                    vargetNoTax = Convert.ToDecimal(sqlreadPay["TNNoTax"]);
                                                    vargetTax = Convert.ToDecimal(sqlreadPay["TNTax"]);
                                                    varupdateTotalCount = vargetTotalCount - varTTC;
                                                    varupdateTax = vargetTax - varT;
                                                    varupdateNoTax = vargetNoTax - varNT;


                                                    boperate.getcom("update tb_AcPay set TNTotalCount='" + varupdateTotalCount + "',TNNoTax='" + varupdateNoTax + "', TNTax='" + varupdateTax +
                                                         "' where StokerID='" + varStokerID + "'");

                                                }
                                                else
                                                {

                                                }
                                                sqlreadPay.Close();
                                                #endregion
                                                #region PayPart
                                                boperate.getcom("insert into tb_PayPart(Year,Month,SN,RootID,RootName,Date,Time,WareID,WareName,Spec,Unit,StokerID,StokerName,ReCount,"
                                                   + "PUnitPrice,TaxRate,TotalCount,NoTax,Tax,TNTotalCount,TNTax,TNNoTax) values ('" + year + "','" + month + "','" + varSN +
                                                   "','" + varID + "','" + RootName + "','" + varDate + "','" + varTime + "','" + varWareID + "','" + varWareName + "','" + varSpec +
                                                   "','" + varUnit + "','" + varStokerID + "','" + varStokerName + "','" + varReCount + "','" + varPUnitPrice + "','" + varTaxRate +
                                                   "','" + varTTC + "','" + varNT + "','" + varT + "','" + var1 + "','" + var2 + "','" + var3 + "')");

                                                #endregion
                                             
                                                #region Re
                                                decimal vargetTNReCount, varupdateTNReCount, vargetTNSCheckCount;
                                                SqlDataReader sqlreadRe = boperate.getread("select PurOrdersID,PurOrdersSN,TNReCount from tb_TNRe where PurOrdersID='" + varPurOrdersID +
                                                    "'and PurOrdersSN='" + varPurOrdersSN + "'");
                                                sqlreadRe.Read();

                                                if (sqlreadRe.HasRows)
                                                {
                                                    vargetTNReCount = Convert.ToDecimal(sqlreadRe["TNReCount"]);
                                                    varupdateTNReCount = vargetTNReCount + varReCount;
                                                    boperate.getcom("update tb_TNRe set TNReCount='" + varupdateTNReCount + "' where PurOrdersID='" + varPurOrdersID + "' and PurOrdersSN='" + varPurOrdersSN + "'");



                                                }
                                                else
                                                {
                                                    varupdateTNReCount = varReCount;
                                                    boperate.getcom("insert into tb_TNRe(PurOrdersID,PurOrdersSN,TNReCount) values ('" + varPurOrdersID + "','" + varPurOrdersSN +
                                                        "','" + varupdateTNReCount + "')");

                                                }
                                                sqlreadRe.Close();
                                                #endregion
                                                #region SCheckCount

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
                                                        decimal varupdateReaSCheckCount =vargetTNSCheckCount  - varupdateTNReCount;
                                                        boperate.getcom("update tb_PurOrders set USCount='" + varupdateUSCount + "' where PurOrdersID='" + varPurOrdersID +
                                                            "' and SN='" + varPurOrdersSN + "' ");
                                                        boperate.getcom("update tb_POrdersSta set TNReCount='" + varupdateTNReCount + "',USCount='" + varupdateUSCount +
                                                               "',TNReaSCheckCount='"+varupdateReaSCheckCount +"' where PurOrdersID='" + varPurOrdersID + "'  and PurOrdersSN='" + varPurOrdersSN + "'");
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

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            sqlread.Close();
            dt.Clear();
            frmReturnT_Load(sender, e);
  }

        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvReturnInfo.SelectedRows)
            {
                if (!r.IsNewRow)
                {
                    dgvReturnInfo.Rows.Remove(r);

                }
            }
        }

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvReturnInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvReturnInfo.CurrentCell.ColumnIndex == 1)
            {
                C23.BomManage.frmWareInfo frm = new C23.BomManage.frmWareInfo();
                frm.dgvReturnT();
                frm.ShowDialog();
                setWareData();
            } 
            
            if (dgvReturnInfo.CurrentCell.ColumnIndex == 7)
            {
                C23.StockManage .frmStockTable frm = new frmStockTable ();
                frm.ReturnT();
                frm.ShowDialog();
                setStockData();
            }
            if (dgvReturnInfo.CurrentCell.ColumnIndex == 18)
            {
                C23.StorageManage.frmStorageInfo frm = new C23.StorageManage.frmStorageInfo();
                frm.dgvReturnT();
                frm.ShowDialog();
                setStorageData();
            }
            if (dgvReturnInfo.CurrentCell.ColumnIndex == 19)
            {
                C23.StorageManage.frmLocationInfo frm = new C23.StorageManage.frmLocationInfo();
                frm.dgvReturnT();
                frm.ShowDialog();
                setLocationData();
            }
           
        }
        private void setStockData()
        {
            dgvReturnInfo[1, dgvReturnInfo.CurrentCell.RowIndex].Value = getStockInfo[0];
            dgvReturnInfo[2, dgvReturnInfo.CurrentCell.RowIndex].Value = getStockInfo[1];
            dgvReturnInfo[3, dgvReturnInfo.CurrentCell.RowIndex].Value = getStockInfo[2];
            dgvReturnInfo[4, dgvReturnInfo.CurrentCell.RowIndex].Value = getStockInfo[3];
            dgvReturnInfo[7, dgvReturnInfo.CurrentCell.RowIndex].Value = getStockInfo[4];
            dgvReturnInfo[8, dgvReturnInfo.CurrentCell.RowIndex].Value = getStockInfo[5];
            dgvReturnInfo[10, dgvReturnInfo.CurrentCell.RowIndex].Value = getStockInfo[6];
            dgvReturnInfo[11, dgvReturnInfo.CurrentCell.RowIndex].Value = getStockInfo[7];
            dgvReturnInfo[18, dgvReturnInfo.CurrentCell.RowIndex].Value = getStockInfo[8];
            dgvReturnInfo[19, dgvReturnInfo.CurrentCell.RowIndex].Value = getStockInfo[9];
            cboxStokerID.Text = getStockInfo[10];
            txtStokerName.Text = getStockInfo[11];
            cboxPur.Text = getStockInfo[12];
            dgvReturnInfo[5, dgvReturnInfo.CurrentCell.RowIndex].Value = getStockInfo[13];
            dgvReturnInfo[6, dgvReturnInfo.CurrentCell.RowIndex].Value = getStockInfo[14];
            }
        
        private void setStorageData()
        {
            dgvReturnInfo.Rows[dgvReturnInfo.CurrentCell.RowIndex].Cells[18].Value = inputTextDataStorage[0];

        }
        private void setLocationData()
        {
            dgvReturnInfo.Rows[dgvReturnInfo.CurrentCell.RowIndex].Cells[19].Value = inputTextDataLocation[0];
        }
        private void setWareData()
        {
            dgvReturnInfo[1, dgvReturnInfo.CurrentCell.RowIndex].Value = inputTextDataWare[0];
            dgvReturnInfo[2, dgvReturnInfo.CurrentCell.RowIndex].Value = inputTextDataWare[1];
            dgvReturnInfo[3, dgvReturnInfo.CurrentCell.RowIndex].Value = inputTextDataWare[2];
            dgvReturnInfo[4, dgvReturnInfo.CurrentCell.RowIndex].Value = inputTextDataWare[3];
        }
        private void dgvReturnInfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (i = 0; i < dgvReturnInfo.Rows.Count - 1; i++)
            {

                dgvReturnInfo[0, i].Value = i + 1;

            }

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

        private void cboxReStokerID_DropDown(object sender, EventArgs e)
        {
            C23.PUR.frmStokerInfo newFrm = new C23.PUR.frmStokerInfo();
            newFrm.frmReturnT();
            newFrm.ShowDialog();
            setStokerData();
            SendKeys.Send("{Tab}");//向活动应用程序发送Tab键,跳到下一控件
        }

        private void setStokerData()
        {
            this.cboxStokerID.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxStokerID.DroppedDown = false;//使组合框不显示其下拉部分
            this.cboxStokerID.Items[0] = inputTextDataStoker[0];
            this.cboxStokerID.SelectedIndex = 0;
            this.txtStokerName.Text = inputTextDataStoker[1];
            this.cboxStokerID.IntegralHeight = true;//恢复默认值
        }

        private void cboxPur_DropDown(object sender, EventArgs e)
        {
            C23.EmployeeManage.frmEmployeeInfo frm = new C23.EmployeeManage.frmEmployeeInfo();
            frm.ReturnT();
            frm.ShowDialog();
            getEPurData();
        }
        private void getEPurData()
        {
            this.cboxPur.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxPur.DroppedDown = false;//使组合框不显示其下拉部分
            this.cboxPur.Items[0] = inputgetSEName[0];
            this.cboxPur.SelectedIndex = 0;
            this.cboxPur.IntegralHeight = true;//恢复默认值
        }
    }

}
