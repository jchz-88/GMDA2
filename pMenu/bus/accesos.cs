using HMDA.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMDA.pMenu.bus
{
    public partial class accesos : Form
    {
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
        public accesos(DataGridView x)
        {
            InitializeComponent();
            dg_clip = x;
        }

        private void accesos_Load(object sender, EventArgs e)
        {
            


            textBox1.Text = Clipboard.GetText().Replace(" ", "");

            this.BringToFront();
            this.Activate();
            this.BackColor = Color.White;
            textBox1.BackColor = Color.Black;
            this.Opacity = 0.65;

            int barH = Screen.PrimaryScreen.WorkingArea.Height;
            int barW = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = new Point(barW / 2 - 255, barH / 2 - 300);


            PointF x1 = new PointF(0, 0);
            PointF x2 = new PointF(650, 0);
            PointF x3 = new PointF(0, 61);
            PointF x4 = new PointF(650, 61);


            GraphicsPath objDraw = new GraphicsPath();
            objDraw.AddLine(x1, x2);
            objDraw.AddLine(x3, x4);
            objDraw.AddLine(x1, x3);
            objDraw.AddLine(x2, x4);


            this.Region = new Region(objDraw);
            textBox1.Focus();
            this.Size = new Size(650,61);

            this.Region = Region.FromHrgn(CreateRoundRectRgn(3, 3, Width, Height, 20, 20));
        }

        


        private void redondear(Control c)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(new Rectangle(5, 5, c.Width - 11, c.Height - 11));
            c.Region = new Region(gp);


        }

        private void redondear2(Control c)
        {
            GraphicsPath gp = new GraphicsPath();

            gp.AddEllipse(new Rectangle(0, 0, c.Width, c.Height));

            c.Region = new Region(gp);
        } 


        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void accesos_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                string copiado = textBox1.Text;

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
                    resBus re = new resBus(textBox1.Text);
                    re.Show();
                }

                this.Close();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Opacity = 0.95;
            this.Size = new Size(650,61);
        }

    }
}
