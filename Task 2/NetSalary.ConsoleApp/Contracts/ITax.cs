namespace NetSalary.ConsoleApp.Contracts
{
    public interface ITax
    {
        string Name { get; }

        decimal TaxPercentage { get; set; }

        decimal MinTaxedAmount { get; set; }

        decimal MaxTaxedAmount { get; set; }
    }
}
