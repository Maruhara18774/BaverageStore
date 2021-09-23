using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Application.Interfaces;
using TeaFanProject.Data;
using TeaFanProject.Entities;
using TeaFanProject.Infrastructures.Identity;
using TeaFanProject.ViewModals.HomeService;

namespace TeaFanProject.Application.Services
{
    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrentUser _currentUser;

        public HomeService(ApplicationDbContext context, ICurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<List<Category>> GetListCategoryAsync()
        {
            var listCate = await _context.Categories.ToListAsync();
            return listCate;
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

        public async Task<List<BrandModal>> GetListBrandAsync()
        {
            var listBrand = from b in _context.Brands
                            select b;
            var result = await listBrand.Select(p => new BrandModal()
            {
                BrandID = p.BrandID,
                BrandName = p.BrandName,
                Origin = p.Origin
            }).ToListAsync();
            return result;
        }

    }
}
