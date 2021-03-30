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
            var cmd = new CmdSinger(songs);
            var uno = new ArduinoSinger(songs);
            var cli = new Cli(cmd);
            cli.Start();
        }
    }
}