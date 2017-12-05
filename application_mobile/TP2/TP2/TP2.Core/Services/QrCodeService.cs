using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;
using TP2.Core.Helpers;


namespace TP2.Core.Services
{
    public class QrCodeService : IQrCodeService
    {
        public const string QrCodeName = "qr_code.png";
        
        public async Task<string> GetQrCode(string model, string serialNumber, string radioId, DateTime date)
        {
            byte[] lnFile;
            var dateFormated = date.ToString("MM/dd/yyyy HH:mm:ss.fff",
                CultureInfo.InvariantCulture);

            var request = (HttpWebRequest) WebRequest.Create(string.Format(NavigationPaths.PathToCallApiToCreateQrCode, model, serialNumber,radioId, dateFormated));

            using (var response = await request.GetResponseAsync()){
                using (var lxBr = new BinaryReader(response.GetResponseStream())) {

                    using (MemoryStream lxMs = new MemoryStream())
                    {
                        var lnBuffer = lxBr.ReadBytes(1024);
                        while (lnBuffer.Length > 0)
                        {
                            lxMs.Write(lnBuffer, 0, lnBuffer.Length);
                            lnBuffer = lxBr.ReadBytes(1024);
                        }
                        lnFile = new byte[(int)lxMs.Length];
                        lxMs.Position = 0;
                        lxMs.Read(lnFile, 0, lnFile.Length);
                    }
                }
            }
            
            string localPath = DependencyService.Get<IFileHelper>().GetLocalFilePath(QrCodeName);

            using (FileStream lxFs = new FileStream(localPath, FileMode.Create))
            {
                lxFs.Write(lnFile, 0, lnFile.Length);
            }
            return localPath;
        }
    }
}