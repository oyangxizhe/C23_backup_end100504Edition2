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
    public partial class frmMateReT : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected int i;
        public static string[] inputTextDataWare = new string[] { null, null, null, null };
        public static string[] inputTextDataStorage = new string[] { "", "" };
        public static string[] inputgetSEName = new string[] { "" };
     public frmMateReT()
     {
            InitializeComponent();
            this.cboxMateRer.Items.Add("");
     }

     private void frmMateReT_Load(object sender, EventArgs e)
     {
         BindData();
         dgvStateControl();
     }
     private void tsbtnAdd_Click(object sender, EventArgs e)
     {
         string year = DateTime.Now.ToString("yy");
         string month = DateTime.Now.ToString("MM");
         opAndvalidate.num("select Year,Month,MateReID from tb_MateRe", "select * from tb_MateRe where Year='" + year +
             "' and Month='" + month + "'", "tb_MateRe", "MateReID", "MR", "0001", txtMateReID);
         tsbtnSave.Enabled = true;
         ClearText();
     }
     public void ClearText()
     {
         cboxMateRer.Text = "";
      }

     private void tsbtnSave_Click(object sender, EventArgs e)
     {
       
         bn.Validate();
         string year, month;
         year = DateTime.Now.ToString("yy");
         month = DateTime.Now.ToString("MM");
         string RootName = "领料单";

         for (i = 0; i < dt.Rows.Count; i++)
         {

             if (dt.Rows[i][0].ToString() == "")
             {

             }
             else
             {
                 if (dt.Rows[i][1].ToString() == "")
                 {
                     MessageBox.Show("品号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
                 else
                 {
                     if (dt.Rows[i][5].ToString() == "")
                     {
                         MessageBox.Show("领料数量不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }

                     else
                     {
                         if (dt.Rows[i][6].ToString() == "")
                         {
                             MessageBox.Show("仓库类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         }
                         else
                         {
                             if (dt.Rows[i][7].ToString() == "")
                             {
                                 MessageBox.Show("库位名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             }
                             else
                             {
                                 string varSN = dt.Rows[i][0].ToString();
                                 string varID = txtMateReID.Text;
                                 string varWareID = dt.Rows[i][1].ToString();
                                 string varWareName = dt.Rows[i][2].ToString();
                                 string varSpec = dt.Rows[i][3].ToString();
                                 string varUnit = dt.Rows[i][4].ToString();
                                 decimal varMRCount = decimal .Parse (dt.Rows[i][5].ToString());
                                 string varStorageType = dt.Rows[i][6].ToString();
                                 string varLocationName = dt.Rows[i][7].ToString();
                                 string varMateRer = cboxMateRer.Text.Trim();
                                 DateTime varMateReDate1 = Convert.ToDateTime(dtpMateReDate.Text.Trim());
                                 string varMateReDate = varMateReDate1.ToShortDateString();
                                 string varMaker = frmLogin.M_str_name;
                                 DateTime varDate1 = Convert.ToDateTime(DateTime.Now.ToLongDateString());
                                 string varDate = varDate1.ToShortDateString();
                                 string varTime = DateTime.Now.ToLongTimeString();
                                 SqlDataReader sqlread = boperate.getread("select StorageCount from tb_StorageCase where WareID='" + varWareID +
                                 "' and StorageType='" + varStorageType  + "' and LocationName='" + varLocationName + "'");
                                 sqlread.Read();
                               decimal  vargetStorageCount,varupdateStorageCount;
                               if (sqlread.HasRows)
                                 {
                                 vargetStorageCount = Convert.ToDecimal (sqlread["StorageCount"]);
                                 if (vargetStorageCount >= varMRCount)
                                 {
                                     
                                     #region MateReT
                                     string varsendValues = "('" + varSN + "','" + varID + "','" + year + "','" + month +
                                 "','" + varWareID + "','" + varWareName + "','" + varSpec + "','" + varUnit +
                                 "','" + varMRCount + "','" + varStorageType + "','" + varLocationName + "','" + varMateReDate +
                                 "','" + varMateRer + "','" + varMaker + "','" + varDate + "','" + varTime + "')";
                                     boperate.getcom("insert into tb_MateRe(SN,MateReID,Year,Month,WareID,WareName,Spec,Unit,"
                                     + "MRCount,StorageType,LocationName,MateReDate,MateRer,Maker,Date,Time) values " + varsendValues);
                                     #endregion
                                     boperate.getcom("insert into tb_Verify(VerifyID) values ('" + varID + "')");
                                     varupdateStorageCount = vargetStorageCount - varMRCount;
                                     boperate.getcom("update tb_StorageCase set StorageCount='" + varupdateStorageCount + "'where WareID='" + varWareID + "'and StorageType='" + varStorageType + "' and LocationName='" + varLocationName + "'");
                                     #region Inventory
                                     boperate.getcom("insert into tb_Inventory(Year,Month,SN,RootID,RootName,WareID,WareName,Spec,Unit,MRCount,StorageType,LocationName,Maker,Date,"
                           + "Time) values ('" + year + "','" + month + "','" + varSN + "','" + varID + "','" + RootName + "','" + varWareID + "','" + varWareName + "','" + varSpec + "','" + varUnit +
                           "','" + varMRCount + "','" + varStorageType + "','" + varLocationName + "','" + varMaker + "','" + varDate + "','" + varTime + "')");
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


                             }

                         }
                     }
                 }
             }

         }
          dt.Clear();
         frmMateReT_Load(sender, e);
     }

     private void tsbtnDel_Click(object sender, EventArgs e)
     {
         foreach (DataGridViewRow r in dgvMAInfo.SelectedRows)
         {
             if (!r.IsNewRow)
             {
                 dgvMAInfo.Rows.Remove(r);

             }
         }
     }
     #region BindData
     private void BindData()
     {
         dt = total1();

         dgvMAInfo.DataSource = dt;

         for (i = 0; i < dgvMAInfo.Columns.Count - 1; i++)
         {
             dgvMAInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;



             if (i == 1 || i == 5 || i == 6 || i == 7)
             {
                 dgvMAInfo.Columns[i].DefaultCellStyle.BackColor = Color.OldLace;
             }
         }


     }
     #endregion
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

             if (i != 1 && i != 5 && i != 6 && i != 7)
             {
                 dgvMAInfo.Columns[i].ReadOnly = true;

             }

            if (i == 1 || i == 2)
             {
                 dgvMAInfo.Columns[i].Width = 200;
             }
         }
     }
     #endregion
     #region total1
     private DataTable total1()
     {
         dt = new DataTable();
         dt.Columns.Add("序号", typeof(string));
         dt.Columns.Add("品号", typeof(string));
         dt.Columns.Add("品名", typeof(string));
         dt.Columns.Add("规格", typeof(string));
         dt.Columns.Add("单位", typeof(string));
         dt.Columns.Add("领料数量", typeof(decimal));
         dt.Columns.Add("仓库类型", typeof(string));
         dt.Columns.Add("库位名称", typeof(string));
         dt.Columns.Add("领料员", typeof(string));
         dt.Columns.Add("领料日期", typeof(DateTime));
         dt.Columns.Add("制单人", typeof(char));
         dt.Columns.Add("制单日期", typeof(DateTime));
         dt.Columns.Add("制单时间", typeof(string));
         return dt;
     }
     #endregion

     private void tsbtnExit_Click(object sender, EventArgs e)
     {
         this.Close();
     }
    private void setStorageData()
     {
         dgvMAInfo.Rows[dgvMAInfo.CurrentCell.RowIndex].Cells[6].Value = inputTextDataStorage[0];

     }
     private void setLocationData()
     {
         dgvMAInfo.Rows[dgvMAInfo.CurrentCell.RowIndex].Cells[7].Value = inputTextDataStorage[1];
     }
    private void dgvMAInfo_CellClick(object sender, DataGridViewCellEventArgs e)
     {
         if (dgvMAInfo.CurrentCell.ColumnIndex == 1)
         {
             C23.BomManage.frmWareInfo frm = new C23.BomManage.frmWareInfo();
             frm.MateReT();
             frm.ShowDialog();
             setWareData();
         } 
        if (dgvMAInfo.CurrentCell.ColumnIndex == 6)
         {
             C23.StorageManage.frmStorageCase  frm = new frmStorageCase ();
             frm.MateReT();
             frm.ShowDialog();
             setStorageData();
         }
         if (dgvMAInfo.CurrentCell.ColumnIndex == 7)
         {
             C23.StorageManage.frmStorageCase  frm = new frmStorageCase ();
             frm.MateReT();
             frm.ShowDialog();
             setLocationData();
         }
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

     private void dgvMAInfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
     {
         for (i = 0; i < dgvMAInfo.Rows.Count - 1; i++)
         {
            dgvMAInfo[0, i].Value = i + 1;
          }
     }

    
     private void setWareData()
     {
         dgvMAInfo[1, dgvMAInfo.CurrentCell.RowIndex].Value = inputTextDataWare[0];
         dgvMAInfo[2, dgvMAInfo.CurrentCell.RowIndex].Value = inputTextDataWare[1];
         dgvMAInfo[3, dgvMAInfo.CurrentCell.RowIndex].Value = inputTextDataWare[2];
         dgvMAInfo[4, dgvMAInfo.CurrentCell.RowIndex].Value = inputTextDataWare[3];
     }

     private void   ComplexMateRerInfo()
     {
         this.cboxMateRer.IntegralHeight = false;//使组合框不调整大小以显示其所有项
         this.cboxMateRer.DroppedDown = false;//使组合框不显示其下拉部分
         this.cboxMateRer.Items[0] = inputgetSEName[0];
         this.cboxMateRer.SelectedIndex = 0;
         this.cboxMateRer.IntegralHeight = true;//恢复默认值

     }

     private void cboxMateRer_DropDown(object sender, EventArgs e)
     {
         C23.EmployeeManage.frmEmployeeInfo frm = new C23.EmployeeManage.frmEmployeeInfo();
         frm.MateReT();
         frm.ShowDialog();
         ComplexMateRerInfo();
     }

      
    }
}
