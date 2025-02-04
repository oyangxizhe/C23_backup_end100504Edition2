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
    public partial class frmAccountPart : Form
    {
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        protected string M_str_sql = "Select ARootID as 来源单号,ARootName as 单号名称,AStockDate as 进货日期,AWareID as 品号,AWareName as 品名,AStokerID as 供运商编号,"
            +"AStokerName as 供运商名称,ACheckCount as 验收数量,AUnitPrice as 单价,ATaxRate as 税率,ADiscountRate as 折扣率,ATotalCount as 合计金额,"
            +"ANoTax as 不含税金额,ATax as 税额 from tb_AccountPart";
        protected string M_str_table = "tb_AccountPart";
        public frmAccountPart()
        {
            InitializeComponent();
        }

        private void frmAccountPart_Load(object sender, EventArgs e)
        { // TODO: 这行代码将数据加载到表“db_JXCDataSet.tb_StockTable”中。您可以根据需要移动或移除它。

            int nX = (this.ParentForm.ClientSize.Width - this.Size.Width) / 2;
            int nY = (this.ParentForm.ClientSize.Height - this.Size.Height) / 2;
            this.Location = new Point(this.ParentForm.ClientRectangle.X + nX,
            this.ParentForm.ClientRectangle.Y + nY);
            

            DataSet ds = boperate.getds(M_str_sql, M_str_table);
            dgvAccountPartInfo.DataSource = ds.Tables[0];
        }
       
        private void tsbtnLook_Click(object sender, EventArgs e)
        {
            try
            {
                if (tstxtKeyWord.Text == "")
                {
                    frmAccountPart_Load(sender, e);
                }
                if (tscboxCondition.Text.Trim() == "按来源单号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where ARootID like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvAccountPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按来源单号名称")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where ARootName like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvAccountPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按品号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where AWareID like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvAccountPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按品名")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where AWareName like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvAccountPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按供运商编号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where AStokerID like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvAccountPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按供运商名称")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where AStokerName like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvAccountPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按进货日期")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where AStockDate like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvAccountPartInfo.DataSource = myds.Tables[0];
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

      
    }
}
