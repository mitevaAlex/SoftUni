using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            MethodInfo[] methodsWithAuthor = type.GetMethods(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                .Where(x => x.GetCustomAttribute(typeof(AuthorAttribute)) != null)
                .ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (MethodInfo method in methodsWithAuthor)
            {
                var attributes = method.GetCustomAttributes(false);
                foreach (AuthorAttribute authorAttr in attributes)
                {
                    sb.AppendLine($"{method.Name} is written by {authorAttr.Name}");
                }
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
