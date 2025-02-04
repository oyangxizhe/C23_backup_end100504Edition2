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
    public partial class frmStockTableT : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected int  i;
     
        public static string[] inputTextDataStoker = new string[] { "", "" };
        public static string[] inputTextDataWare = new string[] { null, null, null, null };
        public static string[] inputTextDataStorage = new string[] { "" };
        public static string[] inputTextDataLocation = new string[] { "" };
        public static string[] inputgetSEName = new string[] { "" };
        public static string[] getPurInfo = new string[] { "", "", "", "", "", "", "", "", "", "", "","" };


        public frmStockTableT()
        {
            InitializeComponent();
            this.cboxStokerID.Items.Add("");
            this.cboxPur.Items.Add("");
            this.cboxAcceptor.Items.Add("");
        }
     
        #region Add
        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            opAndvalidate.num("select Year,Month,StockID from tb_StockTable", "select * from tb_StockTable where Year='" + year +
                "' and Month='" + month + "'", "tb_StockTable", "StockID", "ST", "0001", txtStockID);
            tsbtnSave.Enabled = true;
            ClearText();


        }
        #endregion
        public void ClearText()
        {
            cboxPur.Text = "";
            cboxAcceptor.Text = "";
            cboxStokerID.Text = "";
            txtStokerName.Text = "";
        }
    
        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            #region
            string RootName = "进货单";
            bn.Validate();
            string year, month;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            SqlDataReader sqlread = boperate.getread("select VerifyID from tb_Verify where VerifyID='" + dt.Rows[dgvStockInfo .CurrentCell .RowIndex ][5].ToString() +"' ");
            sqlread.Read();
            if (sqlread.HasRows)
            {
                MessageBox.Show("此采购单号在进货单中已经存在,不要重复带入");
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
                                if (dt.Rows[i][10].ToString() == "")
                                {
                                    MessageBox.Show("验收数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                                string varID = txtStockID.Text;
                                                string varAcceptor = cboxAcceptor.Text.Trim();
                                                string varPur = cboxPur.Text.Trim();
                                                string varStokerID = cboxStokerID.Text.Trim();
                                                string varStokerName = txtStokerName.Text.Trim();
                                                DateTime varStockDate1 = Convert.ToDateTime(dtpStockDate.Text.Trim());
                                                string varStockDate = varStockDate1.ToShortDateString();
                                                string varMaker = frmLogin.M_str_name;
                                                DateTime varDate1 = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                                                string varDate = varDate1.ToShortDateString();
                                                string varTime = DateTime.Now.ToLongTimeString();
                                                string varWareID = dt.Rows[i][1].ToString();
                                                string varWareName = dt.Rows[i][2].ToString();
                                                string varSpec = dt.Rows[i][3].ToString();
                                                string varUnit = dt.Rows[i][4].ToString();

                                                string varSCount = dt.Rows[i][9].ToString();
                                                string varPurOrdersID = dt.Rows[i][5].ToString();
                                                string varPurOrdersSN = dt.Rows[i][6].ToString();
                                                string varPCount = dt.Rows[i][7].ToString();
                                                decimal varCheckCount = Decimal.Parse(dt.Rows[i][10].ToString());
                                                decimal varUnitPrice = Decimal.Parse(dt.Rows[i][11].ToString());
                                                decimal varTaxRate = 17;
                                                decimal varTTC = Decimal.Parse(dt.Rows[i][13].ToString());
                                                decimal varT = Decimal.Parse(dt.Rows[i][14].ToString());
                                                decimal varNT = Decimal.Parse(dt.Rows[i][15].ToString());
                                                decimal var1 = (decimal)this.dt.Compute("SUM (金额)", "");
                                                decimal var2 = (decimal)this.dt.Compute("SUM(税额)", "");
                                                decimal var3 = (decimal)this.dt.Compute("SUM(不含税额)", "");
                                                string varStorageType = dt.Rows[i][19].ToString();
                                                string varLocationName = dt.Rows[i][20].ToString();
                                                #region StockTable
                                                string varsendValues = "('" + varSN + "','" + varID + "','" + year + "','" + month +
                                            "','" + varWareID + "','" + varWareName + "','" + varSpec + "','" + varUnit + "','" + varSCount +
                                            "','" + varCheckCount + "','" + varUnitPrice +
                                            "','" + varTaxRate + "','" + varTTC + "','" + varT + "','" + varNT + "','" + var1 +
                                            "','" + var2 + "','" + var3 + "','" + varPurOrdersID + "','"+varPurOrdersSN +"','" + varPCount +
                                            "','" + varStorageType + "','" + varLocationName + "','" + varStokerID + "','" + varStokerName +
                                            "','" + varStockDate + "','" + varAcceptor +
                                            "','" + varPur + "','" + varMaker + "','" + varDate + "','" + varTime + "')";
                                                boperate.getcom("insert into tb_StockTable(SN,StockID,Year,Month,WareID,WareName,Spec,Unit,StockCount,"
                                                + "CheckCount,PUnitPrice,TaxRate,TotalCount,Tax,NoTax,TNTotalCount,TNTax,TNNoTax,PurOrdersID,PurOrdersSN,PCount,StorageType,"
                                                + "LocationName,StokerID,StokerName,StockDate,Acceptor,Pur,Maker,Date,Time) values " + varsendValues);
                                                #endregion
                                                if (varPurOrdersID != "")
                                                {
                                                    boperate.getcom("insert into tb_Verify(VerifyID) values ('" + varPurOrdersID + "')");
                                                }

                                                #region StorageCase
                                                SqlDataReader sqlread1 = boperate.getread("Select WareID,StorageType,LocationName,StorageCount from tb_StorageCase where WareID='" + varWareID +
                                                    "' and StorageType='" + varStorageType + "' and LocationName='" + varLocationName + "'");
                                           
                                                sqlread1.Read();
                                     
                                                if (sqlread1.HasRows )
                                                {
                                                    decimal vargetStorageCount = Convert.ToDecimal(sqlread1["StorageCount"]);


                                                    decimal varStorageCount = vargetStorageCount + varCheckCount;

                                                    boperate.getcom("update tb_StorageCase set  StorageCount='" + varStorageCount +
                                                           "' where WareID='" + varWareID + "' and StorageType='" + varStorageType + "' and LocationName='" + varLocationName + "'");
                                                }
                                                else
                                                {
                                                    boperate.getcom("insert into tb_StorageCase(WareID,WareName,Spec,Unit,StorageType,LocationName,"
                                                       + "StorageCount) values ('" + varWareID + "','" + varWareName +
                                                       "','" + varSpec + "','" + varUnit + "','" + varStorageType + "','" + varLocationName +
                                                         "','" + varCheckCount + "')");
                                                }
                                                sqlread1.Close();
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
                                                    varupdateTotalCount = varTTC + vargetTotalCount;
                                                    varupdateTax = varT + vargetTax;
                                                    varupdateNoTax = varNT + vargetNoTax;


                                                    boperate.getcom("update tb_AcPay set TNTotalCount='" + varupdateTotalCount + "',TNNoTax='" + varupdateNoTax + "', TNTax='" + varupdateTax +
                                                         "' where StokerID='" + varStokerID + "'");

                                                }
                                                else
                                                {
                                                    boperate.getcom("insert into tb_AcPay(StokerID,StokerName,TNTotalCount,TNTax,TNNoTax) values ('" + varStokerID + "','" + varStokerName + "','" + varTTC +
                                                          "','" + varT + "','" + varNT + "')");
                                                }
                                                sqlreadPay.Close();
#endregion
                                                #region PayPart
                                                boperate.getcom("insert into tb_PayPart(Year,Month,SN,RootID,RootName,WareID,WareName,Spec,Unit,StokerID,StokerName,StockCount,"
                                                + "PUnitPrice,TaxRate,TotalCount,NoTax,Tax,TNTotalCount,TNTax,TNNoTax,Maker,Date,Time) values ('" + year + "','" + month + "','" + varSN + "','" + varID
                                                + "','" + RootName + "','" + varWareID + "','" + varWareName + "','" + varSpec + "','" + varUnit + "','" + varStokerID + "','" + varStokerName +
                                                "','" + varCheckCount + "','" + varUnitPrice + "','" + varTaxRate + "','" + varTTC + "','" + varNT +
                                                 "','" + varT + "','" + var1 + "','" + var2 + "','" + var3 + "','" + varMaker + "','" + varDate + "','" + varTime + "')");
                                                #endregion

                                                   #region Sc
                                                decimal vargetTNSCheckCount, varupdateTNSCheckCount, varupdateTNReaSCheckCount,varupdateUSCount;
                                                        SqlDataReader sqlreadSc = boperate.getread("select PurOrdersID,PurOrdersSN,TNSCheckCount from tb_TNSC where PurOrdersID='" + varPurOrdersID +
                                                            "'and PurOrdersSN='" + varPurOrdersSN + "'");
                                                        sqlreadSc.Read();

                                                        if (sqlreadSc.HasRows)
                                                        {
                                                            vargetTNSCheckCount = Convert.ToDecimal(sqlreadSc["TNSCheckCount"]);
                                                            varupdateTNSCheckCount = vargetTNSCheckCount + varCheckCount;
                                                            boperate.getcom("update tb_TNSC set TNSCheckCount='" + varupdateTNSCheckCount + "' where PurOrdersID='" + varPurOrdersID +
                                                                "' and PurOrdersSN='" + varPurOrdersSN + "'");

                                                        }
                                                        else
                                                        {
                                                            varupdateTNSCheckCount = varCheckCount;
                                                            boperate.getcom("insert into tb_TNSC(PurOrdersID,PurOrdersSN,TNSCheckCount) values ('" + varPurOrdersID +"','" + varPurOrdersSN + 
                                                                "','" + varupdateTNSCheckCount  + "')");


                                                        }
                                                        sqlreadSc.Close();
                                                        #endregion
                                                #region USCount
                                                SqlDataReader sqlreadus1 = boperate.getread("select PurOrdersID,SN,PCount from tb_PurOrders where PurOrdersID='" + varPurOrdersID  +
                                                    "' and SN='" + varPurOrdersSN + "'");
                                                sqlreadus1.Read();
                                                if (sqlreadus1.HasRows)
                                                {
                                                    SqlDataReader sqlreadte = boperate.getread("select TNReCount from tb_TNRe where PurOrdersID='" + varPurOrdersID  +
                                                       "'AND PurOrdersSN='" + varPurOrdersSN + "'");
                                                    sqlreadte.Read();
                                                    if (sqlreadte.HasRows)
                                                    {
                                                        decimal vargetTNReCount = Convert.ToDecimal(sqlreadte["TNReCount"]);
                                                        decimal vargetPCount = Convert.ToDecimal(sqlreadus1["PCount"]);
                                                               varupdateUSCount = vargetPCount - varupdateTNSCheckCount + vargetTNReCount;
                                                        varupdateTNReaSCheckCount = varupdateTNSCheckCount - vargetTNReCount;
                                                      
                                                    }
                                                    else
                                                    {
                                                        decimal vargetPCount = Convert.ToDecimal(sqlreadus1["PCount"]);
                                                               varupdateUSCount = vargetPCount - varupdateTNSCheckCount;
                                                        varupdateTNReaSCheckCount = varupdateTNSCheckCount;
                                                     
                                                    }
                                                      boperate.getcom("update tb_PurOrders set USCount='" + varupdateUSCount + "' where PurOrdersID='" + varPurOrdersID + "' and SN='" + varPurOrdersSN + "' ");
                                                        boperate.getcom("update tb_POrdersSta set TNSCheckCount='" + varupdateTNSCheckCount + "',USCount='" + varupdateUSCount +
                                                           "',TNReaSCheckCount='" + varupdateTNReaSCheckCount + "' where PurOrdersID='" + varPurOrdersID + "'  and PurOrdersSN='" + varPurOrdersSN + "'");
                                                    sqlreadte.Close();

                                                }
                                                else
                                                {


                                                }
                                                sqlreadus1.Close();
                                                #endregion
                                                #region Inventory
                                                boperate.getcom("insert into tb_Inventory(Year,Month,SN,RootID,RootName,WareID,WareName,Spec,Unit,StockCount,StorageType,"
                                                + "LocationName,Maker,Date,"
                                                + "Time) values ('" + year + "','" + month + "','" + varSN + "','" + varID + "','" + RootName + "','" + varWareID + "','" + varWareName + "','" + varSpec +
                                                 "','" + varUnit + "','" + varCheckCount + "','" + varStorageType + "','" + varLocationName +
                                                 "','" + varMaker + "','" + varDate + "','" + varTime + "')");
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
            frmStockTableT_Load(sender, e);
            #endregion
        }
      
        #region Del
        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvStockInfo.SelectedRows)
            {
                if (!r.IsNewRow)
                {
                    dgvStockInfo.Rows.Remove(r);

                }
            }
        }
        #endregion
        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region BindData
        private void BindData()
        {
            dt = total1();

            dgvStockInfo.DataSource = dt;

            for (i = 0; i < dgvStockInfo.Columns.Count - 1; i++)
            {
                dgvStockInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;



                if (i==1 || i == 10 || i == 11 || i ==19|| i==20 )
                {
                    dgvStockInfo.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
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
            dt.Columns.Add("采购单序号", typeof(string));
            dt.Columns.Add("采购数量", typeof(string));
            dt.Columns.Add("采购单未结数量", typeof(string));
            dt.Columns.Add("进货数量", typeof(string ));
            dt.Columns.Add("验收数量", typeof(decimal ));
            dt.Columns.Add("采购单价", typeof(decimal));
            dt.Columns.Add("税率", typeof(decimal));
            dt.Columns.Add("金额", typeof(decimal), "验收数量*采购单价");
            dt.Columns.Add("税额", typeof(decimal), "金额*0.17");
            dt.Columns.Add("不含税额", typeof(decimal), "金额-税额");
            dt.Columns.Add("合计金额", typeof(decimal));
            dt.Columns.Add("合计税额", typeof(decimal));
            dt.Columns.Add("合计不含税金额", typeof(decimal));
            dt.Columns.Add("仓库类型", typeof(string));
            dt.Columns.Add("库位名称", typeof(string));
            dt.Columns.Add("供运商编号", typeof(string));
            dt.Columns.Add("供运商名称", typeof(string));
            dt.Columns.Add("进货日期", typeof(DateTime));
            dt.Columns.Add("验收人", typeof(string));
            dt.Columns.Add("采购员", typeof(string));
            dt.Columns.Add("制单人", typeof(char));
            dt.Columns.Add("制单日期", typeof(DateTime));
            dt.Columns.Add("制单时间", typeof(string));
            return dt;
        }
        #endregion
        #region RowsAdded
        private void dgvStockInfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (i = 0; i < dgvStockInfo.Rows.Count - 1; i++)
            {

                dgvStockInfo[0, i].Value = i + 1;

            }
        }
        #endregion
        private void dgvStockInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStockInfo.CurrentCell.ColumnIndex == 1)
            {
                C23.BomManage.frmWareInfo frm = new C23.BomManage.frmWareInfo();
                frm.dgvStockTableT();
                frm.ShowDialog();
                setWareData();
            } 
            if (dgvStockInfo.CurrentCell.ColumnIndex == 5)
            {
                C23.PUR.frmPurOrders frm = new C23.PUR.frmPurOrders();
                frm.dgvPurOrders();
                frm.ShowDialog();
                setPurData();
            }
            if (dgvStockInfo.CurrentCell.ColumnIndex == 19) 
            {
                C23.StorageManage.frmStorageInfo frm = new C23.StorageManage.frmStorageInfo();
                frm.dgvStockTableT();
                frm.ShowDialog();
                setStorageData();
            }
            if (dgvStockInfo.CurrentCell.ColumnIndex == 20)
            {
                C23.StorageManage.frmLocationInfo  frm = new C23.StorageManage.frmLocationInfo ();
                frm.dgvStockTableT();
                frm.ShowDialog();
                setLocationData();
            }
           

        }
        private void setStorageData()
        {
            dgvStockInfo.Rows[dgvStockInfo.CurrentCell.RowIndex].Cells[19].Value = inputTextDataStorage[0];

        }
        private void setLocationData()
        {
            dgvStockInfo.Rows[dgvStockInfo.CurrentCell.RowIndex].Cells[20].Value = inputTextDataLocation[0];
        }
       private void setPurData()
        {
            dgvStockInfo[1, dgvStockInfo.CurrentCell.RowIndex].Value = getPurInfo[0] ;
            dgvStockInfo[2, dgvStockInfo.CurrentCell.RowIndex].Value = getPurInfo[1];
            dgvStockInfo[3, dgvStockInfo.CurrentCell.RowIndex].Value = getPurInfo[2];
            dgvStockInfo[4, dgvStockInfo.CurrentCell.RowIndex].Value = getPurInfo[3];
            dgvStockInfo[5, dgvStockInfo.CurrentCell.RowIndex].Value = getPurInfo[4];
            dgvStockInfo[6, dgvStockInfo.CurrentCell.RowIndex].Value = getPurInfo[10];
            dgvStockInfo[8, dgvStockInfo.CurrentCell.RowIndex].Value = getPurInfo[11];
           dgvStockInfo[7, dgvStockInfo.CurrentCell.RowIndex].Value = getPurInfo[5];
            dgvStockInfo[11, dgvStockInfo.CurrentCell.RowIndex].Value = getPurInfo[6];
            cboxStokerID .Text  = getPurInfo[7];
            txtStokerName .Text =  getPurInfo[8];
            cboxPur.Text= getPurInfo[9];
            

        }
        private void setWareData()
        {
            dgvStockInfo[1, dgvStockInfo.CurrentCell.RowIndex].Value = inputTextDataWare[0];
            dgvStockInfo[2, dgvStockInfo.CurrentCell.RowIndex].Value = inputTextDataWare[1];
            dgvStockInfo[3, dgvStockInfo.CurrentCell.RowIndex].Value = inputTextDataWare[2];
            dgvStockInfo[4, dgvStockInfo.CurrentCell.RowIndex].Value = inputTextDataWare[3];
        }
        #region dgvStateControl
        private void dgvStateControl()
        {

            int numCols = dgvStockInfo.Columns.Count;

            for (i = 0; i < numCols; i++)
            {

                dgvStockInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (i == 0)
                {
                    dgvStockInfo.Columns[i].Width = 60;

                }
             
                if (i != 1 && i != 10 && i != 5  && i !=11 && i !=19 && i !=20 )
                {
                    dgvStockInfo.Columns[i].ReadOnly = true;

                }

              
                if (i == 1 || i == 2 || i == 21 || i == 22)
                {
                    dgvStockInfo.Columns[i].Width = 200;
                }

            }
        }
        #endregion
        #region DataSourceChanged
        private void dgvStockInfo_DataSourceChanged(object sender, EventArgs e)
        {
            for (i = 0; i < dgvStockInfo.Columns.Count; i++)
            {
                if (dgvStockInfo.Columns[i].ValueType.ToString() == "System.Decimal")
                {
                    dgvStockInfo.Columns[i].DefaultCellStyle.Format = "N";
                    dgvStockInfo.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;


                }

            }
        }
        #endregion

        private void frmStockTableT_Load(object sender, EventArgs e)
        {
            BindData();
            dgvStateControl();
        }
   
        private void cboxStokerID_DropDown(object sender, EventArgs e)
        {
            C23.PUR.frmStokerInfo newFrm = new C23.PUR.frmStokerInfo();
            newFrm.frmStockTableT();
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
            frm.dgvReadOnlyStockT();
            frm.ShowDialog();
            ComplexPurInfo();
        }
        private void ComplexPurInfo()
        {
            this.cboxPur.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxPur.DroppedDown = false;//使组合框不显示其下拉部分
            this.cboxPur.Items[0] = inputgetSEName[0];
            this.cboxPur.SelectedIndex = 0;
            this.cboxPur.IntegralHeight = true;//恢复默认值

        }
        private void cboxAcceptor_DropDown(object sender, EventArgs e)
        {
            C23.EmployeeManage.frmEmployeeInfo frm = new C23.EmployeeManage.frmEmployeeInfo();
            frm.dgvReadOnlyStockT();
            frm.ShowDialog();
            getAcceptorData();
        }
      
        private void getAcceptorData()
        {
            this.cboxAcceptor.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxAcceptor.DroppedDown = false;//使组合框不显示其下拉部分
            this.cboxAcceptor.Items[0] = inputgetSEName[0];
            this.cboxAcceptor.SelectedIndex = 0;
            this.cboxAcceptor.IntegralHeight = true;//恢复默认值
        }

     

    }
}
