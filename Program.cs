using Pacman;

namespace PacmanApp
{
	public class Program
	{
		public static void Main()
		{
			Console.Clear();
			//Map map = new Map(30, 15);
			Map map = new Map("map1.txt");

			map.Start();
			map.Update();


		}
	}
}