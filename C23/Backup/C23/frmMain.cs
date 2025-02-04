using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace C23
{
    public partial class frmMain : Form
    {
         DataTable dt = new DataTable();

        C23.BaseClass.BaseOperate boperate = new C23.BaseClass.BaseOperate();
        C23.BaseClass.OperateAndValidate opAndvalidate = new C23.BaseClass.OperateAndValidate();

        protected string M_str_sql =  "SELECT RightName from tb_RightList where UserID = '" + frmLogin.M_str_UserID+ "'";
    
        public frmMain()
        {
            InitializeComponent();
        }

 

        private void frmMain_Load(object sender, EventArgs e)
        {
             dt = boperate.getdt(M_str_sql);
            tsslUser.Text = "||当前用户：" + frmLogin.M_str_name;
            tsslDepart.Text = "||所属部门：" + frmLogin.M_str_Depart;
            tsslTime.Text = "||登录时间：" + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
      
            //系统管理用户为特殊权限用户,他始终拥有所有权利
            if (frmLogin.M_str_Depart  == "系统管理")
            {
                录入客户订单ToolStripMenuItem.Visible  = true;
                录入采购单ToolStripMenuItem.Visible = true;
                录入进货单ToolStripMenuItem.Visible = true;
                录入退货单ToolStripMenuItem.Visible = true;
                录入领料单ToolStripMenuItem.Visible = true;
                录入入库单ToolStripMenuItem.Visible = true;
                录入销货单ToolStripMenuItem.Visible = true;
                录入销退单ToolStripMenuItem.Visible = true;
                客户信息维护ToolStripMenuItem.Visible = true;
                供运商信息维护ToolStripMenuItem.Visible = true;
                品号信息维护ToolStripMenuItem.Visible = true; 
                员工信息维护ToolStripMenuItem.Visible = true;
                仓库信息维护ToolStripMenuItem.Visible = true;
                库位信息维护ToolStripMenuItem.Visible = true;
                订单状态ToolStripMenuItem.Visible = true;
                库存查询ToolStripMenuItem.Visible = true;
                库存明细ToolStripMenuItem.Visible = true;
                应付账款ToolStripMenuItem.Visible = true;
                应付账款明细ToolStripMenuItem.Visible = true;
                应收账款ToolStripMenuItem.Visible  = true;
                应收账款明细ToolStripMenuItem.Visible = true;
                用户账户ToolStripMenuItem.Visible = true;
                更改密码ToolStripMenuItem.Visible = true;
                权限管理ToolStripMenuItem.Visible = true;
            }
            else
            {
                //根据从数据库中检索到的用户的权限来设置其有权使用的菜单
                for (int intCounter = 0; intCounter < this.dt.Rows.Count; intCounter++)
                {
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "录入客户订单")
                    {
                        录入客户订单ToolStripMenuItem.Visible = true;
                    }
                    if (this.dt.Rows[intCounter][0].ToString ().Trim() == "录入采购单")
                    {
                        录入采购单ToolStripMenuItem.Visible = true; 
                    }
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "录入进货单")
                    {
                        录入进货单ToolStripMenuItem.Visible = true;
                    }
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "录入退货单")
                    {
                        录入退货单ToolStripMenuItem.Visible = true; 
                    }
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "录入领料单")
                    {
                        录入领料单ToolStripMenuItem.Visible= true;
                    }
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "录入入库单")
                    {
                        录入入库单ToolStripMenuItem.Visible= true; 
                    }
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "录入销货单")
                    {
                        录入销货单ToolStripMenuItem.Visible = true; 
                    }
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "录入销退单")
                    {
                        录入销退单ToolStripMenuItem.Visible = true; 
                    }
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "客户信息维护")
                    {
                        客户信息维护ToolStripMenuItem.Visible = true; 
                    }
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "供运商信息维护")
                    {
                        供运商信息维护ToolStripMenuItem.Visible = true; 
                    }
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "品号信息维护")
                    {
                        品号信息维护ToolStripMenuItem.Visible = true;
                    }
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "员工信息维护")
                    {
                        员工信息维护ToolStripMenuItem.Visible = true;
                    }
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "仓库信息维护")
                    {
                        仓库信息维护ToolStripMenuItem.Visible = true;
                    }
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "库位信息维护")
                    {
                        库位信息维护ToolStripMenuItem.Visible = true;
                    }
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "订单状态")
                    {
                        订单状态ToolStripMenuItem.Visible = true;
                    }
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "库存查询")
                    {
                        库存查询ToolStripMenuItem.Visible = true;
                    }
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "库存明细")
                    {
                        库存明细ToolStripMenuItem.Visible = true;
                    }
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "应付帐款")
                    {
                  
                        应付账款ToolStripMenuItem.Visible = true;
                    }
                 
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "应收账款")
                    {
                     
                        应收账款ToolStripMenuItem.Visible = true;
                    }
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "应付账款明细")
                    {
                        应付账款明细ToolStripMenuItem.Visible = true; 
                    }
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "应收账款明细")
                    {
                        应收账款明细ToolStripMenuItem.Visible = true; 
                    }
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "用户帐户")
                    {
                        用户账户ToolStripMenuItem.Visible = true; 
                    }
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "更改密码")
                    {
                        更改密码ToolStripMenuItem.Visible = true;
                    }
                    if (this.dt.Rows[intCounter][0].ToString().Trim() == "权限管理")
                    {
                        权限管理ToolStripMenuItem.Visible = true; 
                    }
                   
                }
            }
          
        }

       

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出本系统吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {
                frmMain fmain = new frmMain();
                fmain.Show();
            }
        }

        private void 供运商信息维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C23.PUR.frmStokerInfo frmS = new C23.PUR.frmStokerInfo();
            frmS.MdiParent = this;
            frmS.Show();
        }

        private void 录入进货单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C23.StockManage.frmStockTable frmS = new C23.StockManage.frmStockTable();
            frmS.MdiParent = this;
            frmS.Show();
        }

        private void 仓库信息维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C23.StorageManage.frmStorageInfo frmS = new C23.StorageManage.frmStorageInfo();
            frmS.MdiParent = this;
            frmS.Show();   
        }

        private void 库位信息维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            C23.StorageManage.frmLocationInfo frmS = new C23.StorageManage.frmLocationInfo();
            frmS.MdiParent = this;
            frmS.Show();
        }

        private void 库存查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C23.StorageManage.frmStorageCase FRM = new C23.StorageManage.frmStorageCase();
            FRM.MdiParent = this;
            FRM.Show();
        }

        private void 客户信息维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C23.SellManage.frmClientInfo frmS = new C23.SellManage.frmClientInfo();
            frmS.MdiParent = this;
            frmS.Show();
        }

        private void 录入客户订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C23.SellManage.frmOrders frmS = new C23.SellManage.frmOrders();
            frmS.MdiParent = this;
            frmS.Show();
        }

        private void 员工信息维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C23.EmployeeManage.frmEmployeeInfo FRM = new C23.EmployeeManage.frmEmployeeInfo();
            FRM.MdiParent = this;
            FRM.Show();

        }

       private void 库存明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C23.StorageManage.frmInventory frm = new C23.StorageManage.frmInventory();
            frm.MdiParent = this;
            frm.Show();

        }

        private void 录入采购单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C23.PUR.frmPurOrders frm = new C23.PUR.frmPurOrders();
            frm.MdiParent = this;
            frm.Show();
        }

      
        private void 应付账款明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C23.AccountManage.frmPayPart frm = new C23.AccountManage.frmPayPart();
            frm.MdiParent = this;
            frm.Show();
        }
         private void 应收账款ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C23.AccountManage.frmAcReceiv frm = new C23.AccountManage.frmAcReceiv();
            frm.MdiParent = this;
            frm.Show();
        }

         private void 应收账款明细ToolStripMenuItem_Click(object sender, EventArgs e)
         {
             C23.AccountManage.frmReceivPart frm = new C23.AccountManage.frmReceivPart();
             frm.MdiParent = this;
             frm.Show();
         }

         private void 录入退货单ToolStripMenuItem_Click(object sender, EventArgs e)
         {
             C23.StockManage.frmReturn FRM = new C23.StockManage.frmReturn();
             FRM.MdiParent = this;
             FRM.Show();

         }

       

         private void 录入入库单ToolStripMenuItem_Click(object sender, EventArgs e)
         {
             C23.StorageManage.frmGodE frm = new C23.StorageManage.frmGodE();
             frm.MdiParent = this;
             frm.Show();
         }
         private void 订单状态ToolStripMenuItem_Click(object sender, EventArgs e)
         {
             C23.SellManage.frmOrdersSta frm = new C23.SellManage.frmOrdersSta();
             frm.MdiParent = this;
             frm.Show();
         }

       
         private void 更改密码ToolStripMenuItem_Click(object sender, EventArgs e)
         {
             C23.UserManage.frmEditPwd  frm = new C23.UserManage.frmEditPwd ();
             frm.MdiParent = this;
             frm.Show();
         }

        

         private void 录入领料单ToolStripMenuItem_Click_1(object sender, EventArgs e)
         {
             C23.StorageManage.frmMateRe frm = new C23.StorageManage.frmMateRe();
             frm.MdiParent = this;
             frm.Show();
         }

         private void 录入销货单ToolStripMenuItem_Click(object sender, EventArgs e)
         {
             C23.SellManage.frmSellTable frm = new C23.SellManage.frmSellTable();
             frm.MdiParent = this;
             frm.Show();
         }

         private void 录入销退单ToolStripMenuItem_Click(object sender, EventArgs e)
         {
             C23.SellManage.frmSellRe frm = new C23.SellManage.frmSellRe();
             frm.MdiParent = this;
             frm.Show();
         }

         private void 用户账户ToolStripMenuItem_Click(object sender, EventArgs e)
         {
             C23.UserManage.frmUserManage frm = new C23.UserManage.frmUserManage();
             frm.MdiParent = this;
             frm.Show();
         }

         private void 应付账款ToolStripMenuItem_Click(object sender, EventArgs e)
         {
             C23.AccountManage.frmAcPay frm = new C23.AccountManage.frmAcPay();
             frm.MdiParent = this;
             frm.Show();
         }

      

         private void 权限管理ToolStripMenuItem_Click(object sender, EventArgs e)
         {
             C23.UserManage.frmEditRight frm = new C23.UserManage.frmEditRight();
             frm.MdiParent = this;
             frm.Show();
         }

         private void 采购单状态ToolStripMenuItem_Click(object sender, EventArgs e)
         {
             C23.PUR.frmPOrdersSta frm = new C23.PUR.frmPOrdersSta();
             frm.MdiParent = this;
             frm.Show();
         }

         private void 品号信息维护ToolStripMenuItem_Click_1(object sender, EventArgs e)
         {
             C23.BomManage.frmWareInfo dmFAM = new C23.BomManage.frmWareInfo();
             dmFAM.MdiParent = this;
             dmFAM.Show();
         }

        
          
    }
}
