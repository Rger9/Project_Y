using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Y.Acces_a_dades
{
    internal class Connexio
    {
        private MySqlConnection connection;


        public MySqlConnection Connectar()
        {
            string connectionString = "Server=localhost;Database=Db_y;Uid=root;Password=;Port=3306;";
            connection = new MySqlConnection();
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
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    MessageBox.Show("Connexio tancada OK");
                }
            }
            return connection;
        }
        public void Desconnectar()
        {
            if (!this.connection.IsDisposed)
            {
                this.connection.Close();
                MessageBox.Show("La connexio sha tancat de forma mena");
            }
            MessageBox.Show("La connexio no sha tancat pq no estava oberta burro");
                
            
        }
    }
}
