using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace C23.ReportManage
{
    public partial class frmCRPurOrders : Form
    {
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        public frmCRPurOrders()
        {
            InitializeComponent();
        }

        private void frmCRPurOrders_Load(object sender, EventArgs e)
        {
            opAndvalidate.cboxBind("select PurOrdersID from tb_PurOrders", "tb_PurOrders", "PurOrdersID", cboxID);
            TableLogOnInfo logOnInfo = new TableLogOnInfo();
            ReportDocument oRpt = new ReportDocument();
            string RptDir = "C:\\Program Files\\Soniasui\\进销存管理系统\\ReportManage\\CReportFile\\CRPurOrders.rpt"; //crystalreport1.rpt文件所在的绝对路径 
            oRpt.Load(RptDir);


            //设置logoninfo参数，注意这里如果不设?编译时最容易出现“登陆失败”的错误！ 
            logOnInfo.ConnectionInfo.ServerName = "soniasui";
            logOnInfo.ConnectionInfo.DatabaseName = "db_JXC";
            logOnInfo.ConnectionInfo.UserID = "sa";
            logOnInfo.ConnectionInfo.Password = "332434sui";
            oRpt.Database.Tables[0].ApplyLogOnInfo(logOnInfo);
            //建立.rpt文件与crystalreportviewer文件之间的连接 
            CRVPurOrders.ReportSource = oRpt;
            
        }

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            SqlDataReader sqlread = boperate.getread("select PurOrdersID from tb_PurOrders");
            sqlread.Read();
            if (sqlread.HasRows)
            {
                boperate.getcom("delete tb_PurOrders");
                C23.SellManage.frmOrders frm = new C23.SellManage.frmOrders();


            }
            else
            {
            }
            sqlread.Close();
            this.Close();
        }

        private void btnLook_Click(object sender, EventArgs e)
        {
            string P_str_sql = " {tb_PurOrders.PurOrdersID} like '" + cboxID.Text.Trim() + "'";
            CRVPurOrders.ReportSource = opAndvalidate.CrystalReports("CRPurOrders.rpt", P_str_sql);  
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CRVPurOrders_Load(object sender, EventArgs e)
        {

        }
    }
}
