using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    static class IoC
    {
        private static IContainer container;
        private static ContainerBuilder builder;

        static IoC()
        {
            builder = new ContainerBuilder();
        }

        public static void Register<TInterface, TImplementation>()
        {
            builder.RegisterType<TImplementation>().As<TInterface>();
        }

        public static void Register<TImplementation>()
        {
            builder.RegisterType<TImplementation>();
        }

        public static void Build()
        {
            container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}
