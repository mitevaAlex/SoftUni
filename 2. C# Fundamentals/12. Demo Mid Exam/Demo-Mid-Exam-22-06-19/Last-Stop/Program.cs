using System;
using System.Collections.Generic;
using System.Linq;

namespace Last_Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> paintingsNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string command = string.Empty;
            while ((command= Console.ReadLine()) != "END")
            {
                string[] splittedCommand = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string operation = splittedCommand[0];
                switch (operation)
                {
                    case "Change":
                        int currentPaintingNumber = int.Parse(splittedCommand[1]);
                        if (DoesPaintingExist(paintingsNumbers, currentPaintingNumber))
                        {
                            int newPaintingNumber = int.Parse(splittedCommand[2]);
                            int indexCurrentPainting = paintingsNumbers.IndexOf(currentPaintingNumber);
                            paintingsNumbers[indexCurrentPainting] = newPaintingNumber;
                        }
                        break;
                    case "Hide":
                        int paintingNumber = int.Parse(splittedCommand[1]);
                        if (DoesPaintingExist(paintingsNumbers, paintingNumber))
                        {
                            int index = paintingsNumbers.IndexOf(paintingNumber);
                            paintingsNumbers.RemoveAt(index);
                        }
                        break;
                    case "Switch":
                        int firstPainting = int.Parse(splittedCommand[1]);
                        int secondPainting = int.Parse(splittedCommand[2]);
                        if (DoesPaintingExist(paintingsNumbers, firstPainting) &&
                            DoesPaintingExist(paintingsNumbers, secondPainting))
                        {
                            int firstIndex = paintingsNumbers.IndexOf(firstPainting);
                            int secondIndex = paintingsNumbers.IndexOf(secondPainting);
                            paintingsNumbers[firstIndex] = secondPainting;
                            paintingsNumbers[secondIndex] = firstPainting;
                        }
                        break;
                    case "Insert":
                        int newPaintingIndex = int.Parse(splittedCommand[1]);
                        if (newPaintingIndex >= 0 && newPaintingIndex + 1 < paintingsNumbers.Count)
                        {
                            int pintingNumber = int.Parse(splittedCommand[2]);
                            paintingsNumbers.Insert(newPaintingIndex + 1, pintingNumber);
                        }
                        break;
                    case "Reverse":
                        paintingsNumbers.Reverse();
                        break;
                }
            }
            Console.WriteLine(string.Join(' ', paintingsNumbers));
        }

        static bool DoesPaintingExist(List<int> paintingsNumbers, int currentPainting)
        {
            if (paintingsNumbers.Contains(currentPainting))
            {
                return true;
            }
            return false;
        }
    }
}
