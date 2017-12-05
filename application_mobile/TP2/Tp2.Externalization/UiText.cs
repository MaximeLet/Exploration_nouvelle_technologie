namespace Tp2.Externalization
{
    public class UiText
    {
        public static class GlobalsId
        {
            public const string InventoryMenu = "L'inventaire";
            public const string QrCodeCreatorMenu = "Création de QR code";
            public const string ScanPageButton = "Scanner un QR code";
            public const string ScannerButton = "Cliquer ici pour ouvrir le scanner";
            public const string ModelEntry = "ModelEntry";
            public const string LabelSerialNumberError = "SerialNumberError";
            public const string LabelModelError = "ModelError";
            public const string ButtonInQrCodePageCreator = "ButtonQrCodeCreator";
            public const string IdQrCodeImage = "QrCodeImage";
            public const string SerialNumberEntry = "SerialNumberEntry";
        }
        
        public static class ModelErrorMessages
        {
            public const string EmptyEntry = "Le champ modèle est vide.";
            public const string LengthNotValid = "Le champ modèle ne doit pas avoir plus de 10 caractères.";
            public const string ContainsSpecialCharacter = "Le champ modèle ne doit pas contenir des caractères spéciaux.";
            public const string BadFormat = "Le champ modèle ne doit pas contenir de minuscule et il doit contenir au moins une majuscule.";
        }
        
        public static class SerialErrorMessages
        {
            public const string EmptyEntry = "Le champ numéro de série est vide.";
            public const string LengthNotValid = "Le champ numéro de série ne doit pas avoir plus de 7 caractères.";
            public const string ContainsSpecialCharacter = "Le champ numéro de série ne doit pas contenir des caractères spéciaux.";
            public const string BadFormat = "Le champ numéro de série ne doit pas contenir de minuscule, il doit contenir au moins une majuscule et plus que 4 chiffres.";
        }

        public static class ScanErrorMessages
        {
            public const string MissingElements = "Il manque des éléments de ce QR code.";
            public const string MissingModal = "Il manque le modèle.";
            public const string MissingSerialNumber = "Il manque le numéro de série.";
            public const string MissingFabricationDate = "Il manque la date de fabrication.";
            public const string ProductIsAlreadyInInventory = "Le produit est déjà enregistrer dans l'inventaire.";
        }

        public static class RadioIdMessages
        {
            public const string MsgIfNoRadioId = "Il n'y a pas de radio dans ce modèle.";
        }
    }
}
