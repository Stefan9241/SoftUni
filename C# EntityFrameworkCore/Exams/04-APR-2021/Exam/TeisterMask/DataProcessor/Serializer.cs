namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .Where(x => x.Tasks.Count > 0)
                .ToArray()
                .Select(x => new ExportProjectWithTasks
                {
                    ProjectName = x.Name,
                    TaskCount = x.Tasks.Count,
                    HasEndDate = x.DueDate.HasValue ? "Yes" : "No",
                    Tasks = x.Tasks.ToArray().Select(t => new ProjectTasks
                    {
                        Label = t.LabelType.ToString(),
                        Name = t.Name
                    })
                    .OrderBy(x => x.Name)
                    .ToArray()
                })
                .OrderByDescending(x => x.TaskCount)
                .ThenBy(x => x.ProjectName)
                .ToArray();

            var xml = XmlConverter.Serialize(projects, "Projects");
            return xml;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var tasks = context.Employees
                .Where(x => x.EmployeesTasks
                .Any(x => x.Task.OpenDate >= date))
                .ToArray()
                .Select(x => new
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks
                    .Where(x=> x.Task.OpenDate >= date)
                    .ToArray()
                    .OrderByDescending(ot => ot.Task.DueDate)
                    .ThenBy(ot => ot.Task.Name)
                    .Select(t => new
                    {
                        TaskName = t.Task.Name,
                        OpenDate = t.Task.OpenDate.ToString("d",CultureInfo.InvariantCulture),
                        DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = t.Task.LabelType.ToString(),
                        ExecutionType = t.Task.ExecutionType.ToString(),
                    })
                    .ToArray()
                })
                .OrderByDescending(at => at.Tasks.Length)
                .ThenBy(u => u.Username)
                .Take(10)
                .ToArray();

            var json = JsonConvert.SerializeObject(tasks,Formatting.Indented);
            return json;
        }
    }
}