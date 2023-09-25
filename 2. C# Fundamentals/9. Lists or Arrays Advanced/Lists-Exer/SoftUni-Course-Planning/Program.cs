using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> courseSchedule = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            //"Add:{lessonTitle}" or "Insert: {lessonTitle}:{index}" or "Remove:{lessonTitle}" 
            //or "Swap: {lessonTitle}:{lessonTitle}" or "Exercise: {lessonTitle}"
            List<string> command = new List<string>();
            while (!(command = Console.ReadLine()
                .Split(':', StringSplitOptions.RemoveEmptyEntries)
                .ToList()).Contains("course start"))
            {
                string operation = command[0];
                string lessonTitle = command[1];
                switch (operation)
                {
                    case "Add":
                        if (!courseSchedule.Contains(lessonTitle))
                        {
                            courseSchedule.Add(lessonTitle);
                        }
                        break;
                    case "Insert":
                        if (!courseSchedule.Contains(lessonTitle))
                        {
                            int index = int.Parse(command[2]);
                            courseSchedule.Insert(index, lessonTitle);
                        }
                        break;
                    case "Remove":
                        if (courseSchedule.Contains(lessonTitle))
                        {
                            courseSchedule.Remove(lessonTitle);
                            if (courseSchedule.Contains($"{lessonTitle}-Exercise"))
                            {
                                courseSchedule.Remove($"{lessonTitle}-Exercise");
                            }
                        }
                        break;
                    case "Swap":
                        string secondTitle = command[2];
                        if (courseSchedule.Contains(lessonTitle) && courseSchedule.Contains(secondTitle))
                        {
                            Swap(courseSchedule, lessonTitle, secondTitle);
                            if (courseSchedule.Contains($"{lessonTitle}-Exercise"))
                            {
                                int lessonIndex = courseSchedule.IndexOf(lessonTitle);
                                int exerciseIndex = courseSchedule.IndexOf($"{lessonTitle}-Exercise");
                                courseSchedule.Insert(lessonIndex + 1, courseSchedule[exerciseIndex]);
                                courseSchedule.RemoveAt(exerciseIndex);
                            }

                            if (courseSchedule.Contains($"{secondTitle}-Exercise"))
                            {
                                int lessonIndex = courseSchedule.IndexOf(secondTitle);
                                int exerciseIndex = courseSchedule.IndexOf($"{secondTitle}-Exercise");
                                courseSchedule.RemoveAt(exerciseIndex);
                                courseSchedule.Insert(lessonIndex + 1, $"{secondTitle}-Exercise");                      
                            }
                        }
                        break;
                    case "Exercise":
                        if (courseSchedule.Contains(lessonTitle) && !courseSchedule.Contains($"{lessonTitle}-Exercise"))
                        {
                            int lessonIndex = courseSchedule.IndexOf(lessonTitle);
                            courseSchedule.Insert(lessonIndex + 1, $"{lessonTitle}-Exercise");
                        }
                        else if (!courseSchedule.Contains(lessonTitle))
                        {
                            courseSchedule.Add(lessonTitle);
                            courseSchedule.Add($"{lessonTitle}-Exercise");
                        }
                        break;
                }
            }
            for (int i = 0; i < courseSchedule.Count; i++)
            {
                Console.WriteLine($"{i +1}.{courseSchedule[i]}");
            }
        }

        static void Swap(List<string> courseSchedule, string firstTitle, string secondTitle)
        {
            int firstIndex = courseSchedule.IndexOf(firstTitle);
            int secondIndex = courseSchedule.IndexOf(secondTitle);
            courseSchedule[firstIndex] = secondTitle;
            courseSchedule[secondIndex] = firstTitle;
        }
    }
}
