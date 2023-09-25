using System;
using System.IO;
using System.Threading.Tasks;

namespace Odd_Lines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("Input.txt"))
            {
                int lineCount = 0;
                string line = await reader.ReadLineAsync();
                using (StreamWriter writer = new StreamWriter("Output.txt"))
                {
                    while (line != null)
                    {
                        if (lineCount % 2 != 0)
                        {
                            await writer.WriteLineAsync(line);
                        }

                        line = await reader.ReadLineAsync();
                        lineCount++;
                    }
                }
            }
        }
    }
}
