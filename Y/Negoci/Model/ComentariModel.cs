using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Model;

namespace Y.Negoci
{
    /// <summary>
    /// L'objecte ComentariModel, format per l'id del comentari, l'id de la persona que comenta, l'id de la publicació comentada, la data del comentari i el contingut
    /// </summary>
    public class ComentariModel
    {
        //Atributs
        private int comentari_id;
        private int user_id;
        private int publicacio_id;
        private DateTime data_c;
        private string contingut;
        //Propietats
        public int Comentari_id { get; set; }
        public int User_id { get; set; }
        public int Publicacio_id { get; set; }
        public DateTime Data_c { get; set; }
        public string Contingut { get; set; }
    }
}
