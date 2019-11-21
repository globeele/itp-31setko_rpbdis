using lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Models
{
    public class Output
    {
        public int Id { get; set; }
        public short Quarter { get; set; }
        public short Year { get; set; }
        public int ReleasePlan { get; set; }
        public int ReleaseFact { get; set; }        
        public int CompanyId { get; set; }
        public int ProductionTypeId { get; set; }
        public int ProductionId { get; set; }

        public virtual Company Company { get; set; }

        public virtual ProductionType ProductionType { get; set; }
    }
}
