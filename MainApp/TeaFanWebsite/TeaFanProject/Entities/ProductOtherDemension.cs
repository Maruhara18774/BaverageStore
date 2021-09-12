using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.Entities
{
    public class ProductOtherDemension
    {
        public int ProductOtherDemensionID { get; set; }
        public int ProductOtherID { get; set; }
        public int DemensionID { get; set; }
        public double Value { get; set; }
        public string Unit { get; set; }
        public virtual ProductOther ProductOther { get; set; }
        public virtual Demension Demension { get; set; }
    }
}
