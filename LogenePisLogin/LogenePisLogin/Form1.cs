using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using dbbase;

namespace LogenePisLogin
{
    public partial class Form1 : Form
    {
        private DataTable _dtYh=null;

        public Form1()
        {
            InitializeComponent();

            txtUid.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtUid.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUid.Focus();

            _dtYh = GetYh();
            if (_dtYh == null)
            {
                MessageBox.Show("无法获取T_YH数据,可能是数据库配置错误,或数据库无法连接!");
                Close();
            }

            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            foreach (DataRow row in _dtYh.Rows)
            {
                col.Add(row["f_yhm"].ToString());
            }
            txtUid.AutoCompleteCustomSource = col;
        }

        private DataTable GetYh()
        {
            dbbase.odbcdb aa = new odbcdb("DSN=pathnet;UID=pathnet;PWD=4s3c2a1p", "", "");
            string sql = "select f_yhm,f_yhmc,f_yhmm from t_yh";
            return aa.GetDataTable(sql, "yh");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var uid = txtUid.Text.Trim();
            var pwd = txtPwd.Text.Trim();

            //验证输入
            if (uid == "" || pwd == "")
            {
                MessageBox.Show("用户名和密码不能为空!");
                return;
            }

            //验证密码
            var loginSuccess = false;
            foreach (DataRow row in _dtYh.Rows)
            {
                if (row["f_yhm"].ToString() == uid &&
                    row["f_yhmm"].ToString() == pwd)
                {
                    loginSuccess = true;
                    break;
                }
            }

            if (loginSuccess == false)
            {
                MessageBox.Show("用户名或密码错误!");
                return;
            }

            //验证成功,打开PIS
            Process.Start($"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\\PATHNetRPT.exe",$"{uid}^{pwd}");

        }

        private void txtUid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPwd.Focus();
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(null, null);
        }
    }
}