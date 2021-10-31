using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Application.Interfaces;
using TeaFanProject.Entities;
using TeaFanProject.ViewModals.Common;
using TeaFanProject.ViewModals.HomeService;

namespace TeaFanProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }
        [HttpGet("Categories")]
        public IActionResult GetListCategoryAsync()
        {
            var result = _homeService.GetListCategoryAsync();
            var content = new TFResult<List<Category>>()
            {
                Code = 200,
                Message = "Success",
                Data = result
            };
            return Ok(content);
        }
        [HttpGet("ProductTypes/{id}")]
        public async Task<IActionResult> GetListProductTypeByCateIDAsync(int id)
        {
            var result = await _homeService.GetListProductTypeByCateAsync(id);
            var content = new TFResult<List<ProductTypeModal>>()
            {
                Code = 200,
                Message = "Success",
                Data = result
            };
            return Ok(content);
        }
        [HttpGet("Origins")]
        public async Task<IActionResult> GetListOriginAsync()
        {
            var result = await _homeService.GetListOriginAsync();
            var content = new TFResult<List<string>>()
            {
                Code = 200,
                Message = "Success",
                Data = result
            };
            return Ok(result);
        }
        [HttpGet("Flavors")]
        public async Task<IActionResult> GetListFlavorAsync()
        {
            var result = await _homeService.GetListFlavorAsync();
            var content = new TFResult<List<FlavorModal>>()
            {
                Code = 200,
                Message = "Success",
                Data = result
            };
            return Ok(result);
        }
        [HttpGet("Category/{id}")]
        public IActionResult GetCategoryByIDAsync(int id)
        {
            var result = _homeService.GetCategoryByID(id);
            var content = new TFResult<Category>()
            {
                Code = 200,
                Message = "Success",
                Data = result
            };
            return Ok(content);
        }
    }
}
