using Xamarin.Forms;
using C72Scan.Services;

namespace C72Scan
{
    public partial class App : Application
    {
        private readonly IRfidService rfidService;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();

            rfidService = DependencyService.Get<IRfidService>();
        }

        protected override void OnStart()
        {
            rfidService.StopInventory();
        }

        protected override void OnSleep()
        {
            rfidService.Free();
        }

        protected override void OnResume()
        {
            for (int i = 1; i <= 3; i++)
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
