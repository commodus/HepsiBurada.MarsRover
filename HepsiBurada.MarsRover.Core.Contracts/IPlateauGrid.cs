using System.Collections.Generic;

namespace HepsiBurada.MarsRover.Core.Contracts
{
    public interface IPlateauGrid
    {
        int GridX { get; set; }
        int GridY { get; set; }
        bool CheckInit { get; }
        bool Initialize(string gridSizeInput);
        IList<IRover> Rovers { get; set; }
    }
}
