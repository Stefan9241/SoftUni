﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern
{
    public class TwelveGrain : Bread
    {

        public override void Bake()
        {
            Console.WriteLine("Baking the 12-Grain bread!");
        }

        public override void MixIngridients()
        {
            Console.WriteLine("Gathering ingridients for 12-Grain bread!");
        }
    }
}
