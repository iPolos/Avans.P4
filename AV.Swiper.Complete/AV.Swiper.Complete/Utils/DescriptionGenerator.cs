using System;
using System.Linq;

namespace AV.Swiper.Complete.Utils
{
    public static class DescriptionGenerator
    {
        private static string[] _adjectives = { "nice", "horrible", "great", "terribly old", "brand new" };
        private static string[] _other = { "picture of grandpa", "car", "photo of a forest", "duck" };

        private static Random random = new Random();

        public static string Generate()
        {
            var a = _adjectives[random.Next(_adjectives.Count())];
            var b = _other[random.Next(_other.Count())];
            return $"A {a} {b}";
        }
    }
}
