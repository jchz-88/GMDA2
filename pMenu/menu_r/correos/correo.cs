
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel;
using Microsoft.Graph.Models;
using Microsoft.Graph;
using Microsoft.Kiota.Abstractions.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using HMDA.Properties;
using Windows.ApplicationModel.Contacts;
using MySql.Data.MySqlClient;
using HMDA;
using System.Diagnostics.Contracts;
using DocumentFormat.OpenXml.EMMA;
using Windows.Data.Text;
using HMDA.pMenu.menu_r.correos;
using System.IO;
using System.Security.Cryptography;
using Microsoft.Kiota.Abstractions;

namespace Listas
{
    public partial class correo : Form
    {

        //TokenCache tokenCache;

        //Set the API Endpoint to Graph 'me' endpoint. 
        // To change from Microsoft public cloud to a national cloud, use another value of graphAPIEndpoint.
        // Reference with Graph endpoints here: https://docs.microsoft.com/graph/deployments#microsoft-graph-and-graph-explorer-service-root-endpoints
        //string graphAPIEndpoint = "https://graph.microsoft.com/v1.0/me";
        string graphAPIEndpoint = "https://login.microsoftonline.com/common/oauth2/nativeclient";
        //Set the scope for API call to user.read
        string[] scopes = new string[] { "user.read", "Mail.send" };

        //Conexión a BBDD de Usuarios/Sitios - Mails Automaticos

        MySqlConnection con = new MySqlConnection();


        public correo()
        {
            InitializeComponent();

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            int barH = Screen.PrimaryScreen.WorkingArea.Height;
            int barW = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = new Point(barW / 2 - 250, barH / 2 - 350);

            con = conexiones.getInstancia().CrearConexion("gmda");

            pictureBox2.Hide();
            pictureBox3.Hide();
            pictureBox4.Hide();

            panel_agregar.Hide();


            panel2.Hide();

            firma.Hide();
            tabPage2.Parent = null;
            tabPage3.Parent = null;
            tabPage4.Parent = null;

            this.BackColor = Color.Black;
            this.Opacity = 0.92;

            //cb1.SelectionChangeCommitted += new EventHandler(selec_cb);
            //cb2.SelectionChangeCommitted += new EventHandler(selec_cb);

            lb1.Click += new EventHandler(activar_contacto);
            ch1.Visible = false; ch1.Visible = false;

            //cargar_combo(2);

            firma.ImageLocation = Settings.Default["firma"].ToString();
            if (firma.ImageLocation != null)
            {
                pb_sign_off.Hide();
                pb_sign_on.Show();
                pb_sign_on.BringToFront();
            }

            ch1.Hide();

        }

        /*
        private void cargar_combo(int f)
        {

            for (int i = 1; i < f + 1; i++)
            {
                ComboBox cb = tabPage1.Controls["cb" + i] as ComboBox;
                cb.Items.Clear();
                for (int j = 1; j < f + 1; j++)
                {
                    cb.Items.Add(j);
                }
                cb.SelectedIndex = i - 1;
            }

        }
        
        private void selec_cb(object sender, EventArgs e)
        {

            ComboBox c = sender as ComboBox;

            string IndexEntrante = c.Name.Substring(2, 1);

            TextBox tE = tabPage1.Controls["tb" + IndexEntrante] as TextBox;
            Label laE = tabPage1.Controls["lb" + IndexEntrante] as Label;

            Point tx = new Point(tE.Location.X, tE.Location.Y);
            Point lax = new Point(laE.Location.X, laE.Location.Y);

            string indexDestino = (c.SelectedIndex + 1).ToString();

            TextBox tD = tabPage1.Controls["tb" + indexDestino] as TextBox;
            Label laD = tabPage1.Controls["lb" + indexDestino] as Label;

            Point ty = new Point(tD.Location.X, tD.Location.Y);
            Point lay = new Point(laD.Location.X, laD.Location.Y);

            tE.Location = ty;
            tD.Location = tx;


            MessageBox.Show(laE.Name + " " + lay.ToString() + "////" + laD.Name + " " + lax.ToString());

            laE.Location = lay;
            laD.Location = lax;

            tE.Name = "tb" + indexDestino;
            tD.Name = "tb" + IndexEntrante;

            laE.Name = "lb" + indexDestino;
            laD.Name = "lb" + IndexEntrante;

            c.SelectedIndex = int.Parse(c.Name.Substring(2, 1)) - 1;
        }

        */


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            agregarCol();
            panel2.Location = new Point((tabPage1.Width / 2) - (panel2.Width / 2), panel2.Location.Y);
            pictureBox3.Location = new Point((tabPage1.Width / 2) - (pictureBox3.Width / 2), pictureBox3.Location.Y);
            pictureBox4.Location = new Point((tabPage1.Width / 2) - (pictureBox4.Width / 2), pictureBox4.Location.Y);
            pb_close.Location = new Point(tabPage1.Width - pb_close.Width - 1, pb_close.Location.Y);
        }

        int column1 = 2;
        private void agregarCol()
        {
            int columnas = dataGridView1.ColumnCount;

            if (columnas > 6)
            {
                columnas = 6;
            }

            if (column1 < columnas)
            {
                int tbx = pictureBox1.Location.X;
                int tby = this.tb.Location.Y;
                int lbx = pictureBox1.Location.X;
                int lby = lb1.Location.Y;
                int chx = pictureBox1.Location.X + tb1.Width - this.ch1.Width;
                int chy = this.ch1.Location.Y;
                //int cbx = pictureBox1.Location.X + 52;
                //int cby = tb2.Location.Y + cb2.Height + 4;
                int laby = lb1.Location.Y;
                int labx = pictureBox1.Location.X;

                Label lab = new Label();
                lab.Location = new Point(labx, laby);
                lab.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                lab.Size = new Size(82, 20);
                lab.TabIndex = 4;
                lab.Text = "Contacto";
                lab.ForeColor = Color.FromArgb(64, 64, 64);
                tabPage1.Controls.Add(lab);
                lab.Cursor = Cursors.Hand;
                lab.Click += new EventHandler(activar_contacto);


                TextBox tb = new TextBox();
                tb.Location = new Point(tbx, tby);
                tb.Size = new Size(100, 25);
                tabPage1.Controls.Add(tb);
                tb.MouseClick += new MouseEventHandler(menu_tb);
                tb.KeyPress += new KeyPressEventHandler(actualizar_tb);
                tb.Cursor = Cursors.Hand;
                tb.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
                tb.ReadOnly = true;


                CheckBox ch = new CheckBox();
                ch.Location = new Point(chx, chy);
                ch.Size = new Size(15, 15);
                tabPage1.Controls.Add(ch);
                ch.Visible = false;
                ch.Cursor = Cursors.Hand;

                tb.Name = "tb" + (column1).ToString();
                ch.Name = "ch" + (column1).ToString();
                lab.Name = "lb" + (column1).ToString();
                tabControl1.Size = new Size(tabControl1.Width + tb.Width + 5, tabControl1.Height);
                this.Size = tabControl1.Size;

                pictureBox1.Location = new Point(pictureBox1.Location.X + 105, pictureBox1.Location.Y);
                


                pictureBox2.Show();
                column1++;

                /*
                
                ComboBox cb = new ComboBox();
                cb.Location = new Point(cbx, cby);
                cb.Size = new Size(46, 21);
                tabPage1.Controls.Add(cb);

                cb.SelectionChangeCommitted += new EventHandler(selec_cb);
                */

                if (column1 == columnas)
                {

                    //cb.Name = "cb5";

                    pictureBox2.Show();
                    pictureBox1.Hide();

                    //cargar_combo(5);
                }


            }

        }

