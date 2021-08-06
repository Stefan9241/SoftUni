using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Interfaces;

namespace Telephony.Models
{
    public class StationaryPhone : ICall
    {
        public void Call(string phoneNumber)
        {
            Console.WriteLine($"Dialing... {phoneNumber}");
        }
    }
}
