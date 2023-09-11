using DocumentFormat.OpenXml.Office2010.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.UI.Xaml.Controls;

namespace HMDA.pMenu.menu_r.alertas
{
    public partial class nueva_alerta : Form
    {

        //Conexión a BBDD de Titulos
       
        MySqlConnection con = new MySqlConnection();
        
        public nueva_alerta()
        {
            InitializeComponent();
        }

        private void nueva_alerta_Load(object sender, EventArgs e)
        {

            con = conexiones.getInstancia().CrearConexion("gmda");


            int w = Screen.PrimaryScreen.WorkingArea.Width / 2;
            int h = Screen.PrimaryScreen.WorkingArea.Height / 2;
            

            this.BackColor = System.Drawing.Color.Black;
            this.Opacity = 0.9;
            groupBox3.Hide();
            groupBox2.Hide();
            groupBox1.Show();
            

            groupBox3.Location = new Point(0, -2);
            groupBox2.Location = new Point(0, -2);
            groupBox1.Location = new Point(0, -2);
            groupBox1.BringToFront();
            this.Size = new Size(400, 140);

            this.Location = new Point(w, h - this.Height - 160);
            carga_cb_urgente();
        }

        private void carga_cb_urgente()
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                string cbox = "SELECT * FROM alerta_comunicados ORDER BY urgente DESC";
                MySqlCommand cmd = new MySqlCommand(cbox, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);


                    cb_alert_comun.ValueMember = "id";
                    cb_alert_comun.DisplayMember = "titulo";

                    cb_alert_comun.DataSource = dt;


                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hay problemas de conexión con el servidor.   " + ex);
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            groupBox2.Show();
            groupBox1.Hide();
            label8.Hide();
            textBox4.Hide();
            label5.Text = "NUEVA ALERTA";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            groupBox2.Show();
            groupBox1.Hide();
            label8.Show();
            textBox4.Show();
            label5.Text = "NUEVO COMUNICADO";
        }

        private void pb_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (label8.Visible == false)
            {
                if (textBox1.Text != "" && textBox5.Text != "")
                {
                    guardar_alerta(1);
                }
                else
                {
                    MessageBox.Show("Hay campos pendientes de llenado", "Alerta");
                }
            }
            else
            {
                if (textBox1.Text != "" && textBox5.Text != "" &&  textBox4.Text != "")
                {
                    guardar_alerta(0);
                }
                else
                {
                    MessageBox.Show("Hay campos pendientes de llenado", "Alerta");
                }
            }
        }

        private void guardar_alerta(int i)
        {
            int urg;
            if (checkBox1.Checked)
            {
                urg=1;
                limpiar_urg();
            }
            else
            {
                urg = 0;
            }
            string query="";
            
            if (i == 0)
            {
                query = "INSERT INTO alerta_comunicados(titulo, contenido, urgente, tipo) VALUES ('" + textBox1.Text + "', '" + textBox5.Text + "' , " + urg + ", 'comunicado');";
            }
            else if (i == 1)
            {
                query = "INSERT INTO alerta_comunicados(titulo, contenido, urgente, tipo) VALUES ('" + textBox1.Text + "', '" + textBox5.Text + "' ," + urg + ", 'alerta');";
            }
            con.Close();

            try
            {

                con.Open();
                MySqlCommand cmd2 = new MySqlCommand(query, con);
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Se realizo la carga de la Alerta: "+ textBox1.Text, "Alerta Cargada");
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hay problemas de conexión con el servidor.   " + ex);
                
            }

            textBox1.Text = "";
            textBox5.Text = "";

            this.Close();

        }

        private void limpiar_urg()
        {
            con.Close();
            con.Open();

            string query = "UPDATE alerta_comunicados SET urgente= 0 WHERE urgente = 1;";
            MySqlCommand cmd2 = new MySqlCommand(query, con);
            cmd2.ExecuteNonQuery();
            con.Close();

        }

        private void cb_alert_comun_SelectionChangeCommitted(object sender, EventArgs e)
        {
            limpiar_urg();

            int index = cb_alert_comun.SelectedIndex;
            MessageBox.Show(index.ToString());
            con.Close();
            con.Open();

            string query = "UPDATE alerta_comunicados SET urgente= 1 WHERE id = " + index + ";";
            MySqlCommand cmd2 = new MySqlCommand(query, con);
            cmd2.ExecuteNonQuery();
            con.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Show();

            try
            {
                con.Open();
                DataTable dt = new DataTable();
                string cbox = "SELECT * FROM alerta_comunicados ORDER BY id DESC";
                MySqlCommand cmd = new MySqlCommand(cbox, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);


                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "titulo";

                comboBox1.DataSource = dt;


                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hay problemas de conexión con el servidor.   " + ex);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(comboBox1.SelectedValue.ToString());

            MessageBox.Show(index.ToString());

            try
            {
                con.Open();
                DataTable dt = new DataTable();
                string cbox = "SELECT * FROM alerta_alertavistas WHERE id_alerta = " + index + ";";
                MySqlCommand cmd = new MySqlCommand(cbox, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                listBox1.ValueMember = "id";
                listBox1.DisplayMember = "usuario";

                listBox1.DataSource = dt;


                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hay problemas de conexión con el servidor.   " + ex);
            }
        }

        public int xClick = 0, yClick = 0;
        private void nueva_alerta_MouseMove(object sender, MouseEventArgs e)
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
