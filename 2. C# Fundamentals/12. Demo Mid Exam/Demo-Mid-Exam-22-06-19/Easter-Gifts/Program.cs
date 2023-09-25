using System;
using System.Collections.Generic;

namespace Easter_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] gifts = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "No Money")
            {
                string[] splitedCommand = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string operation = splitedCommand[0];
                string gift = splitedCommand[1];
                switch (operation)
                {
                    case "OutOfStock":
                        for (int i = 0; i < gifts.Length; i++)
                        {
                            if (gifts[i] == gift)
                            {
                                gifts[i] = "None";
                            }
                        }
                        break;
                    case "Required":
                        int index = int.Parse(splitedCommand[2]);
                        if (index < gifts.Length && index >= 0)
                        {
                            gifts[index] = gift;
                        }
                        break;
                    case "JustInCase":
                        gifts[gifts.Length - 1] = gift;
                        break;
                }
            }
            List<string> giftsToPrint = new List<string>();
            foreach (string gift in gifts)
            {
                if (gift != "None")
                {
                    giftsToPrint.Add(gift);
                }
            }
            Console.WriteLine(string.Join(' ', giftsToPrint));
        }
    }
}
