using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.ViewModals.Common;
using TeaFanProject.ViewModals.ProductService;

namespace TeaFanProject.Application.Interfaces
{
    public interface IProductService
    {
        Task<TFPagedResult<ProductRespond>> GetListProductAsync(ProductRequest request);
    }
}