        private void activar_contacto(object sender, EventArgs e)
        {
            int i = 0;

            CheckBox chX;

            Label lb = sender as Label;
            if (lb.Name == "lb")
            {
                chX = tabPage1.Controls["ch"] as CheckBox;
            }
            else
            {
                string IndexEntrante = lb.Name.Substring(2, 1);
                chX = tabPage1.Controls["ch" + IndexEntrante] as CheckBox;
            }


            foreach (Control controles in tabPage1.Controls)
            {
                if (controles is Label)
                {
                    if (controles.ForeColor == Color.GreenYellow)
                    {
                        i++;
                    }

                }
            }

            if (lb.ForeColor == Color.FromArgb(64, 64, 64))
            {
                if (i == 0)
                {
                    lb.ForeColor = Color.GreenYellow;
                    chX.Visible = true;
                    //lb.Text = "Contacto";
                }
                else if (i == 1)
                {
                    MessageBox.Show("Solo es posible agregar una columna de Contactos");

                }

            }
            else
            {
                lb.ForeColor = Color.FromArgb(64, 64, 64);
                chX.Visible = false;
                chX.Checked = false;
            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            quitar_columnas();
            panel2.Location = new Point((tabPage1.Width / 2) - (panel2.Width / 2), panel2.Location.Y);
            pictureBox3.Location = new Point((tabPage1.Width / 2) - (pictureBox3.Width / 2), pictureBox3.Location.Y);
            pictureBox4.Location = new Point((tabPage1.Width / 2) - (pictureBox4.Width / 2), pictureBox4.Location.Y);
            pb_close.Location = new Point(tabPage1.Width - pb_close.Width - 1, pb_close.Location.Y);

           
        }

        private void quitar_columnas()
        {

            if (column1 > 3)
            {

                tabPage1.Controls.Remove(tabPage1.Controls["ch" + (column1 - 1).ToString()]);
                //tabPage1.Controls.Remove(tabPage1.Controls["cb" + (column1 + 2).ToString()]);
                tabPage1.Controls.Remove(tabPage1.Controls["tb" + (column1 - 1).ToString()]);
                tabPage1.Controls.Remove(tabPage1.Controls["lb" + (column1 - 1).ToString()]);

                pictureBox1.Location = new Point(pictureBox1.Location.X - 105, pictureBox1.Location.Y);


                tabControl1.Size = new Size(tabControl1.Width - tb.Width - 5, tabControl1.Height);

                column1--;

                this.Size = tabControl1.Size;
                pictureBox1.Show();
                //cargar_combo(column1 +2);
            }
            else
            {
                pictureBox2.Hide();
                pictureBox1.Show();
                pictureBox1.Location = new Point(pictureBox1.Location.X - 105, pictureBox1.Location.Y);

                tabPage1.Controls.Remove(tabPage1.Controls["tb" + (column1 - 1).ToString()]);
                tabPage1.Controls.Remove(tabPage1.Controls["ch" + (column1 - 1).ToString()]);
                //tabPage1.Controls.Remove(tabPage1.Controls["cb" + (column1 + 2).ToString()]);
                tabPage1.Controls.Remove(tabPage1.Controls["lb" + (column1 - 1).ToString()]);
                tabControl1.Size = new Size(tabControl1.Width - tb.Width - 5, tabControl1.Height);
                column1 = 2;
                this.Size = tabControl1.Size;
                //cargar_combo(2);
            }
        }
        /// <summary>
        /// CONTEXTMENUSSTRING
        /// </summary>



        public int xClick = 0, yClick = 0;



        private void pictureBox5_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(pictureBox5, new Point(pictureBox5.Location.X + 18, pictureBox5.Location.Y - 50));
        }


        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int datos = dataGridView1.ColumnCount;
            if (datos > 0)
            {
                if (datos > 6)
                {
                    datos = 6;
                }

                for (int i = 0; i < datos - 3; i++)
                {
                    quitar_columnas();
                }

                tb.Text = "";
                tb1.Text = "";
            }

