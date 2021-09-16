using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.DI.Containers
{
    public interface IContainer
    {
        void ConfigureServices();
        void CreateMapping<TInterfaceType,TImplementationType>();
        void CreateMapping<TInterfaceType,TImplementationType>
            (Func<object> creationFunc);
        Type GetMapping(Type TInterfaceType);

        public KeyValuePair<Type, Func<object>> GetCustomMapping(Type interfaceType);
    }
}
