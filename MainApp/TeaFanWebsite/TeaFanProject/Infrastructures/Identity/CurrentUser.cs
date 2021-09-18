using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace TeaFanProject.Infrastructures.Identity
{
    public class CurrentUser : ICurrentUser
    {
        public string UserName { get => _httpContextAccessor.HttpContext.User.Identity.Name; }

        public Guid UserId { get => new Guid(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)); }

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
