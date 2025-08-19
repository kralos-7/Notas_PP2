using System;
using MySql.Data.MySqlClient;

namespace ConexionMySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cadena de conexión
            string connectionString = "Server=localhost;Database=prueba;User ID=root;Password=;SslMode=none;";

            // Crear conexión
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    Console.WriteLine("✅ Conexión exitosa a MySQL!");

                    // Crear un comando
                    string query = "SELECT * FROM usuarios"; // tu tabla de prueba
                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    // Ejecutar y leer resultados
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["id"]}, Nombre: {reader["nombre"]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Error: " + ex.Message);
                }
            }

            Console.WriteLine("Presiona una tecla para salir...");
            Console.ReadKey();
        }
    }
}
