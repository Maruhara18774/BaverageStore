using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Application.Interfaces;
using TeaFanProject.Data;
using TeaFanProject.DesignPatterns.SingletonPattern;
using TeaFanProject.Entities;
using TeaFanProject.Infrastructures.Identity;
using TeaFanProject.ViewModals.HomeService;

namespace TeaFanProject.Application.Services
{
    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext _context;

        public HomeService(ApplicationDbContext context)
        {
            _context = context;
            CategorySingleton.Init(_context);
        }

        public async Task<List<Category>> GetListCategoryAsync()
        {
            var cate = CategorySingleton.GetInstance().GetCategory();
            return cate;
        }

        public async Task<List<ProductTypeModal>> GetListProductTypeByCateAsync(int categoryID)
        {
            var listType = from t in _context.ProductTypes
                           where t.CategoryID == categoryID
                           select t;
            var result = await listType.Select(p => new ProductTypeModal()
            {
                TypeID = p.TypeID,
                TypeName = p.TypeName
            }).ToListAsync();
            return result;
        }

        public async Task<List<string>> GetListOriginAsync()
        {
            var listBrand = await (from b in _context.Brands
                            select b).ToListAsync();
            var result = new List<string>();
            foreach(var item in listBrand)
            {
                var check = result.Where(x => x == item.Origin).FirstOrDefault();
                if (check == null) result.Add(item.Origin);
            }
            return result;
        }

        public async Task<List<FlavorModal>> GetListFlavorAsync()
        {
            var listFlavor = from f in _context.Flavors
                             select f;
            var result = await listFlavor.Select(p => new FlavorModal()
            {
                FlavorID = p.FlavorID,
                FlavorName = p.FlavorName
            }).ToListAsync();
            return result;
        }

        public async Task<Category> GetCategoryByID(int id)
        {
            var cate = CategorySingleton.GetInstance().GetCategory().Where(x => x.CategoryID == id).FirstOrDefault();
            return cate;
        }
    }
}
