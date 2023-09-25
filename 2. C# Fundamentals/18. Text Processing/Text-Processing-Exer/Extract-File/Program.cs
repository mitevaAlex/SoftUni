using System;

namespace Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            // e.g : "C:\Internal\training-internal\Template.pptx"
            string[] filePath = Console.ReadLine()
                .Split('\\');
            string[] file = filePath[filePath.Length - 1]
                .Split('.');
            string fileName = file[0];
            string fileExtension = file[1];
            Console.WriteLine($"File name: {fileName}{Environment.NewLine}File extension: {fileExtension}");
        }
    }
}
