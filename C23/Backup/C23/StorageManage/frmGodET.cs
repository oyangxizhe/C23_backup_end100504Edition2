using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace C23.StorageManage
{
    public partial class frmGodET : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected int i;
        public static string[] inputTextDataWare = new string[] { null, null, null, null };
        public static string[] inputTextDataStorage = new string[] { "" };
        public static string[] inputTextDataLocation = new string[] { "" };
        public static string[] inputgetSEName = new string[] { "" };
        public frmGodET()
        {
            InitializeComponent();
            this.cboxGoder.Items.Add("");
            this.cboxAcceptor.Items.Add("");
        }
        private void cboxAcceptor_DropDown(object sender, EventArgs e)
        {
            C23.EmployeeManage.frmEmployeeInfo frm = new C23.EmployeeManage.frmEmployeeInfo();
            frm.GodET();
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
        private void cboxGoder_DropDown(object sender, EventArgs e)
        {
            C23.EmployeeManage.frmEmployeeInfo frm = new C23.EmployeeManage.frmEmployeeInfo();
            frm.GodET();
            frm.ShowDialog();
            getGoderData();
        }
        private void getGoderData()
        {
            this.cboxGoder.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxGoder.DroppedDown = false;//使组合框不显示其下拉部分
            this.cboxGoder.Items[0] = inputgetSEName[0];
            this.cboxGoder.SelectedIndex = 0;
            this.cboxGoder.IntegralHeight = true;//恢复默认值
        }
        private void frmGodET_Load(object sender, EventArgs e)
        {
            BindData();
            dgvStateControl();
        }
        #region BindData
        private void BindData()
        {
            dt = total1();

            dgvGOInfo.DataSource = dt;

            for (i = 0; i < dgvGOInfo.Columns.Count - 1; i++)
            {
                dgvGOInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;



                if (i == 1 || i == 6 || i == 7 || i == 8)
                {
                    dgvGOInfo.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                }
            }
         }
        #endregion
        #region dgvStateControl
        private void dgvStateControl()
        {
            int numCols = dgvGOInfo.Columns.Count;
            for (i = 0; i < numCols; i++)
            {
                dgvGOInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (i == 0)
                {
                    dgvGOInfo.Columns[i].Width = 60;

                }

                if (i != 1 && i!=5 && i != 6 && i != 7 && i != 8)
                {
                    dgvGOInfo.Columns[i].ReadOnly = true;

                }

                if (i == 1 || i == 2)
                {
                    dgvGOInfo.Columns[i].Width = 200;
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
            dt.Columns.Add("入库数量", typeof(string));
            dt.Columns.Add("验收数量", typeof(decimal));
            dt.Columns.Add("仓库类型", typeof(string));
            dt.Columns.Add("库位名称", typeof(string));
            dt.Columns.Add("入库员", typeof(string));
            dt.Columns.Add("入库日期", typeof(DateTime));
            dt.Columns.Add("制单人", typeof(char));
            dt.Columns.Add("制单日期", typeof(DateTime));
            dt.Columns.Add("制单时间", typeof(string));
            return dt;
        }
        #endregion
        private void dgvGOInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGOInfo.CurrentCell.ColumnIndex == 1)
            {
                C23.BomManage.frmWareInfo frm = new C23.BomManage.frmWareInfo();
                frm.GodET();
                frm.ShowDialog();
                setWareData();
            }
            if (dgvGOInfo.CurrentCell.ColumnIndex == 7)
            {
                C23.StorageManage.frmStorageInfo  frm = new frmStorageInfo ();
                frm.GodET();
                frm.ShowDialog();
                setStorageData();
            }
            if (dgvGOInfo.CurrentCell.ColumnIndex == 8)
            {
                C23.StorageManage.frmLocationInfo  frm = new frmLocationInfo ();
                frm.GodET();
                frm.ShowDialog();
                setLocationData();
            }
        }
        private void setWareData()
        {
            dgvGOInfo[1, dgvGOInfo.CurrentCell.RowIndex].Value = inputTextDataWare[0];
            dgvGOInfo[2, dgvGOInfo.CurrentCell.RowIndex].Value = inputTextDataWare[1];
            dgvGOInfo[3, dgvGOInfo.CurrentCell.RowIndex].Value = inputTextDataWare[2];
            dgvGOInfo[4, dgvGOInfo.CurrentCell.RowIndex].Value = inputTextDataWare[3];
        }

        private void setStorageData()
        {
            dgvGOInfo.Rows[dgvGOInfo.CurrentCell.RowIndex].Cells[7].Value = inputTextDataStorage[0];

        }
        private void setLocationData()
        {
            dgvGOInfo.Rows[dgvGOInfo.CurrentCell.RowIndex].Cells[8].Value = inputTextDataLocation[0];
        }
     
        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {

            bn.Validate();
            string year, month;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            string RootName = "入库单";

            for (i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows[i][0].ToString() == "")
                {

                }
                else
                {
                    if (dt.Rows[i][1].ToString() == "")
                    {
                        MessageBox.Show("品号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (dt.Rows[i][6].ToString() == "")
                        {
                            MessageBox.Show("验收数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                        {
                            if (dt.Rows[i][7].ToString() == "")
                            {
                                MessageBox.Show("仓库类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (dt.Rows[i][8].ToString() == "")
                                {
                                    MessageBox.Show("库位名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    string varSN = dt.Rows[i][0].ToString();
                                    string varID = txtGodEID.Text;
                                    string varWareID = dt.Rows[i][1].ToString();
                                    string varWareName = dt.Rows[i][2].ToString();
                                    string varSpec = dt.Rows[i][3].ToString();
                                    string varUnit = dt.Rows[i][4].ToString();
                                    string varGECount = dt.Rows[i][5].ToString();
                                    decimal varGECheckCount = decimal.Parse(dt.Rows[i][6].ToString());
                                    string varStorageType = dt.Rows[i][7].ToString();
                                    string varLocationName = dt.Rows[i][8].ToString();
                                    string varGoder = cboxGoder.Text.Trim();
                                    string varAcceptor = cboxAcceptor.Text.Trim();
                                    DateTime varGodEDate1 = Convert.ToDateTime(dtpGodEDate.Text.Trim());
                                    string varGodEDate = varGodEDate1.ToShortDateString();
                                    string varMaker = frmLogin.M_str_name;
                                    DateTime varDate1 = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                                    string varDate = varDate1.ToShortDateString();
                                    string varTime = DateTime.Now.ToLongTimeString();
                                    #region MateReT
                                    string varsendValues = "('" + varSN + "','" + varID + "','" + year + "','" + month +
                                     "','" + varWareID + "','" + varWareName + "','" + varSpec + "','" + varUnit +
                                     "','" + varGECount + "','"+varGECheckCount +"','" + varStorageType + "','" + varLocationName + "','" + varGodEDate +
                                     "','"+varGoder+"','" + varAcceptor + "','" + varMaker + "','" + varDate + "','" + varTime + "')";
                                    boperate.getcom("insert into tb_GodE(SN,GodEID,Year,Month,WareID,WareName,Spec,Unit,"
                                    + "GECount,GECheckCount,StorageType,LocationName,GodEDate,Goder,Acceptor,Maker,Date,Time) values " + varsendValues);
                                    #endregion
                                    boperate.getcom("insert into tb_Verify(VerifyID) values ('" + varID + "')");
                                  
                                    #region StorageCase
                                    SqlDataReader sqlread = boperate.getread("Select WareID,StorageType,LocationName,"
                          + "StorageCount from tb_StorageCase where WareID='" + varWareID + "' and StorageType='" + varStorageType + 
                          "' and LocationName='" + varLocationName + "'");
                        
                                    sqlread.Read();
                                    if (sqlread.HasRows)
                                    {
                                     decimal vargetStorageCount = Convert.ToDecimal (sqlread["StorageCount"]);
                                     decimal varupdateStorageCount = vargetStorageCount + varGECheckCount ;
                                     boperate.getcom("update tb_StorageCase set StorageCount='" + varupdateStorageCount  +
                                    "'where WareID='" + varWareID + "' and StorageType='" + varStorageType + "' and LocationName='" + varLocationName + "'");
                                    }
                                    else
                                    {
                                        boperate.getcom("insert into tb_StorageCase(WareID,WareName,Spec,Unit,StorageType,LocationName,"
                                        + "StorageCount) values ('" + varWareID  + "','" + varWareName+ "','" + varSpec  +
                                        "','" +varUnit  + "','" + varStorageType  + "','" + varLocationName + "','" + varGECheckCount + "')");
                                    }
                                    sqlread.Close();
                                    #endregion
                                    #region Inventory
                                    boperate.getcom("insert into tb_Inventory(SN,RootID,RootName,WareID,WareName,Spec,Unit,GECheckCount,StorageType,LocationName,"
                                   + " Maker,Date,Time) values ('" + varSN + "','" + varID + "','" + RootName + "','" + varWareID + "','" + varWareName + "','" + varSpec +
                                   "','" + varUnit + "','" + varGECheckCount + "','" + varStorageType + "','" + varLocationName + "','" + varMaker +
                                   "','" + varDate + "','" + varTime + "')");
                                    #endregion
                                  }
                             }
                        }
                    }
                }
              
            }
            dt.Clear();
            frmGodET_Load(sender, e);
        }

        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            opAndvalidate.num("select Year,Month,GodEID from tb_GodE", "select * from tb_GodE where Year='" + year +
                "' and Month='" + month + "'", "tb_GodE", "GodEID", "GE", "0001", txtGodEID);
            tsbtnSave.Enabled = true;
            ClearText();
        }
        public void ClearText()
        {
            cboxGoder.Text = "";
            cboxAcceptor.Text = "";
        }

        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvGOInfo.SelectedRows)
            {
                if (!r.IsNewRow)
                {
                    dgvGOInfo.Rows.Remove(r);

                }
            }
        }

        private void dgvGOInfo_DataSourceChanged(object sender, EventArgs e)
        {
            for (i = 0; i < dgvGOInfo.Columns.Count; i++)
            {
                if (dgvGOInfo.Columns[i].ValueType.ToString() == "System.Decimal")
                {
                    dgvGOInfo.Columns[i].DefaultCellStyle.Format = "N";
                    dgvGOInfo.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                }

            }
        }

        private void dgvGOInfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (i = 0; i < dgvGOInfo.Rows.Count - 1; i++)
            {
                dgvGOInfo[0, i].Value = i + 1;
            }
        }
       

      
    }
}
