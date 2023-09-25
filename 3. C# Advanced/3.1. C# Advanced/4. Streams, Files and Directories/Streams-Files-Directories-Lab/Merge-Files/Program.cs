using System;
using System.IO;
using System.Threading.Tasks;

namespace Merge_Files
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader sr1 = new StreamReader("FileOne.txt"))
            {
                using (StreamReader sr2 = new StreamReader("FileTwo.txt"))
                {
                    using (StreamWriter sw = new StreamWriter("Output.txt"))
                    {
                        string text1Line = await sr1.ReadLineAsync();
                        string text2Line = await sr2.ReadLineAsync();
                        while (text1Line != null && text2Line != null)
                        {
                            await sw.WriteLineAsync(text1Line);
                            await sw.WriteLineAsync(text2Line);
                            text1Line = await sr1.ReadLineAsync();
                            text2Line = await sr2.ReadLineAsync();
                        }
                    }
                }
            }
        }
    }
}
