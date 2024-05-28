using Y;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Negoci;
using MySql.Data.MySqlClient;
using System.Windows;
using Y.AccesADades;

namespace Y.Model
{
    /// <summary>
    /// La classe "ComentariDB" connecta amb la taula "Comentari" de la base de dades, i pot inserir comentaris i seleccionar-ne'n
    /// </summary>
    public partial class ComentariDB
    {
        /// <summary>
        /// Insereix un comentari a la base de dades
        /// </summary>
        /// <param name="c">El comentari</param>
        public static void Inserir(ComentariModel c)
        {
            string cmdInsert = "INSERT INTO Comentari(user_id, publicacio_id, data_c, contingut) " +
                                "VALUES(@user_id, @publicacio_id, @data_c, @contingut)";
            try
            {
                Connexio.Connectar();
                MySqlCommand comanda = new MySqlCommand(cmdInsert, Connexio.Connection);
                comanda.Parameters.Add("@user_id", MySqlDbType.Int32);
                comanda.Parameters.Add("@publicacio_id", MySqlDbType.Int32);
                comanda.Parameters.Add("@data_c", MySqlDbType.DateTime);
                comanda.Parameters.Add("@contingut", MySqlDbType.VarChar, 300);

                comanda.Parameters["@user_id"].Value = c.User_id;
                comanda.Parameters["@publicacio_id"].Value = c.Publicacio_id;
                comanda.Parameters["@data_c"].Value = c.Data_c;
                comanda.Parameters["@contingut"].Value = c.Contingut;

                int files_afectades = comanda.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("ERROR AL INSERIR A LA BASE DE DADES 'PUBLICACIÓ' ");
            }
            finally
            {
                Connexio.Desconnectar();
            }
        }
        /// <summary>
        /// A partí de l'ID d'un comentari el retorna
        /// </summary>
        /// <param name="id">ID del comentari</param>
        /// <returns>el comentari</returns>
        public static ComentariModel GetComentari(int id)
        {
            string cmdSelect = "SELECT * " +
                                "FROM comentari " +
                                $"WHERE comentari_id = @comentari_id";
            ComentariModel c = new ComentariModel();
            try
            {
                MySqlCommand comanda = new MySqlCommand(cmdSelect, Connexio.Connection);
                comanda.Parameters.Add("@comentari_id", MySqlDbType.Int32);
                comanda.Parameters["@comentari_id"].Value = id;
                Connexio.Connectar();
                MySqlDataReader reader = comanda.ExecuteReader();
                if (reader.Read())
                {
                    c.User_id = reader.GetInt32(1);
                    c.Publicacio_id = reader.GetInt32(2);
                    c.Data_c = reader.GetDateTime(3);
                    c.Contingut = reader.GetString(4);
                }
                reader.Close();
            }
            catch
            {
                MessageBox.Show("ERROR: No s'ha trobat un comentari amb la ID indicada");
            }
            finally
            {
                Connexio.Desconnectar();
            }
            return c;

        }
        /// <summary>
        /// Retorna tots els comentaris de certa publicació, indicada per la seva Id
        /// </summary>
        /// <param name="postId">Id de la publicació</param>
        /// <returns>Tots els comentaris de la publicació</returns>
        public static List<ComentariModel> GetComentarisPost(int postId)
        {
            string cmdSelect = "SELECT * " +
                                "FROM comentari " +
                                $"WHERE publicacio_id = @publicacio_id";
            List<ComentariModel> llistaComentaris = new List<ComentariModel>();
            ComentariModel comentari = new ComentariModel();
            try
            {
                Connexio.Connectar();
                MySqlCommand comanda = new MySqlCommand(cmdSelect, Connexio.Connection);
                comanda.Parameters.Add("@publicacio_id", MySqlDbType.Int32);
                comanda.Parameters["@publicacio_id"].Value = postId;
                MySqlDataReader reader = comanda.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        comentari.Comentari_id = reader.GetInt32(0);
                        comentari.User_id = reader.GetInt32(1);
                        comentari.Data_c = reader.GetDateTime(3);
                        comentari.Contingut = reader.GetString(4);
                        llistaComentaris.Add(ComentariNegoci.GetComentariCopy(comentari));
                    }
                }
                reader.Close();
            }
            catch
            {
                MessageBox.Show($"ERROR: No hi ha comentaris amb la publicació_id {postId}");
            }
            finally
            {

                Connexio.Desconnectar();
            }
            return llistaComentaris;
        }
    }
}
