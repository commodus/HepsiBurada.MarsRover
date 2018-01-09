using HepsiBurada.MarsRover.Core;
using HepsiBurada.MarsRover.Core.Commands;
using HepsiBurada.MarsRover.Core.Common.Enums;
using HepsiBurada.MarsRover.Core.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HepsiBurada.MarsRover.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO : Implement an IOC container tool for dependency injection. DONE
            // TODO : Implement more validations, exception handling and log mechanisms.
            // TODO : Add unit test project.
            // TODO : More explanations for methods, fields etc..
            // TODO : Some refactorings.
            
            var serviceProvider = DI.Configure();

            Console.WriteLine("Hello Mars!");
            Console.WriteLine("Test Input :");

            var plateauGrid = serviceProvider.GetService<IPlateauGrid>();

            while (!plateauGrid.CheckInit)
            {
                Console.WriteLine("Plateau grid size :");
                var plateauGridSizeInput = Console.ReadLine();
                Console.WriteLine(plateauGrid.Initialize(plateauGridSizeInput));
            }

            var addAnotherRover = true;

            while (addAnotherRover)
            {
                Console.WriteLine("Rover position :");
                var roverPositionInput = Console.ReadLine();
                Console.WriteLine("Rover command :");
                var roverCommandInput = Console.ReadLine();

                var rover = serviceProvider.GetService<IRover>();
                if (rover.Initialize(roverPositionInput))
                {
                    rover.PlateauGrid = plateauGrid;
                    rover.CommandParse(roverCommandInput);
                    plateauGrid.Rovers.Add(rover);
                }

                Console.WriteLine("Do you want to deploy another rover ? (Y)");
                var addAnotherRoverInput = Console.ReadLine();
                if (addAnotherRoverInput.ToUpper() != "Y")
                {
                    addAnotherRover = false;
                }
            }

            Console.WriteLine("Expected Output :");
            foreach (var rover in plateauGrid.Rovers)
            {
                var roverCommandManager = serviceProvider.GetService<IRoverCommandManager>();
                roverCommandManager.Rover = rover;

                foreach (var roverCommand in rover.Commands)
                {
                    roverCommandManager.AddCommand(roverCommand);
                }

                roverCommandManager.ProcessCommands();

                Console.WriteLine($"{roverCommandManager.Rover.CurrentPosition.X} " +
                  $"{roverCommandManager.Rover.CurrentPosition.Y} " +
                  $"{roverCommandManager.Rover.CurrentPosition.Direction.ToString()}");
            }

            /*
            // TODO : Convert to unit test project.
            // 5 5
            var plateauGrid1 = new PlateauGrid(5, 5);

            // 1 2 N
            // LMLMLMLMM
            var roverPosition = new RoverPosition(RoverDirection.N, 1, 2);
            var rover = new Rover(roverPosition, plateauGrid1);

            var roverCommandManager = new RoverCommandManager(rover);
            roverCommandManager.AddCommand(new TurnLeftCommand(rover));
            roverCommandManager.AddCommand(new MoveCommand(rover));
            roverCommandManager.AddCommand(new TurnLeftCommand(rover));
            roverCommandManager.AddCommand(new MoveCommand(rover));
            roverCommandManager.AddCommand(new TurnLeftCommand(rover));
            roverCommandManager.AddCommand(new MoveCommand(rover));
            roverCommandManager.AddCommand(new TurnLeftCommand(rover));
            roverCommandManager.AddCommand(new MoveCommand(rover));
            roverCommandManager.AddCommand(new MoveCommand(rover));

            roverCommandManager.ProcessCommands();

            Console.WriteLine($"X: {roverCommandManager.Rover.CurrentPosition.X}, " +
                $"Y: {roverCommandManager.Rover.CurrentPosition.Y}, " +
                $"Direction: {roverCommandManager.Rover.CurrentPosition.Direction.ToString()}");

            // 3 3 E
            // MMRMMRMRRM
            var roverPosition2 = new RoverPosition(RoverDirection.E, 3, 3);
            var rover2 = new Rover(roverPosition2, plateauGrid1);

            var roverCommandManager2 = new RoverCommandManager(rover2);
            roverCommandManager2.AddCommand(new MoveCommand(rover2));
            roverCommandManager2.AddCommand(new MoveCommand(rover2));
            roverCommandManager2.AddCommand(new TurnRightCommand(rover2));
            roverCommandManager2.AddCommand(new MoveCommand(rover2));
            roverCommandManager2.AddCommand(new MoveCommand(rover2));
            roverCommandManager2.AddCommand(new TurnRightCommand(rover2));
            roverCommandManager2.AddCommand(new MoveCommand(rover2));
            roverCommandManager2.AddCommand(new TurnRightCommand(rover2));
            roverCommandManager2.AddCommand(new TurnRightCommand(rover2));
            roverCommandManager2.AddCommand(new MoveCommand(rover2));

            roverCommandManager2.ProcessCommands();

            Console.WriteLine($"X: {roverCommandManager2.Rover.CurrentPosition.X}, " +
                            $"Y: {roverCommandManager2.Rover.CurrentPosition.Y}, " +
                            $"Direction: {roverCommandManager2.Rover.CurrentPosition.Direction.ToString()}");

            */

            Console.ReadKey();
        }
    }
}
