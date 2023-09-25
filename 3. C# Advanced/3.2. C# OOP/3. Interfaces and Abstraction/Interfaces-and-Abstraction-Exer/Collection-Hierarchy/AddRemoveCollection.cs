using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collection_Hierarchy
{
    public class AddRemoveCollection : AddCollection, IAddRemoveList
    {
        public override int Add(string item)
        {
            this.Items.Insert(0, item);
            return 0;
        }

        public virtual string Remove()
        {
            string item = this.Items.Last();
            this.Items.RemoveAt(this.Items.Count - 1);
            return item;
        }
    }
}
