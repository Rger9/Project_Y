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
        public TagModel GetTagDB(int id)
        {
            return TagDB.GetTag(id);
        }
    }
}
