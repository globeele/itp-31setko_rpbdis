using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Models
{
    public class Production

    {
        public int Id { get; set; }
        public string ProductionName { get; set; }
        public string Features { get; set; }
        public int ProductionTypeId { get; set; }
        public string ProductionTypeMeasureUnit { get; set; }
    }
}
