using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Model;

namespace Y.Negoci
{
    internal class TagpublicacioNegoci
    {
        //Atributs
        private TagpublicacioModel tagPublicacio;
        //Propietats
        public TagpublicacioModel Tagpublicacio { get; set; }
        //Metodes
        public TagpublicacioModel GetTagpublicacioDB(int id)
        {
            return TagpublicacioDB.GetTagpublicacio(id);
        }
    }
}
