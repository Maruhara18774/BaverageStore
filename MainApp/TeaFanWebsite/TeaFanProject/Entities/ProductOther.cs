using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.Entities
{
    public class ProductOther
    {
        public int ProductOtherID { get; set; }
        public int ProductID { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
        public string CareInstruction { get; set; }
        public virtual Product Product { get; set; }
        public virtual List<ProductOtherDemension> ProductOtherDemensions { get; set; }
    }
}
