using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int startHours = int.Parse(Console.ReadLine());
            int startMinutes = int.Parse(Console.ReadLine());

            int totalMinutes = startHours * 60 + startMinutes + 15;
            int endHours = totalMinutes / 60;
            int endMinutes = totalMinutes % 60;

            if (endHours >= 24)
            {
                endHours -= 24;
            }

            if (endMinutes < 10)
            {
                Console.WriteLine($"{endHours}:0{endMinutes}");
            }
            else
            {
                Console.WriteLine($"{endHours}:{endMinutes}");
            }
        }
    }
}
