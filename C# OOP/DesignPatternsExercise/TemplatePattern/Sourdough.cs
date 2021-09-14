using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern
{
    public class Sourdough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the Sourdough bread!");
        }

        public override void MixIngridients()
        {
            Console.WriteLine("Gathering ingridients for Sourdough bread!");

        }
    }
}
