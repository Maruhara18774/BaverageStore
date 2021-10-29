using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.ViewModals.ManageProductType;

namespace TeaFanProject.Application.Interfaces
{
    public interface IManageProductTypeService
    {
        Task<string> AddProductType(AddProductTypeRequest request);
        Task<string> EditProductType(EditProductTypeRequest request);
        Task<string> RemoveProductType(int typeID);
    }
}
