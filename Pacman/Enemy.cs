using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Enemy : Person
    {
        public Position Position { get; set; }
        public char Character { get; private set; }
        public Enemy(int x, int y)
        {
            Position = new Position(x, y);
            Character = '%';
        }
    }
}
