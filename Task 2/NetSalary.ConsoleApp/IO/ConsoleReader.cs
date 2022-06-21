using NetSalary.ConsoleApp.Contracts;

namespace NetSalary.ConsoleApp.IO
{
    public class ConsoleReader : IInputReader
    {
        public string? ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
