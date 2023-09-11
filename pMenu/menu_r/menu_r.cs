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

namespace HMDA
{
    public partial class menu_r : Form
    {
    
        public menu_r()
        {
            InitializeComponent();

            

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(menu_r))
                {
                    frm.Close();
                    break;
                }

            }

        }

        private void menu_r_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.BackColor = Color.Black;
            this.Opacity = 0.95;


            int barH = Screen.PrimaryScreen.WorkingArea.Height;
            int barW = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = new Point(barW / 2 - 255, barH / 2 - 300);

            GraphicsPath objDraw = new GraphicsPath();

            objDraw.AddPie(75, 0, 58, 58, 0, 360);
            objDraw.AddPie(7, 31, 58, 58, 0, 360);
            objDraw.AddPie(7, 105, 58, 58, 0, 360);
            objDraw.AddPie(75, 140, 58, 58, 0, 360);

            this.Region = new Region(objDraw);


            redondear(bt_h1);
            redondear(bt_h2);
            redondear(bt_h3);
            redondear(bt_h4);
        }

        private void redondear(Control c)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(new Rectangle(4, 4, c.Width - 9, c.Height - 9));
            c.Region = new Region(gp);

        }

        

        private void menu_r_Deactivate(object sender, EventArgs e)
        {
            this.Close();
           
            //HMDA.pMenu.menu_r.submenu1 sub = new HMDA.pMenu.menu_r.submenu1();
            //sub.Show();


            
            /*
        if (compartido.menu_r == 1)
        {

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(WindowsFormsApp2.Form1))
                {
                    this.Close();

                    int barW = Screen.PrimaryScreen.WorkingArea.Width;

                    if (frm.Location.X == barW - 55)
                    {
                        compartido.menu_r = 0;
                        MessageBox.Show("asdasfasdasd");
                        frm.Location = new Point(barW - 38, frm.Location.Y);
                    }

                    break;
                }
            }
        }*/

        }


        private void bt_h3_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{PRTSC}");
        }
        /// <summary>
        /// MODULO: Titulos
        /// </summary>

        private void bt_h2_Click(object sender, EventArgs e)
        {

        }

        private void bt_h1_Click(object sender, EventArgs e)
        {

        }
    }
}
