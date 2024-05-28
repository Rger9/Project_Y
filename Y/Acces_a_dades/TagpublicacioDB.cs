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
    /// La classe "TagDB" connecta amb la taula "Tag" de la base de dades, i pot inserir tags i fer varies seleccions   
    /// </summary>
    public partial class TagpublicacioDB
    {
        /// <summary>
        /// Insereix una entrada a la base de dades "TagPublicacio"
        /// </summary>
        /// <param name="tp"></param>
        public static void Inserir(TagpublicacioModel tp)
        {
            string cmdInsert = "INSERT INTO TagPublicacio(publicacio_id, tag_id) " +
                                "VALUES(@publicacio_id, @tag_id)";
            try
            {
                Connexio.Connectar();
                MySqlCommand comanda = new MySqlCommand(cmdInsert, Connexio.Connection);
                comanda.Parameters.Add("@publicacio_id", MySqlDbType.Int32);
                comanda.Parameters.Add("@tag_id", MySqlDbType.Int32);

                comanda.Parameters["@publicacio_id"].Value = tp.Publicacio_id;
                comanda.Parameters["@tag_id"].Value = tp.Tag_id;

                int files_afectades = comanda.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("ERROR AL INSERIR A LA BASE DE DADES 'TagPublicacio' ");
            }
            finally
            {
                Connexio.Desconnectar();
            }
        }
        /// <summary>
        /// Donada una publicacio_id aconsegueix tots els tags adjuntats a la publicació
        /// </summary>
        /// <param name="post_id">la publicacio_id</param>
        /// <returns></returns>
        public static List<int> GetTagsIdPublicacio(int post_id)
        {
            string cmdSelect = "SELECT tag_id " +
                                "FROM tagpublicacio " +
                                "WHERE publicacio_id = @publicacio_id";
            List<int> llistaId = new List<int>();
            try
            {
                Connexio.Connectar();
                MySqlCommand comanda = new MySqlCommand(cmdSelect, Connexio.Connection);
                comanda.Parameters.Add("@publicacio_id", MySqlDbType.Int32);
                comanda.Parameters["@publicacio_id"].Value = post_id;

                MySqlDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    llistaId.Add(reader.GetInt32(0));
                }
            }
            catch
            {
                MessageBox.Show("ERROR: no s'han pogut obternir les id tags");
            }
            finally
            {
                Connexio.Desconnectar();
            }
            return llistaId;
        }
       
    }
}
