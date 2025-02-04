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
    public partial class frmSellReT : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected int i;
        public static string[] getSellTableInfo = new string[] { "", "", "", "", "", "", "", "", "", "", "", "","","",""};
        public static string[] inputTextDataWare = new string[] { "", "", "", "" };
        public static string[] getClientInfo = new string[] { "", "" };
        public static string[] getEmployeeInfo = new string[] { "" };
        public static string[] getStorageTypeInfo = new string[] { "" };
        public static string[] getLocationNameInfo = new string[] { "" };

        public frmSellReT()
        {
            InitializeComponent();
            this.cboxClientID.Items.Add("");
            this.cboxSale.Items.Add("");
        }
        #region Sale/Client
        private void cboxSale_DropDown(object sender, EventArgs e)
        {
            C23.EmployeeManage.frmEmployeeInfo frm = new C23.EmployeeManage.frmEmployeeInfo();
            frm.SellReT();
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
        private void cboxClientID_DropDown(object sender, EventArgs e)
        {
            C23.SellManage.frmClientInfo frm = new SellManage.frmClientInfo();
            frm.SellReT();
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
#endregion
        private void frmSellReT_Load(object sender, EventArgs e)
        {
            BindData();
            dgvStateControl();
        }
        #region BindData
        private void BindData()
        {
            dt = total1();

            dgvSRInfo.DataSource = dt;

            for (i = 0; i < dgvSRInfo.Columns.Count - 1; i++)
            {
                dgvSRInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;



                if (i == 1 || i == 8 || i == 10 || i == 11 || i == 20 || i == 21)
                {
                    dgvSRInfo.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                }
            }



        }
        #endregion
        #region dgvStateControl
        private void dgvStateControl()
        {

            int numCols = dgvSRInfo.Columns.Count;

            for (i = 0; i < numCols; i++)
            {

                dgvSRInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (i == 0)
                {
                    dgvSRInfo.Columns[i].Width = 60;

                }

                if (i != 1 && i != 8 && i != 10 && i != 11 && i != 12 && i != 20 && i != 21)
                {
                    dgvSRInfo.Columns[i].ReadOnly = true;

                }


                if (i == 1 || i == 2 || i == 22 || i == 23)
                {
                    dgvSRInfo.Columns[i].Width = 200;
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
            dt.Columns.Add("销货单号", typeof(string));
            dt.Columns.Add("销货数量", typeof(string));
            dt.Columns.Add("销退数量", typeof(decimal));
            dt.Columns.Add("销售单价", typeof(decimal));
            dt.Columns.Add("折扣率", typeof(decimal));
            dt.Columns.Add("税率", typeof(decimal));
            dt.Columns.Add("金额", typeof(decimal), "销退数量*销售单价*折扣率");
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
            opAndvalidate.num("select Year,Month,SellReID from tb_SellRe", "select * from tb_SellRe where Year='" + year +
                "' and Month='" + month + "'", "tb_SellRe", "SellReID", "SR", "0001", txtSellReID);
            tsbtnSave.Enabled = true;
            ClearText();
        }
        public void ClearText()
        {
            cboxSale.Text = "";
            cboxClientID.Text = "";
            txtCName.Text = "";
        }
        #region Save
        private void tsbtnSave_Click(object sender, EventArgs e)
        {

            #region SellReT
            string RootName = "销退单";
            bn.Validate();
            string year, month;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            SqlDataReader sqlread = boperate.getread("select VerifyID from tb_Verify where VerifyID='" + dt.Rows[dgvSRInfo.CurrentCell.RowIndex][8].ToString() + "' ");
            sqlread.Read();
            if (sqlread.HasRows)
            {
                MessageBox.Show("此销货单号在退货单中已经存在,不要重复带入");
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
                                if (dt.Rows[i][10].ToString() == "")
                                {
                                    MessageBox.Show("销退数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    if (dt.Rows[i][11].ToString() == "")
                                    {
                                        MessageBox.Show("销售单价不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                    else
                                    {
                                        if (dt.Rows[i][20].ToString() == "")
                                        {
                                            MessageBox.Show("仓库类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            if (dt.Rows[i][21].ToString() == "")
                                            {
                                                MessageBox.Show("库位名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            else
                                            {
                                                string varSN = dt.Rows[i][0].ToString();
                                                string varID = txtSellReID.Text.Trim();
                                                string varClientID = cboxClientID.Text.Trim();

                                                string varCName = txtCName.Text.Trim();
                                                DateTime varSellReDate1 = Convert.ToDateTime(dtpSellReDate.Text.Trim());
                                                string varSellReDate = varSellReDate1.ToShortDateString();
                                                string varWareID = dt.Rows[i][1].ToString();
                                                string varWareName = dt.Rows[i][2].ToString();
                                                string varSpec = dt.Rows[i][3].ToString();
                                                string varUnit = dt.Rows[i][4].ToString();
                                                string varOrdersID = dt.Rows[i][5].ToString();
                                                string varOrdersSN = dt.Rows[i][6].ToString();
                                                string varOCount = dt.Rows[i][7].ToString();
                                                string varSellID = dt.Rows[i][8].ToString();
                                                string varSellCount = dt.Rows[i][9].ToString();

                                                decimal varSRCount = Decimal.Parse(dt.Rows[i][10].ToString());

                                                decimal varSUnitPrice = Decimal.Parse(dt.Rows[i][11].ToString());
                                                decimal varDiscountRate = Decimal.Parse(dt.Rows[i][12].ToString());
                                                decimal varTaxRate = 17;
                                                decimal varTTC = Decimal.Parse(dt.Rows[i][14].ToString());
                                                decimal varT = Decimal.Parse(dt.Rows[i][15].ToString());
                                                decimal varNT = Decimal.Parse(dt.Rows[i][16].ToString());
                                                decimal var1 = (decimal)this.dt.Compute("SUM (金额)", "");
                                                decimal var2 = (decimal)this.dt.Compute("SUM(税额)", "");
                                                decimal var3 = (decimal)this.dt.Compute("SUM(不含税额)", "");
                                                string varStorageType = dt.Rows[i][20].ToString();
                                                string varLocationName = dt.Rows[i][21].ToString();
                                                string varSale = cboxSale.Text.Trim();
                                                string varMaker = frmLogin.M_str_name;
                                                DateTime varDate1 = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                                                string varDate = varDate1.ToShortDateString();
                                                string varTime = DateTime.Now.ToLongTimeString();
                                             

                                                string varsendValues = "('" + varSN + "','" + varID + "','" + year + "','" + month +
                                            "','" + varWareID + "','" + varWareName + "','" + varSpec + "','" + varUnit + "','"+varOrdersID +"','"+varOrdersSN +"','"+varOCount +"','" + varSellCount +
                                            "','" + varSRCount + "','" + varSUnitPrice + "','" + varTaxRate + "','" + varDiscountRate + "','" + varTTC + "','" + varT +
                                            "','" + varNT + "','" + var1 + "','" + var2 + "','" + var3 + "','" + var1 + "','" + var2 + "','" + var3 + "','" + varSellID +
                                            "','" + varStorageType + "','" + varLocationName + "','" + varClientID + "','" + varCName +
                                            "','" + varSellReDate + "','" + varSale + "','" + varMaker + "','" + varDate + "','" + varTime + "')";
                                              
                                                boperate.getcom("insert into tb_SellRe(SN,SellReID,Year,Month,WareID,WareName,Spec,Unit,OrdersID,OrdersSN,OCount,SellCount,"
                                                + "SRCount,SUnitPrice,TaxRate,DiscountRate,TotalCount,Tax,NoTax,TNTotalCount,TNTax,TNNoTax,LastTNTotalCount,"
                                                + "LastTNTax,LastTNNoTax,SellID,StorageType,"
                                                + "LocationName,ClientID,CName,SellReDate,Sale,Maker,Date,Time) values " + varsendValues);
            #endregion
                                                if (varSellID != "")
                                                {
                                                    boperate.getcom("insert into tb_Verify(VerifyID) values ('" + varSellID + "')");
                                                }
                                                boperate.getcom("insert into tb_Verify(VerifyID) values ('" + varID + "')");
                                                #region StorageCase
                                                SqlDataReader sqlread1 = boperate.getread("select StorageCount from tb_StorageCase where WareID='" + varWareID +
                                                "' and StorageType='" + varStorageType + "' and LocationName='" + varLocationName + "'");
                                                sqlread1.Read();
                                                if (sqlread1.HasRows)
                                                {
                                                    decimal vargetStorageCount = Convert.ToDecimal(sqlread1["StorageCount"]);
                                                    decimal varupdateStorageCount = vargetStorageCount + varSRCount;
                                                    boperate.getcom("update tb_StorageCase set  StorageCount='" + varupdateStorageCount +
                                                         "'where WareID='" + varWareID + "' and StorageType='" + varStorageType +
                                                         "' and LocationName='" + varLocationName + "'");
                                                }
                                                else
                                                {
                                                    boperate.getcom("insert into tb_StorageCase(WareID,WareName,Spec,Unit,StorageType,LocationName,"
                                                       + "StorageCount) values ('" + varWareID + "','" + varWareName +
                                                       "','" + varSpec + "','" + varUnit + "','" + varStorageType + "','" + varLocationName +
                                                         "','" + varSRCount + "')");
                                                }
                                                sqlread1.Close();
                                                #endregion
                                              
                                                #region ReceivPart
                                                boperate.getcom("insert into tb_ReceivPart(Year,Month,SN,RootID,RootName,WareID,WareName,Spec,Unit,SRCount,SUnitPrice,"
                                                               + "DiscountRate,TaxRate,TotalCount,Tax,NoTax,TNTotalCount,TNTax,TNNoTax,ClientID,CName,Maker,Date,"
                                                            + "Time) values ('" + year + "','" + month + "','" + varSN + "','" + varID + "','" + RootName + "','" + varWareID + "','" + varWareName +
                                                            "','" + varSpec + "','" + varUnit + "','" + varSRCount + "','" + varSUnitPrice + "','" + varDiscountRate +
                                                            "','" + varTaxRate + "','" + varTTC + "','" + varT + "','" + varNT + "','" + var1 + "','" + var2 +
                                                            "','" + var3 + "','" + varClientID + "','" + varCName + "','" + varMaker + "','" + varDate + "','" + varTime + "')");

                                                #endregion
                                                #region AcReceiv
                                                SqlDataReader sqlreadPay = boperate.getread("select TNTotalCount,TNNoTax,TNTax from tb_AcReceiv where ClientID='" + varClientID + "'");
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

                                                    varupdateTNTotalCount = vargetTNTotalCount - varTTC;
                                                    varupdateTNNoTax = vargetTNNoTax - varNT;
                                                    varupdateTNTax = vargetTNTax - varT;
                                                    boperate.getcom("update tb_AcReceiv set TNTotalCount='" + varupdateTNTotalCount + "',TNNoTax='" + varupdateTNNoTax +
                                                        "', TNTax='" + varupdateTNTax + "' where ClientID='" + varClientID + "'");
                                                }
                                                else
                                                {

                                                }
                                                sqlreadPay.Close();
                                                #endregion

                                                #region SR
                                                decimal vargetTNSRCount, varupdateTNSRCount, vargetTNSellCount;
                                                SqlDataReader sqlreadSR = boperate.getread("select OrdersID,OrdersSN,TNSRCount from tb_TNSR where OrdersID='" + varOrdersID +
                                                    "'and OrdersSN='" + varOrdersSN + "'");
                                                sqlreadSR.Read();

                                                if (sqlreadSR.HasRows)
                                                {
                                                    vargetTNSRCount = Convert.ToDecimal(sqlreadSR["TNSRCount"]);
                                                    varupdateTNSRCount = vargetTNSRCount + varSRCount;
                                                    boperate.getcom("update tb_TNSR set TNSRCount='" + varupdateTNSRCount + "' where OrdersID='" + varOrdersID + 
                                                        "' and OrdersSN='" + varOrdersSN + "'");



                                                }
                                                else
                                                {
                                                    varupdateTNSRCount = varSRCount;
                                                    boperate.getcom("insert into tb_TNSR(OrdersID,OrdersSN,TNSRCount) values ('" + varOrdersID + "','" + varOrdersSN +
                                                        "','" + varupdateTNSRCount + "')");

                                                }
                                                sqlreadSR.Close();
                                                #endregion
                                                #region Se

                                                SqlDataReader sqlreadSe = boperate.getread("select OrdersID,OrdersSN,TNSellCount from tb_TNSe where OrdersID='" + varOrdersID +
                                                    "'and OrdersSN='" + varOrdersSN + "'");
                                                sqlreadSe.Read();

                                                if (sqlreadSe.HasRows)
                                                {
                                                    vargetTNSellCount = Convert.ToDecimal(sqlreadSe["TNSellCount"]);

                                                    #region USCount
                                                    SqlDataReader sqlreadus1 = boperate.getread("select OrdersID,SN,OCount from tb_Orders where OrdersID='" + varOrdersID +
                                                        "' and SN='" + varOrdersSN + "'");
                                                    sqlreadus1.Read();
                                                    if (sqlreadus1.HasRows)
                                                    {
                                                        decimal vargetOCount = Convert.ToDecimal(sqlreadus1["OCount"]);
                                                        decimal varupdateUSCount = vargetOCount - vargetTNSellCount + varupdateTNSRCount;
                                                        decimal varupdateTNReaSellCount = vargetTNSellCount - varupdateTNSRCount;
                                                        boperate.getcom("update tb_Orders set USCount='" + varupdateUSCount + "' where OrdersID='" + varOrdersID +
                                                            "' and SN='" + varOrdersSN + "' ");
                                                        boperate.getcom("update tb_OrdersSta set TNSRCount='" + varupdateTNSRCount + "',USCount='" + varupdateUSCount +
                                                               "',TNReaSellCount='"+varupdateTNReaSellCount +"' where OrdersID='" + varOrdersID + "'  and OrdersSN='" + varOrdersSN + "'");
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
                                                sqlreadSe.Close();
                                                #endregion
                                                #region Inventory
                                                boperate.getcom("insert into tb_Inventory(Year,Month,SN,RootID,RootName,WareID,WareName,Spec,Unit,SRCount,StorageType,LocationName,"
                                                + "Maker,Date,Time) values ('" + year + "','" + month + "','" + varSN + "','" + varID + "','" + RootName + "','" + varWareID +
                                                "','" + varWareName + "','" + varSpec + "','" + varUnit + "','" + varSRCount + "','" + varStorageType + "','" + varLocationName +
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
            frmSellReT_Load(sender, e);
        }
        #endregion
        #region Del/Exit
        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvSRInfo.SelectedRows)
            {
                if (!r.IsNewRow)
                {
                    dgvSRInfo.Rows.Remove(r);

                }
            }
        }

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
#endregion

        private void dgvSRInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSRInfo.CurrentCell.ColumnIndex == 1)
            {
                C23.BomManage.frmWareInfo frm = new C23.BomManage.frmWareInfo();
                frm.SellReT();
                frm.ShowDialog();
                setWareData();
            }
            if (dgvSRInfo.CurrentCell.ColumnIndex == 8)
            {
                C23.SellManage .frmSellTable frm = new frmSellTable ();
                frm.SellReT();
                frm.ShowDialog();
                setSellTableData();
            }
            if (dgvSRInfo.CurrentCell.ColumnIndex == 20)
            {
                C23.StorageManage.frmStorageInfo  frm = new C23.StorageManage.frmStorageInfo ();
                frm.SellReT();
                frm.ShowDialog();
                setStorageData();
            }
            if (dgvSRInfo.CurrentCell.ColumnIndex == 21)
            {
                C23.StorageManage.frmLocationInfo  frm = new C23.StorageManage.frmLocationInfo ();
                frm.SellReT();
                frm.ShowDialog();
                setLocationData();
            }
        }
        private void setSellTableData()
        {
            dgvSRInfo[1, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[0];
            dgvSRInfo[2, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[1];
            dgvSRInfo[3, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[2];
            dgvSRInfo[4, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[3];
            dgvSRInfo[5, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[4];
            dgvSRInfo[6, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[5];
            dgvSRInfo[7, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[6];
            dgvSRInfo[8, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[7];
            dgvSRInfo[9, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[8];
            dgvSRInfo[11, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[9];
            dgvSRInfo[12, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[10];
            dgvSRInfo[13, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[11];
            cboxClientID.Text = getSellTableInfo[12];
            txtCName.Text = getSellTableInfo[13];
            cboxSale.Text = getSellTableInfo[14];
           
        }

        private void setStorageData()
        {
            dgvSRInfo.Rows[dgvSRInfo.CurrentCell.RowIndex].Cells[20].Value = getStorageTypeInfo[0];

        }
        private void setLocationData()
        {
            dgvSRInfo.Rows[dgvSRInfo.CurrentCell.RowIndex].Cells[21].Value = getLocationNameInfo[0];
        }
        private void dgvSRInfo_DataSourceChanged(object sender, EventArgs e)
        {
            for (i = 0; i < dgvSRInfo.Columns.Count; i++)
            {
                if (dgvSRInfo.Columns[i].ValueType.ToString() == "System.Decimal")
                {
                    dgvSRInfo.Columns[i].DefaultCellStyle.Format = "N";
                    dgvSRInfo.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;


                }

            }
        }
        private void setWareData()
        {
            dgvSRInfo[1, dgvSRInfo.CurrentCell.RowIndex].Value = inputTextDataWare[0];
            dgvSRInfo[2, dgvSRInfo.CurrentCell.RowIndex].Value = inputTextDataWare[1];
            dgvSRInfo[3, dgvSRInfo.CurrentCell.RowIndex].Value = inputTextDataWare[2];
            dgvSRInfo[4, dgvSRInfo.CurrentCell.RowIndex].Value = inputTextDataWare[3];
        }
        private void dgvSRInfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (i = 0; i < dgvSRInfo.Rows.Count - 1; i++)
            {

                dgvSRInfo[0, i].Value = i + 1;

            }
        }
     
    }
}
