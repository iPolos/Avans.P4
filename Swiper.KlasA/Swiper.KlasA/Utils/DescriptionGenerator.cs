using System;
using System.Linq;

namespace Swiper.KlasA.Utils
{
    public class DescriptionGenerator
    {
        private string[] _adjectives = { "mooie", "leuke", "grappige", "avocadoachtige", "prachtige", "achterlijke" };
        private string[] _other = { "avocado", "laptop", "waterfles", "tafel", "stoel", "luchtballon" };

        private static Random random = new Random();

        public string Generate()
        {
            var a = _adjectives[random.Next(_adjectives.Count())];
            var b = _other[random.Next(_other.Count())];

            return $"Een {a} {b}";
        }
    }
}
