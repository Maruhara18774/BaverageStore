using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Application.Interfaces;
using TeaFanProject.Data;
using TeaFanProject.ViewModals.ManageProductType;

namespace TeaFanProject.Application.Services
{
    public class ManageProductTypeService : IManageProductTypeService
    {
        private readonly ApplicationDbContext _context;
        public ManageProductTypeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddProductType(AddProductTypeRequest request)
        {
            if (request.CategoryID <= 0 || String.IsNullOrEmpty(request.TypeName)) return "Wrong input.";
            var category = await _context.Categories.Where(x => x.CategoryID == request.CategoryID).FirstOrDefaultAsync();
            if (category == null) return "Category not found.";
            var type = await _context.ProductTypes.Where(x => x.CategoryID == request.CategoryID || x.TypeName == request.TypeName).FirstOrDefaultAsync();
            if (type != null) return "Duplicated product type";
            _context.ProductTypes.Add(new Entities.ProductType()
            {
                TypeName = request.TypeName,
                CategoryID = request.CategoryID,
                MyProperty = 0
            });
            await _context.SaveChangesAsync();
            return "Success.";
        }

        public async Task<string> EditProductType(EditProductTypeRequest request)
        {
            if (request.TypeID <= 0 || String.IsNullOrEmpty(request.TypeName)) return "Wrong input.";
            var type = await _context.ProductTypes.Where(x => x.TypeID == request.TypeID).FirstOrDefaultAsync();
            if (type == null) return "Product type not found.";
            type.TypeName = request.TypeName;
            await _context.SaveChangesAsync();
            return "Success.";
        }

        public async Task<string> RemoveProductType(int typeID)
        {
            if (typeID <= 0) return "Wrong input.";
            var type = await _context.ProductTypes.Where(x => x.TypeID == typeID).FirstOrDefaultAsync();
            if (type == null) return "Product type not found.";
            _context.ProductTypes.Remove(type);
            await _context.SaveChangesAsync();
            return "Success.";
        }
    }
}
