using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Dollar : Resource
    {
        public char Character { get; private set; }
        public int Counter { get; private set; }
        public Dollar()
        {
            Character = '$';
            Counter = 0;
        }
        public void ToIncrease()
        {
            Counter++;
        }
    }
}
