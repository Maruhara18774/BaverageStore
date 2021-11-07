using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.ViewModals.ProductService;

namespace TeaFanProject.DesignPatterns.AdapterPattern
{
    public abstract class BaseDetailModal
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double SalePrice { get; set; }
        public int TypeID { get; set; }
        public string Origin { get; set; }
        public List<string> Images { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public abstract DetailModal GetBaseDetailModal();
    }
}
