using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Model;

namespace Y.Negoci
{
    internal class ComentariNegoci
    {
        //Atributs
        private ComentariModel comentari;
        //Propietats
        public ComentariModel Comentari { get; set; }
        //Metodes
        public ComentariModel GetComentariDB(int id)
        {
            return ComentariDB.GetComentari(id);
        } 
    }
}
