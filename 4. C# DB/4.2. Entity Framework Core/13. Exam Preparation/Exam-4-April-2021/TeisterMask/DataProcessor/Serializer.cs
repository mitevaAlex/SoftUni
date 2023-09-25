namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            ExportProjectDto[] projects = context.Projects
                .ToArray()
                .Where(x => x.Tasks.Count >= 1)
                .Select(x => new ExportProjectDto
                { 
                    TasksCount = x.Tasks.Count,
                    ProjectName = x.Name,
                    HasEndDate = x.DueDate == null ? "No" : "Yes",
                    Tasks = x.Tasks.Select(y => new ExportTaskDto
                    {
                        Name = y.Name,
                        Label = Enum.GetName(typeof(LabelType), y.LabelType)
                    })
                    .ToList()
                })
                .OrderByDescending(x => x.TasksCount)
                .ThenBy(x => x.ProjectName)
                .ToArray();
            
            projects
                .ToList()
                .ForEach(x => x.Tasks = x.Tasks.OrderBy(y => y.Name).ToList());

            XmlSerializer serializer = new XmlSerializer(typeof(ExportProjectDto[]), new XmlRootAttribute("Projects"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, projects, namespaces);
            }

            return sb.ToString().Trim();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .ToArray()
                .Where(x => x.EmployeesTasks.Count(y => y.Task.OpenDate >= date) >= 1)
                .Select(x => new
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks
                    .Where(y => y.Task.OpenDate >= date)
                    .OrderByDescending(y => y.Task.DueDate)
                    .ThenBy(y => y.Task.Name)
                    .Select(y => new
                    {
                        TaskName = y.Task.Name,
                        OpenDate = y.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = y.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = Enum.GetName(typeof(LabelType), y.Task.LabelType),
                        ExecutionType = Enum.GetName(typeof(ExecutionType), y.Task.ExecutionType)
                    })
                })
                .OrderByDescending(x => x.Tasks.Count())
                .ThenBy(y => y.Username)
                .Take(10);

            string employeesJson = JsonConvert.SerializeObject(employees);
            return employeesJson;
        }
    }
}