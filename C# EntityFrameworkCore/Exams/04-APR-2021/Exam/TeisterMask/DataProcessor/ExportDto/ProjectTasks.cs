using System.Xml.Serialization;

[XmlType("Task")]
public class ProjectTasks
{
    public string Name { get; set; }
    public string Label { get; set; }
}