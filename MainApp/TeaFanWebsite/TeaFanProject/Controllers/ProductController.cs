using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Application.Interfaces;
using TeaFanProject.ViewModals.Common;
using TeaFanProject.ViewModals.ProductService;

namespace TeaFanProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpPost("List")]
        public async Task<IActionResult> GetListProductAsync(ProductRequest request)
        {
            if(request.CategoryID <= 0)
            {
                return Ok(new TFResult<bool>()
                {
                    Code = 400,
                    Message = "Invalid category key",
                    Data = false
                });
            }
            var result = await _service.GetListProductAsync(request);
            var content = new TFResult<TFPagedResult<ProductRespond>>()
            {
                Code = 200,
                Message = "Success",
                Data = result
            };
            return Ok(content);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailProductAsync(int id)
        {
            if (id <= 0)
            {
                return Ok(new TFResult<bool>()
                {
                    Code = 400,
                    Message = "Invalid product key",
                    Data = false
                });
            }
            var result = await _service.GetProductDetailAsync(id);
            var content = new TFResult<DetailModal>()
            {
                Code = (result != null ? 200 : 404),
                Message = (result != null ? "Success" : "Failed"),
                Data = result
            };
            return Ok(content);
        }
    }
}
