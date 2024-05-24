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
    public partial class TagpublicacioDB
    {
        /// <summary>
        /// Insereix una entrada a la base de dades "TagPublicacio"
        /// </summary>
        /// <param name="tp"></param>
        public static void Inserir(TagpublicacioModel tp)
        {
            Connexio c = new Connexio();
            string cmdInsert = "INSERT INTO TagPublicacio(publicacio_id, tag_id) " +
                                "VALUES(@publicacio_id, @tag_id)";
            try
            {
                MySqlCommand comanda = new MySqlCommand(cmdInsert, c.Connection);
                comanda.Parameters.Add("@publicacio_id", MySqlDbType.Int32);
                comanda.Parameters.Add("@tag_id", MySqlDbType.Int32);

                comanda.Parameters["@publicacio_id"].Value = tp.Tag_id;
                comanda.Parameters["@tag_id"].Value = tp.Tag_id;

                c.Connectar();
                int files_afectades = comanda.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("ERROR AL INSERIR A LA BASE DE DADES 'TagPublicacio' ");
            }
            finally
            {
                c.Desconnectar();
            }
        }
    }
}
