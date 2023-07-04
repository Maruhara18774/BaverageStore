using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool IsTypeOfTea { get; set; }
        public virtual List<ProductType> ProductTypes { get; set; }
    }
}
