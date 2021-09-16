using DependencyInjection.DI.Attributes;
using DependencyInjection.DI.Containers;
using System;
using System.Linq;
using System.Reflection;

namespace DependencyInjection.DI
{
    public class Injector
    {
        private IContainer container;
        public Injector(IContainer container)
        {
            this.container = container;
        }

        public TClass Inject<TClass>()
        {
            if (!HasCtorInjection<TClass>())
            {
                return (TClass)Activator.CreateInstance(typeof(TClass));
                //throw new ArgumentException("The class has no ctor annoted " +
                //"with the [Inject] atribute");
            }
            return CreateCtorInjection<TClass>();
        }
        private TClass CreateCtorInjection<TClass>()
        {
            ConstructorInfo[] ctors = typeof(TClass).GetConstructors();

            if (ctors.Length > 1)
            {
                throw new ArgumentException("Only 1 ctor is allowed");
            }
            foreach (ConstructorInfo constructor in ctors)
            {
                //if (constructor.GetCustomAttribute(typeof(Inject), true) == null)
                //{
                //    continue;
                //}
                ParameterInfo[] ctorParams = constructor.GetParameters();
                object[] constructorParamObjects = new object[ctorParams.Length];
                int i = 0;
                //Ilogger,IReader
                foreach (ParameterInfo paramInfo in ctorParams)
                {
                    Type interfaceType = paramInfo.ParameterType;
                    Type implementationType = container.GetMapping(interfaceType);
                    object implementationInstance;
                    if (implementationType == null)
                    {
                        var implementationPair = container.GetCustomMapping(interfaceType);
                        implementationInstance = implementationPair.Value();
                    }
                    else
                    {
                        MethodInfo injectMethod = typeof(Injector).GetMethod("Inject");
                        injectMethod = injectMethod.MakeGenericMethod(implementationType);

                        implementationInstance = injectMethod.Invoke(this, new object[] { });
                    }
                    constructorParamObjects[i++] = implementationInstance;

                }

                return (TClass)Activator.CreateInstance(typeof(TClass), constructorParamObjects);
            }

            return default;
        }
        private bool HasCtorInjection<TClass>()
        {
            return typeof(TClass).GetConstructors()
                .Any(c => c.GetParameters().Length != 0);
        }
    }
}
