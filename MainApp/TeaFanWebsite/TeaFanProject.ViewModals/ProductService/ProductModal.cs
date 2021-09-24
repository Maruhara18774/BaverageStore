using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaFanProject.ViewModals.HomeService;

namespace TeaFanProject.ViewModals.ProductService
{
    public class ProductModal
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double SalePrice { get; set; }
        public int TypeID { get; set; }
        public string Origin { get; set; }
        public virtual List<string> Images { get; set; }
        public virtual List<FlavorModal> Flavors { get; set; }
    }
}
