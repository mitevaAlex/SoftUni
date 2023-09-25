using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers_N_To_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            for (; firstNum >= 1 ; firstNum--)
            {
                Console.WriteLine(firstNum);
            }
        }
    }
}
