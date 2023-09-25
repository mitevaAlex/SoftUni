using System;

namespace Party_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int companionsCount = int.Parse(Console.ReadLine());
            int daysCount = int.Parse(Console.ReadLine());
            int coinsCount = 0;
            for (int i = 1; i <= daysCount; i++)
            {
                if (i % 10 == 0)
                {
                    companionsCount -= 2;
                }

                if (i % 15 == 0)
                {
                    companionsCount += 5;
                }

                coinsCount += 50 - companionsCount * 2;
                if (i % 3 == 0)
                {
                    coinsCount -= 3 * companionsCount;
                }

                if (i % 5 == 0)
                {
                    coinsCount += 20 * companionsCount;
                    if (i % 3 == 0)
                    {
                        coinsCount -= companionsCount * 2;
                    }
                }
            }
            int coinsPerPerson = coinsCount / companionsCount;
            Console.WriteLine($"{companionsCount} companions received {coinsPerPerson} coins each.");
        }
    }
}
