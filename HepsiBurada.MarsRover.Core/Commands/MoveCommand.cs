using HepsiBurada.MarsRover.Core.Contracts;

namespace HepsiBurada.MarsRover.Core.Commands
{
    public class MoveCommand : ICommand
    {
        IRover rover;

        public MoveCommand(IRover rover)
        {
            this.rover = rover;
        }

        public void Process()
        {
            this.rover.Move();
        }
    }
}
