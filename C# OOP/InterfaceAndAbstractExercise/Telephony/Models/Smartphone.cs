using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Interfaces;

namespace Telephony.Models
{
    public class Smartphone : ICall,IBrawse
    {
        public void Brawse(string site)
        {
            Console.WriteLine($"Browsing: {site}!");
        }

        public void Call(string phoneNumber)
        {
            Console.WriteLine($"Calling... {phoneNumber}");
        }
    }
}
