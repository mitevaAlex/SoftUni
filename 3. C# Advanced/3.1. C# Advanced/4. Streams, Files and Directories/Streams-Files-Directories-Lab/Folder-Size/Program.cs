using System;
using System.IO;
using System.Threading.Tasks;

namespace Folder_Size
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] files = Directory.GetFiles("TestFolder");
            double sizesSum = 0;
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                sizesSum += fileInfo.Length;
            }

            sizesSum = sizesSum / 1024 / 1024;
            await File.WriteAllTextAsync("Output.txt", sizesSum.ToString());
        }
    }
}
