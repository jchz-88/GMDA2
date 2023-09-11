using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HMDA.pMenu.bus
{

    public partial class resBus : Form
    {
        int[] posY = { 4, 86, 168, 250 };
        

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


        /// ///BBDD CONEXIONES
        MySqlConnection conn = new MySqlConnection();


        private string dato;
        public resBus(string d)
        {
            
            dato = d;
            InitializeComponent();
        }

        private void resBus_Load(object sender, EventArgs e)
        {
            conn = conexiones.getInstancia().CrearConexion("gmda");

            this.Size = new Size(500, 340);

            gb_buscador_user.Visible= false;
            gb_buscador_paginas.Visible = false;
            gb_buscador_sitios.Visible = false;
            gb_buscador_titulos.Visible = false;
            lb_sin.Visible = false;

            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            this.BackColor = Color.Black;
            this.Opacity = 0.80;


            

            int barH = Screen.PrimaryScreen.WorkingArea.Height;
            int barW = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = new Point(barW / 2 - 250, barH / 2 - 350);


            cb_paginas.Items.Clear();
            cb_problema.Items.Clear();
            cb_sitios.Items.Clear();

            buscar();
        }

        private void buscar()
        {
            int f = 0;
            cargar_usuario();
            

            if (lb_user.Text == "X")
            {
                posicionar(gb_buscador_user, 0);
            }
            else
            {
                posicionar(gb_buscador_user, 1);
                f++;
            }

            cargar_titulos();
            
            
            if (cb_problema.Items.Count <= 0)
            {
                posicionar(gb_buscador_titulos, 0);
            }
            else
            {
                posicionar(gb_buscador_titulos, 1);
                f++;
            }

            cargar_pagina();
            
            
            if (cb_paginas.Items.Count <= 0)
            {
                posicionar(gb_buscador_paginas, 0);
            }
            else
            {
                posicionar(gb_buscador_paginas, 1);
                f++;
            }

            cargar_sitios();
           
           
            if (cb_sitios.Items.Count <= 0)
            {
                posicionar(gb_buscador_sitios, 0);
            }
            else
            {
                posicionar(gb_buscador_sitios, 1);
                f++;
            }

            if (f<1)
            {
                this.Size = new Size(500, 38);
                lb_sin.Visible = true;
                lb_sin.BringToFront();
                lb_sin.Location = new Point(lb_sin.Location.X, posY[0]);
                this.Activate();
                this.Activate();
            }
        }

        private void posicionar(Control x, int n)
        {
            int flag = 0;
            
            if (n==1)
            {
                

                x.Visible= true;

                if (gb_buscador_user.Visible == true)
                {
                    flag++;
                }
                if (gb_buscador_titulos.Visible == true)
                {
                    flag++;
                }
                if (gb_buscador_paginas.Visible == true)
                {
                    flag++;
                }
                if (gb_buscador_sitios.Visible == true)
                {
                    flag++;
                }

                x.Location = new Point(x.Location.X, posY[flag-1]);
                this.Activate();
            }
            else
            {
                this.Size = new Size(500, this.Height - 84);
                this.Activate();
            }

        }

        private void cargar_titulos()
        {
            string titulo;
            cb_problema.DataSource = null;
            
            titulo = dato;


            cb_problema.ValueMember = "desc_titulos";
            cb_problema.DisplayMember = "desc_titulos";
            string comando2 = "SELECT * FROM hmda_titulo_titulos WHERE desc_titulos LIKE '%" + titulo + "%'";
            cb_problema.DataSource = combo(comando2, 2);
            int cant = cb_problema.Items.Count;
            if (cant == 0)
            {
                cb_problema.Text = "No encotrado";
            }
            else
            {
                cb_problema.Text = "               " + cant + "  Titulos Encotrado";
                this.Focus();
            }
        }

        private void cb_problema_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string index = cb_problema.Text;
            lb_paracopiar.Text = index;
        }

        private void lb_paracopiar_TextChanged(object sender, EventArgs e)
        {
            Clipboard.SetText(cb_problema.SelectedValue.ToString());
        }



        private void cargar_pagina()
        {

            string paginas;
            cb_paginas.DataSource = null;
            
            paginas = dato;


            cb_paginas.DisplayMember = "url";
            cb_paginas.ValueMember = "pagina_nom";
            string comando2 = "SELECT id, pagina_nom, url FROM hmda_paginas WHERE url LIKE '%" + paginas + "%' or pagina_nom LIKE '%" + paginas + "%'";

            cb_paginas.DataSource = combo(comando2, 5);


            cb_paginas.SelectedIndex = cb_paginas.FindString(cb_paginas.Text);

        }

        private void cb_paginas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string index = cb_paginas.SelectedValue.ToString();

            Clipboard.SetText(index);
        }


        private void cargar_sitios()
        {
            
            string sitio;
            cb_sitios.DataSource = null;
            
            sitio = dato;

            cb_sitios.ValueMember = "NIS";
            cb_sitios.DisplayMember = "DENOMINACION";
            string comando2 = "SELECT * FROM hmda_sas WHERE DENOMINACION LIKE" + "'%" + sitio + "%' or NIS LIKE" + "'" + sitio + "'";
            cb_sitios.DataSource = combo(comando2, 3);
            cb_sitios.SelectedIndex = cb_sitios.FindString(cb_sitios.Text);

        }

        private void pb_user_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Clipboard.SetText(toolt_user.GetToolTip(pb_user));
        }

        private void cargar_usuario()
        {

            string resultado, user_s_valor, user_s2_valor, user_a_valor, camb_valor, ulti_valor, grupos_valor;

            string nom = dato;
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
            //cmd2.WaitForExit();

            string res = cmd2.StandardOutput.ReadToEnd();

            int largo = res.Length;

            int user_s = res.IndexOf("Nombre de usuario");

            int user_s2 = res.IndexOf("Nombre completo");

            int coment = res.IndexOf("Comentario");

            int user_a = res.IndexOf("Cuenta activa");
            int expi = res.IndexOf("La cuenta expira");

            int camb = res.IndexOf("Ultimo cambio de contrase");
            int contra = res.IndexOf("La contrase");


            int ulti = res.IndexOf("Ultima sesi");
            int ses = res.IndexOf("Horas de inicio de sesi");

            int grupos = res.IndexOf("Miembros del grupo global");
            int completado = res.IndexOf("Se ha completado");



            if (user_s > 0)
            {

                string user_lb = res.Substring(user_s2 + 43, coment - (user_s2 + 43));

                user_s_valor = res.Substring(user_s, user_s2 - user_s);
                user_s2_valor = res.Substring(user_s2, coment - user_s2);
                user_a_valor = res.Substring(user_a, expi - user_a);
                camb_valor = res.Substring(camb, contra - camb);
                ulti_valor = res.Substring(ulti, ses - ulti);
                grupos_valor = res.Substring(grupos, completado - grupos);



                resultado = string.Format(Environment.NewLine + user_s_valor + Environment.NewLine + user_s2_valor + Environment.NewLine + user_a_valor + Environment.NewLine + camb_valor + Environment.NewLine + ulti_valor + Environment.NewLine + grupos_valor);

                if (user_lb.Length>25)
                {
                    lb_user.Location = new Point(lb_user.Location.X, lb_user.Location.Y);
                }
                else if(user_lb.Length > 20)
                {
                    lb_user.Location = new Point(lb_user.Location.X + 5, lb_user.Location.Y);
                }
                else if (user_lb.Length > 15)
                {
                    lb_user.Location = new Point(lb_user.Location.X + 15, lb_user.Location.Y);
                }
                else
                {
                    lb_user.Location = new Point(lb_user.Location.X + 22, lb_user.Location.Y);
                }

                lb_user.Text = user_lb;

                
                cargar_tooltip(resultado);

            }
            else if (res.IndexOf("no se reconoce como un comando interno o externo") > 0)
            {

                lb_user.Text = "CMD->Path";
                toolt_user.SetToolTip(pb_user, "Debe configuar el Path en las Variables de Enterno" + Environment.NewLine + "CMD: setx Path C:\\Windows\\System32" + Environment.NewLine + "Barras simples, con la dirección entre comillas(CMD abierto desde System32)");


            }
            else
            {
                toolt_user.SetToolTip(pb_user, "Usuario Inexistente");
                lb_user.Text = "X";
            }

        }

        private void pb_user_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            Clipboard.SetText(toolt_user.GetToolTip(pb_user));
        }

        string toolT;
        private void cargar_tooltip(string res)
        {
            toolt_user.OwnerDraw = true;
            toolt_user.SetToolTip(pb_user, res);
            toolt_user.SetToolTip(lb_user, res);
            toolT = res;
        }


        public DataTable combo(string x, int y)
        {
            if (y == 5)
            {

                try
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    string cbox = x;
                    MySqlCommand cmd = new MySqlCommand(cbox, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    conn.Close();

                    return dt;
                }
                catch
                {
                    conn.Close();
                    MessageBox.Show("No hay conexión con el servidor que almacena los datos!!", "Error de Conexión", MessageBoxButtons.OK);
                    return null;
                }
            }
            else if (y == 2)
            {
                try
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    string cbox = x;
                    MySqlCommand cmd = new MySqlCommand(cbox, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    conn.Close();
                    return dt;
                }
                catch
                {
                    conn.Close();
                    MessageBox.Show("No hay conexión con el servidor que almacena los datos!!", "Error de Conexión", MessageBoxButtons.OK);
                    return null;
                }
            }
            else
            {
                try
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    string cbox = x;
                    MySqlCommand cmd = new MySqlCommand(cbox, conn);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    conn.Close();
                    return dt;

                }
                catch
                {
                    conn.Close();
                    MessageBox.Show("No hay conexión con el servidor que almacena los datos!!", "Error de Conexión", MessageBoxButtons.OK);
                    return null;
                }
            }


        }

        private void cb_sitios_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sitio = cb_sitios.SelectedValue.ToString();
            sitios sit = new sitios(sitio);
            sit.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        float toolt_size=0;
        private void toolt_user_Draw(object sender, DrawToolTipEventArgs e)
        {
            if (toolT.Length<2800) 
            {
                toolt_size = 14.0f;
            }
            else
            {
                toolt_size = 8.0f;
            }

            Font f = new Font("Arial Black", toolt_size);
            e.DrawBackground();
            e.DrawBorder();
            toolT = e.ToolTipText;
            e.Graphics.DrawString(e.ToolTipText, f, Brushes.Black, new PointF(2, 2));
        }

        private void toolt_user_Popup(object sender, PopupEventArgs e)
        {
            if (toolT.Length < 3000)
            {
                toolt_size = 14.0f;
            }
            else
            {
                toolt_size = 8.0f;
            }
            e.ToolTipSize = TextRenderer.MeasureText(toolT, new Font("Arial Black", toolt_size));
        }
    }
}
