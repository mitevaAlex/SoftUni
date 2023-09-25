using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        try
        {
            var selectedCoins = ChooseCoins(availableCoins.OrderByDescending(x => x).ToArray(), targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        Dictionary<int, int> coinsCounts = new Dictionary<int, int>();
        foreach (int coin in coins)
        {
            if (targetSum == 0)
            {
                break;
            }
            int currentCount = targetSum / coin;
            coinsCounts.Add(coin, currentCount);
            targetSum -= currentCount * coin;
        }

        if (targetSum > 0)
        {
            throw new Exception("Error");
        }

        coinsCounts = coinsCounts.Where(x => x.Value != 0)
            .ToDictionary(x => x.Key, x => x.Value);
        return coinsCounts;
    }
}