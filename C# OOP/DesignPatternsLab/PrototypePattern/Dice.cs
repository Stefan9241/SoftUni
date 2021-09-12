using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    class Dice : ICloneable
    {
        public int Side { get; set; }

        public string Color { get; set; }

        public object Clone()
        {
            // shallow copy
            return this.MemberwiseClone();
        }
    }
}
