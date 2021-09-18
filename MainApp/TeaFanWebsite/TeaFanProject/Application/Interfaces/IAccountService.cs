using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.ViewModals.AccountService;
using TeaFanProject.ViewModals.Common;

namespace TeaFanProject.Application.Interfaces
{
    public interface IAccountService
    {
        Task<UserModal> GetProfieAsync();
        Task<List<OrderModal>> GetHistoryAsync();
        Task<OrderModal> GetHistoryExpandAsync(int cartID);
    }
}
