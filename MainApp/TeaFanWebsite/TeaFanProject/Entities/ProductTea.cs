using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.Entities
{
    public class ProductTea
    {
        public int ProductTeaID { get; set; }
        public int ProductID { get; set; }
        public string WaterTemperature { get; set; }
        public string SteepTime { get; set; }
        public string ServingSize { get; set; }
        public string Ingredients { get; set; }
        public virtual Product Product { get; set; }
        public virtual List<ProductTeaFlavor> ProductTeaFlavors { get; set; }
    }
}
