using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
	public class Position
	{
		public int X { get; set; }
		
		public int Y { get; set; }

		public Position(int x, int y) => (X, Y) = (x, y);

		public Position(Position position) : this(position.X, position.Y) { }

		public static bool operator ==(Position left, Position right) => left.X == right.X && left.Y == right.Y;
		
		public static bool operator !=(Position left, Position right) => !(left == right);

		public override bool Equals(object? o) => (Position)o == this;

		public override int GetHashCode() => base.GetHashCode();
	}
}
