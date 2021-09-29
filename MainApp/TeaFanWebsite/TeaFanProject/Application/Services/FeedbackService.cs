using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Application.Interfaces;
using TeaFanProject.Data;
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

        public FeedbackService(ApplicationDbContext context, ICurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<TFPagedResult<FeedbackModal>> GetListFeedbackAsync(GetFeedbacksRequest request)
        {
            var feedback = await _context.Ratings.Where(x => x.ProductID == request.ProductID)
                .Select(x => new FeedbackModal()
                {
                    CreatedDate = x.CreatedDate,
                    StarCount = x.StarCount,
                    Title = x.Title,
                    Content = x.Content,
                    UserID = x.UserID
                }).ToListAsync();
            foreach(var item in feedback)
            {
                var user = await _context.Users.Where(x => x.Id == item.UserID).FirstOrDefaultAsync();
                item.FullName = user.FirstName + " " + user.LastName;
            }
            var page = request.Page > 0 ? request.Page : 1;
            var endData = feedback.Skip((page - 1) * 5).Take(5).ToList();
            return new TFPagedResult<FeedbackModal>(){
                Page = page,
                Limit = (int)feedback.Count / 5 + 1,
                TotalRecords = feedback.Count,
                Items = endData
            };
        }
        public async Task<bool> CreateFeedbackAsync(CreateFeedbackRequest request)
        {
            _context.Ratings.Add(new Rating()
            {
                UserID = _currentUser.UserId,
                ProductID = request.ProductID,
                CreatedDate = DateTime.Now,
                StarCount = request.StarCount,
                Title = request.Title,
                Content = request.Content
            });
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
