namespace LogenePisLogin
{
    partial class LoginDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtPwd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbYhm = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.yhBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYhm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYhmc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPYM = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYhm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yhBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(77, 49);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.txtPwd.Properties.Appearance.Options.UseFont = true;
            this.txtPwd.Properties.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(152, 24);
            this.txtPwd.TabIndex = 2;
            this.txtPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPwd_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(22, 14);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 17);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "用户名:";
            // 
            // btnLogin
            // 
            this.btnLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.Location = new System.Drawing.Point(34, 85);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(81, 29);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(139, 85);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 29);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "退出";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(22, 50);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 17);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "密  码:";
            // 
            // cmbYhm
            // 
            this.cmbYhm.EditValue = "";
            this.cmbYhm.Location = new System.Drawing.Point(77, 13);
            this.cmbYhm.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.cmbYhm.Name = "cmbYhm";
            this.cmbYhm.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F);
            this.cmbYhm.Properties.Appearance.Options.UseFont = true;
            this.cmbYhm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbYhm.Properties.DataSource = this.yhBindingSource;
            this.cmbYhm.Properties.DisplayMember = "Yhm";
            this.cmbYhm.Properties.NullText = "";
            this.cmbYhm.Properties.NullValuePrompt = "用户名,编码或拼音码...";
            this.cmbYhm.Properties.NullValuePromptShowForEmptyValue = true;
            this.cmbYhm.Properties.ShowClearButton = false;
            this.cmbYhm.Properties.ShowFooter = false;
            this.cmbYhm.Properties.ValueMember = "Yhm";
            this.cmbYhm.Properties.View = this.searchLookUpEdit1View;
            this.cmbYhm.Size = new System.Drawing.Size(152, 24);
            this.cmbYhm.TabIndex = 1;
            this.cmbYhm.Popup += new System.EventHandler(this.clkOuterItem_Popup);
            this.cmbYhm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUid_KeyDown);
            // 
            // yhBindingSource
            // 
            this.yhBindingSource.DataSource = typeof(LogenePisLogin.Form1.Yh);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colYhm,
            this.colYhmc,
            this.colPYM});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsBehavior.AllowSortAnimation = DevExpress.Utils.DefaultBoolean.False;
            this.searchLookUpEdit1View.OptionsBehavior.AutoPopulateColumns = false;
            this.searchLookUpEdit1View.OptionsBehavior.AutoUpdateTotalSummary = false;
            this.searchLookUpEdit1View.OptionsFind.FindDelay = 100;
            this.searchLookUpEdit1View.OptionsFind.FindNullPrompt = "用户名,拼音码或编号...";
            this.searchLookUpEdit1View.OptionsFind.ShowClearButton = false;
            this.searchLookUpEdit1View.OptionsFind.ShowCloseButton = false;
            this.searchLookUpEdit1View.OptionsFind.ShowFindButton = false;
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // colYhm
            // 
            this.colYhm.FieldName = "Yhm";
            this.colYhm.Name = "colYhm";
            this.colYhm.Visible = true;
            this.colYhm.VisibleIndex = 1;
            // 
            // colYhmc
            // 
            this.colYhmc.FieldName = "Yhmc";
            this.colYhmc.Name = "colYhmc";
            this.colYhmc.Visible = true;
            this.colYhmc.VisibleIndex = 2;
            // 
            // colPYM
            // 
            this.colPYM.FieldName = "PYM";
            this.colPYM.Name = "colPYM";
            this.colPYM.Visible = true;
            this.colPYM.VisibleIndex = 3;
            // 
            // LoginDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 122);
            this.Controls.Add(this.cmbYhm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtPwd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginDialog";
            this.ShowIcon = false;
            this.Text = "登录到朗珈系统";
            this.Load += new System.EventHandler(this.LoginDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYhm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yhBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtPwd;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.BindingSource yhBindingSource;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbYhm;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colYhm;
        private DevExpress.XtraGrid.Columns.GridColumn colYhmc;
        private DevExpress.XtraGrid.Columns.GridColumn colPYM;
    }
}