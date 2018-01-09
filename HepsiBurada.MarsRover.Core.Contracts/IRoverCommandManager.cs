namespace HepsiBurada.MarsRover.Core.Contracts
{
    public interface IRoverCommandManager
    {
        IRover Rover { get; set; }
        void AddCommand(ICommand command);
        void ProcessCommands();
    }
}
