﻿namespace NetSalary.ConsoleApp.IO
{
    using NetSalary.ConsoleApp.Contracts;

    public class ConsoleWriter : IOutputWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public void WriteLine(string format, params string[] args)
        {
            Console.WriteLine(string.Format(format, args));
        }
    }
}
