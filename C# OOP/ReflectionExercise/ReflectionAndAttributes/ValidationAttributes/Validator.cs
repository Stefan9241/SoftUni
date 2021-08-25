using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var attributes = property.GetCustomAttributes()
                    .Cast<MyValidationAttribute>().ToArray();
                var value = property.GetValue(obj);

                foreach (var atribute in attributes)
                {
                    bool isValid = atribute.IsValid(value);
                    if (isValid == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
