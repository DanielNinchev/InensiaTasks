namespace NetSalary.Tests
{
    using NetSalary.Common;
    using NetSalary.ConsoleApp.Services;
    using NUnit.Framework;

    public class TaxesServiceTests
    {
        [Test]
        [TestCase(980)]
        [TestCase(3400)]
        public void ShouldReturnCorrectNetSalaryWhenValidInputAndFilePathAreGiven(decimal input)
        {
            // arrange
            decimal expectedResult = 2860;

            if (input < 1000)
            {
                expectedResult = input;
            }

            var service = new TaxesService();

            // act
            var actualResult = service.CalculateNetSalaryFromGrossValueAndTaxFile(input, GlobalConstants.TaxesTestFilePath);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}