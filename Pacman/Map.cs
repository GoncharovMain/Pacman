using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Map
    {
        private int _width;
        private int _height;
        private char[,] _map;

        private int _maxResource = 5;

        private char _wall = '#';
        private char _clearPlace = ' ';

        private Random random = new Random();

        private Resource _resource;

        private Dog _dog;
        private Enemy _enemy;
        private Enemy _enemy2;
        
        public Map(string src)
        {
            List<string> map = new List<string>();
            string line = String.Empty;

            using (StreamReader reader = new StreamReader(src))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    map.Add(line);
                }
            }
            _height = map.Count();
            _width = map[0].Length;

            for (int i = 1; i < _height; i++)
            {
                if (_width < map[i].Length)
                    _width = map[i].Length;
            }

            _map = new char[_height, _width];

            for (int i = 0; i < _height; i++)
                for (int j = 0; j < _width; j++)
                    _map[i, j] = map[i][j];

            _resource = new Euro();

            GenerateResource(_resource);

            _dog = new Dog(2, 2);
            _enemy = new Enemy(_height - 2, _width - 2);
            _enemy2 = new Enemy(_height - 3, _width - 3);
        }

        public Map(int width, int height)
        {
            _width = width;
            _height = height;

            _map = new char[_height, _width];

            DrawMap();

            _resource = new Euro();

            GenerateResource(_resource);

            _dog = new Dog(2, 2);
            _enemy = new Enemy(_height - 2, _width - 2);
            _enemy2 = new Enemy(_height - 3, _width - 3);
        }

        private void DrawMap()
        {
            for (int i = 0; i < _height; i++)
                for (int j = 0; j < _width; j++)
                    _map[i, j] = _clearPlace;

            DrawWalls();
        }
        private void DrawWalls()
        {
            for (int i = 0; i < _width; i++)
            {
                _map[0, i] = _wall;
                _map[_height - 1, i] = _wall;
            }

            for (int j = 0; j < _height; j++)
            {
                _map[j, 0] = _wall;
                _map[j, _width - 1] = _wall;
            }

            for (int i = 0; i < 20; i++)
            {
                (int x, int y) = (random.Next(0, _height), random.Next(0, _width));
                _map[x, y] = _wall;
            }
        }
        private void GenerateResource(Resource resource)
        {
            for (int i = 0; i < _maxResource; i++)
            {
                (int x, int y) = (random.Next(1, _height - 1), random.Next(1, _width - 1));
                _map[x, y] = resource.Character;
            }
        }
        private void PrintMap()
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                    Console.Write(_map[i, j]);
                Console.WriteLine();
            }
        }
       
        private async void MoveRandomPersonAsync(Person person) => await Task.Run(() => MoveRandom(person));
        
        private async void MovePersonAsync(Person person) => await Task.Run(() => MovePerson(person));
        
        
        private void MoveRandom(Person person)
        {
            while (true)
            {
                int key = random.Next(0, 4);

                switch (key)
                {
                    case 0:
                        if (_map[person.Position.X - 1, person.Position.Y] != _wall)
                        {
                            person.Position.X--;
                        }
                        break;
                    case 1:
                        if (_map[person.Position.X + 1, person.Position.Y] != _wall)
                        {
                            person.Position.X++;
                        }
                        break;
                    case 2:
                        if (_map[person.Position.X, person.Position.Y - 1] != _wall)
                        {
                            person.Position.Y--;
                        }
                        break;
                    case 3:
                        if (_map[person.Position.X, person.Position.Y + 1] != _wall)
                        {
                            person.Position.Y++;
                        }
                        break;
                }
                Thread.Sleep(50);
            }
        }
        private void MovePerson(Person person)
        {
            while (true)
            { 
                ConsoleKeyInfo charKey = Console.ReadKey();

                switch (charKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (_map[person.Position.X - 1, person.Position.Y] != _wall)
                        {
                            person.Position.X--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (_map[person.Position.X + 1, person.Position.Y] != _wall)
                        {
                            person.Position.X++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (_map[person.Position.X, person.Position.Y - 1] != _wall)
                        {
                            person.Position.Y--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (_map[person.Position.X, person.Position.Y + 1] != _wall)
                        {
                            person.Position.Y++;
                        }
                        break;
                }

                if (_map[person.Position.X, person.Position.Y] == _resource.Character)
                {
                    _map[person.Position.X, person.Position.Y] = _clearPlace;
                    _resource.ToIncrease();
                }
            }
            
        }

        private string DrawAllMap()
        {
            while (true)
            {
                PrintInfoResource();

                PrintMap();

                PrintPerson(_enemy, ConsoleColor.Red);
                PrintPerson(_enemy2, ConsoleColor.Yellow);
                PrintPerson(_dog, ConsoleColor.Green);

                Thread.Sleep(100);

                if (_enemy.Position == _dog.Position || _enemy2.Position == _dog.Position)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    return "Game over. Loser. lol!.!.)";
                }

                if (_resource.Counter >= _maxResource)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    return "Well done!";
                }
            }
        }
        private void PrintPerson(Person person)
        {
            Console.SetCursorPosition(person.Position.Y, person.Position.X);
            Console.Write(person.Character);
        }
        private void PrintPerson(Person person, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            PrintPerson(person);
            Console.ResetColor();
        }
        private void PrintInfoResource()
        {
            Console.SetCursorPosition(_width + 2, 0);
            Console.Write($"Сумка: {_resource.Counter} {_resource.Character}");
        }
        public void Start() => PrintMap();

        public void Update()
        {
            Console.CursorVisible = false;

            MovePersonAsync(_dog);
            MoveRandomPersonAsync(_enemy);
            //MoveRandomPersonAsync(_enemy2);


            string message = DrawAllMap();

            int biasMessage = message.Length / 2;

            (int centerX, int centerY) = (_width / 2 - biasMessage, _height / 2);

            Console.SetCursorPosition(centerX, centerY);
            Console.Write(message.ToUpper());
        }
        public void Save(string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < _height; i++)
                {
                    for (int j = 0; j < _width; j++)
                        writer.Write(_map[i, j]);
                    writer.WriteLine();
                }
            }
        }
    }
}
