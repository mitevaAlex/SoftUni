using System;
using System.Collections.Generic;
using System.Linq;

namespace Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> companies = new SortedDictionary<string, List<string>>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                //"{companyName} -> {employeeId}"
                string[] companyData = command
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string companyName = companyData[0];
                if (!companies.ContainsKey(companyName))
                {
                    companies.Add(companyName, new List<string>());
                }
                string employeeID = companyData[1];
                if (!companies[companyName].Contains(employeeID))
                {
                    companies[companyName].Add(employeeID);
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine,
                companies.Select(x => $"{x.Key}{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, x.Value.Select(y => $"-- {y}"))}")));
        }
    }
}
