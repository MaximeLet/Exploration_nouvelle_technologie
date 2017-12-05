using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TP2.Core.Repositories;
using TP2.Core.Repositories.Entities;
using ZXing.Net.Mobile.Forms;

namespace TP2.Core.Services
{
    public interface IScannerService
    {
        string ValidateElementScanned(int count, string value);
    }
}
