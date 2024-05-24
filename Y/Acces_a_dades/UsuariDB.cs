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
            string cmdInsert = "INSERT INTO Usuari(username, contrasenya, nom, cognom, correu, telefon) " +
                                "VALUES(@username, @contrasenya, @nom, @cognom, @correu, @telefon)";
            try
            {
                MySqlCommand comanda = new MySqlCommand(cmdInsert, Connexio.Connection);
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

                Connexio.Connectar();
                int files_afectades = comanda.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("ERROR: no s'ha pogut interir a la base de dades 'Usuari' ");
            }
            finally
            {
                Connexio.Desconnectar();
            }
        }
        public static void UpdatePerfil(UsuariModel u)
        {
            string cmdUpdate = "UPDATE usuari " +
                                $"SET username = @username, " +
                                    $"contrasenya = @contrasenya, " +
                                    $"nom = @nom, " +
                                    $"cognom = @cognom, " +
                                    $"correu = @correu, " +
                                    $"telefon = @telefon " +
                                $"WHERE user_id = @user_id";
            try
            {
                MySqlCommand comanda = new MySqlCommand(cmdUpdate, Connexio.Connection);
                comanda.Parameters.Add("@username", MySqlDbType.VarChar, 20);
                comanda.Parameters.Add("@contrasenya", MySqlDbType.VarChar, 30);
                comanda.Parameters.Add("@nom", MySqlDbType.VarChar, 20);
                comanda.Parameters.Add("@cognom", MySqlDbType.VarChar, 20);
                comanda.Parameters.Add("@correu", MySqlDbType.VarChar, 50);
                comanda.Parameters.Add("@telefon", MySqlDbType.VarChar, 9);
                comanda.Parameters.Add("@user_id", MySqlDbType.Int32);

                comanda.Parameters["@username"].Value = u.Username;
                comanda.Parameters["@contrasenya"].Value = u.Contrasenya;
                comanda.Parameters["@nom"].Value = u.Nom;
                comanda.Parameters["@cognom"].Value = u.Cognom;
                comanda.Parameters["@correu"].Value = u.Correu;
                comanda.Parameters["@telefon"].Value = u.Telefon;
                comanda.Parameters["@user_id"].Value = u.User_id;

                Connexio.Connectar();
                int files_afectades = comanda.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("ERROR: no s'ha pogut actualitzar l'usuari");
            }
            finally
            {
                Connexio.Desconnectar();
            }
        }
        /// <summary>
        /// Obté l'usuari a partir del seu Id
        /// </summary>
        /// <param name="id">id de l'usuari</param>
        /// <returns>Usuari</returns>
        public static UsuariModel GetUsuari(int id)
        {
            string cmdSelect = "SELECT * " +
                                "FROM usuari " +
                                $"WHERE user_id = @user_id";
            UsuariModel u = new UsuariModel();
            try
            {
                MySqlCommand comanda = new MySqlCommand(cmdSelect, Connexio.Connection);
                comanda.Parameters.Add("@user_id", MySqlDbType.Int32);
                comanda.Parameters["@user_id"].Value = id;
                Connexio.Connectar();
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
                reader.Close();
            }
            catch
            {
                MessageBox.Show("ERROR: No s'ha trobat un usuari amb la ID indicada");
            }
            finally
            {
                Connexio.Desconnectar();
            }
            return u;
        }
        public static UsuariModel GetUsuari(string username)
        {
            string cmdSelect = "SELECT * " +
                                "FROM usuari " +
                                $"WHERE username = @username";
            UsuariModel u = new UsuariModel();
            try
            {
                Connexio.Connectar();
                MessageBox.Show(Connexio.Connection.ToString());
                MySqlCommand comanda = new MySqlCommand(cmdSelect, Connexio.Connection);
                comanda.Parameters.Add("@username", MySqlDbType.String);
                comanda.Parameters["@username"].Value = username;
                MySqlDataReader reader = comanda.ExecuteReader();
                if (reader.Read())
                {
                    u.User_id = reader.GetInt32(0);
                    u.Contrasenya = reader.GetString(2);
                    u.Nom = reader.GetString(3);
                    u.Cognom = reader.GetString(4);
                    u.Correu = reader.GetString(5);
                    u.Telefon = reader.GetString(6);
                }
                reader.Close();
                if (!Existeix(u)) throw new Exception();
            }
            catch
            {
                MessageBox.Show($"ERROR: No existeix un usuarir amb l'username indicat");
            }
            finally
            {
                Connexio.Desconnectar();
            }
            return u;
        }
        public static List<int> ObtenirTotsId()
        {
            string cmdSelect = "SELECT user_id " +
                                "FROM usuari";
            List<int> llistaId = new List<int>();
            try
            {
                MySqlCommand commanda = new MySqlCommand(cmdSelect, Connexio.Connection);
                Connexio.Connectar();
                MySqlDataReader reader = commanda.ExecuteReader();
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
                MessageBox.Show("ERROR: No s'han trobat els ids a la taula usuari");
            }
            finally
            {
                Connexio.Desconnectar();
            }
            return llistaId;
        }
        public static bool Existeix(UsuariModel u)
        {
            bool existeix = true;
            string cmdSelect = "SELECT * " +
                                "FROM usuari " +
                                $"WHERE user_id = @user_id";
            try
            {
                Connexio.Connectar();
                MessageBox.Show(Connexio.Connection.ToString());
                MySqlCommand comanda = new MySqlCommand(cmdSelect, Connexio.Connection);
                comanda.Parameters.Add("@user_id", MySqlDbType.Int32);
                comanda.Parameters["@user_id"].Value = u.User_id;
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
                reader.Close();
                if (u.Username is null || u.Contrasenya is null || u.Nom is null || u.Correu is null)
                {
                    existeix = false;
                }
            }
            catch
            {
                MessageBox.Show($"ERROR: No s'ha pogut comprovar si existe");
            }
            finally
            {
                Connexio.Desconnectar();
            }
            return existeix;
        }
    }
}
