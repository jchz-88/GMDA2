
namespace HMDA
{
    partial class conex
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
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(conex));
            this.label3 = new System.Windows.Forms.Label();
            this.lb_ip = new System.Windows.Forms.Label();
            this.lb_mss = new System.Windows.Forms.Label();
            this.lb_pf = new System.Windows.Forms.Label();
            this.lb_pok = new System.Windows.Forms.Label();
            this.lb_pe = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gf_ping = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.habilitarBotonKaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tm_ping = new System.Windows.Forms.Timer(this.components);
            this.tt_time = new System.Windows.Forms.ToolTip(this.components);
            this.tb_principal_red = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_uptime = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pb_scan = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gf_ping)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_scan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 57;
            this.label3.Text = "Perdidos";
            // 
            // lb_ip
            // 
            this.lb_ip.AutoSize = true;
            this.lb_ip.BackColor = System.Drawing.Color.Transparent;
            this.lb_ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ip.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lb_ip.Location = new System.Drawing.Point(2, -1);
            this.lb_ip.Name = "lb_ip";
            this.lb_ip.Size = new System.Drawing.Size(26, 20);
            this.lb_ip.TabIndex = 67;
            this.lb_ip.Text = "IP";
            this.lb_ip.Click += new System.EventHandler(this.lb_nombre_Click);
            // 
            // lb_mss
            // 
            this.lb_mss.AutoSize = true;
            this.lb_mss.BackColor = System.Drawing.Color.Transparent;
            this.lb_mss.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_mss.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lb_mss.Location = new System.Drawing.Point(32, 40);
            this.lb_mss.Name = "lb_mss";
            this.lb_mss.Size = new System.Drawing.Size(53, 20);
            this.lb_mss.TabIndex = 66;
            this.lb_mss.Text = "(mss)";
            // 
            // lb_pf
            // 
            this.lb_pf.AutoSize = true;
            this.lb_pf.BackColor = System.Drawing.Color.Transparent;
            this.lb_pf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pf.ForeColor = System.Drawing.Color.Red;
            this.lb_pf.Location = new System.Drawing.Point(90, 39);
            this.lb_pf.Name = "lb_pf";
            this.lb_pf.Size = new System.Drawing.Size(46, 20);
            this.lb_pf.TabIndex = 65;
            this.lb_pf.Text = "ENV";
            // 
            // lb_pok
            // 
            this.lb_pok.AutoSize = true;
            this.lb_pok.BackColor = System.Drawing.Color.Transparent;
            this.lb_pok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pok.ForeColor = System.Drawing.Color.Green;
            this.lb_pok.Location = new System.Drawing.Point(89, 20);
            this.lb_pok.Name = "lb_pok";
            this.lb_pok.Size = new System.Drawing.Size(46, 20);
            this.lb_pok.TabIndex = 64;
            this.lb_pok.Text = "ENV";
            // 
            // lb_pe
            // 
            this.lb_pe.AutoSize = true;
            this.lb_pe.BackColor = System.Drawing.Color.Transparent;
            this.lb_pe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pe.ForeColor = System.Drawing.Color.Cyan;
            this.lb_pe.Location = new System.Drawing.Point(89, -1);
            this.lb_pe.Name = "lb_pe";
            this.lb_pe.Size = new System.Drawing.Size(46, 20);
            this.lb_pe.TabIndex = 63;
            this.lb_pe.Text = "ENV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 56;
            this.label2.Text = "Recibidos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 55;
            this.label1.Text = "Enviados";
            // 
            // gf_ping
            // 
            lineAnnotation1.LineColor = System.Drawing.Color.Transparent;
            lineAnnotation1.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            lineAnnotation1.Name = "LineAnnotation1";
            this.gf_ping.Annotations.Add(lineAnnotation1);
            this.gf_ping.BackColor = System.Drawing.Color.Transparent;
            this.gf_ping.BackImageTransparentColor = System.Drawing.Color.Transparent;
            this.gf_ping.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.gf_ping.BorderSkin.BackColor = System.Drawing.Color.Black;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.Inclination = 5;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea1.Area3DStyle.PointDepth = 60;
            chartArea1.Area3DStyle.Rotation = 10;
            chartArea1.AxisX.InterlacedColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.IsInterlaced = true;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 11;
            chartArea1.AxisX.LabelAutoFitMinFontSize = 7;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.LineColor = System.Drawing.Color.Crimson;
            chartArea1.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisX.LineWidth = 2;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.MaximumAutoSize = 100F;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.ScaleBreakStyle.CollapsibleSpaceThreshold = 10;
            chartArea1.AxisX.ScaleBreakStyle.Enabled = true;
            chartArea1.AxisX.ScaleView.Zoomable = false;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.IsMarginVisible = false;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.LabelAutoFitMaxFontSize = 11;
            chartArea1.AxisY.LabelAutoFitMinFontSize = 7;
            chartArea1.AxisY.LabelStyle.Enabled = false;
            chartArea1.AxisY.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY.MaximumAutoSize = 100F;
            chartArea1.AxisY.ScaleBreakStyle.Enabled = true;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.BorderWidth = 0;
            chartArea1.CursorX.IntervalOffset = 10D;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.SelectionColor = System.Drawing.Color.Gray;
            chartArea1.CursorY.IntervalOffset = 10D;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 76.875F;
            chartArea1.InnerPlotPosition.Width = 85.78868F;
            chartArea1.InnerPlotPosition.X = 12.10771F;
            chartArea1.InnerPlotPosition.Y = 5.58511F;
            chartArea1.Name = "ChartArea1";
            this.gf_ping.ChartAreas.Add(chartArea1);
            this.gf_ping.ContextMenuStrip = this.contextMenuStrip1;
            this.gf_ping.Location = new System.Drawing.Point(-45, -26);
            this.gf_ping.Name = "gf_ping";
            this.gf_ping.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BackImageTransparentColor = System.Drawing.Color.White;
            series1.BackSecondaryColor = System.Drawing.Color.Transparent;
            series1.BorderColor = System.Drawing.Color.ForestGreen;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeBar;
            series1.Color = System.Drawing.Color.LawnGreen;
            series1.EmptyPointStyle.Color = System.Drawing.Color.Red;
            series1.EmptyPointStyle.CustomProperties = "LabelStyle=Center";
            series1.EmptyPointStyle.Label = "#Error";
            series1.EmptyPointStyle.LabelForeColor = System.Drawing.Color.Red;
            series1.EmptyPointStyle.LegendText = "#Error";
            series1.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.IsVisibleInLegend = false;
            series1.Label = "#VAL";
            series1.LabelAngle = 1;
            series1.LabelBackColor = System.Drawing.Color.Transparent;
            series1.LabelBorderColor = System.Drawing.Color.Transparent;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "Series";
            series1.ShadowColor = System.Drawing.Color.ForestGreen;
            series1.ShadowOffset = 2;
            series1.YValuesPerPoint = 6;
            this.gf_ping.Series.Add(series1);
            this.gf_ping.Size = new System.Drawing.Size(324, 260);
            this.gf_ping.TabIndex = 30;
            this.gf_ping.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gf_ping_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.habilitarBotonKaceToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 26);
            // 
            // habilitarBotonKaceToolStripMenuItem
            // 
            this.habilitarBotonKaceToolStripMenuItem.Name = "habilitarBotonKaceToolStripMenuItem";
            this.habilitarBotonKaceToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.habilitarBotonKaceToolStripMenuItem.Text = "Boton Kace";
            this.habilitarBotonKaceToolStripMenuItem.Click += new System.EventHandler(this.habilitarBotonKaceToolStripMenuItem_Click);
            // 
            // tm_ping
            // 
            this.tm_ping.Interval = 1250;
            this.tm_ping.Tick += new System.EventHandler(this.tm_ping_Tick_1);
            // 
            // tt_time
            // 
            this.tt_time.AutoPopDelay = 6000;
            this.tt_time.BackColor = System.Drawing.SystemColors.ControlText;
            this.tt_time.ForeColor = System.Drawing.Color.Lime;
            this.tt_time.InitialDelay = 500;
            this.tt_time.IsBalloon = true;
            this.tt_time.OwnerDraw = true;
            this.tt_time.ReshowDelay = 100;
            this.tt_time.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // tb_principal_red
            // 
            this.tb_principal_red.AutoSize = true;
            this.tb_principal_red.BackColor = System.Drawing.Color.Red;
            this.tb_principal_red.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.tb_principal_red.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tb_principal_red.Location = new System.Drawing.Point(-3, 20);
            this.tb_principal_red.Name = "tb_principal_red";
            this.tb_principal_red.Size = new System.Drawing.Size(41, 18);
            this.tb_principal_red.TabIndex = 68;
            this.tb_principal_red.Text = "nom";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lb_pe);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lb_pok);
            this.panel1.Controls.Add(this.lb_pf);
            this.panel1.Location = new System.Drawing.Point(296, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 65);
            this.panel1.TabIndex = 69;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.tb_principal_red);
            this.panel2.Controls.Add(this.lb_ip);
            this.panel2.Controls.Add(this.lb_mss);
            this.panel2.Location = new System.Drawing.Point(296, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(140, 65);
            this.panel2.TabIndex = 70;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.pictureBox14);
            this.panel3.Controls.Add(this.pictureBox4);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(296, 136);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(140, 39);
            this.panel3.TabIndex = 71;
            // 
            // pictureBox14
            // 
            this.pictureBox14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox14.Image = global::HMDA.Properties.Resources.windows_8__1_;
            this.pictureBox14.Location = new System.Drawing.Point(2, 0);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(33, 33);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox14.TabIndex = 58;
            this.pictureBox14.TabStop = false;
            this.pictureBox14.Click += new System.EventHandler(this.pictureBox14_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = global::HMDA.Properties.Resources.ubuntu__1_;
            this.pictureBox4.Location = new System.Drawing.Point(36, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(33, 33);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 62;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::HMDA.Properties.Resources.ssh__1_;
            this.pictureBox2.Location = new System.Drawing.Point(102, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 60;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::HMDA.Properties.Resources.impresora;
            this.pictureBox1.Location = new System.Drawing.Point(69, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 59;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lb_uptime
            // 
            this.lb_uptime.AutoSize = true;
            this.lb_uptime.BackColor = System.Drawing.Color.Transparent;
            this.lb_uptime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_uptime.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lb_uptime.Location = new System.Drawing.Point(9, 184);
            this.lb_uptime.Name = "lb_uptime";
            this.lb_uptime.Size = new System.Drawing.Size(63, 20);
            this.lb_uptime.TabIndex = 69;
            this.lb_uptime.Text = "uptime";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.pictureBox8);
            this.panel4.Controls.Add(this.pictureBox7);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(0, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(436, 52);
            this.panel4.TabIndex = 72;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox8.Image = global::HMDA.Properties.Resources.no_laptop;
            this.pictureBox8.Location = new System.Drawing.Point(309, 1);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(50, 50);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 63;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox7.Image = global::HMDA.Properties.Resources.close__2_;
            this.pictureBox7.Location = new System.Drawing.Point(409, 3);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(22, 22);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox7.TabIndex = 73;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(22, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 24);
            this.label4.TabIndex = 74;
            this.label4.Text = "label4";
            // 
            // pb_scan
            // 
            this.pb_scan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_scan.Image = global::HMDA.Properties.Resources.computer_networking;
            this.pb_scan.Location = new System.Drawing.Point(269, 96);
            this.pb_scan.Name = "pb_scan";
            this.pb_scan.Size = new System.Drawing.Size(25, 25);
            this.pb_scan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_scan.TabIndex = 74;
            this.pb_scan.TabStop = false;
            this.pb_scan.Click += new System.EventHandler(this.pb_scan_Click);
            // 
            // pictureBox9
            // 
            this.pictureBox9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox9.Image = global::HMDA.Properties.Resources.unnamed_removebg_preview__1_;
            this.pictureBox9.Location = new System.Drawing.Point(269, 68);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(25, 25);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 73;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Click += new System.EventHandler(this.pictureBox9_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Image = global::HMDA.Properties.Resources.tasks;
            this.pictureBox5.Location = new System.Drawing.Point(269, 149);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(25, 25);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 70;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click_1);
            this.pictureBox5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox5_MouseDown);
            this.pictureBox5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox5_MouseUp);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::HMDA.Properties.Resources.close__2_;
            this.pictureBox3.Location = new System.Drawing.Point(274, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(22, 22);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 69;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Image = global::HMDA.Properties.Resources.copy1;
            this.pictureBox6.Location = new System.Drawing.Point(269, 122);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(25, 25);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 51;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            this.pictureBox6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox6_MouseDown);
            this.pictureBox6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox6_MouseUp);
            // 
            // conex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 180);
            this.Controls.Add(this.pb_scan);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lb_uptime);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gf_ping);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "conex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "conex";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.conex_FormClosed);
            this.Load += new System.EventHandler(this.conex_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.conex_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.gf_ping)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_scan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart gf_ping;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.Timer tm_ping;
        private System.Windows.Forms.Label lb_pf;
        private System.Windows.Forms.Label lb_pok;
        private System.Windows.Forms.Label lb_pe;
        private System.Windows.Forms.Label lb_mss;
        private System.Windows.Forms.Label lb_ip;
        private System.Windows.Forms.ToolTip tt_time;
        private System.Windows.Forms.Label tb_principal_red;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label lb_uptime;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem habilitarBotonKaceToolStripMenuItem;
        private System.Windows.Forms.PictureBox pb_scan;
    }
}