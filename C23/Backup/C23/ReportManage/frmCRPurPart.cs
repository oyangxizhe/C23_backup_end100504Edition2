using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace C23.ReportManage
{
    public partial class frmCRPurPart : Form
    {
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        protected string M_str_sql = "select * from tb_PurOrders";
        protected string M_str_table = "tb_PurOrders";
        public frmCRPurPart()
        {
            InitializeComponent();
        }

        private void frmCRPurPart_Load(object sender, EventArgs e)
        {

            TableLogOnInfo logOnInfo = new TableLogOnInfo();
            ReportDocument oRpt = new ReportDocument();
            string RptDir = "C:\\Program Files\\Soniasui\\进销存管理系统\\ReportManage\\CReportFile\\CRPurPart.rpt"; //crystalreport1.rpt文件所在的绝对路径 
            oRpt.Load(RptDir);


            //设置logoninfo参数，注意这里如果不设?编译时最容易出现“登陆失败”的错误！ 
            logOnInfo.ConnectionInfo.ServerName = "soniasui";
            logOnInfo.ConnectionInfo.DatabaseName = "db_JXC";
            logOnInfo.ConnectionInfo.UserID = "sa";
            logOnInfo.ConnectionInfo.Password = "332434sui";
            oRpt.Database.Tables[0].ApplyLogOnInfo(logOnInfo);
            //建立.rpt文件与crystalreportviewer文件之间的连接 
            CRVPurPart.ReportSource = oRpt;
        }



        private void btnLook_Click(object sender, EventArgs e)
        {
            
            #region
            try
            {
                if (txtKeyWord.Text == "")
                {
                    frmCRPurPart_Load(sender, e);
                }
                if (cboxCondition.Text.Trim() == "采购单号")
                {
                    string P_str_sql = " {tb_PurOrders.PurOrdersID} like '" + txtKeyWord.Text.Trim() + "'  ";
                    CRVPurPart.ReportSource = opAndvalidate.CrystalReports("CRPurPart.rpt", P_str_sql);
                }
                if (cboxCondition.Text.Trim() == "品号")
                {
                   
                    string P_str_sql = " {tb_PurOrders.WareID} like '" + txtKeyWord.Text.Trim() + "'  ";
                    CRVPurPart.ReportSource = opAndvalidate.CrystalReports("CRPurPart.rpt", P_str_sql);
                }
                if (cboxCondition.Text.Trim() == "品名")
                {
                    string P_str_sql = " {tb_PurOrders.WareName} like '" + txtKeyWord.Text.Trim() + "'  ";
                    CRVPurPart.ReportSource = opAndvalidate.CrystalReports("CRPurPart.rpt", P_str_sql);
               
                }
                if (cboxCondition.Text.Trim() == "供运商编号")
                {
                    string P_str_sql = " {tb_PurOrders.StokerID} like '" + txtKeyWord.Text.Trim() + "'  ";
                    CRVPurPart.ReportSource = opAndvalidate.CrystalReports("CRPurPart.rpt", P_str_sql);
                   
                }
                if (cboxCondition.Text.Trim() == "供运商名称")
                {

                    string P_str_sql = " {tb_PurOrders.StokerName} like '" + txtKeyWord.Text.Trim() + "'  ";
                    CRVPurPart.ReportSource = opAndvalidate.CrystalReports("CRPurPart.rpt", P_str_sql);
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
