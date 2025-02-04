using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace C23.BaseClass
{
    class OperateAndValidate
    {
        BaseOperate boperate = new BaseOperate();//声明BaseOperate类的一个对象，以调用其方法

        #region  绑定ComboBox控件
        /// <summary>
        /// 对ComboBox控件进行数据绑定
        /// </summary>
        /// <param name="P_str_sqlstr">SQL语句</param>
        /// <param name="P_str_table">表名</param>
        /// <param name="P_str_tbMember">数据表中字段名</param>
        /// <param name="cbox">ComboBox控件ID</param>
        public void cboxBind(string P_str_sqlstr, string P_str_table, string P_str_tbMember, ComboBox cbox)
        {
            DataSet myds = boperate.getds(P_str_sqlstr, P_str_table);
            cbox.DataSource = myds.Tables[P_str_table];
            cbox.DisplayMember = P_str_tbMember;
        }
        #endregion

        #region  验证输入字符串为数字
        /// <summary>
        /// 验证输入字符串为数字
        /// </summary>
        /// <param name="P_str_num">输入字符</param>
        /// <returns>返回一个bool类型的值</returns>
        public bool validateNum(string P_str_num)
        {
            return Regex.IsMatch(P_str_num, "^[0-9]*$");
        }
        #endregion

        #region  验证输入字符串为电话号码
        /// <summary>
        /// 验证输入字符串为电话号码
        /// </summary>
        /// <param name="P_str_phone">输入字符串</param>
        /// <returns>返回一个bool类型的值</returns>
        public bool validatePhone(string P_str_phone)
        {
            return Regex.IsMatch(P_str_phone, @"\d{3,4}-\d{7,8}");
        }
        #endregion

        #region  验证输入字符串为传真号码
        /// <summary>
        /// 验证输入字符串为传真号码
        /// </summary>
        /// <param name="P_str_fax">输入字符串</param
        /// <returns>返回一个bool类型的值</returns>
        public bool validateFax(string P_str_fax)
        {
            return Regex.IsMatch(P_str_fax, @"\d{3,4}-\d{7,8}");
        }
        #endregion

        #region  验证输入字符串为邮政编码
        /// <summary>
        /// 验证输入字符串为邮政编码
        /// </summary>
        /// <param name="P_str_postcode">输入字符串</param>
        /// <returns>返回一个bool类型的值</returns>
        public bool validatePostCode(string P_str_postcode)
        {
            return Regex.IsMatch(P_str_postcode, @"\d{6}");
        }
        #endregion

        #region  验证输入字符串为E-mail地址
        /// <summary>
        /// 验证输入字符串为E-mail地址
        /// </summary>
        /// <param name="P_str_email">输入字符串</param>
        /// <returns>返回一个bool类型的值</returns>
        public bool validateEmail(string P_str_email)
        {
            return Regex.IsMatch(P_str_email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }
        #endregion

        #region  验证输入字符串为网络地址
        /// <summary>
        /// 验证输入字符串为网络地址
        /// </summary>
        /// <param name="P_str_naddress">输入字符串</param>
        /// <returns>返回一个bool类型的值</returns>
        public bool validateNAddress(string P_str_naddress)
        {
            return Regex.IsMatch(P_str_naddress, @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
        }
        #endregion

        #region  自动编号
        /// <summary>
        /// 自动编号
        /// </summary>
        /// <param name="P_str_sqlstr">SQL语句</param>
        /// <param name="P_str_table">数据表名</param>
        /// <param name="P_str_tbColumn">数据表字段</param>
        /// <param name="P_str_codeIndex">编号前的字符串</param>
        /// <param name="P_str_codeNum">编号后面的数字</param>
        /// <param name="txt">TextBox控件名</param>
        public void autoNum(string P_str_sqlstr, string P_str_table, string P_str_tbColumn, string P_str_codeIndex, string P_str_codeNum, TextBox txt)
        {
            string P_str_Code = "";
            int P_int_Code = 0;
            DataSet myds = boperate.getds(P_str_sqlstr, P_str_table);
            if (myds.Tables[0].Rows.Count == 0)
            {
                txt.Text = P_str_codeIndex + P_str_codeNum;
            }
            else
            {
                P_str_Code = Convert.ToString(myds.Tables[0].Rows[myds.Tables[0].Rows.Count - 1][P_str_tbColumn]);
                P_int_Code = Convert.ToInt32(P_str_Code.Substring(2, 7)) + 1;
                P_str_Code = P_str_codeIndex + P_int_Code.ToString();
                txt.Text = P_str_Code;
            }
        }
        #endregion

        #region  绑定报表
        /// <summary>
        /// 绑定报表
        /// </summary>
        /// <param name="P_str_creportName">报表名称</param>
        /// <param name="P_str_sql">SQL语句</param>
        /// <returns>返回ReportDocument对象</returns>
        public ReportDocument CrystalReports(string P_str_creportName, string P_str_sql)
        {

            TableLogOnInfo logOnInfo = new TableLogOnInfo();
            ReportDocument reportDocument = new ReportDocument();
            string P_str_creportPath = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0,
                Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            P_str_creportPath += @"\ReportManage\CReportFile\" + P_str_creportName;
            reportDocument.Load(P_str_creportPath);
            reportDocument.DataDefinition.RecordSelectionFormula = P_str_sql;
            logOnInfo.ConnectionInfo.ServerName = "soniasui";
            logOnInfo.ConnectionInfo.DatabaseName = "db_JXC";
            logOnInfo.ConnectionInfo.UserID = "sa";
            logOnInfo.ConnectionInfo.Password = "332434sui";
            reportDocument.Database.Tables[0].ApplyLogOnInfo(logOnInfo);
            return reportDocument;
            }
        #endregion
       
        #region 编号
        public void num(string sql1, string sql2, string table1, string tbColumns, string prifix, string  suffix, TextBox txt)
        {
            string year, month;
            year = DateTime.Now.ToString("yy");
            month = DateTime.Now.ToString("MM");
            DataSet ds1 = boperate.getds(sql1, table1);
            string P_str_Code,t,q="";
            
            int P_int_Code,w;
            SqlDataReader sqlread = boperate.getread(sql2);
            sqlread.Read();
            if (sqlread.HasRows)
            {
                    P_str_Code = Convert.ToString(ds1.Tables[0].Rows[(ds1.Tables[0].Rows.Count - 1)][tbColumns]);
                    P_int_Code = Convert.ToInt32(P_str_Code.Substring(6, 4)) + 1;
                    t = Convert.ToString(P_int_Code);
                    w  = 4 - t.Length;
                    while (w  >= 1)
                    {
                        q = q + "0";
                        w  = w  - 1;

                    }
                    txt.Text = prifix + year + month + q+P_int_Code;
            }
            else
            {
                txt.Text = prifix + year + month + suffix;
            }
            sqlread.Close();
        }
        #endregion
      
    
    
    
    }
}
