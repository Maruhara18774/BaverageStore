using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaFanProject.ViewModals.AccountService
{
    public class OrderDetailModal
    {
        public int DetailID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ImageURL { get; set; }
        public int Quantity { get; set; }
        public double SalePrice { get; set; }
        public double Total { get; set; }
    }
}
