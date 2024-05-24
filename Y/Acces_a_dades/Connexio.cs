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
        public static MySqlConnection Connectar()
        {
            string connectionString = $"Server={ip};Database={nom};Uid={user};Password={password};Port={port};";
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                //MessageBox.Show("Connexio oberta OK");

                //string cmdSelect = "SELECT COUNT(*) " + " FROM Publicacio;";
                //MySqlCommand oCommand = new MySqlCommand(cmdSelect, connection);
                //long num_contactes = (long)oCommand.ExecuteScalar();
                //MessageBox.Show(num_contactes.ToString());

                MessageBox.Show("Connexio oberta OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obrir la BD: " + ex.Message);
            }
            //finally
            //{
            //    if (connection != null)
            //    {
            //        connection.Close();
            //        MessageBox.Show("Connexio tancada OK");
            //    }
            //}
            return connection;
        }
        public static void Desconnectar()
        {
            if (!connection.IsDisposed)
            {
                connection.Close();
                MessageBox.Show("La connexio sha desconnectat");
            }
            else
                MessageBox.Show("La connexio no sha tancat pq no estava oberta burro");
        }
    }
}
