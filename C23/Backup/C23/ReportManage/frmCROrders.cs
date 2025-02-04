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
    public partial class frmCROrders : Form
    {
        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();
        public frmCROrders()
        {
            InitializeComponent();
        }

        private void frmCROrders_Load(object sender, EventArgs e)
        {
            opAndvalidate.cboxBind("select OrdersID from tb_Orders", "tb_Orders", "OrdersID", cboxID);
         
            TableLogOnInfo logOnInfo = new TableLogOnInfo();
            ReportDocument oRpt = new ReportDocument();
            string RptDir = "C:\\Program Files\\Soniasui\\进销存管理系统\\ReportManage\\CReportFile\\CROrders.rpt"; //crystalreport1.rpt文件所在的绝对路径 
            oRpt.Load(RptDir);


            //设置logoninfo参数，注意这里如果不设?编译时最容易出现“登陆失败”的错误！ 
            logOnInfo.ConnectionInfo.ServerName = "soniasui";
            logOnInfo.ConnectionInfo.DatabaseName = "db_JXC";
            logOnInfo.ConnectionInfo.UserID = "sa";
            logOnInfo.ConnectionInfo.Password = "332434sui";
            oRpt.Database.Tables[0].ApplyLogOnInfo(logOnInfo);
            //建立.rpt文件与crystalreportviewer文件之间的连接 
            CRVOrders.ReportSource = oRpt;
        }

       private void deleteReport()
        {

            SqlDataReader sqlread = boperate.getread("select OrdersID from tb_Orders");
            sqlread.Read();
            if (sqlread.HasRows)
            {
                boperate.getcom("delete tb_Orders");
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
            string P_str_sql = " {tb_Orders.OrdersID} like '" + cboxID.Text.Trim() + "'";
            CRVOrders.ReportSource = opAndvalidate.CrystalReports("CROrders.rpt", P_str_sql);  
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
  
    }
}
