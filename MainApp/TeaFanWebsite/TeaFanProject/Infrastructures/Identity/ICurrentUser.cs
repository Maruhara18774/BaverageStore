using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.Infrastructures.Identity
{
    public interface ICurrentUser
    {
        string UserName { get; }
        string UserId { get; }
    }
}
