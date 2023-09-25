using System;
using System.Linq;

namespace Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string[] command = new string[3];
            while (!(command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)).Contains("end"))
            {
                int moduleDivisionResult = -1;
                if (command.Contains("exchange"))
                {
                    int exchangeIndex = int.Parse(command[1]);
                    if (exchangeIndex >= numbers.Length || exchangeIndex < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers = Exange(numbers, exchangeIndex);
                }
                else if (command.Contains("max"))
                {
                    if (command.Contains("even"))
                    {
                        moduleDivisionResult = 0;
                    }
                    else if (command.Contains("odd"))
                    {
                        moduleDivisionResult = 1;
                    }

                    int maxNumberIndex = FindMaxNumberIndex(numbers, moduleDivisionResult);
                    if (maxNumberIndex == -1)
                    {
                        Console.WriteLine("No matches");
                        continue;
                    }

                    Console.WriteLine(maxNumberIndex);
                }
                else if (command.Contains("min"))
                {
                    if (command.Contains("even"))
                    {
                        moduleDivisionResult = 0;
                    }
                    else if (command.Contains("odd"))
                    {
                        moduleDivisionResult = 1;
                    }

                    int minNumberIndex = FindMinNumberIndex(numbers, moduleDivisionResult);
                    if (minNumberIndex == -1)
                    {
                        Console.WriteLine("No matches");
                        continue;
                    }

                    Console.WriteLine(minNumberIndex);
                }
                else if (command.Contains("first"))
                {
                    if (command.Contains("even"))
                    {
                        moduleDivisionResult = 0;
                    }
                    else if (command.Contains("odd"))
                    {
                        moduleDivisionResult = 1;
                    }

                    int wantedNumbersCount = int.Parse(command[1]);
                    if (wantedNumbersCount > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    int[] firstNumbers = FindFirstNumbers(numbers, wantedNumbersCount, moduleDivisionResult);
                    if (firstNumbers.Length == 0)
                    {
                        Console.WriteLine("[]");
                    }
                    else
                    {
                        string firstNumsString = string.Join(", ", firstNumbers);
                        Console.WriteLine($"[{firstNumsString}]");
                    }
                }
                else if (command.Contains("last"))
                {
                    if (command.Contains("even"))
                    {
                        moduleDivisionResult = 0;
                    }
                    else if (command.Contains("odd"))
                    {
                        moduleDivisionResult = 1;
                    }

                    int wantedNumbersCount = int.Parse(command[1]);
                    if (wantedNumbersCount > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    int[] lastNumbers = FindLastNumbers(numbers, wantedNumbersCount, moduleDivisionResult);
                    if (lastNumbers.Length == 0)
                    {
                        Console.WriteLine("[]");
                    }
                    else
                    {
                        string lastNumsString = string.Join(", ", lastNumbers);
                        Console.WriteLine($"[{lastNumsString}]");
                    }
                }
            }
            string finalNumbers = string.Join(", ", numbers);
            Console.WriteLine($"[{finalNumbers}]");
        }

        static int[] Exange(int[] numbers, int exchangeIndex)
        {
            int[] firstNumbers = new int[exchangeIndex + 1];
            Array.Copy(numbers, firstNumbers, firstNumbers.Length);
            int currentIndex = 0;
            for (int i = exchangeIndex + 1; i < numbers.Length; i++)
            {
                numbers[currentIndex] = numbers[i];
                currentIndex++;
            }

            for (int i = 0; i < firstNumbers.Length; i++)
            {
                numbers[currentIndex] = firstNumbers[i];
                currentIndex++;
            }
            return numbers;
        }

        static int FindMaxNumberIndex(int[] numbers, int moduleDivisionResult)
        {
            int maxNumber = int.MinValue;
            int maxNumIndex = -1;
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                if (currentNumber % 2 == moduleDivisionResult && currentNumber >= maxNumber)
                {
                    maxNumber = currentNumber;
                    maxNumIndex = i;
                }
            }
            return maxNumIndex;
        }

        static int FindMinNumberIndex(int[] numbers, int moduleDivisionResult)
        {
            int minNumber = int.MaxValue;
            int minNumIndex = -1;
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                if (currentNumber % 2 == moduleDivisionResult && currentNumber <= minNumber)
                {
                    minNumber = currentNumber;
                    minNumIndex = i;
                }
            }
            return minNumIndex;
        }

        static int[] FindFirstNumbers(int[] numbers, int wantedNumbersCount, int moduleDivisionResult)
        {
            int[] firstNumbersTempArr = new int[wantedNumbersCount];           
            int indexFirstNums = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                if (currentNumber % 2 == moduleDivisionResult)
                {
                    firstNumbersTempArr[indexFirstNums] = currentNumber;
                    indexFirstNums++;
                }
                if (indexFirstNums == firstNumbersTempArr.Length)
                {
                    break;
                }
            }

            int[] firstNumbers = new int[indexFirstNums];
            Array.Copy(firstNumbersTempArr, firstNumbers, firstNumbers.Length);
            return firstNumbers;
        }

        static int[] FindLastNumbers(int[] numbers, int wantedNumbersCount, int moduleDivisionResult)
        {
            int[] lastNumbersTempArr = new int[wantedNumbersCount];
            int indexLastNums = 0;
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                int currentNumber = numbers[i];
                if (currentNumber % 2 == moduleDivisionResult)
                {
                    lastNumbersTempArr[indexLastNums] = currentNumber;
                    indexLastNums++;
                }
                if (indexLastNums == lastNumbersTempArr.Length)
                {
                    break;
                }
            }
           
            int[] lastNumbers = new int[indexLastNums];
            Array.Copy(lastNumbersTempArr, lastNumbers, lastNumbers.Length);
            return lastNumbers.Reverse().ToArray();
        }
    }
}

