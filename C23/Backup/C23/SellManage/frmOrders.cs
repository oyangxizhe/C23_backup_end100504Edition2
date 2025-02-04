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
    public partial class frmOrders : Form
    {
      
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected string M_str_sql = "select cast(0   as   bit)   as   复选框,SN as 序号,OrdersID as 订单号,WareID as 品号,WareName as 品名,Spec as 规格,Unit as 单位,"
           + "OCount as 订单数量 ,SUnitPrice as 销售单价 ,DiscountRate as 折扣率,USCount as 订单未结数量,TaxRate as 税率,TotalCount as 金额,Tax as 税额,"
           + "NoTax as 不含税额,TNTotalCount as 合计金额,TNTax as 合计税额,TNNoTax as 合计不含税金额,ClientID as 客户编号,CName as 客户名称,OEDD as 预交货日期,ORDD as 实际交货日期,Sale as 业务员,"
           +"Maker as 制单人,Date as 制单日期,Time as 制单时间 from tb_Orders";
        protected int i;
        public static string[] inputClientInfo = new string[] { "", "" };
        public static string[] inputdgvWare = new string[] { null ,null ,null ,null  };
        public static string[] inputgetOEName = new string[] { "" };
        public void dgvReadOnlySell()
        {
            dgvOrdersInfo.Enabled = true;
        }
        public frmOrders()
        {
            InitializeComponent();
            this.cboxClientID.Items.Add("");
            cboxSale.Items.Add("");
        }
        #region save
        private void tsbtnSave_Click(object sender, EventArgs e)
        {

            #region
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

                            if (dt.Rows[i][7].ToString() == "")
                            {
                                MessageBox.Show("订单数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (dt.Rows[i][8].ToString() == "")
                                {
                                    MessageBox.Show("销售单价不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    if (dt.Rows[i][9].ToString() == "")
                                    {
                                        MessageBox.Show("折扣率不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {

                                        string varSN = dt.Rows[i][1].ToString();
                                        string varOrdersID = dt.Rows[i][2].ToString();
                                        string varSale = cboxSale.Text.Trim();
                                        string varClientID = cboxClientID.Text.Trim();
                                        string varCName = txtCName.Text.Trim();
                                        DateTime varOEDD1 = Convert.ToDateTime(dtpOEDD.Text.Trim());
                                        string varOEDD = varOEDD1.ToShortDateString();
                                        DateTime varORDD1 = Convert.ToDateTime(dtpORDD.Text.Trim());
                                        string varORDD = varORDD1.ToShortDateString();
                                        string varMaker = frmLogin.M_str_name;
                                        DateTime varDate1 = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                                        string varDate = varDate1.ToShortDateString();
                                        string varTime = DateTime.Now.ToLongTimeString();
                                        string varWareID = dt.Rows[i][3].ToString();
                                        string varWareName = dt.Rows[i][4].ToString();
                                        string varSpec = dt.Rows[i][5].ToString();
                                        string varUnit = dt.Rows[i][6].ToString();
                                        decimal varOCount = Decimal.Parse(dt.Rows[i][7].ToString());

                                        decimal varSUnitPrice = Decimal.Parse(dt.Rows[i][8].ToString());
                                        decimal varDiscountRate = Decimal.Parse(dt.Rows[i][9].ToString());
                                        decimal varTaxRate = 17;
                                        decimal varTTC = varOCount * varSUnitPrice * varDiscountRate;
                                        decimal varT = varTTC * varTaxRate / 100;
                                        decimal varNT = varTTC - varT;

                                        decimal var1 = (decimal)this.dt.Compute("SUM (金额)", "");
                                        decimal var2 = (decimal)this.dt.Compute("SUM(税额)", "");
                                        decimal var3 = (decimal)this.dt.Compute("SUM(不含税额)", "");

                                        #region Se
                                        decimal varupdateUSCount;
                                        SqlDataReader sqlreadSe = boperate.getread("select OrdersID,OrdersSN,TNSellCount from tb_TNSe where OrdersID='" + varOrdersID +
                                            "'and OrdersSN='" + varSN + "'");
                                        sqlreadSe.Read();

                                        if (sqlreadSe.HasRows)
                                        {
                                            decimal vargetTNSellCount = Convert.ToDecimal(sqlreadSe["TNSellCount"]);
                                            #region SR
                                            decimal vargetTNSRCount;
                                            SqlDataReader sqlreadSR = boperate.getread("select OrdersID,OrdersSN,TNSRCount from tb_TNSR where OrdersID='" + varOrdersID +
                                                "'and OrdersSN='" + varSN + "'");
                                            sqlreadSR.Read();
                                            if (sqlreadSR.HasRows)
                                            {
                                                vargetTNSRCount = Convert.ToDecimal(sqlreadSR["TNSRCount"]);
                                                varupdateUSCount = varOCount - vargetTNSellCount + vargetTNSRCount;
                                            }
                                            else
                                            {
                                                varupdateUSCount = varOCount - vargetTNSellCount;
                                            }
                                            sqlreadSR.Close();
                                            #endregion
                                        }
                                        else
                                        {
                                            varupdateUSCount = varOCount;

                                        }
                                        boperate.getcom("update tb_Orders set WareID='" + varWareID + "',WareName='" + varWareName + "',Spec='" + varSpec +
                                                       "',Unit='" + varUnit + "',OCount='" + varOCount + "',USCount='" + varupdateUSCount + "',SUnitPrice='" + varSUnitPrice + "',TaxRate='" + varTaxRate +
                                                       "',DiscountRate='" + varDiscountRate + "',TotalCount='" + varTTC + "',NoTax='" + varNT + "',Tax='" + varT +
                                                       "',TNTotalCount='" + var1 + "',TNTax='" + var2 + "',TNNoTax='" + var3 + "',ClientID='" + varClientID +
                                                       "',CName='" + varCName + "',OEDD='" + varOEDD + "',ORDD='" + varORDD + "',Sale='" + varSale +
                                                         "',Maker='" + varMaker + "',Date='" + varDate + "',Time='" + varTime + "' where OrdersID ='" + varOrdersID + "' and  SN='" + varSN + "'");

                                        boperate.getcom("update tb_OrdersSta set OCount='" + varOCount + "', USCount='" + varupdateUSCount +
                                                   "' where OrdersID='" + varOrdersID + "'  and OrdersSN='" + varSN + "'");

                                        sqlreadSe.Close();
                                        #endregion
                                    }
                                }
                            }
                        }
                    }
                }
            }
            dt.Clear();
            frmOrders_Load(sender, e);

            tsbtnEdit.Enabled = false;
            tsbtnSave.Enabled = false;

            #endregion
        }
        #endregion

        private void frmOrders_Load(object sender, EventArgs e)
       {    
            BindData();
            dgvStateControl();
           
        }
        #region dgvcellclick
        private void dgvOrdersInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
         
            if (tsbtnSave.Enabled != true)
            {
                txtOrdersID.Text = dgvOrdersInfo[2, dgvOrdersInfo.CurrentCell.RowIndex].Value.ToString();
                cboxSale.Text = dgvOrdersInfo[22, dgvOrdersInfo.CurrentCell.RowIndex].Value.ToString();
                cboxClientID.Text = dgvOrdersInfo[18, dgvOrdersInfo.CurrentCell.RowIndex].Value.ToString();
                txtCName.Text = dgvOrdersInfo[19, dgvOrdersInfo.CurrentCell.RowIndex].Value.ToString();
                dtpOEDD.Text = dgvOrdersInfo[20, dgvOrdersInfo.CurrentCell.RowIndex].Value.ToString();
                dtpORDD.Text = dgvOrdersInfo[21, dgvOrdersInfo.CurrentCell.RowIndex].Value.ToString();
                txtTotalCount.Text = dgvOrdersInfo[15, dgvOrdersInfo.CurrentCell.RowIndex].Value.ToString();
                txtTax.Text = dgvOrdersInfo[16, dgvOrdersInfo.CurrentCell.RowIndex].Value.ToString();
                txtNoTax.Text =dgvOrdersInfo[17, dgvOrdersInfo.CurrentCell.RowIndex].Value.ToString();
            }
          
            
        }
       #endregion
        private void dgvOrdersInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrdersInfo.CurrentCell.ColumnIndex == 0)
            {
                i = dgvOrdersInfo.CurrentCell.RowIndex;
                string varWareID, varWareName, varSpec, varUnit, varOrdersID, varSN, varOCount, varUSCount, varSUnitPrice, varDiscountRate, varClientID, varCName, varSale;
                varWareID = dgvOrdersInfo[3, i].Value.ToString();
                varWareName = dgvOrdersInfo[4, i].Value.ToString();
                varSpec = dgvOrdersInfo[5, i].Value.ToString();
                varUnit = dgvOrdersInfo[6, i].Value.ToString();

                varOrdersID = dgvOrdersInfo[2, i].Value.ToString();
                varSN = dgvOrdersInfo[1, i].Value.ToString();
                varOCount = dgvOrdersInfo[7, i].Value.ToString();
                varUSCount = dgvOrdersInfo[10, i].Value.ToString();
                varSUnitPrice = dgvOrdersInfo[8, i].Value.ToString();
                varDiscountRate = dgvOrdersInfo[9, i].Value.ToString();
                varClientID = dgvOrdersInfo.Rows[i].Cells[18].Value.ToString();
                varCName = dgvOrdersInfo.Rows[i].Cells[19].Value.ToString();
                varSale = dgvOrdersInfo.Rows[i].Cells[22].Value.ToString();

                string[] arr = new string[] { varWareID, varWareName, varSpec, varUnit, varOrdersID, varSN, varOCount, varUSCount, varSUnitPrice, varDiscountRate, varClientID, varCName, varSale };
                string[] arr1 = new string[] { varWareID, varWareName, varSpec, varUnit, varOrdersID, varSN, varOCount, varSUnitPrice, varDiscountRate, varClientID, varCName, varSale };
                C23.SellManage.frmSellTableT.getOrdersInfo[0] = arr[0];
                C23.SellManage.frmSellTableT.getOrdersInfo[1] = arr[1];
                C23.SellManage.frmSellTableT.getOrdersInfo[2] = arr[2];
                C23.SellManage.frmSellTableT.getOrdersInfo[3] = arr[3];
                C23.SellManage.frmSellTableT.getOrdersInfo[4] = arr[4];
                C23.SellManage.frmSellTableT.getOrdersInfo[5] = arr[5];
                C23.SellManage.frmSellTableT.getOrdersInfo[6] = arr[6];
                C23.SellManage.frmSellTableT.getOrdersInfo[7] = arr[7];
                C23.SellManage.frmSellTableT.getOrdersInfo[8] = arr[8];
                C23.SellManage.frmSellTableT.getOrdersInfo[9] = arr[9];
                C23.SellManage.frmSellTableT.getOrdersInfo[10] = arr[10];
                C23.SellManage.frmSellTableT.getOrdersInfo[11] = arr[11];
                C23.SellManage.frmSellTableT.getOrdersInfo[12] = arr[12];

                C23.SellManage.frmSellTable.getOrdersInfo[0] = arr1[0];
                C23.SellManage.frmSellTable.getOrdersInfo[1] = arr1[1];
                C23.SellManage.frmSellTable.getOrdersInfo[2] = arr1[2];
                C23.SellManage.frmSellTable.getOrdersInfo[3] = arr1[3];
                C23.SellManage.frmSellTable.getOrdersInfo[4] = arr1[4];
                C23.SellManage.frmSellTable.getOrdersInfo[5] = arr1[5];
                C23.SellManage.frmSellTable.getOrdersInfo[6] = arr1[6];
                C23.SellManage.frmSellTable.getOrdersInfo[7] = arr1[7];
                C23.SellManage.frmSellTable.getOrdersInfo[8] = arr1[8];
                C23.SellManage.frmSellTable.getOrdersInfo[9] = arr1[9];
                C23.SellManage.frmSellTable.getOrdersInfo[10] = arr1[10];
                C23.SellManage.frmSellTable.getOrdersInfo[11] = arr1[11];

                this.Close();
            }
        }
        #region getSaLeData
        private void cboxSale_DropDown(object sender, EventArgs e)
        {
            C23.EmployeeManage.frmEmployeeInfo frm = new C23.EmployeeManage.frmEmployeeInfo();
            frm.dgvReadOnlyOrders();
            frm.ShowDialog();
            setEmployeedata();
        }
        private void setEmployeedata()
        {
            this.cboxSale.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxSale.DroppedDown = false;//使组合框不显示其下拉部分
            cboxSale.Items[0] = inputgetOEName[0];
            this.cboxSale.SelectedIndex = 0;

            this.cboxSale.IntegralHeight = true;//恢复默认值

        }
        #endregion
        #region getWareInfo
    
         private void setWareData()
        {
            dgvOrdersInfo[3, dgvOrdersInfo.CurrentCell.RowIndex].Value = inputdgvWare[0];
            dgvOrdersInfo[4, dgvOrdersInfo.CurrentCell.RowIndex].Value = inputdgvWare[1];
            dgvOrdersInfo[5, dgvOrdersInfo.CurrentCell.RowIndex].Value = inputdgvWare[2];
            dgvOrdersInfo[6, dgvOrdersInfo.CurrentCell.RowIndex].Value = inputdgvWare[3];
        }
       #endregion
        #region dgvStateControl
        private void dgvStateControl()
        {
        
            int numCols = dgvOrdersInfo.Columns.Count;

            for ( i = 0; i < numCols; i++)
            {

                dgvOrdersInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

               if (i == 0 || i ==1)
                {
                    dgvOrdersInfo.Columns[i].Width = 60;
                   
                }
               if (i!=0 && i!=1 && i != 3 && i!=7 && i !=8 && i!=9)
               {
                   dgvOrdersInfo.Columns[i].ReadOnly = true;
               
               }
              
            
               if (i == 17)
               {
                   dgvOrdersInfo.Columns[i].Width = 120;
               }
                if (i == 3 || i ==4 || i ==18 || i ==19 )
                {
                    dgvOrdersInfo.Columns[i].Width = 200;
                }
              
            }
        }
        #endregion
        #region getClientData
        private void cboxClientID_DropDown(object sender, EventArgs e)
        {
            C23.SellManage.frmClientInfo FRM = new SellManage.frmClientInfo();
            FRM.dgvReadOnly();
            FRM.ShowDialog();
            getClientInfo();
            SendKeys.Send("{Tab}");//向活动应用程序发送Tab键,跳到下一控件
        }

        private void getClientInfo()
        {
            this.cboxClientID.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxClientID.DroppedDown = false;//使组合框不显示其下拉部分
            cboxClientID.Items[0] = inputClientInfo[0];
            txtCName.Text = inputClientInfo[1];
            this.cboxClientID.SelectedIndex = 0;

            this.cboxClientID.IntegralHeight = true;//恢复默认值
        }
        #endregion
        #region btnAdd
        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            C23.SellManage.frmOrdersT frm = new frmOrdersT();
            frm.ShowDialog();
            frmOrders_Load(sender, e);
            Cleardata();
        }
        #endregion
        private void Cleardata()
        {
            cboxSale.Text = "";
            cboxClientID.Text = "";
            txtCName.Text = "";

        }
        private void BindData()
        {       
                dt = boperate.getdt(M_str_sql);
                dgvOrdersInfo.DataSource = dt;
                tsbtnDel.Enabled = false;
                 tsbtnRefresh.Enabled = false;
          
            for (i = 0; i < dgvOrdersInfo.Columns.Count - 1; i++)
            {
                dgvOrdersInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                if (i == 3 || i == 7 || i == 8 || i == 9)
                {
                    dgvOrdersInfo.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                }
            }
        }
        #region Edit
        private void tsbtnEdit_Click(object sender, EventArgs e)
        {

            #region
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

                            if (dt.Rows[i][7].ToString() == "")
                            {
                                MessageBox.Show("订单数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (dt.Rows[i][8].ToString() == "")
                                {
                                    MessageBox.Show("销售单价不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    if (dt.Rows[i][9].ToString() == "")
                                    {
                                        MessageBox.Show("折扣率不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {

                                        string varSN = dt.Rows[i][1].ToString();
                                        string varOrdersID = dt.Rows[i][2].ToString();
                                        string varSale = cboxSale.Text.Trim();
                                        string varClientID = cboxClientID.Text.Trim();
                                        string varCName = txtCName.Text.Trim();
                                        DateTime varOEDD1 = Convert.ToDateTime(dtpOEDD.Text.Trim());
                                        string varOEDD = varOEDD1.ToShortDateString();
                                        DateTime varORDD1 = Convert.ToDateTime(dtpORDD.Text.Trim());
                                        string varORDD = varORDD1.ToShortDateString();
                                        string varMaker = frmLogin.M_str_name;
                                        DateTime varDate1 = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                                        string varDate = varDate1.ToShortDateString();
                                        string varTime = DateTime.Now.ToLongTimeString();
                                        string varWareID = dt.Rows[i][3].ToString();
                                        string varWareName = dt.Rows[i][4].ToString();
                                        string varSpec = dt.Rows[i][5].ToString();
                                        string varUnit = dt.Rows[i][6].ToString();
                                        decimal varOCount = Decimal.Parse(dt.Rows[i][7].ToString());

                                        decimal varSUnitPrice = Decimal.Parse(dt.Rows[i][8].ToString());
                                        decimal varDiscountRate = Decimal.Parse(dt.Rows[i][9].ToString());
                                        decimal varTaxRate = 17;
                                        decimal varTTC = varOCount * varSUnitPrice * varDiscountRate;
                                        decimal varT = varTTC * varTaxRate / 100;
                                        decimal varNT = varTTC - varT;

                                        decimal var1 = (decimal)this.dt.Compute("SUM (金额)", "");
                                        decimal var2 = (decimal)this.dt.Compute("SUM(税额)", "");
                                        decimal var3 = (decimal)this.dt.Compute("SUM(不含税额)", "");

                                        #region Se
                                        decimal varupdateUSCount;
                                        SqlDataReader sqlreadSe = boperate.getread("select OrdersID,OrdersSN,TNSellCount from tb_TNSe where OrdersID='" + varOrdersID +
                                            "'and OrdersSN='" + varSN + "'");
                                        sqlreadSe.Read();

                                        if (sqlreadSe.HasRows)
                                        {
                                            decimal vargetTNSellCount = Convert.ToDecimal(sqlreadSe["TNSellCount"]);
                                            #region SR
                                            decimal vargetTNSRCount;
                                            SqlDataReader sqlreadSR = boperate.getread("select OrdersID,OrdersSN,TNSRCount from tb_TNSR where OrdersID='" + varOrdersID +
                                                "'and OrdersSN='" + varSN  + "'");
                                         sqlreadSR.Read();
                                         if (sqlreadSR.HasRows)
                                            {
                                                vargetTNSRCount = Convert.ToDecimal(sqlreadSR["TNSRCount"]);
                                                varupdateUSCount = varOCount - vargetTNSellCount + vargetTNSRCount;
                                            }
                                            else
                                            {
                                                varupdateUSCount = varOCount - vargetTNSellCount;
                                            }
                                         sqlreadSR.Close();
                                            #endregion
                                        }
                                        else
                                        {     
                                            varupdateUSCount =varOCount ;

                                         }
                                        boperate.getcom("update tb_Orders set WareID='" + varWareID + "',WareName='" + varWareName + "',Spec='" + varSpec +
                                                       "',Unit='" + varUnit + "',OCount='" + varOCount  + "',USCount='" + varupdateUSCount + "',SUnitPrice='" + varSUnitPrice + "',TaxRate='" + varTaxRate +
                                                       "',DiscountRate='" + varDiscountRate + "',TotalCount='" + varTTC + "',NoTax='" + varNT + "',Tax='" + varT +
                                                       "',TNTotalCount='" + var1 + "',TNTax='" + var2 + "',TNNoTax='" + var3 + "',ClientID='" + varClientID +
                                                       "',CName='" + varCName + "',OEDD='" + varOEDD + "',ORDD='" + varORDD + "',Sale='" + varSale +
                                                         "',Maker='" + varMaker + "',Date='" + varDate + "',Time='" + varTime + "' where OrdersID ='" + varOrdersID + "' and  SN='" + varSN + "'");

                                        boperate.getcom("update tb_OrdersSta set OCount='"+varOCount+"', USCount='" + varupdateUSCount +
                                                   "' where OrdersID='" + varOrdersID + "'  and OrdersSN='" + varSN + "'");

                                        sqlreadSe.Close();
                                            #endregion
                                    }
                                }
                            }
                        }
                    }
                }
            }
            dt.Clear();
            frmOrders_Load(sender, e);
       
            tsbtnEdit.Enabled = false;
            tsbtnSave.Enabled = false;

            #endregion

        }
        #endregion
        private void dgvOrdersInfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
          foreach (DataGridViewRow r in dgvOrdersInfo.SelectedRows)
            {
                if (!r.IsNewRow)
                {
                    dgvOrdersInfo.Rows.Remove(r);

                }
            }
      }
        #region 删除
         private void tsbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要删除该条品号信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (dt.Rows.Count > 0)
                    {
                        boperate.getcom("delete tb_Orders where OrdersID='" + dt.Rows[dgvOrdersInfo.CurrentCell.RowIndex][2].ToString() +
                        "' AND SN='" + dt.Rows[dgvOrdersInfo.CurrentCell.RowIndex][1].ToString() + "'");
                  
                        tsbtnEdit.Enabled = false;
                        tsbtnSave.Enabled = false;
                        tsbtnRefresh.Enabled = false;
                        tsbtnDel.Enabled = false;
                    }
                    frmOrders_Load(sender, e);
                    MessageBox.Show("数据已删除！如果该单号还有品号请刷新该单号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            
             
         }

         private void tsbtnPrint_Click(object sender, EventArgs e)
        {
            C23.ReportManage.frmCROrders FRM = new C23.ReportManage.frmCROrders();
            FRM.Show();
        }
       #endregion

        #region 查询
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
                    tsbtnEdit.Enabled = false ;
                    tsbtnSave.Enabled = false ;
                    tsbtnDel.Enabled = false;
                    tsbtnRefresh.Enabled = false;
                    frmOrders_Load(sender, e);
                }
                if (tscboxCondition.Text.Trim() == "按编号")
                {
                    dt = boperate.getdt(M_str_sql + " where SN like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvOrdersInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按订单号")
                {
                    dt = boperate.getdt(M_str_sql + " where OrdersID like '%" + tstxtKeyWord.Text .Trim ()  + "%'");
                    if (dt.Rows.Count > 0)
                        dgvOrdersInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按品号")
                {
                    dt = boperate.getdt(M_str_sql + " where WareID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvOrdersInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按品名")
                {
                    dt = boperate.getdt(M_str_sql + " where WareName like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvOrdersInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按客户编号")
                {
                    dt = boperate.getdt(M_str_sql + " where ClientID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvOrdersInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按客户名称")
                {
                    dt = boperate.getdt(M_str_sql + " where CName like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvOrdersInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按单据日期")
                {
                    dt = boperate.getdt(M_str_sql + " where Date='" + tstxtKeyWord.Text.Trim() + "'");
                    if (dt.Rows.Count > 0)
                        dgvOrdersInfo.DataSource = dt;
                }
                if (tscboxCondition.Text.Trim() == "按审核状态")
                {
                    dt = boperate.getdt(M_str_sql + " where AuditStatus='" + tstxtKeyWord.Text.Trim() + "'");
                    if (dt.Rows.Count > 0)
                        dgvOrdersInfo.DataSource = dt;
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
         cboxClientID.Text = "";
            txtCName.Text = "";
        }
        private void dgvOrdersInfo_DataSourceChanged(object sender, EventArgs e)
        {
            for (i = 0; i < dgvOrdersInfo.Columns.Count; i++)
            {
            if (dgvOrdersInfo .Columns [i].ValueType.ToString ()=="System.Decimal")
                {
                    dgvOrdersInfo.Columns[i].DefaultCellStyle.Format = "N";
                    dgvOrdersInfo.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                }
            
            }

        }
     
        public void getOrdersdata()
        {
            int numCols = dgvOrdersInfo.Columns.Count;

            for (i = 0; i < numCols; i++)
            {
                if (i != 0)
                {
                    dgvOrdersInfo.Columns[i].ReadOnly = true;

                }
            }
        }

        private void dgvOrdersInfo_DoubleClick(object sender, EventArgs e)
        {
            if (dgvOrdersInfo.CurrentCell.ColumnIndex == 2)
            {
                if (dt.Rows.Count > 0)
                {
                    SqlDataReader sqlread = boperate.getread("select VerifyID from tb_Verify where VerifyID='" + dt.Rows[dgvOrdersInfo.CurrentCell.RowIndex][2].ToString() + "'");
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
                   

                        dt = boperate.getdt(M_str_sql + " where OrdersID like '%" + dt.Rows[dgvOrdersInfo.CurrentCell.RowIndex][2].ToString() + "%'");
                        dgvOrdersInfo.DataSource = dt;


                    }
                    sqlread.Close();
                }
            }
            if (dgvOrdersInfo.CurrentCell.ColumnIndex == 3)
            {
                C23.BomManage.frmWareInfo frm = new C23.BomManage.frmWareInfo();
                frm.dgvReadOnlyOrders();
                frm.ShowDialog();
                setWareData();
            }
           
          
        }

      
        
      }
}
