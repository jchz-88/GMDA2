namespace HMDA.pMenu.menu_r.correos
{
    partial class carga_correo
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
            this.lb_user = new System.Windows.Forms.Label();
            this.tb_correo = new System.Windows.Forms.TextBox();
            this.bt_guardar = new System.Windows.Forms.Button();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_user
            // 
            this.lb_user.AutoSize = true;
            this.lb_user.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_user.ForeColor = System.Drawing.Color.White;
            this.lb_user.Location = new System.Drawing.Point(37, 9);
            this.lb_user.Name = "lb_user";
            this.lb_user.Size = new System.Drawing.Size(66, 24);
            this.lb_user.TabIndex = 0;
            this.lb_user.Text = "label1";
            // 
            // tb_correo
            // 
            this.tb_correo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_correo.Location = new System.Drawing.Point(41, 49);
            this.tb_correo.Name = "tb_correo";
            this.tb_correo.Size = new System.Drawing.Size(340, 26);
            this.tb_correo.TabIndex = 1;
            this.tb_correo.Enter += new System.EventHandler(this.tb_correo_Enter);
            // 
            // bt_guardar
            // 
            this.bt_guardar.Location = new System.Drawing.Point(186, 83);
            this.bt_guardar.Name = "bt_guardar";
            this.bt_guardar.Size = new System.Drawing.Size(56, 21);
            this.bt_guardar.TabIndex = 2;
            this.bt_guardar.Text = "Guardar";
            this.bt_guardar.UseVisualStyleBackColor = true;
            this.bt_guardar.Click += new System.EventHandler(this.bt_guardar_Click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox10.Image = global::HMDA.Properties.Resources.close__2_;
            this.pictureBox10.Location = new System.Drawing.Point(391, 0);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(25, 25);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 53;
            this.pictureBox10.TabStop = false;
            this.pictureBox10.Click += new System.EventHandler(this.pictureBox10_Click);
            // 
            // carga_correo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(419, 115);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.bt_guardar);
            this.Controls.Add(this.tb_correo);
            this.Controls.Add(this.lb_user);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "carga_correo";
            this.Text = "carga_correo";
            this.Load += new System.EventHandler(this.carga_correo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_user;
        private System.Windows.Forms.TextBox tb_correo;
        private System.Windows.Forms.Button bt_guardar;
        private System.Windows.Forms.PictureBox pictureBox10;
    }
}