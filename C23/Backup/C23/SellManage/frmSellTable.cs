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
    public partial class frmSellTable : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected string M_str_sql = "select   cast(0   as   bit)   as   复选框, SN as 序号,SellID as 销货单号,WareID as 品号,WareName as 品名,Spec as 规格,"
            +"Unit as 单位,OrdersID as 订单号,OrdersSN as 订单序号,OCount as 订单数量,SellCount as 销货数量,SUnitPrice as 销售单价,DiscountRate as 折扣率,"
            + "TaxRate as 税率,TotalCount as 金额,Tax as 税额,NoTax as 不含税额,TNTotalCount as 合计金额,TNTax as 合计税额,TNNoTax as 合计不含税金额,"
            +"StorageType as 仓库类型,LocationName as 库位名称,ClientID as 客户编号,CName as 客户名称,Sale as 业务员,SellDate as 销货日期,Maker as 制单人,"
            +"Date as 制单日期,Time as 制单时间 from tb_SellTable";
          
        protected string M_str_table = "tb_SellTable";
        protected int i;
        public static string[] getOrdersInfo = new string[] { "","","","","","","","","","","","",""};
        public static string[] inputTextDataWare = new string[] { "", "", "", "" };
        public static string[] getClientInfo = new string[] { "" ,""};
        public static string[] getEmployeeInfo = new string[] { "" };
        public static string[] inputTextDataStorage= new string[] { "","" };
        public frmSellTable()
        {
            InitializeComponent();
            this.cboxClientID.Items.Add("");
            this.cboxSale.Items.Add("");
         }
        #region BindData
        private void BindData()
        {



            dt = boperate.getdt(M_str_sql);
            dgvSeInfo.DataSource = dt;
          

            for (i = 0; i < dgvSeInfo.Columns.Count - 1; i++)
            {
                dgvSeInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                if (i == 3 || i == 10 || i == 11 || i == 12)
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

                if (i == 0 || i == 1)
                {
                    dgvSeInfo.Columns[i].Width = 60;

                }
                if (i!=0 && i != 3 && i != 7 && i != 10 && i != 11 && i !=20  && i !=21 && i !=22 && i !=23)
                {
                    dgvSeInfo.Columns[i].ReadOnly = true;

                }


                if (i == 19)
                {
                    dgvSeInfo.Columns[i].Width = 120;
                }
                if (i == 3 || i == 4 || i == 22 || i == 23)
                {
                    dgvSeInfo.Columns[i].Width = 200;
                }

            }
        }
        #endregion
       
        public void dgvReadOnlySR()
        {
            dgvSeInfo.ReadOnly = true;
        }
      
        #region Client/Sale
        private void cboxClientID_DropDown(object sender, EventArgs e)
        {
            C23.SellManage.frmClientInfo frm = new SellManage.frmClientInfo();
            frm.dgvReadOnlySell();
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
        private void cboxSale_DropDown(object sender, EventArgs e)
        {
            C23.EmployeeManage.frmEmployeeInfo FRM = new C23.EmployeeManage.frmEmployeeInfo();
            FRM.SellTable();
            FRM.ShowDialog();
            AssignmentTextSale();
        }
      
        private void AssignmentTextSale()
        {
            this.cboxSale.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxSale.DroppedDown = false;//使组合框不显示其下拉部分
            cboxSale.Items[0] = getEmployeeInfo[0];
            this.cboxSale.SelectedIndex = 0;
            this.cboxSale.IntegralHeight = true;//恢复默认值    
        }
        #endregion

        private void frmSellTable_Load(object sender, EventArgs e)
        {

            BindData();
            dgvStateControl();
        }

        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            frmSellTableT frm = new frmSellTableT();
            frm.ShowDialog();
            frmSellTable_Load(sender, e);
        }

        private void tsbtbEdit_Click(object sender, EventArgs e)
        {
            #region SellTable

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
                    if (cboxClientID.Text == "")
                    {
                        MessageBox.Show("客户编号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (dt.Rows[i][3].ToString() == "")
                        {
                            MessageBox.Show("品号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (dt.Rows[i][10].ToString() == "")
                            {
                                MessageBox.Show("销货数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                            string varSN = dt.Rows[i][1].ToString();
                                            string varID = txtSellID.Text.Trim();
                                            string varClientID = cboxClientID.Text.Trim();

                                            string varCName = txtCName.Text.Trim();
                                            DateTime varSellDate1 = Convert.ToDateTime(dtpSellDate.Text.Trim());
                                            string varSellDate = varSellDate1.ToShortDateString();
                                            string varWareID = dt.Rows[i][3].ToString();
                                            string varWareName = dt.Rows[i][4].ToString();
                                            string varSpec = dt.Rows[i][5].ToString();
                                            string varUnit = dt.Rows[i][6].ToString();
                                            string varOrdersID = dt.Rows[i][7].ToString();
                                            string varOrdersSN = dt.Rows[i][8].ToString();
                                            string varOCount = dt.Rows[i][9].ToString();

                                            decimal varSellCount = Decimal.Parse(dt.Rows[i][10].ToString());

                                            decimal varSUnitPrice = Decimal.Parse(dt.Rows[i][11].ToString());
                                            decimal varDiscountRate = Decimal.Parse(dt.Rows[i][12].ToString());
                                            decimal varTaxRate = 17;
                                            decimal varTTC = varSellCount * varSUnitPrice;
                                            decimal varT = varTTC * varTaxRate / 100;
                                            decimal varNT = varTTC - varT;
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
                                           
                                       
            #endregion
                                            #region StorageCase
                                            SqlDataReader sqlread = boperate.getread("select StorageCount from tb_StorageCase where WareID='" + varWareID +
                                              "'and StorageType='" + varStorageType + "'and LocationName='" + varLocationName + "'");
                                            SqlDataReader sqlread2 = boperate.getread("select SellCount,RootID,SN from tb_Inventory where RootID='" + varID +
                                             "' AND SN='" + varSN + "'");
                                            sqlread.Read();
                                            sqlread2.Read();
                                            decimal varupdateStorageCount;
                                            if (sqlread.HasRows && sqlread2.HasRows)
                                            {
                                                decimal vargetSellCount = Convert.ToDecimal(sqlread2["SellCount"]);
                                                decimal vargetStorageCount = Convert.ToDecimal(sqlread["StorageCount"]);
                                                if (varSellCount > vargetSellCount)
                                                {
                                                    varupdateStorageCount = vargetStorageCount - (varSellCount - vargetSellCount);
                                                }
                                                else
                                                {
                                                    varupdateStorageCount = vargetStorageCount + (vargetSellCount - varSellCount);
                                                }
                                                if (varupdateStorageCount >= 0)
                                                {

                                                    boperate.getcom("update tb_StorageCase set StorageCount='" + varupdateStorageCount +
                                                    "'where WareID='" + varWareID + "'and StorageType='" + varStorageType +
                                                    "'and LocationName='" + varLocationName + "'");

                                                    boperate.getcom("update tb_SellTable set WareID='" + varWareID + "',WareName='" + varWareName + "',Spec='" + varSpec +
                                                    "',Unit='" + varUnit + "',OrdersID='" + varOrdersID + "',OCount='" + varOCount +
                                                    "',SellCount='" + varSellCount + "',SUnitPrice='" + varSUnitPrice + "',TaxRate='" + varTaxRate +
                                                    "',TotalCount='" + varTTC + "',Tax='" + varT + "',NoTax='" + varNT + "',TNTotalCount='" + var1 + "',TNTax='" + var2 +
                                                    "',TNNoTax='" + var3 + "',LastTNTotalCount='" + var1 + "',LastTNTax='" + var2 + "',LastTNNoTax='" + var3 + "',ClientID='" + varClientID + "',CName='" + varCName +
                                                    "',StorageType='" + varStorageType + "',LocationName='" + varLocationName + "',SellDate='" + varSellDate + "',Sale='" + varSale +
                                                      "',Maker='" + varMaker + "',Date='" + varDate + "',Time='" + varTime + "' where SellID ='" + varID + "' and  SN='" + varSN + "'");
                                                    #region Se
                                                    decimal vargetTNSellCount, varupdateTNSellCount, vargetLastSellCount;
                                                    SqlDataReader sqlreadSe = boperate.getread("select OrdersID,OrdersSN,TNSellCount from tb_TNSe where OrdersID='" + varOrdersID +
                                                        "'and OrdersSN='" + varOrdersSN + "'");
                                                    SqlDataReader sqlreadSe2 = boperate.getread("select SellCount,RootID,SN from tb_Inventory where RootID='" + varID + "' AND SN='" + varSN + "'");
                                                    sqlreadSe.Read();
                                                    sqlreadSe2.Read();
                                                    if (sqlreadSe.HasRows && sqlreadSe2.HasRows)
                                                    {
                                                        vargetTNSellCount = Convert.ToDecimal(sqlreadSe["TNSellCount"]);
                                                        vargetLastSellCount = Convert.ToDecimal(sqlreadSe2["SellCount"]);
                                                        if (varSellCount > vargetLastSellCount)
                                                        {
                                                            varupdateTNSellCount = vargetTNSellCount + (varSellCount - vargetLastSellCount);
                                                        }
                                                        else
                                                        {
                                                            varupdateTNSellCount = vargetTNSellCount - (vargetLastSellCount - varSellCount);
                                                        }

                                                        boperate.getcom("update tb_TNSe set TNSellCount='" + varupdateTNSellCount + "' where OrdersID='" + varOrdersID +
                                                            "' and OrdersSN='" + varOrdersSN + "'");
                                                    #endregion
                                                    #region USCount
                                                        SqlDataReader sqlreadus = boperate.getread("select OrdersID,SN,OCount from tb_Orders where OrdersID='" + varOrdersID +
                                                            "' and SN='" + varOrdersSN + "'");
                                            
                                                        sqlreadus.Read();
                                                        if (sqlreadus.HasRows)
                                                        {
                                                            SqlDataReader sqlreadte = boperate.getread("select TNSRCount from tb_TNSR where OrdersID='" + varOrdersID +
                                                                "'AND OrdersSN='" + varOrdersSN + "'");
                                                            sqlreadte.Read();
                                                            decimal varupdateUSCount,varupdateTNReaSellCount;
                                                            if (sqlreadte.HasRows)
                                                            {
                                                                decimal vargetTNSRCount = Convert.ToDecimal(sqlreadte["TNSRCount"]);
                                                                decimal vargetOCount = Convert.ToDecimal(sqlreadus["OCount"]);
                                                                varupdateUSCount = vargetOCount - varupdateTNSellCount +vargetTNSRCount ;
                                                               varupdateTNReaSellCount = varupdateTNSellCount - vargetTNSRCount;
                                                             
                                                            }
                                                            else
                                                            {
                                                                decimal vargetOCount = Convert.ToDecimal(sqlreadus["OCount"]);
                                                                varupdateUSCount = vargetOCount - varupdateTNSellCount;
                                                                varupdateTNReaSellCount = varupdateTNSellCount;
                                                              
                   
                                                            }
                                                            boperate.getcom("update tb_Orders set USCount='" + varupdateUSCount + "' where OrdersID='" + varOrdersID + "' and SN='" + varOrdersSN + "' ");
                                                            boperate.getcom("update tb_OrdersSta set TNSellCount='" + varupdateTNSellCount + "',USCount='" + varupdateUSCount +
                                                               "',TNReaSellCount='" + varupdateTNReaSellCount + "' where OrdersID='" + varOrdersID + "'  and OrdersSN='" + varOrdersSN + "'");
                                                            sqlreadte.Close();
                                                          
                                                        }
                                                        else
                                                        {


                                                        }
                                                        sqlreadus.Close();

                                                    }
                                                    else
                                                    {


                                                    }
                                                    sqlreadSe.Close();
                                                    sqlreadSe2.Close();

                                                        #endregion
                                                    #region Inventory
                                                    boperate.getcom("update tb_Inventory set WareID='" + varWareID + "',WareName='" + varWareName +
                                                 "',Spec='" + varSpec + "',Unit='" + varUnit + "',SellCount='" + varSellCount +
                                                 "',StorageType='" + varStorageType + "',LocationName='" + varLocationName +
                                                 "',Maker='" + varMaker + "',Date='" + varDate +
                                                 "',Time='" + varTime + "' where RootID='" + varID + "' and SN='" + varSN + "'");

                                                    #endregion

                                                    #region AcReceiv
                                                    SqlDataReader sqlreadupdate = boperate.getread("select TNTotalCount,TNNoTax,TNTax from tb_AcReceiv where ClientID='" + varClientID + "'");
                                                    SqlDataReader sqlreadupdate2 = boperate.getread("select TotalCount,NoTax,Tax,RootID,SN from tb_ReceivPart where RootID='" + varID +
                                                        "'AND SN='" + varSN + "'");
                                                    sqlreadupdate.Read();
                                                    sqlreadupdate2.Read();
                                                    if (sqlreadupdate.HasRows && sqlreadupdate2.HasRows)
                                                    {
                                                        decimal vargetTNTotalCount = Convert.ToDecimal(sqlreadupdate["TNTotalCount"]);
                                                        decimal vargetTNNoTax = Convert.ToDecimal(sqlreadupdate["TNNoTax"]);
                                                        decimal vargetTNTax = Convert.ToDecimal(sqlreadupdate["TNTax"]);
                                                        decimal vargetLastTNTotalCount = Convert.ToDecimal(sqlreadupdate2["TotalCount"]);
                                                        decimal vargetLastTNNoTax = Convert.ToDecimal(sqlreadupdate2["NoTax"]);
                                                        decimal vargetLastTNTax = Convert.ToDecimal(sqlreadupdate2["Tax"]);
                                                        decimal varupdateTNTotalCount, varupdateTNNoTax, varupdateTNTax;

                                                        if (varTTC > vargetLastTNTotalCount)
                                                        {
                                                            varupdateTNTotalCount = vargetTNTotalCount + varTTC - vargetLastTNTotalCount;
                                                            if (varT > vargetLastTNTax)
                                                            {
                                                                varupdateTNTax = vargetTNTax + varT - vargetLastTNTax;
                                                                varupdateTNNoTax = varupdateTNTotalCount - varupdateTNTax;
                                                            }
                                                            else
                                                            {

                                                                varupdateTNTax = vargetTNTax - (vargetLastTNTax - varT);
                                                                varupdateTNNoTax = varupdateTNTotalCount - varupdateTNTax;
                                                            }
                                                            boperate.getcom("update tb_AcReceiv set TNTotalCount='" + varupdateTNTotalCount + "',TNNoTax='" + varupdateTNNoTax +
                                                                "',TNTax='" + varupdateTNTax + "' where ClientID='" + varClientID + "' ");
                                                        }
                                                        else
                                                        {
                                                            varupdateTNTotalCount = vargetTNTotalCount - (vargetLastTNTotalCount - varTTC);
                                                            if (varT > vargetLastTNTax)
                                                            {
                                                                varupdateTNTax = vargetTNTax + varT - vargetLastTNTax;
                                                                varupdateTNNoTax = varupdateTNTotalCount - varupdateTNTax;
                                                            }
                                                            else
                                                            {

                                                                varupdateTNTax = vargetTNTax - (vargetLastTNTax - varT);
                                                                varupdateTNNoTax = varupdateTNTotalCount - varupdateTNTax;
                                                            }



                                                            boperate.getcom("update tb_AcReceiv set TNTotalCount='" + varupdateTNTotalCount + "',TNNoTax='" + varupdateTNNoTax +
                                                                "',TNTax='" + varupdateTNTax + "' where ClientID='" + varClientID + "' ");
                                                        }

                                                    }
                                                    else
                                                    {

                                                    }
                                                    sqlreadupdate.Close();
                                                    sqlreadupdate2.Close();
                                                    #endregion
                                                    #region ReceivPart
                                                    boperate.getcom("update tb_ReceivPart set WareID='" + varWareID + "',WareName='" + varWareName +
                                          "',Spec='" + varSpec + "',Unit='" + varUnit + "',ClientID='" + varClientID + "',CName='" + varCName + "',SellCount='" + varSellCount +
                                          "',SUnitPrice='" + varSUnitPrice + "',TaxRate='" + varTaxRate +
                                          "',DiscountRate='" + varDiscountRate + "',TotalCount='" + varTTC + "',NoTax='" + varNT + "',Tax='" + varT +
                                          "',TNTotalCount='" + var1 + "',TNNoTax='" + var3 + "',TNTax='" + var2 + "',Date='" + varDate + "',Time='" + varTime + "' where RootID='" + varID + "' and SN='" + varSN + "'");
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
                                            sqlread.Close();
                                            sqlread2.Close();
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
            frmSellTable_Load(sender, e);
            tsbtnEdit.Enabled = false;
            tsbtnSave.Enabled = false;
         

        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {

            #region SellTable

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
                    if (cboxClientID.Text == "")
                    {
                        MessageBox.Show("客户编号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (dt.Rows[i][3].ToString() == "")
                        {
                            MessageBox.Show("品号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (dt.Rows[i][10].ToString() == "")
                            {
                                MessageBox.Show("销货数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                            string varSN = dt.Rows[i][1].ToString();
                                            string varID = txtSellID.Text.Trim();
                                            string varClientID = cboxClientID.Text.Trim();

                                            string varCName = txtCName.Text.Trim();
                                            DateTime varSellDate1 = Convert.ToDateTime(dtpSellDate.Text.Trim());
                                            string varSellDate = varSellDate1.ToShortDateString();
                                            string varWareID = dt.Rows[i][3].ToString();
                                            string varWareName = dt.Rows[i][4].ToString();
                                            string varSpec = dt.Rows[i][5].ToString();
                                            string varUnit = dt.Rows[i][6].ToString();
                                            string varOrdersID = dt.Rows[i][7].ToString();
                                            string varOrdersSN = dt.Rows[i][8].ToString();
                                            string varOCount = dt.Rows[i][9].ToString();

                                            decimal varSellCount = Decimal.Parse(dt.Rows[i][10].ToString());

                                            decimal varSUnitPrice = Decimal.Parse(dt.Rows[i][11].ToString());
                                            decimal varDiscountRate = Decimal.Parse(dt.Rows[i][12].ToString());
                                            decimal varTaxRate = 17;
                                            decimal varTTC = varSellCount * varSUnitPrice;
                                            decimal varT = varTTC * varTaxRate / 100;
                                            decimal varNT = varTTC - varT;
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


            #endregion
                                            #region StorageCase
                                            SqlDataReader sqlread = boperate.getread("select StorageCount from tb_StorageCase where WareID='" + varWareID +
                                              "'and StorageType='" + varStorageType + "'and LocationName='" + varLocationName + "'");
                                            SqlDataReader sqlread2 = boperate.getread("select SellCount,RootID,SN from tb_Inventory where RootID='" + varID +
                                             "' AND SN='" + varSN + "'");
                                            sqlread.Read();
                                            sqlread2.Read();
                                            decimal varupdateStorageCount;
                                            if (sqlread.HasRows && sqlread2.HasRows)
                                            {
                                                decimal vargetSellCount = Convert.ToDecimal(sqlread2["SellCount"]);
                                                decimal vargetStorageCount = Convert.ToDecimal(sqlread["StorageCount"]);
                                                if (varSellCount > vargetSellCount)
                                                {
                                                    varupdateStorageCount = vargetStorageCount - (varSellCount - vargetSellCount);
                                                }
                                                else
                                                {
                                                    varupdateStorageCount = vargetStorageCount + (vargetSellCount - varSellCount);
                                                }
                                                if (varupdateStorageCount >= 0)
                                                {

                                                    boperate.getcom("update tb_StorageCase set StorageCount='" + varupdateStorageCount +
                                                    "'where WareID='" + varWareID + "'and StorageType='" + varStorageType +
                                                    "'and LocationName='" + varLocationName + "'");

                                                    boperate.getcom("update tb_SellTable set WareID='" + varWareID + "',WareName='" + varWareName + "',Spec='" + varSpec +
                                                    "',Unit='" + varUnit + "',OrdersID='" + varOrdersID + "',OCount='" + varOCount +
                                                    "',SellCount='" + varSellCount + "',SUnitPrice='" + varSUnitPrice + "',TaxRate='" + varTaxRate +
                                                    "',TotalCount='" + varTTC + "',Tax='" + varT + "',NoTax='" + varNT + "',TNTotalCount='" + var1 + "',TNTax='" + var2 +
                                                    "',TNNoTax='" + var3 + "',LastTNTotalCount='" + var1 + "',LastTNTax='" + var2 + "',LastTNNoTax='" + var3 + "',ClientID='" + varClientID + "',CName='" + varCName +
                                                    "',StorageType='" + varStorageType + "',LocationName='" + varLocationName + "',SellDate='" + varSellDate + "',Sale='" + varSale +
                                                      "',Maker='" + varMaker + "',Date='" + varDate + "',Time='" + varTime + "' where SellID ='" + varID + "' and  SN='" + varSN + "'");
                                                    #region Se
                                                    decimal vargetTNSellCount, varupdateTNSellCount, vargetLastSellCount;
                                                    SqlDataReader sqlreadSe = boperate.getread("select OrdersID,OrdersSN,TNSellCount from tb_TNSe where OrdersID='" + varOrdersID +
                                                        "'and OrdersSN='" + varOrdersSN + "'");
                                                    SqlDataReader sqlreadSe2 = boperate.getread("select SellCount,RootID,SN from tb_Inventory where RootID='" + varID + "' AND SN='" + varSN + "'");
                                                    sqlreadSe.Read();
                                                    sqlreadSe2.Read();
                                                    if (sqlreadSe.HasRows && sqlreadSe2.HasRows)
                                                    {
                                                        vargetTNSellCount = Convert.ToDecimal(sqlreadSe["TNSellCount"]);
                                                        vargetLastSellCount = Convert.ToDecimal(sqlreadSe2["SellCount"]);
                                                        if (varSellCount > vargetLastSellCount)
                                                        {
                                                            varupdateTNSellCount = vargetTNSellCount + (varSellCount - vargetLastSellCount);
                                                        }
                                                        else
                                                        {
                                                            varupdateTNSellCount = vargetTNSellCount - (vargetLastSellCount - varSellCount);
                                                        }

                                                        boperate.getcom("update tb_TNSe set TNSellCount='" + varupdateTNSellCount + "' where OrdersID='" + varOrdersID +
                                                            "' and OrdersSN='" + varOrdersSN + "'");
                                                    #endregion
                                                        #region USCount
                                                        SqlDataReader sqlreadus = boperate.getread("select OrdersID,SN,OCount from tb_Orders where OrdersID='" + varOrdersID +
                                                            "' and SN='" + varOrdersSN + "'");

                                                        sqlreadus.Read();
                                                        if (sqlreadus.HasRows)
                                                        {
                                                            SqlDataReader sqlreadte = boperate.getread("select TNSRCount from tb_TNSR where OrdersID='" + varOrdersID +
                                                                "'AND OrdersSN='" + varOrdersSN + "'");
                                                            sqlreadte.Read();
                                                            decimal varupdateUSCount, varupdateTNReaSellCount;
                                                            if (sqlreadte.HasRows)
                                                            {
                                                                decimal vargetTNSRCount = Convert.ToDecimal(sqlreadte["TNSRCount"]);
                                                                decimal vargetOCount = Convert.ToDecimal(sqlreadus["OCount"]);
                                                                varupdateUSCount = vargetOCount - varupdateTNSellCount + vargetTNSRCount;
                                                                varupdateTNReaSellCount = varupdateTNSellCount - vargetTNSRCount;

                                                            }
                                                            else
                                                            {
                                                                decimal vargetOCount = Convert.ToDecimal(sqlreadus["OCount"]);
                                                                varupdateUSCount = vargetOCount - varupdateTNSellCount;
                                                                varupdateTNReaSellCount = varupdateTNSellCount;


                                                            }
                                                            boperate.getcom("update tb_Orders set USCount='" + varupdateUSCount + "' where OrdersID='" + varOrdersID + "' and SN='" + varOrdersSN + "' ");
                                                            boperate.getcom("update tb_OrdersSta set TNSellCount='" + varupdateTNSellCount + "',USCount='" + varupdateUSCount +
                                                               "',TNReaSellCount='" + varupdateTNReaSellCount + "' where OrdersID='" + varOrdersID + "'  and OrdersSN='" + varOrdersSN + "'");
                                                            sqlreadte.Close();

                                                        }
                                                        else
                                                        {


                                                        }
                                                        sqlreadus.Close();

                                                    }
                                                    else
                                                    {


                                                    }
                                                    sqlreadSe.Close();
                                                    sqlreadSe2.Close();

                                                        #endregion
                                                    #region Inventory
                                                    boperate.getcom("update tb_Inventory set WareID='" + varWareID + "',WareName='" + varWareName +
                                                 "',Spec='" + varSpec + "',Unit='" + varUnit + "',SellCount='" + varSellCount +
                                                 "',StorageType='" + varStorageType + "',LocationName='" + varLocationName +
                                                 "',Maker='" + varMaker + "',Date='" + varDate +
                                                 "',Time='" + varTime + "' where RootID='" + varID + "' and SN='" + varSN + "'");

                                                    #endregion

                                                    #region AcReceiv
                                                    SqlDataReader sqlreadupdate = boperate.getread("select TNTotalCount,TNNoTax,TNTax from tb_AcReceiv where ClientID='" + varClientID + "'");
                                                    SqlDataReader sqlreadupdate2 = boperate.getread("select TotalCount,NoTax,Tax,RootID,SN from tb_ReceivPart where RootID='" + varID +
                                                        "'AND SN='" + varSN + "'");
                                                    sqlreadupdate.Read();
                                                    sqlreadupdate2.Read();
                                                    if (sqlreadupdate.HasRows && sqlreadupdate2.HasRows)
                                                    {
                                                        decimal vargetTNTotalCount = Convert.ToDecimal(sqlreadupdate["TNTotalCount"]);
                                                        decimal vargetTNNoTax = Convert.ToDecimal(sqlreadupdate["TNNoTax"]);
                                                        decimal vargetTNTax = Convert.ToDecimal(sqlreadupdate["TNTax"]);
                                                        decimal vargetLastTNTotalCount = Convert.ToDecimal(sqlreadupdate2["TotalCount"]);
                                                        decimal vargetLastTNNoTax = Convert.ToDecimal(sqlreadupdate2["NoTax"]);
                                                        decimal vargetLastTNTax = Convert.ToDecimal(sqlreadupdate2["Tax"]);
                                                        decimal varupdateTNTotalCount, varupdateTNNoTax, varupdateTNTax;

                                                        if (varTTC > vargetLastTNTotalCount)
                                                        {
                                                            varupdateTNTotalCount = vargetTNTotalCount + varTTC - vargetLastTNTotalCount;
                                                            if (varT > vargetLastTNTax)
                                                            {
                                                                varupdateTNTax = vargetTNTax + varT - vargetLastTNTax;
                                                                varupdateTNNoTax = varupdateTNTotalCount - varupdateTNTax;
                                                            }
                                                            else
                                                            {

                                                                varupdateTNTax = vargetTNTax - (vargetLastTNTax - varT);
                                                                varupdateTNNoTax = varupdateTNTotalCount - varupdateTNTax;
                                                            }
                                                            boperate.getcom("update tb_AcReceiv set TNTotalCount='" + varupdateTNTotalCount + "',TNNoTax='" + varupdateTNNoTax +
                                                                "',TNTax='" + varupdateTNTax + "' where ClientID='" + varClientID + "' ");
                                                        }
                                                        else
                                                        {
                                                            varupdateTNTotalCount = vargetTNTotalCount - (vargetLastTNTotalCount - varTTC);
                                                            if (varT > vargetLastTNTax)
                                                            {
                                                                varupdateTNTax = vargetTNTax + varT - vargetLastTNTax;
                                                                varupdateTNNoTax = varupdateTNTotalCount - varupdateTNTax;
                                                            }
                                                            else
                                                            {

                                                                varupdateTNTax = vargetTNTax - (vargetLastTNTax - varT);
                                                                varupdateTNNoTax = varupdateTNTotalCount - varupdateTNTax;
                                                            }



                                                            boperate.getcom("update tb_AcReceiv set TNTotalCount='" + varupdateTNTotalCount + "',TNNoTax='" + varupdateTNNoTax +
                                                                "',TNTax='" + varupdateTNTax + "' where ClientID='" + varClientID + "' ");
                                                        }

                                                    }
                                                    else
                                                    {

                                                    }
                                                    sqlreadupdate.Close();
                                                    sqlreadupdate2.Close();
                                                    #endregion
                                                    #region ReceivPart
                                                    boperate.getcom("update tb_ReceivPart set WareID='" + varWareID + "',WareName='" + varWareName +
                                          "',Spec='" + varSpec + "',Unit='" + varUnit + "',ClientID='" + varClientID + "',CName='" + varCName + "',SellCount='" + varSellCount +
                                          "',SUnitPrice='" + varSUnitPrice + "',TaxRate='" + varTaxRate +
                                          "',DiscountRate='" + varDiscountRate + "',TotalCount='" + varTTC + "',NoTax='" + varNT + "',Tax='" + varT +
                                          "',TNTotalCount='" + var1 + "',TNNoTax='" + var3 + "',TNTax='" + var2 + "',Date='" + varDate + "',Time='" + varTime + "' where RootID='" + varID + "' and SN='" + varSN + "'");
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
                                            sqlread.Close();
                                            sqlread2.Close();
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
            frmSellTable_Load(sender, e);
            tsbtnEdit.Enabled = false;
            tsbtnSave.Enabled = false;
         
         
        }

        #region Del
        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要删除该条销货单信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    boperate.getcom("delete from tb_SellTable where SellID='" + Convert.ToString(dgvSeInfo[0, dgvSeInfo.CurrentCell.RowIndex].Value).Trim() + "'");
                    frmSellTable_Load(sender, e);
                    MessageBox.Show("删除数据成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Look
        private void tsbtnLook_Click(object sender, EventArgs e)
        {
            tsbtnEdit.Enabled = true;
            tsbtnSave.Enabled = true;
         

            try
            {

                if (tstxtKeyWord.Text == "")
                {
                    tsbtnEdit.Enabled = false;
                    tsbtnSave.Enabled = false;
                
                    frmSellTable_Load(sender, e);
                }
                if (tscboxCondition.Text.Trim() == "按销货单号")
                {
                    dt = boperate.getdt(M_str_sql + " where SellID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvSeInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按编号")
                {
                    dt = boperate.getdt(M_str_sql + " where SN like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvSeInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按订单编号")
                {
                    dt = boperate.getdt(M_str_sql + " where OrdersID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvSeInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按品号")
                {
                    dt = boperate.getdt(M_str_sql + " where WareID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvSeInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按品名")
                {
                    dt = boperate.getdt(M_str_sql + " where WareName like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvSeInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按客户编号")
                {
                    dt = boperate.getdt(M_str_sql + " where ClientID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvSeInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按客户名称")
                {
                    dt = boperate.getdt(M_str_sql + " where CName like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvSeInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按单据日期")
                {
                    dt = boperate.getdt(M_str_sql + " where Date='" + tstxtKeyWord.Text.Trim() + "'");
                    if (dt.Rows.Count > 0)
                        dgvSeInfo.DataSource = dt;
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        private void tsbtbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
 
        private void tsbtnPrint_Click(object sender, EventArgs e)
        {
            C23.ReportManage.frmCRSellTable FRM = new C23.ReportManage.frmCRSellTable();
            FRM.Show();
        }

     

        private void dgvSeInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSeInfo.CurrentCell.ColumnIndex == 7)
            {
                C23.SellManage.frmOrders frm = new C23.SellManage.frmOrders();
                frm.getOrdersdata();
                frm.ShowDialog();
                AssignmentTextOrders();
            }
           
            if (dgvSeInfo.CurrentCell.ColumnIndex == 20)
            {
                C23.StorageManage.frmStorageCase frm = new C23.StorageManage.frmStorageCase ();
                frm.SellTable();
                frm.ShowDialog();
                setStorageData();
            }
            if (dgvSeInfo.CurrentCell.ColumnIndex == 21)
            {
                C23.StorageManage.frmStorageCase frm =new C23.StorageManage.frmStorageCase ();
                frm.SellTable();
                frm.ShowDialog();
                setLocationData();
            }
            txtSellID.Text = Convert.ToString(dgvSeInfo[2, dgvSeInfo.CurrentCell.RowIndex].Value).Trim();
            dtpSellDate.Text = Convert.ToString(dgvSeInfo[25, dgvSeInfo.CurrentCell.RowIndex].Value).Trim();
            cboxClientID.Text = Convert.ToString(dgvSeInfo[22, dgvSeInfo.CurrentCell.RowIndex].Value).Trim();
            txtCName.Text = Convert.ToString(dgvSeInfo[23, dgvSeInfo.CurrentCell.RowIndex].Value).Trim();
            cboxSale.Text = Convert.ToString(dgvSeInfo[24, dgvSeInfo.CurrentCell.RowIndex].Value).Trim();
            txtTotalCount.Text = Convert.ToString(dgvSeInfo[17, dgvSeInfo.CurrentCell.RowIndex].Value).Trim();
            txtNoTax.Text = Convert.ToString(dgvSeInfo[18, dgvSeInfo.CurrentCell.RowIndex].Value).Trim();
            txtTax.Text = Convert.ToString(dgvSeInfo[19, dgvSeInfo.CurrentCell.RowIndex].Value).Trim();

        }
     

        private void setStorageData()
        {
            dgvSeInfo.Rows[dgvSeInfo.CurrentCell.RowIndex].Cells[20].Value = inputTextDataStorage[0];

        }
        private void setLocationData()
        {
            dgvSeInfo.Rows[dgvSeInfo.CurrentCell.RowIndex].Cells[21].Value = inputTextDataStorage[1];
        }
        #region DoubleClick
        private void dgvSeInfo_DoubleClick(object sender, EventArgs e)
        {
           
            if (dgvSeInfo.CurrentCell.ColumnIndex == 2)
            {

                if (dt.Rows.Count > 0)
                {
                    SqlDataReader sqlread = boperate.getread("select VerifyID from tb_Verify where VerifyID='" + dt.Rows[dgvSeInfo.CurrentCell.RowIndex][2].ToString() + "'");
                    sqlread.Read();
                    if (sqlread.HasRows)
                    {
                        MessageBox.Show("该单号已经有相关联的单据被审核，不允许修改");
                    }
                    else
                    {
                        tsbtnEdit.Enabled = true;
                        tsbtnSave.Enabled = true;
                     
                        dt = boperate.getdt(M_str_sql + " where SellID like '%" + dt.Rows[dgvSeInfo.CurrentCell.RowIndex][2].ToString() + "%'");
                        dgvSeInfo.DataSource = dt;


                    }
                    sqlread.Close();
                }
            }
                if (dgvSeInfo.CurrentCell.ColumnIndex == 3)
                {
                    C23.BomManage.frmWareInfo frm = new C23.BomManage.frmWareInfo();
                    frm.SellTable();
                    frm.ShowDialog();
                    setWareData();
                }

        }
        #endregion
        private void AssignmentTextOrders()
        {
            dgvSeInfo[3, dgvSeInfo.CurrentCell.RowIndex].Value = getOrdersInfo[0];
            dgvSeInfo[4, dgvSeInfo.CurrentCell.RowIndex].Value = getOrdersInfo[1];
            dgvSeInfo[5, dgvSeInfo.CurrentCell.RowIndex].Value = getOrdersInfo[2];
            dgvSeInfo[6, dgvSeInfo.CurrentCell.RowIndex].Value = getOrdersInfo[3];
            dgvSeInfo[7, dgvSeInfo.CurrentCell.RowIndex].Value = getOrdersInfo[4];
            dgvSeInfo[8, dgvSeInfo.CurrentCell.RowIndex].Value = getOrdersInfo[5];
            dgvSeInfo[9, dgvSeInfo.CurrentCell.RowIndex].Value = getOrdersInfo[6];
            dgvSeInfo[11, dgvSeInfo.CurrentCell.RowIndex].Value = getOrdersInfo[7];
            dgvSeInfo[12, dgvSeInfo.CurrentCell.RowIndex].Value = getOrdersInfo[8];
            cboxClientID.Text = getOrdersInfo[9];
            txtCName.Text = getOrdersInfo[10];
            cboxSale.Text = getOrdersInfo[11];
        }
        private void setWareData()
        {
            dgvSeInfo[3, dgvSeInfo.CurrentCell.RowIndex].Value = inputTextDataWare[0];
            dgvSeInfo[4, dgvSeInfo.CurrentCell.RowIndex].Value = inputTextDataWare[1];
            dgvSeInfo[5, dgvSeInfo.CurrentCell.RowIndex].Value = inputTextDataWare[2];
            dgvSeInfo[6, dgvSeInfo.CurrentCell.RowIndex].Value = inputTextDataWare[3];
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

        private void dgvSeInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int numCols = dgvSeInfo.Columns.Count;

            for (i = 0; i < numCols; i++)
            {
                if (i == 0)
                {
                    for (i = 0; i < dgvSeInfo.Rows.Count; i++)
                    {
                        if ((bool)dgvSeInfo.Rows[i].Cells[0].EditedFormattedValue == true)
                        {
                            int dex = dgvSeInfo.CurrentCell.RowIndex;
                            string varWareID, varWareName, varSpec, varUnit,varOrdersID,varOrdersSN,varOCount, varSellID, varSellCount, varPUnitPrice,varDiscountRate, varTaxRate, varClientID, varCName, varSale;
                            varWareID = dgvSeInfo[3, i].Value.ToString();
                            varWareName = dgvSeInfo[4, i].Value.ToString();
                            varSpec = dgvSeInfo[5, i].Value.ToString();
                            varUnit = dgvSeInfo[6, i].Value.ToString();
                            varOrdersID = dgvSeInfo.Rows[i].Cells[7].Value.ToString();
                            varOrdersSN = dgvSeInfo.Rows[i].Cells[8].Value.ToString();
                            varOCount = dgvSeInfo.Rows[i].Cells[9].Value.ToString();
                            varSellID = dgvSeInfo[2, i].Value.ToString();
                            varSellCount = dgvSeInfo[10, i].Value.ToString();
                            varPUnitPrice = dgvSeInfo[11, i].Value.ToString();
                            varDiscountRate = dgvSeInfo[12, i].Value.ToString();
                            varTaxRate = dgvSeInfo[13, i].Value.ToString();
                     
                            varClientID = dgvSeInfo.Rows[i].Cells[22].Value.ToString();
                            varCName = dgvSeInfo.Rows[i].Cells[23].Value.ToString();
                            varSale = dgvSeInfo.Rows[i].Cells[24].Value.ToString();
                           
                            string[] arr = new string[] { varWareID, varWareName, varSpec, varUnit,varOrdersID,varOrdersSN,varOCount, varSellID, varSellCount, varPUnitPrice, varDiscountRate, varTaxRate, varClientID, varCName, varSale  };
                            C23.SellManage.frmSellReT.getSellTableInfo[0] = arr[0];
                            C23.SellManage.frmSellReT.getSellTableInfo[1] = arr[1];
                            C23.SellManage.frmSellReT.getSellTableInfo[2] = arr[2];
                            C23.SellManage.frmSellReT.getSellTableInfo[3] = arr[3];
                            C23.SellManage.frmSellReT.getSellTableInfo[4] = arr[4];
                            C23.SellManage.frmSellReT.getSellTableInfo[5] = arr[5];
                            C23.SellManage.frmSellReT.getSellTableInfo[6] = arr[6];
                            C23.SellManage.frmSellReT.getSellTableInfo[7] = arr[7];
                            C23.SellManage.frmSellReT.getSellTableInfo[8] = arr[8];
                            C23.SellManage.frmSellReT.getSellTableInfo[9] = arr[9];
                            C23.SellManage.frmSellReT.getSellTableInfo[10] = arr[10];
                            C23.SellManage.frmSellReT.getSellTableInfo[11] = arr[11];
                            C23.SellManage.frmSellReT.getSellTableInfo[12] = arr[12];
                            C23.SellManage.frmSellReT.getSellTableInfo[13] = arr[13];
                            C23.SellManage.frmSellReT.getSellTableInfo[14] = arr[14];
                          
                            C23.SellManage.frmSellRe.getSellTableInfo[0] = arr[0];
                            C23.SellManage.frmSellRe.getSellTableInfo[1] = arr[1];
                            C23.SellManage.frmSellRe.getSellTableInfo[2] = arr[2];
                            C23.SellManage.frmSellRe.getSellTableInfo[3] = arr[3];
                            C23.SellManage.frmSellRe.getSellTableInfo[4] = arr[4];
                            C23.SellManage.frmSellRe.getSellTableInfo[5] = arr[5];
                            C23.SellManage.frmSellRe.getSellTableInfo[6] = arr[6];
                            C23.SellManage.frmSellRe.getSellTableInfo[7] = arr[7];
                            C23.SellManage.frmSellRe.getSellTableInfo[8] = arr[8];
                            C23.SellManage.frmSellRe.getSellTableInfo[9] = arr[9];
                            C23.SellManage.frmSellRe.getSellTableInfo[10] = arr[10];
                            C23.SellManage.frmSellRe.getSellTableInfo[11] = arr[11];
                            C23.SellManage.frmSellRe.getSellTableInfo[12] = arr[12];
                            C23.SellManage.frmSellRe.getSellTableInfo[13] = arr[13];
                            C23.SellManage.frmSellReT.getSellTableInfo[14] = arr[14];
                     
                            this.Close();
                        }

                    }

                }
            }
        }
        public void SellReT()
        {
            int numCols = dgvSeInfo.Columns.Count;

            for (i = 0; i < numCols; i++)
            {


                if (i != 0)
                {
                    dgvSeInfo.Columns[i].ReadOnly = true;

                }

            }
        }

  
        private void tsbtnRecall_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要撤消单据关联吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (dt.Rows.Count > 0)
                    {
                        boperate.getcom("delete tb_Verify where VerifyID='" + dt.Rows[dgvSeInfo.CurrentCell.RowIndex][7].ToString() + "'");

                        tsbtnEdit.Enabled = false;
                        tsbtnSave.Enabled = false;
                     

                    }
                    frmSellTable_Load(sender, e);
                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void tsbtnVerify_Click(object sender, EventArgs e)
        {
            try
            {

                if (dt.Rows.Count > 0)
                {
                    boperate.getcom("insert into tb_Verify (VerifyID) values ('" + dt.Rows[dgvSeInfo.CurrentCell.RowIndex][7].ToString() + "')");

                    tsbtnEdit.Enabled = false;
                    tsbtnSave.Enabled = false;
              
                }
                frmSellTable_Load(sender, e);
                MessageBox.Show("单据已关联！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }
           
    }
}
