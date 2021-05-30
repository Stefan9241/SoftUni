using System;

namespace _01.WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string[] cmdArgs = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);

            while (cmdArgs[0] != "Travel")
            {
                if (cmdArgs[0] == "Add Stop")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string newString = cmdArgs[2];
                    if (index >= 0 && index <= text.Length - 1)
                    {
                        text = text.Insert(index, newString);
                    }
                }
                else if (cmdArgs[0] == "Remove Stop")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    string stringToDelete = "";
                    if (startIndex >= 0 && startIndex <= text.Length - 1 && endIndex >= 0 && endIndex <= text.Length - 1)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            stringToDelete += text[i];
                        }
                        text = text.Remove(startIndex, stringToDelete.Length);
                    }
                }
                else if (cmdArgs[0] == "Switch")
                {
                    string oldString = cmdArgs[1];
                    string newString = cmdArgs[2];
                    if (text.Contains(oldString))
                    {
                        text = text.Replace(oldString, newString);
                    }
                }
                Console.WriteLine(text);
                cmdArgs = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {text}");
        }
    }
}
