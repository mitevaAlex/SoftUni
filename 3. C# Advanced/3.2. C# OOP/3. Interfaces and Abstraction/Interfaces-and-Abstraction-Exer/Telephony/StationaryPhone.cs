using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public void Call(string number)
        {
            if (!number.All(x => char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid number!");
            }

            Console.WriteLine($"Dialing... {number}");
        }
    }
}
