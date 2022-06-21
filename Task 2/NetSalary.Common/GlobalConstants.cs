namespace NetSalary.Common
{
    public static class GlobalConstants
    {
        public const string SalaryFormat = "0,0.00";
        public const string TaxesFilePath = @"..\..\..\taxes.txt";
        public const string TaxesTestFilePath = @"..\..\..\taxesTestFile.txt";

        // Messages
        public const string DisplaySalaryMessage = "The net salary is {0} IDR.";
        public const string GoodbyeMessage = "Goodbye!";
        public const string SalaryCannotBeANegativeNumberMessage = "The salary cannot be a negative number!";
        public const string WelcomeMessage = "Welcome! Enter a gross salary value to get the net salary value, or press 0 to exit the program.";

        // Errors
        public const string CouldNotFindFile = "Error! Could not find file {0}";
        public const string CouldNotOpenFile = "Error! Could not open file {0}!";
        public const string InvalidFileDirectory = "Error! Invalid file directory!";
        public const string InvalidGrossSalaryInput = "Error! Invalid input amount! Please, enter a number larger than 0.";
        public const string InvalidTaxDataMinOrMaxTaxedAmountMessage = "Error! Invalid data for {0} in the tax input file - the minimal taxed amount cannot be larger than the maximal.";
        public const string TaxDataNumbersCannotBeNegative = "Error! Invalid data for {0} in the tax input file - the tax percentages and amounts cannot be negative numbers.";
        public const string OverflowedGrossSalaryInput = "Error! Please, enter a realistic gross salary value.";
    }
}