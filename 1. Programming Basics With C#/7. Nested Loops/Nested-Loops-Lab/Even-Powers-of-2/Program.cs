using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Even_Powers_of_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int lastPower = int.Parse(Console.ReadLine());
            for (int i = 0; i <= lastPower; i += 2)
            {
                Console.WriteLine(Math.Pow(2,i));
            }
        }
    }
}
