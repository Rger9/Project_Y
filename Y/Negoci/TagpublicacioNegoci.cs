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
        //Constructors
        public TagpublicacioNegoci()
        {
            tagPublicacio = new TagpublicacioModel();
        }
        public TagpublicacioNegoci(TagpublicacioModel tagPublicacio)
        {
            this.tagPublicacio = tagPublicacio;
        }
        //Metodes
        public void Inserir()
        {
            TagpublicacioDB.Inserir(tagPublicacio);
        }
    }
}
