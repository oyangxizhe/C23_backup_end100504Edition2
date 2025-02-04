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
    public partial class frmOrdersT : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected int  i;
        public static string[] inputClientInfo = new string[] { "", "" };
        public static string[] inputdgvWare = new string[] { null, null, null, null };
        public static string[] inputgetOEName = new string[] { "" };
        
        public frmOrdersT()
        {
            InitializeComponent();
            this.cboxClientID.Items.Add("");
            cboxSale.Items.Add("");
        }
        private void BindData()
        {
            dt = total1();

            dgvOrdersInfo.DataSource = dt ;
           
            for (i = 0; i < dgvOrdersInfo.Columns.Count - 1; i++)
            {
                dgvOrdersInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;



                if (i == 1 || i == 5 || i == 6 || i == 7)
                {
                    dgvOrdersInfo.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                }
            }


        }
        private void frmOrdersT_Load(object sender, EventArgs e)
        {


            BindData();
            
            for (i = 0; i < dgvOrdersInfo.Columns.Count - 1; i++)
            {
                dgvOrdersInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            }

            dgvStateControl();



        }
        #region add
        private void tsbntAdd_Click(object sender, EventArgs e)
        {
            string year, month;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            opAndvalidate.num("select *  from tb_Orders", "select OrdersID,Year,Month from tb_Orders where Year='" + year +
                  "' AND Month='" + month + "'", "tb_Orders", "OrdersID", "OR", "0001", txtOrdersID);
            tsbtnSave.Enabled = true;
            ClearText();
         
       }
        #endregion
        public void ClearText()
        {
            cboxSale.Text = "";
            cboxClientID.Text = "";
            txtCName.Text = "";
        }
      
        #region save
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

                            if (dt.Rows[i][5].ToString() == "")
                            {
                                MessageBox.Show("订单数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (dt.Rows[i][6].ToString() == "")
                                {
                                    MessageBox.Show("销售单价不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    if (dt.Rows[i][7].ToString() == "")
                                    {
                                        MessageBox.Show("折扣率不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        string varSN = dt.Rows[i][0].ToString();
                                        string varID = txtOrdersID.Text;
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
                                        string varWareID = dt.Rows[i][1].ToString();
                                        string varWareName = dt.Rows[i][2].ToString();
                                        string varSpec = dt.Rows[i][3].ToString();
                                        string varUnit = dt.Rows[i][4].ToString();
                                        decimal varOCount = Decimal.Parse(dt.Rows[i][5].ToString());
                                        decimal varSUnitPrice = Decimal.Parse(dt.Rows[i][6].ToString());
                                        decimal varDiscountRate = Decimal.Parse(dt.Rows[i][7].ToString());
                                        decimal varUSCount = Decimal.Parse(dt.Rows[i][8].ToString());
                                        decimal varTaxRate = 17;
                                        decimal varTTC = Decimal.Parse(dt.Rows[i][10].ToString());
                                        decimal varT = Decimal.Parse(dt.Rows[i][11].ToString());
                                        decimal varNT = Decimal.Parse(dt.Rows[i][12].ToString());
                                        decimal var1 = (decimal)this.dt.Compute("SUM (金额)", "");
                                        decimal var2 = (decimal)this.dt.Compute("SUM(税额)", "");
                                        decimal var3 = (decimal)this.dt.Compute("SUM(不含税额)", "");
                                        string varsendValues = "('" + varSN + "','" + varID + "','" + year + "','" + month + "','" + varWareID +
                                                                   "','" + varWareName + "','" + varSpec + "','" + varUnit + "','" + varOCount + "','"+varUSCount+"','" + varSUnitPrice +
                                                                   "','" + varTaxRate + "','" + varDiscountRate + "','" + varTTC + "','" + varNT + "','" + varT +
                                                                   "','" + var1 + "','" + var2 + "','" + var3 + "','" + varClientID + "','" + varCName +
                                                                   "','" + varOEDD + "','" + varORDD + "','" + varSale + "','" + varMaker + "','" + varDate + "','" + varTime + "')";
                                        boperate.getcom("insert into tb_Orders(SN,OrdersID,Year,Month,WareID,WareName,Spec,Unit,OCount,USCount,SUnitPrice,TaxRate,"
                                        + "DiscountRate,TotalCount,NoTax,Tax,TNTotalCount,TNTax,TNNoTax,ClientID,"
                                        + "CName,OEDD,ORDD,Sale,Maker,Date,Time) values " + varsendValues);
                                     
                                        #region OrdersSta
                                        boperate.getcom("insert into tb_OrdersSta(OrdersSN,OrdersID,WareID,WareName,Spec,Unit,OCount,USCount,"
                                           + "ClientID,CName) values ('" + varSN + "','" + varID + "','" + varWareID + "','" + varWareName +
                                               "','" + varSpec + "','" + varUnit + "','" + varOCount + "','" + varOCount +
                                                 "','" + varClientID + "','" + varCName + "')");
                                        #endregion
                                    
                                    }  

                                }

                            }

                        }
                    }

                  }
                }
            dt.Clear();
            frmOrdersT_Load(sender, e);
        }
        #endregion
        #region total1
        private DataTable total1()
        {  
            dt = new DataTable();
            dt.Columns.Add ("序号",typeof (string ));
            dt.Columns.Add("品号", typeof(string));
            dt.Columns.Add("品名", typeof(string));
            dt.Columns.Add("规格", typeof(string));
            dt.Columns.Add("单位", typeof(string));
            dt.Columns.Add("订单数量", typeof(decimal));
            dt.Columns.Add("销售单价", typeof(decimal));
            dt.Columns.Add("折扣率", typeof(decimal));
            dt.Columns.Add("订单未结数量", typeof(decimal), "订单数量");
            dt.Columns.Add("税率", typeof(decimal));
            dt.Columns.Add("金额", typeof(decimal), "订单数量*销售单价*折扣率");
            dt.Columns.Add("税额", typeof(decimal), "金额*0.17");
            dt.Columns.Add("不含税额", typeof(decimal), "金额-税额");
            dt.Columns.Add("合计金额", typeof(decimal));
            dt.Columns.Add("合计税额", typeof(decimal));
            dt.Columns.Add("合计不含税金额", typeof(decimal));
            dt.Columns.Add("客户编号", typeof(string));
            dt.Columns.Add("客户名称", typeof(string));
            dt.Columns.Add("预交货日期", typeof(DateTime));
            dt.Columns.Add("实际交货日期", typeof(DateTime));
            dt.Columns.Add("业务员", typeof(string));
            dt.Columns.Add("制单人", typeof(char));
            dt.Columns.Add("制单日期", typeof(DateTime));
            dt.Columns.Add("制单时间", typeof(string));
            return dt;
        }
        #endregion
       
     
        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvOrdersInfo.SelectedRows)
            {
                if (!r.IsNewRow)
                {
                    dgvOrdersInfo.Rows.Remove(r);

                }
            }
        }

     

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvOrdersInfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (i = 0; i < dgvOrdersInfo.Rows.Count - 1; i++)
            {

                dgvOrdersInfo[0, i].Value = i + 1;

            }
        }
        #region dgvStateControl
        private void dgvStateControl()
        {

            int numCols = dgvOrdersInfo.Columns.Count;

            for (i = 0; i < numCols; i++)
            {

                dgvOrdersInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (i == 0)
                {
                    dgvOrdersInfo.Columns[i].Width = 60;

                }
                if (i != 1 && i != 5 && i != 6 && i != 7)
                {
                    dgvOrdersInfo.Columns[i].ReadOnly = true;

                }


                if (i == 15)
                {
                    dgvOrdersInfo.Columns[i].Width = 120;
                }
                if (i == 1 || i == 2 || i == 16 || i == 17)
                {
                    dgvOrdersInfo.Columns[i].Width = 200;
                }

            }
        }
        #endregion
        private void cboxSale_DropDown(object sender, EventArgs e)
        {
            C23.EmployeeManage.frmEmployeeInfo frm = new C23.EmployeeManage.frmEmployeeInfo();
            frm.dgvReadOnlyOrdersT();
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
        private void cboxClientID_DropDown(object sender, EventArgs e)
        {
            C23.SellManage.frmClientInfo FRM = new SellManage.frmClientInfo();
            FRM.dgvReadOnlyT();
            FRM.ShowDialog();
            getClientInfo();
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

      
       

      
        private void dgvOrdersInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrdersInfo.CurrentCell.ColumnIndex == 1)
            {
                C23.BomManage.frmWareInfo frm = new C23.BomManage.frmWareInfo();
                frm.dgvReadOnlyOrdersT();
                frm.ShowDialog();
                setWareData();
            }
        }
  
        private void setWareData()
        {
            dgvOrdersInfo[1, dgvOrdersInfo.CurrentCell.RowIndex].Value = inputdgvWare[0];
            dgvOrdersInfo[2, dgvOrdersInfo.CurrentCell.RowIndex].Value = inputdgvWare[1];
            dgvOrdersInfo[3, dgvOrdersInfo.CurrentCell.RowIndex].Value = inputdgvWare[2];
            dgvOrdersInfo[4, dgvOrdersInfo.CurrentCell.RowIndex].Value = inputdgvWare[3];
        }

        private void dgvOrdersInfo_DataSourceChanged(object sender, EventArgs e)
        {
            for (i = 0; i < dgvOrdersInfo.Columns.Count; i++)
            {
                if (dgvOrdersInfo.Columns[i].ValueType.ToString() == "System.Decimal")
                {
                    dgvOrdersInfo.Columns[i].DefaultCellStyle.Format = "N";
                    dgvOrdersInfo.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;


                }

            }
        }   
      
    }
}
