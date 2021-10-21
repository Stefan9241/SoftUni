using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.students = new List<Student>();
            Capacity = capacity;
        }
        public int Capacity { get; private set; }
        public int Count => students.Count;


        public string RegisterStudent(Student student)
        {
            if (Count + 1 <= Capacity)
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            var student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (student == null)
            {
                return "Student not found";
            }

            students.Remove(student);
            return $"Dismissed student {firstName} {lastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> filterList = students.Where(x => x.Subject == subject).ToList();
            if (filterList.Count == 0)
            {
                return "No students enrolled for the subject";
            }

            var sb = new StringBuilder();

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine($"Students:");
            foreach (var stud in filterList)
            {
                sb.AppendLine($"{stud.FirstName} {stud.LastName}");
            }

            return sb.ToString().Trim();
        }

        public int GetStudentsCount()
        {
            return students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            var student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            return student;
        }
    }
}
