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
    public partial class frm : Form
    {
        public static string[] inputDataGridArray = new string[] {null,null,null,null};
        public static string[] inputStorage = new string[] {""};
        public static string[] inputLocation = new string[] {""};
        C23 .BaseClass .BaseOperate boperate=new C23.BaseClass.BaseOperate ();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected string M_str_sql = "select SN AS 单号序号,StockID as 进货单号,Count as 进货数量,WareID AS 品号,WareName as 品名,Unit as 规格,Spec as 单位 from tb2";
        protected int i;
        protected int M;
        protected string M_str_table = "tb2";
        
      
        
   
        public frm()
        {
            InitializeComponent();
          
       
        }

        private void frm_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“db_JXCDataSet.tb2”中。您可以根据需要移动或移除它。
            DataSet myds = boperate.getds(M_str_sql, M_str_table);

            dgrd_StockTable.DataSource = myds.Tables[0];

            DataStateControl();
         

        }
        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            opAndvalidate.autoNum("select StockID from tb2", "tb2", "StockID", "SC", "1000001", txtStockID);
        
            tsbtnSave.Enabled = true;
            M = 0;
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            DataSet myds = boperate.getds(M_str_sql, M_str_table);
            DataTable newTable = myds.Tables[0];
            try
            {
                if (M == 0)
                {
                    for (i = 0; i < dgrd_StockTable.RowCount; i++)
                    {
                        if (dgrd_StockTable[0, i].Value.ToString() == "")
                        {

                            boperate.getcom("delete tb2 where SN='" + Convert.ToString(dgrd_StockTable[0, dgrd_StockTable.CurrentCell.RowIndex].Value).ToString() + "'");
                            break;
                        }
                        else
                        {
                            boperate.getcom("insert into tb2(SN,StockID,Count,WareID,WareName,Unit,Spec) values ('" + Convert.ToString(dgrd_StockTable[0, i].Value).Trim() +
                              "','" + txtStockID.Text.Trim() + "','" + Convert.ToString(dgrd_StockTable[2, i].Value).Trim() + "','" + Convert.ToString(dgrd_StockTable[3, i].Value).Trim() +
                              "','" + Convert.ToString(dgrd_StockTable[4, i].Value).Trim() + "','" + Convert.ToString(dgrd_StockTable[5, i].Value).Trim() +
                              "','" + Convert.ToString(dgrd_StockTable[6, i].Value).Trim() + "')");
                        }
                    }
                    MessageBox.Show("数据保存成功!", "信息");
                    MessageBox.Show("数据保存成功!！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
            frm_Load(sender, e);
            tsbtnSave.Enabled = false;
        }
     
            
           
    

        private void DataStateControl()
        {
           
            int numCols = dgrd_StockTable.Columns.Count;
            for (int i = 0; i < numCols; i++)
            {
                if (i == 1)
                {
                    dgrd_StockTable.Columns[i].Width = 40;
                }
                if (i == 2)
                {
                    dgrd_StockTable.Columns[i].Width = 200;
                }
                if (i == 3)
                {
                    dgrd_StockTable.Columns[i].Width = 200;
                }
                if (i != 2&& i!=0 && i !=3 && i!=1 && i!=6 && i!=7 && i !=8 && i !=9)//表中只允许编辑【数量】和【单价】两个字段
                {
                    dgrd_StockTable.Columns[i].ReadOnly = true;
                }
                if (i == 5)
                {
                    dgrd_StockTable.Columns[i].Width = 60;
                }
            }
        }

        private void dgrd_StockTable_DoubleClick(object sender, EventArgs e)
        {
            if (dgrd_StockTable.CurrentCell.ColumnIndex == 3)
            {
                C23.BomManage.frmWareInfo frm = new C23.BomManage.frmWareInfo();
                frm.dgvReadOnlyfrm();
                frm.ShowDialog();
                setWareData();
            }
            if (dgrd_StockTable.CurrentCell.ColumnIndex == 9)
            {
                C23.StorageManage .frmStorageInfo frm = new C23.StorageManage .frmStorageInfo ();
                frm.dgvReadOnlyfrm();
                frm.ShowDialog();
                setStorageType();
            }
            if (dgrd_StockTable.CurrentCell.ColumnIndex == 9)
            {
                C23.StorageManage .frmLocationInfo frm = new C23.StorageManage.frmLocationInfo ();
                frm.dgvReadOnlyfrm();
                frm.ShowDialog();
                setLocationName();
            }
       
        
        }

        //-------将双击选择得到的商品信息显示到进货单的表格中--------
        private  void setWareData()
        {
           
                dgrd_StockTable[3, dgrd_StockTable.CurrentCell.RowIndex].Value = inputDataGridArray[0];
                dgrd_StockTable[4, dgrd_StockTable.CurrentCell.RowIndex].Value= inputDataGridArray[1];
                dgrd_StockTable[5, dgrd_StockTable.CurrentCell.RowIndex].Value = inputDataGridArray[2];
                dgrd_StockTable[6, dgrd_StockTable.CurrentCell.RowIndex].Value = inputDataGridArray[3];
          
              
            }
        public void setStorageType()
        {

            dgrd_StockTable[2, dgrd_StockTable.CurrentCell.RowIndex].Value = inputStorage[0];
           

        }
        public void setLocationName()
        {

            dgrd_StockTable[9, dgrd_StockTable.CurrentCell.RowIndex].Value = inputLocation[0];
           ;


        }

        private void dgrd_StockTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (i = 0; i < dgrd_StockTable.Rows.Count - 1; i++)
            {
                dgrd_StockTable[0, i].Value = i + 1;
            }
          
        }

        private void dgrd_StockTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



    }
  }

