using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Infrastructures.Identity;

namespace TeaFanProject.DesignPatterns.FacadePattern
{
    public class FeedbackSubServiceUser
    {
        private readonly ICurrentUser _currentUser;
        public FeedbackSubServiceUser(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }
        public Guid GetUserID()
        {
            return _currentUser.UserId;
        }
    }
}
