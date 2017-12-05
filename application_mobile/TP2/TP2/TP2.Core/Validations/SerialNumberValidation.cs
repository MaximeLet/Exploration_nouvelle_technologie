using System.Collections.Generic;
using Tp2.Externalization;

namespace TP2.Core.Validations
{
    public class SerialNumberValidation<T>: IValidationRule<T>
    {
        public string ValidateMessage { get; set; }
        
        private readonly List<char> _listSpecialCharacters = new List<char> { '&', '/', '>', '<', '=', '+', '$', '%', '!', '#', '.', ',', '~', '@', '-', '_' };
        
        public bool Check(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                ValidateMessage = UiText.SerialErrorMessages.EmptyEntry;
                return false;
            }
            if (value.Length > 7)
            {
                ValidateMessage = UiText.SerialErrorMessages.LengthNotValid;
                return false;
            }
            if (SerialNumberContainsSpecialCharacters(value))
            {
                ValidateMessage = UiText.SerialErrorMessages.ContainsSpecialCharacter;
                return false;
            }
            if (SerialNumberHaveNotGoodFormat(value))
            {
                ValidateMessage = UiText.SerialErrorMessages.BadFormat;
                return false;
            }
            return true;
        }

        private bool SerialNumberHaveNotGoodFormat(string value)
        {
            var hasNotCapitalCharacter = true;
            var nbrDigits = 0;
            foreach (var character in value)
                {
                    if (char.IsDigit(character))
                    {
                        nbrDigits++;
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
            return nbrDigits < 4 || hasNotCapitalCharacter;
        }

        private bool SerialNumberContainsSpecialCharacters(string value)
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