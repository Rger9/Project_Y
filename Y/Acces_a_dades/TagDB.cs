using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.Model
{
    public partial class TagDB
    {
        public int tag_id { get; set; }
        public string nom { get; set; }
        public virtual ICollection<TagpublicacioDB> tagpublicacio { get; set; } = new List<TagpublicacioDB>();
    }
}
