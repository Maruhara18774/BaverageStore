using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Data;
using TeaFanProject.Entities;
using TeaFanProject.ViewModals.ProductService;

namespace TeaFanProject.DesignPatterns.AdapterPattern
{
    public class OtherProductionDetail: BaseDetailModal
    {
        public POtherModal Other { get; set; }

        public OtherProductionDetail(ApplicationDbContext context, Product product)
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

            var other = context.ProductOthers.Where(x => x.ProductID == product.ProductID).FirstOrDefault();
            Other = new POtherModal()
            {
                Material = other.Material,
                Color = other.Color,
                CareInstruction = other.CareInstruction,
                Demensions = new List<DemensionModal>()
            };
            var demensionRefs = context.ProductOtherDemensions.Where(x => x.ProductOtherID == other.ProductOtherID).ToList();
            foreach (var item in demensionRefs)
            {
                Other.Demensions.Add(new DemensionModal()
                {
                    DemensionName = context.Demensions.Where(x => x.DemensionID == item.DemensionID).Select(x => x.DemensionName).FirstOrDefault(),
                    Value = item.Value,
                    Unit = item.Unit
                });
            }
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
