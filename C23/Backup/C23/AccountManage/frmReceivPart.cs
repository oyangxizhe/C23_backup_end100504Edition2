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
    public partial class frmReceivPart : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        protected string M_str_sql = "Select SN as 编号, RootID as 来源单号,RootName as 单据名称,WareID as 品号,WareName as 品名,ClientID as 客户编号,"
            + "CName as 客户名称,SellCount as 销货数量,SRCount as 销退数量,SUnitPrice as 销售单价,TaxRate as 税率,DiscountRate as 折扣率,TNTotalCount as 合计金额,"
            + "TNNoTax as 合计不含税金额,TNTax as 合计税额,Date as 单据日期,Time as 单据时间 from tb_ReceivPart";
        protected string M_str_table = "tb_ReceivPart";
        protected int i;
        public frmReceivPart()
        {
            InitializeComponent();
        }

        private void frmReceivPart_Load(object sender, EventArgs e)
        {
            BindData();
            dgvStateControl();
        }
        #region dgvStateControl
        private void dgvStateControl()
        {

            int numCols = dgvReceivPartInfo.Columns.Count;

            for (i = 0; i < numCols; i++)
            {

                dgvReceivPartInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (i == 0)
                {
                    dgvReceivPartInfo.Columns[i].Width = 60;
                }
                if (i == 3 || i == 4 || i == 5 || i == 6)
                {
                    dgvReceivPartInfo.Columns[i].Width = 200;
                }
                if (i == 12)
                {
                    dgvReceivPartInfo.Columns[i].Width = 150;
                }
                dgvReceivPartInfo.Columns[i].ReadOnly = true;   
            }
        }
        #endregion
        private void BindData()
        {


            dt = boperate.getdt(M_str_sql);
            dgvReceivPartInfo.DataSource = dt;
            for (i = 0; i < dgvReceivPartInfo.Columns.Count - 1; i++)
            {
                dgvReceivPartInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            }
        }

        private void tsbtnPrint_Click(object sender, EventArgs e)
        {
            C23.ReportManage.frmCRReceivPart frm = new C23.ReportManage.frmCRReceivPart();
            frm.Show();
        }

        private void dgvReceivPartInfo_DataSourceChanged(object sender, EventArgs e)
        {
            for (i = 0; i < dgvReceivPartInfo.Columns.Count; i++)
            {
                if (dgvReceivPartInfo.Columns[i].ValueType.ToString() == "System.Decimal")
                {
                    dgvReceivPartInfo.Columns[i].DefaultCellStyle.Format = "N";
                    dgvReceivPartInfo.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;


                }

            }
        }

        private void btnLook_Click(object sender, EventArgs e)
        {
            string varCS,varKS,varC1, varC2, varC3, varK1, varK2, varK3;
            varCS = cboxCondition.Text.Trim();
            varKS = txtKeyWord.Text.Trim();
            varC1 = cboxCondition1.Text.Trim();
            varC2 = cboxCondition2.Text.Trim();
            varC3 = cboxCondition3.Text.Trim();
            varK1 = txtKeyWord1.Text.Trim();
            varK2 = txtKeyWord2.Text.Trim();
            varK3 = txtKeyWord3.Text.Trim();
          

            try
            {
                if (txtKeyWord.Text == "")
                {
                    frmReceivPart_Load(sender, e);
                }
                if (cboxCondition.Text.Trim() == "来源单号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where RootID like '%" + txtKeyWord.Text.Trim() +"%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (cboxCondition.Text.Trim() == "单据名称")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where RootName like '%" + txtKeyWord.Text.Trim() +"%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (cboxCondition.Text.Trim() == "品号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where WareID like '%" + txtKeyWord.Text.Trim() +"%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (cboxCondition.Text.Trim() == "品名")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where WareName like '%" + txtKeyWord.Text.Trim() +"%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (cboxCondition.Text.Trim() == "客户编号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where ClientID like '%" + txtKeyWord.Text.Trim() +"%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (cboxCondition.Text.Trim() == "客户名称")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where CName like '%" + txtKeyWord.Text.Trim() +"%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (cboxCondition.Text.Trim() == "单据日期")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where Date= '" + txtKeyWord.Text.Trim() + "'",M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];

                }
                if (varC1 == "客户编号" && varC2 == "品号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where ClientID like '%" + varK1 +
                        "%' and WareID LIKE '%" + varK2 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (varC1 == "客户编号" && varC2 == "品名")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where ClientID like '%" + varK1 +
                        "%' and WareName LIKE '%" + varK2 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (varC1 == "客户编号" && varC3 == "来源单号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where ClientID like '%" + varK1 +
                        "%' and RootID LIKE '%" + varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (varC1 == "客户编号" && varC3 == "单据名称")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where ClientID like '%" + varK1 +
                        "%' and RootName LIKE '%" + varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (varC1 == "客户名称" && varC2 == "品号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where CName like '%" + varK1 +
                        "%' and WareID LIKE '%" + varK2 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (varC1 == "客户名称" && varC2 == "品名")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where CName like '%" + varK1 +
                        "%' and WareName LIKE '%" + varK2 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }        
                if (varC1 == "客户名称" && varC3 == "来源单号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where CName like '%" + varK1 +
                        "%' and RootID LIKE '%" + varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (varC1 == "客户名称" && varC3 == "单据名称")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where CName like '%" + varK1 +
                        "%' and RootName LIKE '%" + varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (varC2 == "品号" && varC3 == "来源单号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where WareID like '%" + varK2 +
                        "%' and RootID LIKE '%" + varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (varC2 == "品号" && varC3 == "单据名称")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where WareID like '%" + varK2 +
                        "%' and RootName LIKE '%" + varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (varC2 == "品名" && varC3 == "来源单号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where WareName like '%" + varK2 +
                        "%' and RootID LIKE '%" + varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (varC2 == "品名" && varC3 == "单据名称")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where WareName like '%" + varK2 +
                        "%' and RootName LIKE '%" + varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (varC1 == "客户编号" && varC2 == "品号" && varC3 == "来源单号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where ClientID like '%" + varK1 +
                        "%' and WareID LIKE '%" + varK2 + "%' and RootID like '%" + varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }

                if (varC1 == "客户编号" && varC2 == "品号" && varC3 == "单据名称")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where ClientID like '%" + varK1 +
                        "%' and WareID like '%" + varK2 + "%' and RootName like '%" + varK3 + "%'", M_str_table);


                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (varC1 == "客户编号" && varC2 == "品名" && varC3  == "来源单号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where ClientID like '%" + varK1 +
                        "%' and WareName LIKE '%" + varK2 + "%' and RootID like '%" +varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");

                }
                if (varC1 == "客户编号" && varC2 == "品名" && varC3  == "单据名称")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where ClientID like '%" + varK1 +
                        "%' and WareName LIKE '%" + varK2 + "%' and RootName like '%" + varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");

                }
                if (varC1 == "客户名称" && varC2 == "品号" && varC3 == "来源单号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where CName like '%" + varK1 +
                        "%' and WareID LIKE '%" + varK2 + "%' and RootID like '%" + varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (varC1 == "客户名称" && varC2 == "品号" && varC3 == "单据名称")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where CName like '%" + varK1 +
                        "%' and WareID LIKE '%" + varK2 + "%' and RootName like '%" + varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (varC1 == "客户名称" && varC2 == "品名" && varC3 == "来源单号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where CName like '%" + varK1 +
                        "%' and WareName LIKE '%" + varK2 + "%' and RootID like '%" + varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (varC1 == "客户名称" && varC2 == "品名" && varC3 == "单据名称")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where CName like '%" + varK1 +
                        "%' and WareName LIKE '%" + varK2 + "%' and RootName like '%" + varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvReceivPartInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
              
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            C23.ReportManage.frmCRReceivPart  frm = new C23.ReportManage.frmCRReceivPart ();
            frm.Show();
        }

    }
}
