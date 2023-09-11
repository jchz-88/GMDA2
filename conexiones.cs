using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using HMDA.Properties;

namespace HMDA
{
    internal class conexiones
    {
        
        private string Servidor;
        private string Puerto;

        private string Usuario;
        private string Clave;
        private static conexiones Con = null;


        private conexiones()
        {

            this.Servidor = Settings.Default["server"].ToString();
            this.Puerto = "3306";
            this.Usuario = "jchz";
            this.Clave = "";

        }
        public MySqlConnection CrearConexion(string x)
        {
            MySqlConnection Cadena = new MySqlConnection();
            try
            {
                Cadena.ConnectionString = "SERVER=" + this.Servidor +
                                            "; PORT=" + this.Puerto +
                                            "; DATABASE=" + x +
                                            "; UID=" + this.Usuario +
                                            "; PASSWORDS=" + this.Clave;
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }

        public static conexiones getInstancia()
        {
            if (Con==null)
            {
                Con = new conexiones();
            }
            return Con;
        }
    }
}
