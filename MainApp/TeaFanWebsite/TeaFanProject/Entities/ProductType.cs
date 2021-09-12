using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.Entities
{
    public class ProductType
    {
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public int CategoryID { get; set; }
        public int MyProperty { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
