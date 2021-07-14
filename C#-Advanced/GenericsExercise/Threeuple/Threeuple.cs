using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Threeuple<TFirst,TSecond,TThird>
    {
        public TFirst FirstElement { get; set; }
        public TSecond SecondElement { get; set; }
        public TThird ThirdElement { get; set; }
        public Threeuple(TFirst first, TSecond second,TThird third)
        {
            FirstElement = first;
            SecondElement = second;
            ThirdElement = third;
        }
        public override string ToString()
        {
            return $"{FirstElement} -> {SecondElement} -> {ThirdElement}";
        }
    }
}
