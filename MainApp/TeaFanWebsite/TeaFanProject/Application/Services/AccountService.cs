using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Application.Interfaces;
using TeaFanProject.Data;
using TeaFanProject.Entities;
using TeaFanProject.Infrastructures.Identity;
using TeaFanProject.ViewModals.AccountService;
using TeaFanProject.ViewModals.Common;

namespace TeaFanProject.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly ICurrentUser _currentUser;

        public AccountService(ApplicationDbContext context
            , UserManager<User> userManager
            , ICurrentUser currentUser)
        {
            _context = context;
            _userManager = userManager;
            _currentUser = currentUser;
        }

        public async Task<UserModal> GetProfieAsync()
        {
            var user = await _userManager.FindByIdAsync(_currentUser.UserId.ToString());
            if (user!= null)
            {
                return new UserModal()
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Type = (await _userManager.GetRolesAsync(user))[0]
                };
            }
            return null;
        }
        public async Task<List<OrderModal>> GetHistoryAsync()
        {
            var result = new List<OrderModal>();
            var listOrder = await _context.Carts.Where(x => x.UserID == _currentUser.UserId && x.Total != 0).ToListAsync();
            foreach(var item in listOrder)
            {
                result.Add(new OrderModal()
                {
                    OrderID = item.CartID,
                    OrderDate = item.CreatedDate,
                    Shipping = item.ShippingPrice,
                    Total = item.Total
                });
            }
            return result;
        }

        public async Task<OrderModal> GetHistoryExpandAsync(int cartID)
        {
            var cart = _context.Carts.Where(x => x.CartID == cartID).FirstOrDefault();
            if (cart == null) return null;
            var result = new OrderModal()
            {
                OrderID = cart.CartID,
                OrderDate = cart.CreatedDate,
                Shipping = cart.ShippingPrice,
                Total = cart.Total,
                OrderDetails = new List<OrderDetailModal>()
            };
            var details = await _context.CartDetails.Where(x => x.CartID == cartID).ToListAsync();
            foreach(var item in details)
            {
                result.OrderDetails.Add(new OrderDetailModal()
                {
                    DetailID = item.CartDetailID,
                    ProductID = item.ProductID,
                    ProductName = _context.Products.Where(x => x.ProductID == item.ProductID).FirstOrDefault().ProductName,
                    ImageURL = _context.ProductImages.Where(x => x.ProductID == item.ProductID).FirstOrDefault().ImageLink,
                    Quantity = item.Quantity,
                    SalePrice = item.SoldPrice,
                    Total = item.Total
                });
            }
            return result;
        }

        public async Task<UserModal> EditProfieAsync(EditRequest request)
        {
            var user = _context.Users.Where(x => x.Id == _currentUser.UserId).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Address = request.Address;
            user.PhoneNumber = request.PhoneNumber;
            await _context.SaveChangesAsync();
            return new UserModal()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Type = (await _userManager.GetRolesAsync(user))[0]
            };
        }

        public Task<bool> ChangePasswordAsync(string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
