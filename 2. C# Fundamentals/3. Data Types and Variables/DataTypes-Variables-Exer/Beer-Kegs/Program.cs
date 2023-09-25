using System;

namespace Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int kegsCount = int.Parse(Console.ReadLine());//we are going to read 3*kegsCount lines
            string biggestKegModel = string.Empty;
            double biggestKegVolume = 0.0;
            for (int currentKeg = 1; currentKeg <= kegsCount; currentKeg++)
            {
                string kegModel = Console.ReadLine();               
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double currentKegVolume = Math.PI * Math.Pow(radius, 2) * height;
                if (currentKegVolume > biggestKegVolume)
                {
                    biggestKegVolume = currentKegVolume;
                    biggestKegModel = kegModel;
                }
            }
            Console.WriteLine(biggestKegModel);
        }
    }
}
