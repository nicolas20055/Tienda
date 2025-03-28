using System.Configuration;
using MySql.Data.MySqlClient; // Importa el espacio de nombres de MySQL

public class Conexion
{
    private static string cadena = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
    private static MySqlConnection conexion = new MySqlConnection(cadena); // Usa MySqlConnection

    public static MySqlConnection Conectar() // Devuelve MySqlConnection
    {
        if (conexion.State == System.Data.ConnectionState.Closed)
        {
            conexion.Open();
        }
        return conexion;
    }

    public static void Cerrar()
    {
        if (conexion.State == System.Data.ConnectionState.Open)
        {
            conexion.Close();
        }
    }

    public static string CadenaConexion { get => cadena; }
}