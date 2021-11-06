using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Application.Interfaces;
using TeaFanProject.Application.Services;
using TeaFanProject.Data;
using TeaFanProject.Infrastructures.Identity;
using TeaFanProject.ViewModals.Common;
using TeaFanProject.ViewModals.FeedbackService;

namespace TeaFanProject.DesignPatterns.ProxyPattern
{
    public class FeedbackServiceProxy : IFeedbackService
    {
        FeedbackService _realService;
        public FeedbackServiceProxy(ApplicationDbContext context, ICurrentUser currentUser)
        {
            this._realService = new FeedbackService(context,currentUser);
        }
        public async Task<bool> CreateFeedbackAsync(CreateFeedbackRequest request)
        {
            if (request.ProductID <= 0
                || request.StarCount < 1
                || request.StarCount > 5
                || String.IsNullOrWhiteSpace(request.Title))
            {
                return false;
            }
            return await this._realService.CreateFeedbackAsync(request);
        }

        public async Task<TFPagedResult<FeedbackModal>> GetListFeedbackAsync(GetFeedbacksRequest request)
        {
            if(request.ProductID <= 0)
            {
                return null;
            }
            return await this._realService.GetListFeedbackAsync(request);
        }
    }
}
