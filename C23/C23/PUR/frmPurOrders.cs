using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace C23.PUR
{
    public partial class frmPurOrders : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected string M_str_sql = "  select   cast(0   as   bit)   as   复选框, SN as 序号,PurOrdersID as 采购单号,WareID as 品号,WareName as 品名,Spec as 规格,Unit as 单位,"
            + "PCount as 采购数量,PUnitPrice as 采购单价,USCount as 采购单未结数量,TaxRate as 税率,TotalCount as 金额,NoTax as 不含税额,Tax as 税额,TNTotalCount as 合计金额,"
            +"TNTax as 合计税额,TNNoTax as 合计不含税金额,StokerID as 供运商编号,StokerName as 供运商名称,PDate as 采购日期,Pur as 采购员,"
            + "Maker as 制单人,Date as 制单日期, Time as 制单时间 from tb_PurOrders";
        protected string M_str_table = "tb_PurOrders";
        protected int i;
        public static string[] inputTextDataStoker = new string[] { "", "" };
        public static string[] inputTextDataWare = new string[] { "", "", "", "" };
        public static string[] getEmployeeInfo= new string[] { "" };

        public frmPurOrders()
        {
            InitializeComponent();
            this.cboxStokerID.Items.Add("");
         
            this.cboxPur.Items.Add("");
        }
        private void dgvPurOrdersInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tsbtnSave.Enabled != true)
            {
                txtPurOrdersID.Text = dgvPurOrdersInfo[2, dgvPurOrdersInfo.CurrentCell.RowIndex].Value.ToString();
                txtTotalCount.Text = dgvPurOrdersInfo[14, dgvPurOrdersInfo.CurrentCell.RowIndex].Value.ToString();
                txtTax.Text = dgvPurOrdersInfo[15, dgvPurOrdersInfo.CurrentCell.RowIndex].Value.ToString();
                txtNoTax.Text = dgvPurOrdersInfo[16, dgvPurOrdersInfo.CurrentCell.RowIndex].Value.ToString();
                cboxStokerID.Text = dgvPurOrdersInfo[17, dgvPurOrdersInfo.CurrentCell.RowIndex].Value.ToString();
                txtStokerName.Text = dgvPurOrdersInfo[18, dgvPurOrdersInfo.CurrentCell.RowIndex].Value.ToString();
                dtpPDate.Text = dgvPurOrdersInfo[19, dgvPurOrdersInfo.CurrentCell.RowIndex].Value.ToString();
                cboxPur.Text = dgvPurOrdersInfo[20, dgvPurOrdersInfo.CurrentCell.RowIndex].Value.ToString();
            }
          
        }
        private void dgvPurOrdersInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPurOrdersInfo.CurrentCell.ColumnIndex == 0)
            {
                int i = dgvPurOrdersInfo.CurrentCell.RowIndex;
                string varWareID, varWareName, varSpec, varUnit, varPurOrders, varSN, varPCount, varUSCount, varPUnitPrice, varStokerID, varStokerName, varPur;

                varWareID = dgvPurOrdersInfo[3, i].Value.ToString();
                varWareName = dgvPurOrdersInfo[4, i].Value.ToString();
                varSpec = dgvPurOrdersInfo[5, i].Value.ToString();
                varUnit = dgvPurOrdersInfo[6, i].Value.ToString();
                varPurOrders = dgvPurOrdersInfo[2, i].Value.ToString();
                varSN = dgvPurOrdersInfo[1, i].Value.ToString();
                varPCount = dgvPurOrdersInfo[7, i].Value.ToString();
                varPUnitPrice = dgvPurOrdersInfo[8, i].Value.ToString();
                varUSCount = dgvPurOrdersInfo[9, i].Value.ToString();
                varStokerID = dgvPurOrdersInfo.Rows[i].Cells[17].Value.ToString();
                varStokerName = dgvPurOrdersInfo.Rows[i].Cells[18].Value.ToString();
                varPur = dgvPurOrdersInfo.Rows[i].Cells[20].Value.ToString();

                string[] arr = new string[] { varWareID, varWareName, varSpec, varUnit, varPurOrders, varPCount, varPUnitPrice, varStokerID, varStokerName, varPur, varSN, varUSCount };

                C23.StockManage.frmStockTableT.getPurInfo[0] = arr[0];
                C23.StockManage.frmStockTableT.getPurInfo[1] = arr[1];
                C23.StockManage.frmStockTableT.getPurInfo[2] = arr[2];
                C23.StockManage.frmStockTableT.getPurInfo[3] = arr[3];
                C23.StockManage.frmStockTableT.getPurInfo[4] = arr[4];
                C23.StockManage.frmStockTableT.getPurInfo[5] = arr[5];
                C23.StockManage.frmStockTableT.getPurInfo[6] = arr[6];
                C23.StockManage.frmStockTableT.getPurInfo[7] = arr[7];
                C23.StockManage.frmStockTableT.getPurInfo[8] = arr[8];
                C23.StockManage.frmStockTableT.getPurInfo[9] = arr[9];
                C23.StockManage.frmStockTableT.getPurInfo[10] = arr[10];
                C23.StockManage.frmStockTableT.getPurInfo[11] = arr[11];
                this.Close();
            }
        }
        public void dgvReadOnlyPur()
        {
            this.dgvPurOrdersInfo.ReadOnly = true;

        }
      
        private void setWareData()
        {
            dgvPurOrdersInfo[3, dgvPurOrdersInfo.CurrentCell.RowIndex].Value = inputTextDataWare[0];
            dgvPurOrdersInfo[4, dgvPurOrdersInfo.CurrentCell.RowIndex].Value = inputTextDataWare[1];
            dgvPurOrdersInfo[5, dgvPurOrdersInfo.CurrentCell.RowIndex].Value = inputTextDataWare[2];
            dgvPurOrdersInfo[6, dgvPurOrdersInfo.CurrentCell.RowIndex].Value = inputTextDataWare[3];
        }
        private void cboxPur_DropDown(object sender, EventArgs e)
        {
            C23.EmployeeManage.frmEmployeeInfo frm = new C23.EmployeeManage.frmEmployeeInfo();
            frm.dgvReadOnlyPur();
            frm.ShowDialog();
            getPur();
        }
        private void getPur()
        {
            this.cboxPur.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxPur.DroppedDown = false;//使组合框不显示其下拉部分
            cboxPur.Items[0] = getEmployeeInfo[0];

            this.cboxPur.SelectedIndex = 0;

            this.cboxPur.IntegralHeight = true;//恢复默认值
        }

      
      
        private void cboxPStokerID_DropDown(object sender, EventArgs e)
        {
            C23.PUR.frmStokerInfo newFrm = new C23.PUR.frmStokerInfo();
            newFrm.dgvReadOnlyPur();
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

        private void frmPurOrders_Load(object sender, EventArgs e)
        {
           

            BindData();
            dgvStateControl();
        }

        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            C23.PUR.frmPurOrdersT frm = new frmPurOrdersT();
            frm.ShowDialog ();
            frmPurOrders_Load(sender, e);
        }

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            bn.Validate();
            string year, month;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            for (int i = 0; i < dt.Rows.Count; i++)
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
                            if (dt.Rows[i][7].ToString() == "")
                            {
                                MessageBox.Show("采购数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (dt.Rows[i][8].ToString() == "")
                                {
                                    MessageBox.Show("采购单价不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                else
                                {
                                    string varSN= dt.Rows[i][1].ToString();
                                    string varID = dt.Rows[i][2].ToString();
                                    string varPur = cboxPur.Text.Trim();
                                    string varStokerID = cboxStokerID.Text.Trim();
                                    string varStokerName = txtStokerName.Text.Trim();
                                    DateTime varPDate1 = Convert.ToDateTime (dtpPDate.Text.Trim());
                                    string varPDate = varPDate1.ToShortDateString();
                                    string varMaker = frmLogin.M_str_name;
                                    DateTime varDate1= Convert.ToDateTime(DateTime.Now.ToLongDateString());
                                    string varDate = varDate1.ToShortDateString();
                                    string varTime = DateTime.Now.ToLongTimeString();
                                    string varWareID = dt.Rows[i][3].ToString();
                                    string varWareName = dt.Rows[i][4].ToString();
                                    string varSpec = dt.Rows[i][5].ToString();
                                    string varUnit = dt.Rows[i][6].ToString();
                                    decimal varPCount = Decimal.Parse(dt.Rows[i][7].ToString());
                                    decimal varPUnitPrice = Decimal.Parse(dt.Rows[i][8].ToString());
                                    decimal varUSCount = Decimal.Parse(dt.Rows[i][9].ToString());
                                    decimal varTaxRate = 17;
                                    decimal varTTC = varPCount * varPUnitPrice;
                                    decimal varT = varTTC * varTaxRate / 100;
                                    decimal varNT = varTTC - varT;
                                    decimal var1 = (decimal)this.dt.Compute("SUM (金额)", "");
                                    decimal var2 = (decimal)this.dt.Compute("SUM(税额)", "");
                                    decimal var3 = (decimal)this.dt.Compute("SUM(不含税额)", "");

                                    #region SC
                                    decimal varupdateUSCount;
                                    SqlDataReader sqlreadSc = boperate.getread("select PurOrdersID,PurOrdersSN,TNSCheckCount from tb_TNSC where PurOrdersID='" +varID  +
                                        "'and PurOrdersSN='" + varSN + "'");
                                    sqlreadSc.Read();

                                    if (sqlreadSc.HasRows)
                                    {
                                        decimal vargetTNSCheckCount = Convert.ToDecimal(sqlreadSc["TNSCheckCount"]);
                                        #region Re
                                        decimal vargetTNReCount;
                                        SqlDataReader sqlreadRe = boperate.getread("select PurOrdersID,PurOrdersSN,TNReCount from tb_TNRe where PurOrdersID='" + varID +
                                            "'and PurOrdersSN='" + varSN + "'");
                                        sqlreadRe.Read();
                                        if (sqlreadRe.HasRows)
                                        {
                                            vargetTNReCount = Convert.ToDecimal(sqlreadRe["TNReCount"]);
                                            varupdateUSCount = varPCount - vargetTNSCheckCount + vargetTNReCount;
                                        }
                                        else
                                        {
                                            varupdateUSCount = varPCount - vargetTNSCheckCount;
                                        }
                                        sqlreadRe.Close();
                                        #endregion
                                    }
                                    else
                                    {
                                        varupdateUSCount = varPCount;

                                    }
                                    boperate.getcom("update tb_PurOrders set WareID='" + varWareID + "',WareName='" + varWareName + "',Spec='" + varSpec +
                                                      "',Unit='" + varUnit + "',PCount='" + varPCount + "',PUnitPrice='" + varPUnitPrice + "',USCount='" +varupdateUSCount  + "',TaxRate='" + varTaxRate +
                                                      "',TotalCount='" + varTTC + "',NoTax='" + varNT + "',Tax='" + varT +
                                                      "',TNTotalCount='" + var1 + "',TNTax='" + var2 + "',TNNoTax='" + var3 + "',StokerID='" + varStokerID +
                                                      "',StokerName='" + varStokerName + "',PDate='" + varPDate + "',Pur='" + varPur +
                                                      "',Maker='" + varMaker + "',Date='" + varDate + "',Time='" + varTime + "' where PurOrdersID ='" + varID + "' and  SN='" + varSN + "'");
                                    #region POrdersSta

                                    boperate.getcom("update  tb_POrdersSta set WareID='" + varWareID + "',WareName='" + varWareName + "',Spec='" + varSpec +
                                        "',Unit='" + varUnit + "',PCount='" + varPCount + "',USCount='" + varupdateUSCount  + "' where PurOrdersID='" + varID + "' and PurOrdersSN='" + varSN + "'");

                                    #endregion
                                    sqlreadSc.Close();
                                    #endregion
     
                                  
                                }
                            }
                        }
                    }
                }
            }
            dt.Clear();
            frmPurOrders_Load(sender, e);
            tsbtnEdit.Enabled = false;
            tsbtnSave.Enabled = false;



        }

     

    
        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsbtnPrint_Click(object sender, EventArgs e)
        {
            C23.ReportManage.frmCRPurOrders FRM = new C23.ReportManage.frmCRPurOrders();
            FRM.Show();
        }
       private void dgvPurOrdersInfo_DoubleClick(object sender, EventArgs e)
        {
           
            if (dgvPurOrdersInfo.CurrentCell.ColumnIndex == 2)
            {
                if (dt.Rows.Count > 0)
                {
                    SqlDataReader sqlread = boperate.getread("select VerifyID from tb_Verify where VerifyID='" + dt.Rows[dgvPurOrdersInfo.CurrentCell.RowIndex][2].ToString() + "'");
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
            
                        dt = boperate.getdt(M_str_sql + " where PurOrdersID like '%" + dt.Rows[dgvPurOrdersInfo.CurrentCell.RowIndex][2].ToString() + "%'");
                        dgvPurOrdersInfo.DataSource = dt;


                    }
                    sqlread.Close();
                }
               }
            if (dgvPurOrdersInfo.CurrentCell.ColumnIndex == 3)
            {
                C23.BomManage.frmWareInfo frm = new C23.BomManage.frmWareInfo();
                frm.PurOrders();
                frm.ShowDialog();
                setWareData();
            }
        }
    
        public void dgvPurOrders()
        {
            int numCols = dgvPurOrdersInfo.Columns.Count;

            for (i = 0; i < numCols; i++)
            {
                if (i != 0)
                {
                    dgvPurOrdersInfo.Columns[i].ReadOnly = true;

                }
            }
         }
    
        #region dgvStateControl
        private void dgvStateControl()
        {

            int numCols = dgvPurOrdersInfo.Columns.Count;

            for (i = 0; i < numCols; i++)
            {

                dgvPurOrdersInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (i == 0 || i ==1)
                {
                    dgvPurOrdersInfo.Columns[i].Width = 60;

                }
                if ( i!=0 && i != 3 && i != 7 && i != 8)
                {
                    dgvPurOrdersInfo.Columns[i].ReadOnly = true;

                }


                if (i == 16)
                {
                    dgvPurOrdersInfo.Columns[i].Width = 120;
                }
                if (i == 3 || i == 4 || i == 17 || i == 18)
                {
                    dgvPurOrdersInfo.Columns[i].Width = 200;
                }

            }
        }
        #endregion
        private void BindData()
        {
            dt = boperate.getdt(M_str_sql);
            dgvPurOrdersInfo.DataSource = dt;
            tsbtnDel.Enabled = false;
            tsbtnRefresh.Enabled = false;

            for (i = 0; i < dgvPurOrdersInfo.Columns.Count - 1; i++)
            {
                dgvPurOrdersInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                if (i==3 || i == 7 || i == 8)
                {
                    dgvPurOrdersInfo.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                }
            }
        }
        private void dgvPurInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPurOrdersID.Text = Convert.ToString(dgvPurOrdersInfo[2, dgvPurOrdersInfo.CurrentCell.RowIndex].Value).Trim();
            dtpPDate.Text = Convert.ToString(dgvPurOrdersInfo[19, dgvPurOrdersInfo.CurrentCell.RowIndex].Value).Trim();

            cboxStokerID.Text = Convert.ToString(dgvPurOrdersInfo[17, dgvPurOrdersInfo.CurrentCell.RowIndex].Value).Trim();
            txtStokerName.Text = Convert.ToString(dgvPurOrdersInfo[18, dgvPurOrdersInfo.CurrentCell.RowIndex].Value).Trim();
          
               
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
                    frmPurOrders_Load(sender, e);
                }
                if (tscboxCondition.Text.Trim() == "按编号")
                {
                    dt = boperate.getdt(M_str_sql + " where PSN like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvPurOrdersInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按采购单号")
                {
                    dt = boperate.getdt(M_str_sql + " where PurOrdersID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvPurOrdersInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按品号")
                {
                    dt = boperate.getdt(M_str_sql + " where WareID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvPurOrdersInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按品名")
                {
                    dt = boperate.getdt(M_str_sql + " where WareName like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvPurOrdersInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按供运商编号")
                {
                    dt = boperate.getdt(M_str_sql + " where StokerID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvPurOrdersInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按供运商名称")
                {
                    dt = boperate.getdt(M_str_sql + " where StokerName like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvPurOrdersInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按单据日期")
                {
                    dt = boperate.getdt(M_str_sql + " where Date='" + tstxtKeyWord.Text.Trim() + "'");
                    if (dt.Rows.Count > 0)
                        dgvPurOrdersInfo.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

      
        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            bn.Validate();
            string year, month;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            for (int i = 0; i < dt.Rows.Count; i++)
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
                            if (dt.Rows[i][7].ToString() == "")
                            {
                                MessageBox.Show("采购数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (dt.Rows[i][8].ToString() == "")
                                {
                                    MessageBox.Show("采购单价不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                else
                                {
                                    string varSN = dt.Rows[i][1].ToString();
                                    string varID = dt.Rows[i][2].ToString();
                                    string varPur = cboxPur.Text.Trim();
                                    string varStokerID = cboxStokerID.Text.Trim();
                                    string varStokerName = txtStokerName.Text.Trim();
                                    DateTime  varPDate1 = Convert.ToDateTime  (dtpPDate.Text.Trim());
                                    string varPDate = varPDate1.ToShortDateString();
                                    string varMaker = frmLogin.M_str_name;
                                    DateTime varDate1 = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                                    string varDate = varDate1.ToShortDateString();
                                    string varTime = DateTime.Now.ToLongTimeString();
                                    string varWareID = dt.Rows[i][3].ToString();
                                    string varWareName = dt.Rows[i][4].ToString();
                                    string varSpec = dt.Rows[i][5].ToString();
                                    string varUnit = dt.Rows[i][6].ToString();
                                    decimal varPCount = Decimal.Parse(dt.Rows[i][7].ToString());
                                    decimal varPUnitPrice = Decimal.Parse(dt.Rows[i][8].ToString());
                                    decimal varUSCount = Decimal.Parse(dt.Rows[i][9].ToString());
                                    decimal varTaxRate = 17;
                                    decimal varTTC = varPCount * varPUnitPrice;
                                    decimal varT = varTTC * varTaxRate / 100;
                                    decimal varNT = varTTC - varT;
                                    decimal var1 = (decimal)this.dt.Compute("SUM (金额)", "");
                                    decimal var2 = (decimal)this.dt.Compute("SUM(税额)", "");
                                    decimal var3 = (decimal)this.dt.Compute("SUM(不含税额)", "");

                                    #region SC
                                    decimal varupdateUSCount;
                                    SqlDataReader sqlreadSc = boperate.getread("select PurOrdersID,PurOrdersSN,TNSCheckCount from tb_TNSC where PurOrdersID='" + varID +
                                        "'and PurOrdersSN='" + varSN + "'");
                                    sqlreadSc.Read();

                                    if (sqlreadSc.HasRows)
                                    {
                                        decimal vargetTNSCheckCount = Convert.ToDecimal(sqlreadSc["TNSCheckCount"]);
                                        #region Re
                                        decimal vargetTNReCount;
                                        SqlDataReader sqlreadRe = boperate.getread("select PurOrdersID,PurOrdersSN,TNReCount from tb_TNRe where PurOrdersID='" + varID +
                                            "'and PurOrdersSN='" + varSN + "'");
                                        sqlreadRe.Read();
                                        if (sqlreadRe.HasRows)
                                        {
                                            vargetTNReCount = Convert.ToDecimal(sqlreadRe["TNReCount"]);
                                            varupdateUSCount = varPCount - vargetTNSCheckCount + vargetTNReCount;
                                        }
                                        else
                                        {
                                            varupdateUSCount = varPCount - vargetTNSCheckCount;
                                        }
                                        sqlreadRe.Close();
                                        #endregion
                                    }
                                    else
                                    {
                                        varupdateUSCount = varPCount;

                                    }
                                    boperate.getcom("update tb_PurOrders set WareID='" + varWareID + "',WareName='" + varWareName + "',Spec='" + varSpec +
                                                      "',Unit='" + varUnit + "',PCount='" + varPCount + "',PUnitPrice='" + varPUnitPrice + "',USCount='" + varupdateUSCount + "',TaxRate='" + varTaxRate +
                                                      "',TotalCount='" + varTTC + "',NoTax='" + varNT + "',Tax='" + varT +
                                                      "',TNTotalCount='" + var1 + "',TNTax='" + var2 + "',TNNoTax='" + var3 + "',StokerID='" + varStokerID +
                                                      "',StokerName='" + varStokerName + "',PDate='" + varPDate + "',Pur='" + varPur +
                                                      "',Maker='" + varMaker + "',Date='" + varDate + "',Time='" + varTime + "' where PurOrdersID ='" + varID + "' and  SN='" + varSN + "'");
                                    #region POrdersSta

                                    boperate.getcom("update  tb_POrdersSta set WareID='" + varWareID + "',WareName='" + varWareName + "',Spec='" + varSpec +
                                        "',Unit='" + varUnit + "',PCount='" + varPCount + "',USCount='" + varupdateUSCount + "' where PurOrdersID='" + varID + "' and PurOrdersSN='" + varSN + "'");

                                    #endregion
                                    sqlreadSc.Close();
                                    #endregion


                                }
                            }
                        }
                    }
                }
            }
            dt.Clear();
            frmPurOrders_Load(sender, e);
            tsbtnEdit.Enabled = false;
            tsbtnSave.Enabled = false;


           
        }

        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要删除该条品号信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (dt.Rows.Count > 0)
                    {
                        boperate.getcom("delete tb_PurOrders where PurOrdersID='" + dt.Rows[dgvPurOrdersInfo.CurrentCell.RowIndex][2].ToString() +
                "' AND SN='" + dt.Rows[dgvPurOrdersInfo.CurrentCell.RowIndex][1].ToString() + "'");

                        tsbtnEdit.Enabled = false;
                        tsbtnSave.Enabled = false;
                        tsbtnRefresh.Enabled = false;
                        tsbtnDel.Enabled = false;
                    }
                    frmPurOrders_Load(sender, e);
                    MessageBox.Show("数据已删除！如果该单号还有品号请刷新该单号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            
           
        }

        private void dgvPurOrdersInfo_DataSourceChanged(object sender, EventArgs e)
        {
            for (i = 0; i < dgvPurOrdersInfo.Columns.Count; i++)
            {
                if (dgvPurOrdersInfo.Columns[i].ValueType.ToString() == "System.Decimal")
                {
                    dgvPurOrdersInfo.Columns[i].DefaultCellStyle.Format = "N";
                    dgvPurOrdersInfo.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                }

            }
        }

        private void tsPrint2_Click(object sender, EventArgs e)
        {
            C23.ReportManage.frmCRPurPart  FRM = new C23.ReportManage.frmCRPurPart();
            FRM.Show();
        }

      
    }
}
