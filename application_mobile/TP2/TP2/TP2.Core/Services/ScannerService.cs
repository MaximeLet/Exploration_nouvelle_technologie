using System.Threading.Tasks;
using Tp2.Externalization;
using TP2.Core.Repositories;
using TP2.Core.Repositories.Entities;
using TP2.Core.ViewModels;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace TP2.Core.Services
{
    class ScannerService : IScannerService
    {
        public string ValidateElementScanned(int count, string value)
        {
            if (count < 2)
            {
                return UiText.ScanErrorMessages.MissingElements;
            }
            else if (!value.Contains("M:"))
            {
                return UiText.ScanErrorMessages.MissingModal;
            }
            else if (!value.Contains("SER:"))
            {
                return UiText.ScanErrorMessages.MissingSerialNumber;
            }
            else if (!value.Contains("FABD:"))
            {
                return UiText.ScanErrorMessages.MissingFabricationDate;
            }
            return "";
        }
    }
}
