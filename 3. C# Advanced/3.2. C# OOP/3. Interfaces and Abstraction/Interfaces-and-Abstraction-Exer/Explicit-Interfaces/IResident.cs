using System;
using System.Collections.Generic;
using System.Text;

namespace Explicit_Interfaces
{
    interface IResident
    {
        string Country { get; }

        string GetName();
    }
}
