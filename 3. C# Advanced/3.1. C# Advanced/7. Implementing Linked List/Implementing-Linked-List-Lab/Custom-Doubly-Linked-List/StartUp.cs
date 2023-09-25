using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> list1 = new DoublyLinkedList<int>(new int[] { 1, 2, 3, 4 });
            DoublyLinkedList<int> list2 = new DoublyLinkedList<int>(23);
            DoublyLinkedList<int> list3 = new DoublyLinkedList<int>();
            
            foreach (var item in list1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(list1);
            list1.ForEach(Console.WriteLine);
            list1.ForEach(x => Console.WriteLine($"{x}: {x} + {x * 2} = {x + x * 2}"));
        }
    }
}
