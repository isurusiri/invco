using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Invco.Container
{
    /// <summary>
    /// Class that keeps a record of all dependencies.
    /// All dependencies are kept in dictionary of types.
    /// Exposes two operations, which are Registr and Resolve.
    /// </summary>
    internal static class IoCContainer
    {
        static readonly IDictionary<Type, Type> Types = new Dictionary<Type, Type>();

        /// <summary>
        /// Registers dependencies with their interface and implementation.
        /// This method can be used when the contract and implementation is
        /// know at the compile time.
        /// </summary>
        /// <typeparam name="TContract">Interface of the dependency</typeparam>
        /// <typeparam name="TImplementation">Implementation of the dependency</typeparam>
        [Obsolete("Registering and Resolving dependencies with generic types is discouraged from V1.0.5")]
        public static void Register<TContract, TImplementation>()
        {
            Types[typeof (TContract)] = typeof (TImplementation);
        }

        /// <summary>
        /// Register dependencies with their interface and implementation.
        /// This method can be used when the contract and implementation is
        /// to be determind during the executioin.
        /// </summary>
        /// <param name="contract">Interface of the dependency</param>
        /// <param name="implementatioin">Implementation of the dependency</param>
        public static void Register(Type contract, Type implementatioin)
        {
            Types[contract] = implementatioin;
        }

        /// <summary>
        /// Interface that can be used to resolve a dependency.
        /// This interface can be used when the dependency implementation is
        /// know at the compile time.
        /// </summary>
        /// <typeparam name="T">Genric type of the dependency to be resolved</typeparam>
        /// <returns>Resolved implementation of a dependency</returns>
        [Obsolete("Registering and Resolving dependencies with generic types is discouraged from V1.0.5")]
        public static T Resolve<T>()
        {
            return (T) ResolveType(typeof (T));
        }

        /// <summary>
        /// Interface that can be used to resolve a dependency.
        /// This interface can be used when the dependency implementatioin is
        /// not know at the compile time.
        /// </summary>
        /// <param name="implementation">Type of the dependency to be resolved</param>
        /// <returns>Resolved implementation of a dependency</returns>
        public static Type Resolve(Type implementation)
        {
            return (Type) ResolveType(implementation);
        }

        /// <summary>
        /// Resolves dependencies with all internal dependencies.
        /// This method only supports constructor injection.
        /// Get all constructor parameters and resolves those parameters.
        /// </summary>
        /// <param name="contract">Intercface type of the dependency</param>
        /// <returns>Resolved implementation of a dependency</returns>
        private static object ResolveType(Type contract)
        {
            Type implementation = Types[contract];
            ConstructorInfo constructor = implementation.GetConstructors()[0];
            ParameterInfo[] constructorParameters = constructor.GetParameters();

            if (constructorParameters.Length == 1)
            {
                return Activator.CreateInstance(implementation);
            }

            List<object> parameters = new List<object>(constructorParameters.Length);
            parameters.AddRange(constructorParameters.Select(parameterInfo => Resolve(parameterInfo.ParameterType)));

            return constructor.Invoke(parameters.ToArray());
        }
    }
}
