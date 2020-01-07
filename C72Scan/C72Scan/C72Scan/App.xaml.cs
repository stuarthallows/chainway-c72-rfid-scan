using Xamarin.Forms;
using C72Scan.Services;

namespace C72Scan
{
    public partial class App : Application
    {
        private readonly IRfidService rfidService;
        private IBluetoothService bluetoothService;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();

            rfidService = DependencyService.Get<IRfidService>();
            bluetoothService = DependencyService.Get<IBluetoothService>();
        }

        protected override void OnStart()
        {
            rfidService.StopInventory();

            InitializeReader();
        }

        protected override void OnSleep()
        {
            rfidService.StopInventory();
            bluetoothService.Close();
        }

        protected override void OnResume()
        {
            InitializeReader();

            // TODO consider reconnecting to last connected device
        }

        // TODO Handle initialization failure
        private void InitializeReader()
        {
            for (var i = 1; i <= 3; i++)
            {
                if (i != 3)
                {
                    if (!rfidService.Init())
                    {
                        rfidService.Free();
                    }
                }
                else
                {
                    rfidService.Init();
                }
            }
        }
    }
}
