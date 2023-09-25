using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDayOfWeek = int.Parse(Console.ReadLine());
            string dayOfWeek = "Error";
            switch (numberOfDayOfWeek)
            {
                case 1:
                    
                        dayOfWeek = "Monday";
                        break;
                    
                case 2:
                    
                        dayOfWeek = "Tuesday";
                        break;
                    
                case 3:
                    
                        dayOfWeek = "Wednesday";
                        break;
                    
                case 4:
                    
                        dayOfWeek = "Thursday";
                        break;
                    
                case 5:
                   
                        dayOfWeek = "Friday";
                        break;
                    
                case 6:
                    
                        dayOfWeek = "Saturday";
                        break;
                    
                case 7:
                    
                        dayOfWeek = "Sunday";
                        break;
                    

            }
            Console.WriteLine(dayOfWeek);
        }
    }
}
