using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaFanProject.ViewModals.FeedbackService
{
    public class CreateFeedbackRequest
    {
        public int ProductID { get; set; }
        public int StarCount { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
