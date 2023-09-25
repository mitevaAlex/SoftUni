using System;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            //"{title}, {content}, {author}"
            string[] articleArgs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Article article = new Article(articleArgs[0], articleArgs[1], articleArgs[2]);

            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                //"Edit: {new content}" or "ChangeAuthor: {new author}" or "Rename: {new title}" 
                string[] commandArgs = Console.ReadLine()
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string operation = commandArgs[0];
                switch (operation)
                {
                    case "Edit":
                        string newContent = commandArgs[1];
                        article.Edit(newContent);
                        break;
                    case "ChangeAuthor":
                        string newAuthor = commandArgs[1];
                        article.ChangeAuthor(newAuthor);
                        break;
                    case "Rename":
                        string newTitle = commandArgs[1];
                        article.Rename(newTitle);
                        break;
                }
            }
            Console.WriteLine(article);
        }
    }
}
