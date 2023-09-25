using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public void Browse(string website)
        {
            if (website.Any(x => char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid URL!");
            }

            Console.WriteLine($"Browsing: {website}!"); 
        }

        public void Call(string number)
        {
            if (!number.All(x => char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid number!");
            }

            Console.WriteLine($"Calling... {number}");
        }
    }
}
