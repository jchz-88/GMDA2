using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMDA.pMenu.menu_r.correos
{
    public partial class carga_correo : Form
    {
        private string usuario;
        public carga_correo(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;

        }

        private void carga_correo_Load(object sender, EventArgs e)
        {
            lb_user.Text = usuario;
            tb_correo.Focus();
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_guardar_Click(object sender, EventArgs e)
        {
            if (tb_correo.Text == ""+ "@correoargentino.com.ar")
            {
                MessageBox.Show("Debe agregar una dirección de correo Valida!!");
            }
            else
            {


            }
        }


        private void tb_correo_Enter(object sender, EventArgs e)
        {
            if (tb_correo.Text.Length<1)
            {
                tb_correo.Text = "@correoargentino.com.ar";
                tb_correo.SelectionStart = 0;
            }
        }
    }
}
