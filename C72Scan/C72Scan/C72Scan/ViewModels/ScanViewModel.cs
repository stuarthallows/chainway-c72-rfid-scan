using System;
using System.Windows.Input;
using C72Scan.Services;
using Xamarin.Forms;

namespace C72Scan.ViewModels
{
    public class ScanViewModel : BaseViewModel
    {
        private readonly IRfidService rfidService;

        public ScanViewModel()
        {
            rfidService = DependencyService.Get<IRfidService>();

            Title = "Scan";

            Tag = "E8011700454FGHT66457GH60";
            ScannedAt = DateTime.Now;

            ScanCommand = new Command(Scan);
        }

        private void Scan()
        {
            var uii = rfidService.InventorySingleTag();

            if (string.IsNullOrEmpty(uii))
            {
                return;
            }

            Tag = rfidService.ConvertUiiToEpc(uii);
            ScannedAt = DateTime.Now;
        }

        private string scanButtonText = string.Empty;
        public string ScanButtonText
        {
            get => scanButtonText;
            set => SetProperty(ref scanButtonText, value);
        }

        private string tag = string.Empty;
        public string Tag
        {
            get => tag;
            set => SetProperty(ref tag, value);
        }

        private DateTime? scannedAt;
        public DateTime? ScannedAt
        {
            get => scannedAt;
            set => SetProperty(ref scannedAt, value);
        }

        public ICommand ScanCommand { get; }
    }
}