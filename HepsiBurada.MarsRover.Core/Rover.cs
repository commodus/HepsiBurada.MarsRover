using HepsiBurada.MarsRover.Core.Commands;
using HepsiBurada.MarsRover.Core.Common;
using HepsiBurada.MarsRover.Core.Common.Enums;
using HepsiBurada.MarsRover.Core.Common.Exceptions;
using HepsiBurada.MarsRover.Core.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace HepsiBurada.MarsRover.Core
{
    public class Rover : IRover
    {
        public IRoverPosition CurrentPosition { get; private set; }
        public IPlateauGrid PlateauGrid { get; set; }
        public IList<ICommand> Commands { get; set; }

        public Rover()
        {
            this.Commands = new List<ICommand>();
        }

        public Rover(IRoverPosition roverPosition, IPlateauGrid plateauGrid)
        {
            this.CurrentPosition = roverPosition;
            this.PlateauGrid = plateauGrid;
            this.Commands = new List<ICommand>();
        }

        /// <summary>
        /// Move
        /// </summary>
        public void Move()
        {
            CheckRoverIsAtValidGridBoundaries();
            this.CurrentPosition = RoverAction.Move(this.CurrentPosition);
        }

        /// <summary>
        /// Turn left
        /// </summary>
        public void TurnLeft()
        {
            this.CurrentPosition.Direction = RoverAction.TurnLeft(this.CurrentPosition.Direction);
        }

        /// <summary>
        /// Turn right
        /// </summary>
        public void TurnRight()
        {
            this.CurrentPosition.Direction = RoverAction.TurnRight(this.CurrentPosition.Direction);
        }

        /// <summary>
        /// Rover initialize
        /// </summary>
        /// <param name="roverPositionInput">Rover position input</param>
        /// <returns>Boolean</returns>
        public bool Initialize(string roverPositionInput)
        {
            var roverPosition = roverPositionInput.Split(' ');
            if (roverPosition.Length == 3)
            {
                try
                {
                    var x = int.Parse(roverPosition[0]);
                    var y = int.Parse(roverPosition[1]);

                    var direction = roverPosition[2].ToUpper();
                    if (direction == "N" || direction == "S" || direction == "E" || direction == "W")
                    {
                        this.CurrentPosition.Direction = (RoverDirection)Enum.Parse(typeof(RoverDirection), direction);
                        this.CurrentPosition.X = x;
                        this.CurrentPosition.Y = y;
                        return true;
                    }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }

        /// <summary>
        /// Rover command parse
        /// </summary>
        /// <param name="roverCommandInput">Rover command input</param>
        public void CommandParse(string roverCommandInput)
        {
            foreach (var letter in roverCommandInput.ToCharArray())
            {
                switch (char.ToUpper(letter))
                {
                    case 'L':
                        this.Commands.Add(new TurnLeftCommand(this));
                        break;
                    case 'R':
                        this.Commands.Add(new TurnRightCommand(this));
                        break;
                    case 'M':
                        this.Commands.Add(new MoveCommand(this));
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        /// <summary>
        /// Check rover is at the valid grid boundaries
        /// </summary>
        private void CheckRoverIsAtValidGridBoundaries()
        {
            var gridX = this.PlateauGrid.GridX;
            var gridY = this.PlateauGrid.GridY;
            var currentRoverPosition = this.CurrentPosition;

            if (currentRoverPosition.X > gridX || currentRoverPosition.X < 0)
            {
                throw new OutOfBoundaryException(gridX, currentRoverPosition.X, "X");
            }

            if (currentRoverPosition.Y > gridY || currentRoverPosition.Y < 0)
            {
                throw new OutOfBoundaryException(gridY, currentRoverPosition.Y, "Y");
            }
        }
    }
}
