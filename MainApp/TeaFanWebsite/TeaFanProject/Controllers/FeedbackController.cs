using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Application.Interfaces;
using TeaFanProject.ViewModals.Common;
using TeaFanProject.ViewModals.FeedbackService;

namespace TeaFanProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _service;
        public FeedbackController(IFeedbackService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetListAsync(GetFeedbacksRequest request)
        {
            var result = await _service.GetListFeedbackAsync(request);
            var content = new TFResult<TFPagedResult<FeedbackModal>>
            {
                Code = 200,
                Message = "Success",
                Data = result
            };
            return Ok(content);
        }
    }
}
