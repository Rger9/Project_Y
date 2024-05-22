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

namespace Y.Model
{
    public partial class PublicacioDB
    {
        /// <summary>
        /// Insereix una publicació a la base de dades
        /// </summary>
        /// <param name="p"></param>
        public static void Inserir(PublicacioModel p)
        {
            Connexio c = new Connexio();
            string cmdInsert = "INSERT INTO Publicacio(user_id, data_p, titol, contingut)" +
                                "VALUES(@user_id, @data_p, @titol, @contingut)";
            try
            {
                MySqlCommand comanda = new MySqlCommand(cmdInsert,c.Connection);
                comanda.Parameters.Add("@user_id", MySqlDbType.Int32);
                comanda.Parameters.Add("@data_p", MySqlDbType.DateTime);
                comanda.Parameters.Add("@titol", MySqlDbType.VarChar, 30);
                comanda.Parameters.Add("@contingut", MySqlDbType.VarChar, 300);

                comanda.Parameters["@user_id"].Value = p.User_id;
                comanda.Parameters["@data_p"].Value = p.Data_p; 
                comanda.Parameters["@titol"].Value = p.Titol;
                comanda.Parameters["@contingut"].Value = p.Contingut;

                c.Connectar();
                int files_afectades = comanda.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("ERROR AL INSERIR A LA BASE DE DADES 'PUBLICACIÓ' ");
            }
            finally
            {
                c.Desconnectar();
            }
        }
        /// <summary>
        /// A partir de la ID d'una publicaació, busca dita publicació a la base de dades i la retorna
        /// </summary>
        /// <param name="id">ID de la publicació a cercar</param>
        /// <returns>La publicació</returns>
        public static PublicacioModel GetPublicacio(int id)
        {
            Connexio c = new Connexio();
            //string cmdSelect_User_Id = "SELECT user_id" +
            //                            "FROM publicacio" +
            //                            $"WHERE publicacio_id = {id}";

            //string cmdSelect_Data_P = "SELECT data_p" +
            //                            "FROM publicacio" +
            //                            $"WHERE publicacio_id = {id}";

            //string cmdSelect_Titol = "SELECT titol" +
            //                            "FROM publicacio" +
            //                            $"WHERE publicacio_id = {id}";

            //string cmdSelect_Contingut = "SELECT contingut" +
            //                            "FROM publicacio" +
            //                            $"WHERE publicacio_id = {id}";
            string cmdSelect_TOT = "SELECT * " +
                                    "FROM publicacio" +
                                    $"WHERE publicacio_id = {id}";
            PublicacioModel p = new PublicacioModel();
            try
            {
                //MySqlCommand comanda_User_Id = new MySqlCommand(cmdSelect_User_Id, c.Connection);
                //p.User_id = (int)comanda_User_Id.ExecuteScalar();
                //MySqlCommand comanda_Data_P = new MySqlCommand(cmdSelect_Data_P, c.Connection);
                //p.Data_p = (DateTime)comanda_Data_P.ExecuteScalar();
                //MySqlCommand comanda_Titol = new MySqlCommand(cmdSelect_Titol, c.Connection);
                //p.Titol = (string)comanda_Titol.ExecuteScalar();
                //MySqlCommand comanda_Contingut = new MySqlCommand(cmdSelect_Contingut, c.Connection);
                //p.Contingut = (string)comanda_Contingut.ExecuteScalar();
                MySqlCommand comanda_Select = new MySqlCommand(cmdSelect_TOT, c.Connection);
                c.Connectar();
                MySqlDataReader reader = comanda_Select.ExecuteReader();
                if (reader.Read())
                {
                    p.Publicacio_id = reader.GetInt32(0);
                    p.User_id = reader.GetInt32(1);
                    p.Data_p = reader.GetDateTime(2);
                    p.Titol = reader.GetString(3);
                    p.Contingut = reader.GetString(4);
                }
            }
            catch
            {
                MessageBox.Show($"ERROR: No s'ha trobat una publicació amb ID{id}");
            }
            finally
            {
                c.Desconnectar();
            }
            return p;
        }
    }
}
