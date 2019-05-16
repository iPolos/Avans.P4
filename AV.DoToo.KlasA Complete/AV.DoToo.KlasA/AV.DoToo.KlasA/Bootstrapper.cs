using System;
using System.Linq;
using System.Reflection;
using Autofac;
using AV.DoToo.KlasA.Repositories;
using AV.DoToo.KlasA.ViewModels;
using Xamarin.Forms;

namespace AV.DoToo.KlasA
{
    public abstract class Bootstrapper
    {
        protected ContainerBuilder ContainerBuilder { get; private set; }

        public Bootstrapper()
        {
            Initialize();
            FinishInitialization();
        }

        protected virtual void Initialize()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            ContainerBuilder = new ContainerBuilder();

            foreach (var type in currentAssembly.DefinedTypes.Where( e => 
                                                        e.IsSubclassOf(typeof(Page)) ||
                                                        e.IsSubclassOf(typeof(ViewModel))))
            {
                ContainerBuilder.RegisterType(type.AsType());
            }

            ContainerBuilder.RegisterType<ToDoItemRepository>().SingleInstance();
        }

        private void FinishInitialization()
        {
            var container = ContainerBuilder.Build();
            Resolver.Initialize(container);
        }
    }
}
