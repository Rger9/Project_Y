using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Y.Model;

namespace Y.Negoci
{
    /// <summary>
    /// La classe "TagpublicacioNegoci" serà la que la vista cridarà per accedir als mètodes d'Accés a dades
    /// </summary>
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
        /// <summary>
        /// Insereix un "tagpublicacio" a la base de dades
        /// </summary>
        public void Inserir()
        {
            TagpublicacioDB.Inserir(tagPublicacio);
        }
        /// <summary>
        /// Aconsegueix tots els tags_ids pertinents a una publicació
        /// </summary>
        /// <param name="id">publicacio_id de la que en volem saber els tags</param>
        /// <returns>Llista de tag_ids</returns>
        public static List<int> GetTagsIdPublicacio(int id)
        {
            return TagpublicacioDB.GetTagsIdPublicacio(id);
        }
        /// <summary>
        /// Escriu totes les etiquetes d'una publicació separades per ", "
        /// </summary>
        /// <param name="id">publicacio_id</param>
        /// <returns>retorna el text escrit amb totes les etiquetes</returns>
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
