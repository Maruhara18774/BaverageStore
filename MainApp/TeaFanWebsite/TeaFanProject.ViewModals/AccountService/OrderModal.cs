using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaFanProject.ViewModals.AccountService
{
    public class OrderModal
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public double Shipping { get; set; }
        public double Total { get; set; }
        public List<OrderDetailModal> OrderDetails { get; set; }
    }
}
