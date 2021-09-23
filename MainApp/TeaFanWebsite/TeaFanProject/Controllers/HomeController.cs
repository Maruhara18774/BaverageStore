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
        public async Task<IActionResult> GetListCategoryAsync()
        {
            var result = await _homeService.GetListCategoryAsync();
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
            if(result.Count == 0)
            {
                var nullExc = new TFResult<bool>()
                {
                    Code = 404,
                    Message = "Wrong category ID"
                };
                return Ok(nullExc);
            }
            var content = new TFResult<List<ProductTypeModal>>()
            {
                Code = 200,
                Message = "Success",
                Data = result
            };
            return Ok(content);
        }
        [HttpGet("Brands")]
        public async Task<IActionResult> GetListBrandAsync()
        {
            var result = await _homeService.GetListBrandAsync();
            var content = new TFResult<List<BrandModal>>()
            {
                Code = 200,
                Message = "Success",
                Data = result
            };
            return Ok(result);
        }
    }
}
