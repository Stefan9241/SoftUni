using System;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        public Weightlifter(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, numberOfMedals, 50)
        {
        }

        public override void Exercise()
        {
            if (this.Stamina + 10 > 100)
            {
                this.Stamina = 100;

                throw new ArgumentException("Stamina cannot exceed 100 points.");
            }
            else
            {
                this.Stamina += 10;
            }
        }
    }
}
