using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookName = Console.ReadLine();
            int libraryCapacity = int.Parse(Console.ReadLine());

            bool bookFound = false;
            int booksRead = 0;

            while (booksRead < libraryCapacity)
            {
                string currentBook = Console.ReadLine();

                if (bookName == currentBook)
                {
                    bookFound = true;
                    break;
                }
                booksRead++;
            }

            if (bookFound)
            {
                Console.WriteLine($"You checked {booksRead} books and found it.");
            }
            else
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {booksRead} books.");
            }
        }
    }
}
