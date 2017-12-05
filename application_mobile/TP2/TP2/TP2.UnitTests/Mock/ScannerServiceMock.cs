using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp2.Externalization;
using TP2.Core.Services;

namespace TP2.UnitTests.Mock
{
    public class ScannerServiceMock : IScannerService
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
