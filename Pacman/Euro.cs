using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Euro : Resource
    {
        public char Character { get; private set; }

        public int Counter { get; private set; }
        public Euro()
        {
            Character = '€';
            Counter = 0;
        }
        public void ToIncrease()
        {
            Counter++;
        }
    }
}
