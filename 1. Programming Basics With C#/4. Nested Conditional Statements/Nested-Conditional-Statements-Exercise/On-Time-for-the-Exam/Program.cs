using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());

            string status = string.Empty;
            int timeEarlyOrLate = 0;

            if (examHour < arrivalHour)
            {
                status = "Late";
                timeEarlyOrLate = 60 * (arrivalHour - examHour) + arrivalMinutes - examMinutes;
            }
            else if (examHour >= arrivalHour)
            {
                if (examHour == arrivalHour)
                {
                    if (arrivalMinutes - examMinutes <= 0)
                    {
                        status = "On Time";
                        timeEarlyOrLate = examMinutes - arrivalMinutes;
                    }
                    else
                    {
                        status = "Late";
                        timeEarlyOrLate = arrivalMinutes - examMinutes;
                    }
                }
                else if (examHour > arrivalHour)
                {
                    if (60 - arrivalMinutes + examMinutes <= 30)
                    {
                        status = "On Time";
                        timeEarlyOrLate = 60 - arrivalMinutes + examMinutes;
                    }
                    else
                    {
                        status = "Early";
                        timeEarlyOrLate = 60 * (examHour - arrivalHour) + examMinutes - arrivalMinutes;
                    }
                }
            }
            Console.WriteLine(status);

            int hoursEarlyOrLate = timeEarlyOrLate / 60;
            int minutesEarlyOrLate = timeEarlyOrLate % 60;

            if (status == "Late")
            {
                if (hoursEarlyOrLate == 0)
                {
                    Console.WriteLine($"{minutesEarlyOrLate} minutes after the start");
                }
                else
                {
                    if (minutesEarlyOrLate < 10)
                    {
                        Console.WriteLine($"{hoursEarlyOrLate}:0{minutesEarlyOrLate} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hoursEarlyOrLate}:{minutesEarlyOrLate} hours after the start");
                    }
                }
            }
            else if (status == "On Time")
            {
                if (minutesEarlyOrLate > 0)
                {
                    Console.WriteLine($"{minutesEarlyOrLate} minutes before the start");
                }  
            }
            else if (status == "Early")
            {
                if (hoursEarlyOrLate == 0)
                {
                    Console.WriteLine($"{minutesEarlyOrLate} minutes before the start");
                }
                else
                {
                    if (minutesEarlyOrLate < 10)
                    {
                        Console.WriteLine($"{hoursEarlyOrLate}:0{minutesEarlyOrLate} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hoursEarlyOrLate}:{minutesEarlyOrLate} hours before the start");
                    }
                }
            }
        }
    }
}
