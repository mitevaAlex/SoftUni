using System;
using System.Collections.Generic;
using System.Linq;

namespace Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            //"merge {startIndex} {endIndex}" or "divide {index} {partitions}"
            string[] command = new string[3];

            while ((command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries))[0] != "3:1")
            {
                string action = command[0];
                int index = int.Parse(command[1]);
                if (action == "merge")
                {
                    int endIndex = int.Parse(command[2]);
                    MergeData(data, index, endIndex);
                }
                else if (action == "divide")
                {
                    int partitionsCount = int.Parse(command[2]);
                    if (partitionsCount == 0 || partitionsCount > data[index].Length)
                    {
                        continue;
                    }
                    DivideData(data, index, partitionsCount);
                }
            }
            Console.WriteLine(string.Join(' ', data));
        }

        static void MergeData(List<string> data, int startIndex, int endIndex)
        {
            if (startIndex < 0)
            {
                startIndex = 0;
            }

            if (endIndex >= data.Count)
            {
                endIndex = data.Count - 1;
            }
            int mergedIndex = startIndex;
            int currentIndex = startIndex + 1;
            while (mergedIndex < endIndex)
            {
                data[startIndex] += data[currentIndex];
                data.RemoveAt(currentIndex);
                mergedIndex++;
            }
        }

        static void DivideData(List<string> data, int index, int partitionsCount)
        {
            string element = data[index];
            List<char> elementSymbols = new List<char>();           
            for (int i = 0; i < element.Length; i++)
            {
                elementSymbols.Add(element[i]);
            }
            int partLength = elementSymbols.Count / partitionsCount;
            List<string> dividedElements = new List<string>();
            while (elementSymbols.Count > 0)
            {
                string currentPart = string.Empty;
                int currentIndex = 0;
                int currentSymbolsCount = 0;
                while (currentSymbolsCount < partLength)
                {
                    currentPart += elementSymbols[currentIndex];
                    elementSymbols.RemoveAt(currentIndex);
                    currentSymbolsCount++;
                    if (element.Length % partitionsCount != 0
                      && dividedElements.Count == partitionsCount - 1
                      && currentSymbolsCount == partLength)
                    {
                        currentPart += elementSymbols[currentIndex];
                        elementSymbols.RemoveAt(currentIndex);
                        currentSymbolsCount++;
                    }
                }
                dividedElements.Add(currentPart);
            }
            data.RemoveAt(index);
            data.InsertRange(index, dividedElements);
            
        }
    }
}
