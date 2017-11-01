using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using dbbase;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Views.Grid;

namespace LogenePisLogin
{
    public partial class LoginDialog : DevExpress.XtraEditors.XtraForm
    {
        private DataTable _dtYh = null;
        private List<Form1.Yh> lstYh = new List<Form1.Yh>();

        public LoginDialog()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
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

                lstYh.Add(Form1.Yh.FromRow(row));
            }

            yhBindingSource.DataSource = lstYh;

            this.Closing += LoginDialog_Closing;
        }

        private void LoginDialog_Closing(object sender, CancelEventArgs e)
        {
            Application.Exit();
        }

        private void LoginDialog_Load(object sender, EventArgs e)
        {
        }

        private DataTable GetYh()
        {
            dbbase.odbcdb aa = new odbcdb("DSN=pathnet;UID=pathnet;PWD=4s3c2a1p", "", "");
            string sql = "select f_yhm,f_yhmc,F_ID,f_yhmm from t_yh order by F_ID";
            return aa.GetDataTable(sql, "yh");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //检查主程序exe是否存在
            if (File.Exists($"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\\{Program.ExeName}.exe") == false)
            {
                MessageBox.Show($"没有找到{Program.ExeName}.exe,无法启动程序,请将登陆程序放在Pathqc根目录下!");
                return;
            }
            var uid = cmbYhm.EditValue?.ToString();
            var pwd = txtPwd.Text.Trim();

            //验证输入
            if (string.IsNullOrEmpty(uid) || pwd == "")
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
                Process.Start($"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\\PATHNetRPT.exe",
                    $"{uid},{pwd}");
            }
            catch (Exception exception)
            {
                MessageBox.Show("尝试启动PATHNetRPT.exe时出现错误:" + e);
            }
            finally
            {
                Application.Exit();
            }
        }

        private void txtUid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cmbYhm.IsPopupOpen == false)
                txtPwd.Focus();
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(null, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clkOuterItem_Popup(object sender, EventArgs e)
        {
            PopupSearchLookUpEditForm popupForm = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            popupForm.KeyPreview = true;
            popupForm.KeyUp -= popupForm_KeyUp;
            popupForm.KeyUp += popupForm_KeyUp;
        }

        void popupForm_KeyUp(object sender, KeyEventArgs e)
        {
            PopupSearchLookUpEditForm popupForm = sender as PopupSearchLookUpEditForm;
            if (e.KeyData == Keys.Enter)
            {
                GridView view = popupForm.OwnerEdit.Properties.View;
                view.FocusedRowHandle = 0;
                popupForm.OwnerEdit.ClosePopup();
            }
        }
    }
}