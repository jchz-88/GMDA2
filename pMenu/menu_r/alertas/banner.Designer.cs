namespace ModuloAlertas
{
    partial class banner
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
            this.tm_banner = new System.Windows.Forms.Timer(this.components);
            this.lb_text = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tm_banner
            // 
            this.tm_banner.Interval = 25;
            this.tm_banner.Tick += new System.EventHandler(this.tm_banner_Tick);
            // 
            // lb_text
            // 
            this.lb_text.AutoEllipsis = true;
            this.lb_text.AutoSize = true;
            this.lb_text.BackColor = System.Drawing.Color.Transparent;
            this.lb_text.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_text.ForeColor = System.Drawing.Color.DarkRed;
            this.lb_text.Location = new System.Drawing.Point(51, 9);
            this.lb_text.Name = "lb_text";
            this.lb_text.Size = new System.Drawing.Size(135, 38);
            this.lb_text.TabIndex = 6;
            this.lb_text.Text = "label5";
            this.lb_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(443, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 38);
            this.label2.TabIndex = 7;
            this.label2.Text = "label5";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // banner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 77);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "banner";
            this.Text = "banner";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.banner_FormClosed);
            this.Load += new System.EventHandler(this.banner_Load);
            this.DoubleClick += new System.EventHandler(this.banner_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer tm_banner;
        private System.Windows.Forms.Label lb_text;
        private System.Windows.Forms.Label label2;
    }
}