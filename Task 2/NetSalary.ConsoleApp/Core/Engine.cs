namespace NetSalary.ConsoleApp.Core
{
    using NetSalary.Common;
    using NetSalary.ConsoleApp.Contracts;

    public class Engine
    {
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;
        private readonly ITaxesService taxesService;

        public Engine(IInputReader reader, IOutputWriter writer, ITaxesService taxesService)
        {
            this.reader = reader;
            this.writer = writer;
            this.taxesService = taxesService;
        }

        internal void Run()
        {
            Console.WriteLine(GlobalConstants.WelcomeMessage);

            while (true)
            {
                try
                {
                    decimal input = decimal.Parse(this.reader.ReadLine());

                    if (input > 0)
                    {
                        var netSalary = this.taxesService.CalculateNetSalaryFromGrossValueAndTaxFile(input, GlobalConstants.TaxesFilePath);
                        this.writer.WriteLine(GlobalConstants.DisplaySalaryMessage, netSalary.ToString(GlobalConstants.SalaryFormat));
                    }
                    else if (input < 0)
                    {
                        this.writer.WriteLine(GlobalConstants.SalaryCannotBeANegativeNumberMessage);
                    }
                    else
                    {
                        this.writer.WriteLine(GlobalConstants.GoodbyeMessage);
                        break;
                    }
                }
                catch (ArgumentNullException)
                {
                    this.writer.WriteLine(GlobalConstants.InvalidGrossSalaryInput);
                }
                catch (FormatException)
                {
                    this.writer.WriteLine(GlobalConstants.InvalidGrossSalaryInput);
                }
                catch(OverflowException)
                {
                    this.writer.WriteLine(GlobalConstants.OverflowedGrossSalaryInput);
                }
            }
        }
    }
}
