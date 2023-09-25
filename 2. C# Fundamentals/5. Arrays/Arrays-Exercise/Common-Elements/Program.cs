using System;
using System.Linq;

namespace Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split(' ');//words or syllables or any kind of elements
            string[] secondInput = Console.ReadLine().Split(' ');//words or syllables or any kind of elements

            for (int i = 0; i < secondInput.Length; i++)
            {
                string secondArrElement = secondInput[i];

                if (firstInput.Contains(secondArrElement))
                {
                    Console.Write(secondArrElement + " ");
                }
            }
        }
    }
}
