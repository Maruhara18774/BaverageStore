using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaFanProject.ViewModals.Common
{
    public class TFPagedResult<T>
    {
        public List<T> Items { get; set; }
        public int Page { get; set; }

        public int Limit { get; set; }

        public int TotalRecords { get; set; }

        public int PageCount
        {
            get
            {
                var pageCount = (double)TotalRecords / Limit;
                return (int)Math.Ceiling(pageCount);
            }
        }
    }
}
