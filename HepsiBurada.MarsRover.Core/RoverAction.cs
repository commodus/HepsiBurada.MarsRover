using HepsiBurada.MarsRover.Core.Common;
using HepsiBurada.MarsRover.Core.Common.Enums;
using HepsiBurada.MarsRover.Core.Contracts;
using System;

namespace HepsiBurada.MarsRover.Core
{
    public class RoverAction
    {
        public static IRoverPosition Move(IRoverPosition roverPosition)
        {
            IRoverPosition currentRoverPosition = roverPosition;

            switch (roverPosition.Direction)
            {
                case RoverDirection.N:
                    currentRoverPosition = new RoverPosition(roverPosition.Direction, roverPosition.X, roverPosition.Y + 1);
                    break;
                case RoverDirection.S:
                    currentRoverPosition = new RoverPosition(roverPosition.Direction, roverPosition.X, roverPosition.Y - 1);
                    break;
                case RoverDirection.W:
                    currentRoverPosition = new RoverPosition(roverPosition.Direction, roverPosition.X - 1, roverPosition.Y);
                    break;
                case RoverDirection.E:
                    currentRoverPosition = new RoverPosition(roverPosition.Direction, roverPosition.X + 1, roverPosition.Y);
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return currentRoverPosition;
        }

        public static RoverDirection TurnRight(RoverDirection roverDirection)
        {
            RoverDirection currentRoverDirection = roverDirection;

            switch (roverDirection)
            {
                case RoverDirection.N:
                    currentRoverDirection = RoverDirection.E;
                    break;
                case RoverDirection.E:
                    currentRoverDirection = RoverDirection.S;
                    break;
                case RoverDirection.S:
                    currentRoverDirection = RoverDirection.W;
                    break;
                case RoverDirection.W:
                    currentRoverDirection = RoverDirection.N;
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return currentRoverDirection;
        }

        public static RoverDirection TurnLeft(RoverDirection roverDirection)
        {
            RoverDirection currentRoverDirection = roverDirection;

            switch (roverDirection)
            {
                case RoverDirection.N:
                    currentRoverDirection = RoverDirection.W;
                    break;
                case RoverDirection.E:
                    currentRoverDirection = RoverDirection.N;
                    break;
                case RoverDirection.S:
                    currentRoverDirection = RoverDirection.E;
                    break;
                case RoverDirection.W:
                    currentRoverDirection = RoverDirection.S;
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return currentRoverDirection;
        }
    }
}
