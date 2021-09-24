using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Entities;
using TeaFanProject.ViewModals.HomeService;

namespace TeaFanProject.Application.Interfaces
{
    public interface IHomeService
    {
        Task<List<Category>> GetListCategoryAsync();
        Task<List<ProductTypeModal>> GetListProductTypeByCateAsync(int categoryID);
        Task<List<string>> GetListOriginAsync();
        Task<List<FlavorModal>> GetListFlavorAsync();
        Task<Category> GetCategoryByID(int id);
    }
}
