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
    public partial class frmMateRe : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected string M_str_sql = "select SN as 序号,MateReID as 领料单号,WareID as 品号,WareName as 品名,Spec as 规格,Unit as 单位,"
            + "MRCount as 领料数量,StorageType as 仓库类型,LocationName as 库位名称,MateRer as 领料员,MateReDate as 领料日期,"
            + "Maker as 制单人,Date as 制单日期, Time as 制单时间 from tb_MateRe";
        
        protected string M_str_table = "tb_MateRe";
        protected int i;
        public static string[] inputTextDataWare = new string[] { null, null, null, null };
        public static string[] inputTextDataStorage = new string[] { "",""};
        public static string[] inputTextDataLocation = new string[] { "" };
        public static string[] inputgetSEName = new string[] { "" };
        public frmMateRe()
        {
            InitializeComponent();
            this.cboxMateRer.Items.Add("");
        }
      
        private void cboxMateRer_DropDown(object sender, EventArgs e)
        {
            C23.EmployeeManage.frmEmployeeInfo frm = new C23.EmployeeManage.frmEmployeeInfo();
            frm.MateRe();
            frm.ShowDialog();
            ComplexMateRerInfo();

        }
        private void ComplexMateRerInfo()
        {
            this.cboxMateRer.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxMateRer.DroppedDown = false;//使组合框不显示其下拉部分
            this.cboxMateRer.Items[0] = inputgetSEName[0];
            this.cboxMateRer.SelectedIndex = 0;
            this.cboxMateRer.IntegralHeight = true;//恢复默认值

        }
       private void frmMateRe_Load(object sender, EventArgs e)
        {
            BindData();
            dgvStateControl();
        }
        #region dgvStateControl
        private void dgvStateControl()
        {

            int numCols = dgvMAInfo.Columns.Count;
            for (i = 0; i < numCols; i++)
            {
                dgvMAInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (i == 0)
                {
                    dgvMAInfo.Columns[i].Width = 60;

                }

                if (i != 1 && i != 2 && i != 6 && i != 7&& i !=8)
                {
                    dgvMAInfo.Columns[i].ReadOnly = true;

                }

                if (i == 2 || i == 3)
                {
                    dgvMAInfo.Columns[i].Width = 200;
                }
            }
        }
        #endregion
        #region BindData
        private void BindData()
        {
            dt = boperate.getdt(M_str_sql);
            dgvMAInfo.DataSource = dt;
            tsbtnDel.Enabled = false;
          

            for (i = 0; i < dgvMAInfo.Columns.Count - 1; i++)
            {
                dgvMAInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;



                if (i == 2 || i == 6 || i == 7 || i == 8)
                {
                    dgvMAInfo.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
                }
            }
        }
        #endregion

        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            frmMateReT  frm = new frmMateReT ();
            frm.ShowDialog();
            frmMateRe_Load(sender, e);
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
                        if (dt.Rows[i][6].ToString() == "")
                        {
                            MessageBox.Show("领料数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                    string varID = txtMateReID.Text;
                                    string varWareID = dt.Rows[i][2].ToString();
                                    string varWareName = dt.Rows[i][3].ToString();
                                    string varSpec = dt.Rows[i][4].ToString();
                                    string varUnit = dt.Rows[i][5].ToString();
                                    decimal varMRCount = decimal.Parse(dt.Rows[i][6].ToString());
                                    string varStorageType = dt.Rows[i][7].ToString();
                                    string varLocationName = dt.Rows[i][8].ToString();
                                    string varMateRer = cboxMateRer.Text.Trim();
                                    DateTime varMateReDate1 = Convert.ToDateTime(dtpMateReDate.Text.Trim());
                                    string varMateReDate = varMateReDate1.ToShortDateString();
                                    string varMaker = frmLogin.M_str_name;
                                    DateTime varDate1 = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                                    string varDate = varDate1.ToShortDateString();
                                    string varTime = DateTime.Now.ToLongTimeString();
                                    #region MateRe
                                 
                                    #region StorageCase
                                    SqlDataReader sqlread = boperate.getread("select StorageCount from tb_StorageCase where WareID='" + varWareID +
                                    "'and StorageType='" + varStorageType + "'and LocationName='" + varLocationName + "'");
                                 
                                    SqlDataReader sqlread2 = boperate.getread("select MRCount from tb_Inventory where RootID='"+varID +
                                        "' AND SN='"+varSN +"'");
                                    sqlread.Read();
                                    sqlread2.Read();
                                    decimal varupdateStorageCount;
                                    if (sqlread.HasRows && sqlread2 .HasRows )
                                    {
                                        decimal vargetMRCount = Convert.ToDecimal(sqlread2["MRCount"]);
                                        decimal vargetStorageCount = Convert.ToDecimal(sqlread["StorageCount"]);
                                        if (varMRCount > vargetMRCount)
                                        {
                                            varupdateStorageCount = vargetStorageCount - (varMRCount - vargetMRCount);
                                        }
                                        else
                                        {
                                            varupdateStorageCount = vargetStorageCount + (vargetMRCount - varMRCount);
                                        }
                                        if (varupdateStorageCount >= 0)
                                        {

                                            boperate.getcom("update tb_StorageCase set StorageCount='" + varupdateStorageCount +
                                            "'where WareID='" + varWareID + "'and StorageType='" + varStorageType +
                                            "'and LocationName='" + varLocationName + "'");
                                             #endregion
                                            boperate.getcom("update tb_MateRe set WareID='" + varWareID + "',WareName='" + varWareName + "',Spec='" + varSpec +
                                                "',Unit='" + varUnit + "',MRCount='" + varMRCount + "',StorageType='" + varStorageType +
                                                "',LocationName='" + varLocationName + "',MateRer='" + varMateRer + "',MateReDate='" + varMateReDate +
                                                "',Maker='" + varMaker + "',Date='" + varDate + "',Time='" + varTime +
                                               "' where MateReID='" + varID + "'and SN='" + varSN + "'");
                                            #region Inventory
                                            boperate.getcom("update tb_Inventory set WareID='" + varWareID + "',WareName='" + varWareName + "',Spec='" + varSpec +
                                                "',Unit='" + varUnit + "',MRCount='" + varMRCount + "',StorageType='" + varStorageType +
                                                "',LocationName='" + varLocationName + "',Maker='" + varMaker + "',Date='" + varDate +
                                                "',Time='" + varTime + "' where RootID='" + varID + "' and SN='" + varSN + "'");
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
            dt.Clear();
            frmMateRe_Load(sender, e);

            tsbtnSave.Enabled = false;
        }

        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要删除该条品号信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    boperate.getcom("delete from tb_MateRe where MateReID='" + Convert.ToString(dgvMAInfo[0, dgvMAInfo.CurrentCell.RowIndex].Value).Trim() + "'");
                    frmMateRe_Load(sender, e);
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
       
                    frmMateRe_Load(sender, e);
                }
                if (tscboxCondition.Text.Trim() == "按领料单号")
                {
                    dt = boperate.getdt(M_str_sql + " where MateReID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvMAInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
             
                if (tscboxCondition.Text.Trim() == "按品号")
                {
                    dt = boperate.getdt(M_str_sql + " where WareID like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvMAInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按品名")
                {
                    dt = boperate.getdt(M_str_sql + " where WareName like '%" + tstxtKeyWord.Text.Trim() + "%'");
                    if (dt.Rows.Count > 0)
                        dgvMAInfo.DataSource = dt;
                    else
                        MessageBox.Show("没有要查询的相关记录！");
                }
             
                if (tscboxCondition.Text.Trim() == "按单据日期")
                {
                    dt = boperate.getdt(M_str_sql + " where Date='" + tstxtKeyWord.Text.Trim() + "'");
                    if (dt.Rows.Count > 0)
                        dgvMAInfo.DataSource = dt;
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
        public void ClearText()
        {
           
        }

        private void tsbtnPrint_Click(object sender, EventArgs e)
        {
            C23.ReportManage.frmCRMateRe frm = new C23.ReportManage.frmCRMateRe();
            frm.Show();
        }

        private void dgvMAInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMAInfo.CurrentCell.ColumnIndex == 7)
            {
                C23.StorageManage.frmStorageCase frm = new C23.StorageManage.frmStorageCase();
                frm.MateRe();
                frm.ShowDialog();
                setStorageData();
            }
            if (dgvMAInfo.CurrentCell.ColumnIndex == 8)
            {
                C23.StorageManage.frmStorageCase frm = new C23.StorageManage.frmStorageCase();
                frm.MateRe();
                frm.ShowDialog();
                setLocationData();
            }
            txtMateReID.Text = Convert.ToString(dgvMAInfo[1, dgvMAInfo.CurrentCell.RowIndex].Value).Trim();
            cboxMateRer.Text = Convert.ToString(dgvMAInfo[9, dgvMAInfo.CurrentCell.RowIndex].Value).Trim();
            dtpMateReDate.Text = Convert.ToString(dgvMAInfo[10, dgvMAInfo.CurrentCell.RowIndex].Value).Trim();
           }
        private void setStorageData()
        {
            dgvMAInfo.Rows[dgvMAInfo.CurrentCell.RowIndex].Cells[7].Value = inputTextDataStorage[0];

        }
        private void setLocationData()
        {
            dgvMAInfo.Rows[dgvMAInfo.CurrentCell.RowIndex].Cells[8].Value = inputTextDataStorage[1];
        }
        private void dgvMAInfo_DoubleClick(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                if (dgvMAInfo.CurrentCell.ColumnIndex == 1)
                {
                    SqlDataReader sqlread = boperate.getread("select VerifyID from tb_Verify where VerifyID='" + dt.Rows[dgvMAInfo.CurrentCell.RowIndex][1].ToString() + "'");
                    sqlread.Read();
                    if (sqlread.HasRows)
                    {
                        MessageBox.Show("单据已被锁定");
                    }
                    else
                    {
                       
                        tsbtnSave.Enabled = true;
                        dt = boperate.getdt(M_str_sql + " where MateReID like '%" + dt.Rows[dgvMAInfo.CurrentCell.RowIndex][1].ToString() + "%'");
                        dgvMAInfo.DataSource = dt;
                    }
                    sqlread.Close();
                }
            }
            if (dgvMAInfo.CurrentCell.ColumnIndex == 2)
            {
                C23.BomManage.frmWareInfo frm = new C23.BomManage.frmWareInfo();
                frm.MateRe();
                frm.ShowDialog();
                setWareData();
            }     
        }
        private void setWareData()
        {
            dgvMAInfo[2, dgvMAInfo.CurrentCell.RowIndex].Value = inputTextDataWare[0];
            dgvMAInfo[3, dgvMAInfo.CurrentCell.RowIndex].Value = inputTextDataWare[1];
            dgvMAInfo[4, dgvMAInfo.CurrentCell.RowIndex].Value = inputTextDataWare[2];
            dgvMAInfo[5, dgvMAInfo.CurrentCell.RowIndex].Value = inputTextDataWare[3];
        }

        private void dgvMAInfo_DataSourceChanged(object sender, EventArgs e)
        {
            for (i = 0; i < dgvMAInfo.Columns.Count; i++)
            {
                if (dgvMAInfo.Columns[i].ValueType.ToString() == "System.Decimal")
                {
                    dgvMAInfo.Columns[i].DefaultCellStyle.Format = "N";
                    dgvMAInfo.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
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
                        boperate.getcom("delete tb_Verify where VerifyID='" + dt.Rows[dgvMAInfo.CurrentCell.RowIndex][1].ToString() + "'");
                     
                        tsbtnSave.Enabled = false;
                        tsbtnDel.Enabled = false;
                      }
                    frmMateRe_Load(sender, e);
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
                    boperate.getcom("insert into tb_Verify (VerifyID) values ('" + dt.Rows[dgvMAInfo.CurrentCell.RowIndex][1].ToString() + "')");
                
                    tsbtnSave.Enabled = false;
                    tsbtnDel.Enabled = false;
                }
                frmMateRe_Load(sender, e);
                MessageBox.Show("单据已锁定！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }
    }
}
