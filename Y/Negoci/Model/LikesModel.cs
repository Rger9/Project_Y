using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.Negoci
{
    /// <summary>
    /// Aquesta classe guarda els likes de cada usuari a cada publicacio, si hi ha guardades dades de un usuari i una publicacio, 
    /// significa que aquest usuari li ha donat like a aquella publicacio
    /// </summary>
    public class LikesModel
    {
        //Atributs
        private int publicacio_id;
        private int user_id;
        //Propietats
        public int Publicacio_id { get; set; }
        public int User_id { get; set; }
    }
}
