using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;

namespace Jukebox
{
    public class Cli
    {
        private static List<string> _commands = new[]
        {
            "SHUFFLE",
            "ADD",
            "LIST",
            "SING",
            "EXIT"
        }.ToList();
        
        DateTime today = DateTime.Today;
        private string _username;
        private string _state;
        private Singer _singer;

        public Cli(Singer singer)
        {
            _singer = singer;
        }

        public void Start()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("What should I call you?");
            _username = Console.ReadLine();
            MainMenu();
        }
        
        private void CheckState()
        {
            _state = Console.ReadLine();

            while (true)
            {
                var currentState = _state.ToUpper();
                if (_commands.Contains(currentState))
                {
                    switch (currentState)
                    {
                        case "ADD":
                            Add();
                            break;
                        case "SHUFFLE":
                            Shuffle();
                            break;
                        case "LIST":
                            List();
                            break;
                        case "SING":
                            Sing();
                            break;
                        case "EXIT":
                            Exit();
                            break;
                    }
                }
                break;
            }
            MainMenu();
        }

        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine($"Nice to meet you, {_username}. I am Jukebox T-1000, today is {today.ToString("d")}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Type: 'SHUFFLE' for a random song.");
            Console.WriteLine("Type: 'ADD' to create new song.");
            Console.WriteLine($"Type: 'LIST' to see all {_singer.SongCount()} songs in memory.");
            Console.WriteLine("Type: 'EXIT' to quit the Jukebox.");
            Console.WriteLine("What would you like to do?");
            CheckState();
        }

        private void Add()
        {
            Console.Clear();
            Console.WriteLine("Add");
            Thread.Sleep(1000);
        }

        private void Shuffle()
        {
            Console.Clear();
            Console.WriteLine("You be shufflin'");
            Thread.Sleep(1000);
        }

        private void List()
        {
            while (_state != ":q")
            {
                Console.Clear();
                Console.WriteLine("****************");
                Console.WriteLine("==== TITLES ====");
                Console.WriteLine("****************");
                _singer.GetTitles().ForEach(title => Console.WriteLine(title));
                Console.WriteLine();
                Console.WriteLine("Type ':q' to go back to the main menu.");
                _state = Console.ReadLine();
            }
            MainMenu();
        }

        private void Sing()
        {
            var selectSongTitle = Console.ReadLine();
            Console.WriteLine($"Im singing {selectSongTitle}");
        }
        
        private void Exit()
        {
            Console.Clear();
            Console.WriteLine("GoodBye");
            Thread.Sleep(500);
            Environment.Exit(0);   
        }
    }
}