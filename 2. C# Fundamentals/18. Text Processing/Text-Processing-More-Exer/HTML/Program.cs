using System;
using System.Text;

namespace HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string content = Console.ReadLine();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"<h1>{Environment.NewLine}" +
                $"\t{title}{Environment.NewLine}" +
                $"</h1>{Environment.NewLine}" +
                $"<article>{Environment.NewLine}" +
                $"\t{content}{Environment.NewLine}" +
                $"</article>");
            string comment = string.Empty;
            while ((comment = Console.ReadLine()) != "end of comments")
            {
                builder.AppendLine($"<div>{Environment.NewLine}" +
                    $"\t{comment}{Environment.NewLine}" +
                    $"</div>");
            }
            string HTMLCode = builder.ToString();
            Console.WriteLine(HTMLCode);
        }
    }
}
