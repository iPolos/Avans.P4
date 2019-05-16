using System;
using Autofac;

namespace AV.DoToo.KlasB
{
    public static class Resolver
    {
        private static IContainer container;

        public static void Initialize(IContainer container)
        {
            // this?
            Resolver.container = container;
        }

        public static T Resolve<T>() {
            return container.Resolve<T>();
        }
    }
}
