
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pnl_Login = new System.Windows.Forms.Panel();
            this.lbl_SPTBT = new System.Windows.Forms.Label();
            this.pl_Title = new System.Windows.Forms.Panel();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.lbl_TBT = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_LoginForm = new System.Windows.Forms.Panel();
            this.ckbx_RememberPwd = new System.Windows.Forms.CheckBox();
            this.ckbx_ShowPwd = new System.Windows.Forms.CheckBox();
            this.lbl_Forgot = new System.Windows.Forms.Label();
            this.txt_Pwd = new System.Windows.Forms.TextBox();
            this.lbl_Pwd = new System.Windows.Forms.Label();
            this.txt_Account = new System.Windows.Forms.TextBox();
            this.lbl_Account = new System.Windows.Forms.Label();
            this.btn_Quit = new FontAwesome.Sharp.IconButton();
            this.btn_Login = new FontAwesome.Sharp.IconButton();
            this.pnl_Login.SuspendLayout();
            this.pl_Title.SuspendLayout();
            this.pnl_LoginForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Login
            // 
            this.pnl_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.pnl_Login.Controls.Add(this.lbl_SPTBT);
            this.pnl_Login.Controls.Add(this.pl_Title);
            this.pnl_Login.Controls.Add(this.pnl_LoginForm);
            resources.ApplyResources(this.pnl_Login, "pnl_Login");
            this.pnl_Login.Name = "pnl_Login";
            // 
            // lbl_SPTBT
            // 
            resources.ApplyResources(this.lbl_SPTBT, "lbl_SPTBT");
            this.lbl_SPTBT.ForeColor = System.Drawing.Color.White;
            this.lbl_SPTBT.Name = "lbl_SPTBT";
            // 
            // pl_Title
            // 
            this.pl_Title.Controls.Add(this.lbl_Title);
            this.pl_Title.Controls.Add(this.lbl_TBT);
            this.pl_Title.Controls.Add(this.label1);
            resources.ApplyResources(this.pl_Title, "pl_Title");
            this.pl_Title.Name = "pl_Title";
            // 
            // lbl_Title
            // 
            resources.ApplyResources(this.lbl_Title, "lbl_Title");
            this.lbl_Title.ForeColor = System.Drawing.Color.White;
            this.lbl_Title.Name = "lbl_Title";
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
            this.pnl_LoginForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_LoginForm.Controls.Add(this.ckbx_RememberPwd);
            this.pnl_LoginForm.Controls.Add(this.ckbx_ShowPwd);
            this.pnl_LoginForm.Controls.Add(this.lbl_Forgot);
            this.pnl_LoginForm.Controls.Add(this.txt_Pwd);
            this.pnl_LoginForm.Controls.Add(this.lbl_Pwd);
            this.pnl_LoginForm.Controls.Add(this.txt_Account);
            this.pnl_LoginForm.Controls.Add(this.lbl_Account);
            this.pnl_LoginForm.Controls.Add(this.btn_Quit);
            this.pnl_LoginForm.Controls.Add(this.btn_Login);
            this.pnl_LoginForm.Name = "pnl_LoginForm";
            // 
            // ckbx_RememberPwd
            // 
            resources.ApplyResources(this.ckbx_RememberPwd, "ckbx_RememberPwd");
            this.ckbx_RememberPwd.ForeColor = System.Drawing.Color.White;
            this.ckbx_RememberPwd.Name = "ckbx_RememberPwd";
            this.ckbx_RememberPwd.UseVisualStyleBackColor = true;
            this.ckbx_RememberPwd.CheckedChanged += new System.EventHandler(this.ckbx_RememberPwd_CheckedChanged);
            // 
            // ckbx_ShowPwd
            // 
            resources.ApplyResources(this.ckbx_ShowPwd, "ckbx_ShowPwd");
            this.ckbx_ShowPwd.ForeColor = System.Drawing.Color.White;
            this.ckbx_ShowPwd.Name = "ckbx_ShowPwd";
            this.ckbx_ShowPwd.UseVisualStyleBackColor = true;
            this.ckbx_ShowPwd.CheckedChanged += new System.EventHandler(this.ckbx_ShowPwd_CheckedChanged);
            // 
            // lbl_Forgot
            // 
            resources.ApplyResources(this.lbl_Forgot, "lbl_Forgot");
            this.lbl_Forgot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Forgot.ForeColor = System.Drawing.Color.White;
            this.lbl_Forgot.Name = "lbl_Forgot";
            this.lbl_Forgot.Click += new System.EventHandler(this.lbl_Forgot_Click);
            // 
            // txt_Pwd
            // 
            resources.ApplyResources(this.txt_Pwd, "txt_Pwd");
            this.txt_Pwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.txt_Pwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Pwd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Pwd.ForeColor = System.Drawing.Color.White;
            this.txt_Pwd.Name = "txt_Pwd";
            this.txt_Pwd.UseSystemPasswordChar = true;
            // 
            // lbl_Pwd
            // 
            resources.ApplyResources(this.lbl_Pwd, "lbl_Pwd");
            this.lbl_Pwd.ForeColor = System.Drawing.Color.White;
            this.lbl_Pwd.Name = "lbl_Pwd";
            // 
            // txt_Account
            // 
            resources.ApplyResources(this.txt_Account, "txt_Account");
            this.txt_Account.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(34)))), ((int)(((byte)(49)))));
            this.txt_Account.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Account.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Account.ForeColor = System.Drawing.Color.White;
            this.txt_Account.Name = "txt_Account";
            // 
            // lbl_Account
            // 
            resources.ApplyResources(this.lbl_Account, "lbl_Account");
            this.lbl_Account.ForeColor = System.Drawing.Color.White;
            this.lbl_Account.Name = "lbl_Account";
            // 
            // btn_Quit
            // 
            resources.ApplyResources(this.btn_Quit, "btn_Quit");
            this.btn_Quit.ForeColor = System.Drawing.Color.White;
            this.btn_Quit.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btn_Quit.IconColor = System.Drawing.Color.White;
            this.btn_Quit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Quit.IconSize = 18;
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // btn_Login
            // 
            resources.ApplyResources(this.btn_Login, "btn_Login");
            this.btn_Login.ForeColor = System.Drawing.Color.White;
            this.btn_Login.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.btn_Login.IconColor = System.Drawing.Color.White;
            this.btn_Login.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Login.IconSize = 18;
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
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
            this.pl_Title.ResumeLayout(false);
            this.pl_Title.PerformLayout();
            this.pnl_LoginForm.ResumeLayout(false);
            this.pnl_LoginForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_TBT;
        private System.Windows.Forms.Panel pnl_LoginForm;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.TextBox txt_Pwd;
        private System.Windows.Forms.Label lbl_Pwd;
        private System.Windows.Forms.TextBox txt_Account;
        private System.Windows.Forms.Label lbl_Account;
        private FontAwesome.Sharp.IconButton btn_Quit;
        private FontAwesome.Sharp.IconButton btn_Login;
        private System.Windows.Forms.Label lbl_Forgot;
        private System.Windows.Forms.CheckBox ckbx_ShowPwd;
        private System.Windows.Forms.Panel pl_Title;
        private System.Windows.Forms.Label lbl_SPTBT;
        private System.Windows.Forms.CheckBox ckbx_RememberPwd;
    }
}