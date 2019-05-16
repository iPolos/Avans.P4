using System;
namespace AV.DoToo.KlasB.Droid
{
    public class Bootstrapper : AV.DoToo.KlasB.Bootstrapper
    {
        public static void Init()
        {
            var instance = new Bootstrapper();
        }
    }
}
