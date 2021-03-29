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
            try
            {
                return songs[title];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void AddSong(string title, string[] lyrics)
        {
            songs.Add(title, lyrics);
        }
        
        public abstract void Sing(string[] lyrics);
    }
}