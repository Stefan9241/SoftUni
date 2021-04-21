using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Article2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int numArticles = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>(numArticles);
            for (int i = 0; i < numArticles; i++)
            {
                string[] tokens = Console.ReadLine().Split(", ");
                Article article = new Article();
                article.Title = tokens[0];
                article.Content = tokens[1];
                article.Author = tokens[2];
                articles.Add(article);
            }
            string criteria = Console.ReadLine();
            if (criteria == "title")
            {
                articles = articles.OrderBy(x => x.Title).ToList();
            }
            else if(criteria == "content")
            {
               articles =  articles.OrderBy(x => x.Content).ToList();
            }
            else
            {
                articles = articles.OrderBy(x => x.Author).ToList();
            }
            Console.WriteLine(string.Join(Environment.NewLine,articles));
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
