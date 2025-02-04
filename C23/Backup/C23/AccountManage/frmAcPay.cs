using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace C23.AccountManage
{
    public partial class frmAcPay : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        protected string M_str_sql = "Select StokerID as 供运商编号,StokerName as 供运商名称,TNTotalCount as 合计金额,TNNoTax as 合计不含税金额,TNTax as 合计税额 from tb_AcPay";
        protected string M_str_table = "tb_AcPay";
        protected int i;
        public frmAcPay()
        {
            InitializeComponent();
        }
        private void frmAcPay_Load(object sender, EventArgs e)
        {
             BindData();
             dgvStateControl();
           
        }
        #region dgvStateControl
        private void dgvStateControl()
        {

            int numCols = dgvAcPayInfo.Columns.Count;

            for (i = 0; i < numCols; i++)
            {

                dgvAcPayInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                if (i == 0 || i == 1|| i ==3)
                {
                    dgvAcPayInfo.Columns[i].Width = 200;
                }
                if (i == 3)
                {
                    dgvAcPayInfo.Columns[i].Width = 150;
                }
                dgvAcPayInfo.Columns[i].ReadOnly = true;   
            }
        }
        #endregion
        private void BindData()
        {

            dgvAcPayInfo.DataSource = total();
            for (i = 0; i < dgvAcPayInfo.Columns.Count - 1; i++)
            {
                dgvAcPayInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            }
        }
        
 

        private void tsbtnLook_Click(object sender, EventArgs e)
        {

            try
            {
                if (tstxtKeyWord.Text == "")
                {
                    frmAcPay_Load(sender, e);
                }
               
               if (tscboxCondition.Text.Trim() == "按供运商编号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where StokerID like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvAcPayInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按供运商名称")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where StokerName like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvAcPayInfo.DataSource = myds.Tables[0];
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

        private void dgvAcPayInfo_DataSourceChanged(object sender, EventArgs e)
        {
            for (i = 0; i < dgvAcPayInfo.Columns.Count; i++)
            {
                if (dgvAcPayInfo.Columns[i].ValueType.ToString() == "System.Decimal")
                {
                    dgvAcPayInfo.Columns[i].DefaultCellStyle.Format = "N";
                    dgvAcPayInfo.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;


                }

            }
        }
        private DataTable total()
        {
            dt = boperate.getdt(M_str_sql); ;
            DataRow dr = dt.NewRow();
            dr[1] = "合计";
            dr[2] = dt.Compute("sum(合计金额)", null);
            dr[3] = dt.Compute("sum(合计不含税金额)", null);
            dr[4] = dt.Compute("sum(合计税额)", null);
            dt.Rows.Add(dr);
            return dt;
        }
        private void dgvAcPayInfo_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
          if (e.RowIndex >= dgvAcPayInfo.Rows.Count - 1)
                return;
            DataGridViewRow dgr = dgvAcPayInfo.Rows[e.RowIndex];
            try
            {
                string[] Flag = dgr.Cells["供运商名称"].Value.ToString().Split('-');
                DataGridViewCellStyle cstyle = new DataGridViewCellStyle();
                cstyle.BackColor = Color.GreenYellow;

                for (int i = 0; i < Flag.Length; i++)
                {
                    if (Flag[i] == "合计")
                    {

                        //dgr.DefaultCellStyle.ForeColor = Color.Blue; 
                        dgr.Cells[0].Style = cstyle;
                        dgr.Cells[1].Style = cstyle;
                        dgr.Cells[2].Style = cstyle;
                        dgr.Cells[3].Style = cstyle;
                        dgr.Cells[4].Style = cstyle;
                   
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

          }
 
    }
}
