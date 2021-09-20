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
        Task<ProfieModal> GetProfieAsync();
        Task<List<OrderModal>> GetHistoryAsync();
        Task<OrderModal> GetHistoryExpandAsync(int cartID);
        Task<UserModal> EditProfieAsync(EditRequest request);
        Task<bool> ChangePasswordAsync(ChangePasswordRequest request);
    }
}
