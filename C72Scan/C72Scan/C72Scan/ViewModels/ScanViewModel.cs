using System;
using System.Windows.Input;
using C72Scan.Services;
using Xamarin.Forms;

namespace C72Scan.ViewModels
{
    public class ScanViewModel : BaseViewModel
    {
        private readonly IRfidService rfidService;
        private IBluetoothService bluetoothService;

        public ScanViewModel()
        {
            rfidService = DependencyService.Get<IRfidService>();
            bluetoothService = DependencyService.Get<IBluetoothService>();

            Title = "Scan";

            ScanCommand = new Command(Scan);

            MessagingCenter.Subscribe<string, string>(this, "Scan", (sender, arg) =>
            {
                Scan();
            });
        }

        private void Scan()
        {
            SetTag(null);
            
            var uii = rfidService.InventorySingleTag();

            if (string.IsNullOrEmpty(uii))
            {
                return;
            }

            SetTag(rfidService.ConvertUiiToEpc(uii));
            bluetoothService.Write(uii);
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

        private void SetTag(string tagId)
        {
            Tag = tagId;
            ScannedAt = DateTime.Now;
        }
    }
}