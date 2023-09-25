using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_Exception
{
    public class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException()
            : base("The name cannot contain any special characters or numeric values.")
        {
        }
    }
}
