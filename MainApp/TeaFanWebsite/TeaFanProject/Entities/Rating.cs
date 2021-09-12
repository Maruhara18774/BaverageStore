using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.Entities
{
    public class Rating
    {
        public int RatingID { get; set; }
        public Guid UserID { get; set; }
        public int ProductID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int StarCount { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
