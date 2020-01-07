using System;
using System.IO;
using System.Reflection;
using System.Windows.Input;
using C72Scan.Services;
using Plugin.SimpleAudioPlayer;
using Xamarin.Forms;

namespace C72Scan.ViewModels
{
    public class ScanViewModel : BaseViewModel
    {
        private readonly IRfidService rfidService;
        private IBluetoothService bluetoothService;

        public ICommand PlaySoundCommand { get; set; }

        public ScanViewModel()
        {
            rfidService = DependencyService.Get<IRfidService>();
            bluetoothService = DependencyService.Get<IBluetoothService>();

            Title = "Scan";

            ScanCommand = new Command(Scan);
            PlaySoundCommand = new Command(PlaySound);

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

            if (IsTransferToggled)
            {
                bluetoothService.Write(uii);
            }

            PlaySound();
        }

        private void PlaySound()
        {
            try
            {
                // TODO move into service
                // TODO add a setting to toggle sound
                var audioStream = GetStreamFromFile("Audio.beep.mp3");
                CrossSimpleAudioPlayer.Current.Load(audioStream);
                CrossSimpleAudioPlayer.Current.Play();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
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

        private bool isTransferToggled = true;
        public bool IsTransferToggled
        {
            get => isTransferToggled;
            set => SetProperty(ref isTransferToggled, value);
        }

        private Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            var resourceName = $"{assembly.GetName().Name}.{filename}";

            return assembly.GetManifestResourceStream(resourceName);
        }
    }
}