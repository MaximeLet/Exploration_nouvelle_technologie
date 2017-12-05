using NUnit.Framework;
using TP2.Core.Validations;

namespace TP2.UnitTests.Rules.SerialNumber
{
    [TestFixture]
    public class TestModelLength
    {
        [TestCase("", false)]
        [TestCase("aaaaaaaa", false)]
        [TestCase("01234567", false)]
        [TestCase("A/B478dbs", false)]
        public void ValidateSerialNumber_WhenSerialNumberIsEmptyOrMoreThanSevenCharacters_ReturnFalse(string currentEntry, bool expectedValue)
        {
            SerialNumberValidation<string> serialNumberValidation  = new SerialNumberValidation<string>();
            
            var actualAnswer = serialNumberValidation.Check(currentEntry);
            
            Assert.AreEqual(actualAnswer, expectedValue);
        }
        
        [TestCase("R100001", true)]
        [TestCase("LEV0208", true)]
        [TestCase("R200532", true)]
        [TestCase("C3A0002", true)]
        public void ValidateSerialNumber_WhenSerialNumberIsNotEmptyAndLessThanSevenCharacters_ReturnTrue(string currentEntry, bool expectedValue)
        {
            SerialNumberValidation<string> serialNumberValidation  = new SerialNumberValidation<string>();
            
            var actualAnswer = serialNumberValidation.Check(currentEntry);
            
            Assert.AreEqual(actualAnswer, expectedValue);
        }
    }
}