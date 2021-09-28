using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaFanProject.ViewModals.ProductService
{
    public class POtherModal
    {
        public string Material { get; set; }
        public string Color { get; set; }
        public string CareInstruction { get; set; }
        public List<DemensionModal> Demensions { get; set; }
    }
}
