using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySqlX.XDevAPI.Relational;
using DocumentFormat.OpenXml.Office2010.CustomUI;

namespace HMDA
{
    public partial class scanIP : Form
    {
        private string ip_red;
        int finalizado = 0;
        int cantidad = 0;

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
        public scanIP(string ip_red)
        {
            InitializeComponent();

            lblStatus.ForeColor = System.Drawing.Color.Red;
            
            lblStatus.Text = "En Espera";
            Control.CheckForIllegalCrossThreadCalls = false;
            this.ip_red = ip_red;

        }

        Thread myThread = null;
        Thread myThread2 = null;
        Thread myThread3 = null;
        Thread myThread4 = null;
        Thread myThread5 = null;


        private void scanIP_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            this.BackColor = Color.Black;
            this.Opacity = 0.90;

            string[] startIPString = ip_red.Split('.');
            int[] startIP = Array.ConvertAll<string, int>(startIPString, int.Parse);
            string ip_star = startIP[0] + "." + startIP[1] + "." + startIP[2] + "." + 1;
            string ip_fin = startIP[0] + "." + startIP[1] + "." + startIP[2] + "." + 255;

            scanearIP(ip_star, ip_fin);
        }

      
        private void scanearIP(string star, string fin)
        {
            //Catch empty IP addresses
            if (star == string.Empty)
            {
                //MessageBox.Show("No IP address entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "No se recibe IP.";
            }
            else
            {
                dG_scan.DataSource = null;
                dG_scan.Rows.Clear();

                //Create new thread for pinging
                //myThread = new Thread(() => scan(txtIP.Text));

                string[] startIPString = star.Split('.');
                int[] startIP = Array.ConvertAll<string, int>(startIPString, int.Parse); //Change string array to int array
                string[] endIPString = fin.Split('.');
                int[] endIP = Array.ConvertAll<string, int>(endIPString, int.Parse);

                int maxBar = endIP[3] - startIP[3];

                progressBar1.Maximum = maxBar + 1;
                progressBar1.Value = 0;


                string star1 = startIP[0] + "." + startIP[1] + "." + startIP[2] + "." + 1;
                string end1 = startIP[0] + "." + startIP[1] + "." + startIP[2] + "." + 49;

                string star2 = startIP[0] + "." + startIP[1] + "." + startIP[2] + "." + 50;
                string end2 = startIP[0] + "." + startIP[1] + "." + startIP[2] + "." + 100;

                string star3 = startIP[0] + "." + startIP[1] + "." + startIP[2] + "." + 101;
                string end3 = startIP[0] + "." + startIP[1] + "." + startIP[2] + "." + 152;

                string star4 = startIP[0] + "." + startIP[1] + "." + startIP[2] + "." + 153;
                string end4 = startIP[0] + "." + startIP[1] + "." + startIP[2] + "." + 204;

                string star5 = startIP[0] + "." + startIP[1] + "." + startIP[2] + "." + 205;
                string end5 = startIP[0] + "." + startIP[1] + "." + startIP[2] + "." + 255;

                myThread = new Thread(() => scan2(star1, end1));
                myThread.Start();

                myThread2 = new Thread(() => scan2(star2, end2));
                myThread2.Start();

                myThread3 = new Thread(() => scan2(star3, end3));
                myThread3.Start();

                myThread4 = new Thread(() => scan2(star4, end4));
                myThread4.Start();

                myThread5 = new Thread(() => scan2(star5, end5));
                myThread5.Start();
            }

        }

        public void scan2(string start, string end)
        {
            try
            {

                //Split IP string into a 4 part array
                string[] startIPString = start.Split('.');
                int[] startIP = Array.ConvertAll<string, int>(startIPString, int.Parse); //Change string array to int array
                string[] endIPString = end.Split('.');
                int[] endIP = Array.ConvertAll<string, int>(endIPString, int.Parse);
                int count = 0; //Count the number of successful pings
                Ping myPing;
                PingReply reply;
                IPAddress addr;
                IPHostEntry host;

                //Progress bar


                //Loops through the IP range, maxing out at 255
                for (int y = startIP[3]; y <= endIP[3]; y++)
                { //4th octet loop
                    string ipAddress = startIP[0] + "." + startIP[1] + "." + startIP[2] + "." + y; //Convert IP array back into a string
                    string endIPAddress = endIP[0] + "." + endIP[1] + "." + endIP[2] + "." + (endIP[3] + 1); // +1 is so that the scanning stops at the correct range

                    //If current IP matches final IP in range, break
                    if (ipAddress == endIPAddress)
                    {
                        break;
                    }


                    myPing = new Ping();
                    try
                    {
                        reply = myPing.Send(ipAddress, 500); //Ping IP address with 500ms timeout
                    }
                    catch (Exception)
                    {

                        break;
                    }


                    lblStatus.Text = "Scaneando: " + ipAddress;

                    //Log pinged IP address in listview
                    //Grabs DNS information to obtain system info
                    if (reply.Status == IPStatus.Success)
                    {
                        try
                        {
                            addr = IPAddress.Parse(ipAddress);
                            host = Dns.GetHostEntry(addr);

                            string nombre = host.HostName;
                            nombre = nombre.Replace(".correo.local", "");
                            if (cantidad>0)
                            {
                                dG_scan.Rows.Insert(0, ipAddress, nombre, "Activo", y);
                            }
                            else
                            {
                                dG_scan.Rows.Add(ipAddress, nombre, "Activo", y);
                            }
                           
                            count++;
                        }
                        catch (Exception)
                        {
                            if (cantidad > 0)
                            {
                                dG_scan.Rows.Insert(0, ipAddress, "No HostName", "Activo", y);
                            }
                            else
                            {
                                dG_scan.Rows.Add(ipAddress, "No HostName", "Activo", y);
                            }
                                
                            count++; 

                        }
                        if (dG_scan.Rows.Count < 14)
                        {
                            dG_scan.Height = dG_scan.Height + 22;
                            Size = new Size(this.Width, this.Height + 22);
                            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
                            
                        }

                        


                        cantidad++;
                    }
                    else
                    {
                        //listVAddr.Items.Add(new ListViewItem(new String[] { ipAddress, "n/a", "Down" })); //Log unsuccessful pings
                    }

                    progressBar1.Value += 1; //Increase progress bar
                    lb_cantidad.Text = "Equipos En Red: " + cantidad.ToString();
                }


                string[] ip_terminador = end.Split('.');
                int[] terminador = Array.ConvertAll<string, int>(endIPString, int.Parse);
                //Re-enable buttons

                dG_scan.Sort(dG_scan.Columns[3], ListSortDirection.Ascending);


                finalizado++;


                if (finalizado == 5)
                {
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    lblStatus.Text = "Finalizado!";
                    //MessageBox.Show("Escaneo Terminado!\nFound " + count + " hosts.", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                

                //Catch exception that throws when stopping thread, caused by ping waiting to be acknowledged
            }
            catch (ThreadAbortException tex)
            {
                Console.WriteLine(tex.StackTrace);
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Escaneo Detenido";
            }
            //Catch invalid IP types
            catch (Exception ex)
            {

                Console.WriteLine(ex.StackTrace);

                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Rango IP no Valido";
            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void scanIP_FormClosing(object sender, FormClosingEventArgs e)
        {
          

        }
        public int xClick = 0, yClick = 0;

       

        private void scanIP_MouseMove(object sender, MouseEventArgs e)
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
    }
}
