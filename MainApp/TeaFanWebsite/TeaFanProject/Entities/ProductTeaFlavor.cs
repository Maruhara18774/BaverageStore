using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.Entities
{
    public class ProductTeaFlavor
    {
        public int ProductTeaFlavorID { get; set; }
        public int FlavorID { get; set; }
        public int ProductTeaID { get; set; }
        public virtual Flavor Flavor { get; set; }
        public virtual ProductTea ProductTea { get; set; }
    }
}
