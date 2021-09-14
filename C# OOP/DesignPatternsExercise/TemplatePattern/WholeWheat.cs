using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern
{
    public class WholeWheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the WholeWheat Bread!");
        }

        public override void MixIngridients()
        {
            Console.WriteLine("Gathering ingridients for WholeWheat Bread!");
        }
    }
}
