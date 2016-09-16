# INVCO! Opps... Suggest a better name please.

INVCO is a simple Inversion of Control (IoC) container that supports Dependency Injection (DI) in .Net applications. (Well I've been a Spring/Java developer for quite a good time. This framework is inspired by DI in Spring framework).
Basic useful feature list:

 * Flexibility to choose between Generics and runtime types to resolve dependencies.
 * Singletone instants.
 * Easy integration using Nuget.
 * Zero dependencies and it will always be like this.


Few feature that are at the implementation stage,

 * Attribute based dependency resolving (like annotations in Spring).
 * XML configuration driven DI.
 * Integration of logging.
 * A proper application lifecycle ;)

So let's get started. Install this with Package Manager:

```javascript
PM> Install-Package Invco
```

Find this on [NuGet Gallery](https://www.nuget.org/packages/Invco/).

Example usage:

```javascript
using System;
using Invco.Controllers;

namespace Invco
{
    class INVCOTest
    {
        public void InitApp()
        {
        	// Register your dependencies like this.
            IoCController.Register<IInterface, Implementation>();
			
            // Resolve your dependencies like this.
            IServiceProvider serviceProvider = IoCController.Resolve<IInterface>();
        }
    }
}
```

Always value suggestions and new feature requests either vis this repo or [@isurusiri](http://twitter.com/isurusiri).