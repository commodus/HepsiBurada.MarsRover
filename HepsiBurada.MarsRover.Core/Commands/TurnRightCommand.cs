using HepsiBurada.MarsRover.Core.Contracts;

namespace HepsiBurada.MarsRover.Core.Commands
{
    public class TurnRightCommand : ICommand
    {
        IRover rover;

        public TurnRightCommand(IRover rover)
        {
            this.rover = rover;
        }

        public void Process()
        {
           this.rover.TurnRight();
        }
    }
}
