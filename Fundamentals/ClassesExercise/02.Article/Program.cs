using System;

namespace _02.Article
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            string title = input[0];
            string content = input[1];
            string author = input[2];
            Article article = new Article(title, content, author);
            int timesChenges = int.Parse(Console.ReadLine());

            for (int i = 0; i < timesChenges; i++)
            {
                string[] command = Console.ReadLine().Split(": ");
                if (command[0] == "Edit")
                {
                    article.EditContent(command[1]);
                }
                else if(command[0]== "ChangeAuthor")
                {
                    article.ChangeAuthor(command[1]);
                }
                else if(command[0] == "Rename")
                {
                    article.Rename(command[1]);
                }
            }

            Console.WriteLine(article.ToString());

        }

        
    }

    class Article
    {
        public Article(string title, string content, string author) 
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void EditContent(string content)
        {
            Content = content;
        }

        public void ChangeAuthor(string author)
        {
            Author = author;
        }
        public void Rename(string title)
        {
            Title = title;
        }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
