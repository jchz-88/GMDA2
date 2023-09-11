
namespace HMDA.pMenu.bus
{
    partial class resBus
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
            this.toolt_user = new System.Windows.Forms.ToolTip(this.components);
            this.gb_buscador_user = new System.Windows.Forms.GroupBox();
            this.pb_user = new System.Windows.Forms.PictureBox();
            this.lb_user = new System.Windows.Forms.Label();
            this.gb_buscador_titulos = new System.Windows.Forms.GroupBox();
            this.lb_paracopiar = new System.Windows.Forms.Label();
            this.cb_titulos_bus = new System.Windows.Forms.Label();
            this.cb_problema = new System.Windows.Forms.ComboBox();
            this.gb_buscador_sitios = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cb_sitios = new System.Windows.Forms.ComboBox();
            this.gb_buscador_paginas = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_paginas = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_sin = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.gb_buscador_user.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_user)).BeginInit();
            this.gb_buscador_titulos.SuspendLayout();
            this.gb_buscador_sitios.SuspendLayout();
            this.gb_buscador_paginas.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolt_user
            // 
            this.toolt_user.AutoPopDelay = 7000;
            this.toolt_user.BackColor = System.Drawing.Color.RosyBrown;
            this.toolt_user.ForeColor = System.Drawing.Color.Black;
            this.toolt_user.InitialDelay = 1000;
            this.toolt_user.ReshowDelay = 100;
            this.toolt_user.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolt_user_Draw);
            this.toolt_user.Popup += new System.Windows.Forms.PopupEventHandler(this.toolt_user_Popup);
            // 
            // gb_buscador_user
            // 
            this.gb_buscador_user.Controls.Add(this.pb_user);
            this.gb_buscador_user.Controls.Add(this.lb_user);
            this.gb_buscador_user.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gb_buscador_user.Location = new System.Drawing.Point(118, 4);
            this.gb_buscador_user.Name = "gb_buscador_user";
            this.gb_buscador_user.Size = new System.Drawing.Size(256, 80);
            this.gb_buscador_user.TabIndex = 45;
            this.gb_buscador_user.TabStop = false;
            // 
            // pb_user
            // 
            this.pb_user.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_user.Image = global::HMDA.Properties.Resources.usuario;
            this.pb_user.Location = new System.Drawing.Point(104, 10);
            this.pb_user.Name = "pb_user";
            this.pb_user.Size = new System.Drawing.Size(35, 35);
            this.pb_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_user.TabIndex = 33;
            this.pb_user.TabStop = false;
            this.pb_user.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pb_user_MouseDoubleClick_1);
            // 
            // lb_user
            // 
            this.lb_user.AutoSize = true;
            this.lb_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_user.ForeColor = System.Drawing.Color.Navy;
            this.lb_user.Location = new System.Drawing.Point(9, 47);
            this.lb_user.Name = "lb_user";
            this.lb_user.Size = new System.Drawing.Size(27, 25);
            this.lb_user.TabIndex = 18;
            this.lb_user.Text = "X";
            // 
            // gb_buscador_titulos
            // 
            this.gb_buscador_titulos.Controls.Add(this.lb_paracopiar);
            this.gb_buscador_titulos.Controls.Add(this.cb_titulos_bus);
            this.gb_buscador_titulos.Controls.Add(this.cb_problema);
            this.gb_buscador_titulos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gb_buscador_titulos.Location = new System.Drawing.Point(5, 86);
            this.gb_buscador_titulos.Name = "gb_buscador_titulos";
            this.gb_buscador_titulos.Size = new System.Drawing.Size(492, 80);
            this.gb_buscador_titulos.TabIndex = 43;
            this.gb_buscador_titulos.TabStop = false;
            // 
            // lb_paracopiar
            // 
            this.lb_paracopiar.AutoSize = true;
            this.lb_paracopiar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_paracopiar.Location = new System.Drawing.Point(434, 16);
            this.lb_paracopiar.Name = "lb_paracopiar";
            this.lb_paracopiar.Size = new System.Drawing.Size(35, 13);
            this.lb_paracopiar.TabIndex = 18;
            this.lb_paracopiar.Text = "label2";
            this.lb_paracopiar.TextChanged += new System.EventHandler(this.lb_paracopiar_TextChanged);
            // 
            // cb_titulos_bus
            // 
            this.cb_titulos_bus.AutoSize = true;
            this.cb_titulos_bus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_titulos_bus.ForeColor = System.Drawing.Color.Navy;
            this.cb_titulos_bus.Location = new System.Drawing.Point(5, 8);
            this.cb_titulos_bus.Name = "cb_titulos_bus";
            this.cb_titulos_bus.Size = new System.Drawing.Size(83, 25);
            this.cb_titulos_bus.TabIndex = 17;
            this.cb_titulos_bus.Text = "Titulos";
            // 
            // cb_problema
            // 
            this.cb_problema.BackColor = System.Drawing.Color.Gold;
            this.cb_problema.DropDownWidth = 500;
            this.cb_problema.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_problema.ForeColor = System.Drawing.Color.Navy;
            this.cb_problema.FormattingEnabled = true;
            this.cb_problema.Location = new System.Drawing.Point(11, 37);
            this.cb_problema.Name = "cb_problema";
            this.cb_problema.Size = new System.Drawing.Size(472, 33);
            this.cb_problema.TabIndex = 16;
            this.cb_problema.SelectionChangeCommitted += new System.EventHandler(this.cb_problema_SelectionChangeCommitted);
            // 
            // gb_buscador_sitios
            // 
            this.gb_buscador_sitios.Controls.Add(this.label14);
            this.gb_buscador_sitios.Controls.Add(this.cb_sitios);
            this.gb_buscador_sitios.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gb_buscador_sitios.Location = new System.Drawing.Point(5, 250);
            this.gb_buscador_sitios.Name = "gb_buscador_sitios";
            this.gb_buscador_sitios.Size = new System.Drawing.Size(492, 80);
            this.gb_buscador_sitios.TabIndex = 44;
            this.gb_buscador_sitios.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Navy;
            this.label14.Location = new System.Drawing.Point(6, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 25);
            this.label14.TabIndex = 17;
            this.label14.Text = "Sitios";
            // 
            // cb_sitios
            // 
            this.cb_sitios.BackColor = System.Drawing.Color.Gold;
            this.cb_sitios.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_sitios.ForeColor = System.Drawing.Color.Navy;
            this.cb_sitios.FormattingEnabled = true;
            this.cb_sitios.Location = new System.Drawing.Point(40, 36);
            this.cb_sitios.Name = "cb_sitios";
            this.cb_sitios.Size = new System.Drawing.Size(416, 33);
            this.cb_sitios.TabIndex = 16;
            this.cb_sitios.SelectionChangeCommitted += new System.EventHandler(this.cb_sitios_SelectionChangeCommitted);
            // 
            // gb_buscador_paginas
            // 
            this.gb_buscador_paginas.Controls.Add(this.label1);
            this.gb_buscador_paginas.Controls.Add(this.cb_paginas);
            this.gb_buscador_paginas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gb_buscador_paginas.Location = new System.Drawing.Point(4, 168);
            this.gb_buscador_paginas.Name = "gb_buscador_paginas";
            this.gb_buscador_paginas.Size = new System.Drawing.Size(493, 80);
            this.gb_buscador_paginas.TabIndex = 44;
            this.gb_buscador_paginas.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Paginas";
            // 
            // cb_paginas
            // 
            this.cb_paginas.BackColor = System.Drawing.Color.Gold;
            this.cb_paginas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_paginas.ForeColor = System.Drawing.Color.Navy;
            this.cb_paginas.FormattingEnabled = true;
            this.cb_paginas.Location = new System.Drawing.Point(41, 35);
            this.cb_paginas.Name = "cb_paginas";
            this.cb_paginas.Size = new System.Drawing.Size(416, 33);
            this.cb_paginas.TabIndex = 16;
            this.cb_paginas.SelectionChangeCommitted += new System.EventHandler(this.cb_paginas_SelectionChangeCommitted);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lb_sin);
            this.panel1.Controls.Add(this.gb_buscador_paginas);
            this.panel1.Controls.Add(this.gb_buscador_user);
            this.panel1.Controls.Add(this.gb_buscador_sitios);
            this.panel1.Controls.Add(this.gb_buscador_titulos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 340);
            this.panel1.TabIndex = 46;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::HMDA.Properties.Resources.close__2_;
            this.pictureBox1.Location = new System.Drawing.Point(465, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lb_sin
            // 
            this.lb_sin.AutoSize = true;
            this.lb_sin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sin.ForeColor = System.Drawing.Color.Navy;
            this.lb_sin.Location = new System.Drawing.Point(144, 7);
            this.lb_sin.Name = "lb_sin";
            this.lb_sin.Size = new System.Drawing.Size(193, 25);
            this.lb_sin.TabIndex = 34;
            this.lb_sin.Text = "SIN RESULTADO";
            // 
            // resBus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 340);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "resBus";
            this.Text = "resBus";
            this.Load += new System.EventHandler(this.resBus_Load);
            this.gb_buscador_user.ResumeLayout(false);
            this.gb_buscador_user.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_user)).EndInit();
            this.gb_buscador_titulos.ResumeLayout(false);
            this.gb_buscador_titulos.PerformLayout();
            this.gb_buscador_sitios.ResumeLayout(false);
            this.gb_buscador_sitios.PerformLayout();
            this.gb_buscador_paginas.ResumeLayout(false);
            this.gb_buscador_paginas.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolt_user;
        private System.Windows.Forms.GroupBox gb_buscador_user;
        private System.Windows.Forms.Label lb_user;
        private System.Windows.Forms.PictureBox pb_user;
        private System.Windows.Forms.GroupBox gb_buscador_titulos;
        private System.Windows.Forms.Label cb_titulos_bus;
        private System.Windows.Forms.ComboBox cb_problema;
        private System.Windows.Forms.GroupBox gb_buscador_sitios;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cb_sitios;
        private System.Windows.Forms.GroupBox gb_buscador_paginas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_paginas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lb_paracopiar;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_sin;
    }
}