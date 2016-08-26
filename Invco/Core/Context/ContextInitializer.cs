using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Invco.Attributes;

namespace Invco.Core.Context
{
    internal class ContextInitializer
    {
        List<Type> GetAllComponents(Assembly sourceAssembly)
        {
            return sourceAssembly.GetTypes().Where(type => type.GetCustomAttributes(typeof (Component), true).Length > 0).ToList();
        }
    }
}
