using Y;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Negoci;
using Y.AccesADades;
using Mysqlx.Crud;

namespace Y.Model
{
    public partial class PublicacioDB
    {
        public void Inserir()
        {
            Connexio c = new Connexio();
            c.Connectar();
            string insert = "INSERT INTO Publicacio(user_id, data_p, titol, contingut" +
                            "VALUES() ";
            c.Desconnectar();
        }
    }
}
