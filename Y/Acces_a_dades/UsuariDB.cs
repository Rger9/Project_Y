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
    public partial class UsuariDB
    {
        /// <summary>
        /// Insereix un usuari a la base de dades
        /// </summary>
        /// <param name="u"></param>
        public static void Inserir(UsuariModel u)
        {
            Connexio c = new Connexio();
            string cmdInsert = "INSERT INTO Usuari(username, contrasenya, nom, cognom, correu, telefon)" +
                                "VALUES(@username, @contrasenya, @nom, @cognom, @correu, @telefon)";
            try
            {
                MySqlCommand comanda = new MySqlCommand(cmdInsert, c.Connection);
                comanda.Parameters.Add("@username", MySqlDbType.VarChar, 20);
                comanda.Parameters.Add("@contrasenya", MySqlDbType.VarChar, 30);
                comanda.Parameters.Add("@nom", MySqlDbType.VarChar, 20);
                comanda.Parameters.Add("@cognom", MySqlDbType.VarChar, 20);
                comanda.Parameters.Add("@correu", MySqlDbType.VarChar, 50);
                comanda.Parameters.Add("@telefon", MySqlDbType.VarChar, 9);

                comanda.Parameters["@username"].Value = u.Username;
                comanda.Parameters["@contrasenya"].Value = u.Contrasenya;
                comanda.Parameters["@nom"].Value = u.Nom;
                comanda.Parameters["@cognom"].Value = u.Cognom;
                comanda.Parameters["@correu"].Value = u.Correu;
                comanda.Parameters["@telefon"].Value = u.Telefon;

                c.Connectar();
                int files_afectades = comanda.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("ERROR AL INSERIR A LA BASE DE DADES 'Usuari' ");
            }
            finally
            {
                c.Desconnectar();
            }
        }
        public static UsuariModel GetUsuari(int id)
        {
            Connexio c = new Connexio();
            string cmdSelect = "SELECT *" +
                                "FROM usuari" +
                                $"WHERE user_id = {id}";
            UsuariModel u = new UsuariModel();
            try
            {
                MySqlCommand comanda = new MySqlCommand(cmdSelect, c.Connection);
                MySqlDataReader reader = comanda.ExecuteReader();
                if (reader.Read())
                {
                    u.Username = reader.GetString(1);
                    u.Contrasenya = reader.GetString(2);
                    u.Nom = reader.GetString(3);
                    u.Cognom = reader.GetString(4);
                    u.Correu = reader.GetString(5);
                    u.Telefon = reader.GetString(6);
                }
            }
            catch
            {
                MessageBox.Show("ERROR: No s'ha trobat un usuari amb la ID indicada");
            }
            finally
            {
                c.Desconnectar();
            }
            return u;

        }
    }
}
