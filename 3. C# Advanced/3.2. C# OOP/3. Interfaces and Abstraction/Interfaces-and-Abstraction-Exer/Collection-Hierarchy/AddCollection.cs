using System;
using System.Collections.Generic;
using System.Text;

namespace Collection_Hierarchy
{
    public class AddCollection : IAddList
    {
        public List<string> Items { get; private set; } = new List<string>();

        public virtual int Add(string item)
        {
            this.Items.Add(item);
            return this.Items.Count - 1;
        }
    }
}
