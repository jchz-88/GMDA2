
namespace HMDA.pMenu.bus
{
    partial class plantillas
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
            this.tb1_plantilla = new System.Windows.Forms.TextBox();
            this.tb2_plantilla = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pb_elimiar = new System.Windows.Forms.PictureBox();
            this.pb_close = new System.Windows.Forms.PictureBox();
            this.pb_copiar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_elimiar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_copiar)).BeginInit();
            this.SuspendLayout();
            // 
            // tb1_plantilla
            // 
            this.tb1_plantilla.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tb1_plantilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb1_plantilla.ForeColor = System.Drawing.SystemColors.Window;
            this.tb1_plantilla.Location = new System.Drawing.Point(197, 25);
            this.tb1_plantilla.Name = "tb1_plantilla";
            this.tb1_plantilla.Size = new System.Drawing.Size(234, 21);
            this.tb1_plantilla.TabIndex = 0;
            this.tb1_plantilla.Text = "Ingresar Asunto.. / Titulo..";
            this.tb1_plantilla.Click += new System.EventHandler(this.tb1_plantilla_Click);
            // 
            // tb2_plantilla
            // 
            this.tb2_plantilla.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tb2_plantilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb2_plantilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.tb2_plantilla.ForeColor = System.Drawing.SystemColors.Window;
            this.tb2_plantilla.Location = new System.Drawing.Point(197, 52);
            this.tb2_plantilla.Multiline = true;
            this.tb2_plantilla.Name = "tb2_plantilla";
            this.tb2_plantilla.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb2_plantilla.Size = new System.Drawing.Size(290, 111);
            this.tb2_plantilla.TabIndex = 2;
            this.tb2_plantilla.Text = "Ingrese el Contenido que desa guardar como Plantilla...";
            this.tb2_plantilla.Click += new System.EventHandler(this.tb2_plantilla_Click);
            this.tb2_plantilla.TextChanged += new System.EventHandler(this.tb2_plantilla_TextChanged);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.listBox1.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "Plantillas CORREOS",
            "Plantillas TICKETS",
            "NUEVA Plantilla",
            "Eliminadas"});
            this.listBox1.Location = new System.Drawing.Point(6, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(165, 68);
            this.listBox1.TabIndex = 42;
            this.listBox1.MouseCaptureChanged += new System.EventHandler(this.listBox1_MouseCaptureChanged);
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.listBox2.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.ForeColor = System.Drawing.SystemColors.Window;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(6, 101);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(165, 84);
            this.listBox2.TabIndex = 43;
            this.listBox2.MouseCaptureChanged += new System.EventHandler(this.listBox2_MouseCaptureChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(241, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 25);
            this.button1.TabIndex = 44;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(5, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 49;
            this.label1.Text = "Plantillas";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(353, 163);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 26);
            this.button2.TabIndex = 50;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pb_elimiar
            // 
            this.pb_elimiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_elimiar.Image = global::HMDA.Properties.Resources.basura;
            this.pb_elimiar.Location = new System.Drawing.Point(464, 22);
            this.pb_elimiar.Name = "pb_elimiar";
            this.pb_elimiar.Size = new System.Drawing.Size(25, 25);
            this.pb_elimiar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_elimiar.TabIndex = 51;
            this.pb_elimiar.TabStop = false;
            this.pb_elimiar.Click += new System.EventHandler(this.pb_elimiar_Click);
            // 
            // pb_close
            // 
            this.pb_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_close.Image = global::HMDA.Properties.Resources.close__2_;
            this.pb_close.Location = new System.Drawing.Point(463, -2);
            this.pb_close.Name = "pb_close";
            this.pb_close.Size = new System.Drawing.Size(25, 25);
            this.pb_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_close.TabIndex = 48;
            this.pb_close.TabStop = false;
            this.pb_close.Click += new System.EventHandler(this.pb_close_Click);
            // 
            // pb_copiar
            // 
            this.pb_copiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_copiar.Image = global::HMDA.Properties.Resources.copy;
            this.pb_copiar.Location = new System.Drawing.Point(436, 23);
            this.pb_copiar.Name = "pb_copiar";
            this.pb_copiar.Size = new System.Drawing.Size(25, 25);
            this.pb_copiar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_copiar.TabIndex = 45;
            this.pb_copiar.TabStop = false;
            this.pb_copiar.Click += new System.EventHandler(this.pb_copiar_Click);
            // 
            // plantillas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 194);
            this.Controls.Add(this.pb_elimiar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb_close);
            this.Controls.Add(this.pb_copiar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb2_plantilla);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.tb1_plantilla);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "plantillas";
            this.Text = "plantillas";
            this.Load += new System.EventHandler(this.plantillas_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.plantillas_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pb_elimiar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_copiar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tb1_plantilla;
        private System.Windows.Forms.TextBox tb2_plantilla;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pb_copiar;
        private System.Windows.Forms.PictureBox pb_close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pb_elimiar;
    }
}