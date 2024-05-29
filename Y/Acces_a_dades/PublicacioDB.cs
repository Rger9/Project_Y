using Y;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Negoci;
using Y.AccesADades;
using Mysqlx.Crud;
using System.Windows;
using System.Data;
using System.Collections.Specialized;
using System.Reflection.PortableExecutable;

namespace Y.Model
{
    /// <summary>
    /// La classe "PublicacioDB" connecta amb la taula "Publicacio" de la base de dades, i pot inserir-hi publicacions i fer diverses seleccions
    /// </summary>
    public partial class PublicacioDB
    {
        /// <summary>
        /// Insereix una publicaci� a la base de dades
        /// </summary>
        /// <param name="p"></param>
        public static void Inserir(PublicacioModel p)
        {
            Connexio c = new Connexio();
            string cmdInsert = "INSERT INTO Publicacio(user_id, data_p, titol, contingut) " +
                                "VALUES(@user_id, @data_p, @titol, @contingut)";
            try
            {
                Connexio.Connectar();
                MySqlCommand comanda = new MySqlCommand(cmdInsert,Connexio.Connection);
                comanda.Parameters.Add("@user_id", MySqlDbType.Int32);
                comanda.Parameters.Add("@data_p", MySqlDbType.DateTime);
                comanda.Parameters.Add("@titol", MySqlDbType.VarChar, 30);
                comanda.Parameters.Add("@contingut", MySqlDbType.VarChar, 300);

                comanda.Parameters["@user_id"].Value = p.User_id;
                comanda.Parameters["@data_p"].Value = p.Data_p; 
                comanda.Parameters["@titol"].Value = p.Titol;
                comanda.Parameters["@contingut"].Value = p.Contingut;

                
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
        /// A partir de la ID d'una publicaacio, busca dita publicacio a la base de dades i la retorna
        /// </summary>
        /// <param name="id">ID de la publicació a cercar</param>
        /// <returns>La publicació</returns>
        public static PublicacioModel GetPublicacio(int id)
        {
            Connexio c = new Connexio();
            string cmdSelect_TOT = "SELECT * " +
                                    "FROM publicacio " +
                                    $"WHERE publicacio_id = @publicacio_id";
            PublicacioModel p = new PublicacioModel();
            try
            {
                Connexio.Connectar();
                MySqlCommand comanda = new MySqlCommand(cmdSelect_TOT, Connexio.Connection);
                comanda.Parameters.Add("@publicacio_id", MySqlDbType.Int32);
                comanda.Parameters["@publicacio_id"].Value = id;
                MySqlDataReader reader = comanda.ExecuteReader();
                if (reader.Read())
                {
                    p.Publicacio_id = reader.GetInt32(0);
                    p.User_id = reader.GetInt32(1);
                    p.Data_p = reader.GetDateTime(2);
                    p.Titol = reader.GetString(3);
                    p.Contingut = reader.GetString(4);
                }
                reader.Close();
            }
            catch
            {
                MessageBox.Show($"ERROR: No s'ha trobat una publicació amb ID@publicacio_id");
            }
            finally
            {
                Connexio.Desconnectar();
            }
            return p;
        }
        /// <summary>
        /// Obte totes les Ids de les publicacions a la base de dades
        /// </summary>
        /// <returns>Una llista amb totes les Ids</returns>
        public static List<int> ObtenirTotsId()
        {
            Connexio c = new Connexio();
            string cmdSelect = "SELECT publicacio_id " +
                                "FROM publicacio";
            List<int> llistaId = new List<int>();
            try
            {
                Connexio.Connectar();
                MySqlCommand comanda = new MySqlCommand(cmdSelect, Connexio.Connection);
                MySqlDataReader reader = comanda.ExecuteReader(); 
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        llistaId.Add(id);
                    }
                }
                reader.Close();
            }
            catch
            {
                MessageBox.Show("ERROR: No s'han pogut obtenir tots els id");
            }
            finally
            {
                Connexio.Desconnectar();
            }
            return llistaId;
        }
    }
}
