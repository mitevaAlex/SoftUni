using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public interface IWorker
    {
        string Name { get; }

        string Info { get; }
    }
}
