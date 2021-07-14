using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<TFirst,TSecond>
    {
        public TFirst FirstElement { get; set; }
        public TSecond SecondElement { get; set; }
        public Tuple(TFirst first,TSecond second)
        {
            FirstElement = first;
            SecondElement = second;
        }
        public override string ToString()
        {
            return $"{FirstElement} -> {SecondElement}";
        }
    }
}
