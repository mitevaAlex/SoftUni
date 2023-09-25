namespace INStock.Tests
{
    using INStock.Models;
    using NUnit.Framework;

    public class ProductTests
    {
        private Product product;

        [SetUp]
        public void Initialization()
        {
            product = new Product("Tomato soup", 3.50M, 10);
        }

        [Test]
        public void Ctor_SetsValuesToAllProperties()
        {
            bool labelIsSet = product.Label == "Tomato soup";
            bool priceIsSet = product.Price == 3.50M;
            bool quantityIsSet = product.Quantity == 10;

            Assert.That(labelIsSet && priceIsSet && quantityIsSet);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public void Label_ThrowsExceptionWhenValueIsNullOrWhiteSpace(string label)
        {
            Assert.That(() => new Product(label, 5.50M, 15),
                Throws.ArgumentException.With.Message.EqualTo("The product label cannot be empty."));
        }

        [Test]
        public void Price_SetsNewValue()
        {
            product.Price = 5.50M;

            Assert.That(product.Price, Is.EqualTo(5.50M));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Price_ThrowsExceptionWhenValueIsLessThanOrEqualToZero(decimal price)
        {
            Assert.That(() => product.Price = price,
                Throws.ArgumentException.With.Message.EqualTo("The product price cannot be less than or equal to zero."));
        }

        [Test]
        public void Quantity_SetsNewValue()
        {
            product.Quantity = 5;

            Assert.That(product.Quantity, Is.EqualTo(5));
        }

        [Test]
        public void Quantity_ThrowsExceptionWhenValueIsLessThanZero()
        {
            Assert.That(() => product.Quantity = -1,
                Throws.ArgumentException.With.Message.EqualTo("The product quantity cannot be a negative number."));
        }

        [Test]
        public void CompareTo_ComparesProductLabels()
        { 
            Assert.That(() => product.CompareTo(new Product("Tomato soup", 2.50M, 7)), 
                Is.EqualTo(0));
        }
    }
}