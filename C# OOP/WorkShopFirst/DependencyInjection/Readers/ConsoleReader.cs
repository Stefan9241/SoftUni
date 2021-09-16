using DependencyInjection.Common;
using DependencyInjection.Containers;
using DependencyInjection.Contracts;
using DependencyInjection.DI.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.Readers
{
    public class ConsoleReader : IReader
    {
        private ILogger logger;
        public ConsoleReader(ILogger logger)
        {
            this.logger = logger;
        }
        public Position ReadKey()
        {
            Position position = new Position(0, 0);
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            while (!Console.KeyAvailable && key.Key != ConsoleKey.Escape)
            {
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        return new Position(-1, 0);
                        break;
                    case ConsoleKey.UpArrow:
                        return new Position(0, -1);
                        break;
                    case ConsoleKey.RightArrow:
                        return new Position(1, 0);
                        break;
                    case ConsoleKey.DownArrow:
                        return new Position(0, 1);
                        break;
                    case ConsoleKey.Escape:
                        break;
                    default:
                        if (Console.CapsLock && Console.NumberLock)
                        {
                            Console.WriteLine(key.KeyChar);
                        }
                        break;
                 
                }
            }
            return position;
        }

        public string ReadLine()
        {
            logger.Log("Reading line");
            return "";
        }
    }
}
