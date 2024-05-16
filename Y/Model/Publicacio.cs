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
        public DateTime data_p { get; set; }
        public string titol { get; set; }
        public string contingut { get; set; }
        public virtual ICollection<Tagpublicacio> tagpublicacio { get; set; } = new List<Tagpublicacio>();
    }
}
