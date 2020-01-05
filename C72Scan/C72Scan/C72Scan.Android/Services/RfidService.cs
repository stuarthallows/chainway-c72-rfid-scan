using C72Scan.Droid.Services;
using C72Scan.Services;
using Com.Rscja.Deviceapi;
using Xamarin.Forms;

[assembly: Dependency(typeof(RfidService))]
namespace C72Scan.Droid.Services
{
    public class RfidService : IRfidService
    {
        public RFIDWithUHF uhfAPI;

        public RfidService()
        {
            uhfAPI = RFIDWithUHF.Instance;
        }

        public bool StopInventory()
        {
            return uhfAPI.StopInventory();
        }

        public bool Init()
        {
            return uhfAPI.Init();
        }

        public bool Free()
        {
            return uhfAPI.Free();
        }
    }
}