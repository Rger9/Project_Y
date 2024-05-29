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
    /// <summary>
    /// La classe "LikeDB" connecta amb la taula "Likes" de la base de dades, i pot inserir likes, eliminar-ne'n i obtenir els usuaris que han fet like a certa publicació
    /// </summary>
    public partial class LikeDB
    {
        /// <summary>
        /// Insereix un like a la base de dades
        /// </summary>
        /// <param name="l">like</param>
        public static void Inserir(LikeModel l)
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
        /// <summary>
        /// Obté una llista d'usuaris que hagin donat like a una publicació
        /// </summary>
        /// <param name="id">publicacio_id</param>
        /// <returns>llista d'ids de usuari</returns>
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
        /// <summary>
        /// Elimina un like de la base de dades
        /// </summary>
        /// <param name="l">like</param>
        public static void Delete(LikeModel l)
        {
            string cmdDelete = "DELETE FROM Likes " +
                               "WHERE user_id = @user_id AND publicacio_id = @publicacio_id";
            try
            {
                Connexio.Connectar();
                MySqlCommand comanda = new MySqlCommand(cmdDelete, Connexio.Connection);
                comanda.Parameters.Add("@user_id", MySqlDbType.Int32);
                comanda.Parameters.Add("@publicacio_id", MySqlDbType.Int32);

                comanda.Parameters["@user_id"].Value = l.User_id;
                comanda.Parameters["@publicacio_id"].Value = l.Publicacio_id;       

                int files_afectades = comanda.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("ERROR AL ELIMINAR DE LA BASE DE DADES 'LIKES' ");
            }
            finally
            {
                Connexio.Desconnectar();
            }
        }
        /// <summary>
        /// Comprova si l'objecte LikeModel existeix a la base de dades
        /// </summary>
        /// <param name="l"></param>
        /// <returns>true si existeix, fals altrament</returns>
        public static bool Exists(LikeModel l)
        {
            string cmdSelect = "SELECT * " +
                                "FROM Likes " +
                                "WHERE user_id = @user_id AND publicacio_id = @publicacio_id";
            bool existeix = true;
            try
            {
                Connexio.Connectar();
                MySqlCommand comanda = new MySqlCommand(cmdSelect, Connexio.Connection);
                comanda.Parameters.Add("@user_id", MySqlDbType.Int32);
                comanda.Parameters.Add("@publicacio_id", MySqlDbType.Int32);

                comanda.Parameters["@user_id"].Value = l.User_id;
                comanda.Parameters["@publicacio_id"].Value = l.Publicacio_id;

                MySqlDataReader reader = comanda.ExecuteReader();
                if (reader.Read())
                {
                    l.Publicacio_id = reader.GetInt32(0);
                    l.User_id = reader.GetInt32(1);
                }
                else existeix = false; 
                if (l.Publicacio_id == 0 || l.User_id == 0)
                {
                    existeix = false;
                }
            }
            catch
            {
                MessageBox.Show("ERROR AL ELIMINAR DE LA BASE DE DADES 'LIKES' ");
            }
            finally
            {
                Connexio.Desconnectar();
            }
            return existeix;

        }
    }
}
