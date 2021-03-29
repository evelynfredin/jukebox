using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;

namespace Jukebox
{
    public class Cli
    {
        DateTime today = DateTime.Today;
        private string _username;
        private string _state;
        private Singer _singer;
        private Random rnd = new Random();

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
                    default:
                        break;
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
            Console.WriteLine("Type: 'SING' to play a song.");
            Console.WriteLine($"Type: 'LIST' to see all {_singer.SongCount()} songs in memory.");
            Console.WriteLine("Type: 'EXIT' to quit the Jukebox.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("What would you like to do?");
            CheckState();
        }

        private void Add()
        {
            while (_state != ":q")
            {
                Console.Clear();
                Console.WriteLine("What is the song title?");
                var title = Console.ReadLine();
                Console.WriteLine("Type the lyrics (':s' to save):");
                var lyrics = new List<string>();
                var line = "";
                while (true)
                {
                    line = Console.ReadLine();
                    if (line == ":s")
                    {
                        break;
                    }
                    lyrics.Add(line);
                }
                _singer.AddSong(title, lyrics.ToArray());
                _state = "";
                Console.WriteLine("New Song Added!");
                Thread.Sleep(1000);
                break;
            }
        }

        private void Shuffle()
        {
            Console.Clear();
            Console.WriteLine("Shuffling playlist...");
            Thread.Sleep(2000);
            var shuffling = rnd.Next(0, _singer.GetTitles().Count);
            var shuffledSong = _singer.GetSong(_singer.GetTitles()[shuffling]);
            _singer.Sing(shuffledSong);
            Console.WriteLine("Done singing, redirecting you back.");
            Thread.Sleep(3000);
        }

        private void List()
        {
            while (_state != ":q")
            {
                Console.Clear();
                Console.WriteLine("****************");
                Console.WriteLine("==== TITLES ====");
                Console.WriteLine("****************");
                Console.ForegroundColor = ConsoleColor.White;
                _singer.GetTitles().ForEach(title => Console.WriteLine(title));
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Type ':q' to go back to the main menu.");
                _state = Console.ReadLine();
            }

            MainMenu();
        }

        private void Sing()
        {
            while (_state != ":q")
            {
                Console.Clear();
                Console.WriteLine("*********************");
                Console.WriteLine("==== SELECT SONG ====");
                Console.WriteLine("*********************");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter song name or ':q' to go back to main menu.");
                _state = Console.ReadLine();
                if (_state != ":q")
                {
                    Console.WriteLine("Looking for song...");
                    Thread.Sleep(3000);
                    var lyrics = _singer.GetSong(_state);
                    if (lyrics == null)
                    {
                        Console.WriteLine($"Song {_state} not found.");
                        Thread.Sleep(1000);
                        continue;
                    }

                    Console.Clear();
                    Console.WriteLine($"Now playing {_state}.");
                    _singer.Sing(lyrics);
                    Console.WriteLine("Applause!");
                    Thread.Sleep(3000);
                }
            }

            MainMenu();
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