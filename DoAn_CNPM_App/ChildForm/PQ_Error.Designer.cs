
namespace DoAn_CNPM_App.ChildForm
{
    partial class PQ_Error
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
            this.pnl_PQError = new System.Windows.Forms.Panel();
            this.ptbx_Error = new FontAwesome.Sharp.IconPictureBox();
            this.lbl_NotPermission = new System.Windows.Forms.Label();
            this.pnl_PQError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbx_Error)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_PQError
            // 
            this.pnl_PQError.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_PQError.Controls.Add(this.lbl_NotPermission);
            this.pnl_PQError.Controls.Add(this.ptbx_Error);
            this.pnl_PQError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_PQError.Location = new System.Drawing.Point(0, 0);
            this.pnl_PQError.Name = "pnl_PQError";
            this.pnl_PQError.Size = new System.Drawing.Size(800, 450);
            this.pnl_PQError.TabIndex = 0;
            // 
            // ptbx_Error
            // 
            this.ptbx_Error.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ptbx_Error.BackColor = System.Drawing.Color.Transparent;
            this.ptbx_Error.ForeColor = System.Drawing.Color.Red;
            this.ptbx_Error.IconChar = FontAwesome.Sharp.IconChar.ExclamationTriangle;
            this.ptbx_Error.IconColor = System.Drawing.Color.Red;
            this.ptbx_Error.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ptbx_Error.IconSize = 158;
            this.ptbx_Error.Location = new System.Drawing.Point(351, 92);
            this.ptbx_Error.Name = "ptbx_Error";
            this.ptbx_Error.Size = new System.Drawing.Size(158, 161);
            this.ptbx_Error.TabIndex = 0;
            this.ptbx_Error.TabStop = false;
            // 
            // lbl_NotPermission
            // 
            this.lbl_NotPermission.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_NotPermission.AutoSize = true;
            this.lbl_NotPermission.Font = new System.Drawing.Font("Open Sans", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_NotPermission.Location = new System.Drawing.Point(48, 282);
            this.lbl_NotPermission.Name = "lbl_NotPermission";
            this.lbl_NotPermission.Size = new System.Drawing.Size(705, 39);
            this.lbl_NotPermission.TabIndex = 1;
            this.lbl_NotPermission.Text = "Xin lỗi, bạn không có quyền truy cập vào trang này!";
            // 
            // PQ_Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnl_PQError);
            this.Name = "PQ_Error";
            this.Text = "LỖI";
            this.pnl_PQError.ResumeLayout(false);
            this.pnl_PQError.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbx_Error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_PQError;
        private FontAwesome.Sharp.IconPictureBox ptbx_Error;
        private System.Windows.Forms.Label lbl_NotPermission;
    }
}