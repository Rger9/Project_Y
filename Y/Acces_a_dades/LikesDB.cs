using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Y.AccesADades;
using Y.Negoci;

namespace Y.Model
{
    public partial class LikesDB
    {
        public static void Inserir(LikesModel l)
        {
            string cmdInsert = "INSERT INTO Likes(user_id, publicacio_id) " +
                               "VALUES(@user_id, @publicacio_id)";
            try
            {
                Connexio.Connectar();
                MySqlCommand comanda = new MySqlCommand(cmdInsert, Connexio.Connection);
                comanda.Parameters.Add("@user_id", MySqlDbType.Int32);
                comanda.Parameters.Add("@publicacio_id", MySqlDbType.Int32);

                comanda.Parameters["@user_id"].Value = l.User_id;
                comanda.Parameters["@publicacio_id"].Value = l.Publicacio_id;       

                int files_afectades = comanda.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("ERROR AL INSERIR A LA BASE DE DADES 'LIKES' ");
            }
            finally
            {
                Connexio.Desconnectar();
            }
        }
        public static List<int> GetUsers(int id)
        {
            string cmdSelect = "SELECT user_id " +
                                "FROM likes " +
                                $"WHERE publicacio_id = @publicacio_id";
            List<int> users = new List<int>();
            try 
            { 
                Connexio.Connectar();
                MySqlCommand comanda = new MySqlCommand(cmdSelect, Connexio.Connection);
                comanda.Parameters.Add("@publicacio_id", MySqlDbType.Int32);
                comanda.Parameters["@publicacio_id"].Value = id;
                
                MySqlDataReader reader = comanda.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        users.Add(reader.GetInt32(0));
                    }
                }
                
                reader.Close();
            }
            catch
            {
                MessageBox.Show("ERROR: No s'ha trobat un like amb la ID_publicacio indicada");
            }
            finally
            {
                Connexio.Desconnectar();
            }
            return users;

        }
    }
}
