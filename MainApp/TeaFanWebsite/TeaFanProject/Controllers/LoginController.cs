using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Entities;
using TeaFanProject.ViewModals.AccountService;
using TeaFanProject.ViewModals.Common;

namespace TeaFanProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        public LoginController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<TFResult<UserModal>> Login(LoginRequest request)
        {
            var user = await _signInManager.UserManager.FindByEmailAsync(request.Email);
            if(user == null || user.DeletedDate != null)
            {
                return new TFResult<UserModal>()
                {
                    Code = 404,
                    Message = "User not found",
                    Data = null
                };
            }
            var signInResult = await _signInManager.PasswordSignInAsync(request.Email, request.Password, true, false);
            if (signInResult.Succeeded)
            {
                var userModal = new UserModal()
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Type = (await _signInManager.UserManager.GetRolesAsync(user))[0]
                };
                return new TFResult<UserModal>()
                {
                    Code = 200,
                    Message = "Login success",
                    Data = userModal
                };
            }
            else
            {
                return new TFResult<UserModal>()
                {
                    Code = 401,
                    Message = "Password is incorrect",
                    Data = null
                };
            }
        }
    }
}
