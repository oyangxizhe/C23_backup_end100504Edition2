using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace C23.StockManage
{
    public partial class frmStockTable : Form
    {
        
      
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected string M_str_sql = "select StockID as 进货单号,StockDate as 进货日期,StockCount as 进货数量,SPurOrdersID as 采购单号,SPCount as 采购数量,"
            +"SCheckCount as 验收数量,StokerID as 供运商编号,StokerName as 供运商名称,SWareID as 品号,SWareName as 品名,Spec as 规格,SUnit as 单位,"
            + "SPUnitPrice as 采购单价,STaxRate as 税率,SPur as 采购员,SAcceptor as 验收人,StorageType as 仓库类型,SLocationName as 库位名称,"
            + "STotalCount as 合计金额,SNoTax as 不含税金额,STax as 税额,SMaker as 制单人,SDate as 制单日期, STime as 制单时间 from tb_StockTable";
        protected string M_str_table = "tb_StockTable";
        protected int M_int_judge;
        public static string[] inputTextDataStoker = new string [] {"",""};
        public static string[] inputTextDataWare= new string[] { "", "","",""};
        public static string[] inputTextDataStorage = new string[] { "" };
        public static string[] inputTextDataLocation = new string[] { "" };
        public static string[] inputDataGridArray = new string[] { null, null,null,null };
        public static string[] strpub = new string[] { null, null, null, null };
        public static string[] inputgetSEName = new string[] { "" };
        public static string[] getPurInfo = new string[] {"","","","","","","","","","","" };

      
        public frmStockTable()
        {
            InitializeComponent();
            this.cboxStokerID.Items.Add("");
            this.cboxSWareID.Items.Add("");
            this.cboxStorageType.Items.Add("");
            this.cboxSLocationName.Items.Add("");
            this.cboxSPurOrdersID.Items.Add("");
            this.cboxSPur.Items.Add("");
            this.cboxSAcceptor.Items.Add("");
            
        }
        public void dgvReadOnlyRe()
        {
            dgvStockInfo.ReadOnly = true;

        }
        private void dgvStockInfo_DoubleClick(object sender, EventArgs e)
        {
            if (dgvStockInfo.ReadOnly == true)
            {
                int indexRow = dgvStockInfo.CurrentCell.RowIndex;
                string varStockID, varCheckCount, varStokerID, varPStokerName, varPWareID, varPWareName, varPSpec, varPUnit, varPUnitPrice, varPTaxRate, varStorageType, varLocationName;
                varStockID = dgvStockInfo.Rows[indexRow].Cells[0].Value.ToString().Trim();
                varCheckCount = dgvStockInfo.Rows[indexRow].Cells[5].Value.ToString().Trim();
                varStokerID = dgvStockInfo.Rows[indexRow].Cells[6].Value.ToString().Trim();
                varPStokerName = dgvStockInfo.Rows[indexRow].Cells[7].Value.ToString().Trim();
                varPWareID = dgvStockInfo.Rows[indexRow].Cells[8].Value.ToString().Trim();
                varPWareName = dgvStockInfo.Rows[indexRow].Cells[9].Value.ToString().Trim();
                varPSpec = dgvStockInfo.Rows[indexRow].Cells[10].Value.ToString().Trim();
                varPUnit = dgvStockInfo.Rows[indexRow].Cells[11].Value.ToString().Trim();
                varPUnitPrice = dgvStockInfo.Rows[indexRow].Cells[12].Value.ToString().Trim();
                varPTaxRate = dgvStockInfo.Rows[indexRow].Cells[13].Value.ToString().Trim();
                varStorageType = dgvStockInfo.Rows[indexRow].Cells[16].Value.ToString().Trim();
                varLocationName = dgvStockInfo.Rows[indexRow].Cells[17].Value.ToString().Trim();
                string[] arryPur = new string[] { varStockID, varCheckCount, varStokerID, varPStokerName, varPWareID, varPWareName, varPSpec, varPUnit, varPUnitPrice, varPTaxRate, varStorageType, varLocationName };
                C23.StockManage.frmReturn.getStockInfo[0] = arryPur[0];
                C23.StockManage.frmReturn.getStockInfo[1] = arryPur[1];
                C23.StockManage.frmReturn.getStockInfo[2] = arryPur[2];
                C23.StockManage.frmReturn.getStockInfo[3] = arryPur[3];
                C23.StockManage.frmReturn.getStockInfo[4] = arryPur[4];
                C23.StockManage.frmReturn.getStockInfo[5] = arryPur[5];
                C23.StockManage.frmReturn.getStockInfo[6] = arryPur[6];
                C23.StockManage.frmReturn.getStockInfo[7] = arryPur[7];
                C23.StockManage.frmReturn.getStockInfo[8] = arryPur[8];
                C23.StockManage.frmReturn.getStockInfo[9] = arryPur[9];
                C23.StockManage.frmReturn.getStockInfo[10] = arryPur[10];
                C23.StockManage.frmReturn.getStockInfo[11] = arryPur[11];

                this.Close();
            }

        }
        private void dgvStockInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtStockID.Text = Convert.ToString(dgvStockInfo[0, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            dtpSDate.Text = Convert.ToString(dgvStockInfo[1, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            txtStockCount.Text = Convert.ToString(dgvStockInfo[2, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            cboxSPurOrdersID.Text = Convert.ToString(dgvStockInfo[3, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            txtSPCount.Text = Convert.ToString(dgvStockInfo[4, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            txtSCheckCount.Text = Convert.ToString(dgvStockInfo[5, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            cboxStokerID.Text = Convert.ToString(dgvStockInfo[6, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            txtStokerName.Text = Convert.ToString(dgvStockInfo[7, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            cboxSWareID.Text = Convert.ToString(dgvStockInfo[8, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            txtSWareName.Text = Convert.ToString(dgvStockInfo[9, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            cboxSpec.Text = Convert.ToString(dgvStockInfo[10, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            cboxSUnit.Text = Convert.ToString(dgvStockInfo[11, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            txtSPUnitPrice.Text = Convert.ToString(dgvStockInfo[12, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            txtSTaxRate.Text = Convert.ToString(dgvStockInfo[13, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            cboxSPur.Text = Convert.ToString(dgvStockInfo[14, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            cboxSAcceptor.Text = Convert.ToString(dgvStockInfo[15, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            cboxStorageType.Text = Convert.ToString(dgvStockInfo[16, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            cboxSLocationName.Text = Convert.ToString(dgvStockInfo[17, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            txtSTotalCount.Text = Convert.ToString(dgvStockInfo[18, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            txtSNoTax.Text = Convert.ToString(dgvStockInfo[19, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();
            txtSTax.Text = Convert.ToString(dgvStockInfo[20, dgvStockInfo.CurrentCell.RowIndex].Value).Trim();

        }
        private void cboxSPurOrdersID_DropDown(object sender, EventArgs e)
        {
            C23.PUR.frmPurOrders frm = new C23.PUR.frmPurOrders();
            frm.dgvReadOnlyPur();
            frm.ShowDialog();
            ComplexPurInfo();
        }
        private void ComplexPurInfo()
        {
            this.cboxSPurOrdersID.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxSPurOrdersID.DroppedDown = false;//使组合框不显示其下拉部分
            cboxSPurOrdersID.Items[0] = getPurInfo[0];
            txtSPCount.Text = getPurInfo[1];
            cboxStokerID.Text = getPurInfo[2];
            txtStokerName.Text = getPurInfo[3];
            cboxSWareID.Text = getPurInfo[4];
            txtSWareName.Text = getPurInfo[5];
            cboxSpec.Text = getPurInfo[6];
            cboxSUnit.Text = getPurInfo[7];
            txtSPUnitPrice.Text= getPurInfo[8];
            txtSTaxRate.Text = getPurInfo[9];
            cboxSPur.Text = getPurInfo[10];
            this.cboxSPurOrdersID.SelectedIndex = 0;
            this.cboxSPurOrdersID.IntegralHeight = true;//恢复默认值

        }

        private void cboxSAcceptor_DropDown(object sender, EventArgs e)
        {
            C23.EmployeeManage.frmEmployeeInfo frm = new C23.EmployeeManage.frmEmployeeInfo();
            frm.dgvReadOnlyStock();
            frm.ShowDialog();
            getAcceptorData();
        }
        private void getAcceptorData()
        {
            this.cboxSAcceptor.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxSAcceptor.DroppedDown = false;//使组合框不显示其下拉部分
            this.cboxSAcceptor.Items[0] = inputgetSEName[0];
            this.cboxSAcceptor.SelectedIndex = 0;
            this.cboxSAcceptor.IntegralHeight = true;//恢复默认值
        }
       
        
        private void getEPurData()
        {
            this.cboxSPur.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxSPur.DroppedDown = false;//使组合框不显示其下拉部分
            cboxSPur.Items[0] = inputgetSEName[0];
            this.cboxSPur.SelectedIndex = 0;

            this.cboxSPur.IntegralHeight = true;//恢复默认值
        }
        private void cboxSPur_DropDown(object sender, EventArgs e)
        {
            C23.EmployeeManage.frmEmployeeInfo frm = new C23.EmployeeManage.frmEmployeeInfo();
            frm.dgvReadOnlyStock();
            frm.ShowDialog();
            getEPurData();
        }
       
        private void cboxSLocation_DropDown(object sender, EventArgs e)
        {
            C23.StorageManage.frmLocationInfo newFrm = new C23.StorageManage.frmLocationInfo();
            newFrm.dgvReadOnlyStock();
            newFrm.ShowDialog();
            setLocationData();
            SendKeys.Send("{Tab}");//向活动应用程序发送Tab键,跳到下一控件
        }
        private void setLocationData()
        {
            this.cboxSLocationName.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxSLocationName.DroppedDown = false;//使组合框不显示其下拉部分
            this.cboxSLocationName.Items[0] = inputTextDataLocation[0];
            this.cboxSLocationName.SelectedIndex = 0;

            this.cboxSLocationName.IntegralHeight = true;//恢复默认值
        }

        private void setStorageData()
        {
            this.cboxStorageType.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxStorageType.DroppedDown = false;//使组合框不显示其下拉部分
            this.cboxStorageType.Items[0] = inputTextDataStorage[0];
            this.cboxStorageType.SelectedIndex = 0;
          
            this.cboxStorageType.IntegralHeight = true;//恢复默认值
        }
              private void cboxStorage_DropDown(object sender, EventArgs e)
        {
            C23.StorageManage.frmStorageInfo newFrm = new C23 .StorageManage .frmStorageInfo();
            newFrm.dgvReadOnlyStock();
            newFrm.ShowDialog();
            setStorageData();
            SendKeys.Send("{Tab}");//向活动应用程序发送Tab键,跳到下一控件
        }
 
        private void cboxSWareID_DropDown(object sender, EventArgs e)
        {
            C23.BomManage.frmWareInfo newFrm = new C23.BomManage.frmWareInfo();
            newFrm.setDataGridReadOnly();
            newFrm.ShowDialog();
            setWareData();
            SendKeys.Send("{Tab}");//向活动应用程序发送Tab键,跳到下一控件
        }

     
        private void setWareData()
        {

            this.cboxSWareID.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxSWareID.DroppedDown = false;//使组合框不显示其下拉部分
            this.cboxSWareID.Items[0] = inputTextDataWare[0];
            this.cboxSWareID.SelectedIndex = 0;
            this.txtSWareName.Text = inputTextDataWare[1];
            this.cboxSpec.Text = inputTextDataWare[2];
            this.cboxSUnit.Text = inputTextDataWare[3];

            this.cboxSWareID.IntegralHeight = true;//恢复默认值
        }
     

    
        private void setStokerData()
        {
            this.cboxStokerID.IntegralHeight = false;//使组合框不调整大小以显示其所有项
            this.cboxStokerID.DroppedDown = false;//使组合框不显示其下拉部分
            this.cboxStokerID.Items[0] = inputTextDataStoker[0];
            this.cboxStokerID.SelectedIndex = 0;
            this.txtStokerName.Text = inputTextDataStoker[1];
            this.cboxStokerID.IntegralHeight = true;//恢复默认值
        }

        private void cboxStokerID_DropDown(object sender, EventArgs e)
        {
         C23.PUR.frmStokerInfo newFrm = new C23.PUR.frmStokerInfo();
            newFrm.setDataGridReadOnly();
            newFrm.ShowDialog();
            setStokerData();
            SendKeys.Send("{Tab}");//向活动应用程序发送Tab键,跳到下一控件
        }
       
        private void frmStockTable_Load(object sender, EventArgs e)
        {
            
            
            DataSet myds = boperate.getds(M_str_sql, M_str_table);
            dgvStockInfo.DataSource = myds.Tables[0];
            if (myds.Tables[0].Rows.Count > 0)
                tsbtnDel.Enabled = true;
            else
                tsbtnDel.Enabled = false;
        }

        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            opAndvalidate.autoNum("select StockID from tb_StockTable", "tb_StockTable", "StockID", "SC", "1000001", txtStockID);
            tsbtnSave.Enabled = true;
            M_int_judge = 0;
            ClearText();
         
         
        }

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            tsbtnSave.Enabled = true;
            M_int_judge = 1;
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            string  IRootName = "进货单";
            string varSCheckCount=txtSCheckCount .Text ;

            string varSTaxRate = txtSTaxRate.Text;
            string varSUnitPrice = txtSPUnitPrice.Text;
             int varSCC=Convert .ToInt32 (varSCheckCount );
            decimal  varSUP = Convert .ToDecimal(varSUnitPrice);
            decimal varSTR = Convert.ToDecimal(varSTaxRate);
           
            decimal  varSTotalCount = varSCC * varSUP;
            decimal  varSTax=varSCC *varSUP*varSTR ;
            decimal varSNoTax = varSTotalCount - varSTax;
           string varSTC = Convert.ToString(varSTotalCount);
           string varST = Convert.ToString(varSTax);
           string varSNT = Convert.ToString(varSNoTax);
     
           txtSTotalCount.Text = varSTC;
           txtSNoTax.Text = varSNT;
           txtSTax.Text = varST;
          if (M_int_judge == 0)
            {
                if (txtStokerName.Text == "")
                {
                    MessageBox.Show("供运商名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                else
                {
                    boperate.getcom("insert into tb_StockTable(StockID,SPurOrdersID,SPCount,StokerName,StockDate,"
                    +"StokerID,SPur,SMaker,SDate,STime,SWareID,SWareName,Spec,SUnit,StockCount,SCheckCount,SAcceptor,"
                    +"StorageType,SLocationName,SPUnitPrice,STaxRate,STotalCount,SNoTax,STax) values('" + txtStockID.Text.Trim() +
                    "','"+cboxSPurOrdersID .Text .Trim ()+"','"+txtSPCount .Text .Trim ()+"','" + txtStokerName.Text.Trim() + "','" + dtpSDate.Text.Trim() + "','" + cboxStokerID.Text.Trim() +
                    "','" + cboxSPur.Text.Trim() + "','" + frmLogin.M_str_name + "','" + DateTime.Now.ToLongDateString() +
                    "','" + DateTime.Now.ToLongTimeString() +"','"+cboxSWareID.Text .Trim ()+"','"+txtSWareName.Text .Trim ()+
                    "','"+cboxSpec .Text .Trim ()+"','"+cboxSUnit .Text .Trim ()+"','"+txtStockCount .Text .Trim ()+"','"+txtSCheckCount .Text .Trim ()+
                    "','"+cboxSAcceptor .Text .Trim ()+"','"+cboxStorageType .Text .Trim ()+"','"+cboxSLocationName .Text .Trim ()+
                    "','"+txtSPUnitPrice .Text .Trim ()+"','"+txtSTaxRate .Text .Trim ()+"','"+varSTC +
                    "','"+varSNT+"','"+varST +"')");
                    
                    boperate.getcom("insert into tb_Inventory(IRootID,IRootName,IWareID,IWareName,ISpec,IUnit,InCount,IStorageType,ILocationName,IMaker,IDate,"
                        + "ITime) values ('"+txtStockID.Text .Trim ()+"','"+IRootName+"','" + cboxSWareID.Text.Trim() + "','" + txtSWareName.Text.Trim() + "','" + cboxSpec.Text.Trim() +
                        "','"+cboxSUnit .Text .Trim ()+"','"+txtSCheckCount .Text .Trim ()+"','"+cboxStorageType.Text .Trim ()+
                        "','" + cboxSLocationName.Text.Trim() + "','" + frmLogin.M_str_name + "','" + DateTime.Now.ToLongDateString() +
                    "','" + DateTime.Now.ToLongTimeString() + "')");
                    SqlDataReader sqlread=boperate .getread("Select CWareID,CStorageType,CLocationName,CStorageCount from tb_StorageCase where CWareID='"+cboxSWareID.Text.Trim()+
                        "' and CStorageType='"+cboxStorageType.Text.Trim()+"' and CLocationName='"+cboxSLocationName.Text .Trim ()+"'");
                         sqlread.Read();
                    if (sqlread.HasRows)
                     {
                         int vargetStorageCount = Convert.ToInt32(sqlread["CStorageCount"]);
                         string varSc= txtSCheckCount.Text;
                         int varCurrentStorageCount = Convert.ToInt32(varSc);
                         int varStorageCount = vargetStorageCount +varCurrentStorageCount;
                         string varCount = Convert.ToString(varStorageCount);
                         boperate.getcom("update tb_StorageCase set  CheckCount='"+txtSCheckCount.Text.Trim()+"',CStorageCount='" + varCount +
                             "'where CWareID='" + cboxSWareID.Text.Trim() + "' and CStorageType='" + cboxStorageType.Text.Trim() + "' and CLocationName='" + cboxSLocationName.Text.Trim() + "'");
                       }
                    else 
                    {
                     boperate.getcom("insert into tb_StorageCase(CRootID,CWareID,CWareName,CSpec,CUnit,CStorageType,CLocationName,"
                        + "CheckCount,CStorageCount) values ('"+txtStockID .Text .Trim ()+"','" + cboxSWareID.Text.Trim() + "','" + txtSWareName.Text.Trim() + 
                        "','" + cboxSpec.Text.Trim() +"','" + cboxSUnit.Text.Trim() + "','" + cboxStorageType.Text.Trim() + "','" + cboxSLocationName.Text.Trim() +
                          "','"+txtSCheckCount .Text .Trim ()+"','" + txtSCheckCount.Text.Trim()+ "')");
                    }
                    sqlread .Close ();
                    boperate.getcom("insert into tb_PayPart(PPRootID,PPRootName,PPDate,PPTime,PPWareID,PPWareName,PPStokerID,PPStokerName,PPCheckCount,PPUnitPrice,PPTaxRate,"
                   + "PPTotalCount,PPNoTax,PPTax) values ('" + txtStockID.Text.Trim() + "','" + IRootName + "','" + DateTime.Now.ToLongDateString() + "','" + DateTime.Now.ToLongTimeString() + 
                   "','" + cboxSWareID.Text.Trim() + "','" + txtSWareName.Text.Trim() +
                   "','" + cboxStokerID.Text.Trim() + "','" + txtStokerName.Text.Trim() + "','" + txtSCheckCount.Text.Trim() + "','" + txtSPUnitPrice.Text.Trim() +
                   "','" + txtSTaxRate.Text.Trim() + "','" + varSTC + "','" + varSNT +
                   "','" + varST + "')");
                  SqlDataReader sqlreadPay = boperate.getread("select APTotalCount,APNoTax,APTax from tb_AcPay where APStokerID='" + cboxStokerID.Text.Trim() + "'");
                    sqlreadPay.Read();
                    decimal varAPTotalCount;
                    decimal varAPNoTax;
                    decimal varAPTax;
                    decimal varupdateAPTotalCount ;
                    decimal varupdateAPNoTax ;
                    decimal varupdateAPTax;
                    string varAPTC ;
                    string varAPNT ;
                    string varAPT ;
                 if (sqlreadPay.HasRows)
                    {
                         varAPTotalCount = Convert.ToDecimal(sqlreadPay["APTotalCount"]);
                        varAPNoTax = Convert.ToDecimal(sqlreadPay["APNoTax"]);
                        varAPTax = Convert.ToDecimal(sqlreadPay["APTax"]);
                       varupdateAPTotalCount = varSTotalCount + varAPTotalCount;
                         varupdateAPNoTax = varSNoTax + varAPNoTax;
                         varupdateAPTax = varSTax + varAPTax;
                       varAPTC = Convert.ToString(varupdateAPTotalCount);
                        varAPNT = Convert.ToString(varupdateAPNoTax);
                        varAPT = Convert.ToString(varupdateAPTax);
                       boperate.getcom("update tb_AcPay set APTotalCount='" + varAPTC + "',APNoTax='" + varAPNT+ "', APTax='"+varAPT+
                            "',APLastTotalCount='"+varSTC +"',APLastNoTax='"+varSNT+"',APLastTax='"+varST +"' where APStokerID='" + cboxStokerID.Text.Trim() + "'");

                    }
                    else
                    {
                      boperate.getcom("insert into tb_AcPay(APStokerID,APStokerName,"
                            + "APTotalCount,APNoTax,APTax,APLastTotalCount,APLastNoTax,APLastTax) values ('" + cboxStokerID.Text.Trim() + "','" + txtStokerName.Text.Trim() + "','" + varSTC +
                            "','" + varSNT + "','" + varST + "','"+varSTC +"','"+varSNT +"','"+varST +"')");
                      }
                    sqlreadPay.Close();
                    frmStockTable_Load(sender, e);
                    MessageBox.Show("信息添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tsbtnSave.Enabled = false;
                }
            }
       
            if (M_int_judge == 1)
            {
                if (txtStokerName.Text == "")
                {
                    MessageBox.Show("供运商名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    boperate.getcom("update tb_StockTable set StockDate='" + dtpSDate.Text.Trim() + "',SPurOrdersID='"+cboxSPurOrdersID.Text .Trim ()+
                        "',SPCount='"+txtSPCount.Text .Trim ()+"',StokerID='"+cboxStokerID .Text .Trim ()+
                        "',StokerName='"+txtStokerName.Text.Trim()+"',SPur='"+cboxSPur .Text .Trim ()+"',SWareID='"+cboxSWareID .Text .Trim ()+
                        "',SWareName='"+txtSWareName.Text .Trim ()+"',Spec='"+cboxSpec.Text .Trim ()+"',SUnit='"+cboxSUnit.Text .Trim ()+
                        "',StockCount='"+txtStockCount.Text .Trim ()+"',SCheckCount='"+txtSCheckCount.Text .Trim ()+
                        "',SAcceptor='"+cboxSAcceptor.Text .Trim ()+"',StorageType='"+cboxStorageType.Text.Trim()+"',SLocationName='"+cboxSLocationName.Text .Trim ()+
                        "',SMaker='" + frmLogin.M_str_name + "',SDate='"+DateTime .Now .ToLongDateString()+"',STime='"+DateTime .Now .ToLongTimeString()+
                        "',SPUnitPrice='"+txtSPUnitPrice .Text .Trim ()+"',STaxRate='"+txtSTaxRate .Text .Trim ()+
                        "',STotalCount='"+varSTC +"',SNoTax='"+varSNT +"',STax='"+varST +
                        "' where StockID='"+txtStockID.Text .Trim ()+"'");
                    boperate.getcom("update tb_Inventory set IWareID='" + cboxSWareID.Text.Trim() + "',IWareName='" + txtSWareName.Text.Trim() + 
                        "',ISpec='" + cboxSpec.Text.Trim() + "',IUnit='" + cboxSUnit.Text.Trim() + "',InCount='" + txtSCheckCount.Text.Trim() +
                        "',IStorageType='" + cboxStorageType.Text.Trim() + "',ILocationName='" + cboxSLocationName.Text.Trim() + 
                        "',IMaker='" + frmLogin.M_str_name + "',IDate='" + DateTime.Now.ToLongDateString() +
                   "',ITime='" + DateTime.Now.ToLongTimeString() + "' where IRootID='" + txtStockID.Text.Trim() + "'");
                    SqlDataReader sqlread = boperate.getread("Select CWareID,CStorageType,CLocationName,CheckCount,CStorageCount from tb_StorageCase where CWareID='" + cboxSWareID.Text.Trim() +
                        "' and CStorageType='" + cboxStorageType.Text.Trim() + "' and CLocationName='" + cboxSLocationName.Text.Trim() + "'");
                    sqlread.Read();
                    if (sqlread.HasRows)
                    {   
                        int varCheckCount = Convert.ToInt32(sqlread["CheckCount"]);
                        int vargetStorageCount = Convert.ToInt32(sqlread["CStorageCount"]);
                        string varsc = txtSCheckCount.Text;
                        int varCurrentStorageCount = Convert.ToInt32(varsc);
                        int varStorageCount,vara;
                        
                        if (varCurrentStorageCount > varCheckCount)
                        {
                             vara = varCurrentStorageCount - varCheckCount;
                            varStorageCount = vargetStorageCount + vara;
                        }
                        else
                        {
                             vara = varCheckCount - varCurrentStorageCount;
                             varStorageCount = vargetStorageCount - vara;
                        }
                  
                        string varCurrent = Convert.ToString(varStorageCount);

                        boperate.getcom("update tb_StorageCase  set CheckCount='"+txtSCheckCount .Text .Trim ()+"',CStorageCount='" + varCurrent +
                            "' where CWareID='" + cboxSWareID.Text.Trim() + "'and CStorageType='" + cboxStorageType.Text.Trim() + 
                            "' and CLocationName='" + cboxSLocationName.Text.Trim() + "'");
                    }
                    else
                    {
                        boperate.getcom("update tb_StorageCase set CWareID='" + cboxSWareID.Text.Trim() + "',CWareName='" + txtSWareName.Text.Trim() +
                            "',CSpec='" + cboxSpec.Text.Trim() + "',CUnit='" + cboxSUnit.Text.Trim() + "',CStorageType='" + cboxStorageType.Text.Trim() +
                            "',CLocationName='" + cboxSLocationName.Text.Trim() + "',CStorageCount='" + txtSCheckCount.Text.Trim() +
                            "' where CRootID='" + txtStockID.Text.Trim() + "'");
                    }
                    sqlread.Close();
                    boperate.getcom("update tb_PayPart set PPWareID='"+cboxSWareID .Text .Trim ()+"',PPWareName='"+txtSWareName .Text .Trim ()+
                        "',PPStokerID='"+cboxStokerID .Text .Trim ()+"',PPStokerName='"+txtStokerName .Text .Trim ()+"',PPCheckCount='"+txtSCheckCount .Text .Trim ()+
                        "',PPUnitPrice='"+txtSPUnitPrice .Text .Trim ()+"',PPTaxRate='"+txtSTaxRate.Text .Trim ()+
                        "',PPTotalCount='" + varSTC + "',PPNoTax='" + varSNT + "',PPTax='" + varST + "',PPDate='" + DateTime.Now.ToLongDateString() +
                        "',PPTime='" + DateTime.Now.ToLongTimeString() +
                        "' where PPRootID='" + txtStockID.Text.Trim() + "'");
                   
                    SqlDataReader sqlreadupdate = boperate.getread("select APTotalCount,APNoTax,APTax,APLastTotalCount,APLastNoTax,"
                    +"APLastTax from tb_AcPay where APStokerID='"+cboxStokerID .Text .Trim ()+"'");
                    sqlreadupdate.Read();
                    
                    if (sqlreadupdate.HasRows)
                    {
                        decimal vargetAPTotalCount = Convert.ToDecimal(sqlreadupdate["APTotalCount"]);
                        decimal vargetAPNoTax = Convert.ToDecimal(sqlreadupdate["APNoTax"]);
                        decimal vargetAPTax = Convert.ToDecimal(sqlreadupdate["APTax"]);
                        decimal vargetAPLastTotalCount = Convert.ToDecimal(sqlreadupdate["APLastTotalCount"]);
                        decimal vargetAPLastNoTax = Convert.ToDecimal(sqlreadupdate["APLastNoTax"]);
                        decimal vargetAPLastTax = Convert.ToDecimal(sqlreadupdate["APLastTax"]);
                        decimal varupdateAPTotalCount,varupdateAPNoTax,varupdateAPTax;
                   
                        if (varSTotalCount > vargetAPLastTotalCount)
                        {   
                            varupdateAPTotalCount=vargetAPTotalCount +varSTotalCount -vargetAPLastTotalCount;
                            if (varSTax > vargetAPLastTax)
                            {
                                varupdateAPTax = vargetAPTax + varSTax - vargetAPLastTax;
                                varupdateAPNoTax = varupdateAPTotalCount - varupdateAPTax;
                            }
                            else
                            {

                                varupdateAPTax = vargetAPTax -( vargetAPLastTax - varSTax);
                                varupdateAPNoTax = varupdateAPTotalCount - varupdateAPTax;
                            }
                            string varAPTC = Convert.ToString(varupdateAPTotalCount);

                            string varAPNT = Convert.ToString(varupdateAPNoTax);
                            string varAPT = Convert.ToString(varupdateAPTax);

                            boperate.getcom("update tb_AcPay set APTotalCount='"+varAPTC  +"',APNoTax='"+varAPNT +
                                "',APTax='"+varAPT+"',APLastTotalCount='"+varSTC+"',APLastNoTax='"+varSNT +"',APLastTax='"+varST +
                                "'where APStokerID='"+cboxStokerID.Text .Trim ()+"' ");
                        }
                        else
                        {
                            varupdateAPTotalCount = vargetAPTotalCount -( vargetAPLastTotalCount - varSTotalCount);
                            if (varSTax > vargetAPLastTax)
                            {
                                varupdateAPTax = vargetAPTax + varSTax - vargetAPLastTax;
                                varupdateAPNoTax = varupdateAPTotalCount - varupdateAPTax;
                            }
                            else
                            {

                                varupdateAPTax = vargetAPTax -( vargetAPLastTax - varSTax);
                                varupdateAPNoTax = varupdateAPTotalCount - varupdateAPTax;
                            }

                            string varAPTC = Convert.ToString(varupdateAPTotalCount);
                            string varAPNT = Convert.ToString(varupdateAPNoTax);
                            string varAPT = Convert.ToString(varupdateAPTax);

                            boperate.getcom("update tb_AcPay set APTotalCount='" + varAPTC + "',APNoTax='" + varAPNT +
                                "',APTax='" + varAPT + "',APLastTotalCount='" + varSTC + "',APLastNoTax='" + varSNT + "',APLastTax='" + varST +
                                "'where APStokerID='" + cboxStokerID.Text.Trim() + "' ");
                        }

                    }   
                    else
                    {
                        boperate.getcom("update tb_AcPay set APTotalCount='" + varSTC+ "',APNoTax='" + varSNT +
                                    "',APTax='" + varST + "',APLastTotalCount='" + varSTC + "',APLastNoTax='" + varSNT + "',APLastTax='" + varST +
                                    "'where APStokerID='" + cboxStokerID.Text.Trim() + "' ");
                    }
                    sqlreadupdate.Close();
                    frmStockTable_Load(sender, e);
                    MessageBox.Show("信息修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tsbtnSave.Enabled = false;
                }
            }  
        }

        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要删除该条品号信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    boperate.getcom("delete from tb_StockTable where StockID='" + Convert.ToString(dgvStockInfo[0, dgvStockInfo.CurrentCell.RowIndex].Value).Trim() + "'");
                    frmStockTable_Load(sender, e);
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
            try
            {
                if (tstxtKeyWord.Text == "")
                {
                    frmStockTable_Load(sender, e);
                }
                if (tscboxCondition.Text.Trim() == "进货单号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where StockID like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvStockInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "进货日期")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where StockDate like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvStockInfo.DataSource = myds.Tables[0];
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
   

        public void ClearText()
        {
         
            cboxStokerID.Text = "";
            txtStokerName.Text = "";
            cboxSPur.Text = "";
            cboxSWareID.Text = "";
            txtSWareName.Text = "";
            txtStockCount.Text = "";
            txtSCheckCount.Text = "";
            cboxSAcceptor.Text = "";
            cboxStorageType.Text = "";
            cboxSLocationName.Text = "";
            cboxSpec.Text = "";
            cboxSUnit.Text = "";
            txtSPUnitPrice.Text = "";
            txtSTaxRate.Text = "";
            cboxSPurOrdersID.Text = "";
            txtSPCount.Text = "";
          
        }

     
     
     
  
  }

}

