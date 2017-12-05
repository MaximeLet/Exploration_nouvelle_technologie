namespace TP2.Core.Helpers
{
    public class NavigationPaths
    {
        public const string PathToGoWelcomePage = "app:///MainMasterDetailPage/NavigationPage/WelcomePage";
        public const string PathToGoInventoryPage = "app:///MainMasterDetailPage/NavigationPage/InventoryPage";
        public const string PathToGoQrCodeCreatorPage = "app:///MainMasterDetailPage/NavigationPage/QrCodeCreatorPage";
        public const string PathToGoDisplayNewQrCodePage = "app:///MainMasterDetailPage/NavigationPage/DisplayNewQrCodePage";
        public const string PathToGoScanPage = "app:///MainMasterDetailPage/NavigationPage/ScanPage";
        public const string PathToCallApiToCreateQrCode = "http://api.qrserver.com/v1/create-qr-code/?data=Mod:{0};SerialNum:{1};RadioId:{2};FabDate:{3}&size=100x100&ecc=M";
    }
}