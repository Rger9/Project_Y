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
        public void Inserir(TagpublicacioModel tp)
        {
            TagpublicacioDB.Inserir(tp);
        }
        public List<int> GetTagsPublicacio(int id)
        {
            return TagpublicacioDB.GetTagsPublicacio(id);
        }
    }
}
