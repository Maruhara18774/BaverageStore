using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.Entities
{
    public class Cart
    {
        public int CartID { get; set; }
        public Guid UserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public double ShippingPrice { get; set; }
        public double Total { get; set; }
        public virtual User User { get; set; }
        public virtual List<CartDetail> CartDetails { get; set; }
    }
}
