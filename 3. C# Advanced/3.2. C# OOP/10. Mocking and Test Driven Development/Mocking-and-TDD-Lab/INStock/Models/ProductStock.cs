namespace INStock.Models
{
    using INStock.Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductStock : IProductStock
    {
        private List<IProduct> products;

        public ProductStock()
        {
            products = new List<IProduct>();
        }

        public IProduct this[int index]
        {
            get => this.products[index];
            set => this.products[index] = value as Product;
        }

        public int Count => this.products.Count;

        public void Add(IProduct product)
        {
            if (this.Contains(product))
            {
                throw new InvalidOperationException("This product is already in stock.");
            }

            this.products.Add(product as Product);
        }

        public bool Contains(IProduct product)
        {
            return this.products.Contains(product);
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Inavlid index");
            }

            return this.products[index];

        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            List<IProduct> wantedProducts = new List<IProduct>(this.products
                .Where(x => x.Price == price));
            return wantedProducts;
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            List<IProduct> wantedProducts = new List<IProduct>(this.products
                .Where(x => x.Quantity == quantity));
            return wantedProducts;
        }

        public IEnumerable<IProduct> FindAllInPriceRange(decimal lo, decimal hi)
        {
            List<IProduct> wantedProducts = new List<IProduct>(this.products
                .Where(x => x.Price >= lo && x.Price <= hi)
                .OrderByDescending(x => x.Price));
            return wantedProducts;
        }

        public IProduct FindByLabel(string label)
        {
            IProduct wantedProduct = this.products
                .FirstOrDefault(x => x.Label == label);
            if (wantedProduct == null)
            {
                throw new ArgumentException("There is no such product in stock.");
            }

            return wantedProduct;
        }

        public IProduct FindMostExpensiveProduct()
        {
            decimal maxPrice = this.products
                .Max(x => x.Price);
            IProduct wantedProduct = this.products
                .FirstOrDefault(x => x.Price == maxPrice);
            return wantedProduct;
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            for (int i = 0; i < this.products.Count; i++)
                yield return this.products[i];
        }

        public bool Remove(IProduct product)
        {
            return this.products.Remove(product as Product);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
