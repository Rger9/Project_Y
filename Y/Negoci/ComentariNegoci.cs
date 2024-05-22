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
        public static ComentariModel GetComentariDB(int id)
        {
            return ComentariDB.GetComentari(id);
        }
        public void Inserir()
        {
            ComentariDB.Inserir(comentari);
        }
        //public bool Validar()
        //{

        //}
    }
}
