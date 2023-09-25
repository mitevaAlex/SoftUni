using System;
using System.Collections.Generic;
using System.Text;

namespace Collection_Hierarchy
{
    public interface IAddList
    {
        List<string> Items { get; }

        int Add(string item);
    }
}
