using SoftUniDI_Framework.Attributes;
using SoftUniDI_Framework.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace SoftUniDI_Framework.Injectors
{
    public class Injector
    {
        private IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }

        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass)
                .GetFields((BindingFlags)62)
                .Any(field => field.GetCustomAttributes(typeof(InjectAttribute), true).Any());
        }

        private bool CheckForConstuctorInjection<TClass>()
        {
            return typeof(TClass)
                .GetConstructors()
                .Any(ctor => ctor.GetCustomAttributes(typeof(InjectAttribute), true).Any());
        }

        private TClass CreateConstructorInjection<TClass>()
        {
            Type desiredClass = typeof(TClass);
            if (desiredClass == null)
            {
                return default(TClass);
            }

            ConstructorInfo[] ctors = desiredClass.GetConstructors();
            foreach (ConstructorInfo ctor in ctors)
            {
                if (!CheckForConstuctorInjection<TClass>())
                {
                    continue;
                }

                InjectAttribute injectAttr = (InjectAttribute)ctor
                    .GetCustomAttributes(typeof(InjectAttribute), true)
                    .FirstOrDefault();
                ParameterInfo[] parameters = ctor.GetParameters();
                object[] ctorParams = new object[parameters.Length];

                int i = 0;
                foreach (ParameterInfo parameter in parameters)
                {
                    NamedAttribute namedAttr = (NamedAttribute)parameter
                        .GetCustomAttribute(typeof(NamedAttribute));
                    Type type = parameter.ParameterType;
                    Type dependency = null;

                    if (namedAttr == null)
                    {
                        dependency = module.GetMapping(type, injectAttr);
                    }
                    else
                    {
                        dependency = module.GetMapping(type, namedAttr);
                    }

                    if (parameter.ParameterType.IsAssignableFrom(dependency))
                    {
                        object instance = module.GetInstance(dependency);
                        if (instance != null)
                        {
                            ctorParams[i++] = instance;
                        }
                        else
                        {
                            instance = Activator.CreateInstance(dependency);
                            ctorParams[i++] = instance;
                            module.SetInstance(type, instance);
                        }
                    }
                }

                return (TClass)Activator.CreateInstance(desiredClass, ctorParams);
            }

            return default(TClass);
        }

        private TClass CreateFieldInjection<TClass>()
        {
            Type desiredClass = typeof(TClass);
            object desiredClassInstance = module.GetInstance(desiredClass);
            if (desiredClassInstance == null)
            {
                desiredClassInstance = Activator.CreateInstance(desiredClass);
                module.SetInstance(desiredClass, desiredClassInstance);
            }

            FieldInfo[] fields = desiredClass.GetFields((BindingFlags)62);
            foreach (FieldInfo field in fields)
            {
                if (field.GetCustomAttributes(typeof(InjectAttribute), true).Any())
                {
                    InjectAttribute injectAttr = (InjectAttribute)field
                        .GetCustomAttributes(typeof(InjectAttribute), true)
                        .FirstOrDefault();
                    Type dependency = null;

                    NamedAttribute namedAttr = (NamedAttribute)field
                        .GetCustomAttribute(typeof(NamedAttribute), true);
                    Type type = field.FieldType;
                    if (namedAttr == null)
                    {
                        dependency = module.GetMapping(type, injectAttr);
                    }
                    else
                    {
                        dependency = module.GetMapping(type, namedAttr);
                    }

                    if (type.IsAssignableFrom(dependency))
                    {
                        object instance = module.GetInstance(dependency);
                        if (instance == null)
                        {
                            instance = Activator.CreateInstance(dependency);
                            module.SetInstance(dependency, instance);
                        }

                        field.SetValue(desiredClassInstance, instance);
                    }
                }
            }

            return (TClass)desiredClassInstance;
        }

        public TClass Inject<TClass>()
        {
            bool hasCtorAttr = CheckForConstuctorInjection<TClass>();
            bool hasFieldAttr = CheckForFieldInjection<TClass>();
            if (hasCtorAttr && hasFieldAttr)
            {
                throw new ArgumentException("There must be only field or constructor annotated with Inject attribute");
            }

            if (hasCtorAttr)
            {
                return CreateConstructorInjection<TClass>();
            }
            else if (hasFieldAttr)
            {
                return CreateFieldInjection<TClass>();
            }

            return default(TClass);
        }
    }
}
