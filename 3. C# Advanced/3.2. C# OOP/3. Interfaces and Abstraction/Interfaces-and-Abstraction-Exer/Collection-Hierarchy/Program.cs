using System;
using System.Collections.Generic;
using System.Linq;

namespace Collection_Hierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

           string[] items = Console.ReadLine()
                .Split(' ');
            Console.WriteLine(string.Join(' ', AddItems(items, addCollection)));
            Console.WriteLine(string.Join(' ',AddItems(items, addRemoveCollection)));
            Console.WriteLine(string.Join(' ', AddItems(items, myList)));

            int removeCount = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Join(' ', RemoveItems(removeCount, addRemoveCollection)));
            Console.WriteLine(string.Join(' ', RemoveItems(removeCount, myList)));
        }

        static List<int> AddItems(string[] items, IAddList collection)
        {
            List<int> addIndexes = new List<int>();
            foreach (string item in items)
            {
                addIndexes.Add(collection.Add(item));
            }

            return addIndexes;
        }

        static List<string> RemoveItems(int count, IAddRemoveList collection)
        {
            List<string> removedItems = new List<string>();
            for (int i = 0; i < count; i++)
            {
                removedItems.Add(collection.Remove());
            }

            return removedItems;
        }
    }
}
