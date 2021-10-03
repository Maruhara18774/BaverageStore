using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.ViewModals.ProductService;

namespace TeaFanProject.DesignPatterns.IteratorPattern
{
    public class ProductRespondCollection: IteratorAggregate
    {
        List<ProductRespond> _collection = new List<ProductRespond>();
        bool _direction = false;
        public void ReverseDirection()
        {
            _direction = true;
        }
        public List<ProductRespond> getItems() => _collection;
        public ProductRespondCollection(List<ProductRespond> collection, string type)
        {
            switch (type)
            {
                case "Name":
                    _collection = collection.OrderBy(x => x.ProductName).ToList();
                    break;
                case "Price":
                    _collection = collection.OrderBy(x => x.Price).ToList();
                    break;
                default:
                    _collection = collection.OrderBy(x => x.ProductID).ToList();
                    break;
            }
        }
        public override IEnumerator GetEnumerator() => new ProductOrderIterator(this, _direction);
    }
}
