using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Models
{
    public partial class Lantern
    {
        public Lantern()
        {
            Calls = new HashSet<Call>();
            SectionsLightings = new HashSet<SectionsLighting>();
        }
        public int LanternId { get; set; }
        public int? LampId { get; set; }
        public string LanternName { get; set; }
        public string LanternType { get; set; }
        public bool? IsOperable { get; set; }

        public virtual Lamp Lamp { get; set; }
        public virtual ICollection<Call> Calls { get; set; }
        public virtual ICollection<SectionsLighting> SectionsLightings { get; set; }
    }
}

