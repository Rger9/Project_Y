using Y;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.Model
{
    public partial class UsuariDB
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string contrasenya { get; set; }
        public string description { get; set; }
        public string nom { get; set; }
        public string? cognom { get; set; }
        public string correu { get; set; }
        public string? telefon { get; set; }
        public virtual ICollection<PublicacioDB> publicacio { get; set; } = new List<PublicacioDB>();
        public virtual ICollection<ComentariDB> comentari { get; set; } = new List<ComentariDB>();
    }
}
