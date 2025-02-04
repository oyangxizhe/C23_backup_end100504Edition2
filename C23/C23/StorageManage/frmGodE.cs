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
    public partial class frmGodE : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected string M_str_sql = "select SN as 序号,GodEID as 入库单号,WareID as 品号,WareName as 品名,Spec as 规格,Unit as 单位,"
            + "GECount as 入库数量,GECheckCount as 验收数量,StorageType as 仓库类型,LocationName as 库位名称,Acceptor as 验收人,GodEDate as 入库日期,"
            +"Goder as 入库员,Maker as 制单人,Date as 制单日期, Time as 制单时间 from tb_GodE";
        protected string M_str_table = "tb_GodE";
        protected int i;
        public static string[] inputTextDataWare = new string[] { "", "", "", "" };
        public static string[] inputTextDataStorage = new string[] { "" };
        public static string[] inputTextDataLocation = new string[] { "" };
        public static string[] inputgetSEName = new string[] { "" };
        public frmGodE()
        {
            InitializeComponent();
            this.cboxGoder.Items.Add("");
            this.cboxAcceptor.Items.Add("");
        }
        private void dgvGOInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGOInfo.CurrentCell.ColumnIndex == 8)
            {
                C23.StorageManage.frmStorageInfo frm = new frmStorageInfo();
                frm.GodE();
                frm.ShowDialog();
                setStorageData();
            }
            if (dgvGOInfo.CurrentCell.ColumnIndex == 9)
            {
                C23.StorageManage.frmLocationInfo frm = new frmLocationInfo();
                frm.GodE();
                frm.ShowDialog();
                setLocationData();
            }
            txtGodEID.Text = Convert.ToString(dgvGOInfo[1, dgvGOInfo.CurrentCell.RowIndex].Value).Trim();
            cboxGoder.Text = Convert.ToString(dgvGOInfo[12, dgvGOInfo.CurrentCell.RowIndex].Value).Trim();
            dtpGodEDate.Text = Convert.ToString(dgvGOInfo[11, dgvGOInfo.CurrentCell.RowIndex].Value).Trim();
        }
        private void setStorageData()
        {
            dgvGOInfo.Rows[dgvGOInfo.CurrentCell.RowIndex].Cells[8].Value = inputTextDataStorage[0];

        }
        private void setLocationData()
        {
            dgvGOInfo.Rows[dgvGOInfo.CurrentCell.RowIndex].Cells[9].Value = inputTextDataStorage[1];
        }

        private void dgvGOInfo_DoubleClick(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                if (dgvGOInfo.CurrentCell.ColumnIndex == 1)
                {
                    SqlDataReader sqlread = boperate.getread("select VerifyID from tb_Verify where VerifyID='" + dt.Rows[dgvGOInfo.CurrentCell.RowIndex][1].ToString() + "'");
                    sqlread.Read();
                    if (sqlread.HasRows)
                    {
                        MessageBox.Show("单据已被锁定");
                    }
                    else
                    {
                   
                        tsbtnSave.Enabled = true;
                        dt = boperate.getdt(M_str_sql + " where GodEID like '%" + dt.Rows[dgvGOInfo.CurrentCell.RowIndex][1].ToString() + "%'");
                        dgvGOInfo.DataSource = dt;
                    }
                    sqlread.Close();
                }
            }

            if (dgvGOInfo.CurrentCell.ColumnIndex == 2)
            {
                C23.BomManage.frmWareInfo frm = new C23.BomManage.frmWareInfo();
                frm.GodE();
                frm.ShowDialog();
                setWareData();
            }
        }
        private void setWareData()
        {
            dgvGOInfo[2, dgvGOInfo.CurrentCell.RowIndex].Value = inputTextDataWare[0];
            dgvGOInfo[3, dgvGOInfo.CurrentCell.RowIndex].Value = inputTextDataWare[1];
            dgvGOInfo[4, dgvGOInfo.CurrentCell.RowIndex].Value = inputTextDataWare[2];
            dgvGOInfo[5, dgvGOInfo.CurrentCell.RowIndex].Value = inputTextDataWare[3];
        }

        private void cboxGoder_DropDown(object sender, EventArgs e)
        {
            C23.EmployeeManage.frmEmployeeInfo frm = new C23.EmployeeManage.frmEmployeeInfo();
            frm.GodE();
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

        private void cboxAcceptor_DropDown(object sender, EventArgs e)
        {
            C23.EmployeeManage.frmEmployeeInfo frm = new C23.EmployeeManage.frmEmployeeInfo();
            frm.GodE();
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
       private void frmGodE_Load(object sender, EventArgs e)
        {
             BindData();
             dgvStateControl();
        }
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

                if (i != 1 && i != 2 && i != 6 && i != 7 && i != 8)
                {
                    dgvGOInfo.Columns[i].ReadOnly = true;

                }

                if (i == 2 || i == 3)
                {
                    dgvGOInfo.Columns[i].Width = 200;
                }
            }
        }
        #endregion
        #region BindData
        private void BindData()
        {
            dt = boperate.getdt(M_str_sql);
            dgvGOInfo.DataSource = dt;
            tsbtnDel.Enabled = false;
          for (i = 0; i < dgvGOInfo.Columns.Count - 1; i++)
            {
                dgvGOInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
               if (i == 2 || i == 7 || i == 8 || i == 9)
                {
                    dgvGOInfo.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                }
            }
        }
        #endregion
        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            frmGodET frm = new frmGodET();
            frm.ShowDialog();
            frmGodE_Load(sender, e);
     
            ClearText();
        }
        public void ClearText()
        {

        }

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            tsbtnSave.Enabled = true;
          
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
                    if (dt.Rows[i][2].ToString() == "")
                    {
                        MessageBox.Show("品号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (dt.Rows[i][7].ToString() == "")
                        {
                            MessageBox.Show("验收数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                        {
                            if (dt.Rows[i][8].ToString() == "")
                            {
                                MessageBox.Show("仓库类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (dt.Rows[i][9].ToString() == "")
                                {
                                    MessageBox.Show("库位名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    string varSN = dt.Rows[i][0].ToString();
                                    string varID = txtGodEID.Text;
                                    string varWareID = dt.Rows[i][2].ToString();
                                    string varWareName = dt.Rows[i][3].ToString();
                                    string varSpec = dt.Rows[i][4].ToString();
                                    string varUnit = dt.Rows[i][5].ToString();
                                    string varGECount = dt.Rows[i][6].ToString();

                                    decimal varGECheckCount = decimal.Parse(dt.Rows[i][7].ToString());
                                    string varStorageType = dt.Rows[i][8].ToString();
                                    string varLocationName = dt.Rows[i][9].ToString();
                                    string varGoder = cboxGoder.Text.Trim();
                                    DateTime varGodEDate1 = Convert.ToDateTime(dtpGodEDate.Text.Trim());
                                    string varGodEDate = varGodEDate1.ToShortDateString();
                                    string varMaker = frmLogin.M_str_name;
                                    DateTime varDate1 = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                                    string varDate = varDate1.ToShortDateString();
                                    string varTime = DateTime.Now.ToLongTimeString();
                                    #region GodE
                                    #endregion
                                    boperate.getcom("update tb_GodE set WareID='" + varWareID + "',WareName='" + varWareName + "',Spec='" + varSpec +
                                        "',Unit='" + varUnit + "',GECount='" + varGECount + "',GECheckCount='"+varGECheckCount+"',StorageType='" + varStorageType +
                                        "',LocationName='" + varLocationName + "',Goder='" + varGoder + "',GodEDate='" + varGodEDate +
                                        "',Maker='" + varMaker + "',Date='" + varDate + "',Time='" + varTime +
                                       "' where GodEID='" + varID + "'and SN='" + varSN + "'");
                                 
                                    #region StorageCase
                                    SqlDataReader sqlread = boperate.getread("select StorageCount from tb_StorageCase where WareID='" + varWareID +
                                    "'and StorageType='" + varStorageType + "'and LocationName='" + varLocationName + "'");
                                    SqlDataReader sqlread2 = boperate.getread("select GECheckCount from Inventory where RootID='"+varID +
                                        "' AND SN='"+varSN +"'");
                                    sqlread.Read();
                                    sqlread2.Read();
                                    decimal varupdateStorageCount;
                                    if (sqlread.HasRows && sqlread2 .HasRows )
                                    {
                                        decimal vargetGECheckCount = Convert.ToDecimal(sqlread2["GECheckCount"]);
                                        decimal vargetStorageCount = Convert.ToDecimal(sqlread["StorageCount"]);
                                        if (varGECheckCount > vargetGECheckCount)
                                        {
                                            varupdateStorageCount = vargetStorageCount + (varGECheckCount - vargetGECheckCount);
                                        }
                                        else
                                        {
                                            varupdateStorageCount = vargetStorageCount - (vargetGECheckCount - varGECheckCount);
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
                                    #region Inventory
                                    boperate.getcom("update tb_Inventory set WareID='" + varWareID + "',WareName='" + varWareName + "',Spec='" + varSpec +
                                        "',Unit='" + varUnit + "',GECheckCount='" + varGECheckCount + "',StorageType='" + varStorageType +
                                        "',LocationName='" + varLocationName + "',Maker='" + varMaker + "',Date='" + varDate +
                                        "',Time='" + varTime + "' where RootID='" + varID + "' and SN='" + varSN + "'");
                                    #endregion
                                }

                            }
                        }
                    }
                }

            }
            dt.Clear();
            frmGodE_Load(sender, e);
            tsbtnSave.Enabled = false;
     }

        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要删除该条品号信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    boperate.getcom("delete from tb_GodE where GodEID='" + Convert.ToString(dgvGOInfo[0, dgvGOInfo.CurrentCell.RowIndex].Value).Trim() + "'");
                    frmGodE_Load(sender, e);
                    MessageBox.Show("删除数据成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            } 
        }

        private void tsbtnLook_Click(object sender, EventArgs e)
        {
           
            tsbtnSave.Enabled = true;
            tsbtnDel.Enabled = true;
            try
            {

                if (tstxtKeyWord.Text == "")
                {
               
                    tsbtnSave.Enabled = false;
                    tsbtnDel.Enabled = false;

                    frmGodE_Load(sender, e);
                }
                if (tscboxCondition.Text.Trim() == "按入库单号")
                {
                    dt = boperate.getdt(M_str_sql + " where GodEID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvGOInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }

                if (tscboxCondition.Text.Trim() == "按品号")
                {
                    dt = boperate.getdt(M_str_sql + " where WareID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvGOInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按品名")
                {
                    dt = boperate.getdt(M_str_sql + " where WareName like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvGOInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }

                if (tscboxCondition.Text.Trim() == "按单据日期")
                {
                    dt = boperate.getdt(M_str_sql + " where Date='" + tstxtKeyWord.Text.Trim() + "'");
                    if (dt.Rows.Count > 0)
                        dgvGOInfo.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       private void tsbtnPrint_Click(object sender, EventArgs e)
        {
            C23.ReportManage.frmCRGodE frm = new C23.ReportManage.frmCRGodE();
            frm.Show();
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

        private void tsbtnRLock_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要撤消单据锁定吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (dt.Rows.Count > 0)
                    {
                        boperate.getcom("delete tb_Verify where VerifyID='" + dt.Rows[dgvGOInfo.CurrentCell.RowIndex][1].ToString() + "'");
                     
                        tsbtnSave.Enabled = false;
                 
                    }
                    frmGodE_Load(sender, e);
                    MessageBox.Show("单据锁定已撤消！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    boperate.getcom("insert into tb_Verify (VerifyID) values ('" + dt.Rows[dgvGOInfo.CurrentCell.RowIndex][1].ToString() + "')");
                    
                    tsbtnSave.Enabled = false;
              
                }
                frmGodE_Load(sender, e);
                MessageBox.Show("单据已锁定！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

       
    }
}
