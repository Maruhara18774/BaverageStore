using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.Entities
{
    public class Demension
    {
        public int DemensionID { get; set; }
        public string DemensionName { get; set; }
        public virtual List<ProductOtherDemension> OtherDemensions { get; set; }
    }
}
