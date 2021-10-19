
namespace DoAn_CNPM_App
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.lb_DangNhap = new MetroSet_UI.Controls.MetroSetLabel();
            this.metroSetPanel1 = new MetroSet_UI.Controls.MetroSetPanel();
            this.lb_Account = new MetroSet_UI.Controls.MetroSetLabel();
            this.txb_Account = new MetroSet_UI.Controls.MetroSetTextBox();
            this.metroSetControlBox1 = new MetroSet_UI.Controls.MetroSetControlBox();
            this.metroSetPanel2 = new MetroSet_UI.Controls.MetroSetPanel();
            this.lb_Password = new MetroSet_UI.Controls.MetroSetLabel();
            this.txb_Pwd = new MetroSet_UI.Controls.MetroSetTextBox();
            this.btn_Login = new MetroSet_UI.Controls.MetroSetButton();
            this.btn_Quit = new MetroSet_UI.Controls.MetroSetButton();
            this.pnl_Login = new MetroSet_UI.Controls.MetroSetPanel();
            this.lbl_ForgotPwd = new MetroSet_UI.Controls.MetroSetLabel();
            this.ckbx_Remember = new MetroSet_UI.Controls.MetroSetCheckBox();
            this.metroSetLabel1 = new MetroSet_UI.Controls.MetroSetLabel();
            this.metroSetPanel1.SuspendLayout();
            this.metroSetPanel2.SuspendLayout();
            this.pnl_Login.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_DangNhap
            // 
            this.lb_DangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lb_DangNhap.IsDerivedStyle = true;
            this.lb_DangNhap.Location = new System.Drawing.Point(220, 17);
            this.lb_DangNhap.Name = "lb_DangNhap";
            this.lb_DangNhap.Size = new System.Drawing.Size(301, 61);
            this.lb_DangNhap.Style = MetroSet_UI.Enums.Style.Light;
            this.lb_DangNhap.StyleManager = null;
            this.lb_DangNhap.TabIndex = 0;
            this.lb_DangNhap.Text = "Đăng nhập hệ thống";
            this.lb_DangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_DangNhap.ThemeAuthor = "Narwin";
            this.lb_DangNhap.ThemeName = "MetroLite";
            this.lb_DangNhap.Click += new System.EventHandler(this.lb_DangNhap_Click);
            // 
            // metroSetPanel1
            // 
            this.metroSetPanel1.BackgroundColor = System.Drawing.Color.White;
            this.metroSetPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.metroSetPanel1.BorderThickness = 1;
            this.metroSetPanel1.Controls.Add(this.lb_Account);
            this.metroSetPanel1.Controls.Add(this.txb_Account);
            this.metroSetPanel1.IsDerivedStyle = true;
            this.metroSetPanel1.Location = new System.Drawing.Point(77, 81);
            this.metroSetPanel1.Name = "metroSetPanel1";
            this.metroSetPanel1.Size = new System.Drawing.Size(551, 38);
            this.metroSetPanel1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetPanel1.StyleManager = null;
            this.metroSetPanel1.TabIndex = 1;
            this.metroSetPanel1.ThemeAuthor = "Narwin";
            this.metroSetPanel1.ThemeName = "MetroLite";
            this.metroSetPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.metroSetPanel1_Paint);
            // 
            // lb_Account
            // 
            this.lb_Account.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lb_Account.IsDerivedStyle = true;
            this.lb_Account.Location = new System.Drawing.Point(3, 3);
            this.lb_Account.Name = "lb_Account";
            this.lb_Account.Size = new System.Drawing.Size(141, 30);
            this.lb_Account.Style = MetroSet_UI.Enums.Style.Light;
            this.lb_Account.StyleManager = null;
            this.lb_Account.TabIndex = 1;
            this.lb_Account.Text = "Tên người dùng";
            this.lb_Account.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_Account.ThemeAuthor = "Narwin";
            this.lb_Account.ThemeName = "MetroLite";
            this.lb_Account.Click += new System.EventHandler(this.lb_Account_Click);
            // 
            // txb_Account
            // 
            this.txb_Account.AutoCompleteCustomSource = null;
            this.txb_Account.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txb_Account.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txb_Account.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txb_Account.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txb_Account.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txb_Account.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.txb_Account.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txb_Account.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txb_Account.Image = null;
            this.txb_Account.IsDerivedStyle = true;
            this.txb_Account.Lines = null;
            this.txb_Account.Location = new System.Drawing.Point(143, 3);
            this.txb_Account.MaxLength = 32767;
            this.txb_Account.Multiline = false;
            this.txb_Account.Name = "txb_Account";
            this.txb_Account.ReadOnly = false;
            this.txb_Account.Size = new System.Drawing.Size(387, 30);
            this.txb_Account.Style = MetroSet_UI.Enums.Style.Light;
            this.txb_Account.StyleManager = null;
            this.txb_Account.TabIndex = 0;
            this.txb_Account.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txb_Account.ThemeAuthor = "Narwin";
            this.txb_Account.ThemeName = "MetroLite";
            this.txb_Account.UseSystemPasswordChar = false;
            this.txb_Account.WatermarkText = "Nhập tài khoản";
            // 
            // metroSetControlBox1
            // 
            this.metroSetControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroSetControlBox1.CloseHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.metroSetControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this.metroSetControlBox1.CloseNormalForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.DisabledForeColor = System.Drawing.Color.DimGray;
            this.metroSetControlBox1.IsDerivedStyle = true;
            this.metroSetControlBox1.Location = new System.Drawing.Point(701, 0);
            this.metroSetControlBox1.MaximizeBox = true;
            this.metroSetControlBox1.MaximizeHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.metroSetControlBox1.MaximizeHoverForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.MaximizeNormalForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.MinimizeBox = true;
            this.metroSetControlBox1.MinimizeHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.metroSetControlBox1.MinimizeHoverForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.MinimizeNormalForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.Name = "metroSetControlBox1";
            this.metroSetControlBox1.Size = new System.Drawing.Size(100, 25);
            this.metroSetControlBox1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetControlBox1.StyleManager = null;
            this.metroSetControlBox1.TabIndex = 2;
            this.metroSetControlBox1.Text = "metroSetControlBox1";
            this.metroSetControlBox1.ThemeAuthor = "Narwin";
            this.metroSetControlBox1.ThemeName = "MetroLite";
            // 
            // metroSetPanel2
            // 
            this.metroSetPanel2.BackgroundColor = System.Drawing.Color.White;
            this.metroSetPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.metroSetPanel2.BorderThickness = 1;
            this.metroSetPanel2.Controls.Add(this.lb_Password);
            this.metroSetPanel2.Controls.Add(this.txb_Pwd);
            this.metroSetPanel2.IsDerivedStyle = true;
            this.metroSetPanel2.Location = new System.Drawing.Point(77, 147);
            this.metroSetPanel2.Name = "metroSetPanel2";
            this.metroSetPanel2.Size = new System.Drawing.Size(551, 38);
            this.metroSetPanel2.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetPanel2.StyleManager = null;
            this.metroSetPanel2.TabIndex = 3;
            this.metroSetPanel2.ThemeAuthor = "Narwin";
            this.metroSetPanel2.ThemeName = "MetroLite";
            // 
            // lb_Password
            // 
            this.lb_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lb_Password.IsDerivedStyle = true;
            this.lb_Password.Location = new System.Drawing.Point(3, 3);
            this.lb_Password.Name = "lb_Password";
            this.lb_Password.Size = new System.Drawing.Size(141, 30);
            this.lb_Password.Style = MetroSet_UI.Enums.Style.Light;
            this.lb_Password.StyleManager = null;
            this.lb_Password.TabIndex = 1;
            this.lb_Password.Text = "Mật khẩu";
            this.lb_Password.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_Password.ThemeAuthor = "Narwin";
            this.lb_Password.ThemeName = "MetroLite";
            // 
            // txb_Pwd
            // 
            this.txb_Pwd.AutoCompleteCustomSource = null;
            this.txb_Pwd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txb_Pwd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txb_Pwd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txb_Pwd.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txb_Pwd.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txb_Pwd.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.txb_Pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txb_Pwd.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txb_Pwd.Image = null;
            this.txb_Pwd.IsDerivedStyle = true;
            this.txb_Pwd.Lines = null;
            this.txb_Pwd.Location = new System.Drawing.Point(143, 3);
            this.txb_Pwd.MaxLength = 32767;
            this.txb_Pwd.Multiline = false;
            this.txb_Pwd.Name = "txb_Pwd";
            this.txb_Pwd.ReadOnly = false;
            this.txb_Pwd.Size = new System.Drawing.Size(387, 30);
            this.txb_Pwd.Style = MetroSet_UI.Enums.Style.Light;
            this.txb_Pwd.StyleManager = null;
            this.txb_Pwd.TabIndex = 0;
            this.txb_Pwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txb_Pwd.ThemeAuthor = "Narwin";
            this.txb_Pwd.ThemeName = "MetroLite";
            this.txb_Pwd.UseSystemPasswordChar = true;
            this.txb_Pwd.WatermarkText = "Mật khẩu";
            // 
            // btn_Login
            // 
            this.btn_Login.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_Login.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_Login.DisabledForeColor = System.Drawing.Color.Gray;
            this.btn_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_Login.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btn_Login.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btn_Login.HoverTextColor = System.Drawing.Color.White;
            this.btn_Login.IsDerivedStyle = true;
            this.btn_Login.Location = new System.Drawing.Point(179, 259);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_Login.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_Login.NormalTextColor = System.Drawing.Color.White;
            this.btn_Login.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btn_Login.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btn_Login.PressTextColor = System.Drawing.Color.White;
            this.btn_Login.Size = new System.Drawing.Size(97, 42);
            this.btn_Login.Style = MetroSet_UI.Enums.Style.Light;
            this.btn_Login.StyleManager = null;
            this.btn_Login.TabIndex = 4;
            this.btn_Login.Text = "Đăng nhập";
            this.btn_Login.ThemeAuthor = "Narwin";
            this.btn_Login.ThemeName = "MetroLite";
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // btn_Quit
            // 
            this.btn_Quit.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_Quit.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_Quit.DisabledForeColor = System.Drawing.Color.Gray;
            this.btn_Quit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_Quit.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btn_Quit.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btn_Quit.HoverTextColor = System.Drawing.Color.White;
            this.btn_Quit.IsDerivedStyle = true;
            this.btn_Quit.Location = new System.Drawing.Point(476, 259);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_Quit.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_Quit.NormalTextColor = System.Drawing.Color.White;
            this.btn_Quit.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btn_Quit.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btn_Quit.PressTextColor = System.Drawing.Color.White;
            this.btn_Quit.Size = new System.Drawing.Size(88, 42);
            this.btn_Quit.Style = MetroSet_UI.Enums.Style.Light;
            this.btn_Quit.StyleManager = null;
            this.btn_Quit.TabIndex = 5;
            this.btn_Quit.Text = "Thoát";
            this.btn_Quit.ThemeAuthor = "Narwin";
            this.btn_Quit.ThemeName = "MetroLite";
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // pnl_Login
            // 
            this.pnl_Login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnl_Login.BackgroundColor = System.Drawing.Color.White;
            this.pnl_Login.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.pnl_Login.BorderThickness = 1;
            this.pnl_Login.Controls.Add(this.lbl_ForgotPwd);
            this.pnl_Login.Controls.Add(this.ckbx_Remember);
            this.pnl_Login.Controls.Add(this.lb_DangNhap);
            this.pnl_Login.Controls.Add(this.btn_Quit);
            this.pnl_Login.Controls.Add(this.metroSetPanel1);
            this.pnl_Login.Controls.Add(this.btn_Login);
            this.pnl_Login.Controls.Add(this.metroSetPanel2);
            this.pnl_Login.IsDerivedStyle = true;
            this.pnl_Login.Location = new System.Drawing.Point(33, 81);
            this.pnl_Login.Name = "pnl_Login";
            this.pnl_Login.Size = new System.Drawing.Size(718, 316);
            this.pnl_Login.Style = MetroSet_UI.Enums.Style.Light;
            this.pnl_Login.StyleManager = null;
            this.pnl_Login.TabIndex = 6;
            this.pnl_Login.ThemeAuthor = "Narwin";
            this.pnl_Login.ThemeName = "MetroLite";
            // 
            // lbl_ForgotPwd
            // 
            this.lbl_ForgotPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbl_ForgotPwd.IsDerivedStyle = true;
            this.lbl_ForgotPwd.Location = new System.Drawing.Point(523, 193);
            this.lbl_ForgotPwd.Name = "lbl_ForgotPwd";
            this.lbl_ForgotPwd.Size = new System.Drawing.Size(179, 23);
            this.lbl_ForgotPwd.Style = MetroSet_UI.Enums.Style.Light;
            this.lbl_ForgotPwd.StyleManager = null;
            this.lbl_ForgotPwd.TabIndex = 7;
            this.lbl_ForgotPwd.Text = "Quên mật khẩu?";
            this.lbl_ForgotPwd.ThemeAuthor = "Narwin";
            this.lbl_ForgotPwd.ThemeName = "MetroLite";
            this.lbl_ForgotPwd.Click += new System.EventHandler(this.lbl_ForgotPwd_Click);
            // 
            // ckbx_Remember
            // 
            this.ckbx_Remember.BackColor = System.Drawing.Color.Transparent;
            this.ckbx_Remember.BackgroundColor = System.Drawing.Color.White;
            this.ckbx_Remember.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.ckbx_Remember.Checked = false;
            this.ckbx_Remember.CheckSignColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.ckbx_Remember.CheckState = MetroSet_UI.Enums.CheckState.Unchecked;
            this.ckbx_Remember.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckbx_Remember.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.ckbx_Remember.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ckbx_Remember.IsDerivedStyle = true;
            this.ckbx_Remember.Location = new System.Drawing.Point(106, 193);
            this.ckbx_Remember.Name = "ckbx_Remember";
            this.ckbx_Remember.SignStyle = MetroSet_UI.Enums.SignStyle.Sign;
            this.ckbx_Remember.Size = new System.Drawing.Size(208, 16);
            this.ckbx_Remember.Style = MetroSet_UI.Enums.Style.Light;
            this.ckbx_Remember.StyleManager = null;
            this.ckbx_Remember.TabIndex = 6;
            this.ckbx_Remember.Text = "Nhớ mật khẩu";
            this.ckbx_Remember.ThemeAuthor = "Narwin";
            this.ckbx_Remember.ThemeName = "MetroLite";
            // 
            // metroSetLabel1
            // 
            this.metroSetLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroSetLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.metroSetLabel1.IsDerivedStyle = true;
            this.metroSetLabel1.Location = new System.Drawing.Point(12, 415);
            this.metroSetLabel1.Name = "metroSetLabel1";
            this.metroSetLabel1.Size = new System.Drawing.Size(776, 23);
            this.metroSetLabel1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetLabel1.StyleManager = null;
            this.metroSetLabel1.TabIndex = 7;
            this.metroSetLabel1.Text = "Sản phẩm của công ty TBT";
            this.metroSetLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroSetLabel1.ThemeAuthor = "Narwin";
            this.metroSetLabel1.ThemeName = "MetroLite";
            this.metroSetLabel1.Click += new System.EventHandler(this.metroSetLabel1_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroSetLabel1);
            this.Controls.Add(this.pnl_Login);
            this.Controls.Add(this.metroSetControlBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.ShowLeftRect = false;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.metroSetPanel1.ResumeLayout(false);
            this.metroSetPanel2.ResumeLayout(false);
            this.pnl_Login.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroSet_UI.Controls.MetroSetLabel lb_DangNhap;
        private MetroSet_UI.Controls.MetroSetPanel metroSetPanel1;
        private MetroSet_UI.Controls.MetroSetLabel lb_Account;
        private MetroSet_UI.Controls.MetroSetTextBox txb_Account;
        private MetroSet_UI.Controls.MetroSetControlBox metroSetControlBox1;
        private MetroSet_UI.Controls.MetroSetPanel metroSetPanel2;
        private MetroSet_UI.Controls.MetroSetLabel lb_Password;
        private MetroSet_UI.Controls.MetroSetTextBox txb_Pwd;
        private MetroSet_UI.Controls.MetroSetButton btn_Login;
        private MetroSet_UI.Controls.MetroSetButton btn_Quit;
        private MetroSet_UI.Controls.MetroSetPanel pnl_Login;
        private MetroSet_UI.Controls.MetroSetCheckBox ckbx_Remember;
        private MetroSet_UI.Controls.MetroSetLabel metroSetLabel1;
        private MetroSet_UI.Controls.MetroSetLabel lbl_ForgotPwd;
    }
}

