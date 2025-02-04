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
    public partial class frmAccountPay : Form
    {
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        protected string M_str_sql = "Select APStokerID as 供运商编号,APStokerName as 供运商名称,APTotalCount as 合计金额,APNoTax as 不含税金额,APTax as 税额 from tb_AccountPay";
        protected string M_str_table = "tb_AccountPay";
        public frmAccountPay()
        {
            InitializeComponent();
        }

        private void frmAccountPay_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“db_JXCDataSet.tb_StockTable”中。您可以根据需要移动或移除它。

            int nX = (this.ParentForm.ClientSize.Width - this.Size.Width) / 2;
            int nY = (this.ParentForm.ClientSize.Height - this.Size.Height) / 2;
            this.Location = new Point(this.ParentForm.ClientRectangle.X + nX,
            this.ParentForm.ClientRectangle.Y + nY);


            DataSet ds = boperate.getds(M_str_sql, M_str_table);
            dgvAccountPayInfo.DataSource = ds.Tables[0];
        }

        private void tsbtnLook_Click(object sender, EventArgs e)
        {

            try
            {
                if (tstxtKeyWord.Text == "")
                {
                    frmAccountPay_Load(sender, e);
                }
               
               if (tscboxCondition.Text.Trim() == "按供运商编号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where APStokerID like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvAccountPayInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "按供运商名称")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where APStokerName like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvAccountPayInfo.DataSource = myds.Tables[0];
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
