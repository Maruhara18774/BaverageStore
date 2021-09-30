using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Application.Interfaces;
using TeaFanProject.Data;
using TeaFanProject.Entities;
using TeaFanProject.Infrastructures.Identity;
using TeaFanProject.ViewModals.CartService;

namespace TeaFanProject.Application.Services
{
    public class CartService: ICartService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrentUser _currentUser;

        public CartService(ApplicationDbContext context, ICurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<CartModal> GetCurrentCartDetail()
        {
            var currentCartID = await GetCurrentCartAsync();
            var details = (await UpdateProductPrice(currentCartID)).Select(x => new CartDetailModal()
            {
                ProductID = x.ProductID,
                SoldPrice = x.SoldPrice,
                Quantity = x.Quantity,
                ProductName = _context.Products.Where(p => p.ProductID == x.ProductID).Select(p => p.ProductName).FirstOrDefault(),
                ImageURL = _context.ProductImages.Where(i => i.ProductID == x.ProductID).Select(i => i.ImageLink).FirstOrDefault()
            }).ToList();
            return new CartModal()
            {
                CartID = currentCartID,
                ShippingPrice = 0,
                Total = 0,
                Details = details
            };
        }

        public async Task<bool> AddProductAsync(AddProduct2CartRequest request)
        {
            var product = await _context.Products.Where(x => x.ProductID == request.ProductID).FirstOrDefaultAsync();
            if (product == null) return false;
            var currentCartID = await GetCurrentCartAsync();
            var check = await _context.CartDetails.Where(x => x.CartID == currentCartID && x.ProductID == request.ProductID).FirstOrDefaultAsync();
            if(check != null)
            {
                check.Quantity += request.Quantity;
                check.Total = (check.Quantity + request.Quantity) * check.SoldPrice;
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.CartDetails.Add(new CartDetail()
                {
                    CartID = currentCartID,
                    ProductID = request.ProductID,
                    Quantity = request.Quantity,
                    SoldPrice = product.SalePrice,
                    Total = product.SalePrice * request.Quantity
                });
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> ChangeQuantityAsync(EditQuantityRequest request)
        {
            var detail = await _context.CartDetails.Where(x => x.CartID == request.CartID && x.ProductID == request.ProductID).FirstOrDefaultAsync();
            if (detail == null) return false;
            detail.Quantity = request.Quantity;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveProductAsync(RemoveProductInCartRequest request)
        {
            var detail = await _context.CartDetails.Where(x => x.CartID == request.CartID && x.ProductID == request.ProductID).FirstOrDefaultAsync();
            if (detail == null) return false;
            _context.CartDetails.Remove(detail);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<CartModal> GetCheckoutAsync()
        {
            var currentCartID = await GetCurrentCartAsync();
            var check = await UpdateProductPrice(currentCartID);
            if (check.Count == 0) return null;
            var details = check.Select(x => new CartDetailModal()
            {
                ProductID = x.ProductID,
                SoldPrice = x.SoldPrice,
                Quantity = x.Quantity,
                ProductName = _context.Products.Where(p => p.ProductID == x.ProductID).Select(p => p.ProductName).FirstOrDefault(),
                ImageURL = _context.ProductImages.Where(i => i.ProductID == x.ProductID).Select(i => i.ImageLink).FirstOrDefault(),
                Total = x.Total
            }).ToList();
            var count = details.Sum(x => x.Total);
            return new CartModal()
            {
                CartID = currentCartID,
                ShippingPrice = 8,
                Total = count,
                Details = details
            };
        }
        public async Task<bool> ConfirmCheckoutAsync()
        {
            var currentCartID = await GetCurrentCartAsync();
            var check = await UpdateProductPrice(currentCartID);
            if (check.Count == 0) return false;
            var count = check.Sum(x => x.Total);
            var cart = await _context.Carts.Where(x => x.CartID == currentCartID).FirstOrDefaultAsync();
            cart.CreatedDate = DateTime.Now;
            cart.ShippingPrice = 8;
            cart.Total = count;
            return true;
        }
        public async Task<int> GetCurrentCartAsync()
        {
            var currentCart = await _context.Carts.Where(x => x.UserID == _currentUser.UserId && x.Total == 0).FirstOrDefaultAsync();
            if (currentCart == null)
            {
                _context.Carts.Add(new Cart()
                {
                    UserID = _currentUser.UserId,
                    CreatedDate = DateTime.Now,
                    ShippingPrice = 0,
                    Total = 0
                });
                await _context.SaveChangesAsync();
                return await _context.Carts.Where(x => x.UserID == _currentUser.UserId && x.Total == 0).Select(x => x.CartID).FirstOrDefaultAsync();
            }
            return currentCart.CartID;
        }

        public async Task<List<CartDetail>> UpdateProductPrice(int cartID)
        {
            var checkPrice = await _context.CartDetails.Where(x => x.CartID == cartID).ToListAsync();
            foreach (var item in checkPrice)
            {
                var currentPrice = await _context.Products.Where(x => x.ProductID == item.ProductID).Select(x => x.SalePrice).FirstOrDefaultAsync();
                if (item.SoldPrice != currentPrice)
                {
                    item.SoldPrice = currentPrice;
                    item.Total = currentPrice * item.Quantity;
                }
            }
            await _context.SaveChangesAsync();
            return checkPrice;
        }
    }
}
