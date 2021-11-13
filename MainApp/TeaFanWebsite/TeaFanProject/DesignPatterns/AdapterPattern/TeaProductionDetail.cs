using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Data;
using TeaFanProject.Entities;
using TeaFanProject.ViewModals.HomeService;
using TeaFanProject.ViewModals.ProductService;

namespace TeaFanProject.DesignPatterns.AdapterPattern
{
    public class TeaProductionDetail: BaseDetailModal
    {
        public virtual List<FlavorModal> Flavors { get; set; }
        public PTeaModal Tea { get; set; }
        public TeaProductionDetail(ApplicationDbContext context, Product product)
        {
            ProductID = product.ProductID;
            ProductName = product.ProductName;
            Price = product.Price;
            SalePrice = product.SalePrice;
            TypeID = product.TypeID;
            TypeName = context.ProductTypes.Where(x => x.TypeID == product.TypeID).Select(x => x.TypeName).FirstOrDefault();
            Description = product.Description;
            Images = context.ProductImages.Where(x => x.ProductID == product.ProductID).Select(x => x.ImageLink).ToList();

            var brand = context.Brands.Where(x => x.BrandID == product.BrandID).FirstOrDefault();
            Brand = brand.BrandName;
            Origin = brand.Origin;

            var flavor = (from f in context.Flavors
                          join tf in context.ProductTeaFlavors on f.FlavorID equals tf.FlavorID
                          join pt in context.ProductTeas on tf.ProductTeaID equals pt.ProductTeaID
                          where pt.ProductID == product.ProductID
                          select new FlavorModal()
                          {
                              FlavorID = f.FlavorID,
                              FlavorName = f.FlavorName
                          }).AsSplitQuery();
            Flavors = flavor.ToList();
            var tea = context.ProductTeas.Where(x => x.ProductID == product.ProductID).FirstOrDefault();
            Tea = new PTeaModal()
            {
                WaterTemperature = tea.WaterTemperature,
                SteepTime = tea.SteepTime,
                ServingSize = tea.ServingSize,
                Ingredients = tea.Ingredients
            };
        }

        public override DetailModal GetBaseDetailModal()
        {
            return new DetailModal()
            {
                ProductID = ProductID,
                ProductName = ProductName,
                Price = Price,
                SalePrice = SalePrice,
                TypeID = TypeID,
                TypeName = TypeName,
                Description = Description,
                Images = Images
            };
        }
    }
}
