using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace C72Scan.ViewModels
{
    public class ScanViewModel : BaseViewModel
    {
        public ScanViewModel()
        {
            Title = "Scan";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}