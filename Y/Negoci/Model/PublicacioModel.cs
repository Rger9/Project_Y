using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Model;

namespace Y.Negoci
{
    /// <summary>
    /// L'objecte PublicacioModel, formada per l'id de la publicació, l'id de la persona que comenta, la data de la publicació, el títol d'aquesta i el contingut
    /// </summary>
    public class PublicacioModel
    {
        //Atributs
        private int publicacio_id;
        private int user_id;
        private DateTime data_p;
        private string titol;
        private string contingut;
        //Propietats
        public int Publicacio_id { get; set; }
        public int User_id { get; set; }
        public DateTime Data_p { get; set; }
        public string Titol { get; set; }
        public string Contingut { get; set; }
    }
}
