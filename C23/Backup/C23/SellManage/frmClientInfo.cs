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
    public partial class frmClientInfo : Form
    {
        DataTable dt = new DataTable();
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected string M_str_sql = "select ClientID as 客户编号,CName as 客户名称,"
            + "CPhone as 联系电话,CFax as 传真号码,CPostCode as 邮政编码,CAddress as 联系地址,CEmail as Email,CRemark as 备注,"
            + "CMaker as 制单人,CDate as 日期,CTime as 时间 from tb_ClientInfo";
        protected string M_str_table = "tb_ClientInfo";
        protected int M_int_judge,i;
        protected int select;

        public frmClientInfo()
        {
            InitializeComponent();
        }
        private void dgvClientInfo_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgvClientInfo.ReadOnly == true)
            {
                int indexNumer = this.dgvClientInfo.CurrentCell.RowIndex;
                string sendClientID = this.dgvClientInfo.Rows[indexNumer].Cells[0].Value.ToString().Trim();
                string sendCName = dgvClientInfo.Rows[indexNumer].Cells[1].Value.ToString().Trim();
                string[] send =new string[] {sendClientID ,sendCName };
                if (select == 0)
                {
                    C23.SellManage.frmOrders.inputClientInfo[0] = send[0];
                    C23.SellManage.frmOrders.inputClientInfo[1] = send[1];
                }
                if (select ==1)
                {
                    C23.SellManage.frmSellTable.getClientInfo[0] = send[0];
                    C23.SellManage.frmSellTable.getClientInfo[1] = send[1];
                }
                if (select == 2)
                {
                    C23.SellManage.frmSellReT.getClientInfo[0] = send[0];
                    C23.SellManage.frmSellReT.getClientInfo[1] = send[1];
                }
                if (select == 3)
                {
                    C23.SellManage.frmOrdersT.inputClientInfo[0] = send[0];
                    C23.SellManage.frmOrdersT.inputClientInfo[1] = send[1];
                }
                if (select == 4)
                {
                    C23.SellManage.frmSellTableT.getClientInfo[0] = send[0];
                    C23.SellManage.frmSellTableT.getClientInfo[1] = send[1];
                }
                if (select == 5)
                {
                    C23.SellManage.frmSellRe.getClientInfo[0] = send[0];
                    C23.SellManage.frmSellRe.getClientInfo[1] = send[1];
                }
                this.Close();
            }

        }
        public  void dgvReadOnly()
        {
            dgvClientInfo .ReadOnly =true ;
            select = 0;
        }
        public void dgvReadOnlySell()
        {

            dgvClientInfo.ReadOnly = true;
            select = 1;
        }
        public void SellReT()
        {

            dgvClientInfo.ReadOnly = true;
            select = 2;
        }
        public void dgvReadOnlyT()
        {
            dgvClientInfo.ReadOnly = true;
            select = 3;
        }
        public void dgvReadOnlySellT()
        {

            dgvClientInfo.ReadOnly = true;
            select = 4;
        }
        public void SellRe()
        {

            dgvClientInfo.ReadOnly = true;
            select = 5;
        }
        private void frmClientInfo_Load(object sender, EventArgs e)
        {
            BindData();
            dgvStateControl();
        }
        private void BindData()
        {
            dt = boperate.getdt(M_str_sql);
            dgvClientInfo.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                tsbtnDel.Enabled = true;
            }
            else
            {
                tsbtnDel.Enabled = false;
            }
           for (i = 0; i < dgvClientInfo.Columns.Count - 1; i++)
            {
                dgvClientInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
               
            }
        }
        #region dgvStateControl
        private void dgvStateControl()
        {
            int numCols = dgvClientInfo.Columns.Count;
            for (i = 0; i < numCols; i++)
            {
                dgvClientInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (i == 0 || i == 1)
                {
                    dgvClientInfo.Columns[i].Width = 200;
                }
                dgvClientInfo.Columns[i].ReadOnly = true;   
            }
        }
        #endregion
        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            opAndvalidate.num("select CYear,CMonth,ClientID from tb_ClientInfo", "select * from tb_ClientInfo where CYear='" + year +
                "' and CMonth='" + month + "'", "tb_ClientInfo", "ClientID", "CL", "0001", txtClientID); 
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
                if (txtCName.Text == "")
                {
                    MessageBox.Show("客户名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!opAndvalidate.validatePhone(txtCPhone.Text.Trim()))
                    {
                        errorCFax.Clear();
                        errorCPostCode.Clear();
                        errorCEmail.Clear();
                        errorCPhone.SetError(txtCPhone, "电话号码格式不正确");
                    }
                    else if (!opAndvalidate.validateFax(txtCFax.Text.Trim()))
                    {
                        errorCPhone.Clear();
                        errorCPostCode.Clear();
                        errorCEmail.Clear();
                        errorCFax.SetError(txtCFax, "传真号码输入格式不正确");
                    }
                    else if (!opAndvalidate.validatePostCode(txtCPostCode.Text.Trim()))
                    {
                        errorCFax.Clear();
                        errorCPhone.Clear();
                        errorCEmail.Clear();
                        errorCPostCode.SetError(txtCPostCode, "邮编输入格式不正确");
                    }
                    else if (!opAndvalidate.validateEmail(txtCEmail.Text.Trim()))
                    {
                        errorCFax.Clear();
                        errorCPhone.Clear();
                        errorCPostCode.Clear();
                        errorCEmail.SetError(txtCEmail, "E-mail地址输入格式不正确");
                    }
                    else
                    {
                        errorCFax.Clear();
                        errorCPhone.Clear();
                        errorCPostCode.Clear();
                        errorCEmail.Clear();
                        boperate.getcom("insert into tb_ClientInfo(ClientID,CName,"
                            + "CYear,CMonth,CPhone,CFax,CPostCode,CAddress,CEmail,CRemark,CDate,CTime,CMaker) values('" + txtClientID.Text.Trim()
                            + "','" + txtCName.Text.Trim() + "','"+year +"','"+month +"','" + txtCPhone.Text.Trim() + "','" + txtCFax.Text.Trim()
                            + "','" + txtCPostCode.Text.Trim() + "','" + txtCAddress.Text.Trim() + "','" + txtCEmail.Text.Trim()
                            + "','" + txtCRemark.Text.Trim() + "','" + varDate  + "','" + DateTime.Now.ToLongTimeString()
                            + "','" + frmLogin.M_str_name + "')");
                        frmClientInfo_Load(sender, e);
                        tsbtnSave.Enabled = false;
                    }
                }
            }
            if (M_int_judge == 1)
            {
                if (txtCName.Text == "")
                {
                    MessageBox.Show("客户名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!opAndvalidate.validatePhone(txtCPhone.Text.Trim()))
                    {
                        errorCFax.Clear();
                        errorCPostCode.Clear();
                        errorCEmail.Clear();
                        errorCPhone.SetError(txtCPhone, "电话号码格式不正确");
                    }
                    else if (!opAndvalidate.validateFax(txtCFax.Text.Trim()))
                    {
                        errorCPhone.Clear();
                        errorCPostCode.Clear();
                        errorCEmail.Clear();
                        errorCFax.SetError(txtCFax, "传真号码输入格式不正确");
                    }
                    else if (!opAndvalidate.validatePostCode(txtCPostCode.Text.Trim()))
                    {
                        errorCFax.Clear();
                        errorCPhone.Clear();
                        errorCEmail.Clear();
                        errorCPostCode.SetError(txtCPostCode, "邮编输入格式不正确");
                    }
                    else if (!opAndvalidate.validateEmail(txtCEmail.Text.Trim()))
                    {
                        errorCFax.Clear();
                        errorCPhone.Clear();
                        errorCPostCode.Clear();
                        errorCEmail.SetError(txtCEmail, "E-mail地址输入格式不正确");
                    }
                    else
                    {
                        errorCFax.Clear();
                        errorCPhone.Clear();
                        errorCPostCode.Clear();
                        errorCEmail.Clear();
                        boperate.getcom("update tb_ClientInfo set CName='" + txtCName.Text.Trim()
                            + "',CPhone='" + txtCPhone.Text.Trim() + "',CFax='" + txtCFax.Text.Trim()
                            + "',CPostCode='" + txtCPostCode.Text.Trim() + "',CAddress='" + txtCAddress.Text.Trim()
                            + "',CEmail='" + txtCEmail.Text.Trim() + "',CRemark='" + txtCRemark.Text.Trim() + "' where ClientID='" + txtClientID.Text.Trim() + "'");
                        frmClientInfo_Load(sender, e);
                        tsbtnSave.Enabled = false;
                    }
                }
            }
        }

        private void tsbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要删除该客户信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    boperate.getcom("delete from tb_ClientInfo where ClientID='" + Convert.ToString(dgvClientInfo[0, dgvClientInfo.CurrentCell.RowIndex].Value).Trim() + "'");
                    frmClientInfo_Load(sender, e);
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
                    frmClientInfo_Load(sender, e);
                }
                if (tscboxCondition.Text.Trim() == "客户编号")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where ClientID like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvClientInfo.DataSource = myds.Tables[0];
                    else
                        MessageBox.Show("没有要查找的相关记录！");
                }
                if (tscboxCondition.Text.Trim() == "客户名称")
                {
                    DataSet myds = boperate.getds(M_str_sql + " where CName like '%" + tstxtKeyWord.Text.Trim() + "%'", M_str_table);
                    if (myds.Tables[0].Rows.Count > 0)
                        dgvClientInfo.DataSource = myds.Tables[0];
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

        private void dgvClientInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtClientID.Text = Convert.ToString(dgvClientInfo[0, dgvClientInfo.CurrentCell.RowIndex].Value).Trim();
            txtCName.Text = Convert.ToString(dgvClientInfo[1, dgvClientInfo.CurrentCell.RowIndex].Value).Trim();
            txtCPhone.Text = Convert.ToString(dgvClientInfo[2, dgvClientInfo.CurrentCell.RowIndex].Value).Trim();
            txtCFax.Text = Convert.ToString(dgvClientInfo[3, dgvClientInfo.CurrentCell.RowIndex].Value).Trim();
            txtCPostCode.Text = Convert.ToString(dgvClientInfo[4, dgvClientInfo.CurrentCell.RowIndex].Value).Trim();
            txtCAddress.Text = Convert.ToString(dgvClientInfo[5, dgvClientInfo.CurrentCell.RowIndex].Value).Trim();
            txtCEmail.Text = Convert.ToString(dgvClientInfo[6, dgvClientInfo.CurrentCell.RowIndex].Value).Trim();
            txtCRemark.Text = Convert.ToString(dgvClientInfo[7, dgvClientInfo.CurrentCell.RowIndex].Value).Trim();
        }

        public void ClearText()
        {
            txtCName.Text = "";
            txtCPhone.Text = "";
            txtCFax.Text = "";
            txtCPostCode.Text = "";
            txtCAddress.Text = "";
            txtCEmail.Text = "";
            txtCRemark.Text = "";
        }


  
     

      
    }
}
