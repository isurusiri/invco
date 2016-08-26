using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invco.Core.Context
{
    internal static class ApplicationContext
    {
        public static readonly IDictionary<Type, Type> Types = new Dictionary<Type, Type>();
    }
}
