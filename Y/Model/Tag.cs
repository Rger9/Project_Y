using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.Model
{
    public partial class Tag
    {
        public int tag_id { get; set; }
        public string nom { get; set; }
        public virtual ICollection<Tagpublicacio> tagpublicacio { get; set; } = new List<Tagpublicacio>();
    }
}
