using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.Entities
{
    public class Flavor
    {
        public int FlavorID { get; set; }
        public string FlavorName { get; set; }
        public virtual List<ProductTeaFlavor> ProductTeaFlavors { get; set; }
    }
}
