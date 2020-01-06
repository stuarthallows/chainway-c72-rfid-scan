using C72Scan.Droid.Services;
using C72Scan.Services;
using Com.Rscja.Deviceapi;
using Xamarin.Forms;

[assembly: Dependency(typeof(RfidService))]
namespace C72Scan.Droid.Services
{
    public class RfidService : IRfidService
    {
#if NO_BLUETOOTH
#else
        private RFIDWithUHF uhfAPI;

        public RfidService()
        {
            uhfAPI = RFIDWithUHF.Instance;
        }
#endif

        public bool StopInventory()
        {
#if NO_BLUETOOTH
            return true;
#else
            return uhfAPI.StopInventory();
#endif
        }

        public bool Init()
        {
#if NO_BLUETOOTH
            return true;
#else
            return uhfAPI.Init();
#endif
        }

        public bool Free()
        {
#if NO_BLUETOOTH
            return true;
#else
            return uhfAPI.Free();
#endif
        }

        public string InventorySingleTag()
        {
#if NO_BLUETOOTH
            return "X9999ASDFZZZZZ";
#else
            return uhfAPI.InventorySingleTag();
#endif
        }

        public string ConvertUiiToEpc(string uii)
        {
#if NO_BLUETOOTH
            return "X9999ASDFZZZZZ9999";
#else
            return uhfAPI.ConvertUiiToEPC(uii);
#endif
        }
    }
}
