using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class CustomTuple<T, V>
    {
        public CustomTuple(T item1, V item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public T item1 { get; set; }

        public V item2 { get; set; }
        
        public override string ToString()
        {
            return $"{this.item1} -> {this.item2}";
        }
    }
}
