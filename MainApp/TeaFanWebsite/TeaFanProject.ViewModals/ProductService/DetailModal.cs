using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaFanProject.ViewModals.HomeService;

namespace TeaFanProject.ViewModals.ProductService
{
    public class DetailModal: ProductModal
    {
        public string TypeName { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public PTeaModal Tea { get; set; }
        public POtherModal Other { get; set; }
        public virtual DetailModal GetDetailModal() => this;
    }
}
