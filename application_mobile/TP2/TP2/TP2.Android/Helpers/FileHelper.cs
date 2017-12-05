using TP2.Core.Helpers;
using System;
using System.IO;
using TP2.Android.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace TP2.Android.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}