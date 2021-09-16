using DependencyInjection.DI;
using DependencyInjection.DI.Containers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public class GlobalInjector
    {

        // Singleton pattern
        private static Injector instance;
        public static Injector Instance
        {
            get
            {
                if (instance == null)
                {
                    SnakeGameContainer container = new SnakeGameContainer();
                    container.ConfigureServices();
                    instance = new Injector(container);
                }

                return instance;
            }
        }
    }
}
