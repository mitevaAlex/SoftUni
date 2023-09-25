using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniDI_Framework.Interfaces
{
    public interface IModule
    {
        void Configure();

        Type GetMapping(Type @interface, object attribute);

        object GetInstance(Type implementation);

        void SetInstance(Type implementation, object instance);
    }
}
