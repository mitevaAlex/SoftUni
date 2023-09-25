using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Decoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int clientsCount = int.Parse(Console.ReadLine());
            string typeItem = string.Empty;
            double averageBillPerClient = 0.0;

            for (int currentClient = 1; currentClient <= clientsCount; currentClient++)
            {
                double currentClientBill = 0.0;
                int itemsCount = 0;
                while ((typeItem = Console.ReadLine()) != "Finish")
                {
                    if (typeItem == "basket")
                    {
                        currentClientBill += 1.5;
                        itemsCount++;
                    }
                    else if (typeItem == "wreath")
                    {
                        currentClientBill += 3.8;
                        itemsCount++;
                    }
                    else if (typeItem == "chocolate bunny")
                    {
                        currentClientBill += 7;
                        itemsCount++;
                    }
                }
                if (itemsCount % 2 == 0)
                {
                    currentClientBill *= 0.8;
                }
                Console.WriteLine($"You purchased {itemsCount} items for {currentClientBill:F2} leva.");
                averageBillPerClient += currentClientBill;
            }
            averageBillPerClient /= clientsCount;
            Console.WriteLine($"Average bill per client is: {averageBillPerClient:F2} leva.");
        }
    }
}
