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
        Tag t = new Tag();
        public void InserirTag(Publicacio p)
        {
            Connexio c = new Connexio();
            string cmdInsert = "INSERT INTO Tag(nom)" +
                                "VALUES(@nom)";
            try
            {
                MySqlCommand comanda = new MySqlCommand(cmdInsert, c.Connection);
                comanda.Parameters.Add("@nom", MySqlDbType.VarChar, 20);

                comanda.Parameters["@nom"].Value = t.nom;

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
    }
}
