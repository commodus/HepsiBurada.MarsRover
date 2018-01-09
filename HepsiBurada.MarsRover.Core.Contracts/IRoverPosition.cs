using HepsiBurada.MarsRover.Core.Common.Enums;

namespace HepsiBurada.MarsRover.Core.Contracts
{
    public interface IRoverPosition
    {
        int X { get; set; }
        int Y { get; set; }
        RoverDirection Direction { get; set; }
    }
}