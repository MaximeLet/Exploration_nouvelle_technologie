using System.Collections.Generic;
using Tp2.Externalization;

namespace TP2.Core.Validations
{
    public class ModelValidation<T>: IValidationRule<T>
    {
        public string ValidateMessage { get; set; }
        
        private readonly List<char> _listSpecialCharacters = new List<char> { '&', '/', '>', '<', '=', '+', '$', '%', '!', '#', '.', ',', '~', '@', '-', '_' };
        
        public bool Check(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                ValidateMessage =UiText.ModelErrorMessages.EmptyEntry;
                return false;
            }
            if (value.Length > 10)
            {
                ValidateMessage = UiText.ModelErrorMessages.LengthNotValid;
                return false;
            }
            if (ModelContainsSpecialCharacters(value))
            {
                ValidateMessage = UiText.ModelErrorMessages.ContainsSpecialCharacter;
                return false;
            }
            if (ModelHaveNotGoodFormat(value))
            {
                ValidateMessage = UiText.ModelErrorMessages.BadFormat;
                return false;
            }
            return true;
        }

        private bool ModelHaveNotGoodFormat(string value)
        {
            var hasNotCapitalCharacter = true;
            foreach (var character in value)
                {
                    if (char.IsDigit(character))
                    {
                        continue;
                    }
                    if (char.IsLower(character))
                        {
                            return true;
                        }
                    if (char.IsUpper(character))
                    {
                        hasNotCapitalCharacter = false;
                    }
                }
            return hasNotCapitalCharacter;
        }

        private bool ModelContainsSpecialCharacters(string value)
        {
            foreach (char specialCharacter in value)
            {
                if (_listSpecialCharacters.Contains(specialCharacter))
                {
                    return true;
                }
            }
            return false;
        }
    }
}