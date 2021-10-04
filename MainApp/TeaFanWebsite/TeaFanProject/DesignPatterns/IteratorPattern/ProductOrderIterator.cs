using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.ViewModals.ProductService;

namespace TeaFanProject.DesignPatterns.IteratorPattern
{
    public class ProductOrderIterator : Iterator
    {
        List<ProductRespond> _collection;
        int _position = -1;
        bool _reverse = false;
        public ProductOrderIterator(List<ProductRespond> collection, string type, bool reverse = false)
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
            this._reverse = reverse;
            if (reverse)
            {
                this._position = collection.Count;
            }
        }
        public override ProductRespond Current() => this._collection[_position];

        public override int Key() => this._position;

        public override bool MoveNext()
        {
            int updatedPosition = this._position + (this._reverse ? -1 : 1);
            if (updatedPosition >= 0 && updatedPosition < this._collection.Count)
            {
                this._position = updatedPosition;
                return true;
            }
            return false;
        }

        public override void Reset()
        {
            this._position = this._reverse ? _collection.Count - 1 : 0;
        }
        public List<ProductRespond> getItems() => _collection;
    }
}
