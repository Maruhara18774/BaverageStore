using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Data;
using TeaFanProject.Infrastructures.Identity;
using TeaFanProject.ViewModals.Common;
using TeaFanProject.ViewModals.FeedbackService;

namespace TeaFanProject.DesignPatterns.FacadePattern
{
    public class FeedbackFecade
    {
        FeedbackSubServiceContext _contextProvider;
        FeedbackSubServiceUser _currentUserProvider;
        public FeedbackFecade(ApplicationDbContext context, ICurrentUser currentUser)
        {
            _contextProvider = new FeedbackSubServiceContext(context);
            _currentUserProvider = new FeedbackSubServiceUser(currentUser);
        }
        public async Task<TFPagedResult<FeedbackModal>> GetListFeedbackAsync(GetFeedbacksRequest request)
        {
            return await _contextProvider.GetListFeedbackAsync(request);
        }
        public async Task<bool> CreateFeedbackAsync(CreateFeedbackRequest request)
        {
            var userID = _currentUserProvider.GetUserID();
            return await _contextProvider.CreateFeedbackAsync(request, userID);
        }
    }
}