            int contadorTabulaciones = 0;
            if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
            {

                string clipboardData = Clipboard.GetText(TextDataFormat.UnicodeText);
                clipboardData = clipboardData.Replace("\"", string.Empty);
                string[] rows = clipboardData.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                DataTable table = new DataTable();



                for (int i = 0; i < clipboardData.Length; i++)
                {
                    if (clipboardData[i] == '\t')
                    {
                        contadorTabulaciones++;
                    }
                }

                if (contadorTabulaciones > 3)
                {
                    foreach (string row in rows)
                    {
                        string[] cells = row.Split('\t');

                        if (table.Columns.Count == 0)
                        {

                            for (int i = 0; i < cells.Length; i++)
                            {

                                table.Columns.Add(cells[i].ToUpper().Trim());
                            }
                        }
                        else
                        {
                            table.Rows.Add(cells);
                        }


                    }
                }
                else
                {

                    foreach (string row in rows)
                    {
                        string[] cells = row.Split(',');

                        if (table.Columns.Count == 0)
                        {
                            for (int i = 0; i < cells.Length; i++)
                            {
                                table.Columns.Add(cells[i].ToUpper());
                            }
                        }
                        else
                        {
                            table.Rows.Add(cells);
                        }
                    }
                }

                if (table.Columns.Count < 2)
                {
                    MessageBox.Show("El valor Minimo de Clumnas a agregar es de 2 !!!");
                }
                else
                {
                    dataGridView1.DataSource = table;

                    if (table.Columns.Count < 3)
                    {
                        pictureBox2.Hide();

                    }
                    else
                    {
                        pictureBox2.Show();
                    }

                    pictureBox1.Hide();


                    carga_tb();

                    panel1.Hide();

                    lb_col.Text = dataGridView1.ColumnCount.ToString();
                    lb_reg.Text = dataGridView1.RowCount.ToString();

                    panel2.Show();
                    pictureBox4.Show();
                    pictureBox3.Show();
                    pictureBox6.Hide();

                    panel2.Location = new Point((tabPage1.Width / 2) - (panel2.Width / 2), panel2.Location.Y);
                    pictureBox3.Location = new Point((tabPage1.Width / 2) - (pictureBox3.Width / 2), pictureBox3.Location.Y);
                    pictureBox4.Location = new Point((tabPage1.Width / 2) - (pictureBox4.Width / 2), pictureBox4.Location.Y);
                    pb_close.Location = new Point(tabPage1.Width - pb_close.Width - 1, pb_close.Location.Y);

                }

                //duplicados(tb);

            }
        }

        private void carga_tb()
        {
            int colCant = dataGridView1.ColumnCount;

            int i = 0;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (i == 0)
                {
                    tb.Text = column.HeaderText;
                }
                else if (i < 2)
                {

                    TextBox tbx = tabPage1.Controls["tb" + i] as TextBox;

                    tbx.Text = column.HeaderText;

                }
                else if (i < 6)
                {
                    agregarCol();
                    TextBox tbx = tabPage1.Controls["tb" + i] as TextBox;
                    tbx.Text = column.HeaderText;
                }

                i++;
            }


            tb.MouseClick += new MouseEventHandler(menu_tb);
            tb1.MouseClick += new MouseEventHandler(menu_tb);

            tb.KeyPress += new KeyPressEventHandler (actualizar_tb);
            tb1.KeyPress += new KeyPressEventHandler(actualizar_tb);
        }
        
        string tb_modificar=""; 

        private void actualizar_tb(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                TextBox tb = sender as TextBox;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Columns[i].HeaderText == tb_modificar)
                    {
                        dataGridView1.Columns[i].HeaderText = tb.Text.Trim().ToUpper();
                        dataGridView1.Columns[i].Name = tb.Text.Trim().ToUpper();
                        tb.Text = tb.Text.Trim().ToUpper();
                        tb_modificar = "";
                        tb.ReadOnly = true;
                    }
                }
            }
        }


        private void Tb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void menu_tb(object sender, EventArgs e)
        {
            TextBox tbI = sender as TextBox;

            ContextMenuStrip mu = new ContextMenuStrip();
            int i = 1;
            foreach (DataGridViewColumn columna in dataGridView1.Columns)
            {

                ToolStripMenuItem MnuStripItem = new ToolStripMenuItem(columna.HeaderText);
                MnuStripItem.Name = (tbI.Name);
                MnuStripItem.Text = (columna.HeaderText);
                MnuStripItem.ForeColor = Color.Black;
                MnuStripItem.Font = new Font("Georgia", 10);

                mu.Items.Add(MnuStripItem);


                MnuStripItem.Click += new EventHandler(evento);
                i++;
            }

            ToolStripMenuItem editor = new ToolStripMenuItem();
            editor.Name = (tbI.Name);
            editor.Text = (" ✎ EDITAR...");
            editor.ForeColor = Color.Black;
            editor.Font = new Font("Georgia", 10);
            mu.Items.Add(editor);
            editor.Click += new EventHandler(evento);
            mu.Show(tbI, new Point(xClick, yClick));

        }

        private void evento(object sender, EventArgs e)
        {

            ToolStripMenuItem mt = sender as ToolStripMenuItem;
            TextBox tb1 = tabPage1.Controls[mt.Name] as TextBox;

            if (mt.Text== " ✎ EDITAR...")
            {

                TextBox tb = tabPage1.Controls[mt.Name] as TextBox;
                tb.ReadOnly = false;
                tb_modificar =  tb.Text;
                tb.SelectAll();
            }
            else {
                foreach (Control tebox in tabPage1.Controls)
                {
                    if (tebox is TextBox)
                    {
                        if (tebox.Text == mt.Text)
                        {
                            tebox.Text = tb1.Text;
                        }

                    }

                }

                tb1.Text = mt.Text;


                duplicados(tb1);
            }
            

        }

        private void duplicados(Control tb1)
        {

            int flag = 0;
            int i = 0;
            int j = 0;

            if (tb1.Name == "tb")
            {

                foreach (DataGridViewRow rowext in dataGridView1.Rows)
                {
                    if (i < dataGridView1.RowCount - 1)
                    {

                        flag = 0;

                        string valor = rowext.Cells[tb1.Text].Value.ToString();

                        j = 0;
                        if (j < dataGridView1.RowCount)
                        {
                            foreach (DataGridViewRow rowint in dataGridView1.Rows)
                            {
                                //MessageBox.Show(valor+" = " + (string)rowint.Cells[tb1.Text].Value);
                                if ((string)rowint.Cells[tb1.Text].Value != null || (string)rowint.Cells[tb1.Text].Value != "")
                                {

                                    if ((string)rowint.Cells[tb1.Text].Value == valor)
                                    {
                                        flag++;
                                        if (flag > 1)
                                        {
                                            MessageBox.Show("La Columna " + tb1.Text + " Posee valores duplicados!!!!\n \"REGISTROS\" no puede contener valores duplicados \n Por favor, elija un valor correcto.");
                                            tb1.Text = "";
                                            break;
                                        }
                                    }
                                }
                                j++;
                            }

                        }
                        if (j < dataGridView1.RowCount - 1)
                        {
                            break;
                        }

                        i++;
                    }
                }

            }
        }


        private void pb_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl1_MouseMove(object sender, MouseEventArgs e)
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


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int v_c = 0;
            int v_ll = 0;

            foreach (Control cn in tabPage1.Controls)
            {
                if (cn is Label)
                {
                    if (cn.ForeColor == Color.GreenYellow)
                    {
                        v_c++;
                    }
                }
                else if (cn is TextBox)
                {
                    if (cn.Text == null)
                    {
                        v_ll++;
                    }
                }

            }



            if (v_c == 0)
            {
                MessageBox.Show("Debe elegir al menos una columna como \"CONTACTO\" para continuar");
            }
            else if (v_ll > 0)
            {
                MessageBox.Show("Todas las Columnas deben poseer un valor", "Columna Vacia");
            }
            else
            {

                if (Settings.Default["correo_asunto"].ToString() != "")
                {
                    tb_asunto.Text = Settings.Default["correo_asunto"].ToString();
                }
                else
                {
                    SetPlaceholder(tb_asunto, ".....Asunto");
                }

                if (Settings.Default["correo_cc"].ToString() != "")
                {
                    tb_cc.Text = Settings.Default["correo_cc"].ToString();
                }
                else
                {
                    SetPlaceholder(tb_cc, ".....CC");
                }

                if (Settings.Default["correo_inicio"].ToString() != "")
                {
                    tb_msj_inicial.Text = Settings.Default["correo_inicio"].ToString();
                }
                else
                {
                    SetPlaceholder(tb_msj_inicial, ".....Texto de Apertura y Mensaje para el Destinatario");
                }

                if (Settings.Default["correo_final"].ToString() != "")
                {
                    tb_msj_final.Text = Settings.Default["correo_final"].ToString();
                }
                else
                {
                    SetPlaceholder(tb_msj_final, ".....Texto de cierre y despedida");
                }

                
                
                pictureBox3.Hide();
                pictureBox4.Show();
                if (tabPage2.Parent == null)
                {
                    // 0 es el index por la primera pestana
                    tabControl1.TabPages.Insert(0, tabPage2);
                }
                tabPage2.Show();

                reconvertir_data();

                tb_asunto.Location = new Point((tabPage2.Width / 2) - (tb_asunto.Width / 2), tb_asunto.Location.Y);
                tb_cc.Location = new Point((tabPage2.Width / 2) - (tb_cc.Width / 2), tb_cc.Location.Y);
                tb_msj_inicial.Location = new Point((tabPage2.Width / 2) - (tb_msj_inicial.Width / 2), tb_msj_inicial.Location.Y);
                tb_msj_final.Location = new Point((tabPage2.Width / 2) - (tb_msj_final.Width / 2), tb_msj_final.Location.Y);

                pictureBox7.Location = new Point((tabPage2.Width / 2) - (pictureBox7.Width / 2), pictureBox7.Location.Y);
                pictureBox8.Location = new Point((tabPage2.Width / 2) - (pictureBox8.Width / 2), pictureBox8.Location.Y);
                pictureBox9.Location = new Point((tabPage2.Width / 2) - (pictureBox9.Width / 2), pictureBox9.Location.Y);
                pb_sign_on.Location = new Point(tb_msj_final.Location.X + tb_msj_final.Width - pb_sign_on.Width, pb_sign_on.Location.Y);
                pb_sign_off.Location = new Point(tb_msj_final.Location.X + tb_msj_final.Width - pb_sign_off.Width, pb_sign_off.Location.Y);
                pictureBox12.Location = new Point(tabPage2.Width - pictureBox12.Width - 1, pictureBox12.Location.Y);

                chbEnviados.Location = new Point(tb_asunto.Location.X, chbEnviados.Location.Y);
            }


        }




        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// //////////////////////////////////////////TABPAGE 2//////////////////////////////////////////////////////////////////////
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>


        private void reconvertir_data()
        {
            int num = 0;
            foreach (Control tex in tabPage1.Controls)
            {
                if (tex is TextBox)
                {
                    num++;
                }
            }

            DataTable dt = new DataTable();

            for (int i = 0; i < num; i++)
            {
                if (i == 0)
                {
                    dt.Columns.Add(tabPage1.Controls["tb"].Text);
                }
                else
                {
                    dt.Columns.Add(tabPage1.Controls["tb" + i].Text);
                }
            }

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (i == 0)
                {
                    foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
                    {

                        DataRow dtRow = dt.Rows.Add();
                        dtRow[tabPage1.Controls["tb"].Text] = dgvRow.Cells[tabPage1.Controls["tb"].Text].Value;
                    }

                }
                else
                {
                    int j = 0;
                    foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
                    {
                        DataRow dtRow = dt.Rows[j];
                        dtRow[tabPage1.Controls["tb" + i].Text] = dgvRow.Cells[tabPage1.Controls["tb" + i].Text].Value;
                        j++;
                    }
                    j = 0;
                }
            }



            dataGridView2.DataSource = dt;


            string contact = "";
            int k = 0;
            foreach (Control cn in tabPage1.Controls)
            {
                if (cn is Label)
                {
                    if (cn.ForeColor == Color.GreenYellow)
                    {
                        if (k == 0)
                        {
                            contact = tabPage1.Controls["tb"+ k].Text;
                        }
                        else
                        {
                            contact = tabPage1.Controls["tb" + k].Text;
                        }

                    }
                    k++;
                }

            }
            
            dataGridView2.Sort(dataGridView2.Columns[contact], ListSortDirection.Ascending);
            dataGridView2.Rows.RemoveAt(0);


        }
        public static Label SetPlaceholder(Control control, string text)
        {
            var placeholder = new Label
            {
                Text = text,
                Font = control.Font,
                ForeColor = Color.Gray,
                BackColor = Color.Transparent,
                Cursor = Cursors.IBeam,
                Margin = Padding.Empty,

                //get rid of the left margin that all labels have
                FlatStyle = FlatStyle.System,
                AutoSize = false,

                //Leave 1px on the left so we can see the blinking cursor
                Size = new Size(control.Size.Width - 1, control.Size.Height),
                Location = new Point(control.Location.X + 1, control.Location.Y)
            };

            //when clicking on the label, pass focus to the control
            placeholder.Click += (sender, args) => { control.Focus(); };

            //disappear when the user starts typing
            control.TextChanged += (sender, args) => {
                placeholder.Visible = string.IsNullOrEmpty(control.Text);
            };

            //stay the same size/location as the control
            EventHandler updateSize = (sender, args) => {
                placeholder.Location = new Point(control.Location.X + 1, control.Location.Y);
                placeholder.Size = new Size(control.Size.Width - 1, control.Size.Height);
            };

            control.SizeChanged += updateSize;
            control.LocationChanged += updateSize;

            control.Parent.Controls.Add(placeholder);
            placeholder.BringToFront();

            return placeholder;
        }




        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// //////////////////////////////////////////TABPAGE 3//////////////////////////////////////////////////////////////////////
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            
            if (tb_asunto.Text == string.Empty || tb_msj_inicial.Text == string.Empty || tb_msj_final.Text == string.Empty)
            {
                MessageBox.Show("Quedan cammpos por llenar, verifique por favor!!");
            }
            else
            {
                if (tabPage3.Parent == null)
                {
                    // 0 es el index por la primera pestana
                    tabControl1.TabPages.Insert(0, tabPage3);
                }
                tabPage3.Show();



                panel_agregar.Location = new Point((tabPage3.Width / 2) - 45, panel_agregar.Location.Y);
                panel_agregar.BringToFront();

                pictureBox10.Location = new Point((tabPage2.Width - pictureBox10.Width) - 4, pictureBox10.Location.Y);

                verificar();
            }

        }

        private void verificar()
        {
            listaCorreos.Width = tabPage1.Width - 4;

            

            int cor_enviar = 0;
            int reg_enviar = 0;

            List<String> usuarioNoEncontrados = new List<String>();


            int datos = dataGridView2.RowCount;
            string registros = tabPage1.Controls["tb"].Text;
            CheckBox chRegistros = tabPage1.Controls["ch"] as CheckBox;
            string fila = "";
            string contacto1 = "";
            bool chC = false;
            string usuario;

            int i = 0;

            foreach (Control cn in tabPage1.Controls)
            {
                if (cn is Label)
                {


                        if (cn.ForeColor == Color.GreenYellow)
                        {
                            contacto1 = tabPage1.Controls["tb" + i].Text;
                            CheckBox chContacto = tabPage1.Controls["ch" + i] as CheckBox;
                            if (chContacto.Checked) { chC = true; }

                        }

                    i++;
                }


            }


            int indice = 0;
            int nodos = 0;

            if (datos > 1)
            {

                string contacto = dataGridView2.Rows[0].Cells[contacto1].Value.ToString();

                llenarNodo_primerNivel(contacto);

                for (int j = 1; j < datos - 1; j++)
                {


                    //MessageBox.Show(j.ToString() + "|| " + contacto + " ===" + dataGridView2.Rows[j].Cells[contacto1].Value.ToString());
                    if (contacto == dataGridView2.Rows[j].Cells[contacto1].Value.ToString())
                    {
                        for (int k = 0; k < dataGridView2.ColumnCount; k++)
                        {
                            
                            if (dataGridView2.Columns[k].Name == contacto1)
                            {
                                if (chC) { fila += "^" + dataGridView2.Rows[j - 1].Cells[contacto1].Value.ToString(); }
                            }
                            else
                            {

                                if (k == 0)
                                {
                                    fila += dataGridView2.Rows[j - 1].Cells[k].Value.ToString();
                                }
                                else
                                {
                                    fila += "^" + dataGridView2.Rows[j - 1].Cells[k].Value.ToString();
                                }

                            }
                        }
                        llenarNodo_segundoNivel(listaCorreos.Nodes[nodos], fila);
                        fila = "";
                        reg_enviar++;

                    }
                    else
                    {


                        usuario = traerContacto(dataGridView2.Rows[j - 1].Cells[contacto1].Value.ToString());

                        //SendMail(contacto, asunto, (Body + Body_tabla + Body_final))

                        //MessageBox.Show(usuario_office + asunto + (inicio + tabla_1 + tabla_2 + tabla_3 + final));
                        if (usuario == string.Empty)
                        {
                            for (int k = 0; k < dataGridView2.ColumnCount; k++)
                            {
                                if (k == 0)
                                {
                                    if (chRegistros.Checked) { fila += dataGridView2.Rows[j - 1].Cells[registros].Value.ToString(); }

                                }
                                else if (dataGridView2.Columns[k].Name == contacto1)
                                {
                                    if (chC) { fila += "^" + dataGridView2.Rows[j - 1].Cells[contacto1].Value.ToString(); }
                                }
                                else
                                {
                                    fila += "^" + dataGridView2.Rows[j - 1].Cells[k].Value.ToString();
                                }
                            }


                            llenarNodo_segundoNivel(listaCorreos.Nodes[nodos], fila);
                            fila = "";
                            usuarioNoEncontrados.Add(contacto1);
                        }
                        else
                        {
                            for (int k = 0; k < dataGridView2.ColumnCount; k++)
                            {

                                if (dataGridView2.Columns[k].Name == contacto1)
                                {
                                    if (chC) { fila += "^" + dataGridView2.Rows[j - 1].Cells[contacto1].Value.ToString(); }
                                }
                                else
                                {

                                    if (k==0)
                                    {
                                        fila +=  dataGridView2.Rows[j - 1].Cells[k].Value.ToString();
                                    }
                                    else
                                    {
                                        fila += "^" + dataGridView2.Rows[j - 1].Cells[k].Value.ToString(); 
                                    }

                                }
                            }
                            llenarNodo_segundoNivel(listaCorreos.Nodes[nodos], fila);
                            fila = "";
                            cor_enviar++;
                        }

                        contacto = dataGridView2.Rows[j].Cells[contacto1].Value.ToString();

                        if (usuario == "")
                        {

                            listaCorreos.Nodes[nodos].Text = listaCorreos.Nodes[nodos].Text + "  (*  ✎ )";

                        }
                        else
                        {
                            listaCorreos.Nodes[nodos].Text = listaCorreos.Nodes[nodos].Text + "   ( " + usuario + " )";
                        }

                        llenarNodo_primerNivel(contacto);
                        nodos++;
                    }
                    indice = j;

                }


                usuario = traerContacto(dataGridView2.Rows[indice].Cells[contacto1].Value.ToString());



                if (usuario == string.Empty)
                {
                    for (int k = 0; k < dataGridView2.ColumnCount; k++)
                    {
                        if (k == 0)
                        {
                            if (chRegistros.Checked) { fila += dataGridView2.Rows[indice].Cells[registros].Value.ToString(); }

                        }
                        else if (dataGridView2.Columns[k].Name == contacto1)
                        {
                            if (chC) { fila += "^" + dataGridView2.Rows[indice].Cells[contacto1].Value.ToString(); }
                        }
                        else
                        {

                            if (k == 0)
                            {
                                fila += dataGridView2.Rows[indice].Cells[k].Value.ToString();
                            }
                            else
                            {
                                fila += "^" + dataGridView2.Rows[indice].Cells[k].Value.ToString();
                            }
                        }
                    }
                    llenarNodo_segundoNivel(listaCorreos.Nodes[nodos], fila);
                    fila = "";
                    usuarioNoEncontrados.Add(contacto1);
                }
                else
                {
                    for (int k = 0; k < dataGridView2.ColumnCount; k++)
                    {
                       
                        if (dataGridView2.Columns[k].Name == contacto1)
                        {
                            if (chC) { fila += "^" + dataGridView2.Rows[indice].Cells[contacto1].Value.ToString(); }
                        }
                        else
                        {

                            if (k == 0)
                            {
                                fila += dataGridView2.Rows[indice].Cells[k].Value.ToString();
                            }
                            else
                            {
                                fila += "^" + dataGridView2.Rows[indice].Cells[k].Value.ToString();
                            }
                        }
                    }
                    llenarNodo_segundoNivel(listaCorreos.Nodes[nodos], fila);
                    fila = "";
                    cor_enviar++;
                }

                if (usuario == "")
                {

                    listaCorreos.Nodes[nodos].Text = listaCorreos.Nodes[nodos].Text + "   (*  ✎ )";
                }
                else
                {
                    listaCorreos.Nodes[nodos].Text = listaCorreos.Nodes[nodos].Text + "     ( " + usuario + " )";
                }

            }
            label7.Text = cor_enviar.ToString();
            label8.Text = usuarioNoEncontrados.Count.ToString();

            panel_agregar.Hide();
        }

        TreeNode mySelectedNode;
        private void listaCorreos_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            panel_agregar.Width = tabPage3.Width - 2;

            mySelectedNode = listaCorreos.GetNodeAt(e.X, e.Y);

            string usuario = e.Node.Text;

            if (usuario.Intersect("✎").Count() > 0)
            {


                panel_agregar.Show();
                panel_agregar.BringToFront();
                lb_user.Text = usuario;
                tb_correo.Focus();

                if (tb_correo.Text.Length < 1)
                {
                    tb_correo.Text = "@correoargentino.com.ar";
                    tb_correo.SelectionStart = 0;
                }
            }

        }

        private void bt_guardar_Click(object sender, EventArgs e)
        {
            if (tb_correo.Text == "" + "@correoargentino.com.ar")
            {
                MessageBox.Show("Debe agregar una dirección de correo Valida!!");
            }
            else
            {
                panel_agregar.Hide();

                string texto = mySelectedNode.Text;
                mySelectedNode.Text = texto.Replace("*  ✎ ", " " + tb_correo.Text + "  👤 ");


                int cantEncontrados = Convert.ToInt32(label7.Text);
                cantEncontrados++;
                label7.Text = cantEncontrados.ToString();

                int cantNo = Convert.ToInt32(label8.Text);
                cantNo--;
                label8.Text = cantNo.ToString();
            }
        }
        private void llenarNodo_primerNivel(string dato)
        {
            TreeNode nodo1 = new TreeNode();
            nodo1.Name = dato;
            nodo1.Text = dato;
            listaCorreos.Nodes.Add(nodo1);
        }

        private void llenarNodo_segundoNivel(TreeNode nodo, string dato)
        {
            TreeNode nodo2 = new TreeNode();
            nodo2.Name = dato;
            nodo2.Text = dato;
            nodo.Nodes.Add(nodo2);
        }
        private void modificar_Nodo(TreeNode nodo, string dato)
        {
            nodo.Name = nodo.Name + dato;
        } 




        private void w_enviador_DoWork(object sender, DoWorkEventArgs e)
        {


            string textoGuardar;
            textoGuardar = DateTime.Now.ToString() + ";";

            string nombreImage;
            string pathImage;
            string imageHtml;

            string asunto = tb_asunto.Text;

            string inicial = tb_msj_inicial.Text;

            string final = tb_msj_final.Text;

            string temp;

            try
            {
                nombreImage = System.IO.Path.GetFileName(firma.ImageLocation);
                nombreImage = nombreImage.Substring(0, nombreImage.Length - 4);

                pathImage = firma.ImageLocation;
                imageHtml = "<img src='cid:firma'/>";
            }
            catch (Exception)
            {
                nombreImage = null;
                pathImage = null;
                imageHtml = null;
            }
            

            string cc = tb_cc.Text;

            string tabla = "<table  class='default' style= 'padding-left: 50px; border-collapse: collapse; border: 1px solid black; text-align: center; vertical-align: middle; margin-left: 55px;'> <tr>";

            string tabla_3 = "";

            string tablaPost = "";

            string contacto = "";
            string contacto1 = "";

            string registros = tabPage1.Controls["tb"].Text;


            

            int col_reales = 0;

            /*
            if (ch.Checked == true)
            {
                tabla = tabla + "<th style= 'border: 1px solid black; padding: 2px;padding-left: 5px;'>" + tb.Text + "</th>";

                col_reales++;
            }
            */

            int i = 0;
            foreach (Control cn in tabPage1.Controls)
            {
                if (cn is Label)
                {

                    if (i<1)
                    {
                        TextBox texto = tabPage1.Controls["tb"] as TextBox;
                        temp = tabPage1.Controls["tb"].Text;
                        tabla = tabla + "<th style= 'border: 1px solid black; padding: 2px;padding-left: 5px;'>" + texto.Text + "</th>";
                        col_reales++;
                    }
                    else
                    {
                        TextBox texto = tabPage1.Controls["tb" + i] as TextBox;

                        if (cn.ForeColor == Color.GreenYellow)
                        {
                            contacto1 = tabPage1.Controls["tb" + i].Text;
                            CheckBox ch = tabPage1.Controls["ch" + i ] as CheckBox;
                            if (ch.Checked == true)
                            {
                                tabla = tabla + "<th style= 'border: 1px solid black; padding: 2px;padding-left: 5px;'>" + texto.Text + "</th>";


                                col_reales++;
                            }

                        }
                        else
                        {
                            temp = tabPage1.Controls["tb" + i].Text;
                            tabla = tabla + "<th style= 'border: 1px solid black; padding: 2px;padding-left: 5px;'>" + texto.Text + "</th>";


                            col_reales++;
                        }
                    }

                    temp = "";

                    i++;
                }
                
                
            }

            tabla = tabla + "</tr>";


            string[] rows;

            int datos = listaCorreos.Nodes.Count;

            if (datos > 1)
            {

                for (int j = 0; j < datos; j++)
                {

                    //MessageBox.Show(j.ToString() + "|| " + contacto + " ===" + dataGridView2.Rows[j].Cells[contacto1].Value.ToString());

                   
                    if ((listaCorreos.Nodes[j].Text).IndexOf("✎") == -1)
                    {
                        w_enviador.ReportProgress(1, j);
                        contacto = (listaCorreos.Nodes[j].Text).Substring((listaCorreos.Nodes[j].Text).IndexOf("(") + 1, ((listaCorreos.Nodes[j].Text).IndexOf(")") - 7) - (listaCorreos.Nodes[j].Text).IndexOf("("));

                        contacto = contacto.Trim();


                        for (int k = 0; k < listaCorreos.Nodes[j].Nodes.Count; k++)
                        {



                            rows = (listaCorreos.Nodes[j].Nodes[k].Text).Split('^');
                            
                            if (tabla_3.Length > 5 )
                            {
                                tabla_3 = tabla_3 + "<tr>";
                            }
                            else
                            {
                                tabla_3 = "<tr>";
                            }
                             

                            for (int x = 0; x < rows.Length; x++)
                            {
                                tabla_3 = tabla_3 + "<td style ='border: 1px solid black; padding: 2px;padding-left: 5px;'>" + rows[x] + " </td>";
                                
                                if (x==0)
                                {
                                    textoGuardar = textoGuardar + rows[0] + "; " + (listaCorreos.Nodes[j].Text).Substring(0, (listaCorreos.Nodes[j].Text).IndexOf("(") -1) + ";";
                                    
                                }
                            }

                            tabla_3 = tabla_3 + "</tr>";

                            //MessageBox.Show(contacto + "     " + contenido);

                        }

                        tablaPost= tabla + tabla_3 + "</table>";


                        string bodyHtml = $@"
                            <html>
                                <body>
                                    <p>Estimados,</p>
                                    <br>
                                    <p style = 'margin - left: 20px;'>{inicial}</p>
                                        {tablaPost}
                                    <p>{final}</p>
                                    <p> Muchas Gracias. </p>
                                       {imageHtml}
                                </body>
                            </html>";
                        // {imageHtml}

                        Thread.Sleep(2500);
                        enviar_correo(asunto, bodyHtml, contacto, nombreImage, pathImage, cc);

                        

                        //enviar_correo(asunto, bodyHtml, contacto, nombreImage, pathImage, cc);


                        tabla_3 = "";
                        tablaPost = "";
                    }
                    else
                    {
                        w_enviador.ReportProgress(2,j);
                    }

                }

                Settings.Default["correo_inicio"] = tb_msj_inicial.Text;
                Settings.Default.Save();
                Settings.Default["correo_cc"] = tb_cc.Text;
                Settings.Default.Save();
                Settings.Default["correo_asunto"] = tb_asunto.Text;
                Settings.Default.Save();
                Settings.Default["correo_final"] = tb_msj_final.Text;
                Settings.Default.Save();

            }
            textoGuardar = textoGuardar.Replace(";", ".\n");
            System.IO.File.WriteAllText(@"C:\Temp\CorreosEnviados.txt", textoGuardar);
        }


        public void enviar_correo(string asunto, string contenido, string  contacto, string nombreImage, string pathImage, string cc)
        {

            bool save = chbEnviados.Checked;

           
            
            var requestBody = new Microsoft.Graph.Me.SendMail.SendMailPostRequestBody
            {
                Message = new Microsoft.Graph.Models.Message
                {
                    Subject = asunto,
                    Body = new ItemBody
                    {
                        ContentType = BodyType.Html,
                        Content = contenido,
                    },
                    ToRecipients = new List<Recipient>
                                        {
                                        new Recipient
                                            {
                                                EmailAddress = new EmailAddress
                                                    {
                                                        Address = contacto,
                                                    },
                                            },
                                        },
                },
                SaveToSentItems = save,
            };


            if (!string.IsNullOrEmpty(cc))
            {
                requestBody.Message.CcRecipients = new List<Recipient>
                {
                    new Recipient
                    {
                        EmailAddress = new EmailAddress
                        {
                        Address = cc,
                        },
                    },
                };
            }

            if (!string.IsNullOrEmpty(nombreImage) && !string.IsNullOrEmpty(pathImage))
            {
                var fileAttachment = new FileAttachment
                {
                    OdataType = "#microsoft.graph.fileAttachment",
                    Name = nombreImage,
                    ContentType = "image/png", // Asegúrate de establecer el tipo de contenido correcto para una imagen PNG
                    ContentBytes = System.IO.File.ReadAllBytes(pathImage),
                    IsInline = true,
                    ContentId = "firma", // Este ID debe coincidir con el utilizado en el contenido HTML
                };

                requestBody.Message.Attachments = new List<Attachment>
                {
                    fileAttachment,
                };
            }

            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                switch (args.Name)
                {
                    case "System.Buffers, Version=4.0.3.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51":
                        return typeof(System.Buffers.ArrayPool<>).Assembly;
                    default:
                        return null;
                }
            };


            try
            {

                var respuesta =  tokenOffice.Me.SendMail.PostAsync(requestBody);


                //MessageBox.Show("Enviando Enviado : " + contacto + "\n " + "Asunto: " + asunto + "\n " + "firma: " + pathImage + " \n" + " Contenido" + contenido + " \n" + "CC: " + cc + "\n" + " **Respuesta: "+ respuesta.IsFaulted + "\n " + respuesta.Exception + "\n " + respuesta.Status + "\n " + respuesta.IsCompleted);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar Correo: " + ex);
                
            }
            

        }

        private string traerContacto(string user) 
        {

            string devuelve="";

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            string query = "SELECT * FROM correo_correos WHERE DisplayName = '" + user + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        if (reader["Active"].ToString() == "0")
                        {
                            devuelve = reader["UserPrincipalName"].ToString() + "  👤 ";
                        }
                        else
                        {
                            devuelve = reader["Delegate"].ToString() + "  🏠 ";
                        }

                        con.Close();

                    }
                }
                else
                {
                    devuelve = "";
                }
            }
            catch
            {

                MessageBox.Show("No es posible conectar con la BBDD!!");
            }
           

            return devuelve;
        }

        
        /*
        private String llenar_tabla3(string tabla_3, int j)
        {
            if (ch.Checked == true)
            {
                tabla_3 = tabla_3 + "<td style ='border: 1px solid black; padding: 2px;padding-left: 5px;'>" + dataGridView2.Rows[j].Cells[tabPage1.Controls["tb"].Text].Value.ToString() + " </td>";
            }
            int k = 1;
            foreach (Control cn in tabPage1.Controls)
            {
                if (cn is Label)
                {
                    if (cn.ForeColor == Color.GreenYellow)
                    {
                        CheckBox ch = tabPage1.Controls["ch" + k] as CheckBox;
                        if (ch.Checked == true)
                        {
                            tabla_3 = tabla_3 + "<td style ='border: 1px solid black; padding: 2px;padding-left: 5px;'>" + dataGridView2.Rows[j].Cells[tabPage1.Controls["tb" + k].Text].Value.ToString() + " </td> ";
                        }
                    }
                    else if (cn.ForeColor == Color.White)
                    {
                        CheckBox ch = tabPage1.Controls["ch" + k] as CheckBox;
                        if (ch.Checked == true)
                        {
                            tabla_3 = tabla_3 + "<td style ='border: 1px solid black; padding: 2px;padding-left: 5px;'>" + dataGridView2.Rows[j].Cells[tabPage1.Controls["tb" + k].Text].Value.ToString() + " </td> ";
                        }
                    }
                    else
                    {
                        tabla_3 = tabla_3 + "<td style ='border: 1px solid black; padding: 2px;padding-left: 5px;'>" + dataGridView2.Rows[j].Cells[tabPage1.Controls["tb" + k].Text].Value.ToString() + " </td> ";
                    }
                }

            }

            return tabla_3;
        }
        */

        private void w_enviador_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lb_contacto.Text = "CORREOS ENVIADOS..!!";
            lb_contacto.Location = new Point((tabPage4.Width / 2) - (lb_contacto.Width / 2), lb_contacto.Location.Y);
        }

       

        private void w_enviador_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            list_resultado.Items.Clear();
            int tipo = e.ProgressPercentage;
            int dato = Convert.ToInt32(e.UserState);
            //Convert.ToInt32(e.UserState.ToString());

            int progreso = progressBar1.Value;

            if (tipo == 1)
            {
                lb_contacto.Text = (listaCorreos.Nodes[dato].Text).Substring(0, (listaCorreos.Nodes[dato].Text).IndexOf("(") - 1);
                lb_contacto.Location = new Point((tabPage4.Width / 2) - (lb_contacto.Width / 2), lb_contacto.Location.Y);

                for (int i = 0; i < listaCorreos.Nodes[dato].Nodes.Count; i++)
                {
                    list_resultado.Items.Add(listaCorreos.Nodes[dato].Nodes[i].Text);
                }
                progressBar1.Value = progreso + 1;
            }
            else
            {

                
                progressBar1.Value = progreso + 1;
            }
           
            
        }


        GraphServiceClient tokenOffice;
        private async void iniciar_perfil()
        {
            //AuthenticationResult authResult = null;

          

            var app  = PublicClientApplicationBuilder.Create("db01f096-1c0c-41c5-ab12-6a73c80c3708").WithDefaultRedirectUri().WithTenantId("d3abd9d3-3514-4659-94b2-0e1458194215").Build();
            var accounts = await app.GetAccountsAsync();
            AuthenticationResult result;

            try
            {
                result = await app.AcquireTokenSilent(scopes, accounts.FirstOrDefault())
                  .ExecuteAsync();
            }
            catch (MsalUiRequiredException)
            {
                result = await app.AcquireTokenInteractive(scopes)
                  .ExecuteAsync();
            }
            //App.PublicClientApp;

           

            //IAccount firstAccount;
            /*
            switch (modo_user.SelectedIndex)
            {
                // 0: Use account used to signed-in in Windows (WAM)
                case 0:
                    // WAM will always get an account in the cache. So if we want
                    // to have a chance to select the accounts interactively, we need to
                    // force the non-account
                    firstAccount = Microsoft.Identity.Client.PublicClientApplication.OperatingSystemAccount;
                    break;

                //  1: Use one of the Accounts known by Windows(WAM)
                case 1:
                    // We force WAM to display the dialog with the accounts
                    firstAccount = null;
                    break;

                //  Use any account(Azure AD). It's not using WAM
                default:
                    var accounts = await app.GetAccountsAsync();
                    firstAccount = accounts.FirstOrDefault();
                    break;
            }
            
            try
            {
                authResult = await app.AcquireTokenSilent(scopes, firstAccount)
                    .ExecuteAsync();
            }
            catch (MsalUiRequiredException ex)
            {
                // A MsalUiRequiredException happened on AcquireTokenSilent. 
                // This indicates you need to call AcquireTokenInteractive to acquire a token
                System.Diagnostics.Debug.WriteLine($"MsalUiRequiredException: {ex.Message}");

                try
                {
                    authResult = await app.AcquireTokenInteractive(scopes)
                        .WithAccount(firstAccount)
                        .WithPrompt(Microsoft.Identity.Client.Prompt.SelectAccount)
                        .ExecuteAsync();
                }
                catch (MsalException msalex)
                {
                    MessageBox.Show($"Error Acquiring Token:{System.Environment.NewLine}{msalex}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Acquiring Token Silently:{System.Environment.NewLine}{ex}");
                return;
            }
            */

            if (result != null)
            {

                ResultText.Text = await GetHttpContentWithToken(graphAPIEndpoint, result.AccessToken);
                DisplayBasicTokenInfo(result); ;

                var accessTokenProvider = new BaseBearerTokenAuthenticationProvider(new TokenProvider(result.AccessToken));
                tokenOffice = new GraphServiceClient(accessTokenProvider);


               
            }
        }

        public async Task<string> GetHttpContentWithToken(string url, string token)
        {
            var httpClient = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage response;
            try
            {
                var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, url);

                //Add the token in Authorization header
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                response = await httpClient.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        private void DisplayBasicTokenInfo(AuthenticationResult authResult)
        {
            TokenInfoText.Text = "";
            if (authResult != null)
            {
                TokenInfoText.Text += $"Username: {authResult.Account.Username}" + Environment.NewLine;
                TokenInfoText.Text += $"Token Expires: {authResult.ExpiresOn.ToLocalTime()}" + Environment.NewLine;
            }
        }

        public class TokenProvider : IAccessTokenProvider
        {
            public string tk;

            public TokenProvider(string tok) { tk = tok; }
            public Task<string> GetAuthorizationTokenAsync(Uri uri, Dictionary<string, object> additionalAuthenticationContext = default,
                CancellationToken cancellationToken = default)
            {
                var token = tk;
                // get the token and return it
                return Task.FromResult(token);
            }

            public AllowedHostsValidator AllowedHostsValidator { get; }
        }

        string filename;
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                //DE ESTA MANERA FILTRAMOS TODOS LOS ARCHIVOS EXCEL EN EL NAVEGADOR DE ARCHIVOS
                Filter = "Image | *.png;",

                //AQUÍ INDICAMOS QUE NOMBRE TENDRÁ EL NAVEGADOR DE ARCHIVOS COMO TITULO
                Title = "Seleccionar Imagen para Firma"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog.FileName;
                Settings.Default["firma"] = filename.ToString();
                Settings.Default.Save();

                firma.ImageLocation = Settings.Default["firma"].ToString();
                pb_sign_off.Hide();
                pb_sign_on.Show();
                pb_sign_on.BringToFront();

            }
        }


        private void pictureBox12_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// <summary>
        /// // TABPAGE3
        ///  /// /// /// /// /// /// /// /// /// /// /// /// /// /// ///</summary>

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void TokenInfoText_TextChanged(object sender, EventArgs e)
        {

            if (w_enviador.IsBusy != true)
            {
                lb_inicio.Text = tb_msj_inicial.Text;
                lb_final.Text = tb_msj_final.Text;
                progressBar1.Value = 0;
                progressBar1.Maximum = listaCorreos.Nodes.Count;

                w_enviador.WorkerSupportsCancellation = true;
                w_enviador.RunWorkerAsync();
                

            }
           
        }

        private void pb_sign_on_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                //DE ESTA MANERA FILTRAMOS TODOS LOS ARCHIVOS EXCEL EN EL NAVEGADOR DE ARCHIVOS
                Filter = "Image | *.png;",

                //AQUÍ INDICAMOS QUE NOMBRE TENDRÁ EL NAVEGADOR DE ARCHIVOS COMO TITULO
                Title = "Seleccionar Imagen para Firma"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog.FileName;
                Settings.Default["firma"] = filename.ToString();
                Settings.Default.Save();

                firma.ImageLocation = Settings.Default["firma"].ToString();
                pb_sign_off.Hide();
                pb_sign_on.Show();
                pb_sign_on.BringToFront();

            }
        }

      
        private void pb_sign_on_MouseHover(object sender, EventArgs e)
        {
            toolTip2.SetToolTip(pb_sign_on, Settings.Default["firma"].ToString());
        }

        private void pictureBox11_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pb_confirmar_Click(object sender, EventArgs e)
        {
            DialogResult resul = MessageBox.Show("Confirma el envío de los " + lb_reg.Text + " Reigstros en " + label7.Text + " Correos??", "Operator Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (resul == DialogResult.Yes)
            {
                if (tb_asunto.Text == string.Empty || tb_msj_inicial.Text == string.Empty || tb_msj_final.Text == string.Empty)
                {
                    MessageBox.Show("Quedan cammpos por llenar, verifique por favor!!");
                }
                else
                {

                    if (tabPage4.Parent == null)
                    {
                        // 0 es el index por la primera pestana
                        tabControl1.TabPages.Insert(0, tabPage4);
                    }
                    tabPage4.Show();

                    progressBar1.Width = tabPage4.Width - 5;
                    progressBar1.Location = new Point((tabPage4.Width / 2) - (progressBar1.Width / 2), progressBar1.Location.Y);

                    list_resultado.Width = tabPage4.Width - 3;

                    lb_contacto.Location = new Point((tabPage4.Width / 2) - (lb_contacto.Width / 2), lb_contacto.Location.Y);

                    list_resultado.Location = new Point((tabPage4.Width / 2) - (list_resultado.Width / 2), list_resultado.Location.Y);

                    lb_inicio.Location = new Point(list_resultado.Location.X, lb_inicio.Location.Y);
                    lb_final.Location = new Point(list_resultado.Location.X, lb_final.Location.Y);
                    pb_firma.Location = new Point((tabPage4.Width / 2) - (pb_firma.Width / 2), pb_firma.Location.Y);
                    pb_firma.ImageLocation = Settings.Default["firma"].ToString();

                    pictureBox11.Location = new Point(tabPage4.Width - pictureBox11.Width - 4, pictureBox11.Location.Y);


                    iniciar_perfil();

                    TokenInfoText.Location = new Point((tabPage4.Width / 2) - (TokenInfoText.Width / 2), TokenInfoText.Location.Y);

                }
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel_agregar.Hide();
        }

        int close = 0;
        private void eliminarTablaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            close = 1;
            this.Close();
        }

        private void correo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (close == 1)
            {
                correo correoNuevo = new correo();
                correoNuevo.Show();
                close = 0;  
            }
           
        }

        private void envíoSinTablaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}
