namespace NetSalary.ConsoleApp.Models
{
    // Adding a new tax is easy - just add it in the taxes.txt file and no code changes will be required if the taxation concept remains the same.
    public class Tax
    {
        // Not a necessary one, but I thought it would be nice to have it
        public string Name { get; set; }

        public decimal TaxPercentage { get; set; }

        public decimal MinTaxedAmount { get; set; }

        public decimal MaxTaxedAmount { get; set; }
    }
}
