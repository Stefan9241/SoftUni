using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (!egg.IsDone())
            {
                if (bunny.Energy == 0)
                {
                    break;
                }
                if (bunny.Dyes.Any(x=> x.Power > 0) == false)
                {
                    break;
                }
                bunny.Work();
                var bunnyDye = bunny.Dyes.First();
                bunnyDye.Use();
                if (bunny.Dyes.First().Power == 0)
                {
                    bunny.Dyes.Remove(bunnyDye);
                }
                egg.GetColored();
            }
        }
    }
}
