namespace INStock.Tests
{
    using INStock.Contracts;
    using INStock.Models;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Reflection;

    public class ProductStockTests
    {
        private ProductStock productStock;
        private IProduct product;

        [SetUp]
        public void Initialization()
        {
            productStock = new ProductStock();
            product = new Product("Tomato soup", 3.50M, 10);
            productStock.Add(product);
        }

        [Test]
        public void Ctor_InitializesProductList()
        {
            Assert.That(typeof(ProductStock)
                .GetField("products", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(productStock),
                Is.EqualTo(new List<Product>(new Product[] { product as Product })));
        }

        [Test]
        public void Get_Indexer_ReturnsProductAtGivenIndex()
        {
            Assert.That(productStock[0], Is.EqualTo(product));
        }

        [Test]
        public void Set_Indexer_SetsNewValue()
        {
            Product newProduct = new Product("Chicken soup", 4.50M, 3);
            productStock[0] = newProduct;

            Assert.That(productStock[0], Is.EqualTo(newProduct));
        }

        [Test]
        public void Count_ReturnsTheCountOfProductsInStock()
        {
            Assert.That(productStock.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_AddsNewProduct()
        {
            Assert.That(productStock.Contains(product), Is.EqualTo(true));
        }

        [Test]
        public void Add_ThrowsExceptionWhenProductIsAlreadyInStock()
        {
            Assert.That(() => productStock.Add(product),
                Throws.InvalidOperationException.With.Message.EqualTo("This product is already in stock."));
        }

        [Test]
        public void Contains_ReturnsCorrectBoolValue()
        {
            Assert.That(productStock.Contains(product), Is.EqualTo(true));
        }

        [Test]
        public void Find_FindsWantedProduct()
        {
            Assert.That(productStock.Find(0), Is.EqualTo(product));
        }

        [Test]
        public void Find_ThrowsExceptionWhenProductIsAlreadyInStock()
        {
            Assert.That(() => productStock.Find(1),
                Throws.Exception.With.Message.EqualTo("Inavlid index"));
        }

        [Test]
        public void FindAllByPrice_FindsWantedProducts()
        {
            Assert.That(productStock.FindAllByPrice(3.50M), 
                Is.EqualTo(new List<IProduct>(new IProduct[] { product })));
        }

        [Test]
        public void FindAllByPrice_ReturnsEmptyCollectionIfNoProductsFound()
        {
            Assert.That(productStock.FindAllByPrice(1M),
                Is.EqualTo(new List<IProduct>()));
        }

        [Test]
        public void FindAllByQuantity_FindsWantedProducts()
        {
            Assert.That(productStock.FindAllByQuantity(10),
                Is.EqualTo(new List<IProduct>(new IProduct[] { product })));
        }

        [Test]
        public void FindAllByQuantity_ReturnsEmptyCollectionIfNoProductsFound()
        {
            Assert.That(productStock.FindAllByPrice(1),
                Is.EqualTo(new List<IProduct>()));
        }

        [Test]
        public void FindAllInPriceRange_FindsWantedProducts()
        {
            Product product1 = new Product("Chicken", 10M, 15);
            productStock.Add(product1);
            Product product2 = new Product("Peach", 0.50M, 50);
            productStock.Add(product2);

            Assert.That(productStock.FindAllInPriceRange(0.50M, 3.50M),
                Is.EqualTo(new List<IProduct>(new IProduct[] { product, product2 })));
        }

        [Test]
        public void FindAllInPriceRange_ReturnsEmptyCollectionIfNoProductsFound()
        {
            Assert.That(productStock.FindAllInPriceRange(1M, 2M),
                Is.EqualTo(new List<IProduct>()));
        }

        [Test]
        public void FindByLabel_FindsWantedProduct()
        {
            Assert.That(productStock.FindByLabel("Tomato soup"), Is.EqualTo(product));
        }

        [Test]
        public void FindByLabel_ThrowsExceptionWhenProductIsAlreadyInStock()
        {
            Assert.That(() => productStock.FindByLabel("Chicken"),
                Throws.ArgumentException.With.Message.EqualTo("There is no such product in stock."));
        }

        [Test]
        public void FindMostExpensiveProduct_FindsWantedProduct()
        {
            Product product1 = new Product("Chicken", 10M, 15);
            productStock.Add(product1);
            Product product2 = new Product("Peach", 0.50M, 50);
            productStock.Add(product2);

            Assert.That(productStock.FindMostExpensiveProduct(),
                Is.EqualTo(product1));
        }

        [Test]
        public void GetEnumerator_AllowsForechOverProductStock()
        {
            foreach (Product product in productStock)
            {
                product.Price++;
            }

            Assert.That(product.Price, Is.EqualTo(4.50M));
        }

        [Test]
        public void Remove_RemovesGivenProduct()
        {
            Assert.That(productStock.Remove(product),
                Is.EqualTo(true));
        }
    }
}
