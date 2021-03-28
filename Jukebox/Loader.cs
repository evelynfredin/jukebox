using System.Collections.Generic;

namespace Jukebox
{
    public class Loader
    {
        public static Dictionary<string, string[]> Load()
        {
            var dictionary = new Dictionary<string, string[]>();
            
            dictionary.Add("Master Of Puppets", new []
            {
                "Master!",
                "Master!",
                "Master of puppets",
                "I'm pulling your strings"
            });
            
            dictionary.Add("Best Song", new []
            {
                "We're no strangers to love",
                "You know the rules and so do I",
                "A full commitment's what I'm thinking of",
                "You've been Rick-rolled!"
            });
            
            dictionary.Add("Karma Police", new []
            {
                "Karma police",
                "Arrest this man",
                "He talks in maths",
                "He buzzes like a fridge"
            });
            return dictionary;
        }
    }
}