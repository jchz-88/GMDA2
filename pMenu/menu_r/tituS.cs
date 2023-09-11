using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HMDA;

namespace HMDA
{
    public partial class tituS : Form
    {

        //Conexión a BBDD de Titulos
        
        MySqlConnection con = new MySqlConnection();

        public int xClick = 0, yClick = 0;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        int index =0;
        public tituS()
        {
            InitializeComponent();
        }

        private void tituS_Load(object sender, EventArgs e)
        {
            con = conexiones.getInstancia().CrearConexion("gmda");

            this.Region = Region.FromHrgn(CreateRoundRectRgn(1, 3, Width, Height, 20, 20));

            int barH = Screen.PrimaryScreen.WorkingArea.Height;
            int barW = Screen.PrimaryScreen.WorkingArea.Width;

            this.Location = new Point(barW/2 - this.Width, barH/2-this.Height);

            carga_sugerencias();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                con.Close();
                try
                {
                    con.Open();
                    string query = "INSERT INTO sugerencias_titulos(sugerencia) VALUES ('" + tb_nueva.Text + "');";
                    MySqlCommand cmd2 = new MySqlCommand(query, con);
                    cmd2.ExecuteNonQuery();
                   
                    tb_nueva.Text = "";

                    con.Close();
                }
                catch
                {
                    MessageBox.Show("Error, el servidor puede estar fuera de linea!!!", "Sugerencia Agregada");
                    con.Close();
                }

                carga_sugerencias();
            }

        }

        private void carga_sugerencias()
        {

            con.Open();
                string query = "Select id,sugerencia from sugerencias_titulos";

                MySqlDataAdapter sda = new MySqlDataAdapter(query, con);

                DataTable dt = new DataTable();
                sda.Fill(dt);  //Carga el resultado en el dataTable

                listBox1.DataSource = dt.DefaultView;
                listBox1.ValueMember = "id";
                listBox1.DisplayMember = "sugerencia";  //Campo que se mostrará en el ListBox
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = listBox1.SelectedIndex;
        }

        private void tituS_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {

            if ((Properties.Settings.Default["user"].ToString() == "zextjchavez") || (Properties.Settings.Default["user"].ToString() == "zextcayunta") || (Properties.Settings.Default["user"].ToString() == "zextbgalvan"))
            {

                string id = listBox1.SelectedValue.ToString();
                con.Close();
                con.Open();

                try
                {

                    string query = "DELETE FROM sugerencias_titulos WHERE id = " + id + ";";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    con.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Error de acceso a la BBDD", "Error");
                }

                carga_sugerencias();
            }

            
        }
    }
}
