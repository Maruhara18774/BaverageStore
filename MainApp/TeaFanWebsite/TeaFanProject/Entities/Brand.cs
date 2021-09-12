using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.Entities
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string Origin { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
