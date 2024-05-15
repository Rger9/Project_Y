using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.Model
{
    public partial class Usuari
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string contrasenya { get; set; }
        public string description { get; set; }
        public string nom { get; set; }
        public string? cognom { get; set; }
        public string correu { get; set; }
        public string? telefon { get; set; }
        public virtual ICollection<publicacio> publicacio { get; set; } = new List<publicacio>();

    }
}
