namespace ValidationAttributes.ValidationAttributes
{
    using System.Linq;
    using System.Reflection;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            bool isValidEntity = true;

            PropertyInfo[] properties = obj
                .GetType()
                .GetProperties();

            foreach (PropertyInfo property in properties)
            {
                MyValidationAttribute validationAttribute = (MyValidationAttribute)property
                    .GetCustomAttribute(typeof(MyValidationAttribute), false);
                isValidEntity = validationAttribute.IsValid(property.GetValue(obj));
                if (!isValidEntity) break;
            }

            return isValidEntity;
        }
    }
}
