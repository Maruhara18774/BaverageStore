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
    [Authorize]
    public class LoginController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public LoginController(SignInManager<User> signInManager,UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
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
            var signInResult = await _signInManager.PasswordSignInAsync(request.Email, request.Password, request.RememberMe, false);
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
        [HttpGet("Logout")]
        public async Task<TFResult<bool>> Logout()
        {
            await _signInManager.SignOutAsync();
            return new TFResult<bool>()
            {
                Code = 200,
                Message = "Logout success"
            };
        }
        [AllowAnonymous]
        [HttpPost("Regist")]
        public async Task<TFResult<UserModal>> Register(RegistRequest request)
        {
            var checkEmail = await _userManager.FindByEmailAsync(request.Email);
            if(checkEmail!= null)
            {
                return new TFResult<UserModal>()
                {
                    Code = 402,
                    Message = "This email was used"
                };
            }
            var user = new User()
            {
                Email = request.Email,
                UserName = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            await _userManager.AddToRoleAsync(user, "Customer");
            if (result.Succeeded)
            {
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
            }
            return new TFResult<UserModal>()
            {
                Code = 403,
                Message = "Failed regist"
            };
        }
    }
}
