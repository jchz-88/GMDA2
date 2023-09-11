using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;


namespace HMDA
{
    public partial class brawser : Form
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

        private string url;

        private ChromiumWebBrowser Browser;
        public brawser(string urlIn)
        {
            url = urlIn;
            InitializeComponent();
        }

        private void brawser_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));

            
            var setting = new CefSettings();
            setting.CachePath = "";
            if (CefSharp.Cef.IsInitialized == false)
                CefSharp.Cef.Initialize(setting);

            Browser = new ChromiumWebBrowser(url);
            Browser.Dock = DockStyle.Fill;
            chromiumWebBrowser1.Controls.Add(Browser);
        }

        private void pb_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
            
        }

        public int xClick = 0, yClick = 0;
        private void brawser_MouseMove(object sender, MouseEventArgs e)
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
