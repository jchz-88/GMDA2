
using HMDA.Properties;
using Listas;
using Microsoft.Toolkit.Uwp.Notifications;
using ModuloAlertas;
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
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMDA.pMenu.menu_r
{
    public partial class HMDA : Form
    {
        //Conexión a BBDD de Titulos
        //static string conexion = "SERVER=10.254.63.48;PORT=3306;DATABASE=gmda;UID=jchz;PASSWORDS=;";
        MySqlConnection con = new MySqlConnection();

        DataGridView dg_clip;

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
       
        public HMDA(DataGridView x)
        {
            InitializeComponent();
            dg_clip = x;
        }

        private void submenu1_Load(object sender, EventArgs e)
        {
            con = conexiones.getInstancia().CrearConexion("gmda");

            int barW = Screen.PrimaryScreen.WorkingArea.Width;
            int barH = Screen.PrimaryScreen.WorkingArea.Height;

            this.Location = new Point(barW - (this.Width - bt_menu.Width) - 35, this.Location.Y);
            bt_menu2.Hide();
            bt_menu3.Hide();
            

            this.Activate();
            this.Focus();

            this.Opacity = 0.95;
            this.TopMost = true;

            this.Refresh();
            menu_principal(1);

            cargar_edits();

            btn_correo.Hide();
            btn_config.Hide();
            btn_alarmas.Hide();
            btn_plantilla.Hide();


            //tm_verificador.Start();

            
        }

       
        private void redondear(Control c)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(new Rectangle(4, 4, c.Width - 9, c.Height - 9));
            c.Region = new Region(gp);


        }

        private void redondear2(Control c)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(new Rectangle(2, 2, c.Width - 4, c.Height - 4));
            c.Region = new Region(gp);

        }

        private void redondear3(Control c)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(new Rectangle(5, 5, c.Width - 11, c.Height - 11));
            c.Region = new Region(gp);

        }

        private void menu_principal(int f)
        {
            
            GraphicsPath objDraw = new GraphicsPath();
            if (f==1)
            {
                objDraw.AddPie(316, 110, 50, 50, 0, 360);
            }
            else
            {
                objDraw.AddPie(302, 110, 50, 50, 0, 360);
            }
            
            this.BackColor = Color.Black;
            redondear2(bt_menu);
            this.Region = new Region(objDraw);

            int barW = Screen.PrimaryScreen.WorkingArea.Width;


            this.Location = new Point(barW - (this.Width - bt_menu.Width) -35, this.Location.Y);
            
        }

        private void menu_secundario()
        {
            GraphicsPath objDraw = new GraphicsPath();

                objDraw.AddPie(298, 110, 50, 50, 0, 360);

            objDraw.AddPie(294, 40, 53, 53, 0, 360);
            objDraw.AddPie(226, 71, 53, 53, 0, 360);
            objDraw.AddPie(226, 145, 53, 53, 0, 360);
            objDraw.AddPie(294, 180, 53, 53, 0, 360);

            objDraw.AddPie(267, 120, 27, 27, 0, 360);

            this.Region = new Region(objDraw);


            redondear3(btn_con);
            redondear3(btn_titu);
            redondear3(btn_corte);
            redondear3(bt_clip);

            redondear3(btn_correo);
            redondear3(btn_config);
            redondear3(btn_alarmas);
            redondear3(btn_plantilla);

            redondear2(bt_menu2);
        }

        private void menu_submenu()
        {
            int c = 11;
            GraphicsPath objDraw = new GraphicsPath();

            objDraw.AddPie(228, 110, 50, 50, 0, 360);

            objDraw.AddPie(0 + c, 1, 52, 52, 0, 360);
            objDraw.AddPie(0 + c, 55, 52, 52, 0, 360);
            objDraw.AddPie(0 + c, 109, 52, 52, 0, 360);
            objDraw.AddPie(0 + c, 163, 52, 52, 0, 360);
            objDraw.AddPie(0 + c, 217, 52, 52, 0, 360);
            objDraw.AddPie(54 + c, 27, 52, 52, 0, 360);
            objDraw.AddPie(54 + c, 81, 52, 52, 0, 360);
            objDraw.AddPie(54 + c, 135, 52, 52, 0, 360);
            objDraw.AddPie(54 + c, 187, 52, 52, 0, 360);
            objDraw.AddPie(108 + c, 55, 52, 52, 0, 360);
            objDraw.AddPie(108 + c, 109, 52, 52, 0, 360);
            objDraw.AddPie(108 + c, 163, 52, 52, 0, 360);
            objDraw.AddPie(162 + c, 83, 52, 52, 0, 360);
            objDraw.AddPie(162 + c, 137, 52, 52, 0, 360);

            this.Region = new Region(objDraw);

            redondear(bt_a1);
            redondear(bt_a2);
            redondear(bt_a3);
            redondear(bt_a4);
            redondear(bt_a5);
            redondear(bt_a6);
            redondear(bt_h1);
            redondear(bt_h2);
            redondear(bt_h3);
            redondear(bt_tsu);
            redondear(bt_hda);
            redondear(bt_edit1);
            redondear(bt_edit2);
            redondear(bt_edit3);

            redondear2(bt_menu3);

            this.Location = new Point(this.Location.X + 70, this.Location.Y);
        }

        private void submenu1_Deactivate(object sender, EventArgs e)
        {
            bt_menu.Show();
            bt_menu.BringToFront();
            bt_menu2.Hide();
            bt_menu3.Hide();
            btn_corte.Show();
            btn_titu.Show();
            this.Location = new Point(this.Location.X - 70, this.Location.Y);
            this.Refresh();
            menu_principal(1);
        }

        private void bt_menu_MouseUp(object sender, MouseEventArgs e)
        {
            int flag = 0;

            if ((top <= top1 + 2 && top >= top1 - 2) || top == 0)
            {
               
                if (flag==0)
                {
                
                    bt_menu.Hide();
                    bt_menu2.Show();
                    bt_menu2.BringToFront();
                    bt_menu.Location = new Point(bt_menu.Location.X + 14, bt_menu.Location.Y);
                    this.Refresh();

                    btn_correo.Hide();
                    btn_config.Hide();
                    btn_alarmas.Hide();
                    btn_plantilla.Hide();
                    btn_con.Show();
                    bt_clip.Show();
                    btn_corte.Show();
                    btn_titu.Show();
                    pb_option1.Show();
                    menu_secundario();
                }
                
            }
            else
            {
                top1 = this.Location.Y;
            }
            
        }

        private void bt_menu_MouseEnter(object sender, EventArgs e)
        {

            int barW = Screen.PrimaryScreen.WorkingArea.Width;

            

            if (bt_menu.Location.X == (this.Width - bt_menu.Width) - 2)
            {
                bt_menu.Location = new Point(bt_menu.Location.X - 14, bt_menu.Location.Y);

              
                
                menu_principal(0);
            }
        }

        private void bt_menu_MouseLeave(object sender, EventArgs e)
        {
            int barW = Screen.PrimaryScreen.WorkingArea.Width;

            if (bt_menu.Location.X == ((this.Width - bt_menu.Width)-2) - 14)
            {
                if (bt_menu.Visible == true)
                {
                    bt_menu.Location = new Point(bt_menu.Location.X + 14, bt_menu.Location.Y);
                   
                    menu_principal(1);
                }
                
            }
        }

        private void bt_menu2_MouseUp(object sender, MouseEventArgs e)
        {
            if ((top <= top1 + 2 && top >= top1 - 2) || top == 0)
            {
                bt_menu.Hide();
                bt_menu2.Hide();
                bt_menu3.BringToFront();
                bt_menu3.Show();
                btn_corte.Hide();
                btn_titu.Hide();
                btn_config.Hide();
                btn_alarmas.Hide();
                pb_option1.Hide();   
                this.Refresh();
                menu_submenu();
            }
            else
            {
                top1 = this.Location.Y;
            }
        }

        private void bt_menu3_MouseUp(object sender, MouseEventArgs e)
        {
            if ((top <= top1 + 2 && top >= top1 - 2) || top == 0)
            {
                bt_menu.Show();
                bt_menu.BringToFront();
                bt_menu2.Hide();
                bt_menu3.Hide();
                btn_corte.Show();
                btn_titu.Show();
                this.Location = new Point(this.Location.X - 70, this.Location.Y);
                this.Refresh();
                menu_principal(1);
            }
            else
            {
                top1 = this.Location.Y;
            }
        }

        public int top, top1, yClick = 0;



        /// <summary>
        /// MODULO: Conexión
        /// </summary>

        private void bt_con_Click(object sender, EventArgs e)
        {
            string copiado = Clipboard.GetText();

            Ping Pings = new Ping();
            int timeout = 10;

            try
            {
                Pings.Send(copiado, timeout);

                conex frm1 = new conex(copiado);
                frm1.Show();

            }
            catch (Exception)
            {
                conex frm1 = new conex(" ");
                frm1.Show();
            }

        }

        /// <summary>
        /// MODULO: ClipBoard
        /// </summary>
        /// 
        int flag_clip = 0;
        F_Cpliboard frm2;
        private void bt_clip_Click(object sender, EventArgs e)
        {
            flag_clip = 0;

            foreach (Form fmr in Application.OpenForms)
            {
                if (fmr.Name == "F_Cpliboard")
                {
                    flag_clip = 1;
                }
            }
            abrir_formClip();
        }

        private void abrir_formClip()
        {
            if (flag_clip == 1)
            {

                frm2.Close();
                frm2 = null;
            }
            else
            {
                frm2 = new F_Cpliboard();

                frm2.clips.Clear();

                int cant = dg_clip.RowCount - 1;

                for (int i = 0; i < cant; i++)
                {
                    frm2.clips.Add(dg_clip.Rows[i].Cells[0].Value.ToString());
                }

                frm2.Show();
            }
        }
        /// <summary>
        /// MODULO: Accesos Directos
        /// </summary>
        
        private void bt_hda_Click(object sender, EventArgs e)
        {
            ProcessStartInfo cmd = new ProcessStartInfo();
            string user_dir = Settings.Default["user"].ToString();
            cmd.FileName = "C:\\Users\\" + user_dir + "\\AppData\\Roaming\\kitty\\kitty.exe";
            cmd.UseShellExecute = false;
            cmd.RedirectStandardInput = false;
            cmd.RedirectStandardOutput = true;
            cmd.Arguments = "-load HDAACHAV";
            Process process = Process.Start(cmd);
        }

        private void bt_tsu_Click(object sender, EventArgs e)
        {
            ProcessStartInfo cmd = new ProcessStartInfo();
            string user_dir = Settings.Default["user"].ToString();
            cmd.FileName = "C:\\Users\\" + user_dir + "\\AppData\\Roaming\\kitty\\kitty.exe";
            cmd.UseShellExecute = false;
            cmd.RedirectStandardInput = false;
            cmd.RedirectStandardOutput = true;
            cmd.Arguments = "-load TSUNAMI";
            Process process = Process.Start(cmd);
        }

        private void bt_h2_Click(object sender, EventArgs e)
        {
            ProcessStartInfo cmd = new ProcessStartInfo();
            string user_dir = Settings.Default["user"].ToString();
            cmd.FileName = "C:\\Users\\" + user_dir + "\\AppData\\Roaming\\kitty\\kitty.exe";
            cmd.UseShellExecute = false;
            cmd.RedirectStandardInput = false;
            cmd.RedirectStandardOutput = true;
            cmd.Arguments = "-load HOSTAA40073B";
            Process process = Process.Start(cmd);
        }

        private void bt_h3_Click(object sender, EventArgs e)
        {
            ProcessStartInfo cmd = new ProcessStartInfo();
            string user_dir = Settings.Default["user"].ToString();
            cmd.FileName = "C:\\Users\\" + user_dir + "\\AppData\\Roaming\\kitty\\kitty.exe";
            cmd.UseShellExecute = false;
            cmd.RedirectStandardInput = false;
            cmd.RedirectStandardOutput = true;
            cmd.Arguments = "-load HOSTAA40077B";
            Process process = Process.Start(cmd);
        }

        private void bt_h1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo cmd = new ProcessStartInfo();
            string user_dir = Settings.Default["user"].ToString();
            cmd.FileName = "C:\\Users\\" + user_dir + "\\AppData\\Roaming\\kitty\\kitty.exe";
            cmd.UseShellExecute = false;
            cmd.RedirectStandardInput = false;
            cmd.RedirectStandardOutput = true;
            cmd.Arguments = "-load HOSTCTS0459B";
            Process process = Process.Start(cmd);
        }

        private void bt_a4_Click(object sender, EventArgs e)
        {

            string target = "https://www.office.com/?auth=2&home=1";

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
        }

        private void bt_a1_Click(object sender, EventArgs e)
        {

            string target = "https://sm.correoargentino.com.ar/index.do";

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
        }

        private void bt_a5_Click(object sender, EventArgs e)
        {
            string target = "https://portal.azure.com/#home";

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
        }

        private void bt_a2_Click(object sender, EventArgs e)
        {
            string target = "https://soti.correoargentino.com.ar/MobiControl/oauth/logon";

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
        }

        private void bt_a6_Click(object sender, EventArgs e)
        {
            string target = "https://admin.exchange.microsoft.com/#/";

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
        }

        private void bt_a3_Click(object sender, EventArgs e)
        {
            string target = "https://webclientes.canaldirecto.com.ar/users/login";

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
        }




        /// <summary>
        /// MONUDLO: Contex Menu Strip
        /// </summary>


        private void tt_edit_tb_mostrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Control c = menu_edit_acc.SourceControl as Control;
                if (c.Name == bt_edit1.Name)
                {
                    Settings.Default["bt_edit1_nombre"] = tt_edit_tb_mostrar.Text;
                    Settings.Default.Save();
                }
                else if (c.Name == bt_edit2.Name)
                {
                    Settings.Default["bt_edit2_nombre"] = tt_edit_tb_mostrar.Text;
                    Settings.Default.Save();
                }
                else
                {
                    Settings.Default["bt_edit3_nombre"] = tt_edit_tb_mostrar.Text;
                    Settings.Default.Save();
                }
                edit_tt_tb_nombre.Text = "";
                menu_edit_acc.Close();
                cargar_edits();

            }
            
        }
        private void edit_tt_tb_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Control c = menu_edit_acc.SourceControl as Control;
                if (c.Name == bt_edit1.Name)
                {
                    Settings.Default["bt_edit1_nomreal"] = edit_tt_tb_nombre.Text;
                    Settings.Default.Save();
                }
                else if (c.Name == bt_edit2.Name)
                {
                    Settings.Default["bt_edit2_nomreal"] = edit_tt_tb_nombre.Text;
                    Settings.Default.Save();
                }
                else
                {
                    Settings.Default["bt_edit3_nomreal"] = edit_tt_tb_nombre.Text;
                    Settings.Default.Save();
                }
                edit_tt_tb_nombre.Text = "";
                menu_edit_acc.Close();
                cargar_edits();

            }
            
        }


        private void edit_tt_tb_url_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                llenar_enlace(1);
            }
        }

        private void toolStripTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                llenar_enlace(0);
            }
        }

        void llenar_enlace(int f)
        {
            Control c = menu_edit_acc.SourceControl as Control;
            if (f==1)
            {
                if (c.Name == bt_edit1.Name)
                {
                    Settings.Default["bt_edit1_enlace"] = edit_tt_tb_url.Text + ";1";
                    Settings.Default.Save();
                }
                else if (c.Name == bt_edit2.Name)
                {
                    Settings.Default["bt_edit2_enlace"] = edit_tt_tb_url.Text + ";1";
                    Settings.Default.Save();
                }
                else
                {
                    Settings.Default["bt_edit3_enlace"] = edit_tt_tb_url.Text + ";1";
                    Settings.Default.Save();
                }
                edit_tt_tb_url.Text = "";
                
            }
            else
            {
                if (c.Name == bt_edit1.Name)
                {
                    Settings.Default["bt_edit1_enlace"] = edit_tt_tb_enlace.Text + ";0";
                    Settings.Default.Save();
                }
                else if (c.Name == bt_edit2.Name)
                {
                    Settings.Default["bt_edit2_enlace"] = edit_tt_tb_enlace.Text + ";0";
                    Settings.Default.Save();
                }
                else
                {
                    Settings.Default["bt_edit3_enlace"] = edit_tt_tb_enlace.Text + ";0";
                    Settings.Default.Save();
                }
                edit_tt_tb_enlace.Text = "";
                
            }
            menu_edit_acc.Close();
            cargar_edits();
        }

        private void cambiarColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorbg = new ColorDialog();
            
            if (colorbg.ShowDialog() == DialogResult.OK)
            {
                Control c = menu_edit_acc.SourceControl as Control;
                if (c.Name == bt_edit1.Name)
                {
                    Settings.Default["bt_edit1_color"] = colorbg.Color;
                    Settings.Default.Save();
                }
                else if (c.Name == bt_edit2.Name)
                {
                    Settings.Default["bt_edit2_color"] = colorbg.Color;
                    Settings.Default.Save();
                }
                else
                {
                    Settings.Default["bt_edit3_color"] = colorbg.Color;
                    Settings.Default.Save();
                }
                
            }
            menu_edit_acc.Close();
            cargar_edits();
        }


        private void colorFuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorbg = new ColorDialog();

            if (colorbg.ShowDialog() == DialogResult.OK)
            {
                Control c = menu_edit_acc.SourceControl as Control;
                if (c.Name == bt_edit1.Name)
                {
                    Settings.Default["bt_edit1_Fcolor"] = colorbg.Color;
                    Settings.Default.Save();
                }
                else if (c.Name == bt_edit2.Name)
                {
                    Settings.Default["bt_edit2_Fcolor"] = colorbg.Color;
                    Settings.Default.Save();
                }
                else
                {
                    Settings.Default["bt_edit3_Fcolor"] = colorbg.Color;
                    Settings.Default.Save();
                }

            }
            menu_edit_acc.Close();
            cargar_edits();
        }


        private void bt_edit1_Click(object sender, EventArgs e)
        {

            string target = "https://login.wcx.cloud/Azure/Index/d1bc960101684a1cbeef7574329fc2e5";

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

            /*
            string enlace = Settings.Default["bt_edit1_enlace"].ToString();
            string f = enlace.Substring(enlace.Length - 1, 1);
            string real= enlace.Substring(0, enlace.Length - 2);

            if (f== "1")
            {

                try
                {
                    System.Diagnostics.Process.Start(real);
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
            }
            else
            {
                real = real.Replace("\'", "\\");

                ProcessStartInfo info = new ProcessStartInfo();

                info.UseShellExecute = true;
                info.FileName = Settings.Default["bt_edit3_nomreal"].ToString() + ".exe";
                info.WorkingDirectory = real;

                Process.Start(info);
            }
            */
        }


        private void bt_edit2_Click(object sender, EventArgs e)
        {
            string enlace = Settings.Default["bt_edit2_enlace"].ToString();
            string f = enlace.Substring(enlace.Length - 1, 1);
            string real = enlace.Substring(0, enlace.Length - 2);

            if (f == "1")
            {

                try
                {
                    System.Diagnostics.Process.Start(real);
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
            }
            else
            {
                real = real.Replace("\'", "\\");

                ProcessStartInfo info = new ProcessStartInfo();

                info.UseShellExecute = true;
                info.FileName = Settings.Default["bt_edit3_nomreal"].ToString() + ".exe";
                info.WorkingDirectory = real;
                try
                {
                    Process.Start(info);
                }
                catch (Exception)
                {

                    MessageBox.Show("Archivo No Encontrado!!");
                }
                

            }
        }

        private void bt_edit3_Click(object sender, EventArgs e)
        {
            string enlace = Settings.Default["bt_edit3_enlace"].ToString();
            string f = enlace.Substring(enlace.Length - 1, 1);
            string real = enlace.Substring(0, enlace.Length - 2);

            if (f == "1")
            {

                try
                {
                    System.Diagnostics.Process.Start(real);
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
            }
            else
            {
                real = real.Replace("\'", "\\");

                ProcessStartInfo info = new ProcessStartInfo();

                info.UseShellExecute = true;
                info.FileName = Settings.Default["bt_edit3_nomreal"].ToString() + ".exe";
                info.WorkingDirectory = real;

                Process.Start(info);

            }
        }

        string  edit2, edit3;

       

        void cargar_edits()
        {

            bt_edit2.Text = Settings.Default["bt_edit2_nombre"].ToString();
            bt_edit3.Text = Settings.Default["bt_edit3_nombre"].ToString();


            edit2 = Settings.Default["bt_edit2_enlace"].ToString();
            edit3 = Settings.Default["bt_edit3_enlace"].ToString();


            bt_edit2.BackColor = (Color)Settings.Default["bt_edit2_color"];
            bt_edit3.BackColor = (Color)Settings.Default["bt_edit3_color"];

            bt_edit2.ForeColor = (Color)Settings.Default["bt_edit2_Fcolor"];
            bt_edit3.ForeColor = (Color)Settings.Default["bt_edit3_Fcolor"];

            
        }


        private void menu_edit_acc_Opening(object sender, CancelEventArgs e)
        {
            menu_edit_acc.Items[0].Text = "Acceso Directo";
            menu_edit_acc.Items[1].BackColor = Color.Transparent;
            colorFuenteToolStripMenuItem.ForeColor = Color.Black;
            menu_edit_acc.Items[2].Text = "Nombre (Cambiar)";
            

            Control c = menu_edit_acc.SourceControl as Control;
            if (c.Name == bt_edit2.Name)
            {
                menu_edit_acc.Items[0].Text = menu_edit_acc.Items[0].Text + "  '" + Settings.Default["bt_edit2_enlace"].ToString() + "'";
                menu_edit_acc.Items[1].BackColor = (Color)Settings.Default["bt_edit2_color"];
                colorFuenteToolStripMenuItem.ForeColor = (Color)Settings.Default["bt_edit2_Fcolor"];
                menu_edit_acc.Items[2].Text = menu_edit_acc.Items[2].Text + "  '" + Settings.Default["bt_edit2_nombre"].ToString() + "'";

                edit_tt_tb_nombre.Text = Settings.Default["bt_edit2_nomreal"].ToString();
                tt_edit_tb_mostrar.Text = Settings.Default["bt_edit2_nombre"].ToString();

            }
            else
            {
                menu_edit_acc.Items[0].Text = menu_edit_acc.Items[0].Text + "  '" + Settings.Default["bt_edit3_enlace"].ToString() + "'";
                menu_edit_acc.Items[1].BackColor = (Color)Settings.Default["bt_edit3_color"];
                colorFuenteToolStripMenuItem.ForeColor = (Color)Settings.Default["bt_edit3_Fcolor"];
                menu_edit_acc.Items[2].Text = menu_edit_acc.Items[2].Text + "  '" + Settings.Default["bt_edit3_nombre"].ToString() + "'";

                edit_tt_tb_nombre.Text = Settings.Default["bt_edit3_nomreal"].ToString();
                tt_edit_tb_mostrar.Text = Settings.Default["bt_edit3_nombre"].ToString();

            }
        }

        private void pb_option_Click(object sender, EventArgs e)
        {
            if (btn_con.Visible == true)
            {
                pb_option1.Hide();
                bt_option2.Show();

                btn_correo.Show();
                btn_config.Show();
                btn_alarmas.Show();
                btn_plantilla.Show();

                btn_con.Hide();
                bt_clip.Hide();
                btn_corte.Hide();
                btn_titu.Hide();
            }
            else
            {
                pb_option1.Show();
                bt_option2.Hide();

                btn_correo.Hide();
                btn_config.Hide();
                btn_alarmas.Hide();
                btn_plantilla.Hide();

                btn_con.Show();
                bt_clip.Show();
                btn_corte.Show();
                btn_titu.Show();
            }

            
        }

        private void bt_option2_Click(object sender, EventArgs e)
        {
            if (btn_con.Visible == true)
            {
                pb_option1.Hide();
                bt_option2.Show();

                btn_correo.Show();
                btn_config.Show();
                btn_alarmas.Show();
                btn_plantilla.Show();

                btn_con.Hide();
                bt_clip.Hide();
                btn_corte.Hide();
                btn_titu.Hide();
            }
            else
            {
                pb_option1.Show();
                bt_option2.Hide();

                btn_correo.Hide();
                btn_config.Hide();
                btn_alarmas.Hide();
                btn_plantilla.Hide();

                btn_con.Show();
                bt_clip.Show();
                btn_corte.Show();
                btn_titu.Show();
            }
        }

        /// <summary>
        /// MODULO: Plantillas
        /// </summary>
        private void btn_plantilla_Click(object sender, EventArgs e)
        {
            bus.plantillas plan = new bus.plantillas();
            plan.Show();
        }

       

       

        /// <summary>
        /// MODULO: Mouse Move
        /// </summary>




        private void bt_menu_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                yClick = e.Y;
            }
            else
            {
                this.Top = this.Top + (e.Y - yClick);
            }
            top = this.Top;
        }

        private void bt_menu2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                yClick = e.Y;
            }
            else
            {
                this.Top = this.Top + (e.Y - yClick);
            }
            top = this.Top;
        }
        private void bt_menu3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                yClick = e.Y;
            }
            else
            {
                this.Top = this.Top + (e.Y - yClick);
            }
            top = this.Top;
        }

        /// <summary>
        ///  MODULO: Titulos
        /// </summary>
        private void bt_titu_Click(object sender, EventArgs e)
        {

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(titulos))
                {
                    frm.Close();
                    break;
                }

            }

            titulos titu = new titulos();
            titu.Show();
        }

       

        /// <summary>
        ///  MODULO: Alertas
        /// </summary>
        /// 
        private void btn_alarmas_Click(object sender, EventArgs e)
        {
            //Form1 alert = new Form1();
            //alert.Show();
        }

        private void btn_correo_Click(object sender, EventArgs e)
        {
            Listas.correo correo = new Listas.correo();
            correo.Show();
        }

        private void btn_con_Click(object sender, EventArgs e)
        {

            string copiado = Clipboard.GetText();

            Ping Pings = new Ping();
            int timeout = 10;

            try
            {
                Pings.Send(copiado, timeout);

                conex frm1 = new conex(copiado);
                frm1.Show();

            }
            catch (Exception)
            {
                conex frm1 = new conex(" ");
                frm1.Show();
            }


        }

        private void btn_corte_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{PRTSC}");

        }

        private void btn_config_Click(object sender, EventArgs e)
        {
            menu_r.config cf = new config();
            cf.Show();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void tm_verificador_Tick(object sender, EventArgs e)
        {
            try
            {
                con.Close();
                con.Open();
                string cbox = "SELECT alerta_comunicados.urgente AS urgente, alerta_comunicados.link AS link, alerta_comunicados.titulo AS titulo, alerta_comunicados.contenido AS contenido, alerta_comunicados.id AS id, alerta_comunicados.tipo AS tipo FROM alerta_comunicados LEFT JOIN alerta_alertavistas ON alerta_comunicados.id = alerta_alertavistas.id_alerta WHERE alerta_alertavistas.id_alerta IS NULL;";

                MySqlDataAdapter datatable = new MySqlDataAdapter(cbox, con);
                DataTable dt = new DataTable();

                datatable.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow reg in dt.Rows)
                    {
                        mostrar_alerta((int)reg["id"], reg["tipo"].ToString(), reg["titulo"].ToString(), reg["contenido"].ToString(), reg["link"].ToString(), (int)reg["urgente"]);
                    }
                }
                con.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Problemas de conexión con el servidor");
            }
        }

        private void mostrar_alerta(int id, string tipo, string titulo, string contenido, string link, int urgente)
        {
            new ToastContentBuilder()

             .AddArgument("action", "viewConversation")
             .AddArgument("conversationId", 9813)
             .AddHeader("9813", tipo + "!!", "action=openConversation&id=9813")
             .AddAppLogoOverride(new Uri("C:\\Users\\zextjchavez\\Documents\\logo.png"), ToastGenericAppLogoCrop.Circle)
             .AddText(titulo + "!!!", hintMaxLines: 1, hintAlign: AdaptiveTextAlign.Center)
             .AddText("\r")
             .AddText(contenido)

             .AddButton(new ToastButton().SetContent("Mas Detalles").AddArgument("action", "archive"))
             .SetToastDuration(ToastDuration.Short)
             .Show();

            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                if (link != "")
                {
                    Process.Start(link);
                    vistas(id, tipo);
                }
                else
                {
                    Form1 alert = new Form1();
                    alert.Show();

                }

            };

            if (urgente == 1)
            {
                banner bn = new banner(contenido);
                bn.Show();

            }
            else
            {
                vistas(id, tipo);
            }

        }

        private bool vistas(int id, string tipo)
        {
            bool resultado = false;

            con.Close();
            try
            {
                con.Open();

                string cbox = "SELECT * FROM alerta_alertavistas WHERE tipo = '" + tipo + "' AND id_alerta =" + id + " AND usuario = '" + Environment.UserName + "' ;";



                MySqlDataAdapter datatable = new MySqlDataAdapter(cbox, con);
                DataTable dt = new DataTable();

                con.Close();

                datatable.Fill(dt);
                int filas = dt.Rows.Count;
                if (filas > 0)
                {
                    foreach (DataRow reg in dt.Rows)
                    {
                        if ((int)reg["estado"] == 0)
                        {
                            resultado = false;
                            break;
                        }
                        else
                        {
                            resultado = true;
                            break;
                        }

                    }
                }
                else
                {
                    con.Open();


                    string query = "INSERT INTO alerta_alertavistas(id_alerta, usuario, estado, tipo) VALUES (" + id + ", '" + Environment.UserName + "' ," + 0 + ", '" + tipo + "');";
                    MySqlCommand cmd2 = new MySqlCommand(query, con);
                    cmd2.ExecuteNonQuery();
                    con.Clone();
                    resultado = false;
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Problemas con la conexión");

            }

            if (resultado)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void submenu1_FormClosed(object sender, FormClosedEventArgs e)
        {
            tm_verificador.Stop();
            Application.Exit();
        }
    }
}

