using System;
using System.Collections.Generic;
using System.Threading;
using System.IO.Ports;


namespace Jukebox
{
    public class ArduinoSinger: Singer
    {
        private SerialPort port = new SerialPort("/dev/cu.usbmodem1101", 9600, Parity.None, 8, StopBits.One);
        
        public ArduinoSinger(Dictionary<string, string[]> songs) : base(songs)
        {
            Console.WriteLine("Raspberry Pi is for noobs!");
        }
        public override void Sing(string[] lyrics)
        {
            if (!port.IsOpen)
            {
                port.Open();
            }

            Thread.Sleep(2000);
            Console.WriteLine("_♩-♪_♩-♪_");
            foreach (var line in lyrics )
            {
                port.WriteLine(line);
                Thread.Sleep(1500);
            }
            port.WriteLine("");
            port.Close();
        }
    }
    
}
