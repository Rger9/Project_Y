using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Model;

namespace Y.Negoci
{
    /// <summary>
    /// L'objecte TagModel, format pel seu id de tag, i el nom d'aquest
    /// </summary>
    public class TagModel
    {
        //Atributs
        private int tag_id;
        private string nom;
        //Propietats
        public int Tag_id { get; set; }
        public string Nom { get; set; }
    }
}
