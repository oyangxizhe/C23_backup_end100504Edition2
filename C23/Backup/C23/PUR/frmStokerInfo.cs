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
    public partial class frmStokerInfo : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected string M_str_sql = "select StokerID as 供运商编号,SName as 供运商名称,"
            + "SPhone as 联系电话,SFax as 传真号码,SPostCode as 邮政编码,SAddress as 联系地址,SEmail as Email,SRemark as 备注, "
            + "SMaker as 制单人,SDate as 日期,STime as 时间 from tb_StokerInfo";
        protected string M_str_table = "tb_StokerInfo";
        protected int M_int_judge,i;
        protected int M_int_read;
        public frmStokerInfo()
        {
            InitializeComponent();

        }


        public void setDataGridReadOnly()
        {
             M_int_read = 0;
            this.dgvStokerInfo.ReadOnly = true;
        }
        public void dgvReadOnlyPur()
        {
            M_int_read = 1;
           this.dgvStokerInfo.ReadOnly = true;
        }
        public void dgvReadOnlyRe()
        {
            M_int_read = 2;
            this.dgvStokerInfo.ReadOnly = true;
        }
        public void frmStockTableT()
        {
            M_int_read = 3;
            this.dgvStokerInfo.ReadOnly = true;
        }
        public void dgvReadOnlyPurT()
        {
            M_int_read = 4;
            this.dgvStokerInfo.ReadOnly = true;
        }
        public void frmReturnT()
        {
            M_int_read = 5;
            this.dgvStokerInfo.ReadOnly = true;
        }
          private void dgvStokerInfo_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgvStokerInfo.ReadOnly == true) //判断如果是在进货单中生成的窗体则不响应DataGrid的双击事件
            {
                int intCurrentRowNumber = this.dgvStokerInfo.CurrentCell.RowIndex;
                string sendStokerID, sendStokerName;
                sendStokerID = this.dgvStokerInfo.Rows[intCurrentRowNumber].Cells[0].Value.ToString().Trim();
                sendStokerName = this.dgvStokerInfo.Rows [intCurrentRowNumber].Cells[1].Value.ToString().Trim();
                string[] sendArray = new string[] { sendStokerID, sendStokerName };
                if (M_int_read == 0)
                {
                    C23.StockManage.frmStockTable.inputTextDataStoker[0] = sendArray[0];
                    C23.StockManage.frmStockTable.inputTextDataStoker[1] = sendArray[1];

                }
                if (M_int_read==1)
                {
                    C23.PUR.frmPurOrders.inputTextDataStoker[0] = sendArray[0];
                    C23.PUR.frmPurOrders.inputTextDataStoker[1] = sendArray[1];
                }
                if (M_int_read == 2)
                {
                    C23.StockManage.frmReturn.inputTextDataStoker[0] = sendArray[0];
                    C23.StockManage.frmReturn.inputTextDataStoker[1] = sendArray[1];
                }
                if (M_int_read == 3)
                {
                    C23.StockManage.frmStockTableT.inputTextDataStoker[0] = sendArray[0];
                    C23.StockManage.frmStockTableT.inputTextDataStoker[1] = sendArray[1];

                }
                if (M_int_read == 4)
                {
                    C23.PUR.frmPurOrdersT.inputTextDataStoker[0] = sendArray[0];
                    C23.PUR.frmPurOrdersT.inputTextDataStoker[1] = sendArray[1];
                }
                if (M_int_read == 5)
                {
                    C23.StockManage.frmReturnT.inputTextDataStoker[0] = sendArray[0];
                    C23.StockManage.frmReturnT.inputTextDataStoker[1] = sendArray[1];
                }
                this.Close();
            }
          }
        private void frmStokerInfo_Load(object sender, EventArgs e)
        {
            BindData();
            dgvStateControl();
        }
        private void BindData()
        {
            dt = boperate.getdt(M_str_sql);
            dgvStokerInfo.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                tsbtnDel.Enabled = true;
            }
            else
            {
                tsbtnDel.Enabled = false;
            }

            for (i = 0; i < dgvStokerInfo.Columns.Count - 1; i++)
            {
                dgvStokerInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            }
        }
        #region dgvStateControl
        private void dgvStateControl()
        {
            int numCols = dgvStokerInfo.Columns.Count;
            for (i = 0; i < numCols; i++)
            {
                dgvStokerInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (i == 0 || i == 1)
                {
                    dgvStokerInfo.Columns[i].Width = 200;
                }
                dgvStokerInfo.Columns[i].ReadOnly = true;   
            }
        }
        #endregion
        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            opAndvalidate.num("select SYear,SMonth,StokerID from tb_StokerInfo", "select * from tb_StokerInfo where SYear='" + year +
                "' and SMonth='" + month + "'", "tb_StokerInfo", "StokerID", "SK", "0001", txtStokerID); 
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
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            DateTime varDate1 = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            string varDate = varDate1.ToShortDateString();

            if (M_int_judge == 0)
            {
                if (txtSName.Text == "")
                {
                    MessageBox.Show("供运商名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!opAndvalidate.validatePhone(txtSPhone.Text.Trim()))
                    {
                        errorSFax.Clear();
                        errorSPostCode.Clear();
                        errorSEmail.Clear();
                        errorSPhone.SetError(txtSPhone, "电话号码格式不正确");
                    }
                    else if (!opAndvalidate.validateFax(txtSFax.Text.Trim()))
                    {
                        errorSPhone.Clear();
                        errorSPostCode.Clear();
                        errorSEmail.Clear();
                        errorSFax.SetError(txtSFax, "传真号码输入格式不正确");
                    }
                    else if (!opAndvalidate.validatePostCode(txtSPostCode.Text.Trim()))
                    {
                        errorSFax.Clear();
                        errorSPhone.Clear();
                        errorSEmail.Clear();
                        errorSPostCode.SetError(txtSPostCode, "邮编输入格式不正确");
                    }
                    else if (!opAndvalidate.validateEmail(txtSEmail.Text.Trim()))
                    {
                        errorSFax.Clear();
                        errorSPhone.Clear();
                        errorSPostCode.Clear();
                        errorSEmail.SetError(txtSEmail, "E-mail地址输入格式不正确");
                    }
                    else
                    {
                        errorSFax.Clear();
                        errorSPhone.Clear();
                        errorSPostCode.Clear();
                        errorSEmail.Clear();
                        boperate.getcom("insert into tb_StokerInfo(StokerID,SName,"
                            +"SYear,SMonth,SPhone,SFax,SPostCode,SAddress,SEmail,SRemark,SDate,STime,SMaker) values('" + txtStokerID.Text.Trim()
                            +"','" + txtSName.Text.Trim() + "','"+year +"','"+month +"','" + txtSPhone.Text.Trim() + "','" + txtSFax.Text.Trim() 
                            + "','" + txtSPostCode.Text.Trim() + "','" + txtSAddress.Text.Trim() + "','" + txtSEmail.Text.Trim()
                            + "','" + txtSRemark.Text.Trim() + "','"+varDate +"','"+DateTime .Now .ToLongTimeString()
                            + "','" + frmLogin.M_str_name + "')");
                        frmStokerInfo_Load(sender, e);
                        tsbtnSave.Enabled = false;
                    }
                }
            }
            if (M_int_judge == 1)
            {
                if (txtSName.Text == "")
                {
                    MessageBox.Show("供运商名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!opAndvalidate.validatePhone(txtSPhone.Text.Trim()))
                    {
                        errorSFax.Clear();
                        errorSPostCode.Clear();
                        errorSEmail.Clear();
                        errorSPhone.SetError(txtSPhone, "电话号码格式不正确");
                    }
                    else if (!opAndvalidate.validateFax(txtSFax.Text.Trim()))
                    {
                        errorSPhone.Clear();
                        errorSPostCode.Clear();
                        errorSEmail.Clear();
                        errorSFax.SetError(txtSFax, "传真号码输入格式不正确");
                    }
                    else if (!opAndvalidate.validatePostCode(txtSPostCode.Text.Trim()))
                    {
                        errorSFax.Clear();
                        errorSPhone.Clear();
                        errorSEmail.Clear();
                        errorSPostCode.SetError(txtSPostCode, "邮编输入格式不正确");
                    }
                    else if (!opAndvalidate.validateEmail(txtSEmail.Text.Trim()))
                    {
                        errorSFax.Clear();
                        errorSPhone.Clear();
                        errorSPostCode.Clear();
                        errorSEmail.SetError(txtSEmail, "E-mail地址输入格式不正确");
                    }
                    else
                    {
                        errorSFax.Clear();
                        errorSPhone.Clear();
                        errorSPostCode.Clear();
                        errorSEmail.Clear();
                        boperate.getcom("update tb_StokerInfo set SName='" + txtSName.Text.Trim()
                            + "',SPhone='" + txtSPhone.Text.Trim() + "',SFax='" + txtSFax.Text.Trim()
                            + "',SPostCode='" + txtSPostCode.Text.Trim() + "',SAddress='" + txtSAddress.Text.Trim()
                            + "',SEmail='" + txtSEmail.Text.Trim() + "',SRemark='" + txtSRemark.Text.Trim() + "' where StokerID='" + txtStokerID.Text.Trim() + "'");
                        frmStokerInfo_Load(sender, e);
                        tsbtnSave.Enabled = false;
                    }
                }
            }
        }

        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要删除该供运商吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    boperate.getcom("delete from tb_StokerInfo where StokerID='" + Convert.ToString(dgvStokerInfo[0, dgvStokerInfo.CurrentCell.RowIndex].Value).Trim() + "'");
                    frmStokerInfo_Load(sender, e);
    
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
                    frmStokerInfo_Load(sender, e);
                }
                if (tscboxCondition.Text.Trim() == "供运商编号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where StokerID like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvStokerInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "供运商名称")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where SName like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvStokerInfo.DataSource = myds.Tables[0];
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

        private void dgvStokerInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtStokerID.Text = Convert.ToString(dgvStokerInfo[0, dgvStokerInfo.CurrentCell.RowIndex].Value).Trim();
            txtSName.Text = Convert.ToString(dgvStokerInfo[1, dgvStokerInfo.CurrentCell.RowIndex].Value).Trim();
            txtSPhone.Text = Convert.ToString(dgvStokerInfo[2, dgvStokerInfo.CurrentCell.RowIndex].Value).Trim();
            txtSFax.Text = Convert.ToString(dgvStokerInfo[3, dgvStokerInfo.CurrentCell.RowIndex].Value).Trim();
            txtSPostCode.Text = Convert.ToString(dgvStokerInfo[4, dgvStokerInfo.CurrentCell.RowIndex].Value).Trim();
            txtSAddress.Text = Convert.ToString(dgvStokerInfo[5, dgvStokerInfo.CurrentCell.RowIndex].Value).Trim();
            txtSEmail.Text = Convert.ToString(dgvStokerInfo[6, dgvStokerInfo.CurrentCell.RowIndex].Value).Trim();
            txtSRemark.Text = Convert.ToString(dgvStokerInfo[7, dgvStokerInfo.CurrentCell.RowIndex].Value).Trim();
        }

        public void ClearText()
        {
            txtSName.Text = "";
            txtSPhone.Text = "";
            txtSFax.Text = "";
            txtSPostCode.Text = "";
            txtSAddress.Text = "";
            txtSEmail.Text = "";
            txtSRemark.Text = "";
        }

     

      
        }

}

