using System;

namespace AuthorProblem
{
    [Author("Stefan")]
    public class StartUp
    {
        [Author("Dancho")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();

        }
    }
}
