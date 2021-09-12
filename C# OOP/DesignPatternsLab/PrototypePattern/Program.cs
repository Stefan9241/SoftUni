using System;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Dice dice = new Dice() { Side = 5 ,Color = "Red"};
            Console.WriteLine(dice.Side);

            Dice dice2 = (Dice)dice.Clone();

            Console.WriteLine(dice2.Side);
            Console.WriteLine(dice2.Color);
        }
    }
}
