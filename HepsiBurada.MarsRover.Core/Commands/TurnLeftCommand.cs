using HepsiBurada.MarsRover.Core.Contracts;

namespace HepsiBurada.MarsRover.Core.Commands
{
    public class TurnLeftCommand : ICommand
    {
        IRover rover;

        public TurnLeftCommand(IRover rover)
        {
            this.rover = rover;
        }

        public void Process()
        {
            this.rover.TurnLeft();
        }
    }
}
