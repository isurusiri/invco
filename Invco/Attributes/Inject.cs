using System;
using Invco.General;

namespace Invco.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Inject : Attribute
    {
        public Type Contract { get; set; }
        public Type Implementation { get; set; }
        public Scopes Scope { get; set; }
    }
}
