using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dance_Hall
{
    class Program
    {
        static void Main(string[] args)
        {
            double areaForAPerson = 7000 + 40;

            double hallLength = double.Parse(Console.ReadLine()) * 100;
            double hallWidth = double.Parse(Console.ReadLine()) * 100;
            double sideOfWardobe = double.Parse(Console.ReadLine()) * 100;

            double wardwobeArea = Math.Pow(sideOfWardobe, 2);
            double hallArea = hallLength * hallWidth;
            double bench = hallArea / 10;

            double hallFreeArea = hallArea - wardwobeArea - bench;
            int possiblePeople = (int)Math.Floor(hallFreeArea / areaForAPerson);

            Console.WriteLine(possiblePeople);
        }
    }
}
