using System;
using System.IO;
using System.Threading.Tasks;

namespace Slice_a_File
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int parts = 4;
            byte[] buffer = new byte[4096];
            int totalReadBytes = 0;
            using (FileStream inputFS = new FileStream("sliceMe.txt", FileMode.Open, FileAccess.Read))
            {
                int partSize = (int)Math.Ceiling((decimal)inputFS.Length / parts);
                for (int i = 1; i <= parts; i++)
                {
                    int currentReadBytes = 0;
                    using (FileStream outputFS = new FileStream($"Part-{i}.txt", FileMode.Create, FileAccess.Write))
                    {
                        while (currentReadBytes < partSize && totalReadBytes < inputFS.Length)
                        {
                            int bytesToRead = Math.Min(buffer.Length, partSize - currentReadBytes);
                            int bytes = await inputFS.ReadAsync(buffer, 0, bytesToRead);
                            await outputFS.WriteAsync(buffer, 0, bytes);
                            currentReadBytes += bytes;
                            totalReadBytes += bytes;
                        }
                    }
                }
            }
        }
    }
}
