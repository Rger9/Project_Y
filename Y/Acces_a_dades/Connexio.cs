using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Y.AccesADades
{
    /// <summary>
    /// La classe "Connexio" permet a l'aplicació connectar i desconnectar amb la base de dades
    /// </summary>
    public class Connexio
    {
        private static string ip = "localhost";
        private static string nom = "Db_y";
        private static string user = "root";
        private static string password = "";
        private static int port = 3306;
        private static MySqlConnection connection = new MySqlConnection($"Server={ip};Database={nom};Uid={user};Password={password};Port={port};");

        public static MySqlConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }
        /// <summary>
        /// Crea una connexió amb la base de dades
        /// </summary>
        /// <returns> Retorna un objecte MySqlConnection </returns>
        public static MySqlConnection Connectar()
        {
            string connectionString = $"Server={ip};Database={nom};Uid={user};Password={password};Port={port};";
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obrir la BD: " + ex.Message);
            }
            return connection;
        }
        /// <summary>
        /// Si l'aplicació es troba connectada a la base da dades, la desconnecta
        /// </summary>
        public static void Desconnectar()
        {
            if (!connection.IsDisposed)
            {
                connection.Close();
            }
            else
                MessageBox.Show("La connexio no sha tancat pq no estava oberta");
        }
    }
}
