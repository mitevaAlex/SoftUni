using System;
using System.Collections.Generic;
using System.Linq;

namespace Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            string currentBox = string.Empty;
            while ((currentBox = Console.ReadLine()) != "end")
            {
                //"{Serial Number} {Item Name} {Item Quantity} {itemPrice}"
                string[] splittedBoxData = currentBox
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Item item = new Item(splittedBoxData[1], double.Parse(splittedBoxData[3]));
                double pricePerBox = int.Parse(splittedBoxData[2]) * item.Price; //{Item Quantity} * {itemPrice}
                Box box = new Box(int.Parse(splittedBoxData[0]), item,
                    int.Parse(splittedBoxData[2]), pricePerBox);
                boxes.Add(box);
            }
            boxes = boxes
                .OrderByDescending(x => x.PricePerBox)
                .ToList();
            boxes.ForEach(x => Console.WriteLine(x));
        }
    }
}
