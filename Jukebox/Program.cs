using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading;

namespace Jukebox
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var songs = Loader.Load();
            var singer = new CmdSinger(songs);
            var cli = new Cli(singer);
            cli.Start();
        }
    }
}