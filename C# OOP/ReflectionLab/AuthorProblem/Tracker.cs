using System.Linq;
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(x=> x.AttributeType == typeof(AuthorAttribute)))
                {
                    var authorAtributes = method.GetCustomAttributes(false);
                    foreach (AuthorAttribute attr in authorAtributes)
                    {
                        System.Console.WriteLine($"{method.Name} is written by {attr.Name}");
                    }
                }
            }
        }
    }
}
