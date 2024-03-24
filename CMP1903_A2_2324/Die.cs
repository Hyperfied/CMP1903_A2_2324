using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    internal class Die
    {
        private int currentValue;

        public int Roll(Random rand)
        {
            currentValue = rand.Next(0, 7);
            return currentValue;
        }
    }
}
