using System;

namespace Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputType = Console.ReadLine();//"string" or "int" or "double"
            string input = Console.ReadLine();
            string result = string.Empty;
            if (inputType == "int")
            {
                result = WhenInt(input);
            }
            else if (inputType == "real")
            {
                result = WhenReal(input);
            }
            else if (inputType == "string")
            {
                result = WhenString(input);
            }
            Console.WriteLine(result);
        }
        
        static string WhenInt(string numberAsString)
        {
            string result = (int.Parse(numberAsString) * 2).ToString();
            return result;
        }

        static string WhenReal(string realNumberAsString)
        {
            string result = string.Format($"{double.Parse(realNumberAsString) * 1.5:F2}");
            return result;
        }

        static string WhenString(string word)
        {
            string result = string.Format($"${word}$");
            return result;
        }
    }
}
