using System;

namespace Custom_Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomStack stack = new CustomStack();
            stack.Push(55);
            stack.Push(66);
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            stack.Push(100);
            stack.Push(200);
            stack.Push(5151);
            stack.ForEach(element => Console.Write(element + " "));
        }
    }
}
