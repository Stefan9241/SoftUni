using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core.Models
{
    public class CommandFactory : ICommandFactory
    {
        private const string CommandSuffix = "Command";
        public ICommand CreateCommand(string command)
        {
            Type type = Assembly.GetEntryAssembly().GetTypes()
                .FirstOrDefault(x => x.Name == $"{command}{CommandSuffix}");

            if (type == null)
            {
                throw new ArgumentException($"{command} cannot be null");
            }
            ICommand instance = (ICommand)Activator.CreateInstance(type);

            return instance;
        }
    }
}
