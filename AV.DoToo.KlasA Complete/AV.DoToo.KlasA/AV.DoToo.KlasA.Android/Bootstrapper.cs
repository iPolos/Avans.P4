using System;
namespace AV.DoToo.KlasA.Droid
{
    public class Bootstrapper : AV.DoToo.KlasA.Bootstrapper
    {
        public static void Init ()
        {
            var instance = new Bootstrapper();
        }
    }
}
