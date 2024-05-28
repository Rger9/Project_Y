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
    public partial class TagDB
    {
        //TagModel t = new TagModel();
        /// <summary>
        /// Afegeix un tag a la taulda "Tag" de la base de dades "Db_Y"
        /// </summary>
        /// <param name="t">El Tag a inserir</param>
        public static void Inserir(TagModel t)
        {
            string cmdInsert = "INSERT INTO Tag(nom) " +
                                "VALUES(@nom)";
            try
            {
                Connexio.Connectar();
                MySqlCommand comanda = new MySqlCommand(cmdInsert, Connexio.Connection);
                comanda.Parameters.Add("@nom", MySqlDbType.VarChar, 20);

                comanda.Parameters["@nom"].Value = t.Nom;

                
                int files_afectades = comanda.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("ERROR AL INSERIR A LA BASE DE DADES 'TAG' ");
            }
            finally
            {
                Connexio.Desconnectar();
            }
        }
        /// <summary>
        /// Consegueix el id d'un Tag a partir del nom d'aquest
        /// </summary>
        /// <param name="nom">Nom del Tag</param>
        /// <returns>L'ID del Tag</returns>
        public static int GetTag_Id(string nom)
        {
            Connexio.Connectar();
            string cmdSelect = "SELECT tag_id " +
                                "FROM Tag " +
                                $"WHERE nom = @nom";
            MySqlCommand comanda = new MySqlCommand(cmdSelect, Connexio.Connection);
            comanda.Parameters.Add("@nom", MySqlDbType.String);
            comanda.Parameters["@nom"].Value = nom;
            
            
            int? resultat = (int?)comanda.ExecuteScalar();
            int r1 = 0;
            if (resultat != null)
                r1 = Convert.ToInt32(resultat);
            Connexio.Desconnectar();
            return r1;
        }
        /// <summary>
        /// Consegueix el tag a partir de l'id d'aquest
        /// </summary>
        /// <param name="id">Id del Tag</param>
        /// <returns>Tag</returns>
        public static TagModel GetTag(int id)
        {
            string cmdSelect = "SELECT nom " +
                                "FROM Tag " +
                                $"WHERE tag_id = @tag_id";
            TagModel tag = new TagModel();
            try
            {
                Connexio.Connectar();
                MySqlCommand comanda = new MySqlCommand(cmdSelect, Connexio.Connection);
                comanda.Parameters.Add("@tag_id", MySqlDbType.Int32);
                comanda.Parameters["@tag_id"].Value = id;
                
                string tag_name = (string)comanda.ExecuteScalar();

                tag.Tag_id = id;
                tag.Nom = tag_name;
            }
            catch
            {
                MessageBox.Show("ERROR: No s'ha aconseguit cap");
            }
            finally
            {
                Connexio.Desconnectar();
            }
            return tag;
        }
        /// <summary>
        /// Consegueix una llista de tots els Tags existents
        /// </summary>
        /// <returns>Llista de Ids</returns>
        public static List<int> ObtenirTotsId()
        {
            Connexio c = new Connexio();
            string cmdSelect = "SELECT tag_id " +
                                "FROM Tag";
            List<int> llistaId = new List<int>();
            try
            {
                Connexio.Connectar();
                MySqlCommand comanda = new MySqlCommand(cmdSelect, Connexio.Connection);
                
                MySqlDataReader reader = comanda.ExecuteReader();
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        llistaId.Add(id);
                    }
                }
                reader.Close();
            }
            catch
            {
                MessageBox.Show("ERROR: No hi ha cap tag");
            }
            finally
            {
                Connexio.Desconnectar();
            }
            return llistaId;
        }
    }
}
