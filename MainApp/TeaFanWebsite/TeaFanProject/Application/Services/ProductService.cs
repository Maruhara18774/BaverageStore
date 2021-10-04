using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Application.Interfaces;
using TeaFanProject.Data;
using TeaFanProject.DesignPatterns.IteratorPattern;
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
                        join t in _context.ProductTypes on p.TypeID equals t.TypeID
                        where t.CategoryID == request.CategoryID
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
            if(request.Min<request.Max && request.Min >= 0)
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
                int count = flavor.ToList().Count;
                if(request.FlavorsID.Count != 0)
                {
                    if(count != 0 && CheckContain(request.FlavorsID, await flavor.ToListAsync()))
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
                else
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
            var page = request.Page > 0 ? request.Page : 1;
            var endData = result.Skip((page - 1) * 12).Take(12).ToList();
            ProductOrderIterator collection;
            if(request.SortType == "Desc")
            {
                collection = new ProductOrderIterator(endData, request.SortType, true);
            }
            else
            {
                collection = new ProductOrderIterator(endData, request.SortType);
            }
            endData.Clear();
            while (collection.MoveNext())
            {
                endData.Add(collection.Current());
            }
            //switch (request.SortBy)
            //{
            //    case "Name":
            //        if(request.SortType == "Desc")
            //        {
            //            endData =  endData.OrderByDescending(x => x.ProductName).ToList();
            //        }
            //        else
            //        {
            //            endData = endData.OrderBy(x => x.ProductName).ToList();
            //        }
            //        break;
            //    case "Price":
            //        if (request.SortType == "Desc")
            //        {
            //            endData = endData.OrderByDescending(x => x.SalePrice).ToList();
            //        }
            //        else
            //        {
            //            endData = endData.OrderBy(x => x.SalePrice).ToList();
            //        }
            //        break;
            //    default:
            //        break;
            //}
            
            var finalResult = new TFPagedResult<ProductRespond>()
            {
                Page = page,
                Limit = (int)result.Count / 12 + 1,
                TotalRecords = result.Count,
                Items = endData
            };
            return finalResult;
        }

        public async Task<DetailModal> GetProductDetailAsync(int id)
        {
            var product = await _context.Products.Where(x => x.ProductID == id).FirstOrDefaultAsync();
            if (product == null) return null;
            var result = new DetailModal()
            {
                ProductID = id,
                ProductName = product.ProductName,
                Price = product.Price,
                SalePrice = product.SalePrice,
                TypeID = product.TypeID,
                TypeName = await _context.ProductTypes.Where(x => x.TypeID == product.TypeID).Select(x => x.TypeName).FirstOrDefaultAsync(),
                Description = product.Description,
                Images = await _context.ProductImages.Where(x => x.ProductID == id).Select(x => x.ImageLink).ToListAsync()
            };

            var brand = await _context.Brands.Where(x => x.BrandID == product.BrandID).FirstOrDefaultAsync();
            result.Brand = brand.BrandName;
            result.Origin = brand.Origin;

            var cateID = await _context.ProductTypes.Where(x => x.TypeID == product.TypeID).Select(x=>x.CategoryID).FirstOrDefaultAsync();
            if(await _context.Categories.Where(x => x.CategoryID == cateID).Select(x => x.IsTypeOfTea).FirstOrDefaultAsync())
            {
                var flavor = (from f in _context.Flavors
                              join tf in _context.ProductTeaFlavors on f.FlavorID equals tf.FlavorID
                              join pt in _context.ProductTeas on tf.ProductTeaID equals pt.ProductTeaID
                              where pt.ProductID == id
                              select new FlavorModal()
                              {
                                  FlavorID = f.FlavorID,
                                  FlavorName = f.FlavorName
                              }).AsSplitQuery();
                result.Flavors = await flavor.ToListAsync();
                var tea = await _context.ProductTeas.Where(x => x.ProductID == id).FirstOrDefaultAsync();
                result.Tea = new PTeaModal()
                {
                    WaterTemperature = tea.WaterTemperature,
                    SteepTime = tea.SteepTime,
                    ServingSize = tea.ServingSize,
                    Ingredients = tea.Ingredients
                };
            }
            else
            {
                var other = await _context.ProductOthers.Where(x => x.ProductID == id).FirstOrDefaultAsync();
                result.Other = new POtherModal()
                {
                    Material = other.Material,
                    Color = other.Color,
                    CareInstruction = other.CareInstruction,
                    Demensions = new List<DemensionModal>()
                };
                var demensionRefs = await _context.ProductOtherDemensions.Where(x => x.ProductOtherID == other.ProductOtherID).ToListAsync();
                foreach(var item in demensionRefs)
                {
                    result.Other.Demensions.Add(new DemensionModal()
                    {
                        DemensionName = await _context.Demensions.Where(x => x.DemensionID == item.DemensionID).Select(x => x.DemensionName).FirstOrDefaultAsync(),
                        Value = item.Value,
                        Unit = item.Unit
                    });
                }
            }
            return result;
        }

        private bool CheckContain(List<int> arr1, List<FlavorModal> arr2)
        {
            foreach(var item in arr1)
            {
                var check = arr2.Where(x => x.FlavorID == item).ToList();
                if (check.Count == 0) return false;
            }
            return true;
        }
    }
}
