using System;

namespace String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            // e.g. : "abv>1>1>2>2asdasd"
            string[] bombs = Console.ReadLine().Split('>');
            string finalText = bombs[0];
            int powerLeft = 0;
            for (int i = 1; i < bombs.Length; i++)
            {
                finalText += ">";
                int bombPower = int.Parse(bombs[i][0].ToString()) + powerLeft;
                if (bombPower > bombs[i].Length)
                {
                    powerLeft = bombPower - bombs[i].Length;
                }
                else
                {
                    finalText += bombs[i].Substring(bombPower);
                }
            }
            Console.WriteLine(finalText);
        }
    }
}
