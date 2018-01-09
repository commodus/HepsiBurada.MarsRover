using HepsiBurada.MarsRover.Core.Commands;
using HepsiBurada.MarsRover.Core.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace HepsiBurada.MarsRover.Core
{
    public class DI
    {
        public static ServiceProvider Configure()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<ICommand, TurnLeftCommand>();
            services.AddTransient<ICommand, TurnRightCommand>();
            services.AddTransient<ICommand, MoveCommand>();
            services.AddTransient<IRoverCommandManager, RoverCommandManager>();
            services.AddTransient<IRoverPosition, RoverPosition>();
            services.AddTransient<IRover, Rover>();
            services.AddTransient<IPlateauGrid, PlateauGrid>();

            return services.BuildServiceProvider();
        }
    }
}
