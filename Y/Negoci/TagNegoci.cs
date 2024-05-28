using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Y.Model;

namespace Y.Negoci
{
    /// <summary>
    /// La classe "TagNegoci" serà la que validarà els objectes "TagModel" i la que la vista cridarà per accedir als mètodes d'Accés a dades
    /// </summary>
    internal class TagNegoci
    {
        //Atributs
        private TagModel tag;
        //Propietats
        public TagModel Tag 
        {
            get { return tag; }
            set { tag = value;
                tag.Nom = FormatarString(tag.Nom); }
        }
        //Metodes
        /// <summary>
        /// Obté un Tag a partir del seu Id
        /// </summary>
        /// <param name="id">tag_id</param>
        /// <returns>El Tag</returns>
        public TagModel GetTagDB(int id)
        {
            return TagDB.GetTag(id);
        }
        /// <summary>
        /// Obté un tag_id a partir del seu nom
        /// </summary>
        /// <param name="tag_name">Nom del tag</param>
        /// <returns>tag_id</returns>
        public static int GetTag_id(string tag_name)
        {
            tag_name = FormatarString(tag_name);
            int id = TagDB.GetTag_Id(tag_name);
            return id;
        }
        /// <summary>
        /// Obté tots els tags que s'han utilitzat
        /// </summary>
        /// <returns>Llista de tots els tag_id</returns>
        public List<int> ObtenirTotsId()
        {
            return TagDB.ObtenirTotsId();
        }
        public void Inserir()
        {
            try
            {
                if (!Validar()) throw new Exception();
                TagDB.Inserir(tag);
            }
            catch
            {
                MessageBox.Show("ERROR AL VALIDAR/INSERIR TAG A LA BASE DE DADES");
            }
        }
        public bool Validar()
        {
            if(Tag == null) return false;
            if(this.HasNull() ) return false;
            return true;
        }
        public bool HasNull()
        {
            return Tag.Nom == null || Tag.Nom == "";
        }
        public static bool Existeix(string nom)
        {
            nom = FormatarString(nom);
            return (TagDB.ObtenirTotsId().Contains(GetTag_id(nom)));
        }
        public bool Existeix(TagModel tag)
        {
            return (TagDB.ObtenirTotsId().Contains(tag.Tag_id));
        }
        public static string FormatarString(string tag_name)
        {
            if (tag_name == null) return "";
            return tag_name.Substring(0, 1).ToUpper() + tag_name.Substring(1).ToLower();
        }
    }
}
