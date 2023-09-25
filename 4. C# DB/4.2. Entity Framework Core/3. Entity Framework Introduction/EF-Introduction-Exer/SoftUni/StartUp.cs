using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            //string employeesInfo = GetEmployeesFullInformation(context);
            //Console.WriteLine(employeesInfo);

            //string employeesOver50000 = GetEmployeesWithSalaryOver50000(context);
            //Console.WriteLine(employeesOver50000);

            //string employeesResearchAndDevelopment = GetEmployeesFromResearchAndDevelopment(context);
            //Console.WriteLine(employeesResearchAndDevelopment);

            //string addresses = AddNewAddressToEmployee(context);
            //Console.WriteLine(addresses);

            //string employeesProjects = GetEmployeesInPeriod(context);
            //Console.WriteLine(employeesProjects);

            //string addresses = GetAddressesByTown(context);
            //Console.WriteLine(addresses);

            //string employee147 = GetEmployee147(context);
            //Console.WriteLine(employee147);

            //string departmentsOver5Employees = GetDepartmentsWithMoreThan5Employees(context);
            //Console.WriteLine(departmentsOver5Employees);

            //string latestProjects = GetLatestProjects(context);
            //Console.WriteLine(latestProjects);

            //string employeesPromoted = IncreaseSalaries(context);
            //Console.WriteLine(employeesPromoted);

            //string projects = DeleteProjectById(context);
            //Console.WriteLine(projects);

            string deleteSeattle = RemoveTown(context);
            Console.WriteLine(deleteSeattle);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .OrderBy(x => x.EmployeeId)
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    MiddleName = x.MiddleName,
                    JobTitle = x.JobTitle,
                    Salary = x.Salary
                });

            StringBuilder result = new StringBuilder();
            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return result.ToString();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.Salary > 50000)
                .OrderBy(x => x.FirstName)
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    Salary = x.Salary
                });

            StringBuilder result = new StringBuilder();
            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return result.ToString();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DepartmentName = x.Department.Name,
                    Salary = x.Salary
                });

            StringBuilder result = new StringBuilder();
            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
            }

            return result.ToString();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address()
            {
                TownId = 4,
                AddressText = "Vitoshka 15"
            };

            Employee Nakov = context.Employees
                .First(x => x.LastName == "Nakov");
            Nakov.Address = address;
            context.SaveChanges();

            string[] addresses = context.Employees
            .OrderByDescending(x => x.AddressId)
            .Take(10)
            .Select(x => x.Address.AddressText)
            .ToArray();

            return string.Join(Environment.NewLine, addresses);
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employeesProjects = context.Employees
                .Where(x => x.EmployeesProjects.Any(x => x.Project.StartDate.Year >= 2001 && x.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    EmpFirstName = x.FirstName,
                    EmpLastName = x.LastName,
                    MangFirstName = x.Manager.FirstName,
                    MangLastName = x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(y => new
                    {
                        Name = y.Project.Name,
                        StartDate = y.Project.StartDate,
                        EndDate = y.Project.EndDate
                    })
                })
                .Take(10);

            StringBuilder result = new StringBuilder();
            foreach (var employeeProjects in employeesProjects)
            {
                result.AppendLine($"{employeeProjects.EmpFirstName} {employeeProjects.EmpLastName} - Manager: {employeeProjects.MangFirstName} {employeeProjects.MangLastName}");
                foreach (var project in employeeProjects.Projects)
                {
                    if (project.EndDate == null)
                    {
                        result.AppendLine($"--{project.Name} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt")} - not finished");
                    }
                    else
                    {
                        result.AppendLine($"--{project.Name} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt")} - {project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt")}");
                    }
                }
            }

            return result.ToString();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Select(x => new
                {
                    AddressText = x.AddressText,
                    TownName = context.Towns.First(y => y.TownId == x.TownId).Name,
                    EmployeesCount = context.Employees.Where(y => y.AddressId == x.AddressId).Count()
                })
                .OrderByDescending(x => x.EmployeesCount)
                .ThenBy(x => x.TownName)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .ToArray();

            StringBuilder result = new StringBuilder();
            foreach (var addr in addresses)
            {
                result.AppendLine($"{addr.AddressText}, {addr.TownName} - {addr.EmployeesCount} employees");
            }

            return result.ToString();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            Employee employee147 = context.Employees.Find(147);
            var projectNames = context.EmployeesProjects
                .Where(x => x.EmployeeId == employee147.EmployeeId)
                .Select(x => x.Project.Name)
                .OrderBy(x => x);

            StringBuilder result = new StringBuilder();
            result.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var projectName in projectNames)
            {
                result.AppendLine($"{projectName}");
            }

            return result.ToString();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(x => x.Employees.Count > 5)
                .OrderBy(x => x.Employees.Count)
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    DepartmentName = x.Name,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Employees = x.Employees.Select(y => new
                    {
                        EmployeeFirstName = y.FirstName,
                        EmployeeLastName = y.LastName,
                        JobTitle = y.JobTitle
                    })
                });

            StringBuilder result = new StringBuilder();
            foreach (var department in departments)
            {
                result.AppendLine($"{department.DepartmentName} - {department.ManagerFirstName} {department.ManagerLastName}");
                foreach (var employee in department.Employees.OrderBy(y => y.EmployeeFirstName).ThenBy(y => y.EmployeeLastName))
                {
                    result.AppendLine($"{employee.EmployeeFirstName} {employee.EmployeeLastName} - {employee.JobTitle}");
                }
            }

            return result.ToString();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var latestProjects = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .Select(x => new
                {
                    Name = x.Name,
                    Description = x.Description,
                    StartDate = x.StartDate
                })
                .OrderBy(x => x.Name);

            StringBuilder result = new StringBuilder();
            foreach (var project in latestProjects)
            {
                result.AppendLine(project.Name);
                result.AppendLine(project.Description);
                result.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return result.ToString();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.Department.Name.Equals("Engineering") || x.Department.Name.Equals("Tool Design")
                            || x.Department.Name.Equals("Marketing") || x.Department.Name.Equals("Information Services"))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToArray();

            for (int i = 0; i < employees.Count(); i++)
            {
                employees[i].Salary *= 1.12M;
            }
            context.SaveChanges();

            StringBuilder result = new StringBuilder();
            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            return result.ToString();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.FirstName.StartsWith("Sa"))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName);

            StringBuilder result = new StringBuilder();
            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return result.ToString();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects.Find(2);
            var employeesProjects = context.EmployeesProjects
                .Where(x => x.ProjectId == project.ProjectId);

            context.EmployeesProjects.RemoveRange(employeesProjects);
            context.Projects.Remove(project);

            context.SaveChanges();

            var projects = context.Projects.Take(10);

            StringBuilder result = new StringBuilder();
            foreach (var proj in projects)
            {
                result.AppendLine(proj.Name);
            }

            return result.ToString();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var townToRemove = context.Towns
                .FirstOrDefault(x => x.Name == "Seattle");
            var addressesToRemove = context.Addresses
                .Where(x => x.Town.Name == "Seattle");
            int removedAddresses = addressesToRemove.Count();

            var employeesToNull = context.Employees
                .Where(x => x.Address.Town.Name == "Seattle")
                .ToArray();

            for (int i = 0; i < employeesToNull.Length; i++)
            {
                employeesToNull[i].AddressId = null;
            }

            context.Addresses.RemoveRange(addressesToRemove);
            context.Towns.RemoveRange(townToRemove);

            context.SaveChanges();

            return $"{removedAddresses} addresses in Seattle were deleted";
        }
    }
}
