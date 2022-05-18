namespace Pacman
{
	public class Projectile
	{
		public Position Position;

		public char Character;

		public Projectile(Position position)
		{
			Position = new Position(position);
			Character = ' ';
		}

	}
}