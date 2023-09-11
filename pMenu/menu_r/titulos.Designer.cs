
namespace HMDA.pMenu.menu_r
{
    partial class titulos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(titulos));
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cb_ci = new System.Windows.Forms.ComboBox();
            this.cb_problema = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox21 = new System.Windows.Forms.PictureBox();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.pictureBox22 = new System.Windows.Forms.PictureBox();
            this.pb_close = new System.Windows.Forms.PictureBox();
            this.pictureBox42 = new System.Windows.Forms.PictureBox();
            this.pb_option = new System.Windows.Forms.PictureBox();
            this.pictureBox19 = new System.Windows.Forms.PictureBox();
            this.pb_plus = new System.Windows.Forms.PictureBox();
            this.pictureBox23 = new System.Windows.Forms.PictureBox();
            this.pb_fijar = new System.Windows.Forms.PictureBox();
            this.pb_fijado = new System.Windows.Forms.PictureBox();
            this.contex_titus = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fijarIconosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_option)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_plus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_fijar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_fijado)).BeginInit();
            this.contex_titus.SuspendLayout();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label11.Location = new System.Drawing.Point(5, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 20);
            this.label11.TabIndex = 17;
            this.label11.Text = "Titulos";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Location = new System.Drawing.Point(5, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 20);
            this.label12.TabIndex = 16;
            this.label12.Text = "Servicios";
            // 
            // cb_ci
            // 
            this.cb_ci.BackColor = System.Drawing.SystemColors.ControlText;
            this.cb_ci.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_ci.ForeColor = System.Drawing.SystemColors.Window;
            this.cb_ci.FormattingEnabled = true;
            this.cb_ci.Location = new System.Drawing.Point(0, 71);
            this.cb_ci.Name = "cb_ci";
            this.cb_ci.Size = new System.Drawing.Size(271, 32);
            this.cb_ci.TabIndex = 14;
            this.cb_ci.DropDown += new System.EventHandler(this.cb_ci_DropDown);
            this.cb_ci.SelectedIndexChanged += new System.EventHandler(this.cb_ci_SelectedIndexChanged);
            this.cb_ci.SelectionChangeCommitted += new System.EventHandler(this.cb_ci_SelectionChangeCommitted);
            this.cb_ci.TextUpdate += new System.EventHandler(this.cb_ci_TextUpdate);
            this.cb_ci.Enter += new System.EventHandler(this.cb_ci_Enter);
            this.cb_ci.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_ci_KeyPress);
            // 
            // cb_problema
            // 
            this.cb_problema.BackColor = System.Drawing.SystemColors.InfoText;
            this.cb_problema.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_problema.ForeColor = System.Drawing.SystemColors.Window;
            this.cb_problema.FormattingEnabled = true;
            this.cb_problema.Location = new System.Drawing.Point(0, 103);
            this.cb_problema.Name = "cb_problema";
            this.cb_problema.Size = new System.Drawing.Size(271, 32);
            this.cb_problema.TabIndex = 15;
            this.cb_problema.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cb_problema_DrawItem);
            this.cb_problema.DropDown += new System.EventHandler(this.cb_problema_DropDown);
            this.cb_problema.SelectedIndexChanged += new System.EventHandler(this.cb_problema_SelectedIndexChanged);
            this.cb_problema.SelectionChangeCommitted += new System.EventHandler(this.cb_problema_SelectionChangeCommitted);
            this.cb_problema.DropDownClosed += new System.EventHandler(this.cb_problema_DropDownClosed);
            this.cb_problema.Enter += new System.EventHandler(this.cb_problema_Enter);
            this.cb_problema.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_problema_KeyPress);
            // 
            // pictureBox21
            // 
            this.pictureBox21.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox21.Image = global::HMDA.Properties.Resources.microchip;
            this.pictureBox21.Location = new System.Drawing.Point(138, 1);
            this.pictureBox21.Name = "pictureBox21";
            this.pictureBox21.Size = new System.Drawing.Size(40, 40);
            this.pictureBox21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox21.TabIndex = 10;
            this.pictureBox21.TabStop = false;
            this.pictureBox21.Click += new System.EventHandler(this.pictureBox21_Click);
            // 
            // pictureBox20
            // 
            this.pictureBox20.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox20.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox20.Image = global::HMDA.Properties.Resources.blogger;
            this.pictureBox20.Location = new System.Drawing.Point(92, 1);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new System.Drawing.Size(40, 40);
            this.pictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox20.TabIndex = 11;
            this.pictureBox20.TabStop = false;
            this.pictureBox20.Click += new System.EventHandler(this.pictureBox20_Click);
            // 
            // pictureBox22
            // 
            this.pictureBox22.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox22.Image = global::HMDA.Properties.Resources.web;
            this.pictureBox22.Location = new System.Drawing.Point(184, 1);
            this.pictureBox22.Name = "pictureBox22";
            this.pictureBox22.Size = new System.Drawing.Size(40, 40);
            this.pictureBox22.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox22.TabIndex = 9;
            this.pictureBox22.TabStop = false;
            this.pictureBox22.Click += new System.EventHandler(this.pictureBox22_Click);
            // 
            // pb_close
            // 
            this.pb_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_close.Image = global::HMDA.Properties.Resources.close__3_;
            this.pb_close.Location = new System.Drawing.Point(156, 42);
            this.pb_close.Name = "pb_close";
            this.pb_close.Size = new System.Drawing.Size(28, 28);
            this.pb_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_close.TabIndex = 44;
            this.pb_close.TabStop = false;
            this.pb_close.Click += new System.EventHandler(this.pb_close_Click_1);
            // 
            // pictureBox42
            // 
            this.pictureBox42.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox42.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox42.Image = global::HMDA.Properties.Resources.network_switch;
            this.pictureBox42.Location = new System.Drawing.Point(230, 1);
            this.pictureBox42.Name = "pictureBox42";
            this.pictureBox42.Size = new System.Drawing.Size(40, 40);
            this.pictureBox42.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox42.TabIndex = 35;
            this.pictureBox42.TabStop = false;
            this.pictureBox42.Click += new System.EventHandler(this.pictureBox42_Click);
            // 
            // pb_option
            // 
            this.pb_option.ContextMenuStrip = this.contex_titus;
            this.pb_option.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_option.Image = global::HMDA.Properties.Resources.plus__1_;
            this.pb_option.Location = new System.Drawing.Point(243, 42);
            this.pb_option.Name = "pb_option";
            this.pb_option.Size = new System.Drawing.Size(28, 28);
            this.pb_option.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_option.TabIndex = 46;
            this.pb_option.TabStop = false;
            this.pb_option.MouseEnter += new System.EventHandler(this.pb_option_MouseEnter_1);
            this.pb_option.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_option_MouseMove_1);
            // 
            // pictureBox19
            // 
            this.pictureBox19.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox19.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox19.Image = global::HMDA.Properties.Resources.logistics;
            this.pictureBox19.Location = new System.Drawing.Point(46, 1);
            this.pictureBox19.Name = "pictureBox19";
            this.pictureBox19.Size = new System.Drawing.Size(40, 40);
            this.pictureBox19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox19.TabIndex = 12;
            this.pictureBox19.TabStop = false;
            this.pictureBox19.Click += new System.EventHandler(this.pictureBox19_Click);
            // 
            // pb_plus
            // 
            this.pb_plus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_plus.Image = global::HMDA.Properties.Resources.plus;
            this.pb_plus.Location = new System.Drawing.Point(185, 42);
            this.pb_plus.Name = "pb_plus";
            this.pb_plus.Size = new System.Drawing.Size(28, 28);
            this.pb_plus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_plus.TabIndex = 42;
            this.pb_plus.TabStop = false;
            this.pb_plus.Click += new System.EventHandler(this.pb_plus_Click_1);
            // 
            // pictureBox23
            // 
            this.pictureBox23.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox23.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox23.Image = global::HMDA.Properties.Resources.counter;
            this.pictureBox23.Location = new System.Drawing.Point(1, 1);
            this.pictureBox23.Name = "pictureBox23";
            this.pictureBox23.Size = new System.Drawing.Size(40, 40);
            this.pictureBox23.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox23.TabIndex = 8;
            this.pictureBox23.TabStop = false;
            this.pictureBox23.Click += new System.EventHandler(this.pictureBox23_Click);
            // 
            // pb_fijar
            // 
            this.pb_fijar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_fijar.Image = global::HMDA.Properties.Resources.alfiler__2_;
            this.pb_fijar.Location = new System.Drawing.Point(214, 42);
            this.pb_fijar.Name = "pb_fijar";
            this.pb_fijar.Size = new System.Drawing.Size(28, 28);
            this.pb_fijar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_fijar.TabIndex = 43;
            this.pb_fijar.TabStop = false;
            this.pb_fijar.Click += new System.EventHandler(this.pb_fijar_Click_1);
            // 
            // pb_fijado
            // 
            this.pb_fijado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_fijado.Image = global::HMDA.Properties.Resources.alfiler__1_;
            this.pb_fijado.Location = new System.Drawing.Point(214, 42);
            this.pb_fijado.Name = "pb_fijado";
            this.pb_fijado.Size = new System.Drawing.Size(28, 28);
            this.pb_fijado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_fijado.TabIndex = 45;
            this.pb_fijado.TabStop = false;
            this.pb_fijado.Click += new System.EventHandler(this.pb_fijado_Click_1);
            // 
            // contex_titus
            // 
            this.contex_titus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fijarIconosToolStripMenuItem});
            this.contex_titus.Name = "contex_titus";
            this.contex_titus.Size = new System.Drawing.Size(181, 48);
            // 
            // fijarIconosToolStripMenuItem
            // 
            this.fijarIconosToolStripMenuItem.Image = global::HMDA.Properties.Resources.alfiler__1_;
            this.fijarIconosToolStripMenuItem.Name = "fijarIconosToolStripMenuItem";
            this.fijarIconosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fijarIconosToolStripMenuItem.Text = "Fijar Iconos";
            this.fijarIconosToolStripMenuItem.Click += new System.EventHandler(this.fijarIconosToolStripMenuItem_Click);
            // 
            // titulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 136);
            this.Controls.Add(this.pictureBox21);
            this.Controls.Add(this.pictureBox20);
            this.Controls.Add(this.pictureBox22);
            this.Controls.Add(this.pb_close);
            this.Controls.Add(this.pictureBox42);
            this.Controls.Add(this.pb_option);
            this.Controls.Add(this.pictureBox19);
            this.Controls.Add(this.pb_plus);
            this.Controls.Add(this.pictureBox23);
            this.Controls.Add(this.pb_fijar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cb_problema);
            this.Controls.Add(this.cb_ci);
            this.Controls.Add(this.pb_fijado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "titulos";
            this.Text = "Titulos_MDA";
            this.Load += new System.EventHandler(this.titulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_option)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_plus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_fijar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_fijado)).EndInit();
            this.contex_titus.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cb_ci;
        private System.Windows.Forms.ComboBox cb_problema;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pb_close;
        private System.Windows.Forms.PictureBox pb_option;
        private System.Windows.Forms.PictureBox pb_fijado;
        private System.Windows.Forms.PictureBox pb_plus;
        private System.Windows.Forms.PictureBox pb_fijar;
        private System.Windows.Forms.PictureBox pictureBox42;
        private System.Windows.Forms.PictureBox pictureBox23;
        private System.Windows.Forms.PictureBox pictureBox19;
        private System.Windows.Forms.PictureBox pictureBox22;
        private System.Windows.Forms.PictureBox pictureBox21;
        private System.Windows.Forms.PictureBox pictureBox20;
        private System.Windows.Forms.ContextMenuStrip contex_titus;
        private System.Windows.Forms.ToolStripMenuItem fijarIconosToolStripMenuItem;
    }
}