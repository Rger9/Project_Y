using Y;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.Model
{
    public partial class Publicacio
    {
        public int publicacio_id { get; set; }
        public int user_id { get; set; }
        public int data_p { get; set; }
        public int titol { get; set; }
        public int contingut { get; set; }
        public int tags { get; set; }

    }
}
