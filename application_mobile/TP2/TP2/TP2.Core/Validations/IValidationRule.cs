namespace TP2.Core.Validations
{
    public interface IValidationRule<T>
    {
        string ValidateMessage { get; set; }
        bool Check(string value);
    }
}