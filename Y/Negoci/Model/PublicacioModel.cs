using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Model;

namespace Y.Negoci
{
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
