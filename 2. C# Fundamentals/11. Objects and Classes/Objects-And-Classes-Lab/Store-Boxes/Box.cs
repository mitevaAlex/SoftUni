using System;
using System.Collections.Generic;
using System.Text;

namespace Store_Boxes
{
    class Box
    {
        public int SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public double PricePerBox { get; set; }

        public Box(int serialNumber, Item item, int itemQuantity, double pricePerBox)
        {
            this.SerialNumber = serialNumber;
            this.Item = item;
            this.ItemQuantity = itemQuantity;
            this.PricePerBox = pricePerBox;
        }

        public override string ToString()
        {
            return $"{this.SerialNumber}{Environment.NewLine}" +
            $"-- {this.Item.Name} - ${this.Item.Price:F2}: {this.ItemQuantity}{Environment.NewLine}" +
            $"-- ${this.PricePerBox:F2}";
        }
    }
}
