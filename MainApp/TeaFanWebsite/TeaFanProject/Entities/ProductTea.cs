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
        public double WaterTemperature { get; set; }
        public double SteepTime { get; set; }
        public double ServingSize { get; set; }
        public string Ingredients { get; set; }
    }
}
