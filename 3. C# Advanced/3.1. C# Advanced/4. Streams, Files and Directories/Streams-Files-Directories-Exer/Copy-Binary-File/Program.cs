using System;
using System.IO;
using System.Threading.Tasks;

namespace Copy_Binary_File
{
    class Program
    {
        static async Task Main(string[] args)
        {
            byte[] buffer = new byte[4096];
            int totalReadBytes = 0;
            using (FileStream inputFS = new FileStream("copyMe.png", FileMode.Open))
            {
                using (FileStream outputFS = new FileStream("../../../Output.png", FileMode.Create))
                {
                    while (totalReadBytes < inputFS.Length)
                    {
                        int currentBytes = await inputFS.ReadAsync(buffer, 0, buffer.Length);
                        await outputFS.WriteAsync(buffer, 0, currentBytes);
                        totalReadBytes += currentBytes;
                    }
                }
            }
        }
    }
}
