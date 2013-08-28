using System.Collections.Generic;
using System.Linq;

namespace SpaStore.Model
{
    public class Cart
    {
        private readonly List<CartLine>  _lineCollection = new List<CartLine>();

        public IEnumerable<CartLine>  Lines
        {
            get
            {
                return _lineCollection;
            }
        }

        public void AddItem(Product product, int quantity)
        {
            CartLine line = _lineCollection.FirstOrDefault(p => p.Product.Id == product.Id);

            if (line == null)
                _lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            else
                line.Quantity += quantity;
        }

        public void RemoveLine(Product product)
        {
            _lineCollection.RemoveAll(p => p.Product.Id == product.Id);
        }

        public decimal ComputeTotalValue()
        {
            return _lineCollection.Sum(p => p.LineSubTotal);
        }

        public void Clear()
        {
            _lineCollection.Clear();
        }
    }
}