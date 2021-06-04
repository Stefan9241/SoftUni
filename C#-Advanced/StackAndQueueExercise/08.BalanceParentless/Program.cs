using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            // { -->  1
            // } --> -1
            // ( -->  2
            // ) --> -2
            // [ -->  3
            // ] --> -3
            // отваряща скоба, последвана от затваряща скоба --> сбора им е 0

            string input = Console.ReadLine();

            // в стака слагаме само отварящи скоби (int еквивалента им т.е +)
            Stack<int> openBrackets = new Stack<int>();

            bool balancedBrackets = true;

            for (int i = 0; i < input.Length; i++)
            {
                char tempChar = input[i];
                int tempInt = 0;

                switch (tempChar)
                {
                    case '{': tempInt = 1; break;
                    case '}': tempInt = -1; break;
                    case '(': tempInt = 2; break;
                    case ')': tempInt = -2; break;
                    case '[': tempInt = 3; break;
                    case ']': tempInt = -3; break;

                    default: break;
                }

                // в стака пъхаме само отворени скоби
                if (tempInt > 0)
                {
                    openBrackets.Push(tempInt);
                    continue;
                }

                // проверка за затваряща скоба при условие, че няма отваряща скоба преди нея
                if (openBrackets.Count == 0)
                {
                    balancedBrackets = false;
                    break;
                }

                // ако подавания член е положителен - го записваме в стака
                // ако подавания член е ортицателен го сравняваме с най-горния в стака
                // ако съответства - ОК, "продължаваме напред"
                // ако ли не - значи сме до тук, защото сме разбалансирани

                if (tempInt > 0)
                {
                    openBrackets.Push(tempInt);
                    continue;
                }
                else
                {
                    int tempStackPeek = openBrackets.Peek();

                    if ((tempStackPeek + tempInt) == 0)
                    {
                        openBrackets.Pop();
                    }
                    else
                    {
                        balancedBrackets = false;
                        break;
                    }
                }
            }

            if (balancedBrackets)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

            //Console.WriteLine("Hello World!");
        }
    }
}