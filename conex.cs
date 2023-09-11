using DocumentFormat.OpenXml.Drawing;
using HMDA.pMenu.menu_r;
using HMDA.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace HMDA
{
    public partial class conex : Form
    {

        //Conexión a BBDD de UpTime
        
        
        MySqlConnection conn = new MySqlConnection();

        private string copiado; 

        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // width of ellipse
           int nHeightEllipse // height of ellipse
       );

        int tick = 0;
        public conex(string valor)
        {
            this.BackColor = Color.Black;
            this.Opacity = 0.90;

            InitializeComponent();

            SendMessage(tb_principal_red.Handle, EM_SETCUEBANNER, 0, "Nombre/IP de Equipo");

            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            
            this.Size = new Size(440, 50);

            this.copiado = valor;
            panel4.Hide();
        }

        private void conex_Load(object sender, EventArgs e)
        {
            if (copiado!=" ")
            {
                this.Activate();
                this.BringToFront();
                this.WindowState = FormWindowState.Normal;
                tb_principal_red.Text = copiado;
                //tb_principal_red.Select(tb_principal_red.TextLength, 0);

                iniciarPing();
            }
            else
            {
                panel4.Show();
                label4.Text=  Clipboard.GetText();
                this.Size = new Size(this.Width, panel4.Height);
                
            }

            lb_uptime.Hide();

            if (Settings.Default["kace"].ToString() == "False")
            {
                pictureBox9.Hide();
            }
            else
            {
                pictureBox9.Show();
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





        int cortes, enviado, recibido, perdido, total, a, b;
        long mss, max, min;

       

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {

                iniciarPing();

            }
        }

        void iniciarPing()
        {

            conex.ActiveForm.Size = new Size(440, 180);
            //conex.ActiveForm.Size = new Size(344, panel3.Height + 100);


            tick = 0;
            a = 0;
            b = 10;
            respuesta_ping();
        }

        DateTime GetLastBootUpTimeViaWMI(string computerName = ".")
        {
            var scope = new ManagementScope(string.Format(@"\\{0}\root\cimv2", computerName));
            scope.Connect();
            var query = new ObjectQuery("SELECT LastBootUpTime FROM Win32_OperatingSystem");
            var searcher = new ManagementObjectSearcher(scope, query);
            var firstResult = searcher.Get().OfType<ManagementObject>().First(); //assumes that we do have at least one result 
            return ManagementDateTimeConverter.ToDateTime(firstResult["LastBootUpTime"].ToString());
        }

        private void respuesta_ping()
        {
            lb_pe.Text = "0";
            lb_pok.Text = "0";
            lb_pf.Text = "0";
            total = 0;
            cargaIpNombre();
            gf_ping.Series["Series"].Points.Clear();
            tm_ping.Start();

        }

        


        ////
        ////////////////STOP-PLAY AL PING ////////////////
        ////
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            tm_ping.Start();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
            int por = 0;
            long msst = 0;
            try
            {
                por = (perdido*100)/total;
                msst = mss / total;

            }
            catch
            {
                por = 0;
                msst = 0;
            }

            string ping_est = "Estadísticas de ping para  " + tb_principal_red.Text + " :" + Environment.NewLine + "Enviados = " + enviado + ", " + "Recibidos = " + recibido + ", " + "Perdidos = " + perdido + Environment.NewLine + "(" + por + "% Perdidos)" + Environment.NewLine + "Tiempos aproximados de ida y vuelta en milisegundos: " + Environment.NewLine + "Mínimo = " + min + "ms" + " ,  " + "Máximo = " + max + "ms" + " ,   " + "Media = " + msst + "ms";
            Clipboard.SetText(ping_est);
        }





        ////
        ////////////////PING AL VALOR INGRESADO////////////////
        ////
        int repeticione=0;
        private async void tm_ping_Tick_1(object sender, EventArgs e)
        {
            Task task = null;

            task = ping();

            task = uptime();

            await task;

        }

        private async Task uptime()
        {
            conn = conexiones.getInstancia().CrearConexion("gmda");
            if (lb_uptime.Text== "uptime...")
            {
                
                try
                {
                    string qsel = "SELECT * FROM hmda_uptime_peticiones WHERE nom_pc = '" + tb_principal_red.Text +"' AND usuario= '"+ Settings.Default["user"].ToString() + "' AND estado= "+ true +"";


                    //MessageBox.Show("SELECT * FROM hmda_uptime_peticiones WHERE nom_pc = '" + tb_principal_red.Text + "' AND usuario= '" + Settings.Default["user"].ToString() + "' AND estado= " + true + "");

                    using (conn) // my connection string variable
                    {
                        
                        MySqlCommand comando = new MySqlCommand(qsel, conn);

                        conn.Open();
                        
                        MySqlDataReader reader = (MySqlDataReader) await comando.ExecuteReaderAsync();


                        if (reader != null)
                        {
                            //MessageBox.Show("Encontrado: " + reader[1].ToString());
                            while (reader.Read())
                            {
                                lb_uptime.Text= reader[4].ToString();


                                string qdel = "DELETE FROM hmda_uptime_peticiones WHERE id = " + reader[0].ToString() + ";";

                                conn.Close();
                                using (conn) // my connection string variable
                                {
                                    MySqlCommand cmd = new MySqlCommand(qdel, conn);

                                    conn.Open();

                                    await cmd.ExecuteNonQueryAsync();

                                    conn.Close();
                                }
                                break;
                            }
                            
                            conn.Close();
                        }



                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Problemas de acceso a la BBDD", "Error");
                }
                repeticione++;
            }

            if (repeticione >5)
            {
                lb_uptime.Text = "uptime";
                lb_uptime.Hide();

                string qdel2 = "DELETE FROM hmda_uptime_peticiones WHERE nom_pc = '" + tb_principal_red.Text + "';";
                conn.Close();
                using (conn) // my connection string variable
                {
                    MySqlCommand cmd = new MySqlCommand(qdel2, conn);

                    conn.Open();

                    await cmd.ExecuteNonQueryAsync();

                    conn.Close();
                }

                this.Size = new Size(440, 180);
                Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
                this.Update();
                repeticione = 0;
            }

        }
         

            private async Task ping()
        {

            long ms;

            string ip = tb_principal_red.Text;
            Ping pingSender = new Ping();

            PingOptions options = new PingOptions();

            options.DontFragment = true;

            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 2500;            

            try
            {
                var reply = await pingSender.SendPingAsync(ip, timeout, buffer, options);


                total++;
                enviado++;
                a++;
                lb_pe.Text = total.ToString();
                if (reply.Status == IPStatus.Success)
                {

                    lb_pok.Text = (Convert.ToInt32(lb_pok.Text) + 1).ToString();
                    ms = reply.RoundtripTime;

                    lb_mss.Text = "ms= " + ms.ToString();
                    recibido++;
                    mss = mss + ms;

                    if (ms < min)
                    {
                        min = ms;
                    }
                    if (ms > max)
                    {
                        max = ms;
                    }


                    if (a >= 10)
                    {


                        for (int i = 0; i < 8; i++)
                        {
                            if (gf_ping.Series["Series"].Points[i + 1].Color == Color.DarkRed)
                            {

                                gf_ping.Series["Series"].Points[i].SetValueY(Convert.ToInt64(max / 2));
                                gf_ping.Series["Series"].Points[i].Label = "#Error";
                                gf_ping.Series["Series"].Points[i].Color = System.Drawing.Color.DarkRed;

                            }
                            else
                            {

                                gf_ping.Series["Series"].Points[i].SetValueY(Convert.ToInt64(gf_ping.Series["Series"].Points[i + 1].GetValueByName("y").ToString()));
                                gf_ping.Series["Series"].Points[i].Label = gf_ping.Series["Series"].Points[i + 1].GetValueByName("y").ToString();
                                gf_ping.Series["Series"].Points[i].Color = Color.Green;
                            }

                        }

                        /*
                        gf_ping.Series["Series"].Points[0].SetValueY(Convert.ToInt64(gf_ping.Series["Series"].Points[1].GetValueByName("y").ToString()));
                        gf_ping.Series["Series"].Points[1].SetValueY(Convert.ToInt64(gf_ping.Series["Series"].Points[2].GetValueByName("y").ToString()));
                        gf_ping.Series["Series"].Points[2].SetValueY(Convert.ToInt64(gf_ping.Series["Series"].Points[3].GetValueByName("y").ToString()));
                        gf_ping.Series["Series"].Points[3].SetValueY(Convert.ToInt64(gf_ping.Series["Series"].Points[4].GetValueByName("y").ToString()));
                        gf_ping.Series["Series"].Points[4].SetValueY(Convert.ToInt64(gf_ping.Series["Series"].Points[5].GetValueByName("y").ToString()));
                        gf_ping.Series["Series"].Points[5].SetValueY(Convert.ToInt64(gf_ping.Series["Series"].Points[6].GetValueByName("y").ToString()));
                        gf_ping.Series["Series"].Points[6].SetValueY(Convert.ToInt64(gf_ping.Series["Series"].Points[7].GetValueByName("y").ToString()));
                        gf_ping.Series["Series"].Points[7].SetValueY(Convert.ToInt64(gf_ping.Series["Series"].Points[8].GetValueByName("y").ToString()));
                        */

                        gf_ping.Series["Series"].Points[8].SetValueY(ms);
                        gf_ping.Series["Series"].Points[8].Color = Color.GreenYellow;
                        gf_ping.Series["Series"].Points[8].Label = ms.ToString();
                        gf_ping.Series["Series"].Points[8].LabelForeColor = Color.Black;

                    }
                    else
                    {
                        gf_ping.Series["Series"].Points.AddY(ms);

                        gf_ping.Series["Series"].Color = Color.Green;

                        

                        gf_ping.Series["Series"].LabelForeColor = Color.White;

                    }


                }
                else
                {
                    pingSender.Dispose();
                    lb_pf.Text = (Convert.ToInt32(lb_pf.Text) + 1).ToString();
                    ms = Convert.ToInt64(max / 2);
                    if (a >= 10)
                    {

                        for (int i = 0; i < 8; i++)
                        {
                            if (gf_ping.Series["Series"].Points[i + 1].Color == Color.DarkRed)
                            {

                                gf_ping.Series["Series"].Points[i].SetValueY(Convert.ToInt64(max / 2));
                                gf_ping.Series["Series"].Points[i].Label = "#Error";
                                gf_ping.Series["Series"].Points[i].Color = System.Drawing.Color.DarkRed;

                            }
                            else
                            {

                                gf_ping.Series["Series"].Points[i].SetValueY(Convert.ToInt64(gf_ping.Series["Series"].Points[i + 1].GetValueByName("y").ToString()));
                                gf_ping.Series["Series"].Points[i].Label = gf_ping.Series["Series"].Points[i + 1].GetValueByName("y").ToString();
                                gf_ping.Series["Series"].Points[i].Color = Color.Green;
                            }

                        }


                        gf_ping.Series["Series"].Points[8].SetValueY(ms);

                        gf_ping.Series["Series"].Points[8].Color = Color.DarkRed;
                        gf_ping.Series["Series"].Points[8].Label = "#Error";


                    }
                    else
                    {
                        gf_ping.Series["Series"].Points.AddY(ms);
                        gf_ping.Series["Series"].Points[gf_ping.Series["Series"].Points.Count - 1].Color = Color.DarkRed;
                        gf_ping.Series["Series"].Points[gf_ping.Series["Series"].Points.Count - 1].Label = "#Error";
                    }

                    cortes++;
                    perdido++;
                }
            }
            catch
            {
                tm_ping.Stop();
                //lb_ip.Text = "-";
                lb_mss.Text = "-";
                panel3.Hide();
                this.Size = new Size(440, 50);

            }

        }
        private void cargaIpNombre()
        {

            string nom = tb_principal_red.Text;


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
            string res2 = cmd2.StandardOutput.ReadToEnd();
            int id_res = res2.IndexOf("Nombre:");

            if (id_res == -1)
            {
                lb_ip.Text = "No AD";
                pictureBox9.Hide();
                this.Text = this.copiado;
            }
            else
            {
                string resultado = res2.Substring(id_res, res2.Length - id_res);


                int inicio = resultado.IndexOf("Nombre:") + 9;
                
                int fin = resultado.IndexOf("correo.local") - 1;

                int ip = resultado.IndexOf("Address:") + 10;

                string nombre = "";

                if (fin<0)
                {

                    nombre = resultado.Substring(inicio, (ip - 10) - inicio);
                    MessageBox.Show(nombre);
                }
                else
                {
                    nombre = resultado.Substring(inicio, fin - inicio);
                }
               


                tb_principal_red.Text = Regex.Replace(nombre, @"\s", "");


                lb_ip.Text = resultado.Substring(ip, resultado.Length - ip);

                this.Text = tb_principal_red.Text;
            }
            

        }

        

        




        ////
        ////////////////COPIAR ESTADISTICAS PING////////////////
        ////

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            int por = 0;
            long msst = 0;
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

            string ping_est = "Estadísticas de ping para  " + tb_principal_red.Text + " :" + Environment.NewLine + "Enviados = " + enviado + ", " + "Recibidos = " + recibido + ", " + "Perdidos = " + perdido + Environment.NewLine + "(" + por + "% Perdidos)" + Environment.NewLine + "Tiempos aproximados de ida y vuelta en milisegundos: " + Environment.NewLine + "Mínimo = " + min + "ms" + " ,  " + "Máximo = " + max + "ms" + " ,   " + "Media = " + msst + "ms";
            Clipboard.SetText(ping_est);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void conex_Paint(object sender, PaintEventArgs e)
        {

            PointF x1 = new PointF(0, 0);
            PointF x2 = new PointF(439, 0);
            PointF x3 = new PointF(0, 178);
            PointF x4 = new PointF(439, 178);

            Pen pen = new Pen(Color.White, 7);

            e.Graphics.DrawLine(pen, x1 ,x3);
            e.Graphics.DrawLine(pen, x2, x4);
            e.Graphics.DrawLine(pen, x3, x4);
            e.Graphics.DrawLine(pen, x1, x2);
        }

       

        private void lb_nombre_Click(object sender, EventArgs e)
        {
            string ip = lb_ip.Text;
            ip = ip.Substring(0, ip.IndexOf("\n"));
            Clipboard.SetText(ip.Trim());
        }

        public int xClick = 0, yClick = 0;
        private void gf_ping_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                yClick = e.Y;
                xClick = e.X;
            }
            else
            {
                this.Top = this.Top + (e.Y - yClick);
                this.Left = this.Left + (e.X - xClick);
            }
        }

        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox6.Size = new Size(35,35);
        }

        private void pictureBox6_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox6.Size = new Size(25, 25);
        }

        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox5.Size = new Size(35, 35);
        }

        private void pictureBox5_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox5.Size = new Size(25, 25);
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            string pc = "";
            if (lb_ip.Text != "No AD")
            {
                pc = lb_ip.Text;
                string target = "https://kc.correoargentino.com.ar/adminui/computer_inventory.php?LABEL_ID=&SEARCH_SELECTION_TEXT=10.254.63.48&SEARCH_SELECTION=" + pc;

                brawser bw = new brawser(target);
                bw.Show();
                /*
                try
                {
                    System.Diagnostics.Process.Start(target);
                }
                catch (System.ComponentModel.Win32Exception noBrowser)
                {
                    if (noBrowser.ErrorCode == -2147467259)
                        MessageBox.Show(noBrowser.Message);
                }
                catch (System.Exception other)
                {
                    MessageBox.Show(other.Message);
                }
                */

            }
           
           
        }

        private void habilitarBotonKaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.Default["kace"].ToString() == "False")
            {
                Settings.Default["kace"] = "True";
                Settings.Default.Save();
                pictureBox9.Show();
            }
            else
            {
                Settings.Default["kace"] = "False";
                Settings.Default.Save();
                pictureBox9.Hide();
            }
            
        }

        ////
        ////////////////SCAN MULTIPLES IP:::::////////////////
        ////
        private void pb_scan_Click(object sender, EventArgs e)
        {
            string ip;
            if (lb_ip.Text != "No AD")
            {
                ip = lb_ip.Text;
            }
            else
            {
                ip = tb_principal_red.Text;
            }
            scanIP scanIP = new scanIP(ip);
            scanIP.Show();
        }







        ////
        ////////////////Error: IP o NOMBRE No Valido////////////////
        ////




        ////
        ////////////////REMOTO: UBUNTU////////////////
        ////
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string user_dir = Settings.Default["user"].ToString();
            string path = "C:\\Users\\" + user_dir + "\\AppData\\Roaming\\vnc\\admin_2.vnc";



            string nom = tb_principal_red.Text;

            string comando = "[connection]" + Environment.NewLine +
                             "host=" + nom + Environment.NewLine +
                             "port=5901" + Environment.NewLine +
                             "username=" +Environment.NewLine +
                             "password=0c3be231e53046e6" + Environment.NewLine +
                             "proxyhost=" +Environment.NewLine +
                             "proxyport=0";

            byte[] bytes = Encoding.ASCII.GetBytes(comando);

            File.WriteAllBytes(path, bytes);

            

            Process cmd2 = new Process();
            cmd2.StartInfo.FileName = "cmd.exe";
            cmd2.StartInfo.RedirectStandardInput = true;
            cmd2.StartInfo.RedirectStandardOutput = true;
            cmd2.StartInfo.CreateNoWindow = true;
            cmd2.StartInfo.UseShellExecute = false;
            cmd2.Start();
            cmd2.StandardInput.WriteLine("\u0022" + "C:\\Users\\" + user_dir + "\\AppData\\Roaming\\vnc\\vncviewer" + "\u0022 /config \u0022" + path + "\u0022");
            cmd2.StandardInput.Flush();
            cmd2.StandardInput.Close();
        }




        ////
        ////////////////REMOTO WINDOWS////////////////
        ////
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_principal_red.Text))
            {
                tb_principal_red.BackColor = Color.Beige;
            }
            else
            {

                string nom = tb_principal_red.Text;

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

            }
        }

        ////
        ////////////////IMPRESORA POR NAVEGADOR////////////////
        ////
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (lb_ip.Text != "No AD" || lb_ip.Text != "IP")
            {
                string target = "http://" + lb_ip.Text + "/";
                brawser bw = new brawser(target);
                bw.Show();
            }
            else
            {
                string target = "http://" + tb_principal_red.Text + "/";
                brawser bw = new brawser(target);
                bw.Show();
            }
            
            /*
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
            */
           
        }

        ////
        ////////////////PUTTY SSH APERTURA////////////////
        ////
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string nom = tb_principal_red.Text;


            ProcessStartInfo cmd = new ProcessStartInfo();
            string user_dir = Settings.Default["user"].ToString();
            cmd.FileName = "C:\\Users\\" + user_dir + "\\AppData\\Roaming\\kitty\\kitty.exe";
            cmd.UseShellExecute = false;
            cmd.RedirectStandardInput = false;
            cmd.RedirectStandardOutput = true;
            cmd.Arguments = "-ssh mesa@" + nom + " 22 -pw mesadeayuda";
            Process process = Process.Start(cmd);

        }

        private void conex_FormClosed(object sender, FormClosedEventArgs e)
        {
            tm_ping.Stop();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            tm_ping.Stop();
        }

        ////
        ////////////////OCULTAR/CERRAR PANEL PING ////////////////
        ////

        private void pictureBox8_DoubleClick(object sender, EventArgs e)
        {
            if (panel3.Visible==true)
            {
                lb_pe.Text = "0";
                tm_ping.Stop();
                panel3.Hide();
                this.Size = new Size(440, 50);
            }
            else
            {
                this.Close();
            }
            
        }


        ////
        ////////////////UPTIMA PEDIDO SERVICIO ////////////////
        ////
        ///

        private void OnPaint(object sender, PaintEventArgs e)
        {
            PointF x1 = new PointF(0, 0);
            PointF x2 = new PointF(this.Width - 1, 0);
            PointF x3 = new PointF(0, this.Height-2);
            PointF x4 = new PointF(this.Width - 1, this.Height - 2);

            Pen pen = new Pen(Color.White, 7);

            e.Graphics.DrawLine(pen, x1, x3);
            e.Graphics.DrawLine(pen, x2, x4);
            e.Graphics.DrawLine(pen, x3, x4);
            e.Graphics.DrawLine(pen, x1, x2);
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {

            this.Size = new Size(440, 210);
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            this.Paint += this.OnPaint;
            this.Update();

            lb_uptime.Show();
            conn.Close();

            

            if (tb_principal_red.Text == "No AD")
            {
                MessageBox.Show("No se encuentra nombre(Verificar), o no es PC Windows","Error UpTime");
            }
            else
            {
                conn.Open();
                try
                {
                   
                    string query = "INSERT INTO hmda_uptime_peticiones(nom_pc, usuario, estado) VALUES ('" + tb_principal_red.Text + "', '" + Settings.Default["user"].ToString() + "', '" + false + "');";

                    MySqlCommand cmd2 = new MySqlCommand(query, conn);
                    cmd2.ExecuteNonQuery();
                    //MessageBox.Show("pediticón enviada: " + tb_principal_red.Text + "  " + Settings.Default["user"].ToString());
                    conn.Close();

                    lb_uptime.Text = "uptime...";
                    
                }
                catch (Exception)
                {

                    MessageBox.Show("Problemas de acceso a la BBDD", "Error");
                    conn.Close();
                }
            }
            
        }


    }
}
