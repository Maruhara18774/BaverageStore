using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public int TypeID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double SalePrice { get; set; }
        public int BrandID { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public bool IsDisable { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual List<Rating> Ratings { get; set; }
        public virtual List<ProductImage> ProductImages { get; set; }
        public virtual List<ProductTea> ProductTeas { get; set; }
        public virtual List<ProductOther> ProductOthers { get; set; }
        public virtual List<CartDetail> CartDetails { get; set; }
    }
}
