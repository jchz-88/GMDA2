using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMDA.pMenu.bus
{
    public partial class plantillas : Form
    {
        //Conexión a BBDD de Usuarios/Sitios - Mails Automaticos
        
        MySqlConnection conn = new MySqlConnection();

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

        public plantillas()
        {
            InitializeComponent();
        }

        private void plantillas_Load(object sender, EventArgs e)
        {

            conn = conexiones.getInstancia().CrearConexion("gmda");

            this.FormBorderStyle = FormBorderStyle.None;
            

            int w= Screen.PrimaryScreen.WorkingArea.Width/2;
            int h = Screen.PrimaryScreen.WorkingArea.Height /2;
            this.Location = new Point(w + this.Width -60 , h-this.Height );

            this.BackColor = Color.Black;
            this.Opacity = 0.85;

            button1.Hide();
            button2.Hide();
            pb_copiar.Hide();
            pb_elimiar.Hide();
            recorte(0);
        }

        void recorte(int f) 
        {

            GraphicsPath objDraw = new GraphicsPath();
            if (f == 0)
            {
                objDraw.AddRectangle(new Rectangle(0, 0, listBox1.Width + 33, listBox1.Height + label1.Height + 13));
                pb_close.Location = new Point(listBox1.Width + 3, 0);
                pb_copiar.Hide();
                pb_elimiar.Hide();
                
                button1.Text = "";
                button2.Text = "";
                button1.Hide();
                button2.Hide();
            }
            else if(f==1)
            {
                objDraw.AddRectangle(new Rectangle(0, 0, listBox1.Width + 32, listBox1.Height + listBox2.Height + label1.Height + 19));
                pb_close.Location = new Point(listBox1.Width + 3, 0);
                pb_copiar.Hide();
                pb_elimiar.Hide();
                button1.Text = "";
                button2.Text = "";
                button1.Hide();
                button2.Hide();
            }
            else if(f == 2)
            {

                objDraw.AddRectangle(new Rectangle(0, 0, listBox1.Width + 38 + tb2_plantilla.Width, listBox1.Height + listBox2.Height + label1.Height + 19));
                pb_close.Location = new Point(this.Width - 30, 0);
                tb1_plantilla.Text = "Ingresar Asunto.. / Titulo..";
                tb2_plantilla.Text = "Ingrese el Contenido que desa guardar como Plantilla...";
                button1.Text = "";
                button2.Text = "";
                button1.Hide();
                button2.Hide();
            }
            else
            {
                objDraw.AddRectangle(new Rectangle(0, 0, listBox1.Width + 38 + tb2_plantilla.Width, listBox1.Height + listBox2.Height + label1.Height + 19));
                
                pb_close.Location = new Point(this.Width - 30, 0);
                button1.Text = "";
                button2.Text = "";
                button1.Hide();
                button2.Hide();
            }
            
            this.Region = new Region(objDraw);
            if(f == 0)
            {
                this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, listBox1.Width + 32, listBox1.Height + label1.Height + 13, 20, 20));
            }
            else if(f == 1)
            {
                this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, listBox1.Width + 32, listBox1.Height + listBox2.Height + label1.Height + 19, 20, 20));
            }
            else if (f == 2)
            {
                this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, listBox1.Width + 38 + tb2_plantilla.Width, listBox1.Height + listBox2.Height + label1.Height + 19, 20, 20));
            }
            else
            {
                this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, listBox1.Width + 38+ tb2_plantilla.Width, listBox1.Height + listBox2.Height + label1.Height + 19, 20, 20));
            }
            
        }

        private void listBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            listBox2.DataSource = null;
            listBox2.Items.Clear();

            conn.Close();
            try
            {

                conn.Open();
                if (listBox1.SelectedIndex == 0)
                {
                    DataTable dt = new DataTable();
                    string cbox = "select * from plantillas_titulos WHERE id_plantilla = 0 AND usuario_plantilla ='" + Environment.UserName + "' AND estado = 0";
                    MySqlCommand cmd = new MySqlCommand(cbox, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);

                    conn.Close();

                    listBox2.ValueMember = "id_plantillas_titulos";
                    listBox2.DisplayMember = "plantillas_titulos_desc";
                    listBox2.DataSource = dt;

                    recorte(1);
                }
                else if (listBox1.SelectedIndex == 1)
                {
                    DataTable dt = new DataTable();
                    string cbox = "select * from plantillas_titulos WHERE id_plantilla = 1 AND usuario_plantilla ='" + Environment.UserName + "' AND estado = 0";
                    MySqlCommand cmd = new MySqlCommand(cbox, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);

                    conn.Close();

                    listBox2.ValueMember = "id_plantillas_titulos";
                    listBox2.DisplayMember = "plantillas_titulos_desc";
                    listBox2.DataSource = dt;

                    recorte(1);
                }
                else if (listBox1.SelectedIndex == 2)
                {
                    DataTable dt = new DataTable();
                    string cbox = "select * from plantilla_tipo";
                    MySqlCommand cmd = new MySqlCommand(cbox, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);

                    conn.Close();

                    listBox2.ValueMember = "id_plantilla";
                    listBox2.DisplayMember = "plantilla_tipo_nombres";
                    listBox2.DataSource = dt;
                    recorte(1);
                }
                else
                {
                    DataTable dt = new DataTable();
                    string cbox = "select * from plantillas_titulos WHERE usuario_plantilla ='" + Environment.UserName + "' AND estado = 1";
                    MySqlCommand cmd = new MySqlCommand(cbox, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);

                    conn.Close();

                    listBox2.ValueMember = "id_plantillas_titulos";
                    listBox2.DisplayMember = "plantillas_titulos_desc";
                    listBox2.DataSource = dt;

                    recorte(1);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Problemas de acceso a la BBDD", "Error");                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
            }
            
            

        }

        private void listBox2_MouseCaptureChanged(object sender, EventArgs e)
        {

            conn.Close();
            int opt = listBox1.SelectedIndex;

            if (opt == 3)
            {
                string valor = listBox2.SelectedValue.ToString();
                string query = "Select texto, id_plantillas_titulos, plantillas_titulos_desc FROM plantillas_titulos where id_plantillas_titulos =" + valor + " AND estado = 1;";

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        tb1_plantilla.Text = reader["plantillas_titulos_desc"].ToString();
                        tb2_plantilla.Text = reader["texto"].ToString();

                        tb1_plantilla.ForeColor = Color.Black;
                        pb_elimiar.Show();
                        recorte(3);

                        
                    }
                    catch
                    {
                        MessageBox.Show("Vacio!!", "Error de Carga", MessageBoxButtons.OK);
                    }
                }
            }
            else if (opt == 2)
            {
                button2.Hide();
                recorte(2);
            }
            else
            {

                string valor = listBox2.SelectedValue.ToString();
                string query = "Select texto, id_plantillas_titulos, plantillas_titulos_desc FROM plantillas_titulos where id_plantillas_titulos =" + valor + ";";

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        tb1_plantilla.Text = reader["plantillas_titulos_desc"].ToString();
                        tb2_plantilla.Text = reader["texto"].ToString();

                        tb1_plantilla.ForeColor = Color.Black;

                        recorte(3);

                        button2.Text = "COPIAR";
                        button2.Show();

                        pb_copiar.Show();
                        pb_elimiar.Show();
                    }
                    catch
                    {
                        MessageBox.Show("Vacio!!", "Error de Carga", MessageBoxButtons.OK);
                    }
                }
                conn.Close();
            }
            
        }

        

        private void pb_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb2_plantilla_TextChanged(object sender, EventArgs e)
        {
           int opt = listBox1.SelectedIndex;
            if (opt==2)
            {
                button1.Text = "GUARDAR";
                button1.Show();
            }
            else
            {
                if (pb_copiar.Visible == true)
                {
                    button1.Text = "ACTUALIZAR";
                    button1.Show();

                }   
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tipo;
            if (button1.Text == "GUARDAR")
            {
                if (tb1_plantilla.Text == "" || tb1_plantilla.Text == "Ingresar Asunto.. / Titulo..")
                {
                    MessageBox.Show("Complete Los Campos Para Guardar");
                }
                else if (tb2_plantilla.Text == "" || tb2_plantilla.Text == "Ingrese el Contenido que desa guardar como Plantilla...")
                {
                    MessageBox.Show("Complete Los Campos Para Guardar");
                }
                else
                {
                    if (listBox2.SelectedIndex == 0)
                    {
                        tipo = 0;

                    }
                    else
                    {
                        tipo = 1;

                    }


                    try
                    {
                        conn.Close();
                        conn.Open();
                        string query = "INSERT INTO plantillas_titulos(plantillas_titulos_desc, id_plantilla, texto, usuario_plantilla) VALUES ('" + tb1_plantilla.Text + "'," + tipo + ",'" + tb2_plantilla.Text + "', '" + Environment.UserName + "');";
                        MySqlCommand cmd2 = new MySqlCommand(query, conn);
                        cmd2.ExecuteNonQuery();

                        conn.Close();

                        MessageBox.Show("Se realizo la Carga de la Plantilla: '" + tb1_plantilla.Text + "´ Con exito...", "Plantilla Agregada");

                        tb1_plantilla.Text = "Ingresar Asunto.. / Titulo..";
                        tb2_plantilla.Text = "Ingrese el Contenido que desa guardar como Plantilla...";

                        recorte(0);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Problemas de acceso a la BBDD", "Error");
                    }
                }
            }
            else
            {
                conn.Close();
                string valor = tb2_plantilla.Text;
                int titu = Convert.ToInt32(listBox2.SelectedValue.ToString());
                string user = Environment.UserName;
                conn.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("UPDATE plantillas_titulos SET texto = '" + valor + "' WHERE id_plantillas_titulos = '" + titu + "';", conn);
                try
                {
                    cmd.ExecuteReader();
                    conn.Close();
                    MessageBox.Show("Registro de Plantilla actualizado!!!", "Actualización de Plantilla");
                }
                catch (Exception)
                {
                    MessageBox.Show("No es posible actualizar la plantilla!!!", "Actualización de Plantilla");

                }
            }

        }

        private void tb1_plantilla_Click(object sender, EventArgs e)
        {

            int opt = listBox1.SelectedIndex;
            if (opt != 0 && opt != 1)
            {
                tb1_plantilla.Text = "";
            }

            
        }

        private void tb2_plantilla_Click(object sender, EventArgs e)
        {
            int opt = listBox1.SelectedIndex;
            if (opt != 0 && opt != 1)
            {
                tb2_plantilla.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "COPIAR")
            {
                Clipboard.SetText(tb2_plantilla.Text);
                tb2_plantilla.Select();
            }
            
        }

        private void pb_copiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tb1_plantilla.Text);
            tb1_plantilla.Select();
        }

        private void pb_elimiar_Click(object sender, EventArgs e)
        {

            conn.Close();
            int opt = listBox1.SelectedIndex;
            if (opt == 3)
            {
                try
                {
                    var confirmResult = MessageBox.Show("Seguro que desea Eliminar la Plantilla??", "Confirmación!!", MessageBoxButtons.YesNo);
                    
                    if (confirmResult == DialogResult.Yes)
                    {
                        int titu = Convert.ToInt32(listBox2.SelectedValue.ToString());
                        string user = Environment.UserName;

                        conn.Open();

                        string query = "DELETE FROM plantillas_titulos WHERE id_plantillas_titulos = " + titu + ";";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        recorte(0);
                    }

                    conn.Close();

                    MessageBox.Show("Se realizo la eliminación de la Plantilla elegida...", "Plantilla Eliminada");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error de acceso a la BBDD", "Error");
                }

            }
            else
            {
                conn.Close();
                int valor = 1;
                int titu = Convert.ToInt32(listBox2.SelectedValue.ToString());
                string user = Environment.UserName;
                conn.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("UPDATE plantillas_titulos SET estado = '" + valor + "' WHERE id_plantillas_titulos = '" + titu + "';", conn);
                try
                {
                    cmd.ExecuteReader();
                    conn.Close();
                    MessageBox.Show("Registro de Plantilla Borrado!!!", "Actualización de Plantilla");
                }
                catch (Exception)
                {
                    MessageBox.Show("No es posible actualizar la plantilla!!!", "Actualización de Plantilla");

                }
            }
            
        }
        public int xClick = 0, yClick = 0;
        private void plantillas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { 
              xClick = e.X; yClick = e.Y; 
            }
            else
            { 
              this.Left = this.Left + (e.X - xClick); 
              this.Top = this.Top + (e.Y - yClick); 
            }
        }
    }
}
