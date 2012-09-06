using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Info;

namespace MemoryUsage
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!store.DirectoryExists("HTML")) store.CreateDirectory("HTML");                
                CopyToIsolatedStorage("HTML\\geocoding.html", store);
            }
        }

        private static void CopyToIsolatedStorage(string file, IsolatedStorageFile store, bool overwrite = true)
        {
            if (store.FileExists(file) && !overwrite)
                return;

            using (Stream resourceStream = Application.GetResourceStream(new Uri(file, UriKind.Relative)).Stream)  
            using (IsolatedStorageFileStream fileStream = store.OpenFile(file, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                int bytesRead;
                var buffer = new byte[resourceStream.Length];
                while ((bytesRead = resourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    fileStream.Write(buffer, 0, bytesRead);
            }

        }

        private void browser_ScriptNotify(object sender, NotifyEventArgs e)
        {
            if (e.Value == "getMemoryUsage")
            {
                var response = new object[]
                                   {
                                       DeviceStatus.ApplicationCurrentMemoryUsage,
                                       DeviceStatus.ApplicationMemoryUsageLimit,
                                       DeviceStatus.ApplicationPeakMemoryUsage,
                                       DeviceStatus.DeviceTotalMemory
                                   };
                browser.InvokeScript("getMemoryUsageCallback", response.Select(c => c.ToString()).ToArray());
            }
        }
    }
}