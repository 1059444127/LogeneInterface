using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LGI.Core.Model;

namespace LGI.Common
{
    public partial class AuthorizationForm : Form
    {
        private T_YH _authorizedUser = null;

        public T_YH AuthorizedUser
        {
            get { return _authorizedUser; }
        }

        public AuthorizationForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.No;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var uid = txtUid.Text.Trim();
            var pwd = txtPwd.Text.Trim();

            if (string.IsNullOrEmpty(uid))
            {
                XtraMessageBox.Show("登录名不能为空!");
                return;
            }
            if (string.IsNullOrEmpty(pwd))
            {
                XtraMessageBox.Show("密码不能为空!");
                return;
            }

            //query from db
            var db = ContextPool.GetContext();
            var yh = db.T_YH.SingleOrDefault(o => o.F_YHBH == uid && o.F_YHMM == pwd);

            if (yh == null)
            {
                XtraMessageBox.Show("用户命或密码不正确!");
                return;
            }

            //success
            DialogResult = DialogResult.Yes;
            _authorizedUser = yh;
            Close();
        }
    }
}