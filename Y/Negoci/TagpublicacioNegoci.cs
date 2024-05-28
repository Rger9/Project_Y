using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public static List<int> GetTagsIdPublicacio(int id)
        {
            return TagpublicacioDB.GetTagsIdPublicacio(id);
        }
        public static string GetTagsTextPublicacio(int id)
        {
            List<int> listint = GetTagsIdPublicacio(id);
            string text = "";
            foreach (int i in listint)
            {
                text += ", " + TagDB.GetTag(i).Nom;
            }
            if(text.Length > 0) text = text.Substring(2);
            return text;
        }
    }
}
