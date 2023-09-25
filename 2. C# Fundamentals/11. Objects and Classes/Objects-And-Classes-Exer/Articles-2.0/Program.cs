using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int articlesCount = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            for (int i = 0; i < articlesCount; i++)
            {
                //"{title}, {content}, {author}"
                string[] currentArticleArgs = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                Article currentArticle = new Article(currentArticleArgs[0],
                     currentArticleArgs[1], currentArticleArgs[2]);
                articles.Add(currentArticle);
            }
            string orderBy = Console.ReadLine();//"title" or "content" or "author"
            List<Article> orderedArticles = new List<Article>();
            switch (orderBy)
            {
                case "title":
                    orderedArticles = articles
                        .OrderBy(x => x.Title)
                        .ToList();
                    break;
                case "content":
                    orderedArticles = articles
                        .OrderBy(x => x.Content)
                        .ToList();
                    break;
                case "author":
                    orderedArticles = articles
                        .OrderBy(x => x.Author)
                        .ToList();
                    break;
            }
            orderedArticles.ForEach(x => Console.WriteLine(x));
        }
    }
}
