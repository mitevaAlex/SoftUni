using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figureType = Console.ReadLine();
            double area = 0.0;

            switch (figureType)
            {
                case "square":
                    
                        double a = double.Parse(Console.ReadLine());
                        area = a * a;
                        break;
                    
                case "rectangle":
                    
                        double a = double.Parse(Console.ReadLine());
                        double b = double.Parse(Console.ReadLine());
                        area = a * b;
                        break;
                    
                case "circle":
                    
                        double radius = double.Parse(Console.ReadLine());
                        area = Math.PI * Math.Pow(radius, 2);
                        break;
                    
                case "triangle":
                    
                        double side = double.Parse(Console.ReadLine());
                        double height = double.Parse(Console.ReadLine());
                        area = side * height / 2;
                        break;
                    
                    
            }
            Console.WriteLine($"{area:F3}");
        }
    }
}
