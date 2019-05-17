using System;
using System.Linq;

namespace Swiper.KlasB.Utils
{
    public class DescriptionGenerator
    {
        private string[] _adjectives = { "mooie", "prachtige", "achterlijke", "kwalitatief uitermate teleurstellende", "toppe" };
        private string[] _other = { "tafel", "avocado", "mango", "muis", "boekje", "Daenerys" };

        private static Random random = new Random();

        public string Generate()
        {
            var a = _adjectives[random.Next(_adjectives.Count())];
            var b = _other[random.Next(_other.Count())];

            return $"Een {a} {b}";
            // return "Een " + a + " " + b;
        }
    }
}
