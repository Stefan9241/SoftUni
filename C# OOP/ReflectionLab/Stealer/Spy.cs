using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfTheClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(nameOfTheClass);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Public |
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);
            var sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });
            sb.AppendLine($"Class under investigation: {nameOfTheClass}");
            foreach (FieldInfo field in classFields.Where(x=> requestedFields.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }
    }
}
