using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HMDA.Properties;

namespace HMDA.pMenu.menu_r
{
    public partial class config : Form
    {
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

        public config()
        {
            InitializeComponent();
        }

        private void config_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            this.BackColor = Color.Black;
            this.Opacity = 0.80;

            pictureBox1.Hide();

            if (Settings.Default["server"].ToString() == "")
            {
                textBox1.BackColor = Color.IndianRed;
            }
            else
            {
                textBox1.Text = Settings.Default["server"].ToString();
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult Result;

            Settings.Default["server"] = textBox1.Text;
            Result = MessageBox.Show("Esta seguro que quiere modificar el servidor de datos?", "Cambio de Servidor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (Result == DialogResult.OK)
            {
                Settings.Default.Save();
                Application.Restart();
            }
            else
            {
                MessageBox.Show("No se realizaron Cambios!!!");
            }
            
        }

        public int xClick = 0, yClick = 0;

        private void config_MouseMove(object sender, MouseEventArgs e)
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

        private void pb_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
