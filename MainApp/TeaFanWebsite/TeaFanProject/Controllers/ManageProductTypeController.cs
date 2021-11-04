using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Application.Interfaces;
using TeaFanProject.ViewModals.Common;
using TeaFanProject.ViewModals.ManageProductType;

namespace TeaFanProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ManageProductTypeController : Controller
    {
        private readonly IManageProductTypeService _service;
        public ManageProductTypeController(IManageProductTypeService service)
        {
            _service = service;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddType(AddProductTypeRequest request)
        {
            var result = await _service.AddProductType(request);
            var content = new TFResult<string>()
            {
                Code = result == "Success." ? 200 : 400,
                Message = result,
                Data = result
            };
            return Ok(content);
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> EditType(EditProductTypeRequest request)
        {
            var result = await _service.EditProductType(request);
            var content = new TFResult<string>()
            {
                Code = result == "Success." ? 200 : 400,
                Message = result,
                Data = result
            };
            return Ok(content);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteType(int id)
        {
            var result = await _service.RemoveProductType(id);
            var content = new TFResult<string>()
            {
                Code = result == "Success." ? 200 : 400,
                Message = result,
                Data = result
            };
            return Ok(content);
        }
    }
}
