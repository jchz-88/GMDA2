using Microsoft.Graph.Models.ExternalConnectors;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMDA.pMenu.menu_r
{
    public partial class titulos : Form
    {
        //static string conexion = "SERVER=10.254.63.48;PORT=3306;DATABASE=titulos;UID=jchz;PASSWORDS=;";
        MySqlConnection con = new MySqlConnection();

        bool titulo_v = false;

        int barW = Screen.PrimaryScreen.WorkingArea.Width;
        public titulos()
        {
            InitializeComponent();
        }

        private void titulos_Load(object sender, EventArgs e)
        {
            con = conexiones.getInstancia().CrearConexion("gmda");

            this.BackColor = Color.Black;
            this.Opacity = 0.85;
            

            this.Location = new Point(barW - (this.Width) - 5, HMDA.ActiveForm.Location.Y + 120);


            menu_principal(0);

            pb_option.Show();

            pb_fijado.Hide();

            this.cb_problema.DrawMode = DrawMode.OwnerDrawFixed;
            this.cb_problema.DrawItem += new DrawItemEventHandler(cb_problema_DrawItem);
        }

        void menu_principal(int f)
        {
            GraphicsPath objDraw = new GraphicsPath();

            
            
            if (f == 1)
            {
                
                objDraw.AddPie(1, 1, 41, 41, 0, 360);
                objDraw.AddPie(46, 1, 41, 41, 0, 360);
                objDraw.AddPie(92, 1, 41, 41, 0, 360);
                objDraw.AddPie(138, 1, 41, 41, 0, 360);
                objDraw.AddPie(184, 1, 41, 41, 0, 360);
                objDraw.AddPie(230, 1, 41, 41, 0, 360);


                objDraw.AddPie(156, 42, 27, 27, 0, 360);
                objDraw.AddPie(185, 42, 28, 28, 0, 360);
                objDraw.AddPie(214, 42, 28, 28, 0, 360);
                activo = 1;
            }
            else
            {
                activo = 0;

                if (titulo_v)
                {
                    objDraw.AddPie(1, 1, 41, 41, 0, 360);
                    objDraw.AddPie(46, 1, 41, 41, 0, 360);
                    objDraw.AddPie(92, 1, 41, 41, 0, 360);
                    objDraw.AddPie(138, 1, 41, 41, 0, 360);
                    objDraw.AddPie(184, 1, 41, 41, 0, 360);
                    objDraw.AddPie(230, 1, 41, 41, 0, 360);
                    
                }

            }


            objDraw.AddPie(243, 42, 27, 27, 0, 360);

            objDraw.AddRectangle(new Rectangle(-1, 71, this.Width+1, 31));

            
            objDraw.AddRectangle(new Rectangle(-1, 103, this.Width+1, 31));


            this.Region = new Region(objDraw);
            
        }


     

        private void pb_option_MouseEnter_1(object sender, EventArgs e)
        {
            if (activo == 0)
            {
                
                menu_principal(1);

            }
            else
            {
                
                menu_principal(0);
            }
            
            
        }

      
      


        public int activo=0, top, top1, yClick = 0;


        private void pb_option_MouseMove_1(object sender, MouseEventArgs e)
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
      

      

        private void pb_fijar_Click_1(object sender, EventArgs e)
        {
            this.TopMost = true;
            pb_fijar.Hide();
            pb_fijado.Show();
            pb_option.Show();
            menu_principal(0);
            
        }

       
        private void pb_close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pb_fijado_Click_1(object sender, EventArgs e)
        {
            this.TopMost = false;
            pb_fijado.Hide();
            pb_fijar.Show();
            pb_option.Show();
            menu_principal(0);
        }


        ///////
        ///MODULO: Carga de Titulos
        //////
        private void cb_problema_DrawItem(object sender, DrawItemEventArgs e)
        {
            string text = this.cb_problema.GetItemText(cb_problema.Items[e.Index]);
            e.DrawBackground();
            using (SolidBrush br = new SolidBrush(e.ForeColor))
            { e.Graphics.DrawString(text, e.Font, br, e.Bounds); }

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            { this.toolTip1.Show(text, cb_problema, e.Bounds.Right, e.Bounds.Bottom); }
            else { this.toolTip1.Hide(cb_problema); }
            e.DrawFocusRectangle();
        }

        private void cb_problema_DropDownClosed(object sender, EventArgs e)
        {
            this.toolTip1.Hide(cb_problema);
        }


        private void pictureBox23_Click(object sender, EventArgs e)
        {
            cargaboxci(2);
            menu_principal(0);
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            cargaboxci(3);
            menu_principal(0);
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            cargaboxci(1);
            menu_principal(0);
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            cargaboxci(6);
            menu_principal(0);
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            cargaboxci(4);
            menu_principal(0);
        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {
            cargaboxci(5);
            menu_principal(0);
        }

        private void cb_problema_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //string index = cb_problema.Text;
            //lb_paracopiar.Text = index;
        }

        private void cb_problema_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string titulo;
                cb_problema.DataSource = null;
                cb_problema.Items.Clear();
                titulo = cb_problema.Text;

                cb_problema.ValueMember = "desc_titulos";
                cb_problema.DisplayMember = "desc_titulos";
                string comando2 = "SELECT * FROM hmda_titulo_titulos WHERE desc_titulos LIKE '%" + titulo + "%'";
                cb_problema.DataSource = combo(comando2);
                int cant = cb_problema.Items.Count;
                if (cant == 0)
                {
                    cb_problema.Text = "No encotrado";
                }

            }
        }

        private void cb_ci_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargatitulos();
        }

        private void cargatitulos()
        {

            string serv = cb_ci.SelectedValue.ToString();
            string comando2 = "select * FROM hmda_titulo_titulos where id_serv =" + serv + " ORDER BY desc_titulos";
            cb_problema.ValueMember = "desc_titulos";
            cb_problema.DisplayMember = "desc_titulos";
            cb_problema.DataSource = combo(comando2);

        }

        private void cb_ci_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string servicio;
                cb_ci.DataSource = null;
                cb_ci.Items.Clear();
                servicio = cb_ci.Text;

                cb_ci.ValueMember = "id_serv";
                cb_ci.DisplayMember = "desc_serv";
                string comando2 = "SELECT * FROM hmda_titulo_servicios WHERE desc_serv LIKE '%" + servicio + "%'";
                cb_ci.DataSource = combo(comando2);

                cb_ci.SelectedIndex = cb_ci.FindString(cb_ci.Text);
                int cant = cb_ci.Items.Count;
                if (cant > 0)
                {
                    cargatitulos();
                }
                else
                {
                    cb_ci.Text = "No encotrado";
                }

            }
        }

       

        public void cargaboxci(int x)
        {
            int serv = x;

            cb_ci.ValueMember = "id_serv";
            cb_ci.DisplayMember = "desc_serv";
            string comandoCI = "select * from hmda_titulo_servicios where id_tipo =" + serv + " ORDER BY desc_serv";


            cb_ci.DataSource = combo(comandoCI);

        }

        private void pb_option_Click(object sender, EventArgs e)
        {

        }



        private void cb_ci_SelectedIndexChanged(object sender, EventArgs e)
        {
            label12.Hide(); 
            label11.Hide();
        }

        private void cb_problema_DropDown(object sender, EventArgs e)
        {
            menu_principal(0);
        }

        private void cb_ci_DropDown(object sender, EventArgs e)
        {
            menu_principal(0);
        }

        private void cb_ci_Enter(object sender, EventArgs e)
        {
           
        }

        private void cb_problema_Enter(object sender, EventArgs e)
        {
            label11.Hide();
        }

        private void cb_ci_TextUpdate(object sender, EventArgs e)
        {
            label12.Hide();
        }

        private void fijarIconosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (titulo_v)
            {
                titulo_v = false;
            }
            else
            {
                titulo_v=true;  
            }
            
        }

        private void cb_problema_SelectedIndexChanged(object sender, EventArgs e)
        {
            string index = cb_problema.Text;
            Clipboard.SetText(index);
        }

       

        public DataTable combo(string x)
        {

                try
                {
                
                    con.Open();
                    DataTable dt = new DataTable();
                    string cbox = x;
                    MySqlCommand cmd = new MySqlCommand(cbox, con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    con.Close();
                    return dt;
                }
                catch
                {
                    con.Close();
                    MessageBox.Show("No hay conexión con el servidor que almacena los datos!!", "Error de Conexión", MessageBoxButtons.OK);
                    return null;
                }

        }

        ////////
        //////Mudolo: PLUS
        //////
        ///


        private void pb_plus_Click_1(object sender, EventArgs e)
        {
            pb_option.Show();

            tituS titu = new tituS();
            titu.Show();
            menu_principal(0);
        }
    }
}