using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bowlingChallenge.Utilities
{
    internal class Roller
    {
        public int RandomRoller(int pins)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, pins);
            return randomNumber;
        }
    }
}
