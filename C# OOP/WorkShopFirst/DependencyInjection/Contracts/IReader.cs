using DependencyInjection.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.Contracts
{
    public interface IReader
    {
        Position ReadKey();
        string ReadLine();
    }
}
