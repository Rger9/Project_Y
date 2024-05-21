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

namespace Y.Model
{
    public partial class PublicacioDB
    {
        public void Publicar(Publicacio p)
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

                comanda.Parameters["@user_id"].Value = p.user_id;
                comanda.Parameters["@data_p"].Value = p.data_p; 
                comanda.Parameters["@titol"].Value = p.titol;
                comanda.Parameters["@contingut"].Value = p.contingut;

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

        public void GetPublicacio(Publicacio p)
        {
            Connexio c = new Connexio();
            string cmdSelect = "SELECT * FROM Publicacio" +
                                "WHERE @publicacio_id = publicacio_id";
            try
            {
                MySqlCommand comanda = new MySqlCommand(cmdSelect, c.Connection);
                comanda.Parameters.Add("@publicacio_id", MySqlDbType.Int32);

                comanda.Parameters["@publicacio_id"].Value = p.publicacio_id;

                c.Connectar();
                MySqlDataReader reader = comanda.ExecuteReader();
            }
            catch
            {
                MessageBox.Show("ERROR AL SELECCIONAR A LA BASE DE DADES 'PUBLICACIÓ' ");
            }
            finally
            {
                c.Desconnectar();
            }
        }
    }
}
