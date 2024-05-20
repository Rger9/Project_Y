using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Model;

namespace Y.Negoci
{
    internal class Comentari
    {
        public int comentari_id { get; set; }
        public int user_id { get; set; }
        public int publicacio_id { get; set; }
        public DateTime data_c { get; set; }
        public string contingut { get; set; }
    }
}
