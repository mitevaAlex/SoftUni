using System;
using System.Collections.Generic;
using System.Linq;

namespace Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            Dictionary<string, User> users = new Dictionary<string, User>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                //"Add={username}={sent}={received}" or "Message={sender}={receiver}" or "Empty={username}"
                string[] commandArgs = command
                    .Split('=');
                string operation = commandArgs[0];
                if (operation == "Add")
                {
                    string username = commandArgs[1];
                    if (!users.ContainsKey(username))
                    {
                        User user = new User(int.Parse(commandArgs[2]), int.Parse(commandArgs[3]));
                        users.Add(username, user);
                    }
                }
                else if (operation == "Message")
                {
                    string sender = commandArgs[1];
                    string receiver = commandArgs[2];
                    if (users.ContainsKey(sender) && users.ContainsKey(receiver))
                    {
                        users[sender].SentMessages++;
                        users[receiver].ReceivedMessages++;
                        if (users[sender].SentMessages + users[sender].ReceivedMessages == capacity)
                        {
                            users.Remove(sender);
                            Console.WriteLine($"{sender} reached the capacity!");
                        }

                        if (users[receiver].ReceivedMessages + users[receiver].SentMessages == capacity)
                        {
                            users.Remove(receiver);
                            Console.WriteLine($"{receiver} reached the capacity!");
                        }
                    }
                }
                else if (operation == "Empty")
                {
                    string username = commandArgs[1];
                    if (username == "All")
                    {
                        users = new Dictionary<string, User>();
                    }
                    else if (users.ContainsKey(username))
                    {
                        users.Remove(username);
                    }
                }
            }

            users = users
                .OrderByDescending(x => x.Value.ReceivedMessages)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"Users count: {users.Count}" +
                $"{string.Join("", users.Select(x => $"{Environment.NewLine}{x.Key} - {x.Value.ReceivedMessages + x.Value.SentMessages}"))}");
        }
    }
}
