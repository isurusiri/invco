using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invco.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Inject : Attribute
    {
        public Type Contract { get; set; }
        public Type Implementation { get; set; }
    }
}
