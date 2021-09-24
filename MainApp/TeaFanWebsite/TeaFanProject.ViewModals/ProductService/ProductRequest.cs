using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaFanProject.ViewModals.ProductService
{
    public class ProductRequest
    {
        public int Page { get; set; }
        public int ProductTypeID { get; set; }
        public List<int> FlavorsID { get; set; }
        public string Origin { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public string SortBy { get; set; }
        public string SortType { get; set; }
        public int CategoryID { get; set; }
    }
}
