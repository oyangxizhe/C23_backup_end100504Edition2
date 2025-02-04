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
    public partial class frmStockTable : Form
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
      
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected string M_str_sql = " select   cast(0   as   bit)   as   复选框,SN as 序号,StockID as 进货单号,WareID as 品号,WareName as 品名,"
             + "Spec as 规格,Unit as 单位,StockCount as 进货数量,PurOrdersID as 采购单号,PCount as 采购数量,CheckCount as 验收数量,PUnitPrice as 采购单价,"
             + "TaxRate as 税率,TotalCount as 金额,NoTax as 不含税额,Tax as 税额,TNTotalCount as 合计金额,TNTax as 合计税额,TNNoTax as 合计不含税额,StokerID as 供运商编号,"
             + "StokerName as 供运商名称,Pur as 采购员,Acceptor as 验收人,StorageType as 仓库类型,LocationName as 库位名称,StockDate as 进货日期,Maker as 制单人,"
             + "Date as 制单日期, Time as 制单时间 from tb_StockTable";
        protected string M_str_table = "tb_StockTable";
        protected int i;
        public static string[] inputTextDataStoker = new string [] {"",""};
        public static string[] inputTextDataWare= new string[] { "", "","",""};
        public static string[] inputTextDataStorage = new string[] { "" };
        public static string[] inputTextDataLocation = new string[] { "" };
        public static string[] inputDataGridArray = new string[] { null, null,null,null };
        public static string[] strpub = new string[] { null, null, null, null };
        public static string[] inputgetSEName = new string[] { "" };


      
        public frmStockTable()
        {
            InitializeComponent();
            this.cboxStokerID.Items.Add("");
            this.cboxAcceptor.Items.Add("");
            this.cboxPur.Items.Add("");
            
        }
        public void dgvReadOnlyRe()
        {
            dgvStockInfo.ReadOnly = true;

        }
        #region dgvStateControl
        private void dgvStateControl()
        {

            int numCols = dgvStockInfo.Columns.Count;

            for (i = 0; i < numCols; i++)
            {

                dgvStockInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (i == 0 || i==1)
                {
                    dgvStockInfo.Columns[i].Width = 60;

                }
                if (i!=0 && i != 3 && i != 7 && i != 8 && i !=9 && i!=10 && i !=11 && i !=23 && i!=24)
                {
                    dgvStockInfo.Columns[i].ReadOnly = true;

                }


                if (i == 14)
                {
                    dgvStockInfo.Columns[i].Width = 120;
                }
                if (i == 3 || i == 4 || i == 19 || i == 20)
                {
                    dgvStockInfo.Columns[i].Width = 200;
                }

            }
        }
        #endregion
        #region BindData
        private void BindData()
        {
            dt = boperate.getdt(M_str_sql);
            dgvStockInfo.DataSource = dt;
            tsbtnDel.Enabled = false;
            tsbtnRefresh.Enabled = false;

            for (i = 0; i < dgvStockInfo.Columns.Count - 1; i++)
            {
                dgvStockInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable ;
                if (i==3 || i == 10 || i == 11)
                {
                    dgvStockInfo.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                }
            }
        }
        #endregion
        #region DoubleClick
        private void dgvStockInfo_DoubleClick(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                if (dgvStockInfo.CurrentCell.ColumnIndex == 2)
                {


                    SqlDataReader sqlread = boperate.getread("select VerifyID from tb_Verify where VerifyID='" + dt.Rows[dgvStockInfo.CurrentCell.RowIndex][2].ToString() + "'");
                    sqlread.Read();
                    if (sqlread.HasRows)
                    {
                        MessageBox.Show("该单号已经有相关联的单据被审核，不允许修改");
                    }
                    else
                    {
                        tsbtnEdit.Enabled = true;
                        tsbtnSave.Enabled = true;
                        tsbtnRefresh.Enabled = true;
                        tsbtnDel.Enabled = true;
                        dt = boperate.getdt(M_str_sql + " where StockID like '%" + dt.Rows[dgvStockInfo.CurrentCell.RowIndex][2].ToString() + "%'");
                        dgvStockInfo.DataSource = dt;
                    }
                    sqlread.Close();
                }
            }
                
            if (dgvStockInfo.CurrentCell.ColumnIndex == 3)
            {
                C23.BomManage.frmWareInfo frm = new C23.BomManage.frmWareInfo();
                frm.StockTable();
                frm.ShowDialog();
                setWareData();
            }     
        }
         #endregion
        private void setWareData()
        {
            dgvStockInfo[3, dgvStockInfo.CurrentCell.RowIndex].Value = inputTextDataWare[0];
            dgvStockInfo[4, dgvStockInfo.CurrentCell.RowIndex].Value = inputTextDataWare[1];
            dgvStockInfo[5, dgvStockInfo.CurrentCell.RowIndex].Value = inputTextDataWare[2];
            dgvStockInfo[6, dgvStockInfo.CurrentCell.RowIndex].Value = inputTextDataWare[3];
        }
     
        #region CellClick
        private void dgvStockInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStockInfo.CurrentCell.ColumnIndex == 23)
            {
                C23.StorageManage.frmStorageInfo frm = new C23.StorageManage.frmStorageInfo();
                frm.dgvStockTable();
                frm.ShowDialog();
                setStorageData();
            }
            if (dgvStockInfo.CurrentCell.ColumnIndex == 24)
            {
                C23.StorageManage.frmLocationInfo frm = new C23.StorageManage.frmLocationInfo();
                frm.dgvStockTable();
                frm.ShowDialog();
                setLocationData();
            }
            txtStockID.Text = Convert.ToString(dgvStockInfo[2, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            dtpStockDate.Text = Convert.ToString(dgvStockInfo[25, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            cboxStokerID.Text = Convert.ToString(dgvStockInfo[19, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            txtStokerName.Text = Convert.ToString(dgvStockInfo[20, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            cboxPur.Text = Convert.ToString(dgvStockInfo[21, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            cboxAcceptor.Text = Convert.ToString(dgvStockInfo[22, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            txtTotalCount.Text = Convert.ToString(dgvStockInfo[16, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            txtNoTax.Text = Convert.ToString(dgvStockInfo[17, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            txtTax.Text = Convert.ToString(dgvStockInfo[18, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
        }
        private void setStorageData()
        {
            dgvStockInfo.Rows[dgvStockInfo.CurrentCell.RowIndex].Cells[23].Value = inputTextDataStorage[0];

        }
        private void setLocationData()
        {
            dgvStockInfo.Rows[dgvStockInfo.CurrentCell.RowIndex].Cells[24].Value = inputTextDataLocation[0];
        }
        #endregion
        private void dgvStockInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int numCols = dgvStockInfo.Columns.Count;

            for (i = 0; i < numCols; i++)
            {
                if (i == 0)
                {
                    for (i = 0; i < dgvStockInfo.Rows.Count; i++)
                    {
                        if ((bool)dgvStockInfo.Rows[i].Cells[0].EditedFormattedValue == true)
                        {
                            int dex = dgvStockInfo.CurrentCell.RowIndex;
                            string varWareID, varWareName, varSpec, varUnit, varStockID, varSCheckCount, varPUnitPrice,varTaxRate,varStorageType,varLocationName, varStokerID, varStokerName,varPur;
                            varWareID = dgvStockInfo[3, i].Value.ToString();
                            varWareName = dgvStockInfo[4, i].Value.ToString();
                            varSpec = dgvStockInfo[5, i].Value.ToString();
                            varUnit = dgvStockInfo[6, i].Value.ToString();
                            varStockID = dgvStockInfo[2, i].Value.ToString();
                            varSCheckCount = dgvStockInfo[10, i].Value.ToString();
                            varPUnitPrice = dgvStockInfo[11, i].Value.ToString();
                            varTaxRate = dgvStockInfo[12, i].Value.ToString();
                            varStorageType = dgvStockInfo[23, i].Value.ToString();
                            varLocationName = dgvStockInfo[24, i].Value.ToString();
                            varStokerID = dgvStockInfo.Rows[i].Cells[19].Value.ToString();
                            varStokerName = dgvStockInfo.Rows[i ].Cells[20].Value.ToString();
                            varPur = dgvStockInfo.Rows[i].Cells[21].Value.ToString();
                            string[] arr = new string[] { varWareID, varWareName, varSpec, varUnit, varStockID, varSCheckCount, varPUnitPrice,varTaxRate ,varStorageType ,varLocationName , varStokerID, varStokerName,varPur };
                            C23.StockManage.frmReturnT.getStockInfo[0] = arr[0];
                            C23.StockManage.frmReturnT.getStockInfo[1] = arr[1];
                            C23.StockManage.frmReturnT.getStockInfo[2] = arr[2];
                            C23.StockManage.frmReturnT.getStockInfo[3] = arr[3];
                            C23.StockManage.frmReturnT.getStockInfo[4] = arr[4];
                            C23.StockManage.frmReturnT.getStockInfo[5] = arr[5];
                            C23.StockManage.frmReturnT.getStockInfo[6] = arr[6];
                            C23.StockManage.frmReturnT.getStockInfo[7] = arr[7];
                            C23.StockManage.frmReturnT.getStockInfo[8] = arr[8];
                            C23.StockManage.frmReturnT.getStockInfo[9] = arr[9];
                            C23.StockManage.frmReturnT.getStockInfo[10] = arr[10];
                            C23.StockManage.frmReturnT.getStockInfo[11] = arr[11];
                            C23.StockManage.frmReturnT.getStockInfo[12] = arr[12];
                            this.Close();
                        }

                    }

                }
            }
        }
        public void ReturnT()
        {
            int numCols = dgvStockInfo.Columns.Count;

            for (i = 0; i < numCols; i++)
            {


                if (i != 0)
                {
                    dgvStockInfo.Columns[i].ReadOnly = true;

                }

            }
        }
        #region Stoker/Pur/Acceptor
        private void cboxAcceptor_DropDown(object sender, EventArgs e)
        {
            C23.EmployeeManage.frmEmployeeInfo frm = new C23.EmployeeManage.frmEmployeeInfo();
            frm.dgvReadOnlyStock();
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

        private void cboxPur_DropDown(object sender, EventArgs e)
        {
            C23.EmployeeManage.frmEmployeeInfo frm = new C23.EmployeeManage.frmEmployeeInfo();
            frm.dgvReadOnlyStock();
            frm.ShowDialog();
            getEPurData();
        }

        private void  getEPurData()
        {
            this.cboxPur.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxPur.DroppedDown = false;//使组合框不显示其下拉部分
            this.cboxPur.Items[0] = inputgetSEName[0];
            this.cboxPur.SelectedIndex = 0;
            this.cboxPur.IntegralHeight = true;//恢复默认值
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

        private void cboxStokerID_DropDown(object sender, EventArgs e)
        {
         C23.PUR.frmStokerInfo newFrm = new C23.PUR.frmStokerInfo();
            newFrm.setDataGridReadOnly();
            newFrm.ShowDialog();
            setStokerData();
            SendKeys.Send("{Tab}");//向活动应用程序发送Tab键,跳到下一控件
        }
        #endregion

        private void frmStockTable_Load(object sender, EventArgs e)
        {


            BindData();
            dgvStateControl();
        }

        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            frmStockTableT frm = new frmStockTableT();
            frm.ShowDialog ();
            frmStockTable_Load(sender, e);
        }
      
        #region Edit
        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
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
                        if (dt.Rows[i][3].ToString() == "")
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
                                    if (dt.Rows[i][23].ToString() == "")
                                    {
                                        MessageBox.Show("仓库类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        if (dt.Rows[i][24].ToString() == "")
                                        {
                                            MessageBox.Show("库位名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {

                                            string varSN = dt.Rows[i][1].ToString();
                                            string varID = txtStockID.Text;
                                            string varPur = cboxPur.Text.Trim();
                                            string varStokerID = cboxStokerID.Text.Trim();
                                            string varStokerName = txtStokerName.Text.Trim();
                                            DateTime varStockDate = Convert.ToDateTime(dtpStockDate.Text.Trim());
                                            string varMaker = frmLogin.M_str_name;
                                            DateTime varDate = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                                            string varTime = DateTime.Now.ToLongTimeString();
                                            string varWareID = dt.Rows[i][3].ToString();
                                            string varWareName = dt.Rows[i][4].ToString();
                                            string varSpec = dt.Rows[i][5].ToString();
                                            string varUnit = dt.Rows[i][6].ToString();
                                            string varStockCount = dt.Rows[i][7].ToString();
                                            string varPurOrdersID = dt.Rows[i][8].ToString();
                                            string varPCount = dt.Rows[i][9].ToString();
                                            decimal varCheckCount = Decimal.Parse(dt.Rows[i][10].ToString());
                                            decimal varPUnitPrice = Decimal.Parse(dt.Rows[i][11].ToString());
                                            decimal varTaxRate = 17;
                                            string varAcceptor = cboxAcceptor.Text.Trim();
                                            string varStorageType = dt.Rows[i][23].ToString();
                                            string varLocationName = dt.Rows[i][24].ToString();
                                            decimal varTTC = varCheckCount * varPUnitPrice;
                                            decimal varT = varTTC * varTaxRate / 100;
                                            decimal varNT = varTTC - varT;
                                            decimal var1 = (decimal)this.dt.Compute("SUM (金额)", "");
                                            decimal var2 = (decimal)this.dt.Compute("SUM(税额)", "");
                                            decimal var3 = (decimal)this.dt.Compute("SUM(不含税额)", "");
                                            #region StockTable
                                            boperate.getcom("update tb_StockTable set WareID='" + varWareID + "',WareName='" + varWareName + "',Spec='" + varSpec +
                                                "',Unit='" + varUnit + "',StockCount='" + varStockCount + "',PurOrdersID='" + varPurOrdersID + "',PCount='" + varPCount +
                                                "',CheckCount='" + varCheckCount + "',PUnitPrice='" + varPUnitPrice + "',TaxRate='" + varTaxRate +
                                                "',TotalCount='" + varTTC + "',Tax='" + varT + "',NoTax='" + varNT + "',TNTotalCount='" + var1 + "',TNTax='" + var2 +
                                                "',TNNoTax='" + var3 + "',StokerID='" + varStokerID + "',StokerName='" + varStokerName +
                                                "',StorageType='" + varStorageType + "',LocationName='" + varLocationName + "',Acceptor='" + varAcceptor + "',StockDate='" + varStockDate + "',Pur='" + varPur +
                                                "',Maker='" + varMaker + "',Date='" + varDate + "',Time='" + varTime + "' where StockID ='" + varID + "' and  SN='" + varSN + "'");
                                            #endregion
                                            #region Inventory
                                            boperate.getcom("update tb_Inventory set WareID='" + varWareID + "',WareName='" + varWareName +
                                                  "',Spec='" + varSpec + "',Unit='" + varUnit + "',StockCount='" + varCheckCount +
                                                  "',StorageType='" + varStorageType + "',LocationName='" + varLocationName +
                                                  "',Maker='" + varMaker + "',Date='" + varDate +
                                             "',Time='" + varTime + "' where RootID='" + varID + "' and SN='" + varSN + "'");
                                            #endregion
                                            #region StorageCase
                                            SqlDataReader sqlread = boperate.getread("Select WareID,StorageType,LocationName,CheckCount,StorageCount from tb_StorageCase where WareID='" + varWareID +
                                                "' and StorageType='" + varStorageType + "' and LocationName='" + varLocationName + "'");
                                            sqlread.Read();
                                            if (sqlread.HasRows)
                                            {
                                                decimal vargetCheckCount = Convert.ToDecimal(sqlread["CheckCount"]);
                                                decimal vargetStorageCount = Convert.ToDecimal(sqlread["StorageCount"]);

                                                decimal varStorageCount, vara;

                                                if (varCheckCount > vargetCheckCount)
                                                {
                                                    vara = varCheckCount - vargetCheckCount;
                                                    varStorageCount = vargetStorageCount + vara;
                                                }
                                                else
                                                {
                                                    vara = vargetCheckCount - varCheckCount;
                                                    varStorageCount = vargetStorageCount - vara;
                                                }
                                                boperate.getcom("update tb_StorageCase  set CheckCount='" + varCheckCount + "',StorageCount='" + varStorageCount +
                                                     "' where WareID='" + varWareID + "'and StorageType='" + varStorageType + "' and LocationName='" + varLocationName + "'");
                                            }
                                            else
                                            {

                                            }
                                            sqlread.Close();
                                            #endregion
                                            #region PayPart
                                            boperate.getcom("update tb_PayPart set WareID='" + varWareID + "',WareName='" + varWareName +
                                                   "',StokerID='" + varStokerID + "',StokerName='" + varStokerName + "',StockCount='" + varCheckCount +
                                                   "',PUnitPrice='" + varPUnitPrice + "',TaxRate='" + varTaxRate +
                                                   "',TotalCount='" + varTTC + "',NoTax='" + varNT + "',Tax='" + varT + "',TNTotalCount='" + var1 + "',TNTax='" + var2 +
                                                   "',TNNoTax='" + var3 + "',Date='" + varDate + "',Time='" + varTime + "' where RootID='" + varID + "' and SN='" + varSN + "'");


                                            #endregion
                                            #region AcPay
                                            SqlDataReader sqlreadupdate = boperate.getread("select TNTotalCount,TNNoTax,TNTax,LastTNTotalCount,LastTNNoTax,"
                                            + "LastTNTax from tb_AcPay where StokerID='" + varStokerID + "'");
                                            sqlreadupdate.Read();
                                            if (sqlreadupdate.HasRows)
                                            {
                                                decimal vargetTotalCount = Convert.ToDecimal(sqlreadupdate["TNTotalCount"]);
                                                decimal vargetNoTax = Convert.ToDecimal(sqlreadupdate["TNNoTax"]);
                                                decimal vargetTax = Convert.ToDecimal(sqlreadupdate["TNTax"]);
                                                decimal vargetLastTotalCount = Convert.ToDecimal(sqlreadupdate["LastTNTotalCount"]);
                                                decimal vargetLastNoTax = Convert.ToDecimal(sqlreadupdate["LastTNNoTax"]);
                                                decimal vargetLastTax = Convert.ToDecimal(sqlreadupdate["LastTNTax"]);
                                                decimal varupdateTotalCount, varupdateNoTax, varupdateTax;

                                                if (var1 > vargetLastTotalCount)
                                                {
                                                    varupdateTotalCount = vargetTotalCount + var1 - vargetLastTotalCount;
                                                    if (var2 > vargetLastTax)
                                                    {
                                                        varupdateTax = vargetTax + var2 - vargetLastTax;
                                                        varupdateNoTax = varupdateTotalCount - varupdateTax;
                                                    }
                                                    else
                                                    {

                                                        varupdateTax = vargetTax - (vargetLastTax - var2);
                                                        varupdateNoTax = varupdateTotalCount - varupdateTax;
                                                    }


                                                    boperate.getcom("update tb_AcPay set TNTotalCount='" + varupdateTotalCount + "',TNNoTax='" + varupdateNoTax +
                                                        "',TNTax='" + varupdateTax + "',LastTNTotalCount='" + var1 + "',LastTNTax='" + var2 +
                                                        "',LastTNNoTax='" + var3 + "' where StokerID='" + varStokerID + "' ");
                                                }
                                                else
                                                {
                                                    varupdateTotalCount = vargetTotalCount - (vargetLastTotalCount - var1);
                                                    if (var2 > vargetLastTax)
                                                    {
                                                        varupdateTax = vargetTax + var2 - vargetLastTax;
                                                        varupdateNoTax = varupdateTotalCount - varupdateTax;
                                                    }
                                                    else
                                                    {

                                                        varupdateTax = vargetTax - (vargetLastTax - var2);
                                                        varupdateNoTax = varupdateTotalCount - varupdateTax;
                                                    }
                                                    boperate.getcom("update tb_AcPay set TNTotalCount='" + varupdateTotalCount + "',TNNoTax='" + varupdateNoTax +
                                                           "',TNTax='" + varupdateTax + "',LastTNTotalCount='" + var1 + "',LastTNTax='" + var2 +
                                                           "',LastTNNoTax='" + var3 + "' where StokerID='" + varStokerID + "' ");
                                                }

                                            }
                                            else
                                            {

                                            }
                                            sqlreadupdate.Close();
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
            frmStockTable_Load(sender, e);
            tsbtnEdit.Enabled = false;
            tsbtnSave.Enabled = false;
     }
        #endregion
        #region Save
        private void tsbtnSave_Click(object sender, EventArgs e)
        {
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
                        if (dt.Rows[i][3].ToString() == "")
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
                                    if (dt.Rows[i][23].ToString() == "")
                                    {
                                        MessageBox.Show("仓库类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        if (dt.Rows[i][24].ToString() == "")
                                        {
                                            MessageBox.Show("库位名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {

                                            string varSN = dt.Rows[i][1].ToString();
                                            string varID = txtStockID.Text;
                                            string varPur = cboxPur.Text.Trim();
                                            string varStokerID = cboxStokerID.Text.Trim();
                                            string varStokerName = txtStokerName.Text.Trim();
                                            DateTime varStockDate = Convert.ToDateTime(dtpStockDate.Text.Trim());
                                            string varMaker = frmLogin.M_str_name;
                                            DateTime varDate = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                                            string varTime = DateTime.Now.ToLongTimeString();
                                            string varWareID = dt.Rows[i][3].ToString();
                                            string varWareName = dt.Rows[i][4].ToString();
                                            string varSpec = dt.Rows[i][5].ToString();
                                            string varUnit = dt.Rows[i][6].ToString();
                                            string varStockCount = dt.Rows[i][7].ToString();
                                            string varPurOrdersID = dt.Rows[i][8].ToString();
                                            string varPCount = dt.Rows[i][9].ToString();
                                            decimal varCheckCount = Decimal.Parse(dt.Rows[i][10].ToString());
                                            decimal varPUnitPrice = Decimal.Parse(dt.Rows[i][11].ToString());
                                            decimal varTaxRate = 17;
                                            string varAcceptor = cboxAcceptor.Text.Trim();
                                            string varStorageType = dt.Rows[i][23].ToString();
                                            string varLocationName = dt.Rows[i][24].ToString();
                                            decimal varTTC = varCheckCount * varPUnitPrice;
                                            decimal varT = varTTC * varTaxRate / 100;
                                            decimal varNT = varTTC - varT;
                                            decimal var1 = (decimal)this.dt.Compute("SUM (金额)", "");
                                            decimal var2 = (decimal)this.dt.Compute("SUM(税额)", "");
                                            decimal var3 = (decimal)this.dt.Compute("SUM(不含税额)", "");
                                            #region StockTable
                                            boperate.getcom("update tb_StockTable set WareID='" + varWareID + "',WareName='" + varWareName + "',Spec='" + varSpec +
                                                "',Unit='" + varUnit + "',StockCount='" + varStockCount + "',PurOrdersID='" + varPurOrdersID + "',PCount='" + varPCount +
                                                "',CheckCount='" + varCheckCount + "',PUnitPrice='" + varPUnitPrice + "',TaxRate='" + varTaxRate +
                                                "',TotalCount='" + varTTC + "',Tax='" + varT + "',NoTax='" + varNT + "',TNTotalCount='" + var1 + "',TNTax='" + var2 +
                                                "',TNNoTax='" + var3 + "',StokerID='" + varStokerID + "',StokerName='" + varStokerName +
                                                "',StorageType='" + varStorageType + "',LocationName='" + varLocationName + "',Acceptor='" + varAcceptor + "',StockDate='" + varStockDate + "',Pur='" + varPur +
                                                "',Maker='" + varMaker + "',Date='" + varDate + "',Time='" + varTime + "' where StockID ='" + varID + "' and  SN='" + varSN + "'");
                                            #endregion
                                            #region Inventory
                                            boperate.getcom("update tb_Inventory set WareID='" + varWareID + "',WareName='" + varWareName +
                                                  "',Spec='" + varSpec + "',Unit='" + varUnit + "',StockCount='" + varCheckCount +
                                                  "',StorageType='" + varStorageType + "',LocationName='" + varLocationName +
                                                  "',Maker='" + varMaker + "',Date='" + varDate +
                                             "',Time='" + varTime + "' where RootID='" + varID + "' and SN='" + varSN + "'");
                                            #endregion
                                            #region StorageCase
                                            SqlDataReader sqlread = boperate.getread("Select WareID,StorageType,LocationName,CheckCount,StorageCount from tb_StorageCase where WareID='" + varWareID +
                                                "' and StorageType='" + varStorageType + "' and LocationName='" + varLocationName + "'");
                                            sqlread.Read();
                                            if (sqlread.HasRows)
                                            {
                                                decimal vargetCheckCount = Convert.ToDecimal(sqlread["CheckCount"]);
                                                decimal vargetStorageCount = Convert.ToDecimal(sqlread["StorageCount"]);

                                                decimal varStorageCount, vara;

                                                if (varCheckCount > vargetCheckCount)
                                                {
                                                    vara = varCheckCount - vargetCheckCount;
                                                    varStorageCount = vargetStorageCount + vara;
                                                }
                                                else
                                                {
                                                    vara = vargetCheckCount - varCheckCount;
                                                    varStorageCount = vargetStorageCount - vara;
                                                }
                                                boperate.getcom("update tb_StorageCase  set CheckCount='" + varCheckCount + "',StorageCount='" + varStorageCount +
                                                     "' where WareID='" + varWareID + "'and StorageType='" + varStorageType + "' and LocationName='" + varLocationName + "'");
                                            }
                                            else
                                            {

                                            }
                                            sqlread.Close();
                                            #endregion
                                            #region PayPart
                                            boperate.getcom("update tb_PayPart set WareID='" + varWareID + "',WareName='" + varWareName +
                                                   "',StokerID='" + varStokerID + "',StokerName='" + varStokerName + "',StockCount='" + varCheckCount +
                                                   "',PUnitPrice='" + varPUnitPrice + "',TaxRate='" + varTaxRate +
                                                   "',TotalCount='" + varTTC + "',NoTax='" + varNT + "',Tax='" + varT + "',TNTotalCount='" + var1 + "',TNTax='" + var2 +
                                                   "',TNNoTax='" + var3 + "',Date='" + varDate + "',Time='" + varTime + "' where RootID='" + varID + "' and SN='" + varSN + "'");


                                            #endregion
                                            #region AcPay
                                            SqlDataReader sqlreadupdate = boperate.getread("select TNTotalCount,TNNoTax,TNTax,LastTNTotalCount,LastTNNoTax,"
                                            + "LastTNTax from tb_AcPay where StokerID='" + varStokerID + "'");
                                            sqlreadupdate.Read();
                                            if (sqlreadupdate.HasRows)
                                            {
                                                decimal vargetTotalCount = Convert.ToDecimal(sqlreadupdate["TNTotalCount"]);
                                                decimal vargetNoTax = Convert.ToDecimal(sqlreadupdate["TNNoTax"]);
                                                decimal vargetTax = Convert.ToDecimal(sqlreadupdate["TNTax"]);
                                                decimal vargetLastTotalCount = Convert.ToDecimal(sqlreadupdate["LastTNTotalCount"]);
                                                decimal vargetLastNoTax = Convert.ToDecimal(sqlreadupdate["LastTNNoTax"]);
                                                decimal vargetLastTax = Convert.ToDecimal(sqlreadupdate["LastTNTax"]);
                                                decimal varupdateTotalCount, varupdateNoTax, varupdateTax;

                                                if (var1 > vargetLastTotalCount)
                                                {
                                                    varupdateTotalCount = vargetTotalCount + var1 - vargetLastTotalCount;
                                                    if (var2 > vargetLastTax)
                                                    {
                                                        varupdateTax = vargetTax + var2 - vargetLastTax;
                                                        varupdateNoTax = varupdateTotalCount - varupdateTax;
                                                    }
                                                    else
                                                    {

                                                        varupdateTax = vargetTax - (vargetLastTax - var2);
                                                        varupdateNoTax = varupdateTotalCount - varupdateTax;
                                                    }


                                                    boperate.getcom("update tb_AcPay set TNTotalCount='" + varupdateTotalCount + "',TNNoTax='" + varupdateNoTax +
                                                        "',TNTax='" + varupdateTax + "',LastTNTotalCount='" + var1 + "',LastTNTax='" + var2 +
                                                        "',LastTNNoTax='" + var3 + "' where StokerID='" + varStokerID + "' ");
                                                }
                                                else
                                                {
                                                    varupdateTotalCount = vargetTotalCount - (vargetLastTotalCount - var1);
                                                    if (var2 > vargetLastTax)
                                                    {
                                                        varupdateTax = vargetTax + var2 - vargetLastTax;
                                                        varupdateNoTax = varupdateTotalCount - varupdateTax;
                                                    }
                                                    else
                                                    {

                                                        varupdateTax = vargetTax - (vargetLastTax - var2);
                                                        varupdateNoTax = varupdateTotalCount - varupdateTax;
                                                    }
                                                    boperate.getcom("update tb_AcPay set TNTotalCount='" + varupdateTotalCount + "',TNNoTax='" + varupdateNoTax +
                                                           "',TNTax='" + varupdateTax + "',LastTNTotalCount='" + var1 + "',LastTNTax='" + var2 +
                                                           "',LastTNNoTax='" + var3 + "' where StokerID='" + varStokerID + "' ");
                                                }

                                            }
                                            else
                                            {

                                            }
                                            sqlreadupdate.Close();
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
            frmStockTable_Load(sender, e);
     
            tsbtnEdit.Enabled = false;
            tsbtnSave.Enabled = false;



        }
        #endregion 
        #region Del
        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要删除该条品号信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (dt.Rows.Count > 0)
                      {
                boperate.getcom("delete tb_StockTable where StockID='" + dt.Rows[dgvStockInfo.CurrentCell.RowIndex][2].ToString() +
                "' AND SN='" + dt.Rows[dgvStockInfo.CurrentCell.RowIndex][1].ToString() + "'");

                boperate.getcom("delete tb_Inventory where RootID='" + dt.Rows[dgvStockInfo.CurrentCell.RowIndex][2].ToString() +
                "' AND SN='" + dt.Rows[dgvStockInfo.CurrentCell.RowIndex][1].ToString() + "'");

                boperate.getcom("delete tb_PayPart where RootID='" + dt.Rows[dgvStockInfo.CurrentCell.RowIndex][2].ToString() +
                 "' AND SN='" + dt.Rows[dgvStockInfo.CurrentCell.RowIndex][1].ToString() + "'");

                boperate.getcom("delete tb_Verify where VerifyID='" + dt.Rows[dgvStockInfo.CurrentCell.RowIndex][2].ToString() +
             "' AND SN='" + dt.Rows[dgvStockInfo.CurrentCell.RowIndex][1].ToString() + "'");

                tsbtnEdit.Enabled = false;
                tsbtnSave.Enabled = false;
                tsbtnRefresh.Enabled = false;
                tsbtnDel.Enabled = false;
                     }
                    frmStockTable_Load(sender, e);
                    MessageBox.Show("数据已删除！如果该单号还有品号请刷新该单号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    frmStockTable_Load(sender, e);
                }
                if (tscboxCondition.Text.Trim() == "按进货单号")
                {
                    dt = boperate.getdt(M_str_sql + " where StockID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvStockInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按编号")
                {
                    dt = boperate.getdt(M_str_sql + " where SN like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvStockInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按采购单号")
                {
                    dt = boperate.getdt(M_str_sql + " where PurOrdersID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvStockInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按品号")
                {
                    dt = boperate.getdt(M_str_sql + " where WareID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvStockInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按品名")
                {
                    dt = boperate.getdt(M_str_sql + " where WareName like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvStockInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按供运商编号")
                {
                    dt = boperate.getdt(M_str_sql + " where StokerID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvStockInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按供运商名称")
                {
                    dt = boperate.getdt(M_str_sql + " where StokerName like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvStockInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按单据日期")
                {
                    dt = boperate.getdt(M_str_sql + " where Date='" + tstxtKeyWord.Text.Trim() + "'");
                    if (dt.Rows.Count > 0)
                        dgvStockInfo.DataSource = dt;
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
            C23.ReportManage.frmCRStockTable frm = new C23.ReportManage.frmCRStockTable();
            frm.Show();
        }
        #region Refresh
        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
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
                        if (dt.Rows[i][3].ToString() == "")
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
                                    if (dt.Rows[i][23].ToString() == "")
                                    {
                                        MessageBox.Show("仓库类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        if (dt.Rows[i][24].ToString() == "")
                                        {
                                            MessageBox.Show("库位名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {

                                            string varSN = dt.Rows[i][1].ToString();
                                            string varID = txtStockID.Text;
                                            string varPur = cboxPur.Text.Trim();
                                            string varStokerID = cboxStokerID.Text.Trim();
                                            string varStokerName = txtStokerName.Text.Trim();
                                            DateTime varStockDate = Convert.ToDateTime(dtpStockDate.Text.Trim());
                                            string varMaker = frmLogin.M_str_name;
                                            DateTime varDate = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                                            string varTime = DateTime.Now.ToLongTimeString();
                                            string varWareID = dt.Rows[i][3].ToString();
                                            string varWareName = dt.Rows[i][4].ToString();
                                            string varSpec = dt.Rows[i][5].ToString();
                                            string varUnit = dt.Rows[i][6].ToString();
                                            string varStockCount = dt.Rows[i][7].ToString();
                                            string varPurOrdersID = dt.Rows[i][8].ToString();
                                            string varPCount = dt.Rows[i][9].ToString();
                                            decimal varCheckCount = Decimal.Parse(dt.Rows[i][10].ToString());
                                            decimal varPUnitPrice = Decimal.Parse(dt.Rows[i][11].ToString());
                                            decimal varTaxRate = 17;
                                            string varAcceptor = cboxAcceptor.Text.Trim();
                                            string varStorageType = dt.Rows[i][23].ToString();
                                            string varLocationName = dt.Rows[i][24].ToString();
                                            decimal varTTC = varCheckCount * varPUnitPrice;
                                            decimal varT = varTTC * varTaxRate / 100;
                                            decimal varNT = varTTC - varT;
                                            decimal var1 = (decimal)this.dt.Compute("SUM (金额)", "");
                                            decimal var2 = (decimal)this.dt.Compute("SUM(税额)", "");
                                            decimal var3 = (decimal)this.dt.Compute("SUM(不含税额)", "");
                                            #region StockTable
                                            boperate.getcom("update tb_StockTable set WareID='" + varWareID + "',WareName='" + varWareName + "',Spec='" + varSpec +
                                                "',Unit='" + varUnit + "',StockCount='" + varStockCount + "',PurOrdersID='" + varPurOrdersID + "',PCount='" + varPCount +
                                                "',CheckCount='" + varCheckCount + "',PUnitPrice='" + varPUnitPrice + "',TaxRate='" + varTaxRate +
                                                "',TotalCount='" + varTTC + "',Tax='" + varT + "',NoTax='" + varNT + "',TNTotalCount='" + var1 + "',TNTax='" + var2 +
                                                "',TNNoTax='" + var3 + "',StokerID='" + varStokerID + "',StokerName='" + varStokerName +
                                                "',StorageType='" + varStorageType + "',LocationName='" + varLocationName + "',Acceptor='" + varAcceptor + "',StockDate='" + varStockDate + "',Pur='" + varPur +
                                                "',Maker='" + varMaker + "',Date='" + varDate + "',Time='" + varTime + "' where StockID ='" + varID + "' and  SN='" + varSN + "'");
                                            #endregion
                                            #region Inventory
                                            boperate.getcom("update tb_Inventory set WareID='" + varWareID + "',WareName='" + varWareName +
                                                  "',Spec='" + varSpec + "',Unit='" + varUnit + "',StockCount='" + varCheckCount +
                                                  "',StorageType='" + varStorageType + "',LocationName='" + varLocationName +
                                                  "',Maker='" + varMaker + "',Date='" + varDate +
                                             "',Time='" + varTime + "' where RootID='" + varID + "' and SN='" + varSN + "'");
                                            #endregion
                                            #region StorageCase
                                            SqlDataReader sqlread = boperate.getread("Select WareID,StorageType,LocationName,CheckCount,StorageCount from tb_StorageCase where WareID='" + varWareID +
                                                "' and StorageType='" + varStorageType + "' and LocationName='" + varLocationName + "'");
                                            sqlread.Read();
                                            if (sqlread.HasRows)
                                            {
                                                decimal vargetCheckCount = Convert.ToDecimal(sqlread["CheckCount"]);
                                                decimal vargetStorageCount = Convert.ToDecimal(sqlread["StorageCount"]);

                                                decimal varStorageCount, vara;

                                                if (varCheckCount > vargetCheckCount)
                                                {
                                                    vara = varCheckCount - vargetCheckCount;
                                                    varStorageCount = vargetStorageCount + vara;
                                                }
                                                else
                                                {
                                                    vara = vargetCheckCount - varCheckCount;
                                                    varStorageCount = vargetStorageCount - vara;
                                                }
                                                boperate.getcom("update tb_StorageCase  set CheckCount='" + varCheckCount + "',StorageCount='" + varStorageCount +
                                                     "' where WareID='" + varWareID + "'and StorageType='" + varStorageType + "' and LocationName='" + varLocationName + "'");
                                            }
                                            else
                                            {

                                            }
                                            sqlread.Close();
                                            #endregion
                                            #region PayPart
                                            boperate.getcom("update tb_PayPart set WareID='" + varWareID + "',WareName='" + varWareName +
                                                   "',StokerID='" + varStokerID + "',StokerName='" + varStokerName + "',StockCount='" + varCheckCount +
                                                   "',PUnitPrice='" + varPUnitPrice + "',TaxRate='" + varTaxRate +
                                                   "',TotalCount='" + varTTC + "',NoTax='" + varNT + "',Tax='" + varT + "',TNTotalCount='" + var1 + "',TNTax='" + var2 +
                                                   "',TNNoTax='" + var3 + "',Date='" + varDate + "',Time='" + varTime + "' where RootID='" + varID + "' and SN='" + varSN + "'");


                                            #endregion
                                            #region AcPay
                                            SqlDataReader sqlreadupdate = boperate.getread("select TNTotalCount,TNNoTax,TNTax,LastTNTotalCount,LastTNNoTax,"
                                            + "LastTNTax from tb_AcPay where StokerID='" + varStokerID + "'");
                                            sqlreadupdate.Read();
                                            if (sqlreadupdate.HasRows)
                                            {
                                                decimal vargetTotalCount = Convert.ToDecimal(sqlreadupdate["TNTotalCount"]);
                                                decimal vargetNoTax = Convert.ToDecimal(sqlreadupdate["TNNoTax"]);
                                                decimal vargetTax = Convert.ToDecimal(sqlreadupdate["TNTax"]);
                                                decimal vargetLastTotalCount = Convert.ToDecimal(sqlreadupdate["LastTNTotalCount"]);
                                                decimal vargetLastNoTax = Convert.ToDecimal(sqlreadupdate["LastTNNoTax"]);
                                                decimal vargetLastTax = Convert.ToDecimal(sqlreadupdate["LastTNTax"]);
                                                decimal varupdateTotalCount, varupdateNoTax, varupdateTax;

                                                if (var1 > vargetLastTotalCount)
                                                {
                                                    varupdateTotalCount = vargetTotalCount + var1 - vargetLastTotalCount;
                                                    if (var2 > vargetLastTax)
                                                    {
                                                        varupdateTax = vargetTax + var2 - vargetLastTax;
                                                        varupdateNoTax = varupdateTotalCount - varupdateTax;
                                                    }
                                                    else
                                                    {

                                                        varupdateTax = vargetTax - (vargetLastTax - var2);
                                                        varupdateNoTax = varupdateTotalCount - varupdateTax;
                                                    }


                                                    boperate.getcom("update tb_AcPay set TNTotalCount='" + varupdateTotalCount + "',TNNoTax='" + varupdateNoTax +
                                                        "',TNTax='" + varupdateTax + "',LastTNTotalCount='" + var1 + "',LastTNTax='" + var2 +
                                                        "',LastTNNoTax='" + var3 + "' where StokerID='" + varStokerID + "' ");
                                                }
                                                else
                                                {
                                                    varupdateTotalCount = vargetTotalCount - (vargetLastTotalCount - var1);
                                                    if (var2 > vargetLastTax)
                                                    {
                                                        varupdateTax = vargetTax + var2 - vargetLastTax;
                                                        varupdateNoTax = varupdateTotalCount - varupdateTax;
                                                    }
                                                    else
                                                    {

                                                        varupdateTax = vargetTax - (vargetLastTax - var2);
                                                        varupdateNoTax = varupdateTotalCount - varupdateTax;
                                                    }
                                                    boperate.getcom("update tb_AcPay set TNTotalCount='" + varupdateTotalCount + "',TNNoTax='" + varupdateNoTax +
                                                           "',TNTax='" + varupdateTax + "',LastTNTotalCount='" + var1 + "',LastTNTax='" + var2 +
                                                           "',LastTNNoTax='" + var3 + "' where StokerID='" + varStokerID + "' ");
                                                }

                                            }
                                            else
                                            {

                                            }
                                            sqlreadupdate.Close();
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
            frmStockTable_Load(sender, e);
       
            tsbtnEdit.Enabled = false;
            tsbtnSave.Enabled = false;
            tsbtnDel.Enabled = false;
            tsbtnRefresh.Enabled = false;

        }
        #endregion
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

        #region Recall/Verify
        private void tsbtnRecall_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要撤消单据关联吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (dt.Rows.Count > 0)
                    {
                        boperate.getcom("delete tb_Verify where VerifyID='" + dt.Rows[dgvStockInfo.CurrentCell.RowIndex][8].ToString() + "'");

                        tsbtnEdit.Enabled = false;
                        tsbtnSave.Enabled = false;
                        tsbtnRefresh.Enabled = false;
                        tsbtnDel.Enabled = false;
                     
                    }
                    frmStockTable_Load(sender, e);
                    MessageBox.Show("单据关联已撤消！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    boperate.getcom("insert into tb_Verify (VerifyID) values ('" + dt.Rows[dgvStockInfo.CurrentCell.RowIndex][8].ToString() + "')");

                    tsbtnEdit.Enabled = false;
                    tsbtnSave.Enabled = false;
                    tsbtnRefresh.Enabled = false;
                    tsbtnDel.Enabled = false;
                }
                frmStockTable_Load(sender, e);
                MessageBox.Show("单据已关联！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }
        #endregion

      

       

      

    }

}

