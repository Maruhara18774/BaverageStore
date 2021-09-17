using Microsoft.AspNetCore.Identity;
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
            var user = await _userManager.FindByIdAsync(_currentUser.UserId);
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
    }
}
