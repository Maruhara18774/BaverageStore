using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Application.Interfaces;
using TeaFanProject.ViewModals.AccountService;
using TeaFanProject.ViewModals.Common;

namespace TeaFanProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet("Profie")]
        public async Task<TFResult<UserModal>> GetProfie()
        {
            var result = await _accountService.GetProfieAsync();
            if (result == null)
            {
                return new TFResult<UserModal>()
                {
                    Code = 400,
                    Message = "User can not found"
                };
            }
            return new TFResult<UserModal>()
            {
                Code = 200,
                Message = "Success",
                Data = result
            };
        }
    }
}
