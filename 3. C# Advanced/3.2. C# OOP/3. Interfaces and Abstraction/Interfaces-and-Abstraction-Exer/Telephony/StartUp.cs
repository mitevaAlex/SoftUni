using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            string[] numbers = Console.ReadLine()
                .Split();
            string[] websites = Console.ReadLine()
                .Split();

            foreach (string number in numbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        stationaryPhone.Call(number);
                    }
                    else
                    {
                        smartphone.Call(number);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (string website in websites)
            {
                try
                {
                    smartphone.Browse(website);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
