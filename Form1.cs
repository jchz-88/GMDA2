using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using HMDA.Properties;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace WindowsFormsApp2
{



    public partial class Form1 : Form
    {
        int flag = 1;

        string path_titulos;

        float max_op = 100f;
        float trs;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );


        [DllImport("user32.dll")]
        protected static extern int SetClipboardViewer(int hWndNewViewer);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        protected static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        protected static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        IntPtr nextClipboardViewer;


        public Form1()
        {
            InitializeComponent();
            this.Region = Region.FromHrgn(CreateRoundRectRgn(1, 3, Width, Height, 20, 20));
            //this.logo.Image = Properties.Resources.logo;
            //this.btn_login.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.btn_login.Width, this.btn_login.Height, 10, 10));
            
            //Inicia la Ventana de escucha de Clipboard
            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)this.Handle);
            //Recargar path de Imagen de Forma
            pbFirma.ImageLocation = Settings.Default["firma"].ToString();
        }

        //Conexión a BBDD de Titulos
        static string conexion = "SERVER=10.254.63.48;PORT=3306;DATABASE=titulos;UID=jchz;PASSWORDS=;";
        MySqlConnection cn = new MySqlConnection(conexion);

        //Conexión a BBDD de Tipificaciónes
        static string conexion2 = "SERVER=127.0.0.1;PORT=3306;DATABASE=tipifica;UID=root;PASSWORDS=;";
        MySqlConnection cn2 = new MySqlConnection(conexion2);

        //Conexión a BBDD de Sitios (SAS)
        static string conexion3 = "SERVER=10.254.63.48;PORT=3306;DATABASE=sas;UID=jchz;PASSWORDS=;";
        MySqlConnection cn3 = new MySqlConnection(conexion3);

        //Conexión a BBDD de Usuarios/Sitios - Mails Automaticos
        static string conexion4 = "SERVER=10.254.63.48;PORT=3306;DATABASE=base_correos;UID=root;PASSWORDS=;";
        MySqlConnection cn4 = new MySqlConnection(conexion4);

        //Conexión a BBDD de Usuarios/Sitios - Mails Automaticos
        static string conexion5 = "SERVER=10.254.63.48;PORT=3306;DATABASE=paginas;UID=jchz;PASSWORDS=;";
        MySqlConnection cn5 = new MySqlConnection(conexion5);

        


        private void Form1_Load(object sender, EventArgs e)
        {
           




            this.TopMost = (bool)Settings.Default["Fijar"];
            this.Opacity = (float)Settings.Default["Transparente"];
            this.Font = (Font)Settings.Default["Fuente"];
            this.BackColor = (Color)Settings.Default["Color_B"];
            this.ForeColor = (Color)Settings.Default["Color_F"];


            if ((bool)Settings.Default["Fijar"] == true) { fijar.Text = "ON"; fijar.ForeColor = Color.Lime; }
            else { fijar.Text = "OFF"; fijar.ForeColor = Color.Crimson; }

            opacidad.Value = (int)(((float)Settings.Default["Transparente"]) * 0.99f);


            path_titulos = (string)Settings.Default["Path"];


            gb_config.Hide();
            gb_ping.Hide();
            gb_titulo.Hide();
            gb_user.Hide();
            gb_remote.Hide();
            gp_op1.Hide();
            gb_bdc.Hide();
            gb_tipifica.Hide();
            gb_tipifica2.Hide();
            gb_sitios.Hide();
            gb_clip.Hide();
            gb_email.Hide();
            gb_app.Hide();
            tabControl1.Hide();
            tabControl2.Hide();

            
            dg_lista1.Hide();
            dg_lista2.Hide();
            dg_lista3.Hide();
            textBox1.Hide();
            textBox1.ReadOnly = true;
            //textBox1.BorderStyle = 0;
            //textBox1.BackColor = this.BackColor;
            textBox1.TabStop = false;
            textBox1.Multiline = true;

            textBox3.Hide();
            textBox3.ReadOnly = true;
            //textBox3.BorderStyle = 0;
            //textBox3.BackColor = this.BackColor;
            textBox3.TabStop = false;
            textBox3.Multiline = true;
            this.Size = new Size(346, 54);


            this.AutoSize = true;
        }

        private void mostrar(Control x)
        {
            gp_op1.Hide();
            gb_ping.Hide();
            gb_titulo.Hide();
            gb_remote.Hide();
            gb_user.Hide();
            gb_config.Hide();
            gb_tipifica.Hide();
            gb_tipifica2.Hide();
            gb_bdc.Hide();
            gb_sitios.Hide();
            gb_clip.Hide();
            gb_email.Hide();
            tabControl1.Hide();
            tabControl2.Hide();
            gb_app.Hide();
            x.Show();
            x.Location = new Point(3, 60);
            Form1.ActiveForm.Size = new Size(344, 165);
            pictureBox6.BringToFront();
        }

        private void ocultar(Control x)
        {
            gp_op1.Hide();
            gb_ping.Hide();
            gb_titulo.Hide();
            gb_remote.Hide();
            gb_user.Hide();
            gb_config.Hide();
            gb_tipifica.Hide();
            gb_tipifica2.Hide();
            gb_bdc.Hide();
            gb_sitios.Hide();
            tabControl1.Hide();
            tabControl2.Hide();
            gb_email.Hide();
            timer1.Stop();
            timer2.Stop();
            gb_clip.Hide();
            gb_app.Hide();
            x.Location = new Point(440, 330);
            Form1.ActiveForm.Size = new Size(346, 54);
            pictureBox7.BringToFront();
        }

        public DataTable combo(string x, int y)
        {
            if (y == 1)
            {
                try
                {
                    cn.Open();
                    DataTable dt = new DataTable();
                    string cbox = x;
                    MySqlCommand cmd = new MySqlCommand(cbox, cn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    cn.Close();
                    return dt;
                }
                catch
                {
                    MessageBox.Show("No hay conexión con el servidor que almacena los datos!!", "Error de Conexión", MessageBoxButtons.OK);
                    return null;
                }
                
            }
            else if (y==2)
            {
                try
                {
                    cn2.Open();
                    DataTable dt = new DataTable();
                    string cbox = x;
                    MySqlCommand cmd = new MySqlCommand(cbox, cn2);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    cn2.Close();
                    return dt;
                }
                catch
                {
                    MessageBox.Show("No hay conexión con el servidor que almacena los datos!!", "Error de Conexión", MessageBoxButtons.OK);
                    return null;
                }
            }
            else if (y == 5)
            {
                try
                {
                    cn5.Open();
                    DataTable dt = new DataTable();
                    string cbox = x;
                    MySqlCommand cmd = new MySqlCommand(cbox, cn5);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    cn5.Close();
                   
                    return dt;
                }
                catch
                {
                    MessageBox.Show("No hay conexión con el servidor que almacena los datos!!", "Error de Conexión", MessageBoxButtons.OK);
                    return null;
                }
            }
            else
            {
                try
                {
                    cn3.Open();
                    DataTable dt = new DataTable();
                    string cbox = x;
                    MySqlCommand cmd = new MySqlCommand(cbox, cn3);
                    
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    cn3.Close();
                    return dt;
                    
                }
                catch
                {
                    MessageBox.Show("No hay conexión con el servidor que almacena los datos!!", "Error de Conexión", MessageBoxButtons.OK);
                    return null;
                }
            }


        }


        private void bt_cambiar_Click(object sender, EventArgs e)
        {


            FolderBrowserDialog ruta = new FolderBrowserDialog();

            if (ruta.ShowDialog() == DialogResult.OK)
            {
                path_titulos = Directory.GetFiles(ruta.SelectedPath).ToString();
                Settings.Default["Path"] = path_titulos;
                Settings.Default.Save();

            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            por.Text = opacidad.Value.ToString() + "%";

            trs = opacidad.Value / max_op;

            Settings.Default["Transparente"] = trs;
            Settings.Default.Save();

            Form1.ActiveForm.Opacity = trs;
        }


        private void fijar_Click(object sender, EventArgs e)
        {
            if (fijar.Text == "OFF")
            {
                Form1.ActiveForm.TopMost = true;
                fijar.Text = "ON";
                fijar.ForeColor = Color.Lime;
                Settings.Default["Fijar"] = true;
                Settings.Default.Save();
            }
            else
            {
                Form1.ActiveForm.TopMost = false;
                fijar.Text = "OFF";
                fijar.ForeColor = Color.Crimson;
                Settings.Default["Fijar"] = false;
                Settings.Default.Save();
            }

        }





        private void ping_Click(object sender, EventArgs e)
        {
            if (gp_op1.Visible == false)
            {
                mostrar(gp_op1);
                pictureBox12.BringToFront();
           
                label7.Hide();
                label8.Hide();
            }
            else
            {
                ocultar(gp_op1);
                ocultar(gb_ping);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (gb_remote.Visible == false)
            {
                mostrar(gb_remote);
            }
            else
            {
                ocultar(gb_remote);
            }

            Form1.ActiveForm.AutoSize = true;
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (gb_user.Visible == false)
            {
                mostrar(gb_user);
            }
            else
            {
                ocultar(gb_user);
            }
            Form1.ActiveForm.AutoSize = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            gb_config.Hide();
            gb_ping.Hide();
            gb_titulo.Hide();
            gb_user.Hide();
            gb_remote.Hide();
            timer1.Stop();
            gp_op1.Hide();
            gb_tipifica.Hide();
            gb_tipifica2.Hide();
            gb_sitios.Hide();
            tabControl1.Hide();
            Form1.ActiveForm.Size = new Size(346, 54);


            /*
            Process snippingToolProcess = new Process();
            snippingToolProcess.EnableRaisingEvents = true;
        
            snippingToolProcess.StartInfo.FileName = "C:\\Windows\\sysnative\\SnippingTool.exe";
            snippingToolProcess.Start();
            */

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            cmd.StandardInput.WriteLine(@"C:\Temp\HMDA\CloudShot\CloudShot.exe");
            //cmd.StandardInput.WriteLine("C:\\Windows\\sysnative\\SnippingTool.exe /clip");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();


        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            cmb_archivos.ValueMember = "id_serv";
            string comando = "select * from servicios";
            cmb_archivos.DataSource = combo(comando, 1);
            
            
            cmb_archivos.DisplayMember = "desc_serv";

            

            if (gb_titulo.Visible == false)
                {
                mostrar(gb_titulo);
            }
            else
            {
            ocultar(gb_titulo);
            }
            Form1.ActiveForm.AutoSize = true;
        }

        private void cmb_archivos_SelectedIndexChanged(object sender, EventArgs e)
        {

            string serv = cmb_archivos.SelectedValue.ToString();
            cmb_titulos.ValueMember = "desc_titulos";
            cmb_titulos.DisplayMember = "desc_titulos";
            string comando2 = "select * from titulos where id_serv =" + serv;
            cmb_titulos.DataSource = combo(comando2, 1);
           
        }

        private void cmb_titulos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string index = cmb_titulos.SelectedValue.ToString();

            Clipboard.SetText(index);
        }


        private void usu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                if (string.IsNullOrEmpty(usu.Text))
                {
                    usu.BackColor = Color.Beige;
                }
                else
                {
                    gb_user.AutoSize = true;
                    Form1.ActiveForm.AutoSize = false;
                    //Form1.ActiveForm.Size = new Size(388, 238);
                    string salida, salida1, salida2, salida3, salida4, salida5;

                    string nom = usu.Text;
                    Process cmd2 = new Process();
                    cmd2.StartInfo.FileName = "cmd.exe";
                    cmd2.StartInfo.RedirectStandardInput = true;
                    cmd2.StartInfo.RedirectStandardOutput = true;
                    cmd2.StartInfo.CreateNoWindow = true;

                    cmd2.StartInfo.UseShellExecute = false;
                    cmd2.Start();
                    cmd2.StandardInput.WriteLine("@echo off ");
                    cmd2.StandardInput.WriteLine("net user " + nom + " /do");
                    cmd2.StandardInput.Flush();
                    cmd2.StandardInput.Close();

                    string res = cmd2.StandardOutput.ReadToEnd();

                    int largo = res.Length;
                    int permisos = res.IndexOf("grupo global");
                    int user_s = res.IndexOf("Nombre");
                    int user_e = res.IndexOf("Comentario del usuario");
                    int user_a = res.IndexOf("Cuenta activa");
                    int camb = res.IndexOf("Ultimo cambio");
                    int ulti = res.IndexOf("Ultima");



                    if (user_s > 0)
                    {
                        salida1 = res.Substring(user_s, user_e - (user_s));
                        salida2 = res.Substring(user_a, user_a - user_a + 45);
                        salida3 = res.Substring(camb, camb - camb + 50);
                        salida4 = res.Substring(ulti, ulti - ulti + 50);
                        salida5 = "                         " + res.Substring(permisos + 12, largo - permisos - 50);
                        salida = string.Format(Environment.NewLine + salida1 + Environment.NewLine + salida2 + Environment.NewLine + salida3 + Environment.NewLine + salida4 + Environment.NewLine + salida5);
                    }
                    else
                    {
                        salida1 = "";
                        salida2 = "\n";
                        salida3 = "++++++++++++++++ Usuario no Encontrado +++++++++++++++";
                        salida4 = "";
                        salida5 = "";
                        salida = salida1 + salida2 + salida3 + salida4 + salida5;
                    }




                    textBox3.Show();
                    int alto = (salida.Split('\n').Length - 1);
                    textBox3.Height = alto * 12;
                    textBox3.Text = salida;


                    Form1.ActiveForm.AutoSize = true;
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (gb_config.Visible == false)
            {
                mostrar(gb_config);
            }
            else
            {
                ocultar(gb_config);
            }

            Form1.ActiveForm.AutoSize = true;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Cerrar Aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                Form1.ActiveForm.Close();
            }
        }

        int posY = 0;
        int posX = 0;
        private void pictureBox8_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }


        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ocultar(gb_remote);
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            RemoveClipboardFormatListener(this.Handle);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            long ms;
            
            string ip= u_pc.Text;
            Ping pingSender = new Ping();
            
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            enviado++;
            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            try
            {
                PingReply reply = pingSender.Send(ip, timeout, buffer, options);
                total++;
                if (reply.Status == IPStatus.Success)
                {
                    pingSender.Dispose();
                    gb_ping.Text = reply.RoundtripTime.ToString() + "ms";
                    pictureBox11.BringToFront();
                    ms = reply.RoundtripTime;
                   
                    recibido++;
                    mss =mss + ms;
                    
                    if (ms < min)
                    {
                        min = ms;
                    }
                    if (ms > max)
                    {
                        max = ms;
                    }
                    chart1.Series["Series"].Points.AddY(ms);
                    chart1.Series["Series"].Color = System.Drawing.Color.LawnGreen;
                }
                else
                {
                    pingSender.Dispose();
                    pictureBox9.BringToFront();
                    ms = 0;
                    chart1.Series["Series"].Points.AddY(ms);
                    chart1.Series["Series"].Color = System.Drawing.Color.DarkRed;
                    cortes++;
                    label8.Text = cortes.ToString();
                    perdido++;
                }
                
            
            }
            catch
            {
                chart1.Hide();
                textBox1.Show();
                textBox1.Text = "Valor No Valido";
                timer1.Stop();
                cmd_menost.Text = "Parar";
            }

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
           

            if (string.IsNullOrEmpty(u_pc.Text))
            {
                u_pc.BackColor = Color.Beige;
            }
            else
            {

                timer2.Start();

                gb_ping.Show();
                chart1.Hide();
                gb_ping.Location = new Point(3, 145);
                Form1.ActiveForm.Size = new Size(344, 250);
                
               
                string nom = u_pc.Text;
                gb_ping.Text = nom;
                int largo = 0;
                int largo2 = 0;
                string salida1;
                string salida2;
                textBox1.Clear();


                Process cmd2 = new Process();
                cmd2.StartInfo.FileName = "cmd.exe";
                cmd2.StartInfo.RedirectStandardInput = true;
                cmd2.StartInfo.RedirectStandardOutput = true;
                cmd2.StartInfo.CreateNoWindow = true;
                cmd2.StartInfo.UseShellExecute = false;
                cmd2.Start();
                cmd2.StandardInput.WriteLine("@echo off");
                cmd2.StandardInput.WriteLine("nslookup " + nom);
                cmd2.StandardInput.Flush();
                cmd2.StandardInput.Close();
                cmd2.WaitForExit();
                string res2 = cmd2.StandardOutput.ReadToEnd();
                int ok1 = res2.IndexOf("Nombre:");
                if (ok1 > 0)
                {
                    if (nom.Substring(0, 2) == "10")
                    {
                        largo2 = 285;
                    }
                    else
                    {
                        largo2 = 286;
                    }
                    salida1 = res2.Substring(largo2);
                }
                else
                {
                    salida1 = "+++++++++++++++";
                }



                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();
                cmd.StandardInput.WriteLine("@echo off");
                cmd.StandardInput.WriteLine("ping -4 " + nom);
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                string res = cmd.StandardOutput.ReadToEnd();
                int ok2 = res.IndexOf("no pudo encontrar el host");
                if (ok2 == -1)
                {

                    if (nom.Substring(0, 2) == "10")
                    {
                        largo = 275;
                    }
                    else
                    {
                        largo = 305;
                    }
                    salida2 = res.Substring(largo);


                }
                else
                {
                    salida2 = " Terminal no Encontrada \n ++++++++++++++++";
                }

                int ok3 = res.IndexOf("(0% perdidos)");
                if (ok3 == -1)
                {
                    timer2.Stop();
                    pictureBox9.BringToFront();
                }
                else
                {
                    timer2.Stop();
                    pictureBox11.BringToFront();
                }

                string salida = salida1 + salida2;
                textBox1.Show();

                int alto = (salida.Split('\n').Length + salida2.Split('\n').Length - 1);

                textBox1.Height = alto * 12;
                textBox1.Text = salida;


                //Form1.ActiveForm.AutoSize = true;
            }


        }

        string r_ping, rec;
        int cortes, enviado, recibido, perdido, total;
        long mss, max, min;

        private void bt_font_Click(object sender, EventArgs e)
        {
            FontDialog fuente = new FontDialog();
            if (fuente.ShowDialog() == DialogResult.OK)
            {
                this.Font = fuente.Font;
            }
        }

        private void bt_letra_Click(object sender, EventArgs e)
        {
            ColorDialog colorlet = new ColorDialog();
            if (colorlet.ShowDialog() == DialogResult.OK)
            {
                this.ForeColor = colorlet.Color;
                bt_letra.BackColor = colorlet.Color;

                Settings.Default["Color_F"] = bt_letra.BackColor;
                Settings.Default.Save();
            }
        }

        private void bt_bg_Click(object sender, EventArgs e)
        {
            ColorDialog colorbg = new ColorDialog();
            if (colorbg.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorbg.Color;
                bt_bg.BackColor = colorbg.Color;

                Settings.Default["Color_B"] = bt_bg.BackColor;
                Settings.Default.Save();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Empty;
            Settings.Default["Color_B"] = Color.Empty;

           this.ForeColor = Color.Empty;
            Settings.Default["Color_F"] = Color.Empty;
            

            //this.Font = default;
            //Settings.Default["Fuente"] = default;


            Form1.ActiveForm.Size = new Size(344, 220);

            path_titulos = @"\\b1842zacw0879\\Pablo\\Datos\\TEST\\Titulos";
            Settings.Default["Path"] = path_titulos;
         

            Settings.Default["Fijar"] = false;
            

            Settings.Default["Transparente"] = 0.99f;


            Settings.Default.Save();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog ruta = new FolderBrowserDialog();

            if (ruta.ShowDialog() == DialogResult.OK)
            {
                path_titulos = Directory.GetFiles(ruta.SelectedPath).ToString();
                Settings.Default["Path"] = path_titulos;
                Settings.Default.Save();



            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            

            if (flag == 1)
            {
                pictureBox1.Hide();
                pictureBox2.Hide();
                pictureBox3.Hide();
                pictureBox5.Hide();
                pictureBox26.Hide();
                ping.Hide();
                flag = 0;
            }
            else
            {
                pictureBox1.Show();
                pictureBox2.Show();
                pictureBox3.Show();
                pictureBox5.Show();
                pictureBox26.Show();
                ping.Show();
                flag = 1;
            }
            
            
        }



        private void pictureBox17_Click(object sender, EventArgs e)
        {
            if (gb_bdc.Visible == false)
            {
                mostrar(gb_bdc);



                tb_paginas.AutoCompleteCustomSource = CargaPaginas();
                tb_paginas.AutoCompleteMode = AutoCompleteMode.Suggest;
                tb_paginas.AutoCompleteSource = AutoCompleteSource.CustomSource;

            }
            else
            {
                ocultar(gb_bdc);
            }
        }


        private AutoCompleteStringCollection CargaPaginas()
        {
            string consulta = "SELECT * FROM paginas_web";

            DataTable lista = new DataTable();
            lista = combo(consulta, 5);


            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (DataRow row in lista.Rows)
            {
                stringCol.Add(Convert.ToString(row["url"]));
            }

            return stringCol;
        }


        private void tb_paginas_TextChanged(object sender, EventArgs e)
        {
            string consulta = "SELECT pagina_nom FROM paginas_web WHERE url="+ tb_paginas.Text + ";";
            MySqlCommand cm = new MySqlCommand(consulta, cn5);

            //string url = (Int32)cm.ExecuteScalar();


            //Clipboard.SetText(url);
        }



        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                System.Diagnostics.Process.Start("http://bc-mda:8080/basedeconocimientos/?s=" + textBox4.Text + "&submit=Buscar");
            }
        }

        

        private void pictureBox15_Click(object sender, EventArgs e)
        {
          


        }

       

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            int por;
            long msst;
            chart1.BringToFront();
            textBox1.Hide();
            label8.Show();
            Form1.ActiveForm.Size = new Size(344, 250);
            
            if (string.IsNullOrEmpty(u_pc.Text))
            {
                u_pc.BackColor = Color.Beige;
            }
            else
            {
                gb_ping.Show();
                gb_ping.Location = new Point(3, 145);
                Form1.ActiveForm.Size = new Size(344, 250);


                if (cmd_menost.Text == "Ping -t")
                {
                    r_ping = " ";
                    total = 0;
                    enviado = 0;
                    recibido = 0;
                    perdido = 0;
                    min = 0;
                    max = 0;
                    cortes = 0;

                    timer1.Start();

                    cmd_menost.Text = "Parar";
                    chart1.Series["Series"].Points.Clear();
                    chart1.Show();
                    Form1.ActiveForm.Size = new Size(344, 220);
                }
                else
                {
                    timer1.Stop();
                    cmd_menost.Text = "Ping -t";
                    chart1.Hide();
                    textBox1.Clear();
                    textBox1.Show();
                    gb_ping.AutoSize = false;

                    
                    try
                    {
                        por = (total / perdido);
                        msst = mss / total;

                    }
                    catch
                    {
                        por = 0;
                        msst = 0;
                    }
                    textBox1.Text = "Estadísticas de ping para  " + u_pc.Text + " :" + Environment.NewLine + "Enviados = " + enviado + Environment.NewLine + "Recibidos = " + recibido + Environment.NewLine + "Perdidos = " + perdido + Environment.NewLine + "(" + por + "% Perdidos)" + Environment.NewLine + "Tiempos aproximados de ida y vuelta en milisegundos: " + Environment.NewLine + "Mínimo = " + min + "ms" + " ,  " + "Máximo = " + max + "ms" + " ,   " + "Media = " + msst + "ms";
                    pictureBox12.BringToFront();
                    textBox1.Height = 102;

                    Form1.ActiveForm.Size = new Size(344, 200);
                }
            }
        }

        

        private void pictureBox14_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.BackColor = Color.Beige;
            }
            else
            {

                gb_config.Hide();
                gb_ping.Hide();
                gb_titulo.Hide();
                gb_user.Hide();
                Form1.ActiveForm.Size = new Size(346, 54);
                string nom = textBox2.Text;

                Process cmd2 = new Process();
                cmd2.StartInfo.FileName = "cmd.exe";
                cmd2.StartInfo.RedirectStandardInput = true;
                cmd2.StartInfo.RedirectStandardOutput = true;
                cmd2.StartInfo.CreateNoWindow = true;
                cmd2.StartInfo.UseShellExecute = false;
                cmd2.Start();
                cmd2.StandardInput.WriteLine("@echo off");
                cmd2.StandardInput.WriteLine("msra /offerRA " + nom);
                cmd2.StandardInput.Flush();
                cmd2.StandardInput.Close();
                cmd2.WaitForExit();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            u_pc.Text = rec; 
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox16.BringToFront();
            Thread.Sleep(250);
            pictureBox12.BringToFront();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void u_pc_Click(object sender, EventArgs e)
        {
            if (u_pc.Text == String.Empty)
            {
                u_pc.Focus();

            }
            else
            {
                rec = u_pc.Text;
                label7.Show();
                label7.ForeColor = Color.OrangeRed;
                u_pc.Clear();
                timer1.Stop();
                cmd_menost.Text = "Ping -t";
                
                pictureBox12.BringToFront();
            }
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            tb_tipi_ci.Hide();
            tb_tipi_p.Hide();
            if (gb_tipifica.Visible == false)
            {
                mostrar(gb_tipifica);
            }
            else
            {
                ocultar(gb_tipifica);
            }
        }

        

        private void cb_problema_SelectionChangeCommitted(object sender, EventArgs e)
        {
            gb_tipifica2.Show();
            gb_tipifica2.Location = new Point(3,152);
            Form1.ActiveForm.Size = new Size(344, 500);

            string id = cb_problema.SelectedValue.ToString();
            cn2.Open();
            MySqlCommand cmd = new MySqlCommand("select * from problema where id_ci =" + id, cn2);
            MySqlDataReader reg = cmd.ExecuteReader();

            if (reg.Read())
            {
                lb_titulo.Text = reg["servicio_titulo"].ToString();
                lb_servicio.Text = reg["servicio_p"].ToString(); ;
                lb_ci_afectado.Text = reg["servicio_ci"].ToString(); ;
                lb_categoria.Text = reg["servicio_cat"].ToString(); ;
                lb_subarea.Text = reg["servicio_subarea"].ToString(); ;
                lb_area.Text = reg["servicio_area"].ToString(); ;

            }
            else
            {
                lb_titulo.Text = "";
                lb_servicio.Text = "";
                lb_ci_afectado.Text = "";
                lb_categoria.Text = "";
                lb_subarea.Text = "";
                lb_area.Text = "";
            }

            cn2.Close();
        }

       

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            cargaboxci(1);
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            cargaboxci(1);
        }

        

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            cargaboxci(1);
        }


        private void pictureBox21_Click(object sender, EventArgs e)
        {
            cargaboxci(1);
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            cargaboxci(1);
        }

        

        public void cargaboxci(int x)
        {
            int serv = x;

            cb_ci.ValueMember = "id_ci";
            cb_ci.DisplayMember = "desc_ci";
            string comandoCI = "select * from ci where id_esquema =" + serv;


            cb_ci.DataSource = combo(comandoCI, 2);

        }



        private void cb_ci_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string serv = cb_ci.SelectedValue.ToString();
            cb_problema.ValueMember = "id_problema";
            cb_problema.DisplayMember = "desc_problema";
            string comando2 = "select * from problema where id_ci =" + serv;
            cb_problema.DataSource = combo(comando2, 2);
        }


        private void label13_Click(object sender, EventArgs e)
        {
            if (tb_tipi_ci.Visible == false)
            {
                tb_tipi_ci.Show();
                label13.BackColor = Color.Silver;
                tb_tipi_p.Hide();
            }
            else
            {
                tb_tipi_ci.Hide();
                label13.BackColor = Color.White;
            }
            
        }

        private void tb_tipi_ci_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string serv = "%" + tb_tipi_ci.Text + "%";
                cb_problema.ValueMember = "id_ci";
                cb_problema.DisplayMember = "desc_ci";
                string comando2 = "select * from ci where desc_ci LIKE" + "'" + serv + "'";
                cb_problema.DataSource = combo(comando2, 2);
                tb_tipi_p.Hide();
                label13.BackColor = Color.White;
                tb_tipi_ci.Hide();
                label14.BackColor = Color.White;
            }
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            if (gb_clip.Visible == false)
            {
                mostrar(gb_clip);
            }
            else
            {
                ocultar(gb_clip);
            }
            Form1.ActiveForm.AutoSize = true;
        }

       

        private void label14_Click(object sender, EventArgs e)
        {
            if (tb_tipi_p.Visible == false)
            {
                tb_tipi_p.Show();
                label14.BackColor = Color.Silver;
                tb_tipi_ci.Hide();
            }
            else
            {
                tb_tipi_p.Hide();
                label14.BackColor = Color.White;
            }
        }

        private void tb_tipi_p_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string serv = "%" + tb_tipi_p.Text + "%";
                cb_problema.ValueMember = "id_problema";
                cb_problema.DisplayMember = "desc_problema";
                string comando2 = "select * from problema where desc_problema LIKE" +"'" + serv+ "'";
                cb_problema.DataSource = combo(comando2, 2);
                tb_tipi_p.Hide();
                label13.BackColor = Color.White;
                tb_tipi_ci.Hide();
                label14.BackColor = Color.White;
            }
            
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            tabControl1.Hide();
            dataGridView1.Hide();
            tb_sitio.Text = "";

            if (gb_sitios.Visible == false)
            {
                mostrar(gb_sitios);
            }
            else
            {
                ocultar(gb_sitios);
            }

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                tabControl1.Hide();
                string serv = "%" + tb_sitio.Text + "%";
                string comando3 = "";

                if (rb_comercial.Checked == true)
                {
                    comando3 = "select  NIS as NIS, DENOMINACION as DENOMINACIÓN from sas where DENOMINACION LIKE" + "'" + serv + "' or NIS LIKE" + "'" + serv + "' and (CATEGORIA='ESPECIALES' and CATEGORIA='CORREO CORPORATIVO' and CATEGORIA='AGENCIA' or CATEGORIA='SUCURSAL' or CATEGORIA='ESTAFETA' or CATEGORIA='UNIDAD POSTAL')";
                }
                else if (rb_operativo.Checked == true)
                {
                    comando3 = "select  NIS as NIS, DENOMINACION as DENOMINACIÓN from sas where DENOMINACION LIKE" + "'" + serv + "' or NIS LIKE" + "'" + serv + "' and (CATEGORIA='CDD' or CATEGORIA='CDP' or CATEGORIA='CTP')";
                }
                else if (rb_admin.Checked == true)
                {
                    comando3 = "select NIS as NIS, DENOMINACION as DENOMINACIÓN from sas where DENOMINACION LIKE" + "'" + serv + "' or NIS LIKE" + "'" + serv + "' and (CATEGORIA='ADMINISTRACION' or CATEGORIA='GENERAL')";
                }
                else
                {
                    comando3 = "select NIS as NIS, DENOMINACION as DENOMINACIÓN from sas where DENOMINACION LIKE" + "'" + serv + "' or NIS LIKE" + "'" + serv + "'";
                }

                /*
                lb_sitios.DisplayMember = "denominacion";
                lb_sitios.ValueMember = "nis";
                
                lb_sitios.DataSource = combo(comando3, 3);
                int cant_sitios = lb_sitios.Items.Count;

                lb_sitios.Height = cant_sitios+cant_sitios*10;
                lb_cant_sitios.Text = lb_sitios.Height.ToString();
                */

                dataGridView1.DataSource = combo(comando3, 3);

                dataGridView1.Show();
                
                dataGridView1.Columns[1].Width = 225;
                dataGridView1.Columns[0].Width = 60;

                if (dataGridView1.Rows.Count < 10)
                {
                    dataGridView1.Height = dataGridView1.ColumnHeadersHeight*dataGridView1.Rows.Count+1;
                    
                }
                else
                {
                    dataGridView1.Height = dataGridView1.ColumnHeadersHeight * 10;
                }

                gb_sitios.AutoSize = true;

            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tb_sitio.Text = "";
            
            string valorCelda = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex-1].Value.ToString();

            tabControl1.Show();
            dataGridView1.Hide();
            tabControl1.Location = new Point(3, 152);
            Form1.ActiveForm.Size = new Size(344, 500);


            cn3.Open();
            MySqlCommand cmd = new MySqlCommand("select * from sas where NIS =" + "'" + valorCelda + "'", cn3);
            MySqlDataReader reg = cmd.ExecuteReader();

            if (reg.Read())
            {
                lbb_denom.Text = reg["DENOMINACION"].ToString();
                lbb_nis.Text = reg["NIS"].ToString();
                lbb_partido.Text = reg["PARTIDO"].ToString(); 
                lbb_provincia.Text = reg["PROVINCIA"].ToString(); 
                lbb_categoria.Text = reg["CATEGORIA"].ToString(); 
                lbb_cpa.Text = reg["CPA_SUCURSAL"].ToString(); 
                lbb_tipo.Text = reg["TIPO"].ToString(); 
                lbb_titular.Text = reg["TITULAR"].ToString();
                lbb_region.Text = reg["REGION"].ToString();
                lbb_dire.Text = reg["CALLE"].ToString();
                lbb_telefono.Text = reg["TELEFONOS"].ToString();
                lbb_hora.Text = reg["HORARIOS"].ToString();
                lbb_numero.Text = reg["NUMERO"].ToString();
                if (reg["simon"].ToString() == "SI")
                {
                    pictureBox25.Show();
                }
                else
                {
                    pictureBox25.Hide();
                }
            }
            else
            {
                lbb_nis.Text = "";
                lbb_partido.Text = "";
                lbb_provincia.Text = "";
                lbb_categoria.Text = "";
                lbb_cpa.Text = "";
                lbb_tipo.Text = "";
                lbb_titular.Text = "";
                lbb_region.Text = "";
                lbb_dire.Text = "";
                lbb_telefono.Text = "";
                lbb_hora.Text = "";
                pictureBox25.Hide();
            }

            cn3.Close();

        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_DRAWCLIPBOARD = 0x308;
            const int CHANGECBCHAIN = 0x030D;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    DisplayClipboardData();
                    
                    SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;

                case CHANGECBCHAIN:
                    if (m.WParam == nextClipboardViewer)
                        nextClipboardViewer = m.WParam;
                    else
                        SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        void DisplayClipboardData()
        {
            string strClipboard = string.Empty;
            
            try
            {
                IDataObject myDataObject = new DataObject();
                myDataObject = Clipboard.GetDataObject();
                if (myDataObject.GetDataPresent(DataFormats.UnicodeText))
                {
                    strClipboard = myDataObject.GetData(DataFormats.UnicodeText).ToString();
                }
                else if (myDataObject.GetDataPresent(DataFormats.Text))
                {
                    strClipboard = (string)myDataObject.GetData(DataFormats.StringFormat);
                }

                if (dataGridView2.RowCount > 10)
                {
                    this.dataGridView2.Rows.Remove(dataGridView2.Rows[0]);
                    this.dataGridView2.Rows.Add(Clipboard.GetText());
                }
                else
                {
                    this.dataGridView2.Rows.Add(Clipboard.GetText());
                }
                var height = dataGridView2.ColumnHeadersHeight;
                
                foreach (DataGridViewRow dr in dataGridView2.Rows)
                {
                    height += dr.Height;

                }
                dataGridView2.ScrollBars = ScrollBars.None;
                dataGridView2.Height = height - dataGridView2.ColumnHeadersHeight;
                gb_clip.AutoSize = true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            

        }



        //ZONA::::: Envíar Mails Automatico..........................................


        string asunto = "Prueba de Confirmación de Tickets";

        string cuerpo = "Nos comunicamos desde Mesa de Ayuda para informar que los siguientes casos nos figuran como resueltos. " +
                        "Podria indicarnos si podemos proceder con el cierre de los casos que figuran en la siguiente Tabla:";
        string final = "Muchas Gracias";

        int MailsEnviados = 0;

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            cn4.Close();

            if (gb_email.Visible == false)
            {
                

                if (dg_lista0.Rows.Count > 1 && dg_lista0.Rows != null)
                {
                    mostrar(tabControl2);

                }
                else
                {
                    mostrar(gb_email);

                }
            }
            else
            {
                ocultar(gb_email);

            }
            Form1.ActiveForm.AutoSize = true;

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

            dg_lista1.Hide();
            dg_lista2.Hide();
            dg_lista3.Hide();
            label45.Hide();

            this.Size = new Size(346, 60);
            this.AutoSize = true;
            testConect();

            textBox8.Text = asunto;
            textBox7.Text = cuerpo;
            textBox6.Text = final;
        }

       

        void testConect()
        {

            try
            {
                cn4.Open();
                
            }
            catch (Exception)
            {
                MessageBox.Show("No hay conexión con el Servidor de Datos, la aplicación se cerrará", "Fallo de conexión con el server");
                //this.Close();
                gb_email.Hide();
                Form1.ActiveForm.Size = new Size(346, 54);
                pictureBox7.BringToFront();
            }

        }



        private void pictureBox27_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                //DE ESTA MANERA FILTRAMOS TODOS LOS ARCHIVOS EXCEL EN EL NAVEGADOR DE ARCHIVOS
                Filter = "Excel | *.xls;*.xlsx;",

                //AQUÍ INDICAMOS QUE NOMBRE TENDRÁ EL NAVEGADOR DE ARCHIVOS COMO TITULO
                Title = "Seleccionar Archivo"
            };

            //EN CASO DE SELECCIONAR EL ARCHIVO, ENTONCES PROCEDEMOS A ABRIR EL ARCHIVO CORRESPONDIENTE
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                dg_lista1.DataSource = ImportarDatos(openFileDialog.FileName);
                dg_lista1.Columns.Add("flag", "tipo");
                lb_num_total.Text = (dg_lista1.RowCount - 1).ToString();

            }

            if (dg_lista1.Columns.Contains("Ubicación") && dg_lista1.Columns.Contains("Título") && dg_lista1.Columns.Contains("Nombre completo de contacto") && dg_lista1.Columns.Contains("ID de la interacción"))
            {


                dg_lista2.Columns.Add("Ubicación", "Ubicación");
                dg_lista2.Columns.Add("ID de la interacción", "ID de la interacción");
                dg_lista2.Columns.Add("Título", "Título");
                dg_lista2.Columns.Add("Nombre completo de contacto", "Nombre completo de contacto");
                dg_lista3.Columns.Add("Ubicación", "Ubicación");
                dg_lista3.Columns.Add("ID de la interacción", "ID de la interacción");
                dg_lista3.Columns.Add("Título", "Título");
                dg_lista3.Columns.Add("Nombre completo de contacto", "Nombre completo de contacto");

                ListarUsuario();

                for (int i = 0; i < dg_lista1.RowCount - 1; i++)
                {
                    if (this.dg_lista1.Rows[i].Cells["flag"].Value == "user")
                    {

                        this.dg_lista2.Rows.Add(dg_lista1.Rows[i].Cells["Ubicación"].Value, dg_lista1.Rows[i].Cells["ID de la interacción"].Value, dg_lista1.Rows[i].Cells["Título"].Value, dg_lista1.Rows[i].Cells["Nombre completo de contacto"].Value);

                        this.dg_lista1.Rows.Remove(dg_lista1.Rows[i]);
                        i--;
                    }
                }

                ListarSitios();

                for (int i = 0; i < dg_lista1.RowCount - 1; i++)
                {
                    if (this.dg_lista1.Rows[i].Cells["flag"].Value == "sitio")
                    {
                        this.dg_lista3.Rows.Add(dg_lista1.Rows[i].Cells["Ubicación"].Value, dg_lista1.Rows[i].Cells["ID de la interacción"].Value, dg_lista1.Rows[i].Cells["Título"].Value, dg_lista1.Rows[i].Cells["Nombre completo de contacto"].Value);

                        this.dg_lista1.Rows.Remove(dg_lista1.Rows[i]);
                        i--;
                    }
                }

                ListarNoEncontrados();

                this.dg_lista1.Refresh();
                var height = dg_lista0.ColumnHeadersHeight;

                if (dg_lista0.Rows.Count < 10)
                {
                    dg_lista0.Height = (height * dg_lista0.RowCount + 1) + 5;
                }
                else
                {
                    dg_lista0.Height = dg_lista0.RowCount * height;
                }



                lb_num_usuario.Text = (dg_lista2.RowCount - 1).ToString();
                lb_num_sitios.Text = (dg_lista3.RowCount - 1).ToString();
                lb_num_no.Text = (dg_lista1.RowCount - 1).ToString();
                gb_email.Hide();
                tabControl2.Show();
                tabControl2.Location = new Point(3, 60);
                tabControl2.Height = 240 + dg_lista0.RowCount * height;
                Form1.ActiveForm.Size = new Size(346, 60);
                Form1.ActiveForm.AutoSize = true;

            }
            else
            {
                MessageBox.Show("No se encuentran las Tablas necesarias para el analisis", "Tablas Faltantes");

            }
        }

        

        DataView ImportarDatos(string nombrearchivo) //COMO PARAMETROS OBTENEMOS EL NOMBRE DEL ARCHIVO A IMPORTAR
        {
            //UTILIZAMOS 12.0 DEPENDIENDO DE LA VERSION DEL EXCEL, EN CASO DE QUE LA VERSIÓN QUE TIENES ES INFERIOR AL DEL 2013, CAMBIAR A EXCEL 8.0 Y EN VEZ DE
            //ACE.OLEDB.12.0 UTILIZAR LO SIGUIENTE (Jet.Oledb.4.0)
            string conexion = string.Format("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = {0}; Extended Properties = 'Excel 12.0;'", nombrearchivo);

            OleDbConnection conector = new OleDbConnection(conexion);


            conector.Open();

            //DEPENDIENDO DEL NOMBRE QUE TIENE LA PESTAÑA EN TU ARCHIVO EXCEL COLOCAR DENTRO DE LOS []
            OleDbCommand consulta = new OleDbCommand("select * from [Hoja1$]", conector);

            OleDbDataAdapter adaptador = new OleDbDataAdapter
            {
                SelectCommand = consulta
            };

            DataSet ds = new DataSet();

            adaptador.Fill(ds);

            conector.Close();

            return ds.Tables[0].DefaultView;
        }

        void ListarUsuario()
        {
            dg_lista1.Sort(dg_lista1.Columns["Nombre completo de contacto"], ListSortDirection.Ascending);

            string nombre = "";
            string desc = "";
            int verifica = 0;

            int vueltas = 0;
            int cant_ticket = 0;

            int cant_registros = dg_lista1.RowCount - 1;

            string user = dg_lista1.Rows[0].Cells["Nombre completo de contacto"].Value.ToString();

            for (int i = 0; i < cant_registros; i++)
            {
                if (user == dg_lista1.Rows[i].Cells["Nombre completo de contacto"].Value.ToString())
                {
                    cant_ticket++;
                    (nombre, desc, verifica) = verificar(dg_lista1.Rows[i].Cells["Nombre completo de contacto"].Value.ToString(), 1);

                    if (verifica == 1)
                    {
                        this.dg_lista1.Rows[i].Cells["flag"].Value = "user";

                    }

                }
                else
                {

                    if (verifica == 1)
                    {
                        this.dg_lista0.Rows.Add(nombre, desc + "@correoargentino.com.ar", cant_ticket);

                    }

                    user = dg_lista1.Rows[i].Cells["Nombre completo de contacto"].Value.ToString();

                    cant_ticket = 0;
                    i--;
                }
                vueltas++;
            }
            (nombre, desc, verifica) = verificar(dg_lista1.Rows[cant_registros - 1].Cells["Nombre completo de contacto"].Value.ToString(), 1);

            if (verifica == 1)
            {
                this.dg_lista1.Rows[cant_registros - 1].Cells["flag"].Value = "user";
            }
        }

        void ListarSitios()
        {
            dg_lista1.Sort(dg_lista1.Columns["Ubicación"], ListSortDirection.Ascending);

            string nombre = "";
            string desc = "";
            int verifica = 0;
            int vueltas = 0;
            int cant_ticket = 0;

            int cant_registros = dg_lista1.RowCount - 1;

            string user = dg_lista1.Rows[0].Cells["Ubicación"].Value.ToString();

            for (int i = 0; i < cant_registros; i++)
            {

                if (user == dg_lista1.Rows[i].Cells["Ubicación"].Value.ToString())
                {
                    cant_ticket++;
                    (nombre, desc, verifica) = verificar(dg_lista1.Rows[i].Cells["Ubicación"].Value.ToString(), 2);

                    if (verifica == 1)
                    {
                        this.dg_lista1.Rows[i].Cells["flag"].Value = "sitio";
                    }

                }
                else
                {

                    if (verifica == 1)
                    {
                        this.dg_lista0.Rows.Add(nombre, desc + "@correoargentino.com.ar", cant_ticket);

                    }

                    user = dg_lista1.Rows[i].Cells["Ubicación"].Value.ToString();

                    cant_ticket = 0;
                    i--;
                }
            }
            vueltas++;

            (nombre, desc, verifica) = verificar(dg_lista1.Rows[cant_registros - 1].Cells["Ubicación"].Value.ToString(), 2);

            if (verifica == 1)
            {
                this.dg_lista0.Rows.Add(nombre, desc, cant_ticket);
            }

        }

        void ListarNoEncontrados()
        {
            if (dg_lista1.RowCount > 1)
            {
                dg_lista1.Sort(dg_lista1.Columns["Ubicación"], ListSortDirection.Ascending);

                string nombre = "";
                string desc = "";
                int verifica = 0;
                int cant_ticket = 0;

                int cant_registros = dg_lista1.RowCount - 1;

                string nis = dg_lista1.Rows[0].Cells["Ubicación"].Value.ToString();


                for (int i = 0; i < cant_registros; i++)
                {


                    if (nis == dg_lista1.Rows[i].Cells["Ubicación"].Value.ToString())
                    {
                        cant_ticket++;
                        (nombre, desc, verifica) = verificar(dg_lista1.Rows[i].Cells["Ubicación"].Value.ToString(), 2);

                    }
                    else
                    {
                        if (verifica == 1)
                        {
                            this.dg_lista0.Rows.Add(nombre, desc + "@correoargentino.com.ar", cant_ticket);

                        }
                        else
                        {
                            this.dg_lista1.Rows[i].Cells["flag"].Value = "No Encontrado";
                            this.dg_lista0.Rows.Add(dg_lista1.Rows[i - 1].Cells["Ubicación"].Value.ToString(), desc, dg_lista1.Rows[i - 1].Cells["Nombre completo de contacto"].Value.ToString());
                        }


                        nis = dg_lista1.Rows[i].Cells["Ubicación"].Value.ToString();

                        cant_ticket = 0;
                        i--;
                    }
                }


                (nombre, desc, verifica) = verificar(dg_lista1.Rows[cant_registros - 1].Cells["Ubicación"].Value.ToString(), 2);

                if (verifica == 1)
                {
                    this.dg_lista1.Rows[cant_registros - 1].Cells["flag"].Value = "No Encontrado";
                }
                else
                {
                    this.dg_lista1.Rows[cant_registros - 1].Cells["flag"].Value = "No Encontrado";
                    this.dg_lista0.Rows.Add(dg_lista1.Rows[cant_registros - 1].Cells["Ubicación"].Value.ToString(), desc, dg_lista1.Rows[cant_registros - 1].Cells["Nombre completo de contacto"].Value.ToString());
                }

            }
        }

        public (string, string, int) verificar(string valor, int tipo)
        {
            string nombre = "";
            string desc = "";

            if (tipo == 1)
            {
                if (cn4.State == ConnectionState.Open)
                {
                    cn4.Close();
                }

                cn4.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuarios WHERE nom_user ='" + valor + "'", cn4);
                MySqlDataReader num = cmd.ExecuteReader();
                if (num.HasRows)
                {
                    if (num.Read())
                    {
                        nombre = num["nom_user"].ToString();
                        desc = num["correo_user"].ToString() + "@correoargentino.com.ar";
                    }

                    cn.Close();
                    return (nombre, desc, 1);

                }
                else
                {

                    return (" - ", "No Encontrado", 2);

                }

            }
            else
            {
                if (cn4.State == ConnectionState.Open)
                {
                    cn4.Close();
                }

                cn4.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM sitios WHERE desc_sitio ='" + valor + "'", cn4);
                MySqlDataReader num = cmd.ExecuteReader();
                if (num.HasRows)
                {
                    if (num.Read())
                    {
                        nombre = num["desc_sitio"].ToString();
                        desc = num["correo_sitio"].ToString() + "@correoargentino.com.ar";
                    }
                    cn.Close();
                    return (nombre, desc, 1);
                }
                else
                {

                    return (" - ", "No Encontrado", 2);

                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (tb_psw.BackColor == Color.White)
            {
                tb_psw.BackColor = Color.LightBlue;
                tb_mail.BackColor = Color.LightBlue;
                tb_mail.BorderStyle = System.Windows.Forms.BorderStyle.None;
                tb_psw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            }
            else
            {
                tb_psw.BackColor = Color.White;
                tb_mail.BackColor = Color.White;
                tb_psw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                tb_mail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            }
        }



        private void tb_mail_Click(object sender, EventArgs e)
        {
            timer3.Stop();
            tb_psw.BackColor = Color.White;
            tb_mail.BackColor = Color.White;
            tb_psw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            tb_mail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        }

        

        private void tb_psw_Click(object sender, EventArgs e)
        {
            timer3.Stop();
            tb_psw.BackColor = Color.White;
            tb_mail.BackColor = Color.White;
            tb_psw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            tb_mail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        }

        

        string firma;

        

        public void sendMail(string destinatario, string asunto, string correo, string cuenta, string psw)
        {
            MailsEnviados++;
            dg_lista0.Rows[MailsEnviados].Cells["tickets"].Value = "✔";

            MailMessage msg = new MailMessage();

            if (pbFirma.Image != null)
            {
                AlternateView html = AlternateView.CreateAlternateViewFromString(correo + "<img src=cid:imagen1>", null, "text/html");
                LinkedResource url = new LinkedResource(pbFirma.ImageLocation, MediaTypeNames.Image.Jpeg);
                url.ContentId = "imagen1";
                html.LinkedResources.Add(url);
                msg.AlternateViews.Add(html);
                msg.Body = url.ContentId;

            }
            else
            {
                msg.Body = correo; //Mensaje del correo
            }

            msg.From = new MailAddress(cuenta, "Kyocode", System.Text.Encoding.UTF8);//Correo de salida
            msg.To.Add(destinatario); //Correo destino?
            msg.Subject = asunto; //Asunto

            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.office365.com"; //Host del servidor de correo
            smtp.Port = 587; //Puerto de salida
            smtp.Credentials = new System.Net.NetworkCredential(cuenta, psw);//Cuenta de correo
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.EnableSsl = true;//True si el servidor de correo permite ssl

            try
            {
                smtp.Send(msg);
                dg_lista0.Rows[MailsEnviados - 1].Cells["tickets"].Value = "✔✔";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el correo , Verifique Usuario y Contraseña y vuelva a intentar!!");
            }
        }

 

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            int flag = 0;
            int cantidadSitios = dg_lista3.RowCount - 1;
            int cantidadUsuarios = dg_lista2.RowCount - 1;
            string Body_tabla = "";
            int indice = 0;



            string Body_final = "</table>" +
                                "<p>" + final + "</p>" +
                             "</BODY>" +
                        "</HTML>";

            string Body = "<!DOCTYPE HTML PUBLIC>" +
                            "<HTML>" +
                                  "<BODY>" +

                                    "<p>Buen día,</p>" +
                                    "<p style='margin - left: 20px;'>" + cuerpo + "</p>" +
                                    "<table  class='default' style= 'padding - left: 50px; border - collapse: collapse; border: 1px solid black; text - align: center; vertical - align: middle; margin - left: 55px;' class='default'>" +
                                    "<tr style= 'border: 1px solid black;'> " +
                                        "<th style= 'border: 1px solid black;'> TICKET</th>" +
                                        "<th style= 'border: 1px solid black;' > TITULO </th>" +
                                    "</tr>";




            do
            {
                if (flag == 0)
                {
                    string user = dg_lista2.Rows[0].Cells["Nombre completo de contacto"].Value.ToString();


                    for (int i = 0; i < cantidadUsuarios; i++)
                    {
                        backgroundWorker1.ReportProgress(i + 1, user);

                        if (user == dg_lista2.Rows[i].Cells["Nombre completo de contacto"].Value.ToString())
                        {

                            Body_tabla = Body_tabla + "<tr style= 'border: 1px solid black;'> " +
                                        "<td style= 'border: 1px solid black;'> " + dg_lista2.Rows[i].Cells["ID de la interacción"].Value.ToString() + " </td>" +
                                        "<td style= 'border: 1px solid black;'> " + dg_lista2.Rows[i].Cells["Título"].Value.ToString() + " </td> " +
                                       "</tr>";

                        }
                        else
                        {
                            sendMail("zextjchavez" + "@correoargentino.com.ar", asunto, (Body + Body_tabla + Body_final), tb_mail.Text + "@correoargentino.com.ar", tb_psw.Text);
                            Body_tabla = "";


                            user = dg_lista2.Rows[i].Cells["Nombre completo de contacto"].Value.ToString();

                            Body_tabla = Body_tabla + "<tr style= 'border: 1px solid black;'>" +
                                                        "<td style= 'border: 1px solid black;'>" + dg_lista2.Rows[i].Cells["ID de la interacción"].Value.ToString() + " </td>" +
                                                        "<td style= 'border: 1px solid black;'> " + dg_lista2.Rows[i].Cells["Título"].Value.ToString() + " </td> " +
                                                       "</tr>";
                        }

                        indice = i;
                    }
                    backgroundWorker1.ReportProgress(indice + 1, user);
                    sendMail("zextjchavez" + "@correoargentino.com.ar", asunto, (Body + Body_tabla + Body_final), tb_mail.Text + "@correoargentino.com.ar", tb_psw.Text);
                    Body_tabla = "";
                    flag++;
                }
                else
                {
                    string nis = dg_lista3.Rows[0].Cells["Ubicación"].Value.ToString();

                    for (int i = 0; i < cantidadSitios; i++)
                    {
                        backgroundWorker1.ReportProgress(i + 1 + dg_lista2.RowCount, nis);

                        if (nis == dg_lista3.Rows[i].Cells["Ubicación"].Value.ToString())
                        {

                            Body_tabla = Body_tabla + "<tr style= 'border: 1px solid black;'>" +
                                        "<td style= 'border: 1px solid black;'>" + dg_lista3.Rows[i].Cells["ID de la interacción"].Value.ToString() + " </td>" +
                                        "<td style= 'border: 1px solid black;'> " + dg_lista3.Rows[i].Cells["Título"].Value.ToString() + " </td> " +
                                       "</tr>";

                        }
                        else
                        {

                            sendMail("zextjchavez" + "@correoargentino.com.ar", asunto, (Body + Body_tabla + Body_final), tb_mail.Text + "@correoargentino.com.ar", tb_psw.Text);

                            Body_tabla = "";


                            nis = dg_lista3.Rows[i].Cells["Ubicación"].Value.ToString();

                            Body_tabla = Body_tabla + "<tr style= 'border: 1px solid black;'>" +
                                                        "<td style= 'border: 1px solid black;'>" + dg_lista3.Rows[i].Cells["ID de la interacción"].Value.ToString() + " </td>" +
                                                        "<td style= 'border: 1px solid black;'> " + dg_lista3.Rows[i].Cells["Título"].Value.ToString() + " </td> " +
                                                       "</tr>";

                        }
                        indice = i;
                    }
                    backgroundWorker1.ReportProgress(indice + 1 + dg_lista2.RowCount, nis);
                    sendMail("zextjchavez" + "@correoargentino.com.ar", asunto, (Body + Body_tabla + Body_final), tb_mail.Text + "@correoargentino.com.ar", tb_psw.Text);
                    Body_tabla = "";
                    flag++;
                }


            } while (flag < 2);

        }



        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pb_enviar.Value = e.ProgressPercentage;
            label45.Text = e.UserState.ToString();

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dg_lista0.Show();
            label45.Hide();
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            if (pbFirma.ImageLocation != null)
            {
                MessageBox.Show("Ya se encuentra una firma cargada en la aplicación", "Firma Cargada");
            }
            else
            {


                OpenFileDialog ImagenFile = new OpenFileDialog();

                string filtro = "imagen| *. png; *.jpg";

                var ruta = "";

                ImagenFile.Filter = filtro;
                ImagenFile.Title = "Cargar imagen con Firma";
                try
                {

                    ImagenFile.Filter = filtro;
                    ImagenFile.Title = "Cargar imagen con Firma";

                    if (ImagenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (!ImagenFile.FileName.Equals(""))
                        {
                            pbFirma.ImageLocation = ImagenFile.FileName;
                            pictureBox29.BorderStyle = BorderStyle.Fixed3D;
                            pictureBox29.Refresh();

                            Settings.Default["firma"] = ImagenFile.FileName;
                            Settings.Default.Save();
                        }
                        else
                        {
                            pbFirma.ImageLocation = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fallo la carga de la imagen", MessageBoxButtons.OK);

                }
                finally
                {
                    ImagenFile.Dispose();
                }
            }
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            if (tb_mail.Text == "" || tb_psw.Text == "")
            {
                timer3.Interval = 1050;
                timer3.Start();

            }
            else
            {

                timer3.Stop();

                pb_enviar.Value = 0;
                pb_enviar.Maximum = (dg_lista2.RowCount + dg_lista3.RowCount) - 1;
                dg_lista0.Hide();
                Form1.ActiveForm.Size = new Size(346, 100);
                Form1.ActiveForm.AutoSize = true;
                tabControl2.AutoSize = true;
                label45.Show();
                label45.BringToFront();


                if (backgroundWorker1.IsBusy != true)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            dg_lista0.Rows.Clear();
            dg_lista0.Refresh();
            if (dg_lista1.Rows.Count <= 0)
            {
                dg_lista1.Rows.Clear();
                dg_lista1.Refresh();
            }

            dg_lista2.Rows.Clear();
            dg_lista2.Refresh();
            dg_lista3.Rows.Clear();
            dg_lista3.Refresh();

            gb_email.Show();
            gb_email.Location = new Point(3, 60);
            tabControl2.Hide();
            Form1.ActiveForm.Size = new Size(346, 60);
            Form1.ActiveForm.AutoSize = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pbFirma.ImageLocation = null;
            Settings.Default["firma"] = null;
            Settings.Default.Save();
            pictureBox29.Refresh();
        }
        //ZONA:::: APERTURA DE PROGRAMAS...............................

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            if (gb_app.Visible == false)
            {
                mostrar(gb_app);
            }
            else
            {
                ocultar(gb_app);
            }
            Form1.ActiveForm.AutoSize = true;
        }
    }
}