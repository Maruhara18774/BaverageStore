using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Application.Interfaces;
using TeaFanProject.Data;
using TeaFanProject.Entities;
using TeaFanProject.ViewModals.Common;
using TeaFanProject.ViewModals.HomeService;
using TeaFanProject.ViewModals.ProductService;

namespace TeaFanProject.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TFPagedResult<ProductRespond>> GetListProductAsync(ProductRequest request)
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
            if(request.ProductTypeID > 0)
            {
                data = data.Where(x => x.TypeID == request.ProductTypeID);
            }
            if(request.Origin != "")
            {
                data = data.Where(x => x.Origin == request.Origin);
            }
            if(request.Min<request.Max && request.Min > 0)
            {
                data = data.Where(x => x.SalePrice >= request.Min && x.SalePrice <= request.Max);
            }
            var result = new List<ProductRespond>();
            foreach(var item in data)
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
                if(request.FlavorsID.Count != 0)
                {
                    if(CheckContain(request.FlavorsID, await flavor.ToListAsync()))
                    {
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
                }
            }
            switch (request.SortBy)
            {
                case "Name":
                    if(request.SortBy == "Desc")
                    {
                        result.OrderByDescending(x => x.ProductName);
                    }
                    else
                    {
                        result.OrderBy(x => x.ProductName);
                    }
                    break;
                case "Price":
                    if (request.SortBy == "Desc")
                    {
                        result.OrderByDescending(x => x.SalePrice);
                    }
                    else
                    {
                        result.OrderBy(x => x.SalePrice);
                    }
                    break;
                default:
                    break;
            }
            var page = request.Page > 0 ? request.Page : 1;
            var finalResult = new TFPagedResult<ProductRespond>()
            {
                Page = page,
                Limit = (int)result.Count / 12,
                TotalRecords = result.Count,
                Items = result.Skip((page - 1) * 12).Take(12).ToList()
            };
            return finalResult;
        }
        private bool CheckContain(List<int> arr1, List<FlavorModal> arr2)
        {
            foreach(var item in arr1)
            {
                var check = arr2.Where(x => x.FlavorID == item);
                if (check == null) return false;
            }
            return true;
        }
    }
}
