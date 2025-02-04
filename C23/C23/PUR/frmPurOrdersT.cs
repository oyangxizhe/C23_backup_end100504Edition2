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
    public partial class frmPurOrdersT : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        public static string[] inputTextDataStoker = new string[] { "", "" };
        public static string[] inputTextDataWare = new string[] { "", "", "", "" };
        public static string[] getEmployeeInfo = new string[] { "" };
        protected int i, Status;
        public frmPurOrdersT()
        {
            InitializeComponent();
            this.cboxStokerID.Items.Add("");

            this.cboxPur.Items.Add("");
        }

     

        private void frmPurOrdersT_Load(object sender, EventArgs e)
        {
            BindData();

            for (i = 0; i < dgvPurOrdersInfo.Columns.Count - 1; i++)
            {
                dgvPurOrdersInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            }

            dgvStateControl();
        }
        #region dgvStateControl
        private void dgvStateControl()
        {

            int numCols = dgvPurOrdersInfo.Columns.Count;

            for (i = 0; i < numCols; i++)
            {

                dgvPurOrdersInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (i == 0)
                {
                    dgvPurOrdersInfo.Columns[i].Width = 60;

                }

                if (i != 1 && i != 5 && i != 6)
                {
                    dgvPurOrdersInfo.Columns[i].ReadOnly = true;

                }


                if (i == 1|| i==2 || i == 15 || i == 16)
                {
                    dgvPurOrdersInfo.Columns[i].Width = 200;
                }

            }
        }
        #endregion
        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            opAndvalidate.num("select Year,Month,PurOrdersID from tb_PurOrders", "select * from tb_PurOrders where Year='" + year +
                "' and Month='" + month + "'", "tb_PurOrders", "PurOrdersID", "PU", "0001", txtPurOrdersID);
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
                        if (dt.Rows[i][1].ToString() == "")
                        {
                            MessageBox.Show("品号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (dt.Rows[i][5].ToString() == "")
                            {
                                MessageBox.Show("采购数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (dt.Rows[i][6].ToString() == "")
                                {
                                    MessageBox.Show("采购单价不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                else
                                {
                                    string varSN = dt.Rows[i][0].ToString();
                                    string varID = txtPurOrdersID.Text;
                                    string varPur = cboxPur.Text.Trim();
                                    string varStokerID = cboxStokerID.Text.Trim();
                                    string varStokerName = txtStokerName.Text.Trim();
                                    DateTime  varPDate1 =  Convert .ToDateTime (dtpPDate.Text.Trim());
                                    string varPDate = varPDate1.ToShortDateString();
                                    string varMaker = frmLogin.M_str_name;
                                    DateTime varDate1 = DateTime .Now ;
                                    string varDate = varDate1.ToShortDateString();
                                    string varTime = DateTime.Now.ToLongTimeString();
                                    string varWareID = dt.Rows[i][1].ToString();
                                    string varWareName = dt.Rows[i][2].ToString();
                                    string varSpec = dt.Rows[i][3].ToString();
                                    string varUnit = dt.Rows[i][4].ToString();
                                    decimal varPCount = Decimal.Parse(dt.Rows[i][5].ToString());
                                    decimal varPUnitPrice = Decimal.Parse(dt.Rows[i][6].ToString());
                                    decimal varUSCount = Decimal.Parse(dt.Rows[i][7].ToString());
                                    decimal varTaxRate = 17;
                                    decimal varTTC = Decimal.Parse(dt.Rows[i][9].ToString());
                                    decimal varT = Decimal.Parse(dt.Rows[i][10].ToString());
                                    decimal varNT = Decimal.Parse(dt.Rows[i][11].ToString());
                                    decimal var1 = (decimal)this.dt.Compute("SUM (金额)", "");
                                    decimal var2 = (decimal)this.dt.Compute("SUM(税额)", "");
                                    decimal var3 = (decimal)this.dt.Compute("SUM(不含税额)", "");
                                

                                    string varsendValues = "('" + varSN + "','" + varID + "','" + year + "','" + month +
                                    "','" + varWareID + "','" + varWareName + "','" + varSpec + "','" + varUnit + "','" + varPCount +
                                    "','" + varPUnitPrice + "','"+varUSCount +"','" + varTaxRate + "','" + varTTC + "','" + varT + "','" + varNT +
                                    "','" + var1 + "','" + var2 + "','" + var3 + "','" + varStokerID + "','" + varStokerName + "','" + varPDate +
                                    "','" + varPur + "','" + varMaker + "','" + varDate + "','" + varTime + "')";
                                    boperate.getcom("insert into tb_PurOrders(SN,PurOrdersID,Year,Month,WareID,WareName,Spec,Unit,PCount,"
                                    + "PUnitPrice,USCount,TaxRate,TotalCount,Tax,NoTax,TNTotalCount,TNTax,TNNoTax,StokerID,StokerName,"
                                    + "PDate,Pur,Maker,Date,Time) values " + varsendValues);
                                    #region PurOrdersSta
                                    SqlDataReader sqlread1 = boperate.getread("Select PurOrdersID,WareID,PCount,USCount from tb_POrdersSta where PurOrdersID='" + varID +
                                        "' and PurOrdersSN='" + varSN + "'");
                                    sqlread1.Read();
                                    if (sqlread1.HasRows)
                                    {

                                    }
                                    else
                                    {
                                        boperate.getcom("insert into tb_POrdersSta(PurOrdersSN,PurOrdersID,WareID,WareName,Spec,Unit,PCount,USCount,"
                                       + "StokerID,StokerName) values ('" + varSN + "','" + varID + "','" + varWareID + "','" + varWareName +
                                           "','" + varSpec + "','" + varUnit + "','" + varPCount + "','" + varPCount +
                                             "','" + varStokerID + "','" + varStokerName + "')");
                                     
                                    }
                                    sqlread1.Close();
                                    #endregion

                                }

                            }
                        }
                    }

                }
            }
            dt.Clear();
            frmPurOrdersT_Load (sender, e);
        }

        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvPurOrdersInfo.SelectedRows)
            {
                if (!r.IsNewRow)
                {
                    dgvPurOrdersInfo.Rows.Remove(r);

                }
            }
        }

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
            private void BindData()
        {
            dt = total1();

            dgvPurOrdersInfo.DataSource = dt;

            for (i = 0; i < dgvPurOrdersInfo.Columns.Count - 1; i++)
            {
                dgvPurOrdersInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;



                if (i==1 || i == 5 || i == 6)
                {
                    dgvPurOrdersInfo.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                }
            }


        }
  
        
        
        #region total1
        private DataTable total1()
        {
            dt = new DataTable();
            dt.Columns.Add("序号", typeof(string));
            dt.Columns.Add("品号", typeof(string));
            dt.Columns.Add("品名", typeof(string));
            dt.Columns.Add("规格", typeof(string));
            dt.Columns.Add("单位", typeof(string));
            dt.Columns.Add("采购数量", typeof(decimal ));
            dt.Columns.Add("采购单价", typeof(decimal));
            dt.Columns.Add("采购未结数量", typeof(decimal),"采购数量");
            dt.Columns.Add("税率", typeof(decimal));
            dt.Columns.Add("金额", typeof(decimal), "采购数量*采购单价");
            dt.Columns.Add("税额", typeof(decimal), "金额*0.17");
            dt.Columns.Add("不含税额", typeof(decimal), "金额-税额");
            dt.Columns.Add("合计金额", typeof(decimal));
            dt.Columns.Add("合计税额", typeof(decimal));
            dt.Columns.Add("合计不含税金额", typeof(decimal));
            dt.Columns.Add("供运商编号", typeof(string));
            dt.Columns.Add("供运商名称", typeof(string));
            dt.Columns.Add("采购日期", typeof(DateTime));
            dt.Columns.Add("采购员", typeof(string));
            dt.Columns.Add("审核状栏", typeof(char));
            dt.Columns.Add("制单人", typeof(char));
            dt.Columns.Add("制单日期", typeof(DateTime));
            dt.Columns.Add("制单时间", typeof(string));
            return dt;
        }
        #endregion
   
        private void getPur()
        {
            this.cboxPur.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxPur.DroppedDown = false;//使组合框不显示其下拉部分
            cboxPur.Items[0] = getEmployeeInfo[0];

            this.cboxPur.SelectedIndex = 0;

            this.cboxPur.IntegralHeight = true;//恢复默认值
        }

        private void dgvPurOrdersInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPurOrdersInfo.CurrentCell.ColumnIndex == 1)
            {
                C23.BomManage.frmWareInfo frm = new C23.BomManage.frmWareInfo();
                frm.PurOrdersT();
                frm.ShowDialog();
                setWareData();
            }
        }
      
        private void setWareData()
        {
            dgvPurOrdersInfo[1, dgvPurOrdersInfo.CurrentCell.RowIndex].Value = inputTextDataWare[0];
            dgvPurOrdersInfo[2, dgvPurOrdersInfo.CurrentCell.RowIndex].Value = inputTextDataWare[1];
            dgvPurOrdersInfo[3, dgvPurOrdersInfo.CurrentCell.RowIndex].Value = inputTextDataWare[2];
            dgvPurOrdersInfo[4, dgvPurOrdersInfo.CurrentCell.RowIndex].Value = inputTextDataWare[3];
           
        }
        private void dgvPurOrdersInfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (i = 0; i < dgvPurOrdersInfo.Rows.Count - 1; i++)
            {

                dgvPurOrdersInfo[0, i].Value = i + 1;

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
            newFrm.dgvReadOnlyPurT();
            newFrm.ShowDialog();
            setStokerData();
            SendKeys.Send("{Tab}");//向活动应用程序发送Tab键,跳到下一控件
        }

        private void cboxPur_DropDown(object sender, EventArgs e)
        {
            C23.EmployeeManage.frmEmployeeInfo frm = new C23.EmployeeManage.frmEmployeeInfo();
            frm.dgvReadOnlyPurT();
            frm.ShowDialog();
            getPur();
        }


     
    }
}
