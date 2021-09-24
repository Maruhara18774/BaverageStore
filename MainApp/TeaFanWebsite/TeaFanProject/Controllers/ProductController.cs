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
        [HttpGet("List")]
        public async Task<IActionResult> GetListProductAsync(ProductRequest request)
        {
            var result = await _service.GetListProductAsync(request);
            var content = new TFResult<TFPagedResult<ProductRespond>>()
            {
                Code = 200,
                Message = "Success",
                Data = result
            };
            return Ok(content);
        }
    }
}
