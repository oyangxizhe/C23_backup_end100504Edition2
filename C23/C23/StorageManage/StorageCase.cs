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
    public partial class frmStorageCase : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        protected string M_str_sql = "select StorageType as 仓库类型,LocationName as 库位名称,WareID as 品号,WareName as 品名,Spec as 规格,Unit as 单位,"
            +"StorageCount as 库存数量 from tb_StorageCase";
        protected string M_str_table = "tb_StorageCase";
        protected int select,i;
        public frmStorageCase()
        {
            InitializeComponent();
        }
        private void frmStorageCase_Load(object sender, EventArgs e)
        {
            BindData();
            dgvStateControl();
        }
        #region dgvStateControl
        private void dgvStateControl()
        {

            int numCols = dgvStorageCaseInfo.Columns.Count;

            for (i = 0; i < numCols; i++)
            {

                dgvStorageCaseInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

              
                if (i == 2 || i == 3)
                {
                    dgvStorageCaseInfo.Columns[i].Width = 200;
                }

            }
        }
        #endregion
        private void BindData()
        {


            dt = boperate.getdt(M_str_sql);
            dgvStorageCaseInfo.DataSource = dt;
        
          
        }

        private void tsbtnLook_Click(object sender, EventArgs e)
        {
            try
            {
                if (tstxtKeyWord.Text == "")
                {
                    frmStorageCase_Load(sender, e);
                }
          
                if (tscboxCondition.Text.Trim() == "按品号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where CWareID like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvStorageCaseInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按品名")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where CWareName like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvStorageCaseInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按仓库类型")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where CStorageType like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvStorageCaseInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按库位名称")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where CLocationName like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvStorageCaseInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
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

        private void dgvStorageCaseInfo_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgvStorageCaseInfo.ReadOnly == true) //判断如果是在进货单中生成的窗体则不响应DataGrid的双击事件
            {
                int intCurrentRowNumber = this.dgvStorageCaseInfo.CurrentCell.RowIndex;
                string sendSType,sendSName;

                sendSType = this.dgvStorageCaseInfo.Rows[intCurrentRowNumber].Cells[0].Value.ToString().Trim();
                sendSName = this.dgvStorageCaseInfo.Rows[intCurrentRowNumber].Cells[1].Value.ToString().Trim();

                string[] sendArray = new string[] { sendSType,sendSName };
                if (select == 0)
                {
                    C23.SellManage .frmSellTable.inputTextDataStorage[0] = sendArray[0];
                    C23.SellManage.frmSellTable.inputTextDataStorage[1] = sendArray[1];
                }

                if (select == 1)
                {
                    C23.StorageManage .frmMateRe.inputTextDataStorage[0] = sendArray[0];
                    C23.StorageManage.frmMateRe.inputTextDataStorage[1] = sendArray[1];
                }
           
                this.Close();
            }
        }
        public void dgvReadOnlySell()
        {
            this.dgvStorageCaseInfo.ReadOnly = true;
            select = 0;
        }

        public void dgvReadOnlyMR()
        {
            this.dgvStorageCaseInfo.ReadOnly = true;
            select = 1;
        }

        private void dgvStorageCaseInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
      
    }
}
