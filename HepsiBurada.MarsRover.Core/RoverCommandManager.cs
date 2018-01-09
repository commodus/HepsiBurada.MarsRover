using HepsiBurada.MarsRover.Core.Contracts;
using System.Collections.Generic;

namespace HepsiBurada.MarsRover.Core
{
    public class RoverCommandManager : IRoverCommandManager
    {
        public IRover Rover { get; set; }
        private Queue<ICommand> commands = new Queue<ICommand>();

        public RoverCommandManager(IRover rover)
        {
            this.Rover = rover;
        }

        public void AddCommand(ICommand command)
        {
            commands.Enqueue(command);
        }

        public void ProcessCommands()
        {
            while (commands.Count > 0)
            {
                ICommand command = commands.Dequeue();
                command.Process();
            }
        }
    }
}
