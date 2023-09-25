using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers_1_To_N_with_Step_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int lastNum = int.Parse(Console.ReadLine());
            for (int i = 1; i <= lastNum; i += 3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
