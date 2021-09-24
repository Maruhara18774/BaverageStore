using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaFanProject.ViewModals.ProductService
{
    public class ProductRespond
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double SalePrice { get; set; }
        public virtual List<string> Images { get; set; }
        public virtual List<string> Flavors { get; set; }
    }
}
