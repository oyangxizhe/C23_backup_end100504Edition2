using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace C23.SellManage
{
    public partial class frmSellTableT : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected int i;
        public static string[] getOrdersInfo = new string[] { "", "", "", "", "", "", "", "", "", "","","","",""};
        public static string[] inputTextDataWare = new string[] { "", "", "", "" };
        public static string[] getClientInfo = new string[] { "", "" };
        public static string[] getEmployeeInfo = new string[] { "" };
        public static string[] inputTextDataStorage = new string[] { "", "" };
        public frmSellTableT()
        {
            InitializeComponent();
            this.cboxClientID.Items.Add("");
            this.cboxSale.Items.Add("");
        }
        private void frmSellTableT_Load(object sender, EventArgs e)
        {
            BindData();
            dgvStateControl();
        }
        #region BindData
        private void BindData()
        {
            dt = total1();

            dgvSeInfo.DataSource = dt;

            for (i = 0; i < dgvSeInfo.Columns.Count - 1; i++)
            {
                dgvSeInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;



                if (i == 1 || i == 9 || i == 10 || i==11 || i==19|| i==20)
                {
                    dgvSeInfo.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                }
            }
           


        }
        #endregion
        #region dgvStateControl
        private void dgvStateControl()
        {

            int numCols = dgvSeInfo.Columns.Count;

            for (i = 0; i < numCols; i++)
            {

                dgvSeInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (i == 0)
                {
                    dgvSeInfo.Columns[i].Width = 60;

                }

                if (i != 1 && i != 5 && i != 9 && i != 10 && i!=11  && i != 19 && i != 20)
                {
                    dgvSeInfo.Columns[i].ReadOnly = true;

                }


                if (i == 1 || i == 2 || i == 21|| i == 22)
                {
                    dgvSeInfo.Columns[i].Width = 200;
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
            dt.Columns.Add("订单号", typeof(string));
            dt.Columns.Add("订单序号", typeof(string));
            dt.Columns.Add("订单数量", typeof(string));
            dt.Columns.Add("订单未结数量", typeof(string));
            dt.Columns.Add("销货数量", typeof(decimal));
            dt.Columns.Add("销售单价", typeof(decimal));
            dt.Columns.Add("折扣率", typeof(decimal));
            dt.Columns.Add("税率", typeof(decimal));
            dt.Columns.Add("金额", typeof(decimal), "销货数量*销售单价*折扣率");
            dt.Columns.Add("税额", typeof(decimal), "金额*0.17");
            dt.Columns.Add("不含税额", typeof(decimal), "金额-税额");
            dt.Columns.Add("合计金额", typeof(decimal));
            dt.Columns.Add("合计税额", typeof(decimal));
            dt.Columns.Add("合计不含税金额", typeof(decimal));
            dt.Columns.Add("仓库类型", typeof(string));
            dt.Columns.Add("库位名称", typeof(string));
            dt.Columns.Add("客户编号", typeof(string));
            dt.Columns.Add("客户名称", typeof(string));
            dt.Columns.Add("销货日期", typeof(DateTime));
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
            opAndvalidate.num("select Year,Month,SellID from tb_SellTable", "select * from tb_SellTable where Year='" + year +
                "' and Month='" + month + "'", "tb_SellTable", "SellID", "SE", "0001", txtSellID);
            tsbtnSave.Enabled = true;
            ClearText();
        }
        public void ClearText()
        {
            cboxSale.Text = "";
            cboxClientID.Text = "";
            txtCName.Text = "";
        }

        private void tsbntSave_Click(object sender, EventArgs e)
        {
           
            #region SellTable
            string RootName = "销货单";
            bn.Validate();
            string year, month;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            SqlDataReader sqlread = boperate.getread("select VerifyID from tb_Verify where VerifyID='" + dt.Rows[dgvSeInfo.CurrentCell.RowIndex][5].ToString() + "' ");
            sqlread.Read();
            if (sqlread.HasRows)
            {
                MessageBox.Show("此订单号在销货单中已经存在,不要重复带入");
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
                        if (cboxClientID.Text == "")
                        {
                            MessageBox.Show("客户编号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                    MessageBox.Show("销货数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    if (dt.Rows[i][10].ToString() == "")
                                    {
                                        MessageBox.Show("销售单价不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                                string varID = txtSellID.Text.Trim();
                                                string varClientID = cboxClientID.Text.Trim();

                                                string varCName = txtCName.Text.Trim();
                                                DateTime varSellDate1 = Convert.ToDateTime(dtpSeDate.Text.Trim());
                                                string varSellDate = varSellDate1.ToShortDateString();
                                                string varWareID = dt.Rows[i][1].ToString();
                                                string varWareName = dt.Rows[i][2].ToString();
                                                string varSpec = dt.Rows[i][3].ToString();
                                                string varUnit = dt.Rows[i][4].ToString();
                                                string varOrdersID = dt.Rows[i][5].ToString();
                                                string varOrdersSN = dt.Rows[i][6].ToString();
                                                string varOCount = dt.Rows[i][7].ToString();
                                                string varUSCount = dt.Rows[i][8].ToString();

                                                decimal varSellCount = Decimal.Parse(dt.Rows[i][9].ToString());

                                                decimal varSUnitPrice = Decimal.Parse(dt.Rows[i][10].ToString());
                                                decimal varDiscountRate = Decimal.Parse(dt.Rows[i][11].ToString());
                                                decimal varTaxRate = 17;
                                                decimal varTTC = Decimal.Parse(dt.Rows[i][13].ToString());
                                                decimal varT = Decimal.Parse(dt.Rows[i][14].ToString());
                                                decimal varNT = Decimal.Parse(dt.Rows[i][15].ToString());
                                                decimal var1 = (decimal)this.dt.Compute("SUM (金额)", "");
                                                decimal var2 = (decimal)this.dt.Compute("SUM(税额)", "");
                                                decimal var3 = (decimal)this.dt.Compute("SUM(不含税额)", "");
                                                string varStorageType = dt.Rows[i][19].ToString();
                                                string varLocationName = dt.Rows[i][20].ToString();
                                                string varSale = cboxSale.Text.Trim();
                                                string varMaker = frmLogin.M_str_name;
                                                DateTime varDate1 = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                                                string varDate = varDate1.ToShortDateString();
                                                string varTime = DateTime.Now.ToLongTimeString();

            #endregion
                                                #region StorageCase
                                                SqlDataReader sqlread1 = boperate.getread("select StorageCount from tb_StorageCase where WareID='" + varWareID +
                                                 "' and StorageType='" + varStorageType + "' and LocationName='" + varLocationName + "'");
                                                sqlread1.Read();
                                                decimal vargetStorageCount, varupdateStorageCount;

                                                if (sqlread1.HasRows)
                                                {
                                                    vargetStorageCount = Convert.ToDecimal(sqlread1["StorageCount"]);
                                                    if (vargetStorageCount >= varSellCount)
                                                    {
                                                        varupdateStorageCount = vargetStorageCount - varSellCount;
                                                        boperate.getcom("update tb_StorageCase set StorageCount='" + varupdateStorageCount + 
                                                            "' where WareID='" + varWareID + "'and StorageType='" + varStorageType +
                                                            "'and LocationName='" + varLocationName + "'");
                                                   
                                                       
                                                        
                                                        
                                                      
                                                        string varsendValues = "('" + varSN + "','" + varID + "','" + year + "','" + month +
                                       "','" + varWareID + "','" + varWareName + "','" + varSpec + "','" + varUnit + "','" + varOCount +
                                       "','"+varOrdersSN +"','" + varSellCount + "','" + varSUnitPrice + "','" + varTaxRate + "','" + varDiscountRate + "','" + varTTC + "','" + varT +
                                       "','" + varNT + "','" + var1 + "','" + var2 + "','" + var3 + "','" + var1 + "','" + var2 + "','" + var3 + "','" + varOrdersID +
                                       "','" + varStorageType + "','" + varLocationName + "','" + varClientID + "','" + varCName +
                                       "','" + varSellDate + "','" + varSale + "','" + varMaker + "','" + varDate + "','" + varTime + "')";
                                                        boperate.getcom("insert into tb_SellTable(SN,SellID,Year,Month,WareID,WareName,Spec,Unit,OCount,"
                                                        + "OrdersSN,SellCount,SUnitPrice,TaxRate,DiscountRate,TotalCount,Tax,NoTax,TNTotalCount,TNTax,TNNoTax,LastTNTotalCount,"
                                                        + "LastTNTax,LastTNNoTax,OrdersID,StorageType,"
                                                        + "LocationName,ClientID,CName,SellDate,Sale,Maker,Date,Time) values " + varsendValues);
                                                #endregion
                                                        if (varOrdersID != "")
                                                        {
                                                            boperate.getcom("insert into tb_Verify(VerifyID) values ('" + varOrdersID + "')");
                                                        }
                                                      
                                                        
                                                        #region ReceivPart
                                                        boperate.getcom("insert into tb_ReceivPart(Year,Month,SN,RootID,RootName,WareID,WareName,Spec,Unit,SellCount,SUnitPrice,"
                                                                       + "DiscountRate,TaxRate,TotalCount,Tax,NoTax,TNTotalCount,TNTax,TNNoTax,ClientID,CName,Maker,Date,"
                                                                    + "Time) values ('" + year + "','" + month + "','" + varSN + "','" + varID + "','" + RootName + "','" + varWareID + "','" + varWareName +
                                                                    "','" + varSpec + "','" + varUnit + "','" + varSellCount + "','" + varSUnitPrice + "','" + varDiscountRate +
                                                                    "','" + varTaxRate + "','" + varTTC + "','" + varT + "','" + varNT + "','" + var1 + "','" + var2 +
                                                                    "','" + var3 + "','" + varClientID + "','" + varCName + "','" + varMaker + "','" + varDate + "','" + varTime + "')");

                                                        #endregion
                                                        #region AcReceiv
                                                        SqlDataReader sqlreadPay = boperate.getread("select TNTotalCount,TNNoTax,"
                                                        + "TNTax from tb_AcReceiv where ClientID='" + varClientID + "'");
                                                        sqlreadPay.Read();
                                                        decimal vargetTNTotalCount;
                                                        decimal vargetTNNoTax;
                                                        decimal vargetTNTax;
                                                        decimal varupdateTNTotalCount;
                                                        decimal varupdateTNNoTax;
                                                        decimal varupdateTNTax;
                                                        if (sqlreadPay.HasRows)
                                                        {
                                                            vargetTNTotalCount = Convert.ToDecimal(sqlreadPay["TNTotalCount"]);
                                                            vargetTNNoTax = Convert.ToDecimal(sqlreadPay["TNNoTax"]);
                                                            vargetTNTax = Convert.ToDecimal(sqlreadPay["TNTax"]);
                                                            varupdateTNTotalCount = varTTC + vargetTNTotalCount;
                                                            varupdateTNNoTax = varNT + vargetTNNoTax;
                                                            varupdateTNTax = varT + vargetTNTax;
                                                            boperate.getcom("update tb_AcReceiv set TNTotalCount='" + varupdateTNTotalCount + "',TNNoTax='" + varupdateTNNoTax +
                                                                "', TNTax='" + varupdateTNTax + "' where ClientID='" + varClientID + "'");
                                                        }
                                                        else
                                                        {
                                                            boperate.getcom("insert into tb_AcReceiv(ClientID,CName,"
                                                                  + "TNTotalCount,TNNoTax,TNTax) values ('" + varClientID + "','" + varCName + "','" + varTTC +
                                                                  "','" + varNT + "','" + varT + "')");
                                                        }
                                                        sqlreadPay.Close();
                                                        #endregion

                                                        #region SeSR
                                                        decimal vargetTNSellCount, varupdateTNSellCount,varupdateTNReaSellCount;
                                                        SqlDataReader sqlreadSe = boperate.getread("select OrdersID,OrdersSN,TNSellCount from tb_TNSe where OrdersID='" + varOrdersID +
                                                            "'and OrdersSN='" + varOrdersSN + "'");
                                                        sqlreadSe.Read();

                                                        if (sqlreadSe.HasRows)
                                                        {
                                                            vargetTNSellCount = Convert.ToDecimal(sqlreadSe["TNSellCount"]);
                                                            varupdateTNSellCount = vargetTNSellCount + varSellCount;
                                                            boperate.getcom("update tb_TNSe set TNSellCount='" + varupdateTNSellCount + "' where OrdersID='" + varOrdersID +
                                                                "' and OrdersSN='" + varOrdersSN + "'");

                                                        } 
                                                        else
                                                        {
                                                            varupdateTNSellCount = varSellCount;
                                                            boperate.getcom("insert into tb_TNSe(OrdersID,OrdersSN,TNSellCount) values ('" + varOrdersID + "','" + varOrdersSN +
                                                                "','" + varupdateTNSellCount + "')");


                                                        }
                                                        sqlreadSe.Close();
                                                        #endregion
                                                        #region USCount
                                                        SqlDataReader sqlreadus1 = boperate.getread("select OrdersID,SN,OCount from tb_Orders where OrdersID='" + varOrdersID +
                                                            "' and SN='" + varOrdersSN + "'");
                                                        sqlreadus1.Read();
                                                        if (sqlreadus1.HasRows)
                                                        {
                                                            SqlDataReader sqlreadte = boperate.getread("select TNSRCount from tb_TNSR where OrdersID='" + varOrdersID +
                                                               "'AND OrdersSN='" + varOrdersSN + "'");
                                                            sqlreadte.Read();
                                                            if (sqlreadte.HasRows)
                                                            {
                                                                decimal vargetTNSRCount = Convert.ToDecimal(sqlreadte["TNSRCount"]);
                                                                decimal vargetOCount = Convert.ToDecimal(sqlreadus1["OCount"]);
                                                                decimal varupdateUSCount = vargetOCount - varupdateTNSellCount + vargetTNSRCount;
                                                                  varupdateTNReaSellCount = varupdateTNSellCount - vargetTNSRCount;
                                                                boperate.getcom("update tb_Orders set USCount='" + varupdateUSCount + "' where OrdersID='" + varOrdersID + "' and SN='" + varOrdersSN + "' ");
                                                                boperate.getcom("update tb_OrdersSta set TNSellCount='" + varupdateTNSellCount + "',USCount='" + varupdateUSCount +
                                                                   "',TNReaSellCount='"+varupdateTNReaSellCount +"' where OrdersID='" + varOrdersID + "'  and OrdersSN='" + varOrdersSN + "'");
                                                            }
                                                            else
                                                            {
                                                                decimal vargetOCount = Convert.ToDecimal(sqlreadus1["OCount"]);
                                                                decimal varupdateUSCount = vargetOCount - varupdateTNSellCount;
                                                                varupdateTNReaSellCount = varupdateTNSellCount;
                                                                boperate.getcom("update tb_Orders set USCount='" + varupdateUSCount + "' where OrdersID='" + varOrdersID +
                                                                    "' and SN='" + varOrdersSN + "' ");
                                                                boperate.getcom("update tb_OrdersSta set TNSellCount='" + varupdateTNSellCount +
                                                                    "',TNReaSellCount='" +varupdateTNReaSellCount  + "',   USCount='" + varupdateUSCount +
                                                                    "' where OrdersID='" + varOrdersID + "'  and OrdersSN='" + varOrdersSN + "'");
                                                            }
                                                            sqlreadte.Close();
                                                          
                                                        }
                                                        else
                                                        {


                                                        }
                                                        sqlreadus1.Close();
                                                        #endregion

                                                        #region Inventory
                                                        boperate.getcom("insert into tb_Inventory(Year,Month,SN,RootID,RootName,WareID,WareName,Spec,Unit,SellCount,StorageType,LocationName,"
                                                        + "Maker,Date,Time) values ('" + year + "','" + month + "','" + varSN + "','" + varID + "','" + RootName + "','" + varWareID + "','" + varWareName +
                                                        "','" + varSpec +
                                                        "','" + varUnit + "','" + varSellCount + "','" + varStorageType + "','" + varLocationName + "','" + varMaker + "','" + varDate +
                                                       "','" + varTime + "')");
                                                        #endregion

                                                    }
                                                    else 
                                                    {
                                                        MessageBox.Show("库存数量不足");
                                                    }
                                                }
                                                else
                                                {

                                                }
                                                sqlread1.Close();
                                           
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
            frmSellTableT_Load(sender, e);
        }

        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvSeInfo.SelectedRows)
            {
                if (!r.IsNewRow)
                {
                    dgvSeInfo.Rows.Remove(r);

                }
            }
        }

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       private void cboxClientID_DropDown(object sender, EventArgs e)
        {
            C23.SellManage.frmClientInfo frm = new SellManage.frmClientInfo();
            frm.dgvReadOnlySellT();
            frm.ShowDialog();
            AssignmentTextClient();
        }
        private void AssignmentTextClient()
        {
            this.cboxClientID.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxClientID.DroppedDown = false;//使组合框不显示其下拉部分
            this.cboxClientID.SelectedIndex = 0;
            cboxClientID.Items[0] = getClientInfo[0];
            txtCName.Text = getClientInfo[1];
            this.cboxClientID.IntegralHeight = true;//恢复默认值
        }
       private void  AssignmentTextOrders()
        {
            dgvSeInfo[1, dgvSeInfo.CurrentCell.RowIndex].Value = getOrdersInfo[0];
            dgvSeInfo[2, dgvSeInfo.CurrentCell.RowIndex].Value = getOrdersInfo[1];
            dgvSeInfo[3, dgvSeInfo.CurrentCell.RowIndex].Value = getOrdersInfo[2];
            dgvSeInfo[4, dgvSeInfo.CurrentCell.RowIndex].Value = getOrdersInfo[3];
            dgvSeInfo[5, dgvSeInfo.CurrentCell.RowIndex].Value = getOrdersInfo[4];//ordersID
            dgvSeInfo[6, dgvSeInfo.CurrentCell.RowIndex].Value = getOrdersInfo[5];//OrdersSn
            dgvSeInfo[7, dgvSeInfo.CurrentCell.RowIndex].Value = getOrdersInfo[6];//OCount
            dgvSeInfo[8, dgvSeInfo.CurrentCell.RowIndex].Value = getOrdersInfo[7];//USCount
            dgvSeInfo[10, dgvSeInfo.CurrentCell.RowIndex].Value = getOrdersInfo[8];//SUnitPrice
            dgvSeInfo[11, dgvSeInfo.CurrentCell.RowIndex].Value = getOrdersInfo[9];//discountrATE
       
            cboxClientID.Text = getOrdersInfo[10];
            txtCName.Text = getOrdersInfo[11];
            cboxSale.Text = getOrdersInfo[12];
        }
        private void setWareData()
        {
            dgvSeInfo[1, dgvSeInfo.CurrentCell.RowIndex].Value = inputTextDataWare[0];
            dgvSeInfo[2, dgvSeInfo.CurrentCell.RowIndex].Value = inputTextDataWare[1];
            dgvSeInfo[3, dgvSeInfo.CurrentCell.RowIndex].Value = inputTextDataWare[2];
            dgvSeInfo[4, dgvSeInfo.CurrentCell.RowIndex].Value = inputTextDataWare[3];
        }
        private void dgvSeInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSeInfo.CurrentCell.ColumnIndex == 1)
            {
                C23.BomManage.frmWareInfo frm = new C23.BomManage.frmWareInfo();
                frm.SellTableT();
                frm.ShowDialog();
                setWareData();
            }
            if (dgvSeInfo.CurrentCell.ColumnIndex == 5)
            {
                C23.SellManage.frmOrders frm = new C23.SellManage.frmOrders();
                frm.getOrdersdata();
                frm.ShowDialog();
                AssignmentTextOrders();
            }
            if (dgvSeInfo.CurrentCell.ColumnIndex == 19)
            {
                C23.StorageManage.frmStorageCase  frm = new C23.StorageManage.frmStorageCase ();
                frm.SellTableT();
                frm.ShowDialog();
                setStorageData();
            }
            if (dgvSeInfo.CurrentCell.ColumnIndex == 20)
            {
                C23.StorageManage.frmStorageCase  frm=new C23.StorageManage.frmStorageCase ();
                frm.SellTableT();
                frm.ShowDialog();
                setLocationData();
            }
        }
        private void setStorageData()
        {
            dgvSeInfo.Rows[dgvSeInfo.CurrentCell.RowIndex].Cells[19].Value = inputTextDataStorage[0];

        }
        private void setLocationData()
        {
            dgvSeInfo.Rows[dgvSeInfo.CurrentCell.RowIndex].Cells[20].Value = inputTextDataStorage[1];
        }
        private void dgvSeInfo_DataSourceChanged(object sender, EventArgs e)
        {
            for (i = 0; i < dgvSeInfo.Columns.Count; i++)
            {
                if (dgvSeInfo.Columns[i].ValueType.ToString() == "System.Decimal")
                {
                    dgvSeInfo.Columns[i].DefaultCellStyle.Format = "N";
                    dgvSeInfo.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;


                }

            }
        }
      private void dgvSeInfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (i = 0; i < dgvSeInfo.Rows.Count - 1; i++)
            {

                dgvSeInfo[0, i].Value = i + 1;

            }
        }

      private void cboxSale_DropDown(object sender, EventArgs e)
      {
          C23.EmployeeManage.frmEmployeeInfo frm = new C23.EmployeeManage.frmEmployeeInfo();
          frm.SellTableT();
          frm.ShowDialog();
          setEmployeedata();
      }
      private void setEmployeedata()
      {
          this.cboxSale.IntegralHeight = false;//使组合框不调整大小以显示其所有项
          this.cboxSale.DroppedDown = false;//使组合框不显示其下拉部分
          cboxSale.Items[0] = getEmployeeInfo[0];
          this.cboxSale.SelectedIndex = 0;
         this.cboxSale.IntegralHeight = true;//恢复默认值

      }

    }
}
