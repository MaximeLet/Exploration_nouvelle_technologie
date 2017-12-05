using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TP2.Core.Services
{
    public interface IQrCodeService
    {
        Task<string> GetQrCode(string model, string serialNumber, string radioId, DateTime date);
    }
}