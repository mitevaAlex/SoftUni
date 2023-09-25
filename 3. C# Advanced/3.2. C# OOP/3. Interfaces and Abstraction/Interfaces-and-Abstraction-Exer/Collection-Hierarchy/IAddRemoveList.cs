using System;
using System.Collections.Generic;
using System.Text;

namespace Collection_Hierarchy
{
    public interface IAddRemoveList : IAddList
    {
        string Remove();
    }
}
