using HepsiBurada.MarsRover.Core.Contracts;
using System.Collections.Generic;

namespace HepsiBurada.MarsRover.Core
{
    public class PlateauGrid : IPlateauGrid
    {
        public int GridX { get; set; }
        public int GridY { get; set; }
        public bool CheckInit { get; private set; }
        public IList<IRover> Rovers { get; set; }

        public PlateauGrid()
        {
            this.Rovers = new List<IRover>();
        }

        public PlateauGrid(int gridX, int gridY)
        {
            GridX = gridX;
            GridY = gridY;
        }

        public bool Initialize(string gridSizeInput)
        {
            this.CheckInit = false;
            if (!string.IsNullOrWhiteSpace(gridSizeInput))
            {
                var gridSize = gridSizeInput.Split(' ');
                if (gridSize.Length == 2)
                {
                    int gridX;
                    if (int.TryParse(gridSize[0], out gridX))
                    {
                        int gridY;
                        if (int.TryParse(gridSize[1], out gridY))
                        {
                            this.GridX = gridX;
                            this.GridY = gridY;
                            this.CheckInit = true;
                        }
                    }

                }
            }
            return this.CheckInit;
        }
    }
}
