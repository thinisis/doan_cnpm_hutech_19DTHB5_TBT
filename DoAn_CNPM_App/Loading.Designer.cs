
namespace DoAn_CNPM_App
{
    partial class Loading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            this.Loader = new Bunifu.UI.WinForms.BunifuLoader();
            this.lbl_Wait = new Bunifu.UI.WinForms.BunifuLabel();
            this.SuspendLayout();
            // 
            // Loader
            // 
            this.Loader.AllowStylePresets = true;
            this.Loader.BackColor = System.Drawing.Color.Transparent;
            this.Loader.CapStyle = Bunifu.UI.WinForms.BunifuLoader.CapStyles.Round;
            this.Loader.Color = System.Drawing.Color.DodgerBlue;
            this.Loader.Colors = new Bunifu.UI.WinForms.Bloom[0];
            this.Loader.Customization = "";
            this.Loader.DashWidth = 0.5F;
            this.Loader.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Loader.Image = null;
            this.Loader.Location = new System.Drawing.Point(194, 90);
            this.Loader.Name = "Loader";
            this.Loader.NoRounding = false;
            this.Loader.Preset = Bunifu.UI.WinForms.BunifuLoader.StylePresets.Solid;
            this.Loader.RingStyle = Bunifu.UI.WinForms.BunifuLoader.RingStyles.Solid;
            this.Loader.ShowText = false;
            this.Loader.Size = new System.Drawing.Size(86, 85);
            this.Loader.Speed = 7;
            this.Loader.TabIndex = 1;
            this.Loader.Text = "bunifuLoader1";
            this.Loader.TextPadding = new System.Windows.Forms.Padding(0);
            this.Loader.Thickness = 6;
            this.Loader.Transparent = true;
            this.Loader.UseWaitCursor = true;
            // 
            // lbl_Wait
            // 
            this.lbl_Wait.AllowParentOverrides = false;
            this.lbl_Wait.AutoEllipsis = false;
            this.lbl_Wait.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Wait.CursorType = System.Windows.Forms.Cursors.Default;
            this.lbl_Wait.Font = new System.Drawing.Font("Open Sans", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Wait.Location = new System.Drawing.Point(70, 12);
            this.lbl_Wait.Name = "lbl_Wait";
            this.lbl_Wait.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_Wait.Size = new System.Drawing.Size(296, 69);
            this.lbl_Wait.TabIndex = 2;
            this.lbl_Wait.Text = "Vui lòng chờ";
            this.lbl_Wait.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lbl_Wait.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.lbl_Wait.UseWaitCursor = true;
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 199);
            this.Controls.Add(this.lbl_Wait);
            this.Controls.Add(this.Loader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Loading";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.Loading_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuLoader Loader;
        private Bunifu.UI.WinForms.BunifuLabel lbl_Wait;
    }
}