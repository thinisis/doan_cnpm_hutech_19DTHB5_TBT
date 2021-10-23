
namespace DoAn_CNPM_App
{
    partial class Login
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
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pnl_Login = new System.Windows.Forms.Panel();
            this.lbl_SPTBT = new System.Windows.Forms.Label();
            this.lbl_TBT = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_LoginForm = new System.Windows.Forms.Panel();
            this.txt_Pwd = new Bunifu.UI.WinForms.BunifuTextBox();
            this.txt_Account = new Bunifu.UI.WinForms.BunifuTextBox();
            this.ckbx_RememberPwd = new System.Windows.Forms.CheckBox();
            this.lbl_Forgot = new System.Windows.Forms.Label();
            this.btn_Quit = new FontAwesome.Sharp.IconButton();
            this.btn_Login = new FontAwesome.Sharp.IconButton();
            this.lbl_Title = new Bunifu.UI.WinForms.BunifuLabel();
            this.lbl_MTitle = new Bunifu.UI.WinForms.BunifuLabel();
            this.pnl_Login.SuspendLayout();
            this.pnl_LoginForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Login
            // 
            this.pnl_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.pnl_Login.Controls.Add(this.lbl_MTitle);
            this.pnl_Login.Controls.Add(this.lbl_TBT);
            this.pnl_Login.Controls.Add(this.label1);
            this.pnl_Login.Controls.Add(this.pnl_LoginForm);
            resources.ApplyResources(this.pnl_Login, "pnl_Login");
            this.pnl_Login.Name = "pnl_Login";
            this.pnl_Login.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Login_Paint);
            // 
            // lbl_SPTBT
            // 
            resources.ApplyResources(this.lbl_SPTBT, "lbl_SPTBT");
            this.lbl_SPTBT.ForeColor = System.Drawing.Color.White;
            this.lbl_SPTBT.Name = "lbl_SPTBT";
            this.lbl_SPTBT.Click += new System.EventHandler(this.lbl_SPTBT_Click);
            // 
            // lbl_TBT
            // 
            resources.ApplyResources(this.lbl_TBT, "lbl_TBT");
            this.lbl_TBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_TBT.ForeColor = System.Drawing.Color.White;
            this.lbl_TBT.Name = "lbl_TBT";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pnl_LoginForm
            // 
            resources.ApplyResources(this.pnl_LoginForm, "pnl_LoginForm");
            this.pnl_LoginForm.BackColor = System.Drawing.Color.White;
            this.pnl_LoginForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_LoginForm.Controls.Add(this.lbl_Title);
            this.pnl_LoginForm.Controls.Add(this.txt_Pwd);
            this.pnl_LoginForm.Controls.Add(this.txt_Account);
            this.pnl_LoginForm.Controls.Add(this.lbl_SPTBT);
            this.pnl_LoginForm.Controls.Add(this.ckbx_RememberPwd);
            this.pnl_LoginForm.Controls.Add(this.lbl_Forgot);
            this.pnl_LoginForm.Controls.Add(this.btn_Quit);
            this.pnl_LoginForm.Controls.Add(this.btn_Login);
            this.pnl_LoginForm.Name = "pnl_LoginForm";
            this.pnl_LoginForm.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_LoginForm_Paint);
            // 
            // txt_Pwd
            // 
            this.txt_Pwd.AcceptsReturn = false;
            this.txt_Pwd.AcceptsTab = false;
            resources.ApplyResources(this.txt_Pwd, "txt_Pwd");
            this.txt_Pwd.AnimationSpeed = 200;
            this.txt_Pwd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txt_Pwd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txt_Pwd.AutoSizeHeight = true;
            this.txt_Pwd.BackColor = System.Drawing.Color.White;
            this.txt_Pwd.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txt_Pwd.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txt_Pwd.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txt_Pwd.BorderColorIdle = System.Drawing.Color.Silver;
            this.txt_Pwd.BorderRadius = 1;
            this.txt_Pwd.BorderThickness = 1;
            this.txt_Pwd.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txt_Pwd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Pwd.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.txt_Pwd.DefaultText = "";
            this.txt_Pwd.FillColor = System.Drawing.Color.White;
            this.txt_Pwd.HideSelection = true;
            this.txt_Pwd.IconLeft = ((System.Drawing.Image)(resources.GetObject("txt_Pwd.IconLeft")));
            this.txt_Pwd.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Pwd.IconPadding = 10;
            this.txt_Pwd.IconRight = null;
            this.txt_Pwd.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Pwd.Lines = new string[0];
            this.txt_Pwd.MaxLength = 32767;
            this.txt_Pwd.Modified = false;
            this.txt_Pwd.Multiline = false;
            this.txt_Pwd.Name = "txt_Pwd";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txt_Pwd.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txt_Pwd.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txt_Pwd.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txt_Pwd.OnIdleState = stateProperties4;
            this.txt_Pwd.PasswordChar = '●';
            this.txt_Pwd.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txt_Pwd.PlaceholderText = "Enter text";
            this.txt_Pwd.ReadOnly = false;
            this.txt_Pwd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_Pwd.SelectedText = "";
            this.txt_Pwd.SelectionLength = 0;
            this.txt_Pwd.SelectionStart = 0;
            this.txt_Pwd.ShortcutsEnabled = true;
            this.txt_Pwd.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
            this.txt_Pwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_Pwd.TextMarginBottom = 0;
            this.txt_Pwd.TextMarginLeft = 3;
            this.txt_Pwd.TextMarginTop = 1;
            this.txt_Pwd.TextPlaceholder = "Enter text";
            this.txt_Pwd.UseSystemPasswordChar = true;
            this.txt_Pwd.WordWrap = true;
            // 
            // txt_Account
            // 
            this.txt_Account.AcceptsReturn = false;
            this.txt_Account.AcceptsTab = false;
            resources.ApplyResources(this.txt_Account, "txt_Account");
            this.txt_Account.AnimationSpeed = 200;
            this.txt_Account.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txt_Account.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txt_Account.AutoSizeHeight = true;
            this.txt_Account.BackColor = System.Drawing.Color.White;
            this.txt_Account.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txt_Account.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txt_Account.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txt_Account.BorderColorIdle = System.Drawing.Color.Silver;
            this.txt_Account.BorderRadius = 1;
            this.txt_Account.BorderThickness = 1;
            this.txt_Account.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txt_Account.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Account.DefaultFont = new System.Drawing.Font("Open Sans SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.txt_Account.DefaultText = "";
            this.txt_Account.FillColor = System.Drawing.Color.White;
            this.txt_Account.HideSelection = true;
            this.txt_Account.IconLeft = ((System.Drawing.Image)(resources.GetObject("txt_Account.IconLeft")));
            this.txt_Account.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Account.IconPadding = 10;
            this.txt_Account.IconRight = null;
            this.txt_Account.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Account.Lines = new string[0];
            this.txt_Account.MaxLength = 32767;
            this.txt_Account.Modified = false;
            this.txt_Account.Multiline = false;
            this.txt_Account.Name = "txt_Account";
            stateProperties5.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txt_Account.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txt_Account.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txt_Account.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Silver;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txt_Account.OnIdleState = stateProperties8;
            this.txt_Account.PasswordChar = '\0';
            this.txt_Account.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txt_Account.PlaceholderText = "Nhập tài khoản";
            this.txt_Account.ReadOnly = false;
            this.txt_Account.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_Account.SelectedText = "";
            this.txt_Account.SelectionLength = 0;
            this.txt_Account.SelectionStart = 0;
            this.txt_Account.ShortcutsEnabled = true;
            this.txt_Account.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Material;
            this.txt_Account.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_Account.TextMarginBottom = 0;
            this.txt_Account.TextMarginLeft = 3;
            this.txt_Account.TextMarginTop = 1;
            this.txt_Account.TextPlaceholder = "Nhập tài khoản";
            this.txt_Account.UseSystemPasswordChar = false;
            this.txt_Account.WordWrap = true;
            this.txt_Account.TextChanged += new System.EventHandler(this.txt_Account_TextChanged);
            // 
            // ckbx_RememberPwd
            // 
            resources.ApplyResources(this.ckbx_RememberPwd, "ckbx_RememberPwd");
            this.ckbx_RememberPwd.ForeColor = System.Drawing.Color.Gray;
            this.ckbx_RememberPwd.Name = "ckbx_RememberPwd";
            this.ckbx_RememberPwd.UseVisualStyleBackColor = true;
            this.ckbx_RememberPwd.CheckedChanged += new System.EventHandler(this.ckbx_RememberPwd_CheckedChanged);
            // 
            // lbl_Forgot
            // 
            resources.ApplyResources(this.lbl_Forgot, "lbl_Forgot");
            this.lbl_Forgot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Forgot.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Forgot.Name = "lbl_Forgot";
            this.lbl_Forgot.Click += new System.EventHandler(this.lbl_Forgot_Click);
            // 
            // btn_Quit
            // 
            resources.ApplyResources(this.btn_Quit, "btn_Quit");
            this.btn_Quit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(34)))), ((int)(((byte)(48)))));
            this.btn_Quit.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btn_Quit.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(34)))), ((int)(((byte)(48)))));
            this.btn_Quit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Quit.IconSize = 24;
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // btn_Login
            // 
            resources.ApplyResources(this.btn_Login, "btn_Login");
            this.btn_Login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(34)))), ((int)(((byte)(48)))));
            this.btn_Login.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.btn_Login.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(34)))), ((int)(((byte)(48)))));
            this.btn_Login.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Login.IconSize = 24;
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.AllowParentOverrides = false;
            resources.ApplyResources(this.lbl_Title, "lbl_Title");
            this.lbl_Title.AutoEllipsis = false;
            this.lbl_Title.CursorType = System.Windows.Forms.Cursors.Default;
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lbl_Title.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // lbl_MTitle
            // 
            this.lbl_MTitle.AllowParentOverrides = false;
            resources.ApplyResources(this.lbl_MTitle, "lbl_MTitle");
            this.lbl_MTitle.AutoEllipsis = false;
            this.lbl_MTitle.CursorType = System.Windows.Forms.Cursors.Default;
            this.lbl_MTitle.ForeColor = System.Drawing.Color.White;
            this.lbl_MTitle.Name = "lbl_MTitle";
            this.lbl_MTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_MTitle.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // Login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.Controls.Add(this.pnl_Login);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.pnl_Login.ResumeLayout(false);
            this.pnl_Login.PerformLayout();
            this.pnl_LoginForm.ResumeLayout(false);
            this.pnl_LoginForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_TBT;
        private System.Windows.Forms.Panel pnl_LoginForm;
        private FontAwesome.Sharp.IconButton btn_Quit;
        private FontAwesome.Sharp.IconButton btn_Login;
        private System.Windows.Forms.Label lbl_Forgot;
        private System.Windows.Forms.Label lbl_SPTBT;
        private System.Windows.Forms.CheckBox ckbx_RememberPwd;
        private Bunifu.UI.WinForms.BunifuTextBox txt_Account;
        private Bunifu.UI.WinForms.BunifuTextBox txt_Pwd;
        private Bunifu.UI.WinForms.BunifuLabel lbl_Title;
        private Bunifu.UI.WinForms.BunifuLabel lbl_MTitle;
    }
}