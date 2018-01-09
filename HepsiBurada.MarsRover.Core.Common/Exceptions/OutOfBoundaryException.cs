using System;

namespace HepsiBurada.MarsRover.Core.Common.Exceptions
{
    public class OutOfBoundaryException : Exception
    {
        public OutOfBoundaryException(int boundary, int actual, string grid)
            : base($"Out of boundary on grid {grid}. (Boundary limit: {boundary}, Actual: {actual})")
        {
            Boundary = boundary;
            Actual = actual;
            Grid = grid;
        }

        public int Boundary { get; set; }
        public int Actual { get; set; }
        public string Grid { get; set; }
    }
}
