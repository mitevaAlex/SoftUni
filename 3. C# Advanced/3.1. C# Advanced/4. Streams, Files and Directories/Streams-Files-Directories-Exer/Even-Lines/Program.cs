using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Even_Lines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("text.txt"))
            {
                using (StreamWriter sw = new StreamWriter("../../../Output.txt"))
                {
                    char[] oldChars = { '-', ',', '.', '!', '?' };
                    int lineCount = 0;
                    StringBuilder line = new StringBuilder();
                    line.Append(await sr.ReadLineAsync());
                    while (line.Length > 0)
                    {
                        if (lineCount % 2 == 0)
                        {
                            foreach (char oldChar in oldChars)
                            {
                                line.Replace(oldChar, '@');
                            }

                            string lineToPrint = string.Join(' ', line.ToString()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Reverse()
                                .ToArray());
                            await sw.WriteLineAsync(lineToPrint);
                        }

                        line.Clear();
                        line.Append(await sr.ReadLineAsync());
                        lineCount++;
                    }
                }
            }
        }
    }
}
