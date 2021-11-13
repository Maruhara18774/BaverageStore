using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.ViewModals.ProductService;

namespace TeaFanProject.DesignPatterns.AdapterPattern
{
    public class ProductionDetailToDetailModalAdapter: DetailModal
    {
        private readonly TeaProductionDetail _teaProductionDetail;
        private readonly OtherProductionDetail _otherProductionDetail;
        private readonly string Type;
        public ProductionDetailToDetailModalAdapter(TeaProductionDetail teaProductionDetail)
        {
            _teaProductionDetail = teaProductionDetail;
            Type = "Tea";
        }
        public ProductionDetailToDetailModalAdapter(OtherProductionDetail otherProductionDetail)
        {
            _otherProductionDetail = otherProductionDetail;
            Type = "Other";
        }

        public override DetailModal GetDetailModal()
        {
            DetailModal modal;
            if(Type == "Tea")
            {
                modal = _teaProductionDetail.GetBaseDetailModal();
                modal.Flavors = _teaProductionDetail.Flavors;
                modal.Tea = _teaProductionDetail.Tea;
            }
            else
            {
                modal = _otherProductionDetail.GetBaseDetailModal();
                modal.Other = _otherProductionDetail.Other;
            }
            return modal;
        }
    }
}
