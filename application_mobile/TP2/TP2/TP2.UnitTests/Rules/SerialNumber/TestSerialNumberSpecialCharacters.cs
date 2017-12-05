using NUnit.Framework;
using TP2.Core.Validations;

namespace TP2.UnitTests.Rules.SerialNumber
{
    [TestFixture]
    public class TestSerialNumberSpecialCharacters
    {
        [TestCase("R10000~", false)]
        [TestCase("R10000!", false)]
        [TestCase("R10000#", false)]
        [TestCase("R10000%", false)]
        [TestCase("R10000$", false)]
        [TestCase("R10000@", false)]
        [TestCase("R10000+", false)]
        [TestCase("R10000>", false)]
        [TestCase("R10000<", false)]
        [TestCase("R10000=", false)]
        [TestCase("R10000.", false)]
        [TestCase("R10000,", false)]
        [TestCase("R10000-", false)]
        [TestCase("R10000_", false)]
        public void ValidateSerialNumber_WhenSerialNumberContainsSpecialCharacters_ReturnFalse(string currentEntry, bool expectedValue)
        {
            SerialNumberValidation<string> serialNumberValidation  = new SerialNumberValidation<string>();
            
            var actualAnswer = serialNumberValidation.Check(currentEntry);
            
            Assert.AreEqual(actualAnswer, expectedValue);
        }
        
        [TestCase("R100001", true)]
        [TestCase("LEV0208", true)]
        [TestCase("R200532", true)]
        [TestCase("C3A0002", true)]
        public void ValidateSerialNumber_WhenSerialNumberNotContainsSpecialCharacters_ReturnTrue(string currentEntry, bool expectedValue)
        {
            SerialNumberValidation<string> serialNumberValidation  = new SerialNumberValidation<string>();
            
            var actualAnswer = serialNumberValidation.Check(currentEntry);
            
            Assert.AreEqual(actualAnswer, expectedValue);
        }
    }
}