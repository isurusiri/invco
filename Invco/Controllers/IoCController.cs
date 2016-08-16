using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invco.Container;

namespace Invco.Controllers
{
    public class IoCController
    {
        public static void Register<TContract, TImplementation>()
        {
            IoCContainer.Register<TContract, TImplementation>();
        }

        public static T Resolve<T>()
        {
            return IoCContainer.Resolve<T>();
        }
    }
}
