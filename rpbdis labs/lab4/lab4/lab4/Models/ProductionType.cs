using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Models
{
    public partial class ProductionType

    {
    

        //public ProductionType()

        //{

        //    NormalConsumptionRate = new HashSet<NormalConsumptionRate>();

        //    ProductionsAndConsumption = new HashSet<ProductionAndConsumption>();

        //}

        public int Id { get; set; }

        public string MeasureUnit { get; set; }

        public string TypeName { get; set; }



        //public virtual ICollection<NormalConsumptionRate> NormalConsumptionRate { get; set; }

        //public virtual ICollection<ProductionAndConsumption> ProductionsAndConsumption { get; set; }

        
    }
}
