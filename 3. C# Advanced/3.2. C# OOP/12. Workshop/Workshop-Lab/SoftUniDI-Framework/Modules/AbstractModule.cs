using SoftUniDI_Framework.Attributes;
using SoftUniDI_Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniDI_Framework.Modules
{
    public abstract class AbstractModule : IModule
    {
        private IDictionary<Type, Dictionary<string, Type>> implementations;
        private IDictionary<Type, object> instances;

        protected AbstractModule()
        {
            implementations = new Dictionary<Type, Dictionary<string, Type>>();
            instances = new Dictionary<Type, object>();
        }

        public abstract void Configure();

        protected void CreateMapping<TInterface, TImplemantation>()
        {
            Type @interface = typeof(TInterface);
            Type implementation = typeof(TImplemantation);
            if (!implementations.ContainsKey(typeof(TInterface)))
            {
                implementations[@interface] = new Dictionary<string, Type>();
            }

            implementations[@interface].Add(implementation.Name, implementation);
        }

        public Type GetMapping(Type @interface, object attribute)
        {
            Dictionary<string, Type> implementation = implementations[@interface];
            Type type = null;

            if (attribute is InjectAttribute)
            {
                if (implementation.Count == 1)
                {
                    type = implementation.Values.First();
                }
                else
                {
                    throw new ArgumentException($"No available mapping for class: {@interface.FullName}");
                }
            }
            else if (attribute is NamedAttribute namedAttr)
            {
                string dependencyName = namedAttr.Name;
                type = implementation[dependencyName];
            }

            return type;
        }

        public object GetInstance(Type implementation)
        {
            instances.TryGetValue(implementation, out object value);
            return value;
        }

        public void SetInstance(Type implementation, object instance)
        {
            if (!instances.ContainsKey(implementation))
            {
                instances.Add(implementation, instance);
            }
        }
    }
}
