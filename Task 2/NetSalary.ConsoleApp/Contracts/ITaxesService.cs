namespace NetSalary.ConsoleApp.Contracts
{
    public interface ITaxesService
    {
        decimal CalculateNetSalaryFromGrossValueAndTaxFile(decimal grossSalary, string taxFilePath);
    }
}
