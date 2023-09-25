using System;
using System.Linq;

namespace Kamino_Factory_Second_Attempt
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthDNA = int.Parse(Console.ReadLine());
            int[] bestDNASecquence = new int[lengthDNA];
            int longestSequenceLength = 0;//sequence of ones
            int longestSequenceIndex = 0;
            int longestSequenceDNASum = 0;
            int currentDNANumber = 0;
            int longestSequenceDNANumber = 0;
            string longestSequenceDNASample = string.Empty;
            string command = string.Empty;//DNA sample (e.g. 0!1!0!1!1) or "Clone them!"
            while ((command = Console.ReadLine()) != "Clone them!")
            {
                int[] currentDNA = command
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                currentDNANumber++;
                int currentSequenceLength = FindSequnceLengthAndIndex(currentDNA)[0];
                int currentSequenceIndex = FindSequnceLengthAndIndex(currentDNA)[1];
                int currentSequenceDNASum = currentDNA.Sum();

                if (currentSequenceLength > longestSequenceLength)
                {
                    longestSequenceLength = currentSequenceLength;
                    longestSequenceIndex = currentSequenceIndex;
                    longestSequenceDNASum = currentSequenceDNASum;
                    longestSequenceDNANumber = currentDNANumber;
                    longestSequenceDNASample = string.Join(' ', currentDNA);
                }
                else if (currentSequenceLength == longestSequenceLength)
                {
                    if (currentSequenceIndex < longestSequenceIndex)
                    {
                        longestSequenceLength = currentSequenceLength;
                        longestSequenceIndex = currentSequenceIndex;
                        longestSequenceDNASum = currentSequenceDNASum;
                        longestSequenceDNANumber = currentDNANumber;
                        longestSequenceDNASample = string.Join(' ', currentDNA);
                    }
                    else if (currentSequenceIndex == longestSequenceIndex)
                    {
                        if (currentSequenceDNASum > longestSequenceDNASum)
                        {
                            longestSequenceLength = currentSequenceLength;
                            longestSequenceIndex = currentSequenceIndex;
                            longestSequenceDNASum = currentSequenceDNASum;
                            longestSequenceDNANumber = currentDNANumber;
                            longestSequenceDNASample = string.Join(' ', currentDNA);
                        }
                    }
                }

                if (longestSequenceDNASample == string.Empty)
                {
                    longestSequenceDNASample = string.Join(' ', currentDNA);
                }
            }
            Console.WriteLine($"Best DNA sample {longestSequenceDNANumber} with sum: {longestSequenceDNASum}.");
            Console.WriteLine(longestSequenceDNASample);
        }

        static int[] FindSequnceLengthAndIndex(int[] currentDNA)
        {
            int sequenceLength = 0;
            int longestSequenceLength = 0;
            int longestSequenceIndex = 0;
            int currentSequenceIndex = 0;
            for (int i = 0; i < currentDNA.Length; i++)
            {
                if (currentDNA[i] == 1 && sequenceLength == 0)
                {
                    sequenceLength++;
                    currentSequenceIndex = i;
                }
                else if (currentDNA[i] == 1)
                {
                    sequenceLength++;
                }
                else
                {
                    if (sequenceLength > longestSequenceLength)
                    {
                        longestSequenceLength = sequenceLength;
                        longestSequenceIndex = currentSequenceIndex;
                    }
                    sequenceLength = 0;
                }

                if (i == currentDNA.Length - 1)
                {
                    if (sequenceLength > longestSequenceLength)
                    {
                        longestSequenceLength = sequenceLength;
                        longestSequenceIndex = currentSequenceIndex;
                    }
                }
            }
            int[] longestSequenceFeatures = { longestSequenceLength, longestSequenceIndex };
            return longestSequenceFeatures;
        }
    }
}
