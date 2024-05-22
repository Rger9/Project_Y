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
    public partial class TagDB
    {
        //TagModel t = new TagModel();
        /// <summary>
        /// Afegeix un tag a la taulda "Tag" de la base de dades "Db_Y"
        /// </summary>
        /// <param name="t">El Tag a inserir</param>
        public void Inserir(TagModel t)
        {
            Connexio c = new Connexio();
            string cmdInsert = "INSERT INTO Tag(nom)" +
                                "VALUES(@nom)";
            try
            {
                MySqlCommand comanda = new MySqlCommand(cmdInsert, c.Connection);
                comanda.Parameters.Add("@nom", MySqlDbType.VarChar, 20);

                comanda.Parameters["@nom"].Value = t.Nom;

                c.Connectar();
                int files_afectades = comanda.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("ERROR AL INSERIR A LA BASE DE DADES 'TAG' ");
            }
            finally
            {
                c.Desconnectar();
            }
        }
        /// <summary>
        /// Consegueix el id d'un Tag a partir del nom d'aquest
        /// </summary>
        /// <param name="nom">Nom del Tag</param>
        /// <returns>L'ID del Tag</returns>
        public static int GetTag_Id(string nom)
        {
            Connexio c = new Connexio();
            string cmdSelect = "SELECT tag_id" +
                                "FROM Tag" +
                                $"WHERE nom = {nom}";
            MySqlCommand comanda = new MySqlCommand(cmdSelect, c.Connection);
            c.Connectar();
            
            int? resultat = (int?)comanda.ExecuteScalar();
            int r1 = 0;
            if (resultat != null)
                r1 = Convert.ToInt32(resultat);
            c.Desconnectar();
            return r1;
        }
        /// <summary>
        /// Consegueix el tag a partir de l'id d'aquest
        /// </summary>
        /// <param name="id">Id del Tag</param>
        /// <returns>Tag</returns>
        public static TagModel GetTag(int id)
        {
            Connexio c = new Connexio();
            string cmdSelect = "SELECT nom" +
                                "FROM Tag" +
                                $"WHERE tag_id = {id}";
            TagModel tag = new TagModel();
            try
            {
                MySqlCommand comanda = new MySqlCommand(cmdSelect, c.Connection);
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
                c.Desconnectar();
            }
            return tag;
        }
        public static List<int> GetAllTag_Id()
        {
            Connexio c = new Connexio();
            string cmdSelect = "SELECT tag_id" +
                                "FROM Tag";
            List<int> tags = new List<int>();
            try
            {
                MySqlCommand comanda = new MySqlCommand(cmdSelect, c.Connection);
                MySqlDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    tags.Add(reader.GetInt32(0));
                }
            }
            catch
            {
                MessageBox.Show("ERROR: No hi ha cap tag");
            }
            finally
            {
                c.Desconnectar();
            }
            return tags;
        }
    }
}
