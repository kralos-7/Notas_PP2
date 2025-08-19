using System;
using System.Data.SQLite;

namespace ConexionSQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ruta al archivo de la base de datos
            string connectionString = "Data Source=C:\\sqlite\\mi_base.db;Version=3;";

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    Console.WriteLine("✅ Conexión exitosa a SQLite!");

                    // Crear tabla si no existe
                    string sqlTabla = "CREATE TABLE IF NOT EXISTS usuarios (id INTEGER PRIMARY KEY AUTOINCREMENT, nombre TEXT)";
                    SQLiteCommand cmdTabla = new SQLiteCommand(sqlTabla, conexion);
                    cmdTabla.ExecuteNonQuery();

                    // Insertar un dato de prueba
                    string sqlInsert = "INSERT INTO usuarios (nombre) VALUES ('Carlos')";
                    SQLiteCommand cmdInsert = new SQLiteCommand(sqlInsert, conexion);
                    cmdInsert.ExecuteNonQuery();

                    // Leer datos
                    string sqlSelect = "SELECT * FROM usuarios";
                    SQLiteCommand cmdSelect = new SQLiteCommand(sqlSelect, conexion);

                    using (SQLiteDataReader reader = cmdSelect.ExecuteReader())
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
