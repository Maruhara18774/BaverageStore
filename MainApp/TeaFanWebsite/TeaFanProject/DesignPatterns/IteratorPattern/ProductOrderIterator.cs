using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.ViewModals.ProductService;

namespace TeaFanProject.DesignPatterns.IteratorPattern
{
    public class ProductOrderIterator : Iterator
    {
        ProductRespondCollection _collection;
        int _position = -1;
        bool _reverse = false;
        public ProductOrderIterator(ProductRespondCollection collection, bool reverse = false)
        {
            this._collection = collection;
            this._reverse = reverse;
            if (reverse)
            {
                this._position = collection.getItems().Count;
            }
        }
        public override object Current() => this._collection.getItems()[_position];

        public override int Key() => this._position;

        public override bool MoveNext()
        {
            int updatedPosition = this._position + (this._reverse ? -1 : 1);
            if (updatedPosition >= 0 && updatedPosition < this._collection.getItems().Count)
            {
                this._position = updatedPosition;
                return true;
            }
            return false;
        }

        public override void Reset()
        {
            this._position = this._reverse ? _collection.getItems().Count - 1 : 0;
        }
    }
}
