using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace C23.SellManage
{
    public partial class frmOrdersStatus : Form
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected string M_str_sql = "select OrdersSN as 序号,OrdersID as 订单号,WareID as 品号,WareName as 品名,Spec as 规格,Unit as 单位,"
           + "OCount as 订单数量 ,TNSellCount as 累计销货数量,TNSRCount as 累计销退数量,USCount as 订单未结数量,ClientID as 客户编号,CName as 客户名称 from tb_OrdersStatus";
        protected  int i;
        public frmOrdersStatus()
        {
            InitializeComponent();
        }
        private void frmOrdersStatus_Load(object sender, EventArgs e)
        {
            BindData();
            dgvStateControl();
        }
        private void BindData()
        {
            dt = boperate.getdt(M_str_sql);
            dgvOSInfo.DataSource = dt;
            for (i = 0; i < dgvOSInfo.Columns.Count - 1; i++)
            {
                dgvOSInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        #region dgvStateControl
        private void dgvStateControl()
        {
            int numCols = dgvOSInfo.Columns.Count;
            for (i = 0; i < numCols; i++)
            {
                 dgvOSInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (i == 0 )
                {
                    dgvOSInfo.Columns[i].Width = 60;

                }
               if (i == 2 || i == 3 || i == 10 || i == 11)
                {
                    dgvOSInfo.Columns[i].Width = 200;
                }
               dgvOSInfo.Columns[i].ReadOnly = true;   
            }
        }
        #endregion

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvOSInfo_DataSourceChanged(object sender, EventArgs e)
        {
            for (i = 0; i < dgvOSInfo.Columns.Count; i++)
            {
                if (dgvOSInfo.Columns[i].ValueType.ToString() == "System.Decimal")
                {
                    dgvOSInfo.Columns[i].DefaultCellStyle.Format = "N";
                    dgvOSInfo.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;


                }

            }
        }
       
    }
}
