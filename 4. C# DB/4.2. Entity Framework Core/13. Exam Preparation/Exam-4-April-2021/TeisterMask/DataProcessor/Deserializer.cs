namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportProjectDto[]), new XmlRootAttribute("Projects"));
            ImportProjectDto[] projectsDto = (ImportProjectDto[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            foreach (ImportProjectDto projectDto in projectsDto)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool IsProjOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate,
                    "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime projOpenDate);
                if (!IsProjOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? projDueDate = null;
                if (!string.IsNullOrEmpty(projectDto.DueDate))
                {
                    bool IsProjDueDateValid = DateTime.TryParseExact(projectDto.DueDate,
                    "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime dueDateValue);

                    if (!IsProjDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    projDueDate = dueDateValue;
                }

                List<ImportTaskDto> validTasksDto = new List<ImportTaskDto>();
                foreach (ImportTaskDto taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool IsTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate,
                    "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime taskOpenDate);
                    if (!IsTaskOpenDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool IsTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate,
                    "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime taskDueDate);
                    if (!IsTaskDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < projOpenDate || taskDueDate > projDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    validTasksDto.Add(taskDto);
                }

                projectDto.Tasks = validTasksDto;
                Project project = StartUp.mapper.Map<Project>(projectDto);
                context.Projects.Add(project);
                context.SaveChanges();
                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            return sb.ToString().Trim();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            IEnumerable<ImportEmployeeDto> employees = JsonConvert.DeserializeObject<IEnumerable<ImportEmployeeDto>>(jsonString);

            StringBuilder sb = new StringBuilder();
            foreach (ImportEmployeeDto employeeDTO in employees)
            {
                if (!IsValid(employeeDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee employee = new Employee
                {
                    Username = employeeDTO.Username,
                    Email = employeeDTO.Email,
                    Phone = employeeDTO.Phone
                };

                context.Employees.Add(employee);
                context.SaveChanges();

                foreach (int taskId in employeeDTO.Tasks)
                {
                    if (context.Tasks.FirstOrDefault(t => t.Id == taskId) == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    EmployeeTask employeeTask = new EmployeeTask
                    {
                        EmployeeId = employee.Id,
                        TaskId = taskId
                    };

                    if (employee.EmployeesTasks.FirstOrDefault(t => t.TaskId == taskId) == null)
                    {
                        context.EmployeesTasks.Add(employeeTask);
                    }
                }

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            context.SaveChanges();
            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}