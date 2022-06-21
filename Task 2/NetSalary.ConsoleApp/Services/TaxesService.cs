namespace NetSalary.ConsoleApp.Services
{
    using NetSalary.Common;
    using NetSalary.ConsoleApp.Contracts;
    using NetSalary.ConsoleApp.Models;
    using Newtonsoft.Json;

    public class TaxesService : ITaxesService
    {
        public TaxesService()
        {
        }

        public decimal CalculateNetSalaryFromGrossValueAndTaxFile(decimal grossSalary, string taxFilePath)
        {
            try
            {
                StreamReader reader = new(taxFilePath);
                decimal netSalary = grossSalary;

                using (reader)
                {
                    var json = reader.ReadToEnd();
                    var taxes = JsonConvert.DeserializeObject<List<Tax>>(json);

                    if (taxes != null)
                    {
                        foreach (var tax in taxes.Where(x => x.MinTaxedAmount < grossSalary))
                        {
                            this.ValidateTaxData(tax);

                            if (grossSalary > tax.MaxTaxedAmount && tax.MaxTaxedAmount != 0)
                            {
                                netSalary -= (tax.MaxTaxedAmount - tax.MinTaxedAmount) * tax.TaxPercentage;
                            }
                            else
                            {
                                netSalary -= (grossSalary - tax.MinTaxedAmount) * tax.TaxPercentage;
                            }
                        }
                    }
                }

                return netSalary;
            }
            catch (FileNotFoundException)
            {
                string message = string.Format(GlobalConstants.CouldNotFindFile, taxFilePath);
                throw new FileNotFoundException(message);
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException(GlobalConstants.InvalidFileDirectory);
            }
            catch (IOException)
            {
                string message = string.Format(GlobalConstants.CouldNotOpenFile, taxFilePath);
                throw new IOException(message);
            }
        }

        private void ValidateTaxData(Tax tax)
        {
            // More validations could be added here, but I think it's enough for the purpose of this task
            if (tax.MaxTaxedAmount < 0 || tax.MinTaxedAmount < 0 || tax.TaxPercentage <= 0)
            {
                string message = string.Format(GlobalConstants.TaxDataNumbersCannotBeNegative, tax.Name);
                throw new InvalidDataException(message);
            }

            if (tax.MaxTaxedAmount != 0)
            {
                if (tax.MinTaxedAmount > tax.MaxTaxedAmount)
                {
                    string message = string.Format(GlobalConstants.InvalidTaxDataMinOrMaxTaxedAmountMessage, tax.Name);
                    throw new InvalidDataException(message);
                }
            }
        }
    }
}
