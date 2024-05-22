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
    public partial class ComentariDB
    {
        /// <summary>
        /// Insereix un comentari a la base de dades
        /// </summary>
        /// <param name="c"></param>
        public static void Inserir(ComentariModel c)
        {
            Connexio con = new Connexio();
            string cmdInsert = "INSERT INTO Comentari(user_id, publicacio_id, data_c, contingut)" +
                                "VALUES(@user_id, @publicacio, @data_c, @contingut)";
            try
            {
                MySqlCommand comanda = new MySqlCommand(cmdInsert, con.Connection);
                comanda.Parameters.Add("@user_id", MySqlDbType.Int32);
                comanda.Parameters.Add("@publicacio_id", MySqlDbType.Int32);
                comanda.Parameters.Add("@data_c", MySqlDbType.DateTime);
                comanda.Parameters.Add("@contingut", MySqlDbType.VarChar, 300);

                comanda.Parameters["@user_id"].Value = c.User_id;
                comanda.Parameters["@publicacio_id"].Value = c.Publicacio_id;
                comanda.Parameters["@data_c"].Value = c.Data_c;
                comanda.Parameters["@contingut"].Value = c.Contingut;

                con.Connectar();
                int files_afectades = comanda.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("ERROR AL INSERIR A LA BASE DE DADES 'PUBLICACIÓ' ");
            }
            finally
            {
                con.Desconnectar();
            }
        }
        public static ComentariModel GetComentari(int id)
        {
            Connexio con = new Connexio();
            string cmdSelect = "SELECT *" +
                                "FROM comentari" +
                                $"WHERE comentari_id = {id}";
            ComentariModel c = new ComentariModel();
            try
            {
                MySqlCommand comanda = new MySqlCommand(cmdSelect, con.Connection);
                MySqlDataReader reader = comanda.ExecuteReader();
                if (reader.Read())
                {
                    c.User_id = reader.GetInt32(1);
                    c.Publicacio_id = reader.GetInt32(2);
                    c.Data_c = reader.GetDateTime(3);
                    c.Contingut = reader.GetString(4);
                }
            }
            catch
            {
                MessageBox.Show("ERROR: No s'ha trobat un comentari amb la ID indicada");
            }
            finally
            {
                con.Desconnectar();
            }
            return c;

        }
    }
}
