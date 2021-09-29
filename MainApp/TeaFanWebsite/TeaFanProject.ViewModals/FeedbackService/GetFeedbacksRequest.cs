using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaFanProject.ViewModals.FeedbackService
{
    public class GetFeedbacksRequest
    {
        public int Page { get; set; }
        public int ProductID { get; set; }
    }
}
