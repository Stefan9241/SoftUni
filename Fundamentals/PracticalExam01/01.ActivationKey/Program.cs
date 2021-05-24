using System;

namespace _01.ActivationKey
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();
            string[] command = Console.ReadLine().Split(">>>", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Generate")
            {
                switch (command[0])
                {
                    case "Contains":
                        string text = command[1];
                        if (activationKey.Contains(text))
                        {
                            Console.WriteLine($"{activationKey} contains {text}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        string upperOrLower = command[1];
                        int startIndex = int.Parse(command[2]);
                        int endIndex = int.Parse(command[3]);
                        if (upperOrLower == "Upper")
                        {
                            string partToUpper = activationKey.Substring(startIndex, endIndex - startIndex);
                            string replaceToUpper = partToUpper.ToUpper();
                            activationKey = activationKey.Replace(partToUpper, replaceToUpper);
                            Console.WriteLine(activationKey);
                        }
                        else
                        {
                            string partToUpper = activationKey.Substring(startIndex, endIndex - startIndex);
                            string replaceToUpper = partToUpper.ToLower();
                            activationKey = activationKey.Replace(partToUpper, replaceToUpper);
                            Console.WriteLine(activationKey);
                        }
                        break;
                    case "Slice":
                        int sliceStartIndex = int.Parse(command[1]);
                        int sliceEndIndex = int.Parse(command[2]);
                        activationKey = activationKey.Remove(sliceStartIndex, sliceEndIndex - sliceStartIndex);
                        Console.WriteLine(activationKey);
                        break;
                }

                command = Console.ReadLine().Split(">>>", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
