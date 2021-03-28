using System;
using System.Collections.Generic;

namespace Jukebox
{
    public class CmdSinger: Singer
    {
        public CmdSinger(Dictionary<string, string[]> songs) : base(songs)
        {
            Console.WriteLine("CMD Singer, whaddup!");
        }
        
        public override void Sing(string title)
        { 
            Console.WriteLine("Fix the sing method broh!");
        }
    }
}