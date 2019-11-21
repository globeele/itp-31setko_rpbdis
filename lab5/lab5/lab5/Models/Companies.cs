using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab5.Models
{
    public class Companies
    {
        public Companies()
        {
            NormalConsumptionRate = new HashSet<NormalConsumptionRate>();

            ProductionsAndConsumption = new HashSet<ProductionAndConsumption>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string OwnershipType { get; set; }

        public string HeadName { get; set; }

        public string ActivityType { get; set; }

        public virtual ICollection<NormalConsumptionRate> NormalConsumptionRate { get; set; }

        public virtual ICollection<ProductionAndConsumption> ProductionsAndConsumption
        {
            get; set;

        }
}
