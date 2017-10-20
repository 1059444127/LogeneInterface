using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using dbbase;

namespace LogenePisLogin
{
    public partial class Form1 : Form
    {
        private DataTable _dtYh=null;
        private List<Yh> lstYh = new List<Yh>(); 

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

                lstYh.Add(Yh.FromRow(row));
            }
            txtUid.AutoCompleteCustomSource = col;
            
            comboBox1.Items.AddRange(lstYh.ToArray());
        }

        private DataTable GetYh()
        {
            dbbase.odbcdb aa = new odbcdb("DSN=pathnet;UID=pathnet;PWD=4s3c2a1p", "", "");
            string sql = "select f_yhm,f_yhmc,f_yhmm from t_yh";
            return aa.GetDataTable(sql, "yh");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //检查主程序exe是否存在
            if (File.Exists($"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\\PATHNetRPT.exe") == false)
            {
                MessageBox.Show("没有找到PATHNetRPT.exe,无法启动程序,请将登陆程序放在Pathqc根目录下!");
                return;
            }

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
            try
            {
                Process.Start($"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\\PATHNetRPT.exe",$"{uid}^{pwd}");
            }
            catch (Exception exception)
            {
                MessageBox.Show("尝试启动PATHNetRPT.exe时出现错误:" + e);
            }
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

        public class Yh
        {
            public string Yhm { get; set; }
            public string Yhmm { get; set; }
            public string Yhmc { get; set; }

            public static Yh FromRow(DataRow dr)
            {
                Yh yh = new Yh();
                yh.Yhm = dr["f_yhm"].ToString();
                yh.Yhmc = dr["f_yhmc"].ToString();
                yh.Yhmm = dr["f_yhmm"].ToString();

                return yh;
            }

            #region Overrides of Object

            /// <summary>
            /// Returns a string that represents the current object.
            /// </summary>
            /// <returns>
            /// A string that represents the current object.
            /// </returns>
            public override string ToString()
            {
                return this.Yhmc + "  |  " + Yhm;
            }

            #endregion
        }
    }
}