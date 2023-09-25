using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@">>(?<name>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)");
            double totalPrice = 0.0;
            List<string> furnitureNames = new List<string>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match currentPieceOfFurniture = regex.Match(input);
                if (currentPieceOfFurniture.Success)
                {
                    furnitureNames.Add(currentPieceOfFurniture.Groups["name"].Value);
                    totalPrice += double.Parse(currentPieceOfFurniture.Groups["price"].Value) * double.Parse(currentPieceOfFurniture.Groups["quantity"].Value);
                }
            }
            Console.WriteLine($"Bought furniture:{Environment.NewLine}" +
                $"{string.Join("", furnitureNames.Select(x => x + Environment.NewLine))}" +
                $"Total money spend: {totalPrice:F2}");
        }
    }
}
