using NUnit.Framework;
using TP2.Core.Validations;

namespace TP2.UnitTests.Rules.Model
{
    [TestFixture]
    public class TestModelHasGoodFormat
    {
        [TestCase("Red123", false)]
        [TestCase("122345", false)]
        [TestCase("22222red", false)]
        public void ValidateModel_WhenModelHasNotCapitalCharacterOrHasLowerCapitals_ReturnFalse(string currentEntry, bool expectedValue)
        {
            ModelValidation<string> modelValidation  = new ModelValidation<string>();
            
            var actualAnswer = modelValidation.Check(currentEntry);
            
            Assert.AreEqual(actualAnswer, expectedValue);
        }
        
        [TestCase("REDBV1", true)]
        [TestCase("LEVSND", true)]
        [TestCase("REDBV3", true)]
        [TestCase("CTLAV1", true)]
        [TestCase("CTLAV3", true)]
        [TestCase("REDREPB", true)]
        public void ValidateModel_WhenModelIsNotEmptyAndLessThanTenCharacters_ReturnTrue(string currentEntry, bool expectedValue)
        {
            ModelValidation<string> modelValidation  = new ModelValidation<string>();
            
            var actualAnswer = modelValidation.Check(currentEntry);
            
            Assert.AreEqual(actualAnswer, expectedValue);
        }  
    }
}