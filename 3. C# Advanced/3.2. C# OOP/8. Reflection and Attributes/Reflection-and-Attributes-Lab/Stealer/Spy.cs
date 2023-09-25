namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldsNames)
        {
            Type classType = Type.GetType(className);
            object classInstance = Activator.CreateInstance(classType);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {className}");

            for (int i = 0; i < fieldsNames.Length; i++)
            {
                FieldInfo fieldInfo = classType.GetField(fieldsNames[i],
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                if (fieldInfo != null)
                {
                    sb.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(classInstance)}");
                }
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);

            FieldInfo[] publicFields = classType.GetFields(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo publicField in publicFields)
            {
                sb.AppendLine($"{publicField.Name} must be private!");
            }

            MethodInfo[] nonPublicMethods = classType.GetMethods(
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (MethodInfo nonPublicMethod in nonPublicMethods)
            {
                if (nonPublicMethod.Name.StartsWith("get"))
                {
                    sb.AppendLine($"{nonPublicMethod.Name} have to be public!");
                }
            }

            MethodInfo[] publicMethodsInfo = classType.GetMethods(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            foreach (MethodInfo publicMethod in publicMethodsInfo)
            {
                if (publicMethod.Name.StartsWith("set"))
                {
                    sb.AppendLine($"{publicMethod.Name} have to be private!");
                }
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            Type classType = Type.GetType(className);
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");
            MethodInfo[] nonPublicMethods = classType.GetMethods(
                BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            foreach (MethodInfo method in nonPublicMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);
            MethodInfo[] methods = classType.GetMethods(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (MethodInfo method in methods)
            {
                if (method.Name.StartsWith("get"))
                {
                    sb.AppendLine($"{method.Name} will return {method.ReturnType}");
                }
                else if (method.Name.StartsWith("set"))
                {
                    sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
