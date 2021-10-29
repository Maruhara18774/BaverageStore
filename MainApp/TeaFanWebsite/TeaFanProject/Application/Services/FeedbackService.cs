using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Application.Interfaces;
using TeaFanProject.Data;
using TeaFanProject.DesignPatterns.FacadePattern;
using TeaFanProject.Entities;
using TeaFanProject.Infrastructures.Identity;
using TeaFanProject.ViewModals.Common;
using TeaFanProject.ViewModals.FeedbackService;

namespace TeaFanProject.Application.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrentUser _currentUser;
        private readonly FeedbackFecade _fecade;

        public FeedbackService(ApplicationDbContext context, ICurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;

            _fecade = new FeedbackFecade(context,currentUser);
        }

        public async Task<TFPagedResult<FeedbackModal>> GetListFeedbackAsync(GetFeedbacksRequest request)
        {
            return await _fecade.GetListFeedbackAsync(request);
        }
        public async Task<bool> CreateFeedbackAsync(CreateFeedbackRequest request)
        {
            return await _fecade.CreateFeedbackAsync(request);
        }
    }
}
