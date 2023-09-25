using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerCards = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();
            List<int> secondPlayerCards = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();
            int counter = 0;
            while (firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0)
            {
                if (firstPlayerCards[counter] > secondPlayerCards[counter])
                {
                    TakeCards(firstPlayerCards, secondPlayerCards, counter);
                }
                else if (firstPlayerCards[counter] < secondPlayerCards[counter])
                {
                    TakeCards(secondPlayerCards, firstPlayerCards, counter);
                }
                else
                {
                    RemoveCards(firstPlayerCards, secondPlayerCards, counter);
                }
            }

            if (firstPlayerCards.Count > 0 )
            {
                int sum = firstPlayerCards.Sum();
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else
            {
                int sum = secondPlayerCards.Sum();
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
        }

        static void TakeCards(List<int> winnerDeck, List<int> loserDeck, int cardIndex)
        {
            winnerDeck.Add(winnerDeck[cardIndex]);
            winnerDeck.Add(loserDeck[cardIndex]);
            loserDeck.RemoveAt(cardIndex);
            winnerDeck.RemoveAt(cardIndex);
        }

        static void RemoveCards(List<int> firstPlayerDeck, List<int> secondPlayerDeck, int cardIndex)
        {
            firstPlayerDeck.RemoveAt(cardIndex);
            secondPlayerDeck.RemoveAt(cardIndex);
        }
    }
}
