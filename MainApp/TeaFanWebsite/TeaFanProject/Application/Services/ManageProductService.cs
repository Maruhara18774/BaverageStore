using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Application.Interfaces;
using TeaFanProject.Data;
using TeaFanProject.DesignPatterns.IteratorPattern;
using TeaFanProject.ViewModals.Common;
using TeaFanProject.ViewModals.HomeService;
using TeaFanProject.ViewModals.ProductService;

namespace TeaFanProject.Application.Services
{
    public class ManageProductService : IManageProductService
    {
        private readonly ApplicationDbContext _context;
        public ManageProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<TFPagedResult<ProductRespond>> GetListProductAsync(int pageIndex)
        {
            var data = (from p in _context.Products
                        join b in _context.Brands on p.BrandID equals b.BrandID
                        select new ProductModal()
                        {
                            ProductID = p.ProductID,
                            ProductName = p.ProductName,
                            Price = p.Price,
                            SalePrice = p.SalePrice,
                            TypeID = p.TypeID,
                            Origin = b.Origin
                        }).AsSplitQuery();
            var result = new List<ProductRespond>();
            foreach (var item in data)
            {
                var flavor = (from f in _context.Flavors
                              join tf in _context.ProductTeaFlavors on f.FlavorID equals tf.FlavorID
                              join pt in _context.ProductTeas on tf.ProductTeaID equals pt.ProductTeaID
                              where pt.ProductID == item.ProductID
                              select new FlavorModal()
                              {
                                  FlavorID = f.FlavorID,
                                  FlavorName = f.FlavorName
                              }).AsSplitQuery();
                int count = flavor.ToList().Count;
                result.Add(new ProductRespond()
                {
                    ProductID = item.ProductID,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    SalePrice = item.SalePrice,
                    Flavors = await flavor.Select(x => x.FlavorName).ToListAsync(),
                    Images = await _context.ProductImages.Where(x => x.ProductID == item.ProductID).Select(x => x.ImageLink).ToListAsync()
                });
            }
            var page = pageIndex > 0 ? pageIndex : 1;
            var endData = result.Skip((page - 1) * 12).Take(12).ToList();

            var finalResult = new TFPagedResult<ProductRespond>()
            {
                Page = page,
                Limit = (int)result.Count / 12 + 1,
                TotalRecords = result.Count,
                Items = endData
            };
            return finalResult;
        }
    }
}
