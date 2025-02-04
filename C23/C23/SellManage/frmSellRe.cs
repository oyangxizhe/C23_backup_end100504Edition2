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
    public partial class frmSellRe : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected string M_str_sql = "select SN as 序号,SellReID as 销退单号,WareID as 品号,WareName as 品名,Spec as 规格,"
            + "Unit as 单位,OrdersID as 订单号,OrdersSN 订单序号,OCount as 订单数量,SellID as 销货单号,SellCount as 销货数量,SRCount as 销退数量,SUnitPrice as 销售单价,DiscountRate as 折扣率,"
            + "TaxRate as 税率,TotalCount as 金额,Tax as 税额,NoTax as 不含税额,TNTotalCount as 合计金额,TNTax as 合计税额,TNNoTax as 合计不含税金额,"
            + "StorageType as 仓库类型,LocationName as 库位名称,ClientID as 客户编号,CName as 客户名称,Sale as 业务员,SellReDate as 销货日期,Maker as 制单人,"
            + "Date as 制单日期,Time as 制单时间 from tb_SellRe";
        protected string M_str_table = "tb_SellRe";
        protected int i;
        public static string[] getSellTableInfo = new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "","" };
        public static string[] inputTextDataWare = new string[] { "", "", "", "" };
        public static string[] getClientInfo = new string[] { "", "" };
        public static string[] getStorageTypeInfo = new string[] { "" };
        public static string[] getLocationNameInfo = new string[] { "" };
        public static string[] getEmployeeInfo = new string[] { "" };
        public frmSellRe()
        {
            InitializeComponent();
            this.cboxClientID.Items.Add("");
            this.cboxSale.Items.Add("");
       }
        #region BindData
        private void BindData()
        {
            dt = boperate.getdt(M_str_sql);
            dgvSRInfo.DataSource = dt;
       

            for (i = 0; i < dgvSRInfo.Columns.Count - 1; i++)
            {
                dgvSRInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                if (i == 2 || i == 11 || i == 12 || i == 13 || i == 21 || i == 22)
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
                if (i!=1 && i != 2 && i != 9 && i!=11 && i != 12 && i != 13 && i != 21 && i != 22)
                {
                    dgvSRInfo.Columns[i].ReadOnly = true;

                }


                if (i == 20)
                {
                    dgvSRInfo.Columns[i].Width = 120;
                }
                if (i == 2 || i == 3 || i == 23 || i == 24)
                {
                    dgvSRInfo.Columns[i].Width = 200;
                }

            }
        }
        #endregion
        #region CellClick
        private void dgvSellReInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSRInfo.CurrentCell.ColumnIndex == 9)
            {
                C23.SellManage.frmSellTable frm = new frmSellTable();
                frm.SellReT();
                frm.ShowDialog();
                setSellTableData();
            }
            if (dgvSRInfo.CurrentCell.ColumnIndex == 21)
            {
                C23.StorageManage.frmStorageInfo frm = new C23.StorageManage.frmStorageInfo();
                frm.SellRe();
                frm.ShowDialog();
                setStorageData();
            }
            if (dgvSRInfo.CurrentCell.ColumnIndex == 22)
            {
                C23.StorageManage.frmLocationInfo frm = new C23.StorageManage.frmLocationInfo();
                frm.SellRe();
                frm.ShowDialog();
                setLocationData();
            }
            txtSellReID.Text = Convert.ToString(dgvSRInfo[1, dgvSRInfo.CurrentCell.RowIndex].Value).Trim();
            dtpSellReDate.Text = Convert.ToString(dgvSRInfo[26, dgvSRInfo.CurrentCell.RowIndex].Value).Trim();
            cboxClientID.Text = Convert.ToString(dgvSRInfo[23, dgvSRInfo.CurrentCell.RowIndex].Value).Trim();
            txtCName.Text = Convert.ToString(dgvSRInfo[24, dgvSRInfo.CurrentCell.RowIndex].Value).Trim();
            cboxSale.Text = Convert.ToString(dgvSRInfo[25, dgvSRInfo.CurrentCell.RowIndex].Value).Trim();
            txtTotalCount.Text = Convert.ToString(dgvSRInfo[18, dgvSRInfo.CurrentCell.RowIndex].Value).Trim();
            txtNoTax.Text = Convert.ToString(dgvSRInfo[19, dgvSRInfo.CurrentCell.RowIndex].Value).Trim();
            txtTax.Text = Convert.ToString(dgvSRInfo[20, dgvSRInfo.CurrentCell.RowIndex].Value).Trim();
        }
        private void setSellTableData()
        {
            dgvSRInfo[2, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[0];
            dgvSRInfo[3, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[1];
            dgvSRInfo[4, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[2];
            dgvSRInfo[5, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[3];
            dgvSRInfo[6, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[4];
            dgvSRInfo[7, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[5];
            dgvSRInfo[8, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[6];
            dgvSRInfo[9, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[7];
            dgvSRInfo[10, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[8];
            dgvSRInfo[12, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[9];
            dgvSRInfo[13, dgvSRInfo.CurrentCell.RowIndex].Value = getSellTableInfo[10];
            cboxClientID.Text = getSellTableInfo[11];
            txtCName.Text = getSellTableInfo[12];
            cboxSale.Text = getSellTableInfo[13];

        }

        private void setStorageData()
        {
            dgvSRInfo.Rows[dgvSRInfo.CurrentCell.RowIndex].Cells[21].Value = getStorageTypeInfo[0];

        }
        private void setLocationData()
        {
            dgvSRInfo.Rows[dgvSRInfo.CurrentCell.RowIndex].Cells[22].Value = getLocationNameInfo[0];
        }
        #endregion
        #region Client/Sale
        private void cboxClientID_DropDown(object sender, EventArgs e)
        {
            C23.SellManage.frmClientInfo frm = new SellManage.frmClientInfo();
            frm.SellRe();
            frm.ShowDialog();
            ComplexSellReClient();
        }
        private void ComplexSellReClient()
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
            C23.EmployeeManage.frmEmployeeInfo frm = new C23.EmployeeManage.frmEmployeeInfo();
            frm.SellRe();
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
        #endregion
        private void frmSellRe_Load(object sender, EventArgs e)
        {
            BindData();
            dgvStateControl();
        }
     
        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
          frmSellReT frm = new frmSellReT();
            frm.ShowDialog();
            frmSellRe_Load(sender, e);
        }
        #region Edit
        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            #region SellSe

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
                        if (dt.Rows[i][2].ToString() == "")
                        {
                            MessageBox.Show("品号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (dt.Rows[i][11].ToString() == "")
                            {
                                MessageBox.Show("销退数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (dt.Rows[i][12].ToString() == "")
                                {
                                    MessageBox.Show("销售单价不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                else
                                {
                                    if (dt.Rows[i][13].ToString() == "")
                                    {
                                        MessageBox.Show("折扣率不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                    else
                                    {
                                        if (dt.Rows[i][21].ToString() == "")
                                        {
                                            MessageBox.Show("仓库类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            if (dt.Rows[i][22].ToString() == "")
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
                                                string varWareID = dt.Rows[i][2].ToString();
                                                string varWareName = dt.Rows[i][3].ToString();
                                                string varSpec = dt.Rows[i][4].ToString();
                                                string varUnit = dt.Rows[i][5].ToString();
                                                string varOrdersID = dt.Rows[i][6].ToString();
                                                string varOrdersSN = dt.Rows[i][7].ToString();
                                                string varOCount = dt.Rows[i][8].ToString();
                                                string varSellID = dt.Rows[i][9].ToString();
                                                string varSellCount = dt.Rows[i][10].ToString();
                                                decimal varSRCount = Decimal.Parse(dt.Rows[i][11].ToString());
                                                decimal varSUnitPrice = Decimal.Parse(dt.Rows[i][12].ToString());
                                                decimal varDiscountRate = Decimal.Parse(dt.Rows[i][13].ToString());
                                                decimal varTaxRate = 17;
                                                decimal varTTC = varSRCount * varSUnitPrice;
                                                decimal varT = varTTC * varTaxRate / 100;
                                                decimal varNT = varTTC - varT;
                                                decimal var1 = (decimal)this.dt.Compute("SUM (金额)", "");
                                                decimal var2 = (decimal)this.dt.Compute("SUM(税额)", "");
                                                decimal var3 = (decimal)this.dt.Compute("SUM(不含税额)", "");
                                                string varStorageType = dt.Rows[i][21].ToString();
                                                string varLocationName = dt.Rows[i][22].ToString();
                                                string varSale = cboxSale.Text.Trim();
                                                string varMaker = frmLogin.M_str_name;
                                                DateTime varDate1 = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                                                string varDate = varDate1.ToShortDateString();
                                                string varTime = DateTime.Now.ToLongTimeString();

                                                boperate.getcom("update tb_SellRe set WareID='" + varWareID + "',WareName='" + varWareName + "',Spec='" + varSpec +
                                                  "',Unit='" + varUnit + "',OrdersID='" + varOrdersID + "',OrdersSN='" + varOrdersSN + "',OCount='" + varOCount + "',SellID='" + varSellID + "',SellCount='" + varSellCount +
                     "',SRCount='" + varSRCount + "',SUnitPrice='" + varSUnitPrice + "',TaxRate='" + varTaxRate +
                     "',TotalCount='" + varTTC + "',Tax='" + varT + "',NoTax='" + varNT + "',TNTotalCount='" + var1 + "',TNTax='" + var2 +
                     "',TNNoTax='" + var3 + "',LastTNTotalCount='" + var1 + "',LastTNTax='" + var2 + "',LastTNNoTax='" + var3 + "',ClientID='" + varClientID + "',CName='" + varCName +
                     "',StorageType='" + varStorageType + "',LocationName='" + varLocationName + "',SellReDate='" + varSellReDate + "',Sale='" + varSale +
                     "',Maker='" + varMaker + "',Date='" + varDate + "',Time='" + varTime + "' where SellReID ='" + varID + "' and  SN='" + varSN + "'");

            #endregion
                                                #region StorageCase
                                                SqlDataReader sqlread = boperate.getread("select StorageCount from tb_StorageCase where WareID='" + varWareID +
                                                  "'and StorageType='" + varStorageType + "'and LocationName='" + varLocationName + "'");
                                                SqlDataReader sqlread2 = boperate.getread("select SRCount,RootID,SN FROM tb_Inventory where RootID='" + varID + "' AND SN='" + varSN + "'");
                                                sqlread.Read();
                                                sqlread2.Read();
                                                decimal varupdateStorageCount;
                                                if (sqlread.HasRows && sqlread2.HasRows)
                                                {
                                                    decimal vargetSRCount = Convert.ToDecimal(sqlread2["SRCount"]);
                                                    decimal vargetStorageCount = Convert.ToDecimal(sqlread["StorageCount"]);
                                                    if (varSRCount > vargetSRCount)
                                                    {
                                                        varupdateStorageCount = vargetStorageCount + (varSRCount - vargetSRCount);
                                                    }
                                                    else
                                                    {
                                                        varupdateStorageCount = vargetStorageCount - (vargetSRCount - varSRCount);
                                                    }

                                                    boperate.getcom("update tb_StorageCase set StorageCount='" + varupdateStorageCount +
                                                    "'where WareID='" + varWareID + "'and StorageType='" + varStorageType +
                                                    "'and LocationName='" + varLocationName + "'");
                                                }
                                                else
                                                {

                                                }
                                                sqlread.Close();
                                                sqlread2.Close();
                                                #endregion

                                                #region AcReceiv
                                                SqlDataReader sqlreadupdate = boperate.getread("select TNTotalCount,TNNoTax,TNTax from tb_AcReceiv where ClientID='" + varClientID + "'");
                                                SqlDataReader sqlreadupdate2 = boperate.getread("select TotalCount,NoTax,Tax,RootID,SN from tb_ReceivPart where RootID='" + varID + "' AND SN='" + varSN + "'");
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
                                                        varupdateTNTotalCount = vargetTNTotalCount - (varTTC - vargetLastTNTotalCount);
                                                        varupdateTNTax = vargetTNTax - (varT - vargetLastTNTax);
                                                        varupdateTNNoTax = varupdateTNTotalCount - varupdateTNTax;
                                                        boperate.getcom("update tb_AcReceiv set TNTotalCount='" + varupdateTNTotalCount + "',TNNoTax='" + varupdateTNNoTax +
                                                            "',TNTax='" + varupdateTNTax + "' where ClientID='" + varClientID + "' ");
                                                    }
                                                    else
                                                    {
                                                        varupdateTNTotalCount = vargetTNTotalCount + (vargetLastTNTotalCount - varTTC);
                                                        varupdateTNTax = vargetTNTax + (vargetLastTNTax - varT);
                                                        varupdateTNNoTax = varupdateTNTotalCount - varupdateTNTax;
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
                                      "',Spec='" + varSpec + "',Unit='" + varUnit + "',ClientID='" + varClientID + "',CName='" + varCName + "',SRCount='" + varSRCount +
                                      "',SUnitPrice='" + varSUnitPrice + "',TaxRate='" + varTaxRate +
                                      "',DiscountRate='" + varDiscountRate + "',TotalCount='" + varTTC + "',NoTax='" + varNT + "',Tax='" + varT +
                                      "',TNTotalCount='" + var1 + "',TNNoTax='" + var3 + "',TNTax='" + var2 + "',Date='" + varDate + "',Time='" + varTime + "' where RootID='" + varID +
                                      "' and SN='" + varSN + "'");
                                                #endregion
                                                #region SR
                                                decimal vargetTNSRCount, varupdateTNSRCount, vargetTNSellCount, vargetLastSRCount;
                                                SqlDataReader sqlreadSR = boperate.getread("select OrdersID,OrdersSN,TNSRCount from tb_TNSR where OrdersID='" + varOrdersID +
                                                    "'and OrdersSN='" + varOrdersSN + "'");
                                                SqlDataReader sqlreadSR2 = boperate.getread("select SRCount,RootID,SN from tb_Inventory where RootID='" + varID + "' AND SN='" + varSN + "'");
                                                sqlreadSR.Read();
                                                sqlreadSR2.Read();
                                                if (sqlreadSR.HasRows && sqlreadSR2.HasRows)
                                                {
                                                    vargetLastSRCount = Convert.ToDecimal(sqlreadSR2["SRCount"]);
                                                    vargetTNSRCount = Convert.ToDecimal(sqlreadSR["TNSRCount"]);
                                                    if (varSRCount > vargetLastSRCount)
                                                    {
                                                        varupdateTNSRCount = vargetTNSRCount + (varSRCount - vargetLastSRCount);
                                                    }
                                                    else
                                                    {
                                                        varupdateTNSRCount = vargetTNSRCount - (vargetLastSRCount - varSRCount);
                                                    }

                                                    boperate.getcom("update tb_TNSR set TNSRCount='" + varupdateTNSRCount +
                                                        "' where OrdersID='" + varOrdersID + "' and OrdersSN='" + varOrdersSN + "'");
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
                                                             "',TNReaSellCount='" + varupdateTNReaSellCount + "' where OrdersID='" + varOrdersID + "'  and OrdersSN='" + varOrdersSN + "'");
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


                                                }
                                                else
                                                {

                                                }
                                                sqlreadSR.Close();
                                                sqlreadSR2.Close();
                                                #endregion
                                                #region Inventory
                                                boperate.getcom("update tb_Inventory set WareID='" + varWareID + "',WareName='" + varWareName +
                                             "',Spec='" + varSpec + "',Unit='" + varUnit + "',SRCount='" + varSRCount +
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
            }

            dt.Clear();
            frmSellRe_Load(sender, e);
            tsbtnEdit.Enabled = false;
            tsbtnSave.Enabled = false;



        }
        #endregion
        #region Save
        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            #region SellSe

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
                        if (dt.Rows[i][2].ToString() == "")
                        {
                            MessageBox.Show("品号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (dt.Rows[i][11].ToString() == "")
                            {
                                MessageBox.Show("销退数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (dt.Rows[i][12].ToString() == "")
                                {
                                    MessageBox.Show("销售单价不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                else
                                {
                                    if (dt.Rows[i][13].ToString() == "")
                                    {
                                        MessageBox.Show("折扣率不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                    else
                                    {
                                        if (dt.Rows[i][21].ToString() == "")
                                        {
                                            MessageBox.Show("仓库类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            if (dt.Rows[i][22].ToString() == "")
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
                                                string varWareID = dt.Rows[i][2].ToString();
                                                string varWareName = dt.Rows[i][3].ToString();
                                                string varSpec = dt.Rows[i][4].ToString();
                                                string varUnit = dt.Rows[i][5].ToString();
                                                string varOrdersID = dt.Rows[i][6].ToString();
                                                string varOrdersSN = dt.Rows[i][7].ToString();
                                                string varOCount = dt.Rows[i][8].ToString();
                                                string varSellID = dt.Rows[i][9].ToString();
                                                string varSellCount = dt.Rows[i][10].ToString();
                                                decimal varSRCount = Decimal.Parse(dt.Rows[i][11].ToString());
                                                decimal varSUnitPrice = Decimal.Parse(dt.Rows[i][12].ToString());
                                                decimal varDiscountRate = Decimal.Parse(dt.Rows[i][13].ToString());
                                                decimal varTaxRate = 17;
                                                decimal varTTC = varSRCount * varSUnitPrice;
                                                decimal varT = varTTC * varTaxRate / 100;
                                                decimal varNT = varTTC - varT;
                                                decimal var1 = (decimal)this.dt.Compute("SUM (金额)", "");
                                                decimal var2 = (decimal)this.dt.Compute("SUM(税额)", "");
                                                decimal var3 = (decimal)this.dt.Compute("SUM(不含税额)", "");
                                                string varStorageType = dt.Rows[i][21].ToString();
                                                string varLocationName = dt.Rows[i][22].ToString();
                                                string varSale = cboxSale.Text.Trim();
                                                string varMaker = frmLogin.M_str_name;
                                                DateTime varDate1 = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                                                string varDate = varDate1.ToShortDateString();
                                                string varTime = DateTime.Now.ToLongTimeString();

                                                boperate.getcom("update tb_SellRe set WareID='" + varWareID + "',WareName='" + varWareName + "',Spec='" + varSpec +
                                                  "',Unit='" + varUnit + "',OrdersID='" + varOrdersID + "',OrdersSN='" + varOrdersSN + "',OCount='" + varOCount + "',SellID='" + varSellID + "',SellCount='" + varSellCount +
                     "',SRCount='" + varSRCount + "',SUnitPrice='" + varSUnitPrice + "',TaxRate='" + varTaxRate +
                     "',TotalCount='" + varTTC + "',Tax='" + varT + "',NoTax='" + varNT + "',TNTotalCount='" + var1 + "',TNTax='" + var2 +
                     "',TNNoTax='" + var3 + "',LastTNTotalCount='" + var1 + "',LastTNTax='" + var2 + "',LastTNNoTax='" + var3 + "',ClientID='" + varClientID + "',CName='" + varCName +
                     "',StorageType='" + varStorageType + "',LocationName='" + varLocationName + "',SellReDate='" + varSellReDate + "',Sale='" + varSale +
                     "',Maker='" + varMaker + "',Date='" + varDate + "',Time='" + varTime + "' where SellReID ='" + varID + "' and  SN='" + varSN + "'");

            #endregion
                                                #region StorageCase
                                                SqlDataReader sqlread = boperate.getread("select StorageCount from tb_StorageCase where WareID='" + varWareID +
                                                  "'and StorageType='" + varStorageType + "'and LocationName='" + varLocationName + "'");
                                                SqlDataReader sqlread2 = boperate.getread("select SRCount,RootID,SN FROM tb_Inventory where RootID='" + varID + "' AND SN='" + varSN + "'");
                                                sqlread.Read();
                                                sqlread2.Read();
                                                decimal varupdateStorageCount;
                                                if (sqlread.HasRows && sqlread2.HasRows)
                                                {
                                                    decimal vargetSRCount = Convert.ToDecimal(sqlread2["SRCount"]);
                                                    decimal vargetStorageCount = Convert.ToDecimal(sqlread["StorageCount"]);
                                                    if (varSRCount > vargetSRCount)
                                                    {
                                                        varupdateStorageCount = vargetStorageCount + (varSRCount - vargetSRCount);
                                                    }
                                                    else
                                                    {
                                                        varupdateStorageCount = vargetStorageCount - (vargetSRCount - varSRCount);
                                                    }

                                                    boperate.getcom("update tb_StorageCase set StorageCount='" + varupdateStorageCount +
                                                    "'where WareID='" + varWareID + "'and StorageType='" + varStorageType +
                                                    "'and LocationName='" + varLocationName + "'");
                                                }
                                                else
                                                {

                                                }
                                                sqlread.Close();
                                                sqlread2.Close();
                                                #endregion

                                                #region AcReceiv
                                                SqlDataReader sqlreadupdate = boperate.getread("select TNTotalCount,TNNoTax,TNTax from tb_AcReceiv where ClientID='" + varClientID + "'");
                                                SqlDataReader sqlreadupdate2 = boperate.getread("select TotalCount,NoTax,Tax,RootID,SN from tb_ReceivPart where RootID='" + varID + "' AND SN='" + varSN + "'");
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
                                                        varupdateTNTotalCount = vargetTNTotalCount - (varTTC - vargetLastTNTotalCount);
                                                        varupdateTNTax = vargetTNTax - (varT - vargetLastTNTax);
                                                        varupdateTNNoTax = varupdateTNTotalCount - varupdateTNTax;
                                                        boperate.getcom("update tb_AcReceiv set TNTotalCount='" + varupdateTNTotalCount + "',TNNoTax='" + varupdateTNNoTax +
                                                            "',TNTax='" + varupdateTNTax + "' where ClientID='" + varClientID + "' ");
                                                    }
                                                    else
                                                    {
                                                        varupdateTNTotalCount = vargetTNTotalCount + (vargetLastTNTotalCount - varTTC);
                                                        varupdateTNTax = vargetTNTax + (vargetLastTNTax - varT);
                                                        varupdateTNNoTax = varupdateTNTotalCount - varupdateTNTax;
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
                                      "',Spec='" + varSpec + "',Unit='" + varUnit + "',ClientID='" + varClientID + "',CName='" + varCName + "',SRCount='" + varSRCount +
                                      "',SUnitPrice='" + varSUnitPrice + "',TaxRate='" + varTaxRate +
                                      "',DiscountRate='" + varDiscountRate + "',TotalCount='" + varTTC + "',NoTax='" + varNT + "',Tax='" + varT +
                                      "',TNTotalCount='" + var1 + "',TNNoTax='" + var3 + "',TNTax='" + var2 + "',Date='" + varDate + "',Time='" + varTime + "' where RootID='" + varID +
                                      "' and SN='" + varSN + "'");
                                                #endregion
                                                #region SR
                                                decimal vargetTNSRCount, varupdateTNSRCount, vargetTNSellCount, vargetLastSRCount;
                                                SqlDataReader sqlreadSR = boperate.getread("select OrdersID,OrdersSN,TNSRCount from tb_TNSR where OrdersID='" + varOrdersID +
                                                    "'and OrdersSN='" + varOrdersSN + "'");
                                                SqlDataReader sqlreadSR2 = boperate.getread("select SRCount,RootID,SN from tb_Inventory where RootID='" + varID + "' AND SN='" + varSN + "'");
                                                sqlreadSR.Read();
                                                sqlreadSR2.Read();
                                                if (sqlreadSR.HasRows && sqlreadSR2.HasRows)
                                                {
                                                    vargetLastSRCount = Convert.ToDecimal(sqlreadSR2["SRCount"]);
                                                    vargetTNSRCount = Convert.ToDecimal(sqlreadSR["TNSRCount"]);
                                                    if (varSRCount > vargetLastSRCount)
                                                    {
                                                        varupdateTNSRCount = vargetTNSRCount + (varSRCount - vargetLastSRCount);
                                                    }
                                                    else
                                                    {
                                                        varupdateTNSRCount = vargetTNSRCount - (vargetLastSRCount - varSRCount);
                                                    }

                                                    boperate.getcom("update tb_TNSR set TNSRCount='" + varupdateTNSRCount +
                                                        "' where OrdersID='" + varOrdersID + "' and OrdersSN='" + varOrdersSN + "'");
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
                                                             "',TNReaSellCount='" + varupdateTNReaSellCount + "' where OrdersID='" + varOrdersID + "'  and OrdersSN='" + varOrdersSN + "'");
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


                                                }
                                                else
                                                {

                                                }
                                                sqlreadSR.Close();
                                                sqlreadSR2.Close();
                                                #endregion
                                                #region Inventory
                                                boperate.getcom("update tb_Inventory set WareID='" + varWareID + "',WareName='" + varWareName +
                                             "',Spec='" + varSpec + "',Unit='" + varUnit + "',SRCount='" + varSRCount +
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
            }

            dt.Clear();
            frmSellRe_Load(sender, e);
            tsbtnEdit.Enabled = false;
            tsbtnSave.Enabled = false;

        }
        #endregion
        #region Del
        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要删除该条销货单信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    boperate.getcom("delete from tb_SellRe where SellReID='" + Convert.ToString(dgvSRInfo[0, dgvSRInfo.CurrentCell.RowIndex].Value).Trim() + "'");
                    frmSellRe_Load(sender, e);
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
                    
                    frmSellRe_Load(sender, e);
                }
                if (tscboxCondition.Text.Trim() == "按销退单号")
                {
                    dt = boperate.getdt(M_str_sql + " where SellReID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvSRInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按编号")
                {
                    dt = boperate.getdt(M_str_sql + " where SN like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvSRInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按销货单号")
                {
                    dt = boperate.getdt(M_str_sql + " where SellID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvSRInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按品号")
                {
                    dt = boperate.getdt(M_str_sql + " where WareID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvSRInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按品名")
                {
                    dt = boperate.getdt(M_str_sql + " where WareName like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvSRInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按客户编号")
                {
                    dt = boperate.getdt(M_str_sql + " where ClientID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvSRInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按客户名称")
                {
                    dt = boperate.getdt(M_str_sql + " where CName like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvSRInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按单据日期")
                {
                    dt = boperate.getdt(M_str_sql + " where Date='" + tstxtKeyWord.Text.Trim() + "'");
                    if (dt.Rows.Count > 0)
                        dgvSRInfo.DataSource = dt;
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ClearText()
        {
           

        }

        private void tsbtnPrint_Click(object sender, EventArgs e)
        {
            C23.ReportManage.frmCRSellRe frm = new C23.ReportManage.frmCRSellRe();
            frm.Show();
        }
        #region DoubleClick
        private void dgvSRInfo_DoubleClick(object sender, EventArgs e)
        {
            if (dgvSRInfo.CurrentCell.ColumnIndex == 1)
            {

                if (dt.Rows.Count > 0)
                {
                    SqlDataReader sqlread = boperate.getread("select VerifyID from tb_Verify where VerifyID='" + dt.Rows[dgvSRInfo.CurrentCell.RowIndex][1].ToString() + "'");
                    sqlread.Read();
                    if (sqlread.HasRows)
                    {
                        MessageBox.Show("些单号已锁定");
                    }
                    else
                    {
                        tsbtnEdit.Enabled = true;
                        tsbtnSave.Enabled = true;
                    
                        dt = boperate.getdt(M_str_sql + " where SellReID like '%" + dt.Rows[dgvSRInfo.CurrentCell.RowIndex][1].ToString() + "%'");
                        dgvSRInfo.DataSource = dt;


                    }
                    sqlread.Close();
                }
            }
            if (dgvSRInfo.CurrentCell.ColumnIndex == 2)
            {
                C23.BomManage.frmWareInfo frm = new C23.BomManage.frmWareInfo();
                frm.SellRe();
                frm.ShowDialog();
                setWareData();
            }
           
        }
        #endregion
        private void setWareData()
        {
            dgvSRInfo[2, dgvSRInfo.CurrentCell.RowIndex].Value = inputTextDataWare[0];
            dgvSRInfo[3, dgvSRInfo.CurrentCell.RowIndex].Value = inputTextDataWare[1];
            dgvSRInfo[4, dgvSRInfo.CurrentCell.RowIndex].Value = inputTextDataWare[2];
            dgvSRInfo[5, dgvSRInfo.CurrentCell.RowIndex].Value = inputTextDataWare[3];
        }
        #region RowsAdded/DataSourceChanged
      
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
        #endregion
        private void tsbtnRecall_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要撤消单据关联吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (dt.Rows.Count > 0)
                    {
                        boperate.getcom("delete tb_Verify where VerifyID='" + dt.Rows[dgvSRInfo.CurrentCell.RowIndex][9].ToString() + "'");

                        tsbtnEdit.Enabled = false;
                        tsbtnSave.Enabled = false;
                      

                    }
                    frmSellRe_Load(sender, e);
                   
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
                    boperate.getcom("insert into tb_Verify (VerifyID) values ('" + dt.Rows[dgvSRInfo.CurrentCell.RowIndex][9].ToString() + "')");

                    tsbtnEdit.Enabled = false;
                    tsbtnSave.Enabled = false;
                  
                }
                frmSellRe_Load(sender, e);
                MessageBox.Show("单据已关联！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void tsbtnRLock_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要撤消单据锁定吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (dt.Rows.Count > 0)
                    {
                        boperate.getcom("delete tb_Verify where VerifyID='" + dt.Rows[dgvSRInfo.CurrentCell.RowIndex][1].ToString() + "'");

                        tsbtnEdit.Enabled = false;
                        tsbtnSave.Enabled = false;
                      

                    }
                    frmSellRe_Load(sender, e);
                 
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
                    boperate.getcom("insert into tb_Verify (VerifyID) values ('" + dt.Rows[dgvSRInfo.CurrentCell.RowIndex][1].ToString() + "')");

                    tsbtnEdit.Enabled = false;
                    tsbtnSave.Enabled = false;
                 
                }
                frmSellRe_Load(sender, e);
                MessageBox.Show("单据已锁定！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }
   
    }
}
