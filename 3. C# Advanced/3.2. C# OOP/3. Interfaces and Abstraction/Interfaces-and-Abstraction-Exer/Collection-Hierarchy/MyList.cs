using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collection_Hierarchy
{
    public class MyList : AddRemoveCollection, IAddRemoveList
    {
        public override string Remove()
        {
            string item = this.Items.First();
            this.Items.RemoveAt(0);
            return item;
        }

        public int Used => this.Items.Count;
    }
}
