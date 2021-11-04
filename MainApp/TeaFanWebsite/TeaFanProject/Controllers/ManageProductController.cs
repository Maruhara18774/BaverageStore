using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class ManageProductController : Controller
    {
        private readonly IManageProductService _service;
        public ManageProductController(IManageProductService service)
        {
            _service = service;
        }
        [HttpGet("{page}")]
        public async Task<IActionResult> GetProductsAsync(int page)
        {
            var result = await _service.GetListProductAsync(page);
            var content = new TFResult<TFPagedResult<ProductRespond>>
            {
                Code = 200,
                Message = "Success",
                Data = result
            };
            return Ok(result);
        }
    }
}
