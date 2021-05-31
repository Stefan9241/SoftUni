using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    class Pieces
    {
        public Pieces(string piece, string composer, string key)
        {
            PieceName = piece;
            Composer = composer;
            Key = key;
        }
        public string PieceName { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }

        public override string ToString()
        {
            return $"{PieceName} -> Composer: {Composer}, Key: {Key}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Pieces> list = new List<Pieces>();
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string piece = cmd[0];
                string composer = cmd[1];
                string key = cmd[2];
                if (!list.Any(x=>x.PieceName == piece))
                {
                    Pieces curr = new Pieces(piece, composer, key);
                    list.Add(curr);
                }
                
            }

            string[] commands = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
            while (commands[0] != "Stop")
            {
                string command = commands[0];
                string piece = commands[1];

                if (command == "Add")
                {
                    string composer = commands[2];
                    string key = commands[3];
                    if (list.Any(x => x.PieceName == piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                        list.Add(new Pieces(piece, composer, key));
                    }
                }
                else if (command == "Remove")
                {
                    if (list.Any(x => x.PieceName == piece))
                    {
                        Pieces toRemove = list.FirstOrDefault(x => x.PieceName == piece);
                        list.Remove(toRemove);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (command == "ChangeKey")
                {
                    string newKey = commands[2];
                    if (list.Any(x => x.PieceName == piece))
                    {
                        Pieces keyToReplace = list.FirstOrDefault(x => x.PieceName == piece);
                        keyToReplace.Key = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }

                }

                commands = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                
            }
            foreach (var item in list.OrderBy(x => x.PieceName).ThenBy(x => x.Composer))
            {
                Console.WriteLine(item);
            }
        }
    }
}
