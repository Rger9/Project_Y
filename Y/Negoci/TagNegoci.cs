using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        //public TagModel GetTagDB(int id)
        //{
        //    return TagDB.GetTag(id);
        //}

        public static int GetTag_id(string tag_name)
        {
            int id = TagDB.GetTag_Id(tag_name);
            return id;
        }
        public void Inserir()
        {
            TagDB tdb = new TagDB();
            if(!Existeix(tag))
                tdb.Inserir(tag);
        }
        public bool Existeix(TagModel tag)
        {
            return TagDB.GetTag_Id(tag.Nom) != null;
        }
    }
}
