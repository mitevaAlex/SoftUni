using System;
using System.IO;
using System.Threading.Tasks;

namespace Line_Numbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("Input.txt"))
            {
                int lineCount = 1;
                string line = await reader.ReadLineAsync();
                using (StreamWriter writer = new StreamWriter("Output.txt"))
                {
                    while (line != null)
                    {
                        await writer.WriteLineAsync($"{lineCount}. {line}");
                        line = await reader.ReadLineAsync();
                        lineCount++;
                    }
                }
            }
        }
    }
}
