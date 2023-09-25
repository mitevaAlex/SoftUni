using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public Stack<string> AddRange(params string[] range)
        {
            foreach (string item in range)
            {
                this.Push(item);
            }

            return this;
        }
    }
}
