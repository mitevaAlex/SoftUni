using SoftUniDI_Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniDI_Framework.Injectors
{
    public class DependencyInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}
