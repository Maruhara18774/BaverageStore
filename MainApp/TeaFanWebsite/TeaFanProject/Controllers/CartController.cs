using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Application.Interfaces;
using TeaFanProject.ViewModals.CartService;
using TeaFanProject.ViewModals.Common;

namespace TeaFanProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CartController: Controller
    {
        private readonly ICartService _service;
        public CartController(ICartService service)
        {
            _service = service;
        }
        [HttpGet("Current")]
        public async Task<IActionResult> GetCurrentCartAsync()
        {
            var result = await _service.GetCurrentCartDetail();
            return Ok(new TFResult<CartModal>()
            {
                Code = 200,
                Message = "Success",
                Data = result
            });
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddProductAsync(AddProduct2CartRequest request)
        {
            if(request.ProductID <= 0 || request.Quantity <= 0)
            {
                return Ok(new TFResult<bool>()
                {
                    Code = 400,
                    Message = "Invalid input",
                    Data = false
                });
            }
            var result = await _service.AddProductAsync(request);
            return Ok(new TFResult<bool>()
            {
                Code = result ? 200 : 400,
                Message = result ? "Success" : "Invalid key of cart/ product",
                Data = result
            });
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> ChangeQuantityAsync(EditQuantityRequest request)
        {
            if (request.CartID <= 0 ||
                request.ProductID <= 0 ||
                request.Quantity <= 0)
            {
                return Ok(new TFResult<bool>()
                {
                    Code = 400,
                    Message = "Invalid input",
                    Data = false
                });
            }
            var result = await _service.ChangeQuantityAsync(request);
            return Ok(new TFResult<bool>()
            {
                Code = result ? 200 : 400,
                Message = result ? "Success" : "Invalid key of cart/ product",
                Data = result
            });
        }

        [HttpPost("Remove")]
        public async Task<IActionResult> RemoveProductAsync(RemoveProductInCartRequest request)
        {
            if(request.CartID <= 0|| request.ProductID <= 0)
            {
                return Ok(new TFResult<bool>()
                {
                    Code = 400,
                    Message = "Invalid input",
                    Data = false
                });
            }
            var result = await _service.RemoveProductAsync(request);
            return Ok(new TFResult<bool>()
            {
                Code = result ? 200 : 400,
                Message = result ? "Success" : "Invalid key of cart/ product",
                Data = result
            });
        }

    }
}
