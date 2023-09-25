using System;
using System.Collections.Generic;
using System.Linq;

namespace Contact_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> contacts = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();//names of people
            //"Add {contact} {index}" or  "Remove {index}" or 
            //"Export {startIndex} {count}" or "Print Normal/Reversed"
            string[] command = new string[3];
            while (!(command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)).Contains("Print"))
            {
                string operation = command[0];
                switch (operation)
                {
                    case "Add":
                        string newContact = command[1];
                        int index = int.Parse(command[2]);
                        if (!contacts.Contains(newContact))
                        {
                            contacts.Add(newContact);
                        }
                        else if (contacts.Contains(newContact) && IsIndexValid(contacts.Count, index))
                        {
                            contacts.Insert(index, newContact);
                        }
                        break;
                    case "Remove":
                        index = int.Parse(command[1]);
                        if (IsIndexValid(contacts.Count, index))
                        {
                            contacts.RemoveAt(index);
                        }
                        break;
                    case "Export":
                        int startIndex = int.Parse(command[1]);
                        int wantedContactsCount = int.Parse(command[2]);
                        List<string> wantedContacts = new List<string>();
                        int counter = 0;
                        foreach (string currentName in contacts)
                        {
                            if (contacts.IndexOf(currentName) >= startIndex &&
                                counter < wantedContactsCount)
                            {
                                wantedContacts.Add(currentName);
                                counter++;
                            }
                        }
                        Console.WriteLine(string.Join(' ', wantedContacts));
                        break;
                }
            }
            string printingWay = command[1];
            if (printingWay == "Reversed")
            {
                contacts.Reverse();
            }
            Console.Write("Contacts: ");
            Console.WriteLine(string.Join(' ', contacts));
        }

        static bool IsIndexValid(int contactsLength, int index)
        {
            if (index >= 0 && index < contactsLength)
            {
                return true;
            }
            return false;
        }
    }
}
