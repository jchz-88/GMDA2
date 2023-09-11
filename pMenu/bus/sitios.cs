using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMDA.pMenu.bus
{
    public partial class sitios : Form
    {
        private string sitio;

        //Conexión a BBDD de Sitios (SAS)
        MySqlConnection con = new MySqlConnection();
        public sitios(string s)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is resBus);

            if (frm != null)
            {
                frm.Close();
            }

            sitio = s;
            InitializeComponent();
        }

        

        private void sitios_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            this.Opacity = 0.80;

            int barH = Screen.PrimaryScreen.WorkingArea.Height;
            int barW = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = new Point(barW / 2 - 174, barH / 2 - 250);

            tabControl1.Show();
            con = conexiones.getInstancia().CrearConexion("gmda");

            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM hmda_sas WHERE NIS =" + "'" + sitio + "'", con);
            MySqlDataReader reg = cmd.ExecuteReader();



            if (reg.Read())
            {
                lbb_denom.Text = reg["DENOMINACION"].ToString();
                tt_copia.SetToolTip(lbb_denom, "Doble Click para Copiar");
                lbb_nis.Text = reg["NIS"].ToString();
                tt_copia.SetToolTip(lbb_nis, "Doble Click para Copiar");
                lbb_partido.Text = reg["PARTIDO"].ToString();
                tt_copia.SetToolTip(lbb_partido, "Doble Click para Copiar");
                lbb_provincia.Text = reg["PROVINCIA"].ToString();
                tt_copia.SetToolTip(lbb_provincia, "Doble Click para Copiar");
                lbb_categoria.Text = reg["CATEGORIA"].ToString();
                tt_copia.SetToolTip(lbb_categoria, "Doble Click para Copiar");
                lbb_cpa.Text = reg["CPA_SUCURSAL"].ToString();
                tt_copia.SetToolTip(lbb_cpa, "Doble Click para Copiar");
                lbb_tipo.Text = reg["TIPO"].ToString();
                tt_copia.SetToolTip(lbb_tipo, "Doble Click para Copiar");
                lbb_titular.Text = reg["TITULAR"].ToString();
                tt_copia.SetToolTip(lbb_titular, "Doble Click para Copiar");
                lbb_region.Text = reg["REGION"].ToString();
                tt_copia.SetToolTip(lbb_region, "Doble Click para Copiar");
                lbb_dire.Text = reg["CALLE"].ToString();
                tt_copia.SetToolTip(lbb_dire, "Doble Click para Copiar");
                lbb_telefono.Text = reg["TELEFONOS"].ToString();
                tt_copia.SetToolTip(lbb_telefono, "Doble Click para Copiar");
                lbb_hora.Text = reg["HORARIOS"].ToString();
                tt_copia.SetToolTip(lbb_hora, "Doble Click para Copiar");
                lbb_numero.Text = reg["NUMERO"].ToString();
                tt_copia.SetToolTip(lbb_numero, "Doble Click para Copiar");
                if (reg["simon"].ToString() == "1")
                {
                    pictureBox25.Show();
                }
                else
                {
                    pictureBox25.Hide();
                }

                string region = reg["REGION"].ToString();
                string zona = reg["ZONA"].ToString();

                con.Close();

                con.Open();
                MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM hmda_zonal WHERE(REGION = '" + region + "' AND ZONA = '" + zona + "')", con);
                MySqlDataReader reg2 = cmd2.ExecuteReader();

                if (reg2.Read())
                {

                    lb_z_zona.Text = reg2["ZONA"].ToString();
                    lb_z_jefe.Text = reg2["JEFE"].ToString();
                    lb_z_suc.Text = reg2["SUC_BASE"].ToString();
                    lb_z_tel.Text = reg2["TELEFONO"].ToString();
                    lb_z_dir.Text = reg2["DIRECCION"].ToString();
                    lb_z_cel.Text = reg2["CELULAR"].ToString();
                    lb_z_cpa.Text = reg2["CPA"].ToString();
                    lb_z_correo.Text = reg2["MAIL"].ToString();
                    lb_z_reg.Text = reg2["REGION"].ToString();
                    lb_z_asis.Text = reg2["ASSIS"].ToString();

                    con.Close();
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

            con.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
