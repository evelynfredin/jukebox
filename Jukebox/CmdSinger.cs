using System;
using System.Collections.Generic;
using System.Threading;

namespace Jukebox
{
    public class CmdSinger: Singer
    {
        public CmdSinger(Dictionary<string, string[]> songs) : base(songs)
        {
            Console.WriteLine("CMD Singer, whaddup!");
        }
        
        public override void Sing(string[] lyrics)
        { 
            Console.WriteLine("_♩-♪_♩-♪_");
            foreach (var line in lyrics )
            {
                Console.WriteLine(line);
                Thread.Sleep(1500);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
    }
}