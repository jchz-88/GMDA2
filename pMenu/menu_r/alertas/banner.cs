using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuloAlertas
{
    public partial class banner : Form
    {
        private string contenido;
        public banner(string contenido)
        {
            InitializeComponent();
            this.contenido = contenido;
        }


        private void banner_Load(object sender, EventArgs e)
        {
            int Hv = Screen.PrimaryScreen.WorkingArea.Height;
            int Wv = Screen.PrimaryScreen.WorkingArea.Width;

            this.Width = Wv;
            this.Height = 5 * Hv / 100;
            this.BackColor = Color.Orange;
            this.Opacity = 0.75;
            this.Location = new Point(0, 0);

            lb_text.Text = contenido;
            lb_text.Location = new Point(0, lb_text.Location.Y);

            label2.Text = contenido;
            label2.Location = new Point(this.Width, lb_text.Location.Y);

            label2.ForeColor = Color.Black;

            this.BringToFront();
            
            

            tm_banner.Start();


        }

        private void tm_banner_Tick(object sender, EventArgs e)
        {
            if (lb_text.Visible == true)
            {
                lb_text.Location = new Point(lb_text.Location.X - 5, lb_text.Location.Y);
            }
            if (label2.Visible == true)
            {
                label2.Location = new Point(label2.Location.X - 5, label2.Location.Y);
            }

            if (lb_text.Location.X < 0)
            {
                label2.Show();
            }
            if (label2.Location.X < 0)
            {
                lb_text.Show();
            }

            if (lb_text.Location.X < 0 - lb_text.Width)
            {
                lb_text.Hide();
                lb_text.Location = new Point(this.Width, lb_text.Location.Y);
            }

            if (label2.Location.X < 0 - label2.Width)
            {
                label2.Hide();
                label2.Location = new Point(this.Width, label2.Location.Y);
            }
        }

        private void banner_FormClosed(object sender, FormClosedEventArgs e)
        {
            tm_banner.Stop();
        }

        private void banner_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
