using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory = Console.ReadLine();
            string[] fileNames = Directory.GetFiles(directory);
            Dictionary<string, Dictionary<string, decimal>> extensionsFilesSizes = new Dictionary<string, Dictionary<string, decimal>>();
            foreach (string file in fileNames)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (!extensionsFilesSizes.ContainsKey(fileInfo.Extension))
                {
                    extensionsFilesSizes.Add(fileInfo.Extension, new Dictionary<string, decimal>());
                }

                extensionsFilesSizes[fileInfo.Extension].Add(fileInfo.Name, (decimal)fileInfo.Length / 1024);
            }

            extensionsFilesSizes = extensionsFilesSizes
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            File.WriteAllText("../../../report.txt", "");
            foreach (var extension in extensionsFilesSizes)
            {
                File.AppendAllText("../../../report.txt", $"{extension.Key}{Environment.NewLine}");
                Dictionary<string, decimal> filesSizes = extension
                    .Value
                    .OrderBy(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value);
                foreach (var file in filesSizes)
                {
                    File.AppendAllText("../../../report.txt", $"--{file.Key} - {file.Value}kb{Environment.NewLine}");
                }
            }
        }
    }
}
