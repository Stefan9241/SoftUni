using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    public class SandwichMenu
    {
        private Dictionary<string,SandwichPrototype> sandwich;
        public SandwichMenu()
        {
            this.sandwich = new Dictionary<string, SandwichPrototype>();
        }

        public SandwichPrototype this[string name] 
        {
            get
            {
                return this.sandwich[name];
            }
            set
            {
                this.sandwich.Add(name, value);
            }
        }
    }
}
