using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Final_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .ToList();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Stop")
            {
                //"Delete {index}" or  "Swap {word1} {word2}" or "Put {word} {index}" or
                //"Sort" or "Replace {word1} {word2}"
                string[] splittedCommand = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string operation = splittedCommand[0];
                switch (operation)
                {
                    case "Delete":
                        int index = int.Parse(splittedCommand[1]) + 1;
                        if (IsIndexValid(words.Count, index))
                        {
                            words.RemoveAt(index);
                        }
                        break;
                    case "Swap":
                        string firstWord = splittedCommand[1];
                        string secondWord = splittedCommand[2];
                        if (DoesWordExist(words, firstWord) && DoesWordExist(words, secondWord))
                        {
                            int firstIndex = words.IndexOf(firstWord);
                            int secondIndex = words.IndexOf(secondWord);
                            words[firstIndex] = secondWord;
                            words[secondIndex] = firstWord;
                        }
                        break;
                    case "Put":
                        index = int.Parse(splittedCommand[2]) - 1;
                        string word = splittedCommand[1];
                        if (index == words.Count)
                        {
                            words.Add(word);
                        }
                        else if (IsIndexValid(words.Count, index))
                        {
                            words.Insert(index, word);
                        }
                        break;
                    case "Sort":
                        words.Sort();
                        words.Reverse();
                        break;
                    case "Replace":
                        firstWord = splittedCommand[1];
                        secondWord = splittedCommand[2];
                        if (DoesWordExist(words, secondWord))
                        {
                            int secondIndex = words.IndexOf(secondWord);
                            words[secondIndex] = firstWord;
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(' ', words));
        }

        static bool IsIndexValid(int listCount, int index)
        {
            if (index >= 0 && index < listCount)
            {
                return true;
            }
            return false;
        }

        static bool DoesWordExist(List<string> words, string word)
        {
            if (words.Contains(word))
            {
                return true;
            }
            return false;
        }
    }
}
