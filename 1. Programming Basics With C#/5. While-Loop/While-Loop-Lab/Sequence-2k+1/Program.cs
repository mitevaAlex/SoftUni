using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence_2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int i = 1;

            while (i <= num)
            {
                Console.WriteLine(i);
                i = i * 2 + 1;
            }
        }
    }
}
