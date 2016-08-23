using Invco.Container;
using System;

namespace Invco.Controllers
{
    public class IoCController
    {
        public static void Register<TContract, TImplementation>()
        {
            IoCContainer.Register<TContract, TImplementation>();
        }

        public static void Register(Type contract, Type implementation)
        {
            IoCContainer.Register(contract, implementation);
        }

        public static T Resolve<T>()
        {
            return IoCContainer.Resolve<T>();
        }

        public static Type Resolve(Type implementation)
        {
            return IoCContainer.Resolve(implementation);
        }
    }
}
