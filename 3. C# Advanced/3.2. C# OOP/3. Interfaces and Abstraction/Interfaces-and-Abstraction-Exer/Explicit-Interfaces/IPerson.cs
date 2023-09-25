using System;
using System.Collections.Generic;
using System.Text;

namespace Explicit_Interfaces
{
    interface IPerson
    {
        string Name { get; }

        int Age { get; }

        string GetName();
    }
}
