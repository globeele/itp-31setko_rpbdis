﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Models
{
    public partial class Lamp
    {
        public Lamp()
        {
            Lanterns = new HashSet<Lantern>();
        }

        public int LampId { get; set; }

        [DisplayName("Lamp name")]
        public string LampName { get; set; }
        public int? LampPower { get; set; }
        public int? LampLife { get; set; }

        public virtual ICollection<Lantern> Lanterns { get; set; }
    }

}
