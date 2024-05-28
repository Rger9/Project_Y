using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.Negoci
{
    /// <summary>
    /// L'objecte TagpublicacioModel, el qual conté una id de tag associada a una id de publicació
    /// </summary>
    public class TagpublicacioModel
    {
        //Atributs
        private int publicacio_id;
        private int tag_id;
        //Propietats
        public int Publicacio_id { get; set; }
        public int Tag_id { get; set; }
    }
}
