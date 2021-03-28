using System.Collections.Generic;

namespace Jukebox
{
    public class Loader
    {
        public static Dictionary<string, string[]> Load()
        {
            var dictionary = new Dictionary<string, string[]>();
            
            dictionary.Add("Trapped", new []
            {
                "I am the lyrics to Trapped, yeah!",
                "I'm still the lyrics to Trapped"
            });
            
            dictionary.Add("Turtleneck and Blazer", new []
            {
                "Blazer, yeah!",
                "Turtle necks, yeah"
            });
            return dictionary;
        }
    }
}