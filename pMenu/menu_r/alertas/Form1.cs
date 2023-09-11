using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.Security.EnterpriseData;
using Windows.UI.Popups;
using HMDA;

namespace ModuloAlertas
{
    public partial class Form1 : Form
    {


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        //Conexión a BBDD de Titulos
        
        MySqlConnection con = new MySqlConnection();
        

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            con = conexiones.getInstancia().CrearConexion("gmda");

            this.BackColor = Color.Black;
            this.Opacity = 0.9;
            lb_comu.ForeColor = Color.AliceBlue;
            lb_alertas.ForeColor = Color.AliceBlue;

            dataGridView1.Hide();
            lb_titu.Hide();
            lb_desc.Hide();
            lb_link.Hide(); 
            this.Size = new Size(this.Width, this.Height - dataGridView1.Height -20);
            this.AutoSize = true;

            this.Region = Region.FromHrgn(CreateRoundRectRgn(3, 3, this.Width - 3, this.Height - 3, 20, 20));

            int w = Screen.PrimaryScreen.WorkingArea.Width / 2;
            int h = Screen.PrimaryScreen.WorkingArea.Height / 2;
            this.Location = new Point(w , h - this.Height -160);

            carga_urgente();
        }

        private void carga_urgente()
        {
            con = conexiones.getInstancia().CrearConexion("gmda");
            try
            {
                con.Open();
                string cbox = "SELECT urgente, contenido FROM alerta_comunicados;";

                MySqlDataAdapter datatable = new MySqlDataAdapter(cbox, con);
                DataTable dt = new DataTable();

                datatable.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    
                    foreach (DataRow reg in dt.Rows)
                    {
                        if ((int)reg["urgente"] == 1)
                        {
                            banner bn = new banner(reg["contenido"].ToString());
                            bn.Show();
                        }
                        
                    }
                }
               

            }
            catch (Exception ex)
            {

                MessageBox.Show("Problemas con la conexión   \n\r" + ex);
            }
            
        }
        
        private void lb_alertas_MouseEnter(object sender, EventArgs e)
        {
            if (lb_comu.ForeColor == Color.White)
            {
                lb_alertas.ForeColor = Color.White;
            }
        }

        private void lb_alertas_MouseLeave(object sender, EventArgs e)
        {
            if (lb_comu.ForeColor == Color.White)
            {
                lb_alertas.ForeColor = Color.DimGray;
            }
        }

        private void lb_comu_MouseEnter(object sender, EventArgs e)
        {
            if (lb_alertas.ForeColor == Color.White)
            {
                lb_comu.ForeColor = Color.White;
            }

        }

        private void lb_comu_MouseLeave(object sender, EventArgs e)
        {
            if (lb_alertas.ForeColor == Color.White)
            {
                lb_comu.ForeColor = Color.DimGray;
            }
        }

        private void lb_comu_Click(object sender, EventArgs e)
        {
            lb_link.Show();
            lb_titu.Show();
            lb_link.Show();
            lb_desc.Show();
            lb_comu.ForeColor = Color.White;
            dataGridView1.Show();
            lb_alertas.ForeColor = Color.DimGray;
            carga_comu();
        }

        private void lb_alertas_Click(object sender, EventArgs e)
        {
            lb_link.Hide();
            lb_titu.Hide(); 
            lb_link.Hide();
            lb_desc.Show();
            dataGridView1.Show();
            lb_alertas.ForeColor = Color.White;

            lb_comu.ForeColor = Color.DimGray;
            carga_alertas();
        }

        private void carga_comu()
        {
           
            dataGridView1.Columns.Clear();

            

            con.Close();
            try
            {
                con.Open();
                string cbox = "SELECT id, urgente, titulo AS Titulo, contenido AS Descripcion, link AS Link, tipo FROM alerta_comunicados WHERE tipo='comunicado';";

                MySqlDataAdapter datatable = new MySqlDataAdapter(cbox, con);
                DataTable dt = new DataTable();
                
                datatable.Fill(dt);

                con.Close();
                // 0
                dataGridView1.Columns.Add("Titulo", "Titulo");
                // 1
                dataGridView1.Columns.Add("Descripción", "Descripción");


                DataGridViewButtonColumn lk = new DataGridViewButtonColumn();
                lk.Name = "LK";
                lk.Text = "Link";
                lk.HeaderText = "Link";
                
                lk.UseColumnTextForButtonValue = true;
                // 2
                dataGridView1.Columns.Add(lk);
                // 3
                dataGridView1.Columns.Add("Link", "Link");
                dataGridView1.Columns["Link"].Visible = false;
                // 4
                dataGridView1.Columns.Add("id", "id");
                dataGridView1.Columns["id"].Visible = false;
                // 5
                dataGridView1.Columns.Add("tipo", "tipo");
                dataGridView1.Columns["tipo"].Visible = false;
                // 6
                dataGridView1.Columns.Add("orden", "orden");
                dataGridView1.Columns["orden"].Visible = false;


                

                dataGridView1.Columns[0].Width = (int)(dataGridView1.Width * 0.27);
                dataGridView1.Columns[1].Width = (int)(dataGridView1.Width * 0.63);
                dataGridView1.Columns[2].Width = (int)(dataGridView1.Width * 0.10);


                dataGridView1.Columns[0].DefaultCellStyle.Alignment= DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                int i = 0;
                if (dt.Rows.Count >0)
                {

                
                    foreach (DataRow fila in dt.Rows)
                    {


                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = fila["Titulo"].ToString();

                        dataGridView1.Rows[i].Cells[1].Value = fila["Descripcion"].ToString();

                        bool y = vistas((int)fila["id"], "comunicado");


                        if (!y)
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkOrange;
                            dataGridView1.Rows[i].Cells[6].Value = "1";
                            if ((int)fila["urgente"] == 1)
                            {
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            }
                        }
                        else
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Black;
                            dataGridView1.Rows[i].Cells[5].Value = "0";
                        }

                        dataGridView1.Rows[i].Cells[3].Value = fila["Link"].ToString();

                        if ((string)dataGridView1.Rows[i].Cells[3].Value == "")
                        {
                            dataGridView1.Rows[i].Cells[2].Value = false;
                            dataGridView1.Rows[i].Cells[2] = new DataGridViewTextBoxCell();
                            dataGridView1.Rows[i].Cells[2].Value = "";
                        }

                        dataGridView1.Rows[i].Cells[4].Value = (int)fila["id"];
                        dataGridView1.Rows[i].Cells[5].Value = "comunicado";
                        i++;
                    }
                    int j = dataGridView1.Rows[0].Height;
                
                    dataGridView1.Size = new Size(this.Width - 10, (j*i) + 5);
                    this.Size = new Size(this.Width, dataGridView1.Height);
                    this.AutoSize = true;

                    int k = this.Height - dataGridView1.Size.Height;

                    this.Size = new Size(this.Width +3, k+ dataGridView1.Size.Height - j);
                    this.AutoSize = true;

                    this.Region = Region.FromHrgn(CreateRoundRectRgn(3, 3, this.Width - 3, this.Height - 3, 20, 20));

                    if (dataGridView1.Rows[0].Selected == true)
                    {
                    
                        dataGridView1.CurrentRow.Selected = false;
                    }
                
                    dataGridView1.ClearSelection();
                
                    dataGridView1.CurrentCell = null;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Problemas con la conexión   \n\r" + ex);
            }
            
            dataGridView1.Sort(this.dataGridView1.Columns["orden"], ListSortDirection.Descending);

            
        }

        private bool vistas(int id, string tipo)
        {
            bool resultado = false;
            
            con.Close();
            try
            {
                con.Open();

               string cbox = "SELECT * FROM alerta_alertavistas WHERE tipo = '" + tipo + "' AND id_alerta =" + id + " AND usuario = '" + Environment.UserName + "' ;";

                

                MySqlDataAdapter datatable = new MySqlDataAdapter(cbox, con);
                DataTable dt = new DataTable();

                con.Close();

                datatable.Fill(dt);
                int filas = dt.Rows.Count;
                if (filas > 0)
                {
                    foreach (DataRow reg in dt.Rows)
                    {
                        if ((int)reg["estado"] == 0)
                        {
                            resultado= false;
                            break;
                        }
                        else
                        {
                            resultado = true;
                            break;
                        }

                    }
                }
                else
                {
                    con.Open();


                    string query = "INSERT INTO alerta_alertavistas(id_alerta, usuario, estado, tipo) VALUES (" + id + ", '" + Environment.UserName + "' ," + 0 + ", '" + tipo + "');";
                    MySqlCommand cmd2 = new MySqlCommand(query, con);
                    cmd2.ExecuteNonQuery();
                    con.Clone();
                    resultado = false;
                }
                

            }
            catch (Exception)
            {
                MessageBox.Show("Problemas con la conexión");
                 
            }

            if (resultado)
            {
                return true;
            }
            else
            {
                return false;   
            }
        }

        

        private void carga_alertas()
        {

            dataGridView1.Columns.Clear();
            con.Close();
            try
            {
                con.Open();
                string cbox = "SELECT id, urgente, contenido AS Contenido FROM alerta_comunicados WHERE tipo='alerta';";

                MySqlDataAdapter datatable = new MySqlDataAdapter(cbox, con);
                DataTable dt = new DataTable();

                datatable.Fill(dt);
                // 0
                dataGridView1.Columns.Add("Descripción", "Descripción");
                // 1
                dataGridView1.Columns.Add("id", "id");
                dataGridView1.Columns["id"].Visible = false;
                // 2
                dataGridView1.Columns.Add("tipo", "tipo");
                dataGridView1.Columns["tipo"].Visible = false;
                // 3
                dataGridView1.Columns.Add("orden", "orden");
                dataGridView1.Columns["orden"].Visible = false;

                dataGridView1.Columns[0].Width = (int)(dataGridView1.Width * 1);

                con.Close();
                int i = 0;
                foreach (DataRow fila in dt.Rows)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = fila["Contenido"].ToString();

                    dataGridView1.Rows[i].Cells[1].Value = (int)fila["id"];

                    bool y = vistas((int)fila["id"], "alerta");


                    if (!y)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkOrange;
                        dataGridView1.Rows[i].Cells[3].Value = "1";
                        if ((int)fila["urgente"] == 1)
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        }
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[3].Value = "0";
                    }

                    dataGridView1.Rows[i].Cells[2].Value = "alerta";

                    i++;

                }
                int j = dataGridView1.Rows[0].Height;

                dataGridView1.Size = new Size(this.Width-13, (j * i) + 5);
                this.Size = new Size(this.Width, dataGridView1.Height);
                this.AutoSize = true;

                int k = this.Height - dataGridView1.Size.Height;

                this.Size = new Size(this.Width, k + dataGridView1.Size.Height - j);
                this.AutoSize = true;

                this.Region = Region.FromHrgn(CreateRoundRectRgn(3, 3, this.Width - 3, this.Height - 3, 20, 20));
                
                dataGridView1.CurrentCell.Selected = false;
                dataGridView1.ClearSelection();
                dataGridView1.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas con la conexión \n\r" + ex);
            }

            dataGridView1.Sort(dataGridView1.Columns["orden"], ListSortDirection.Descending);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.CurrentCell.Selected = false;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            if (e.ColumnIndex == 2)
            {
                System.Diagnostics.Process.Start(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                con.Open();

                string query = "UPDATE alerta_alertavistas SET estado=1 WHERE id_alerta = " + dataGridView1.CurrentRow.Cells[4].Value + " AND usuario = '" + Environment.UserName + "' AND tipo = 'comunicado' ;";
                MySqlCommand cmd2 = new MySqlCommand(query, con);
                cmd2.ExecuteNonQuery();
                con.Clone();
                carga_comu();
            }

        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
            if (e.ColumnIndex == 0)
            {
                if (dataGridView1.CurrentRow.Cells[2].Value.ToString() == "alerta")
                {
                    var confirmResult = MessageBox.Show("Confirmar Lectura ?? ", "Confirmación!!", MessageBoxButtons.YesNo);

                    if (confirmResult == DialogResult.Yes)
                    {
                        con.Open();

                        string query = "UPDATE alerta_alertavistas SET estado=1 WHERE id_alerta = " + dataGridView1.CurrentRow.Cells[1].Value + " AND usuario = '" + Environment.UserName + "' AND tipo = 'alerta' ;";
                        MySqlCommand cmd2 = new MySqlCommand(query, con);
                        cmd2.ExecuteNonQuery();

                        con.Clone();
                        carga_alertas();
                    }
                }
               
                
            }

        }

        private void pb_close_Click(object sender, EventArgs e)
        {

            foreach (Form fmr in Application.OpenForms)
            {
                if (fmr.Name == "banner")
                {
                    fmr.Close();
                    break;
                }
            }
            this.Close();
        }


        public int xClick = 0, yClick = 0;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HMDA.pMenu.menu_r.alertas.nueva_alerta na = new HMDA.pMenu.menu_r.alertas.nueva_alerta();
            na.Show();
            this.Close();
        }

        /// <summary>
        /// MODULO: TIMER....................
        /// </summary>



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        
    }

}
