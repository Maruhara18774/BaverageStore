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
        public async Task<IActionResult> GetProfieAsync()
        {
            var result = await _accountService.GetProfieAsync();
            if (result == null)
            {
                var content2 =  new TFResult<ProfieModal>()
                {
                    Code = 400,
                    Message = "User can not found"
                };
                return BadRequest(content2);
            }
            var content =  new TFResult<ProfieModal>()
            {
                Code = 200,
                Message = "Success",
                Data = result
            };
            return Ok(content);
        }

        [HttpGet("History")]
        public async Task<IActionResult> GetHistoryAsync()
        {
            var result = await _accountService.GetHistoryAsync();
            var content =  new TFResult<List<OrderModal>>()
            {
                Code = 200,
                Message = "Success",
                Data = result
            };
            return Ok(content);
        }
        [HttpGet("History/{id}")]
        public async Task<IActionResult> GetHistoryExpandAsync(int id)
        {
            var result = await _accountService.GetHistoryExpandAsync(id);
            var content = new TFResult<OrderModal>()
            {
                Code = 200,
                Message = "Success",
                Data = result
            };
            return Ok(content);
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> EditProfieAsync(EditRequest request)
        {
            var result = await _accountService.EditProfieAsync(request);
            if(result != null)
            {
                return Ok(new TFResult<UserModal>()
                {
                    Code = 200,
                    Message = "Success",
                    Data = result
                });
            }
            return BadRequest(new TFResult<UserModal>()
            {
                Code = 400,
                Message = "Failed request"
            });
        }
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordRequest request)
        {
            var result = await _accountService.ChangePasswordAsync(request);
            if (result)
            {
                return Ok(new TFResult<bool>()
                {
                    Code = 200,
                    Message = "Success",
                    Data = true
                });
            }
            return BadRequest(new TFResult<bool>()
            {
                Code = 400,
                Message = "Failed",
                Data = false
            });
        }
    }
}
