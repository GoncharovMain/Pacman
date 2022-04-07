using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public interface Resource
    {
        public char Character { get; }
        public int Counter { get; }
        public void ToIncrease();
    }
}
