using System;
using System.Collections.Generic;

namespace Jukebox
{
    public abstract class Singer
    {
        private Dictionary<string, string[]> songs;

        protected Singer(Dictionary<string, string[]> songs)
        {
            this.songs = songs;
        }

        public List<string> GetTitles()
        {
            return new(songs.Keys);
        }

        public int SongCount()
        {
            return songs.Count;
        }

        public string[] GetSong(string title)
        {
            return songs[title];
        }
        
        public abstract void Sing(string title);
    }
}