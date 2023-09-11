using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using HMDA.Properties;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using SpreadsheetLight;
using HMDA;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp2
{


    public partial class Form1 : Form
    {
        


        string path_titulos;

        float max_op = 100f;
        float trs;


        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        private const int WM_HOTKEY = 0x0312;
        

        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );


        [DllImport("user32.dll")]
        protected static extern int SetClipboardViewer(int hWndNewViewer);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        protected static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        protected static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        IntPtr nextClipboardViewer;

        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);



        public Form1()
        {

            InitializeComponent();


            int id = 0;   //dejar por defecto 
                          //Registramos El evento asociado al iniciar el formulario
            RegisterHotKey(this.Handle, id, (int)KeyModifier.Control, Keys.Space.GetHashCode());

            

            
            //this.logo.Image = Properties.Resources.logo;
            //this.btn_login.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.btn_login.Width, this.btn_login.Height, 10, 10));

            //Inicia la Ventana de escucha de Clipboard
            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)this.Handle);

            //Recargar path de Imagen de Firma
            pbFirma.ImageLocation = Settings.Default["firma"].ToString();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            

            List<string> usuarios = new List<string>();

            string[] directories = Directory.GetDirectories(@"c:\Users\");

            foreach (var item in directories)
            {
                usuarios.Add(item.Substring(9));
            }

            
            cb_users.DataSource = usuarios;
            if (Settings.Default["user"] == null)
            {
                cb_users.Text = "Elija su usuario 🡻🡻";
            }
            else
            {
                cb_users.Text = Settings.Default["user"].ToString();
            }

            this.BackColor = Color.Black;
            this.Opacity = 0.8;


            this.TopMost = (bool)Settings.Default["Fijar"];
            //this.Opacity = (float)Settings.Default["Transparente"];
            //this.Font = (Font)Settings.Default["Fuente"];
            //this.BackColor = (Color)Settings.Default["Color_B"];
            //this.ForeColor = (Color)Settings.Default["Color_F"];


            if ((bool)Settings.Default["Fijar"] == true) { fijar.Text = "ON"; fijar.ForeColor = Color.Lime; }
            else { fijar.Text = "OFF"; fijar.ForeColor = Color.Crimson; }

            opacidad.Value = (int)(((float)Settings.Default["Transparente"]) * 0.99f);


            path_titulos = (string)Settings.Default["Path"];


            dg_clip.Hide();


            gb_config.Hide();


            gb_email.Hide();
            tabControl2.Hide();
            tabControl3.Hide();


            dg_lista1.Hide();
            dg_lista2.Hide();
            dg_lista3.Hide();

            int barW = Screen.PrimaryScreen.WorkingArea.Width /2;

            this.Location = new Point(barW - 172, 200);
            

            this.Size = new Size(310, 105);


            if (this.TopMost == true)
            {
                opcion1.Text = opcion1.Text + "  ✔";
            }

            this.Region = Region.FromHrgn(CreateRoundRectRgn(3, 3, Width, Height, 20, 20));
        }

        GraphicsPath objDraw = new GraphicsPath();
        

      
      

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            timer3.Stop();
            RemoveClipboardFormatListener(this.Handle);
            UnregisterHotKey(this.Handle, 0);
        }

        //Conexión a BBDD de Titulos
        //static string conexion = "SERVER=" + Settings.Default["server"].ToString() + "10.254.63.48;PORT=3306;DATABASE=titulos;UID=jchz;PASSWORDS=;";
        //MySqlConnection cn = new MySqlConnection(conexion);
        MySqlConnection cn = new MySqlConnection();

        //Conexión a BBDD de Tipificaciónes
        static string conexion2 = "SERVER=10.254.63.48;PORT=3306;DATABASE=titulos;UID=jchz;PASSWORDS=;";
        MySqlConnection cn2 = new MySqlConnection(conexion2);

        //Conexión a BBDD de Sitios (SAS)
        static string conexion3 = "SERVER=10.254.63.48;PORT=3306;DATABASE=sas;UID=jchz;PASSWORDS=;";
        MySqlConnection cn3 = new MySqlConnection(conexion3);

        //Conexión a BBDD de Usuarios/Sitios - Mails Automaticos
        static string conexion4 = "SERVER=10.254.63.48;PORT=3306;DATABASE=base_correos;UID=jchz;PASSWORDS=;";
        MySqlConnection cn4 = new MySqlConnection(conexion4);

        //Conexión a BBDD de Usuarios/Sitios - Mails Automaticos
        static string conexion5 = "SERVER=10.254.63.48;PORT=3306;DATABASE=paginas;UID=jchz;PASSWORDS=;";
        MySqlConnection cn5 = new MySqlConnection(conexion5);

        //Conexión a BBDD de Usuarios/Sitios - Mails Automaticos
        static string conexion6 = "SERVER=10.254.63.48;PORT=3306;DATABASE=gmda;UID=jchz;PASSWORDS=;";
        MySqlConnection cn6 = new MySqlConnection(conexion6);

        private void cb_users_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cbx = sender as ComboBox;
            if (cbx != null)
            {
                // Always draw the background
                e.DrawBackground();

                // Drawing one of the items?
                if (e.Index >= 0)
                {
                    // Set the string alignment.  Choices are Center, Near and Far
                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;

                    // Set the Brush to ComboBox ForeColor to maintain any ComboBox color settings
                    // Assumes Brush is solid
                    Brush brush = new SolidBrush(cbx.ForeColor);

                    // If drawing highlighted selection, change brush
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                        brush = SystemBrushes.HighlightText;

                    // Draw the string
                    e.Graphics.DrawString(cbx.Items[e.Index].ToString(), cbx.Font, brush, e.Bounds, sf);
                }
            }
        }

        private void pictureBox39_Click(object sender, EventArgs e)
        {
            if (cb_users.Text == "**Seleccione USUARIO ↓↓")
            {
                MessageBox.Show("Elija un usuario de la lista desplegable...");
            }
            else
            {

                Settings.Default["user"] = cb_users.Text;
                Settings.Default.Save();

                this.BackColor = Color.HotPink;
                abrir_cloud();
                this.Visible = false;
                HMDA.pMenu.menu_r.HMDA menu = new HMDA.pMenu.menu_r.HMDA(dg_clip);
                menu.Show();
                

                //modo_oculto();
            }


        }

        private void abrir_cloud()
        {
            if (!IsExecutingApplication())
            {
                string user_dir = Settings.Default["user"].ToString();
                Process cmd = new Process();

                cmd.StartInfo.FileName = "C:\\Users\\" + user_dir + "\\AppData\\Roaming\\CloudShot\\CloudShot.exe";
                try
                {
                    cmd.Start();
                    cmd.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error abriendo la aplicación de Recoretes!!!", "Error en CloudShoot");
                }
            }

        }

        private static bool IsExecutingApplication()
        {

            // Matriz de procesos
            Process[] processes = Process.GetProcesses();

            // Recorremos los procesos en ejecución
            foreach (Process p in processes)
            {
                if (p.ProcessName == "CloudShot")
                {
                    return true;
                }
            }
            return false;
        }

       

        public DataTable combo(string x, int y)
        {
            if (y == 1)
            {
                
                cn = conexiones.getInstancia().CrearConexion("titulos");
                try
                {
                    cn.Open();
                    DataTable dt = new DataTable();
                    string cbox = x;
                    MySqlCommand cmd = new MySqlCommand(cbox, cn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    cn.Close();
                    return dt;
                }
                catch
                {
                    cn.Close();
                    MessageBox.Show("No hay conexión con el servidor que almacena los datos!!", "Error de Conexión", MessageBoxButtons.OK);
                    return null;
                }

            }
            else if (y == 2)
            {
                try
                {
                    cn2.Open();
                    DataTable dt = new DataTable();
                    string cbox = x;
                    MySqlCommand cmd = new MySqlCommand(cbox, cn2);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    cn2.Close();
                    return dt;
                }
                catch
                {
                    cn2.Close();
                    MessageBox.Show("No hay conexión con el servidor que almacena los datos!!", "Error de Conexión", MessageBoxButtons.OK);
                    return null;
                }
            }
            else if (y == 5)
            {
                try
                {
                    cn5.Open();
                    DataTable dt = new DataTable();
                    string cbox = x;
                    MySqlCommand cmd = new MySqlCommand(cbox, cn5);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    cn5.Close();

                    return dt;
                }
                catch
                {
                    cn5.Close();
                    MessageBox.Show("No hay conexión con el servidor que almacena los datos!!", "Error de Conexión", MessageBoxButtons.OK);
                    return null;
                }
            }
            else
            {
                try
                {
                    cn3.Open();
                    DataTable dt = new DataTable();
                    string cbox = x;
                    MySqlCommand cmd = new MySqlCommand(cbox, cn3);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    cn3.Close();
                    return dt;

                }
                catch
                {
                    cn3.Close();
                    MessageBox.Show("No hay conexión con el servidor que almacena los datos!!", "Error de Conexión", MessageBoxButtons.OK);
                    return null;
                }
            }


        }

        private void bt_cambiar_Click(object sender, EventArgs e)
        {


            FolderBrowserDialog ruta = new FolderBrowserDialog();

            if (ruta.ShowDialog() == DialogResult.OK)
            {
                path_titulos = Directory.GetFiles(ruta.SelectedPath).ToString();
                Settings.Default["Path"] = path_titulos;
                Settings.Default.Save();

            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            por.Text = opacidad.Value.ToString() + "%";

            trs = opacidad.Value / max_op;

            Settings.Default["Transparente"] = trs;
            Settings.Default.Save();

            Form1.ActiveForm.Opacity = trs;
        }

        private void fijar_Click(object sender, EventArgs e)
        {
            if (fijar.Text == "OFF")
            {
                Form1.ActiveForm.TopMost = true;
                fijar.Text = "ON";
                fijar.ForeColor = Color.Lime;
                Settings.Default["Fijar"] = true;
                Settings.Default.Save();
            }
            else
            {
                Form1.ActiveForm.TopMost = false;
                fijar.Text = "OFF";
                fijar.ForeColor = Color.Crimson;
                Settings.Default["Fijar"] = false;
                Settings.Default.Save();
            }

        }

        ///
        /////////////////////ZONA::::::CORTADOR////////////////////////
        ///
        private void pictureBox3_Click(object sender, EventArgs e)
        {

            SendKeys.Send("{PRTSC}");

        }

       

        ///
        /////////////////////ZONA::::::CONFIGRUACIÓN////////////////////////
        ///
       

        private void bt_font_Click(object sender, EventArgs e)
        {
            FontDialog fuente = new FontDialog();
            if (fuente.ShowDialog() == DialogResult.OK)
            {
                this.Font = fuente.Font;
            }
        }

        private void bt_letra_Click(object sender, EventArgs e)
        {
            ColorDialog colorlet = new ColorDialog();
            if (colorlet.ShowDialog() == DialogResult.OK)
            {
                this.ForeColor = colorlet.Color;
                bt_letra.BackColor = colorlet.Color;

                Settings.Default["Color_F"] = bt_letra.BackColor;
                Settings.Default.Save();
            }
        }

        private void bt_bg_Click(object sender, EventArgs e)
        {
            ColorDialog colorbg = new ColorDialog();
            if (colorbg.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorbg.Color;
                bt_bg.BackColor = colorbg.Color;

                Settings.Default["Color_B"] = bt_bg.BackColor;
                Settings.Default.Save();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Empty;
            Settings.Default["Color_B"] = Color.Empty;

            this.ForeColor = Color.Empty;
            Settings.Default["Color_F"] = Color.Empty;


            //this.Font = default;
            //Settings.Default["Fuente"] = default;


            Form1.ActiveForm.Size = new Size(344, 220);

            path_titulos = @"\\b1842zacw0879\\Pablo\\Datos\\TEST\\Titulos";
            Settings.Default["Path"] = path_titulos;


            Settings.Default["Fijar"] = false;


            Settings.Default["Transparente"] = 0.99f;


            Settings.Default.Save();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog ruta = new FolderBrowserDialog();

            if (ruta.ShowDialog() == DialogResult.OK)
            {
                path_titulos = Directory.GetFiles(ruta.SelectedPath).ToString();
                Settings.Default["Path"] = path_titulos;
                Settings.Default.Save();

            }
        }

        ///
        /////////////////////ZONA::::::CERRAR APLICACIÓN////////////////////////
        ///
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Cerrar Aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                Form1.ActiveForm.Close();
            }
        }

        ///
        /////////////////////ZONA::::::MOVER APLICACIÓN////////////////////////
        ///
      

        /// <summary>
        /// ///MODULO:_ TITULOS
        /// </summary>
        /// 
      
        private void cb_problema_SelectedValueChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


      

       





        ///
        /////////////////////ZONA::::::PING CONEXIÓN////////////////////////
        ///


        private void ping_Click(object sender, EventArgs e)
        {
            conex frm = new conex(" ");
            frm.Show();
        }
        ///
        /////////////////////ZONA::::::CLIPBOARD GUARDADO////////////////////////
        ///

        int flag_clip = 0;
        F_Cpliboard frm2;
        private void pictureBox26_Click(object sender, EventArgs e)
        {
            flag_clip = 0;
            
            foreach (Form fmr in Application.OpenForms)
            {
                if (fmr.Name == "F_Cpliboard")
                {

                    flag_clip = 1;
                }
            }
            abrir_formClip();

        }

        private void abrir_formClip()
        {
            if (flag_clip == 1)
            {
                
                frm2.Close();
                frm2 = null;
            }
            else
            {
                frm2 = new F_Cpliboard();
                
                frm2.clips.Clear();

                int cant = dg_clip.RowCount - 1;

                for (int i = 0; i < cant; i++)
                {
                    frm2.clips.Add(dg_clip.Rows[i].Cells[0].Value.ToString());
                }
                
                frm2.Show();
            }
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_DRAWCLIPBOARD = 0x308;
            const int CHANGECBCHAIN = 0x030D;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    DisplayClipboardData();

                    SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;

                case CHANGECBCHAIN:
                    if (m.WParam == nextClipboardViewer)
                        nextClipboardViewer = m.WParam;
                    else
                        SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;
                case WM_HOTKEY:



                    HMDA.pMenu.bus.accesos ac = new HMDA.pMenu.bus.accesos(dg_clip);
                    ac.Show();

                    
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }


            //base.WndProc(ref m);
            
        }

        void DisplayClipboardData()
        {
            string strClipboard = string.Empty;
            bool ok = false;
            try
            {
                IDataObject myDataObject = new DataObject();
                myDataObject = Clipboard.GetDataObject();
                if (myDataObject.GetDataPresent(DataFormats.UnicodeText))
                {
                    strClipboard = myDataObject.GetData(DataFormats.UnicodeText).ToString();
                }
                else if (myDataObject.GetDataPresent(DataFormats.Text))
                {
                    strClipboard = (string)myDataObject.GetData(DataFormats.StringFormat);
                }

                

                if (Clipboard.ContainsText())
                {
                    
                    if (dg_clip.RowCount==1)
                    {
                        this.dg_clip.Rows.Add(Clipboard.GetText());
                    }
                    else
                    {
                        
                        for (int i = 0; i < dg_clip.RowCount-1; i++)
                        {
                            if (Clipboard.GetText() == dg_clip.Rows[i].Cells[0].Value.ToString())
                            {
                                ok = true;
                            }
                        }

                        if (!ok)
                        {
                            if (dg_clip.RowCount > 10)
                            {
                                this.dg_clip.Rows.Remove(dg_clip.Rows[0]);
                                this.dg_clip.Rows.Add(Clipboard.GetText());
                            }
                            else
                            {
                                this.dg_clip.Rows.Add(Clipboard.GetText());
                            }
                        }
                    }
                    
                    
                }
                
                   

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: "+e.ToString());
            }


        }

        ///
        ////////////////////ZONA::::: Envíar Mails Automatico/////////////////////////////////
        ///
        string asunto = "Confirmación de Tickets";
        string cuerpo = "El sector interviniente indica que los siguientes tickets se encuentran resueltos, favor de confirmar para proceder al cierre de los mismos.";
        string final = "Aguardo su respuesta.";
        string copia;


        private void pictureBox28_Click(object sender, EventArgs e)
        {
            cn4.Close();


            if (gb_email.Visible == false)
            {


                if (dg_lista0.Rows.Count > 1 && dg_lista0.Rows != null)
                {
                    tabControl2.Show();

                }
                else
                {
                    gb_email.Show();

                }
            }
            else
            {
                gb_email.Hide();

            }
            Form1.ActiveForm.AutoSize = true;

            bgW_mail.WorkerReportsProgress = true;
            bgW_mail.WorkerSupportsCancellation = true;
            bgw_carga.WorkerReportsProgress = true;
            bgw_carga.WorkerSupportsCancellation = true;


            dg_lista1.Hide();
            dg_lista2.Hide();
            dg_lista3.Hide();
            dg_enviados.Hide();

            this.Size = new Size(346, 60);
            this.AutoSize = true;
           
            bgw_carga.RunWorkerAsync();

            textBox9.Text = asunto;
            textBox8.Text = cuerpo;
            textBox7.Text = final;
        }

        private void bgw_carga_DoWork_1(object sender, DoWorkEventArgs e)
        {

           
                  
            
            try
            {

                cn4.Open();
                cn4.Close();
            }
            catch (Exception)
            {
                
                //this.Close();
                bgw_carga.ReportProgress(1);

            }

            try
            {

                Process cmd2 = new Process();
                cmd2.StartInfo.FileName = "cmd.exe";
                cmd2.StartInfo.RedirectStandardInput = true;
                cmd2.StartInfo.RedirectStandardOutput = true;
                cmd2.StartInfo.CreateNoWindow = true;
                cmd2.StartInfo.UseShellExecute = false;
                cmd2.Start();
                cmd2.StandardInput.WriteLine("@echo off");
                cmd2.StandardInput.WriteLine("powershell.exe -ExecutionPolicy Unrestricted -Command Connect-MgGraph -Scopes ` 'Mail.Send'");
                cmd2.StandardInput.Flush();
                cmd2.StandardInput.Close();
                cmd2.WaitForExit();
                string res = cmd2.StandardOutput.ReadToEnd();

                if (!res.Contains("Welcome To Microsoft Graph!"))
                {
                    

                    bgw_carga.ReportProgress(2);

                }
                else
                {
                    bgw_carga.ReportProgress(3);

                }


            }
            catch (Exception)
            {
                
                bgw_carga.ReportProgress(4);
            }

        }

        private void bgw_carga_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
            {
                MessageBox.Show("No hay conexión con el Servidor de Datos, la aplicación se cerrará", "Fallo de conexión con el server");
                gb_email.Hide();
                Form1.ActiveForm.Size = new Size(346, 54);


            }
            else if (e.ProgressPercentage == 2)
            {
                MessageBox.Show("Se ha cancelado el registro del Usuario", "Conexión Mg-Grapf");
                gb_email.Hide();
                Form1.ActiveForm.Size = new Size(346, 54);


            }
            else if (e.ProgressPercentage == 3)
            {
                pb_cargando.Hide();

            }
            else
            {
                MessageBox.Show("No tiene los permisos necesaríos para realizar esta acción.  \n", "Conexión MGrapf");
                gb_email.Hide();
                Form1.ActiveForm.Size = new Size(346, 54);

            }
        }

       
        private void bgw_carga_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pb_cargando.Hide();
        }
       
        string filename;

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            groupBox14.Hide();
            groupBox18.Hide();
            pictureBox38.Hide();
            dg_enviados.Hide();

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                //DE ESTA MANERA FILTRAMOS TODOS LOS ARCHIVOS EXCEL EN EL NAVEGADOR DE ARCHIVOS
                Filter = "Excel | *.xls;*.xlsx;*.cvs;",

                //AQUÍ INDICAMOS QUE NOMBRE TENDRÁ EL NAVEGADOR DE ARCHIVOS COMO TITULO
                Title = "Seleccionar Archivo"
            };

            //EN CASO DE SELECCIONAR EL ARCHIVO, ENTONCES PROCEDEMOS A ABRIR EL ARCHIVO CORRESPONDIENTE
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog.FileName;


                copia = Settings.Default["cc"].ToString();
                string pasador = Settings.Default["cc"].ToString().Replace("@correoargentino.com.ar", ";");
                textBox6.Text = pasador.Replace(";;", ";");
                tabControl2.SelectedIndex = 1;
                tabControl2.SelectedIndex = 0;

                cargadedatos(filename);

            }

        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {

                Filter = "Image | *.png;",


                Title = "Seleccionar Imagen para Firma"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog.FileName;
                Settings.Default["firma"] = filename.ToString();
                Settings.Default.Save();
                pbFirma.ImageLocation = Settings.Default["firma"].ToString();
            }
        }

        void cargadedatos(string fuente)
        {

            //dg_lista1.DataSource = 
            ImportarDatos(fuente);
            dg_lista1.Columns.Add("flag", "tipo");
            lb_num_total.Text = (dg_lista1.RowCount - 1).ToString();


            if (dg_lista1.Columns.Contains("Ubicación") && dg_lista1.Columns.Contains("Título") && dg_lista1.Columns.Contains("Nombre completo de contacto") && dg_lista1.Columns.Contains("ID de la interacción"))
            {


                dg_lista2.Columns.Add("Ubicación", "Ubicación");
                dg_lista2.Columns.Add("ID de la interacción", "ID de la interacción");
                dg_lista2.Columns.Add("Título", "Título");
                dg_lista2.Columns.Add("Nombre completo de contacto", "Nombre completo de contacto");

                dg_lista3.Columns.Add("Ubicación", "Ubicación");
                dg_lista3.Columns.Add("ID de la interacción", "ID de la interacción");
                dg_lista3.Columns.Add("Título", "Título");
                dg_lista3.Columns.Add("Nombre completo de contacto", "Nombre completo de contacto");

                ListarUsuario();

                for (int i = 0; i < dg_lista1.RowCount - 1; i++)
                {
                    if (this.dg_lista1.Rows[i].Cells["flag"].Value.ToString() == "user")
                    {

                        this.dg_lista2.Rows.Add(dg_lista1.Rows[i].Cells["Ubicación"].Value, dg_lista1.Rows[i].Cells["ID de la interacción"].Value, dg_lista1.Rows[i].Cells["Título"].Value, dg_lista1.Rows[i].Cells["Nombre completo de contacto"].Value);

                        this.dg_lista1.Rows.Remove(dg_lista1.Rows[i]);
                        i--;
                    }
                }

                ListarSitios();

                for (int i = 0; i < dg_lista1.RowCount - 1; i++)
                {
                    if (this.dg_lista1.Rows[i].Cells["flag"].Value.ToString() == "sitio")
                    {
                        this.dg_lista3.Rows.Add(dg_lista1.Rows[i].Cells["Ubicación"].Value, dg_lista1.Rows[i].Cells["ID de la interacción"].Value, dg_lista1.Rows[i].Cells["Título"].Value, dg_lista1.Rows[i].Cells["Nombre completo de contacto"].Value);

                        this.dg_lista1.Rows.Remove(dg_lista1.Rows[i]);
                        i--;
                    }
                }

                ListarNoEncontrados();

                this.dg_lista1.Refresh();


                if (dg_lista0.Rows.Count < 10)
                {
                    dg_lista0.Height = (dg_lista0.ColumnHeadersHeight * dg_lista0.Rows.Count + 1) + 5;
                    tabControl2.Height = 280 + dg_lista0.ColumnHeadersHeight * dg_lista0.RowCount;
                    dg_lista0.Location = new Point(5, 215);
                }
                else
                {
                    dg_lista0.Height = dg_lista0.ColumnHeadersHeight * 10;
                    tabControl2.Height = 275 + dg_lista0.Height;
                    dg_lista0.Location = new Point(4, 215);
                }



                lb_num_usuario.Text = (dg_lista2.RowCount - 1).ToString();
                lb_num_sitios.Text = (dg_lista3.RowCount - 1).ToString();
                lb_num_no.Text = (dg_lista1.RowCount - 1).ToString();

                Form1.ActiveForm.AutoSize = true;

                //tabControl2.Show();
                //tabControl2.Location = new Point(3, 3);
                //groupBox1.Hide();

                Form1.ActiveForm.Size = new Size(346, 54);
                Form1.ActiveForm.AutoSize = true;

            }
            else
            {
                MessageBox.Show("No se encuentran las Tablas necesarias para el analisis", "Tablas Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        void ImportarDatos(string nombrearchivo) //COMO PARAMETROS OBTENEMOS EL NOMBRE DEL ARCHIVO A IMPORTAR
        {

            dg_lista1.Columns.Add("Ubicación", "Ubicación");
            dg_lista1.Columns.Add("ID de la interacción", "ID de la interacción");
            dg_lista1.Columns.Add("Título", "Título");
            dg_lista1.Columns.Add("Nombre completo de contacto", "Nombre completo de contacto");



            SLDocument sl = new SLDocument(nombrearchivo);

            int iRow = 2;


            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {

                dg_lista1.Rows.Add(sl.GetCellValueAsString(iRow, 1), sl.GetCellValueAsString(iRow, 2),
                    sl.GetCellValueAsString(iRow, 3), sl.GetCellValueAsString(iRow, 4));

                iRow++;
            }


            /*
            Excel.Application xlApp = new Excel.Application();
            try
            {
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(nombrearchivo);
                Excel.Worksheet xlWorksheet = xlWorkbook.Worksheets[1];
                Excel.Range range = xlWorksheet.UsedRange;
                int filas = range.Rows.Count;
                int columnas = range.Columns.Count;


                for (int i = 0; i < filas - 1; i++)
                {
                    dg_lista1.Rows.Add();
                }



                for (int i = 2; i <= filas; i++)
                {
                    DataGridViewRow row = dg_lista1.Rows[j];


                    row.Cells["Ubicación"].Value = range.Cells[i, 1].value;
                    row.Cells["ID de la interacción"].Value = range.Cells[i, 2].value;
                    row.Cells["Título"].Value = range.Cells[i, 3].value;
                    row.Cells["Nombre completo de contacto"].Value = range.Cells[i, 4].value;

                    j++;
                }

                Marshal.ReleaseComObject(range);
                Marshal.ReleaseComObject(xlWorksheet);
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);


            }
            catch (Exception)
            {
                MessageBox.Show("Error al abrir el archivo Excel: " + nombrearchivo);
            }
           

            return null;

            /*
            //UTILIZAMOS 12.0 DEPENDIENDO DE LA VERSION DEL EXCEL, EN CASO DE QUE LA VERSIÓN QUE TIENES ES INFERIOR AL DEL 2013, CAMBIAR A EXCEL 8.0 Y EN VEZ DE
            //ACE.OLEDB.12.0 UTILIZAR LO SIGUIENTE (Jet.Oledb.4.0)
            string conexion = string.Format("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = {0}; Extended Properties = 'Excel 12.0;'", nombrearchivo);

            OleDbConnection conector = new OleDbConnection(conexion);


            conector.Open();

            //DEPENDIENDO DEL NOMBRE QUE TIENE LA PESTAÑA EN TU ARCHIVO EXCEL COLOCAR DENTRO DE LOS []
            OleDbCommand consulta = new OleDbCommand("select * from [Hoja1$]", conector);

            OleDbDataAdapter adaptador = new OleDbDataAdapter
            {
                SelectCommand = consulta
            };

            DataSet ds = new DataSet();

            adaptador.Fill(ds);

            conector.Close();

            return ds.Tables[0].DefaultView;
            */
        }

        void ListarUsuario()
        {
            dg_lista1.Sort(dg_lista1.Columns["Nombre completo de contacto"], ListSortDirection.Ascending);

            string nombre = "";
            string desc = "";
            int verifica = 0;

            int vueltas = 0;
            int cant_ticket = 0;

            int cant_registros = dg_lista1.RowCount - 1;

            string user = dg_lista1.Rows[0].Cells["Nombre completo de contacto"].Value.ToString();


            for (int i = 0; i < cant_registros; i++)
            {
                if (user == dg_lista1.Rows[i].Cells["Nombre completo de contacto"].Value.ToString())
                {
                    cant_ticket++;
                    (nombre, desc, verifica) = verificar(dg_lista1.Rows[i].Cells["Nombre completo de contacto"].Value.ToString(), 1);

                    if (verifica == 1)
                    {
                        this.dg_lista1.Rows[i].Cells["flag"].Value = "user";

                    }


                }
                else
                {


                    if (verifica == 1)
                    {
                        this.dg_lista0.Rows.Add(nombre, desc, cant_ticket, "0");

                    }


                    user = dg_lista1.Rows[i].Cells["Nombre completo de contacto"].Value.ToString();

                    cant_ticket = 0;
                    i--;
                }
                vueltas++;
            }


            (nombre, desc, verifica) = verificar(dg_lista1.Rows[cant_registros - 1].Cells["Nombre completo de contacto"].Value.ToString(), 1);

            if (verifica == 1)
            {
                this.dg_lista1.Rows[cant_registros - 1].Cells["flag"].Value = "user";
                this.dg_lista0.Rows.Add(nombre, desc + "@correoargentino.com.ar", cant_ticket, "0");
            }


        }

        void ListarSitios()
        {
            dg_lista1.Sort(dg_lista1.Columns["Ubicación"], ListSortDirection.Ascending);

            string nombre = "";
            string desc = "";
            int verifica = 0;
            int vueltas = 0;
            int cant_ticket = 0;


            if (dg_lista1.RowCount == 1)
            {
                lb_cant_sitios.Text = "No hay Sitios";
                lb_num_sitios.Hide();
            }
            else
            {
                int cant_registros = dg_lista1.RowCount - 1;
                string user = dg_lista1.Rows[0].Cells["Ubicación"].Value.ToString();


                for (int i = 0; i < cant_registros; i++)
                {



                    if (user == dg_lista1.Rows[i].Cells["Ubicación"].Value.ToString())
                    {
                        cant_ticket++;
                        (nombre, desc, verifica) = verificar(dg_lista1.Rows[i].Cells["Ubicación"].Value.ToString(), 2);

                        if (verifica == 1)
                        {
                            this.dg_lista1.Rows[i].Cells["flag"].Value = "sitio";
                        }


                    }
                    else
                    {


                        if (verifica == 1)
                        {
                            this.dg_lista0.Rows.Add(nombre, desc, cant_ticket, "1");

                        }


                        user = dg_lista1.Rows[i].Cells["Ubicación"].Value.ToString();

                        cant_ticket = 0;
                        i--;
                    }
                }
                vueltas++;



                (nombre, desc, verifica) = verificar(dg_lista1.Rows[cant_registros - 1].Cells["Ubicación"].Value.ToString(), 2);

                if (verifica == 1)
                {
                    this.dg_lista0.Rows.Add(nombre, desc, cant_ticket, "1");
                }

            }

        }

        void ListarNoEncontrados()
        {
            if (dg_lista1.RowCount > 1)
            {
                dg_lista1.Sort(dg_lista1.Columns["Ubicación"], ListSortDirection.Ascending);

                string nombre = "";
                string desc = "";
                int verifica = 0;
                int cant_ticket = 0;

                int cant_registros = dg_lista1.RowCount - 1;

                string nis = dg_lista1.Rows[0].Cells["Ubicación"].Value.ToString();


                for (int i = 0; i < cant_registros; i++)
                {


                    if (nis == dg_lista1.Rows[i].Cells["Ubicación"].Value.ToString())
                    {
                        cant_ticket++;
                        (nombre, desc, verifica) = verificar(dg_lista1.Rows[i].Cells["Ubicación"].Value.ToString(), 2);

                    }
                    else
                    {
                        if (verifica == 1)
                        {
                            this.dg_lista0.Rows.Add(nombre, desc, cant_ticket);

                        }
                        else
                        {
                            this.dg_lista1.Rows[i].Cells["flag"].Value = "No Encontrado";
                            this.dg_lista0.Rows.Add(dg_lista1.Rows[i - 1].Cells["Ubicación"].Value.ToString(), desc, dg_lista1.Rows[i - 1].Cells["Nombre completo de contacto"].Value.ToString(), "2");
                        }


                        nis = dg_lista1.Rows[i].Cells["Ubicación"].Value.ToString();

                        cant_ticket = 0;
                        i--;
                    }
                }


                (nombre, desc, verifica) = verificar(dg_lista1.Rows[cant_registros - 1].Cells["Ubicación"].Value.ToString(), 2);

                if (verifica == 1)
                {
                    this.dg_lista1.Rows[cant_registros - 1].Cells["flag"].Value = "No Encontrado";
                }
                else
                {
                    this.dg_lista1.Rows[cant_registros - 1].Cells["flag"].Value = "No Encontrado";
                    this.dg_lista0.Rows.Add(dg_lista1.Rows[cant_registros - 1].Cells["Ubicación"].Value.ToString(), desc, dg_lista1.Rows[cant_registros - 1].Cells["Nombre completo de contacto"].Value.ToString(), "2");
                }

            }


        }

        public (string, string, int) verificar(string valor, int tipo)
        {
            string nombre = "";
            string desc = "";

            if (tipo == 1)
            {
                if (cn4.State == ConnectionState.Open)
                {
                    cn4.Close();
                }

                cn4.Open();



                MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuarios WHERE nom_user ='" + valor + "'", cn4);
                try
                {
                    MySqlDataReader num = cmd.ExecuteReader();

                    if (num.HasRows)
                    {
                        if (num.Read())
                        {
                            nombre = num["nom_user"].ToString();
                            desc = num["correo_user"].ToString() + "@correoargentino.com.ar";
                        }

                        cn4.Close();
                        return (nombre, desc, 1);

                    }
                    else
                    {
                        cn4.Close();
                        return (" - ", "No Encontrado", 2);
                        
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("El descartó el usuario/sitio:" + valor + " debido a que el mismo tiene el caracter ' el cual no esta permitido", "Error: Apostrofe no permitidos");
                    cn4.Close();
                    return (" - ", "No Encontrado", 2);
                    
                }

            }
            else
            {
                if (cn4.State == ConnectionState.Open)
                {
                    cn4.Close();
                }


                cn4.Open();


                MySqlCommand cmd = new MySqlCommand("SELECT * FROM sitios WHERE nis_sitio ='" + valor + "'", cn4);
                try
                {
                    MySqlDataReader num = cmd.ExecuteReader();
                    if (num.HasRows)
                    {
                        if (num.Read())
                        {
                            nombre = num["desc_sitio"].ToString();
                            desc = num["correo_sitio"].ToString() + "@correoargentino.com.ar";
                        }

                        cn4.Close();
                        return (nombre, desc, 1);

                    }
                    else
                    {
                        cn4.Close();
                        return (" - ", "No Encontrado", 2);
                        

                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("El descartó el usuario/sitio:" + valor + " debido a que el mismo tiene el caracter ' el cual no esta permitido", "Error: Apostrofe no permitidos");
                    cn4.Close();
                    return (" - ", "No Encontrado", 2);
                    
                }

                
            }
            


        }


        public void sendMail(string destinatario, string asunto, string correo)
        {
            string codigoPS;

            string user_dir = Settings.Default["user"].ToString();

            

            string pathcodigoPS_txt = "C:\\Users\\" + user_dir + "\\AppData\\Roaming\\Mail\\Email.txt";
            //string pathcodigoPS_txt = @"C:\Users\Zextjchavez.B1842ZACP0188\Desktop\email-templates-master\Email.txt";
            //string pathcodigoPS_ps1 = @"C:\Users\Zextjchavez.B1842ZACP0188\Desktop\email-templates-master\Email.ps1";
            string pathcodigoPS_ps1 = "C:\\Users\\" + user_dir + "\\AppData\\Roaming\\Mail\\Email.ps1";

            try
            {
                codigoPS = File.ReadAllText(pathcodigoPS_txt);
            }
            catch (Exception e)
            {
                MessageBox.Show("Fallo la carga" + e);
                throw;
            }

            string usuario = user_dir.Replace(" ", "");
            try
            {
                
                string punto = usuario.Substring(usuario.IndexOf("."));
                usuario = usuario.Replace(punto, "");
            }
            catch (Exception)
            {
               
            }
            


            File.WriteAllText(pathcodigoPS_ps1, "");

            codigoPS = codigoPS.Replace("<table>", correo);
            codigoPS = codigoPS.Replace("*inicio*", cuerpo);
            codigoPS = codigoPS.Replace("*final*", final);
            codigoPS = codigoPS.Replace("*asunto*", asunto);
            codigoPS = codigoPS.Replace("*user*", usuario + "@correoargentino.com.ar");
            


            if (pbFirma.Image != null)
            {
                codigoPS = codigoPS.Replace("insertarImagen", "'" + pbFirma.ImageLocation + "'");

                codigoPS = codigoPS.Replace("***firma***", System.IO.Path.GetFileName(pbFirma.ImageLocation));
            }
            else
            {
                codigoPS = codigoPS.Replace("insertarImagen", "''");
                codigoPS = codigoPS.Replace("$EncodedAttachment =", "#$EncodedAttachment =");
                codigoPS = codigoPS.Replace("attachments = $Attachment;", null);
                codigoPS = codigoPS.Replace("<img id='firma' src='cid:***firma***' alt='firma'/>", null);
            }

            if (copia == "@correoargentino.com.ar" || copia == ";")
            {
                codigoPS = codigoPS.Replace("ccRecipients = $CcRecipients;", null);
                codigoPS = codigoPS.Replace("*copia*", "");

            }
            else
            {
                codigoPS = codigoPS.Replace("*copia*", copia);

            }



            if (destinatario == "mesadeayuda@correoargentino.com.ar" || destinatario == "otelegrafica@correoargentino.com.ar")
            {
                DialogResult result2 = MessageBox.Show("El Destinatario corresponde a un contacto que hace referencia a Tickets de creación Internoa de MDA. Desea Enviar el Mail de todas Formas??", "Alerta de Contacto interno", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result2 == DialogResult.Yes)
                {
                    codigoPS = codigoPS.Replace("*para*", destinatario);


                    try
                    {
                        StreamWriter sw = new StreamWriter(pathcodigoPS_ps1, false, Encoding.UTF8);
                        sw.Write(codigoPS.ToString());
                        sw.Close();


                        Process cmd2 = new Process();
                        cmd2.StartInfo.FileName = "cmd.exe";
                        cmd2.StartInfo.RedirectStandardInput = true;
                        cmd2.StartInfo.RedirectStandardOutput = true;
                        cmd2.StartInfo.CreateNoWindow = true;
                        cmd2.StartInfo.UseShellExecute = false;
                        cmd2.Start();
                        cmd2.StandardInput.WriteLine("@echo off");
                        cmd2.StandardInput.WriteLine("powershell -File " + "\u0022" + pathcodigoPS_ps1 + "\u0022");
                        cmd2.StandardInput.Flush();
                        cmd2.StandardInput.Close();
                        cmd2.WaitForExit();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al enviar el correo , vuelva a intentarlo mas tarde!!" + ex.ToString(), "Error de Envío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    File.WriteAllText(pathcodigoPS_ps1, "");
                }

            }
            else
            {
                codigoPS = codigoPS.Replace("*para*", destinatario);
                try
                {
                    StreamWriter sw = new StreamWriter(pathcodigoPS_ps1, false, Encoding.UTF8);
                    sw.Write(codigoPS.ToString());
                    sw.Close();

                    Process cmd2 = new Process();
                    cmd2.StartInfo.FileName = "cmd.exe";
                    cmd2.StartInfo.RedirectStandardInput = true;
                    cmd2.StartInfo.RedirectStandardOutput = true;
                    cmd2.StartInfo.CreateNoWindow = true;
                    cmd2.StartInfo.UseShellExecute = false;
                    cmd2.Start();
                    cmd2.StandardInput.WriteLine("@echo off");
                    cmd2.StandardInput.WriteLine("powershell -File " + "\u0022" + pathcodigoPS_ps1 + "\u0022");
                    cmd2.StandardInput.Flush();
                    cmd2.StandardInput.Close();
                    cmd2.WaitForExit();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al enviar el correo , vuelva a intentarlo mas tarde!!" + ex.ToString(), "Error de Envío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void bgW_mail_DoWork(object sender, DoWorkEventArgs e)
        {

            string Body_final = "";
            string Body = "";
            string Body_tabla = "";

            int HeaderCargado = 0;
            string contacto;

            int flag = 0;

            int cantidadSitios = dg_lista3.RowCount - 1;
            int cantidadUsuarios = dg_lista2.RowCount - 1;


            int indice = 0;



            Body_final = "</table>"; /*+
                                "<p>" + final + "</p>" +
                                "<p>Muchas Gracias</P>" +
                             "</BODY>" +
                        "</HTML>"; */

            Body = /*"<!DOCTYPE HTML PUBLIC>" +
                            "<HTML>" +
                                  "<BODY>" +

                                    "<p>Estimados,</p>" +
                                    "<p style='margin - left: 20px;'>" + cuerpo + "</p>" +*/
                                    "<table class='default' style= 'padding-left: 50px; border-collapse: collapse; border: 1px solid black; text-align: center; vertical-align: middle; margin-left: 55px;'>" +
                                    "<tr> " +
                                        "<th style= 'border: 1px solid black; padding: 2px;padding-left: 5px;'> TICKET</th>" +
                                        "<th style= 'border: 1px solid black; padding: 2px;padding-left: 5px;' > TITULO </th>";
            do
            {
                if (flag == 0)
                {


                    if (dg_lista2.RowCount > 1)
                    {

                        string user = dg_lista2.Rows[0].Cells["Nombre completo de contacto"].Value.ToString();


                        for (int i = 0; i < cantidadUsuarios; i++)
                        {
                            if ((bgW_mail.CancellationPending == true))
                            {
                                e.Cancel = true;
                            }



                            if (user == dg_lista2.Rows[i].Cells["Nombre completo de contacto"].Value.ToString())
                            {
                                bgW_mail.ReportProgress(1, user);

                                Body_tabla = Body_tabla + "</tr>" +
                                    "<tr> " +
                                                               "<td style ='border: 1px solid black; padding: 2px;padding-left: 5px;'>" + dg_lista2.Rows[i].Cells["ID de la interacción"].Value.ToString() + " </td>" +
                                                               "<td style ='border: 1px solid black; padding: 2px;padding-left: 5px;'>" + dg_lista2.Rows[i].Cells["Título"].Value.ToString() + " </td> ";

                            }
                            else
                            {


                                contacto = traerContacto(dg_lista2.Rows[i - 1].Cells["Nombre completo de contacto"].Value.ToString(), 0);

                                sendMail(contacto, asunto, (Body + Body_tabla + Body_final));

                                bgW_mail.ReportProgress(2, user);

                                Body_tabla = "";

                                user = dg_lista2.Rows[i].Cells["Nombre completo de contacto"].Value.ToString();

                                Body_tabla = Body_tabla + "</tr>" +
                                           "<tr>" +
                                                "<td style ='border: 1px solid black; padding: 2px;padding-left: 5px;'>" + dg_lista2.Rows[i].Cells["ID de la interacción"].Value.ToString() + " </td>" +
                                                "<td style ='border: 1px solid black; padding: 2px;padding-left: 5px;'>" + dg_lista2.Rows[i].Cells["Título"].Value.ToString() + " </td> ";


                            }

                            indice = i;
                        }


                        contacto = traerContacto(dg_lista2.Rows[indice].Cells["Nombre completo de contacto"].Value.ToString(), 0);
                        sendMail(contacto, asunto, (Body + Body_tabla + Body_final));

                        bgW_mail.ReportProgress(3, user);

                        Body_tabla = "";

                    }
                    flag++;
                }
                else
                {
                    if (dg_lista3.RowCount < 2)
                    {
                        //MessageBox.Show("No se encontraron sitios en el archivo cargado", "Sitios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bgW_mail.ReportProgress(1, "Sin sitios Cargados");

                    }
                    else
                    {
                        string nis = dg_lista3.Rows[0].Cells["Ubicación"].Value.ToString();

                        for (int i = 0; i < cantidadSitios; i++)
                        {


                            if (nis == dg_lista3.Rows[i].Cells["Ubicación"].Value.ToString())
                            {
                                bgW_mail.ReportProgress(1, nis);

                                if (HeaderCargado == 0)
                                {
                                    Body_tabla = Body_tabla +
                                         "<th style= 'border: 1px solid black; padding: 2px;padding-left: 5px;'> CONTACTO </th>" +
                                       "</tr>";

                                }
                                Body_tabla = Body_tabla +
                                       "<tr>" +
                                        "<td style ='border: 1px solid black; padding: 2px;padding-left: 5px;'>" + dg_lista3.Rows[i].Cells["ID de la interacción"].Value.ToString() + " </td>" +
                                        "<td style ='border: 1px solid black; padding: 2px;padding-left: 5px;'>" + dg_lista3.Rows[i].Cells["Título"].Value.ToString() + " </td> " +
                                        "<td style ='border: 1px solid black; padding: 2px;padding-left: 5px;'>" + dg_lista3.Rows[i].Cells["Nombre completo de contacto"].Value.ToString() + " </td> " +
                                       "</tr>";
                                HeaderCargado = 1;

                            }
                            else
                            {


                                contacto = traerContacto(dg_lista3.Rows[i - 1].Cells["Ubicación"].Value.ToString(), 1);
                                sendMail(contacto, asunto, (Body + Body_tabla + Body_final));

                                bgW_mail.ReportProgress(2, nis);

                                Body_tabla = "";

                                Body_tabla = Body_tabla +
                                         "<th style= 'border: 1px solid black; padding: 2px;padding-left: 5px;'> CONTACTO </th>" +
                                       "</tr>";
                                nis = dg_lista3.Rows[i].Cells["Ubicación"].Value.ToString();

                                Body_tabla = Body_tabla +
                                       "<tr>" +
                                         "<td style ='border: 1px solid black; padding: 2px;padding-left: 5px;'>" + dg_lista3.Rows[i].Cells["ID de la interacción"].Value.ToString() + " </td>" +
                                         "<td style ='border: 1px solid black; padding: 2px;padding-left: 5px;'>" + dg_lista3.Rows[i].Cells["Título"].Value.ToString() + " </td> " +
                                         "<td style ='border: 1px solid black; padding: 2px;padding-left: 5px;'>" + dg_lista3.Rows[i].Cells["Nombre completo de contacto"].Value.ToString() + " </td> " +
                                       "</tr>";
                                HeaderCargado = 1;


                            }
                            indice = i;
                        }

                        contacto = traerContacto(dg_lista3.Rows[indice].Cells["Ubicación"].Value.ToString(), 1);
                        sendMail(contacto, asunto, (Body + Body_tabla + Body_final));

                        bgW_mail.ReportProgress(3, nis);

                        Body_tabla = "";

                    }
                    flag++;
                }


            } while (flag < 2);
        }

        public string traerContacto(string contacto, int op)
        {


            string valor = contacto;
            int tipo = op;
            string devuelve = "";

            if (cn4.State == ConnectionState.Open)
            {
                cn4.Close();
            }

            if (op == 0)
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuarios WHERE nom_user ='" + valor + "'", cn4);
                cn4.Open();
                MySqlDataReader num = cmd.ExecuteReader();
                if (num.HasRows)
                {
                    if (num.Read())
                    {

                        devuelve = num["correo_user"].ToString() + "@correoargentino.com.ar";
                        cn4.Close();
                        return devuelve;
                    }
                }
                else
                {
                    return devuelve;
                }
            }
            else
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM sitios WHERE nis_sitio ='" + valor + "'", cn4);
                cn4.Open();
                MySqlDataReader num = cmd.ExecuteReader();
                if (num.HasRows)
                {
                    if (num.Read())
                    {

                        devuelve = num["correo_sitio"].ToString() + "@correoargentino.com.ar";
                        cn4.Close();
                        return devuelve;
                    }
                }
                else
                {
                    return devuelve;
                }
            }
            cn4.Close();
            return devuelve;
        }

        private void bgW_mail_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int progreso = progressBar1.Value;
            if (e.ProgressPercentage == 1)
            {
                progressBar1.Value = progreso + 1;
                label64.Text = (Convert.ToInt32(label64.Text) + 1).ToString();
                tb_enviando.Text = e.UserState.ToString();

            }
            else if (e.ProgressPercentage == 2)
            {
                if (Convert.ToInt32(label64.Text) == 0)
                {
                    label64.Text = (Convert.ToInt32(label64.Text) + 1).ToString();
                    tb_enviando.Text = e.UserState.ToString();
                    progressBar1.Value = progreso + 1;
                    dg_enviados.Rows.Add(e.UserState.ToString(), label64.Text, "✔✔ Enviado");
                    label64.Text = "0";
                }
                else if (Convert.ToInt32(label64.Text) > 0)
                {
                    label64.Text = (Convert.ToInt32(label64.Text)).ToString();
                    tb_enviando.Text = e.UserState.ToString();
                    progressBar1.Value = progreso + 1;
                    dg_enviados.Rows.Add(e.UserState.ToString(), label64.Text, "✔✔ Enviado");
                    label64.Text = "0";
                }


            }
            else
            {

                if (Convert.ToInt32(label64.Text) == 0)
                {
                    label64.Text = (Convert.ToInt32(label64.Text) + 1).ToString();
                    tb_enviando.Text = e.UserState.ToString();
                    dg_enviados.Rows.Add(e.UserState.ToString(), label64.Text, "✔✔ Enviado");
                    label64.Text = "0";
                }
                else if (Convert.ToInt32(label64.Text) > 0)
                {
                    label64.Text = (Convert.ToInt32(label64.Text)).ToString();
                    tb_enviando.Text = e.UserState.ToString();
                    dg_enviados.Rows.Add(e.UserState.ToString(), label64.Text, "✔✔ Enviado");
                    label64.Text = "0";
                }


            }

        }

        private void bgW_mail_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled)
            {
                MessageBox.Show("Se ha interrumpido el envío de los correos!!!");
                limpiar();
            }
            else
            {
                MessageBox.Show("Finalizo el envío de los Correos!!!");

                groupBox8.Show();
                pictureBox31.Show();

                groupBox14.Hide();
                groupBox18.Hide();
                pictureBox38.Hide();
                Form1.ActiveForm.AutoSize = true;

            }


        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {
            bgW_mail.CancelAsync();

        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            if (pbFirma.ImageLocation != null)
            {
                DialogResult result = MessageBox.Show("Ya se encuentra una firma cargada en la aplicación, Quiere cargar una nueva?", "Firma Cargada", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    cargaFirma();
                }
            }
            else
            {
                cargaFirma();
            }
        }

        void cargaFirma()
        {


            OpenFileDialog ImagenFile = new OpenFileDialog();

            string filtro = "imagen| *. png; *.jpg";

            ImagenFile.Filter = filtro;
            ImagenFile.Title = "Cargar imagen con Firma";
            try
            {

                ImagenFile.Filter = filtro;
                ImagenFile.Title = "Cargar imagen con Firma";

                if (ImagenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (!ImagenFile.FileName.Equals(""))
                    {
                        pbFirma.ImageLocation = ImagenFile.FileName;


                        Settings.Default["firma"] = ImagenFile.FileName;
                        Settings.Default.Save();
                    }
                    else
                    {
                        pbFirma.ImageLocation = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fallo la carga de la imagen", MessageBoxButtons.OK);

            }
            finally
            {
                ImagenFile.Dispose();
            }
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            groupBox14.Show();
            dg_lista0.Hide();
            dg_enviados.Show();
            groupBox8.Hide();

            groupBox18.Show();
            pictureBox38.Show();

            pictureBox31.Hide();
            pictureBox30.Hide();

            tabControl2.AutoSize = true;
            tabControl2.Refresh();

            Form1.ActiveForm.Size = new Size(346, 100);
            Form1.ActiveForm.AutoSize = true;

            

            int max = dg_lista2.RowCount + dg_lista3.RowCount;

            progressBar1.Maximum = max;
            progressBar1.Step = 1;
            progressBar1.Value = 0;

            if (pbFirma.Image != null)
            {

                validation();

            }
            else
            {
                DialogResult result1 = MessageBox.Show("No se cencuentra una Firma Cargada, Desea enviar de todas formas? \n *Elija NO para cargar una firma nueva*", "Sin Firma", MessageBoxButtons.YesNo);


                if (result1 == DialogResult.No)
                {

                    OpenFileDialog openFileDialog = new OpenFileDialog
                    {
                        //DE ESTA MANERA FILTRAMOS TODOS LOS ARCHIVOS EXCEL EN EL NAVEGADOR DE ARCHIVOS
                        Filter = "Excel | *.png;",

                        //AQUÍ INDICAMOS QUE NOMBRE TENDRÁ EL NAVEGADOR DE ARCHIVOS COMO TITULO
                        Title = "Seleccionar Imagen para Firma"
                    };

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filename = openFileDialog.FileName;
                        Settings.Default["firma"] = filename.ToString();
                        Settings.Default.Save();
                        pbFirma.ImageLocation = Settings.Default["firma"].ToString();
                        validation();
                    }

                }
                else if (result1 == DialogResult.Yes)
                {
                    validation();

                }
            }
        }

        public void validation()
        {
            if (bgW_mail.IsBusy != true)
            {
                bgW_mail.WorkerSupportsCancellation = true;
                bgW_mail.RunWorkerAsync();
            }

        }

        void limpiar()
        {

            dg_lista0.Rows.Clear();
            dg_lista0.Refresh();
            if (dg_lista1.Rows.Count <= 0)
            {
                dg_lista1.Rows.Clear();
                dg_lista1.Refresh();
            }

            dg_lista2.Rows.Clear();
            dg_lista2.Refresh();
            dg_lista3.Rows.Clear();
  

            groupBox8.Show();
            dg_lista0.Show();

            Form1.ActiveForm.AutoSize = true;
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pbFirma.ImageLocation = null;
            Settings.Default["firma"] = null;
            Settings.Default.Save();
            pictureBox29.Refresh();
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            pbFirma.ImageLocation = null;
            Settings.Default["firma"] = null;

        }

        private void dg_lista0_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dg_lista0.CurrentRow.Cells[3].Value.ToString() == "0")
            {
                tb_user_modi.Text = dg_lista0.CurrentRow.Cells[0].Value.ToString();
                tb_sitio_modi.Text = "";
                tabControl3.SelectedIndex = 1;

                tabPage8.Parent = null;
                tabPage5.Parent = null;
                tabPage7.Parent = tabControl3;

                btn_modi_sitio.Hide();
                btn_modi_user.Hide();
                button4.Show();
                button5.Show();

                string user = dg_lista0.CurrentRow.Cells[0].Value.ToString();
                MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM usuarios WHERE nom_user='" + user + "';", cn4);
                if (cn4.State == ConnectionState.Open)
                {
                    cn4.Close();
                }
                cn4.Open();
                MySqlDataReader registro = cmd2.ExecuteReader();
                if (registro.Read())
                {
                    tb_correo_user_modi.Text = registro["correo_user"].ToString();

                    cn4.Close();
                }
            }
            else if (dg_lista0.CurrentRow.Cells[3].Value.ToString() == "1")
            {
                tb_sitio_modi.Text = dg_lista0.CurrentRow.Cells[0].Value.ToString();
                tb_user_modi.Text = "";
                tabControl3.SelectedIndex = 0;

                tabPage8.Parent = null;
                tabPage7.Parent = null;
                tabPage5.Parent = tabControl3;

                btn_modi_sitio.Hide();
                btn_modi_user.Show();
                button4.Show();
                button5.Show();

                string sitio = dg_lista0.CurrentRow.Cells[0].Value.ToString();
                MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM sitios WHERE desc_sitio='" + sitio + "';", cn4);
                if (cn4.State == ConnectionState.Open)
                {
                    cn4.Close();
                }
                cn4.Open();
                MySqlDataReader registro = cmd2.ExecuteReader();
                if (registro.Read())
                {
                    tb_correo_sitio_modi.Text = registro["correo_sitio"].ToString();
                    tb_desc_modi.Text = registro["desc_sitio"].ToString();
                    cn4.Close();
                }
            }
            else
            {
                tb_user_modi.Text = dg_lista0.CurrentRow.Cells[2].Value.ToString();
                tb_sitio_modi.Text = dg_lista0.CurrentRow.Cells[0].Value.ToString();
                button4.Hide();
                button5.Hide();
                btn_modi_sitio.Show();
                btn_modi_user.Show();
                tabPage8.Parent = tabControl3;
                tabPage7.Parent = tabControl3;
                tabControl3.SelectedIndex = 2;
            }

            tabControl2.Hide();
            tabControl3.Show();
            tabControl3.Location = tabControl2.Location;
            tabControl3.Height = tabControl2.Height;
            tabControl3.Width = tabControl2.Width;
            Form1.ActiveForm.Size = new Size(346, 54);
            Form1.ActiveForm.AutoSize = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl2.Show();
            tabControl3.Hide();
            Form1.ActiveForm.Size = new Size(346, 54);
            Form1.ActiveForm.AutoSize = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sitio = tb_sitio_modi.Text;
            string desc = sitio + " - " + tb_desc_modi.Text;
            string correo = tb_correo_sitio_modi.Text;


            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE sitios SET nis_sitio = '" + sitio + "', correo_sitio= '" + correo + "' WHERE desc_sitio ='" + desc + "';", cn4);

                if (cn4.State == ConnectionState.Open)
                {
                    cn4.Close();
                }
                cn4.Open();
                cmd.ExecuteReader();
                cn4.Close();
                DialogResult result = MessageBox.Show("La Actualización de los Datos del Sitio fue Exitosa, Debe recargar la Pagina para que retome la verificación de sitios", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    dg_lista0.CurrentRow.Cells[1].Value = correo + "@Correoargentino.com.ar";
                    dg_lista0.CurrentRow.Cells[2].Value = "1+";
                    button3.PerformClick();
                    tb_desc_modi.Text = "";
                    tb_correo_sitio_modi.Text = "";
                }




                /*
                dg_lista0.Rows.Clear();
                dg_lista0.Refresh();
                if (dg_lista1.Rows.Count <= 0)
                {
                    dg_lista1.Rows.Clear();
                    dg_lista1.Refresh();
                }

                dg_lista2.Rows.Clear();
                dg_lista2.Refresh();
                dg_lista3.Rows.Clear();
                dg_lista3.Refresh();

                cargadedatos(filename);
                */
            }
            catch (Exception)
            {

                MessageBox.Show("Se produjo un error al actualizar los dato en la BBDD", "Error en el Actualización de Sitio/Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button3.PerformClick();
            }

            tb_sitio_modi.Text = "";
            tb_desc_modi.Text = "";
            tb_correo_sitio_modi.Text = "";
        }

        private void btn_modi_sitio_Click(object sender, EventArgs e)
        {


            string sitio = tb_sitio_modi.Text;
            string desc = sitio + " - " + tb_desc_modi.Text;
            string correo = tb_correo_sitio_modi.Text;

            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO sitios(nis_sitio, correo_sitio, desc_sitio) VALUES ('" + sitio + "','" + correo + "','" + desc + "');", cn4);
                if (cn4.State == ConnectionState.Open)
                {
                    cn4.Close();
                }
                cn4.Open();
                cmd.ExecuteReader();
                cn4.Close();
                DialogResult result = MessageBox.Show("La carga del Sitio fue Exitosa, Se recargará la Pagina para que recargue la verificación de sitios", "Carga exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    dg_lista0.CurrentRow.Cells[1].Value = correo + "@Correoargentino.com.ar";
                    dg_lista0.CurrentRow.Cells[2].Value = "1+";
                    button3.PerformClick();
                    tb_desc_modi.Text = "";
                    tb_correo_sitio_modi.Text = "";
                }




                /*
                dg_lista0.Rows.Clear();
                dg_lista0.Refresh();
                if (dg_lista1.Rows.Count <= 0)
                {
                    dg_lista1.Rows.Clear();
                    dg_lista1.Refresh();
                }

                dg_lista2.Rows.Clear();
                dg_lista2.Refresh();
                dg_lista3.Rows.Clear();
                dg_lista3.Refresh();

                cargadedatos(filename);
                */
            }
            catch (Exception)
            {

                MessageBox.Show("Se produjo un error al cargar el dato en la BBDD", "Error en el Alta de Sitio/Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button3.PerformClick();
            }



            tb_sitio_modi.Text = "";
            tb_desc_modi.Text = "";
            tb_correo_sitio_modi.Text = "";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl2.Show();
            tabControl3.Hide();
            Form1.ActiveForm.Size = new Size(346, 54);
            Form1.ActiveForm.AutoSize = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string user = tb_user_modi.Text;
            string correo = tb_correo_user_modi.Text;

            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE usuarios SET correo_user='" + correo + "' WHERE nom_user = '" + user + "';", cn4);

                if (cn4.State == ConnectionState.Open)
                {
                    cn4.Close();
                }
                cn4.Open();
                cmd.ExecuteReader();
                cn4.Close();
                DialogResult result = MessageBox.Show("La Actualización de los Datos del Usuario fue Exitosa, Debe recargar la Pagina para que retome la verificación de sitios", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {

                    dg_lista0.CurrentRow.Cells[1].Value = correo + "@Correoargentino.com.ar";
                    dg_lista0.CurrentRow.Cells[2].Value = "1+";
                    button3.PerformClick();
                    tb_correo_user_modi.Text = "";
                }



                /*
                dg_lista0.Rows.Clear();
                dg_lista0.Refresh();
                if (dg_lista1.Rows.Count <= 0)
                {
                    dg_lista1.Rows.Clear();
                    dg_lista1.Refresh();
                }

                dg_lista2.Rows.Clear();
                dg_lista2.Refresh();
                dg_lista3.Rows.Clear();
                dg_lista3.Refresh();

                cargadedatos(filename);

                */
            }
            catch (Exception)
            {
                MessageBox.Show("Se produjo un error al actualizar los dato en la BBDD", "Error en la Actualización de Sitio/Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button3.PerformClick();
            }

            tb_user_modi.Text = "";
            tb_correo_user_modi.Text = "";
        }

        private void btn_modi_user_Click(object sender, EventArgs e)
        {
            string user = tb_user_modi.Text;
            string correo = tb_correo_user_modi.Text;

            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO usuarios(nom_user, correo_user) VALUES ('" + user + "','" + correo + "');", cn4);

                if (cn4.State == ConnectionState.Open)
                {
                    cn4.Close();
                }
                cn4.Open();
                cmd.ExecuteReader();
                cn4.Close();
                DialogResult result = MessageBox.Show("La carga del Usuario fue Exitosa, Debe recargar la Pagina para que retome la verificación de sitios", "Carga exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {

                    dg_lista0.CurrentRow.Cells[1].Value = correo + "@Correoargentino.com.ar";
                    dg_lista0.CurrentRow.Cells[2].Value = "1+";
                    button6.PerformClick();
                    tb_correo_user_modi.Text = "";
                }



                /*

                dg_lista0.Rows.Clear();
                dg_lista0.Refresh();
                if (dg_lista1.Rows.Count <= 0)
                {
                    dg_lista1.Rows.Clear();
                    dg_lista1.Refresh();
                }

                dg_lista2.Rows.Clear();
                dg_lista2.Refresh();
                dg_lista3.Rows.Clear();
                dg_lista3.Refresh();

                cargadedatos(filename);

                */
            }
            catch (Exception)
            {
                MessageBox.Show("Se produjo un error al cargar el dato en la BBDD", "Error en el Alta de Sitio/Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button3.PerformClick();
            }

            tb_user_modi.Text = "";
            tb_correo_user_modi.Text = "";
        }

        private void textBox6_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                copia = textBox6.Text;
                copia = copia.Replace(";", "@correoargentino.com.ar;");
                Settings.Default["cc"] = copia + "@correoargentino.com.ar";
                Settings.Default.Save();
                copia = Settings.Default["cc"].ToString();
                string pasador = Settings.Default["cc"].ToString().Replace("@correoargentino.com.ar", ";");
                textBox6.Text = pasador.Replace(";;", ";");

            }
        }

        private void pb_plus_Click(object sender, EventArgs e)
        {
            tituS titu = new tituS();
            titu.Show();
        }

        //////////////////////////////////////////////////////////////////////////////////
        ///////////////////////// MOVIMIENTO DE MENU  ////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////


       
        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

            
        }
        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            int barW = Screen.PrimaryScreen.WorkingArea.Width;

            if (this.Location.X != barW - 55)
            {
                this.Location = new Point( this.Location.X - 12, this.Location.Y);
            }
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            int barW = Screen.PrimaryScreen.WorkingArea.Width;

            if (this.Location.X == barW - 50)
            {
                this.Location = new Point(this.Location.X + 12, this.Location.Y);
            }
            
        }

        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            int flag = 0;
            if ((top <= top1 + 2 && top >= top1 - 2) || top == 0)
            {
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.GetType() == typeof(menu_r))
                    {

                        flag = 1;

                        break;
                    }

                }

                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.GetType() == typeof(HMDA.pMenu.menu_r.HMDA))
                    {

                        flag = 2;

                        break;
                    }

                }


                if (flag == 0)
                {
                    menu_r menu = new menu_r();
                    menu.Show();
                    menu.Location = new Point(this.Location.X - 88, this.Location.Y - 70);
                    this.Location = new Point(this.Location.X - 5, this.Location.Y);
                }
                else if (flag == 1)
                {/*
                    //MessageBox.Show("menu_r_Cierre");
                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm.GetType() == typeof(menu_r))
                        {

                            frm.Close();
                            int barW = Screen.PrimaryScreen.WorkingArea.Width;
                            this.Location = new Point(barW - 38, this.Location.Y);
                            break;
                        }

                    }

                    /*
                    HMDA.pMenu.menu_r.submenu1 sub = new HMDA.pMenu.menu_r.submenu1();
                    sub.Show();
                    sub.Location = new Point(this.Location.X - 220, this.Location.Y - 112);
                    */
                }
                else if (flag == 2)
                {
                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm.GetType() == typeof(HMDA.pMenu.menu_r.HMDA))
                        {

                            frm.Close();

                            break;
                        }

                    }

                }

            }
            else
            {
                top1 = this.Location.Y;

            }



            //modo_vista();
        }

        //PASO 1: declarar como globales
        public int top, top1 , yClick = 0;



        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button != MouseButtons.Left)
            {
                yClick = e.Y;
            }
            else
            {

            this.Top = this.Top + (e.Y - yClick);
            top = this.Top;
                
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.GetType() == typeof(menu_r))
                    {

                        frm.Location = new Point(this.Location.X - 88, this.Location.Y - 70);
                        break;
                    }
                    if (frm.GetType() == typeof(HMDA.pMenu.menu_r.HMDA)){
                        frm.Location = new Point(this.Location.X - 220, this.Location.Y - 112);
                        break;
                    }

                }
                
            }

            

           

        }

        //////////////////////////////////////////////////////////////////////////////////
        ///////////////////////// VARIOS  ////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////

        private void menu_kitty_Opened(object sender, EventArgs e)
        {
            cb_menuK.Items.Clear();
            string user_dir = Settings.Default["user"].ToString();
            DirectoryInfo di = new DirectoryInfo("C:\\Users\\" + user_dir + "\\AppData\\Roaming\\kitty\\Sessions");
            FileInfo[] files = di.GetFiles("*.");
            rellenaCombo(cb_menuK, files);
        }


        void rellenaCombo(ToolStripComboBox cb, FileInfo[] path)
        {
            cb.Items.Clear();
            for (int i = 1; i < path.Length; i++)
            {
                cb.Items.Add(path[i]);
            }
            
        }


        private void cb_menuK_SelectedIndexChanged_1(object sender, EventArgs e)
        {
         
            menu_kitty.Close();

            ProcessStartInfo cmd = new ProcessStartInfo();
            string user_dir = Settings.Default["user"].ToString();
            cmd.FileName = "C:\\Users\\" + user_dir + "\\AppData\\Roaming\\kitty\\kitty.exe";
            cmd.UseShellExecute = false;
            cmd.RedirectStandardInput = false;
            cmd.RedirectStandardOutput = true;
            cmd.Arguments = "-load " + cb_menuK.Text;
            Process process = Process.Start(cmd);
        }

        private void opcion1_Click(object sender, EventArgs e)
        {
            if (this.TopMost == true)
            {
                this.TopMost = false;
                opcion1.Text = "Fijar al Frente";
                Settings.Default["Fijar"] = true;
                Settings.Default.Save();
            }
            else
            {
                this.TopMost = true;
                opcion1.Text = opcion1.Text + "  ✔";
                Settings.Default["Fijar"] = true;
                Settings.Default.Save();
            }
            
        }

    }

    
}
