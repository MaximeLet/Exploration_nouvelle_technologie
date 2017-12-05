using TP2.Core.Validations;

namespace TP2.UnitTests.Mock
{
    public class MockRule<T> : IValidationRule<T>
    {
        public string ValidateMessage { get; set; }
        
        public bool IsValid { get; set; }
        
        public bool Check(string value)
        {
            return IsValid;
        }
    }
}