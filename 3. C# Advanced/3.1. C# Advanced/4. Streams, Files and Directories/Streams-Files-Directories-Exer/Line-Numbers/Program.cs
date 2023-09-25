using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Line_Numbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] lines = await File.ReadAllLinesAsync("text.txt");
            File.WriteAllText("../../../Output.txt", "");
            for (int i = 0; i < lines.Length; i++)
            {
                int lettersCount = Regex.Matches(lines[i], @"[a-zA-Z]").Count;
                int punctuationCount = Regex.Matches(lines[i], @"[-,.!?':;]").Count;
                File.AppendAllText("../../../Output.txt", $"Line {i + 1}: {lines[i]} ({lettersCount})({punctuationCount}){Environment.NewLine}");
            }
        }
    }
}
