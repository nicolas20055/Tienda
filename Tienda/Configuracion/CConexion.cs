using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Tienda.Configuracion
{
    internal class CConexion
    {
        private MySqlConnection conectar = null;
        private static String usuario = "root";
        private static String contraseña = "";
        private static String bd = "bd_post";
        private static String ip = "localhost";
        private static String puerto = "3306";

        private string cadena = $"Server={ip};Port={3306};Database={bd};Uid={usuario};Pwd={contraseña};";

        public MySqlConnection EstablecerConexion()
        {
            try
            {
                conectar = new MySqlConnection(cadena);
                conectar.Open();
                MessageBox.Show("Conexión exitosa");
                return conectar;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al conectar a la base de datos");
                return null;
            }
            return conectar;
        }
        public void CerrarConexion()
        {
            try
            {
                if(conectar != null && conectar.State == System.Data.ConnectionState.Open)
            conectar.Close();
                MessageBox.Show("Conexión cerrada");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al cerrar la conexión");
            }
        }
    }
}
