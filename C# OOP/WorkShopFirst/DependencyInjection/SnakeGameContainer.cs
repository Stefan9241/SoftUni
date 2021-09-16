using DependencyInjection.Containers;
using DependencyInjection.Contracts;
using DependencyInjection.Drawers;
using DependencyInjection.Loggers;
using DependencyInjection.Movers;
using DependencyInjection.Readers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.DI.Containers
{
    public class SnakeGameContainer : AbstractContainer
    {
        public override void ConfigureServices()
        {
            CreateMapping<ILogger, FileLogger>(()=> new FileLogger("../../../logs.txt"));
            CreateMapping<IReader, ConsoleReader>();
            CreateMapping<IDrawer, ConsoleDrawer>();
            CreateMapping<IMover, SlowMover>();
            //CreateMapping<IMover, FastMover>();
        }
    }
}
