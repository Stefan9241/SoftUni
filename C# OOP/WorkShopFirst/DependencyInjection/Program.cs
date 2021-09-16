using DependencyInjection.DI;
using DependencyInjection.DI.Containers;
using System;

namespace DependencyInjection
{
    public class Program
    {
        static void Main(string[] args)
        {
            Engine engine = GlobalInjector.Instance.Inject<Engine>();

            engine.Start();
            engine.End();
        }
    }
}
