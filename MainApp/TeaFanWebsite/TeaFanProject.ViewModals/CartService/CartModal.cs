using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaFanProject.ViewModals.CartService
{
    public class CartModal
    {
        public int CartID { get; set; }
        public double ShippingPrice { get; set; }
        public double Total { get; set; }
        public List<CartDetailModal> Details { get; set; }
    }
}
