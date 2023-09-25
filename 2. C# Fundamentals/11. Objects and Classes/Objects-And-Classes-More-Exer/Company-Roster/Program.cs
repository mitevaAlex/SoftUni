using System;
using System.Collections.Generic;
using System.Linq;

namespace Company_Roster
{
    class Program
    {
        static void Main(string[] args)
        {
            int employeesCount = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();
            List<string> departments = new List<string>();
            for (int i = 0; i < employeesCount; i++)
            {
                //"{name} {salary} {department}"
                string[] employeeData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string department = employeeData[2];
                if (!departments.Contains(department))
                {
                    departments.Add(department);
                }
                Employee employee = new Employee(employeeData[0], 
                    double.Parse(employeeData[1]), department);
                employees.Add(employee);
            }
            double highestAverageSalary = double.MinValue;
            string highestSalaryDepartment = string.Empty; 
            for (int i = 0; i < departments.Count; i++)
            {
                string currentDepartment = departments[i];
                double currentAverageSalary = 0.0;
                Employee[] currentEmployees = employees
                    .Where(x => x.Department == currentDepartment)
                    .ToArray();
                for (int j = 0; j < currentEmployees.Length; j++)
                {
                    currentAverageSalary += currentEmployees[j].Salary;
                }
                currentAverageSalary /= currentEmployees.Length;
                if (currentAverageSalary > highestAverageSalary)
                {
                    highestAverageSalary = currentAverageSalary;
                    highestSalaryDepartment = currentDepartment;
                }
            }

            Console.WriteLine($"Highest Average Salary: {highestSalaryDepartment}");
            List<Employee> wealthyEmployees = employees
                .Where(x => x.Department == highestSalaryDepartment)
                .OrderByDescending(x => x.Salary)
                .ToList();
            wealthyEmployees.ForEach(x => Console.WriteLine(x));
        }
    }
}
