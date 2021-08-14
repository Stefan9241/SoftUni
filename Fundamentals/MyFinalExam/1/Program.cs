using System;
using System.Collections.Generic;
using System.Text;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string[] tokens = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            while (tokens[0] != "End")
            {
                if (tokens[0] == "Translate")
                {
                    char charToReplace = char.Parse(tokens[1]);
                    char replacement = char.Parse(tokens[2]);
                    text = text.Replace(charToReplace, replacement);
                    Console.WriteLine(text);
                }
                else if(tokens[0] == "Includes")
                {
                    bool isIncludes = false;
                    if (text.Contains(tokens[1]))
                    {
                        isIncludes = true;
                    }
                    Console.WriteLine(isIncludes);
                }
                else if(tokens[0] == "Start")
                {
                    string checkString = tokens[1];
                    int lenghtOfcheckString = checkString.Length;
                    string cutString = text.Substring(0, lenghtOfcheckString);
                    bool isAtTheStart = false;
                    if (cutString == checkString)
                    {
                        isAtTheStart = true;
                    }
                    Console.WriteLine(isAtTheStart);
                }
                else if (tokens[0] == "Lowercase")
                {
                    var sb = new StringBuilder();
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (char.IsWhiteSpace(text[i]))
                        {
                            sb.Append(" ");
                        }
                        else
                        {
                            sb.Append(text[i].ToString().ToLower());
                        }
                    }
                    text = sb.ToString();
                    Console.WriteLine(text);
                }
                else if (tokens[0] == "FindIndex")
                {
                    char charToCheck = char.Parse(tokens[1]);
                    int indexOfChar = text.LastIndexOf(charToCheck);
                    Console.WriteLine(indexOfChar);
                }
                else if (tokens[0] == "Remove")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int count = int.Parse(tokens[2]);
                    text = text.Remove(startIndex, count);
                    Console.WriteLine(text);
                }

                tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
