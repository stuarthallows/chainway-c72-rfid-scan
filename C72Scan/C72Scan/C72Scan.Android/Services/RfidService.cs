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

        /// <summary>
        /// Stop circular identification
        /// </summary>
        public bool StopInventory()
        {
#if NO_BLUETOOTH
            return true;
#else
            return uhfAPI.StopInventory();
#endif
        }

        /// <summary>
        /// Initialize UHF module.
        /// </summary>
        public bool Init()
        {
#if NO_BLUETOOTH
            return true;
#else
            return uhfAPI.Init();
#endif
        }

        /// <summary>
        /// Switch off UHF module
        /// </summary>
        public bool Free()
        {
#if NO_BLUETOOTH
            return true;
#else
            return uhfAPI.Free();
#endif
        }

        /// <summary>
        /// This formula identify tag in single step, return UII for only one time.
        /// </summary>
        /// <remarks>
        /// Consider calling inventorySingleTagEPC_TID_USER to get TID directly.
        /// </remarks>
        public string InventorySingleTag()
        {
#if NO_BLUETOOTH
            return "X9999ASDFZZZZZ";
#else
            return uhfAPI.InventorySingleTag();
#endif
        }

        /// <summary>
        /// UII transform to EPC.
        /// </summary>
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
