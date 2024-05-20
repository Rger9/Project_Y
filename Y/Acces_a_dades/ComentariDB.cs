using Y;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.Model
{
    public partial class ComentariDB
    {
        public int comentari_id { get; set; }
        public int user_id { get; set; }
        public int publicacio_id { get; set; }
        public DateTime data_c { get; set; }
        public string contingut { get; set; }
        public virtual ICollection<PublicacioDB> publicacio { get; set; } = new List<PublicacioDB>();
        public virtual ICollection<UsuariDB> usuari { get; set; } = new List<UsuariDB>();
    }
}
