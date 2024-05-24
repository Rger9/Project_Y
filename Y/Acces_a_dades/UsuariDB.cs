﻿using Y;
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
            string cmdInsert = "INSERT INTO Usuari(username, contrasenya, nom, cognom, correu, telefon) " +
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
                MessageBox.Show("ERROR: no s'ha pogut interir a la base de dades 'Usuari' ");
            }
            finally
            {
                c.Desconnectar();
            }
        }
        public static void UpdatePerfil(UsuariModel u)
        {
            Connexio c = new Connexio();
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
                MySqlCommand comanda = new MySqlCommand(cmdUpdate, c.Connection);
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

                c.Connectar();
                int files_afectades = comanda.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("ERROR: no s'ha pogut actualitzar l'usuari");
            }
            finally
            {
                c.Desconnectar();
            }
        }
        /// <summary>
        /// Obté l'usuari a partir del seu Id
        /// </summary>
        /// <param name="id">id de l'usuari</param>
        /// <returns>Usuari</returns>
        public static UsuariModel GetUsuari(int id)
        {
            Connexio c = new Connexio();
            string cmdSelect = "SELECT * " +
                                "FROM usuari " +
                                $"WHERE user_id = @user_id";
            UsuariModel u = new UsuariModel();
            try
            {
                MySqlCommand comanda = new MySqlCommand(cmdSelect, c.Connection);
                comanda.Parameters.Add("@user_id", MySqlDbType.Int32);
                comanda.Parameters["@user_id"].Value = id;
                c.Connectar();
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
                c.Desconnectar();
            }
            return u;
        }
        public static UsuariModel GetUsuari(string username)
        {
            Connexio c = new Connexio();
            string cmdSelect = "SELECT * " +
                                "FROM usuari " +
                                $"WHERE username = @username";
            string username2;
            UsuariModel u = new UsuariModel();
            try
            {
                MySqlCommand comanda = new MySqlCommand(cmdSelect, c.Connection);
                comanda.Parameters.Add("@username", MySqlDbType.String);
                comanda.Parameters["@username"].Value = username;
                c.Connectar();
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
            }
            catch
            {
                MessageBox.Show($"ERROR: No existeix un usuarir amb l'username indicat {u.User_id}");
            }
            finally
            {
                c.Desconnectar();
            }
            return u;
        }
        public static List<int> ObtenirTotsId()
        {
            Connexio c = new Connexio();
            string cmdSelect = "SELECT user_id " +
                                "FROM usuari";
            List<int> llistaId = new List<int>();
            try
            {
                MySqlCommand commanda = new MySqlCommand(cmdSelect, c.Connection);
                c.Connectar();
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
                c.Desconnectar();
            }
            return llistaId;
        }
    }
}
