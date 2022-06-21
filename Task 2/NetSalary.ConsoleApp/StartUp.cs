namespace NetSalary.ConsoleApp
{
    using Microsoft.Extensions.DependencyInjection;
    using NetSalary.ConsoleApp.Contracts;
    using NetSalary.ConsoleApp.Core;
    using NetSalary.ConsoleApp.IO;
    using NetSalary.ConsoleApp.Services;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                IServiceProvider serviceProvider = ConfigureServices();
                IInputReader reader = serviceProvider.GetService<IInputReader>();
                IOutputWriter writer = serviceProvider.GetService<IOutputWriter>();
                ITaxesService taxesService = serviceProvider.GetService<ITaxesService>();

                Engine engine = new(reader, writer, taxesService);
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

            services.AddSingleton<IInputReader, ConsoleReader>();
            services.AddSingleton<IOutputWriter, ConsoleWriter>();
            services.AddSingleton<ITaxesService, TaxesService>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}

