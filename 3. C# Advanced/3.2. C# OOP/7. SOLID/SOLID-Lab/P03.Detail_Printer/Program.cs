using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<IWorker> workers = new List<IWorker>()
            {
                new Manager("Alex", new string[] { "CV", "Birth Certificate", "Personal ID Card"}),
                new Employee("John"),
                new Employee("Eva"),
                new Manager("Teodora", new List<string> { "Library Card", "Fitness Card", "CV"})
            };

            DetailsPrinter printer = new DetailsPrinter(workers);
            Console.WriteLine(printer.PrintDetails());
        }
    }
}
