namespace HMDA
{
    partial class scanIP
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(scanIP));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dG_scan = new System.Windows.Forms.DataGridView();
            this.col_IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_HostName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_cantidad = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linuxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.impresoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dG_scan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 33);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(298, 17);
            this.progressBar1.TabIndex = 50;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(11, 3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(16, 15);
            this.lblStatus.TabIndex = 52;
            this.lblStatus.Text = "X";
            // 
            // dG_scan
            // 
            this.dG_scan.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dG_scan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dG_scan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dG_scan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dG_scan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dG_scan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_IP,
            this.col_HostName,
            this.col_Estado,
            this.col_sort});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dG_scan.DefaultCellStyle = dataGridViewCellStyle2;
            this.dG_scan.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dG_scan.Location = new System.Drawing.Point(11, 55);
            this.dG_scan.MultiSelect = false;
            this.dG_scan.Name = "dG_scan";
            this.dG_scan.ReadOnly = true;
            this.dG_scan.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dG_scan.RowHeadersVisible = false;
            this.dG_scan.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dG_scan.Size = new System.Drawing.Size(340, 23);
            this.dG_scan.TabIndex = 53;
            // 
            // col_IP
            // 
            this.col_IP.HeaderText = "IP";
            this.col_IP.Name = "col_IP";
            this.col_IP.ReadOnly = true;
            this.col_IP.Width = 135;
            // 
            // col_HostName
            // 
            this.col_HostName.HeaderText = "HostName";
            this.col_HostName.Name = "col_HostName";
            this.col_HostName.ReadOnly = true;
            this.col_HostName.Width = 139;
            // 
            // col_Estado
            // 
            this.col_Estado.HeaderText = "Estado";
            this.col_Estado.Name = "col_Estado";
            this.col_Estado.ReadOnly = true;
            this.col_Estado.Width = 56;
            // 
            // col_sort
            // 
            this.col_sort.HeaderText = "sort";
            this.col_sort.Name = "col_sort";
            this.col_sort.ReadOnly = true;
            this.col_sort.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::HMDA.Properties.Resources.close__2_;
            this.pictureBox1.Location = new System.Drawing.Point(317, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lb_cantidad
            // 
            this.lb_cantidad.AutoSize = true;
            this.lb_cantidad.BackColor = System.Drawing.Color.Transparent;
            this.lb_cantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_cantidad.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lb_cantidad.Location = new System.Drawing.Point(10, 17);
            this.lb_cantidad.Name = "lb_cantidad";
            this.lb_cantidad.Size = new System.Drawing.Size(16, 15);
            this.lb_cantidad.TabIndex = 54;
            this.lb_cantidad.Text = "X";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowsToolStripMenuItem,
            this.linuxToolStripMenuItem,
            this.impresoraToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(128, 70);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.Image = global::HMDA.Properties.Resources.windows_8__1_;
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.windowsToolStripMenuItem.Text = "Windows";
            // 
            // linuxToolStripMenuItem
            // 
            this.linuxToolStripMenuItem.Image = global::HMDA.Properties.Resources.ubuntu__1_;
            this.linuxToolStripMenuItem.Name = "linuxToolStripMenuItem";
            this.linuxToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.linuxToolStripMenuItem.Text = "Linux";
            // 
            // impresoraToolStripMenuItem
            // 
            this.impresoraToolStripMenuItem.Image = global::HMDA.Properties.Resources.impresora;
            this.impresoraToolStripMenuItem.Name = "impresoraToolStripMenuItem";
            this.impresoraToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.impresoraToolStripMenuItem.Text = "Impresora";
            // 
            // scanIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 87);
            this.Controls.Add(this.lb_cantidad);
            this.Controls.Add(this.dG_scan);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "scanIP";
            this.Text = "scanIP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.scanIP_FormClosing);
            this.Load += new System.EventHandler(this.scanIP_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scanIP_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dG_scan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView dG_scan;
        private System.Windows.Forms.Label lb_cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_HostName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sort;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linuxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem impresoraToolStripMenuItem;
    }
}