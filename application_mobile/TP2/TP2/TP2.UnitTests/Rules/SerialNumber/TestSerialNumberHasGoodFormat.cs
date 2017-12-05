using NUnit.Framework;
using TP2.Core.Validations;

namespace TP2.UnitTests.Rules.SerialNumber
{
    [TestFixture]
    public class TestSerialNumberHasGoodFormat
    {
        [TestCase("R10", false)]
        [TestCase("LeV0208", false)]
        [TestCase("r200532", false)]
        [TestCase("C3A00", false)]
        public void ValidateSerialNumber_WhenSerialNumberHaveNotGoodFormat_ReturnTrue(string currentEntry, bool expectedValue)
        {
            SerialNumberValidation<string> serialNumberValidation  = new SerialNumberValidation<string>();
            
            var actualAnswer = serialNumberValidation.Check(currentEntry);
            
            Assert.AreEqual(actualAnswer, expectedValue);
        }
        
        [TestCase("R100001", true)]
        [TestCase("LEV0208", true)]
        [TestCase("R200532", true)]
        [TestCase("C3A0002", true)]
        public void ValidateSerialNumber_WhenSerialNumberHaveGoodFormat_ReturnTrue(string currentEntry, bool expectedValue)
        {
            SerialNumberValidation<string> serialNumberValidation  = new SerialNumberValidation<string>();
            
            var actualAnswer = serialNumberValidation.Check(currentEntry);
            
            Assert.AreEqual(actualAnswer, expectedValue);
        }
    }
}