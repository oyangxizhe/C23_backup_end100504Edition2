using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace C23
{
    public partial class frmClose : Form
    {
        public frmClose()
        {
            InitializeComponent();
        }

        private void frmClose_Load(object sender, EventArgs e)
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
        }
    }

