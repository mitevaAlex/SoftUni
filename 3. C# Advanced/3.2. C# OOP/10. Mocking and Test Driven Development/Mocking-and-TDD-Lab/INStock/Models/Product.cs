namespace INStock.Models
{
    using INStock.Contracts;
    using System;

    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;

        public Product(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
        }

        public string Label
        {
            get { return this.label; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The product label cannot be empty.");
                }

                this.label = value;
            }
        }

        public decimal Price 
        { 
            get { return this.price; } 
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The product price cannot be less than or equal to zero.");
                }

                this.price = value;
            }
        }

        public int Quantity 
        {
            get { return this.quantity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The product quantity cannot be a negative number.");
                }

                this.quantity = value;
            }
        }

        public int CompareTo(IProduct other)
        {
            return this.Label.CompareTo(other.Label);
        }
    }
}
