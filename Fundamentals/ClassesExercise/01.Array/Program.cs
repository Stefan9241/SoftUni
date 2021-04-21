using System;

namespace _01.Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberMsg = int.Parse(Console.ReadLine());
            string[] phrases = { "Excellent product."
                    , "Such a great product."
                    , "I always use that product."
                    , "Best product of its category."
                    , "Exceptional product."
                    , "I can’t live without this product." };

            string[] events = { "Now I feel good."
                    , "I have succeeded with this product."
                    , "Makes miracles. I am happy of the results!"
                    , "I cannot believe but now I feel awesome."
                    , "Try it yourself, I am very satisfied."
                    , "I feel great!" };

            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random rnd = new Random();

            for (int i = 0; i < numberMsg; i++)
            {
                int phraseIndex = rnd.Next(0, phrases.Length);
                string currPhrase = phrases[phraseIndex];

                int eventIndex = rnd.Next(0, events.Length);
                string currEvent = events[eventIndex];

                int authorsIndex = rnd.Next(0, authors.Length);
                string currAuthor = authors[authorsIndex];

                int cityIndex = rnd.Next(0, cities.Length);
                string currCity = cities[cityIndex];

                Console.WriteLine($"{currPhrase} {currEvent} {currAuthor} – {currCity}.");
            }
        }
    }
}
