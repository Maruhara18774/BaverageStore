using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.ViewModals.CartService;

namespace TeaFanProject.Application.Interfaces
{
    public interface ICartService
    {
        Task<CartModal> GetCurrentCartDetail();
        Task<bool> AddProductAsync(AddProduct2CartRequest request);
        Task<bool> ChangeQuantityAsync(EditQuantityRequest request);
        Task<bool> RemoveProductAsync(RemoveProductInCartRequest request);
        Task<CartModal> GetCheckoutAsync();
        Task<bool> ConfirmCheckoutAsync();
    }
}
