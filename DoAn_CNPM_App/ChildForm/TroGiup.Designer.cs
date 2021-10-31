
namespace DoAn_CNPM_App.ChildForm
{
    partial class TroGiup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TroGiup));
            this.bunifuColorTransition1 = new Bunifu.UI.WinForms.BunifuColorTransition(this.components);
            this.lbl_TroGiup_Title = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.SuspendLayout();
            // 
            // bunifuColorTransition1
            // 
            this.bunifuColorTransition1.AutoTransition = true;
            this.bunifuColorTransition1.ColorArray = new System.Drawing.Color[] {
        System.Drawing.Color.Orange,
        System.Drawing.Color.LightBlue,
        System.Drawing.Color.Purple};
            this.bunifuColorTransition1.EndColor = System.Drawing.Color.Navy;
            this.bunifuColorTransition1.Interval = 10;
            this.bunifuColorTransition1.ProgessValue = 0;
            this.bunifuColorTransition1.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bunifuColorTransition1.TransitionControl = null;
            // 
            // lbl_TroGiup_Title
            // 
            this.lbl_TroGiup_Title.AllowParentOverrides = false;
            this.lbl_TroGiup_Title.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_TroGiup_Title.AutoEllipsis = false;
            this.lbl_TroGiup_Title.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_TroGiup_Title.CursorType = System.Windows.Forms.Cursors.Default;
            this.lbl_TroGiup_Title.Font = new System.Drawing.Font("Open Sans", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TroGiup_Title.Location = new System.Drawing.Point(12, 112);
            this.lbl_TroGiup_Title.Name = "lbl_TroGiup_Title";
            this.lbl_TroGiup_Title.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_TroGiup_Title.Size = new System.Drawing.Size(714, 69);
            this.lbl_TroGiup_Title.TabIndex = 0;
            this.lbl_TroGiup_Title.Text = "Liên hệ trợ giúp về phần mềm";
            this.lbl_TroGiup_Title.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lbl_TroGiup_Title.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel1.Location = new System.Drawing.Point(12, 187);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(302, 50);
            this.bunifuLabel1.TabIndex = 1;
            this.bunifuLabel1.Text = "Hotline: 0989999999\r\nEmail: phanmem@tbtcomputer.com";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // TroGiup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.lbl_TroGiup_Title);
            this.Name = "TroGiup";
            this.Text = "TRỢ GIÚP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuColorTransition bunifuColorTransition1;
        private Bunifu.UI.WinForms.BunifuLabel lbl_TroGiup_Title;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
    }
}