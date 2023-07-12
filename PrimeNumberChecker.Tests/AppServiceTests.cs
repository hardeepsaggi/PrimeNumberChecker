using NUnit.Framework;
using AppService.Services;

namespace AppService.Tests
{
    [TestFixture]
    public class CalculationServiceTests
    {
        private CalculationService _calculationService;

        [SetUp]
        public void Setup()
        {
            // Initialize the CalculationService
            _calculationService = new CalculationService();
        }

        [Test]
        public void CheckNumber_PrimeNumber_ReturnsPrimeResponse()
        {
            // Arrange
            var primeNumber = new PrimeNumber
            {
                Number = 13,
                Timestamp = 123456789
            };

            // Act
            var result = _calculationService.CheckNumber(primeNumber, null).Result;
                        
            // Assert
            Assert.That(result.Number, Is.EqualTo(13));          // Check if the Number property of the response is 13
            Assert.IsTrue(result.Isprime);              // Check if the Isprime property is true
            Assert.That(result.Timestamp, Is.EqualTo(123456789));  // Check if the Timestamp property matches the provided value

        }

        [Test]
        public void CheckNumber_NonPrimeNumber_ReturnsNonPrimeResponse()
        {
            // Arrange
            var nonPrimeNumber = new PrimeNumber
            {
                Number = 10,
                Timestamp = 987654321
            };

            // Act
            var result = _calculationService.CheckNumber(nonPrimeNumber, null).Result;

            // Assert            
            Assert.That(result.Number, Is.EqualTo(10));                 // Check if the Number property of the response is 10
            Assert.IsFalse(result.Isprime);                              // Check if the Isprime property is false
            Assert.That(result.Timestamp, Is.EqualTo(987654321));       // Check if the Timestamp property matches the provided value

        }

        [Test]
        public void CheckNumber_NullRequest_ReturnsDefaultResponse()
        {
            // Act
            var result = _calculationService.CheckNumber(null, null).Result;

            // Assert
            Assert.That(result.Number, Is.EqualTo(0));           // Check if the Number property of the response is 0
            Assert.IsFalse(result.Isprime);                      // Check if the Isprime property is false
            Assert.That(result.Timestamp, Is.EqualTo(-1));       // Check if the Timestamp property matches the default value of -1

        }
    }
}
