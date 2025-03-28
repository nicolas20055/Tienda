using System;
using MySql.Data.MySqlClient;
namespace CapaDatos
{
    public class PruebaConexion
    {
        public static void Probar()
        {
            MySqlConnection conexion = Conexion.Conectar();

            if (conexion.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("¡Conexión a la base de datos exitosa!");
                Conexion.Cerrar(); // Cierra la conexión después de verificar
            }
            else
            {
                Console.WriteLine($"Error al conectar a la base de datos. Estado: {conexion.State}");
                Console.WriteLine($"Cadena de Conexión: {Conexion.CadenaConexion}");
            }
        }
    }
}