namespace MovieStars.ConsoleApp
{
    using Microsoft.Extensions.DependencyInjection;
    using MovieStars.Common;
    using MovieStars.ConsoleApp.Contracts;
    using MovieStars.ConsoleApp.Core;
    using MovieStars.ConsoleApp.IO;
    using MovieStars.ConsoleApp.Services;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                IServiceProvider serviceProvider = ConfigureServices();
                IOutputWriter writer = serviceProvider.GetService<IOutputWriter>();
                IMovieStarsService movieStarsService = serviceProvider.GetService<IMovieStarsService>();

                Engine engine = new(movieStarsService, writer);
                engine.Run();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IOutputWriter, ConsoleWriter>();
            services.AddSingleton<IMovieStarsService, MovieStarsService>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}