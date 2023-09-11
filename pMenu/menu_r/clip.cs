using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMDA
{
    public partial class F_Cpliboard : Form
    {

        public List<string> clips = new List<string>();

        private System.Windows.Forms.Timer tmr;

        public F_Cpliboard()
        {
            InitializeComponent();

            
            this.BackColor = Color.Black;
            this.Opacity = 0.65;

            tmr = new System.Windows.Forms.Timer();
            tmr.Tick += delegate {
                this.Close();
            };
            tmr.Interval = (int)TimeSpan.FromSeconds(8).TotalMilliseconds;
            tmr.Start();

        }

        private void F_Cpliboard_Load(object sender, EventArgs e)
        {
            dg_clip.Hide();
            int cant = clips.Count;
            int reducir = panel1.Height * cant;
            int barH = Screen.PrimaryScreen.WorkingArea.Height;
            int barW = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = new Point(barW - this.Width, barH - reducir );


            cargaClips();

        }


        private void cargaClips()
        {
            int cant = clips.Count;
            int flag = 0;
            foreach(Control panel in this.Controls)
            {
                foreach (Control lb in panel.Controls)
                { 
                    if (lb is Label)
                    {
                        if (flag<cant)
                        {
                            lb.Text = clips[flag];
                            new ToolTip().SetToolTip(lb, clips[flag]);
                            flag++;
                        }
                        else
                        {
                            break;
                        }

                    }
                }
            }

        }

        private void F_Cpliboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            tmr.Stop();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label10.Text);
            this.Close();
        }

        private void label10_MouseEnter(object sender, EventArgs e)
        {
            label10.Location = new Point(label10.Location.X - 3, label10.Location.Y - 3);
            Thread.Sleep(300);
            label10.Location = new Point(label10.Location.X + 3, label10.Location.Y + 3);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label9.Text);
            this.Close();
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            label9.Location = new Point(label9.Location.X - 3, label9.Location.Y - 3);
            Thread.Sleep(300);
            label9.Location = new Point(label9.Location.X + 3, label9.Location.Y + 3);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label8.Text);
            this.Close();
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.Location = new Point(label8.Location.X - 3, label8.Location.Y - 3);
            Thread.Sleep(300);
            label8.Location = new Point(label8.Location.X + 3, label8.Location.Y + 3);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label7.Text);
            this.Close();
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            label7.Location = new Point(label7.Location.X - 3, label7.Location.Y - 3);
            Thread.Sleep(300);
            label7.Location = new Point(label7.Location.X + 3, label7.Location.Y + 3);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label6.Text);
            this.Close();
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.Location = new Point(label6.Location.X - 3, label6.Location.Y - 3);
            Thread.Sleep(300);
            label6.Location = new Point(label6.Location.X + 3, label6.Location.Y + 3);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label5.Text);
            this.Close();
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.Location = new Point(label5.Location.X - 3, label5.Location.Y - 3);
            Thread.Sleep(300);
            label5.Location = new Point(label5.Location.X + 3, label5.Location.Y + 3);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label4.Text);
            this.Close();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.Location = new Point(label4.Location.X - 3, label4.Location.Y - 3);
            Thread.Sleep(300);
            label4.Location = new Point(label4.Location.X + 3, label4.Location.Y + 3);
        }


        private void label3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label3.Text);
            this.Close();
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.Location = new Point(label3.Location.X - 3, label3.Location.Y - 3);
            Thread.Sleep(300);
            label3.Location = new Point(label3.Location.X + 3, label3.Location.Y + 3);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label2.Text);
            this.Close();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.Location = new Point(label2.Location.X - 3, label2.Location.Y - 3);
            Thread.Sleep(300);
            label2.Location = new Point(label2.Location.X + 3, label2.Location.Y + 3);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label1.Text);
            this.Close();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.Location = new Point(label1.Location.X - 3, label1.Location.Y - 3);
            Thread.Sleep(300);
            label1.Location = new Point(label1.Location.X + 3, label1.Location.Y + 3);
        }

       
    }
}
