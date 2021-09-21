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
        private readonly UserManager<User> _userManager;
        public LoginController(SignInManager<User> signInManager,UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if(request.Email == null || request.Password == null || request.Email == "" || request.Password == "")
            {
                var content = new TFResult<UserModal>()
                {
                    Code = 400,
                    Message = "Have null parameter"
                };
                return BadRequest(content);
            }
            var user = await _signInManager.UserManager.FindByEmailAsync(request.Email);
            if(user == null || user.DeletedDate != null)
            {
                var content =  new TFResult<UserModal>()
                {
                    Code = 404,
                    Message = "User not found",
                    Data = null
                };
                return BadRequest(content);
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
                var content =  new TFResult<UserModal>()
                {
                    Code = 200,
                    Message = "Login success",
                    Data = userModal
                };
                return Ok(content);
            }
            else
            {
                var content =  new TFResult<UserModal>()
                {
                    Code = 401,
                    Message = "Password is incorrect",
                    Data = null
                };
                return BadRequest(content);
            }
        }
        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
                var content = new TFResult<bool>()
                {
                    Code = 200,
                    Message = "Logout success"
                };
                return Ok(content);
            }
            var content2 = new TFResult<bool>()
            {
                Code = 401,
                Message = "Did not login before"
            };
            return BadRequest(content2);
        }
        [AllowAnonymous]
        [HttpPost("Regist")]
        public async Task<IActionResult> Register(RegistRequest request)
        {
            var checkEmail = await _userManager.FindByEmailAsync(request.Email);
            if(checkEmail!= null)
            {
                var content1 =  new TFResult<UserModal>()
                {
                    Code = 402,
                    Message = "This email was used"
                };
                return BadRequest(content1);
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
                    var content2 =  new TFResult<UserModal>()
                    {
                        Code = 200,
                        Message = "Login success",
                        Data = userModal
                    };
                    return Ok(content2);
                }
            }
            var content =  new TFResult<UserModal>()
            {
                Code = 403,
                Message = "Failed regist"
            };
            return BadRequest(content);
        }
    }
}
