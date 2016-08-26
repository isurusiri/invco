using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Invco.Attributes;
using Invco.Core.Container;

namespace Invco.Core.Context
{
    internal class ContextInitializer
    {
        public List<Type> GetAllComponents(Assembly sourceAssembly)
        {
            return sourceAssembly.GetTypes().Where(type => type.GetCustomAttributes(typeof (Component), true).Length > 0).ToList();
        }

        public void RegisterDependency(Type sourceType)
        {
            foreach (var property in sourceType.GetProperties())
            {
                var attr = (Inject[])property.GetCustomAttributes(typeof(Inject), false);
                if (attr.Length > 0)
                {
                    foreach (var inject in attr)
                    {
                        // have a possiblity of getting duplicated entries. to be decide.
                        IoCContainer.Register(inject.Contract, inject.Implementation);
                    }
                }
            }
        }
    }
}
