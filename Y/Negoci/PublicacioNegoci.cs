using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Model;

namespace Y.Negoci
{
    internal class PublicacioNegoci
    {
        //Atributs
        private PublicacioModel publicacio;
        //Propietats
        public PublicacioModel Publicacio { get; set; }
        //Metodes
        public PublicacioModel GetPublicacioDB(int id)
        {
            return PublicacioDB.GetPublicacio(id);
        }
    }
}
