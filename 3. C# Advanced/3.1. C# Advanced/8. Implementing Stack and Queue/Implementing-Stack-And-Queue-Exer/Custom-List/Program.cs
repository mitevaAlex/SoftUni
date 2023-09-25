using System;

namespace Custom_List
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();
            list.Add(1);
            list.Add(2);
            Console.WriteLine(list);
            list.Insert(2, 10);
            Console.WriteLine(list[2]);
            Console.WriteLine(list);
            Console.WriteLine(list.Contains(18));
            list.Swap(0, 1);
            Console.WriteLine(list);
        }
    }
}
