using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Y.Model;

namespace Y.Negoci
{
    internal class TagNegoci
    {
        //Atributs
        private TagModel tag;
        //Propietats
        public TagModel Tag { get; set; }
        //Metodes
        public TagModel GetTagDB(int id)
        {
            return TagDB.GetTag(id);
        }

        public static int GetTag_id(string tag_name)
        {
            int id = TagDB.GetTag_Id(tag_name);
            return id;
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
                MessageBox.Show("ERROR AL VALIDAR/INSERIR TAG");
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
            return tag.Nom == null || tag.Nom == "";
        }
        public static bool Existeix(string nom)
        {
            return (TagDB.ObtenirTotsId().Contains(GetTag_id(nom)));
        }
        public bool Existeix(TagModel tag)
        {
            return (TagDB.ObtenirTotsId().Contains(tag.Tag_id));
        }
    }
}
