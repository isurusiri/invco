using Invco.Container;
using System;

namespace Invco.Controllers
{
    public class IoCController
    {
        /// <summary>
        /// Records all interfaces and their implementations.
        /// Can be used when the types are known at the compilation time.
        /// </summary>
        /// <typeparam name="TContract">Interface of the dependency</typeparam>
        /// <typeparam name="TImplementation">Implementation of the dependency</typeparam>
        public static void Register<TContract, TImplementation>()
        {
            IoCContainer.Register<TContract, TImplementation>();
        }

        /// <summary>
        /// Records all interfaces and their implementations.
        /// Can be used when the types are unknown at the compilation time.
        /// </summary>
        /// <param name="contract">Interface of the dependency</param>
        /// <param name="implementation">Implementation of the dependency</param>
        public static void Register(Type contract, Type implementation)
        {
            IoCContainer.Register(contract, implementation);
        }

        /// <summary>
        /// Resolves dependencies for a given type.
        /// Can be used when the types are known at the compilation time.
        /// </summary>
        /// <typeparam name="T">Type to be resolved</typeparam>
        /// <returns>Resolved implementation of the specified type</returns>
        public static T Resolve<T>()
        {
            return IoCContainer.Resolve<T>();
        }

        /// <summary>
        /// Resolves dependencies for a given type.
        /// Can be used when the types are unknown at the compilation time.
        /// </summary>
        /// <param name="implementation">Type to be resolved</param>
        /// <returns>Resolved implementation of the specified type</returns>
        public static Type Resolve(Type implementation)
        {
            return IoCContainer.Resolve(implementation);
        }
    }
}
