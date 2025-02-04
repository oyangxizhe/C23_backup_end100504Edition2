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
    public partial class frmPOrdersSta : Form
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected string M_str_sql = "select PurOrdersSN as 序号,PurOrdersID as 采购单号,WareID as 品号,WareName as 品名,Spec as 规格,Unit as 单位,"
           + "PCount as 采购数量 ,TNSCheckCount as 累计进货验收数量,TNReCount as 累计退货数量,TNReaSCheckCount as 累计实际验收数量,USCount as 采购单未结数量, StokerID as 供运商编号,StokerName as 供运商名称 from tb_POrdersSta";
        protected int i;
        protected string M_str_table = "tb_POrdersSta";
        public frmPOrdersSta()
        {
            InitializeComponent();
        }
        private void frmPOrdersSta_Load(object sender, EventArgs e)
        {
            BindData();
            dgvStateControl();
        }
        #region BindData
        private void BindData()
        {
            dt = boperate.getdt(M_str_sql);
            dgvInfo.DataSource = dt;
            for (i = 0; i < dgvInfo.Columns.Count - 1; i++)
            {
                dgvInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        #endregion
        #region dgvStateControl
        private void dgvStateControl()
        {
            int numCols = dgvInfo.Columns.Count;
            for (i = 0; i < numCols; i++)
            {
                dgvInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (i == 0)
                {
                    dgvInfo.Columns[i].Width = 60;

                }
                if (i==7 || i == 9 || i==10)
                {
                    dgvInfo.Columns[i].Width = 120;

                }
                if (i == 2 || i == 3 || i == 11 || i == 12)
                {
                    dgvInfo.Columns[i].Width = 200;
                }
                dgvInfo.Columns[i].ReadOnly = true;
            }
        }
        #endregion
        private void dgvInfo_DataSourceChanged(object sender, EventArgs e)
        {
            for (i = 0; i < dgvInfo.Columns.Count; i++)
            {
                if (dgvInfo.Columns[i].ValueType.ToString() == "System.Decimal")
                {
                    dgvInfo.Columns[i].DefaultCellStyle.Format = "N";
                    dgvInfo.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;


                }

            }
        }

        private void btnLook_Click(object sender, EventArgs e)
        {
            #region
            string varCS, varKS, varC1, varC2, varC3, varK1, varK2, varK3;
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
                    frmPOrdersSta_Load(sender, e);
                }
                if (cboxCondition.Text.Trim() == "采购单号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where PurOrdersID like '%" + txtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (cboxCondition.Text.Trim() == "品号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where WareID like '%" + txtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (cboxCondition.Text.Trim() == "品名")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where WareName like '%" + txtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (cboxCondition.Text.Trim() == "供运商编号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where StokerID like '%" + txtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (cboxCondition.Text.Trim() == "供运商名称")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where StokerName like '%" + txtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (varC1 == "供运商编号" && varC2 == "品号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where StokerID like '%" + varK1 +
                        "%' and WareID LIKE '%" + varK2 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (varC1 == "供运商编号" && varC2 == "品名")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where StokerID like '%" + varK1 +
                        "%' and WareName LIKE '%" + varK2 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (varC1 == "供运商编号" && varC3 == "采购单号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where StokerID like '%" + varK1 +
                        "%' and PurOrdersID LIKE '%" + varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }

                if (varC1 == "供运商名称" && varC2 == "品号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where StokerName like '%" + varK1 +
                        "%' and WareID LIKE '%" + varK2 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (varC1 == "供运商名称" && varC2 == "品名")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where StokerName like '%" + varK1 +
                        "%' and WareName LIKE '%" + varK2 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (varC1 == "供运商名称" && varC3 == "采购单号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where StokerName like '%" + varK1 +
                        "%' and PurOrdersID LIKE '%" + varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (varC2 == "品号" && varC3 == "采购单号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where WareID like '%" + varK2 +
                        "%' and PurOrdersID LIKE '%" + varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }

                if (varC2 == "品名" && varC3 == "采购单号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where WareName like '%" + varK2 +
                        "%' and PurOrdersID LIKE '%" + varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }

                if (varC1 == "供运商编号" && varC2 == "品号" && varC3 == "采购单号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where StokerID like '%" + varK1 +
                        "%' and WareID LIKE '%" + varK2 + "%' and PurOrdersID like '%" + varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }


                if (varC1 == "供运商编号" && varC2 == "品名" && varC3 == "采购单号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where StokerID like '%" + varK1 +
                        "%' and WareName LIKE '%" + varK2 + "%' and PurOrdersID like '%" + varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");

                }

                if (varC1 == "供运商名称" && varC2 == "品号" && varC3 == "采购单号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where StokerName like '%" + varK1 +
                        "%' and WareID LIKE '%" + varK2 + "%' and PurOrdersID like '%" + varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (varC1 == "供运商名称" && varC2 == "品名" && varC3 == "采购单号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where StokerName like '%" + varK1 +
                        "%' and WareName LIKE '%" + varK2 + "%' and PurOrdersID like '%" + varK3 + "%'", M_str_table);

                    if (myds.Tables[0].Rows.Count > 0)
                        dgvInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
