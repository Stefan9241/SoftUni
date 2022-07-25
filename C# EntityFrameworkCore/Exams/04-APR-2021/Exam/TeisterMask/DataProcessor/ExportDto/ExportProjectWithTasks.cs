using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ExportProjectWithTasks
    {
        [XmlAttribute("TasksCount")]
        public int TaskCount { get; set; }

        public string ProjectName { get; set; }

        public string HasEndDate { get; set; }

        [XmlArray("Tasks")]
        public ProjectTasks[] Tasks { get; set; }
    }
}
