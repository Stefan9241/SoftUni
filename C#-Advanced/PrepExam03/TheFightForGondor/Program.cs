using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            var waves = int.Parse(Console.ReadLine());
            var plates = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var orcsToPrint = new Stack<int>();
            for (int i = 1; i <= waves; i++)
            {
                var newWaveOrcs = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
                if (i % 3 == 0)
                {
                    string input = Console.ReadLine();
                    int plateToAdd = int.Parse(input);
                    plates.Enqueue(plateToAdd);
                }
                while (newWaveOrcs.Count != 0 && plates.Count != 0)
                {
                    if (plates.Peek() < newWaveOrcs.Peek())
                    {
                        newWaveOrcs.Push(newWaveOrcs.Pop() - plates.Dequeue());
                    }
                    else if (plates.Peek() > newWaveOrcs.Peek())
                    {
                        Queue<int> updatedPlatesOfTheAragornsDefence = new Queue<int>();

                        updatedPlatesOfTheAragornsDefence.Enqueue(plates.Dequeue() - newWaveOrcs.Pop());

                        for (int j = 0; j < plates.Count; j++)
                        {
                            updatedPlatesOfTheAragornsDefence.Enqueue(plates.ElementAt(j));
                        }

                        plates = updatedPlatesOfTheAragornsDefence;
                    }
                    else
                    {
                        plates.Dequeue();
                        newWaveOrcs.Pop();
                    }
                }
                if (plates.Count == 0)
                {
                    orcsToPrint = newWaveOrcs;
                    break;
                }

            }

            if (plates.Count <= 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcsToPrint)}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
