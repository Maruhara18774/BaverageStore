using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaFanProject.ViewModals.FeedbackService
{
    public class FeedbackModal
    {
        public Guid UserID { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int StarCount { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
