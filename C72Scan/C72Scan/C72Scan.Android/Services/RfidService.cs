using C72Scan.Droid.Services;
using C72Scan.Services;
using Com.Rscja.Deviceapi;
using Xamarin.Forms;

[assembly: Dependency(typeof(RfidService))]
namespace C72Scan.Droid.Services
{
    /// <summary>
    /// Manage reading tags using the Chainway C72 UHF RFID reader.
    /// </summary>
    /// <remarks>
    /// Documentation for this API is taken from the Java docs provided by Chainway.
    ///
    /// Links to C72 product information;
    /// https://www.chainway.net/Support/Info/10
    /// https://www.chainway.net/Products/Info/42
    /// </remarks>>
    public class RfidService : IRfidService
    {
#if NO_RFID
#else
        /// <summary>
        /// RFIDWithUHF has been marked obsolete, however as this is the only API for which sample code is provided by Chainway we will use it to manage the reader.
        /// </summary>
        private readonly RFIDWithUHF uhfApi = RFIDWithUHF.Instance;
#endif

        /// <summary>
        /// Initialize UHF module.
        /// </summary>
        /// <remarks>
        /// Switches on the device before operating the device.
        /// </remarks>
        public bool Init()
        {
#if NO_RFID
            return true;
#else
            return uhfApi.Init();
#endif
        }

        /// <summary>
        /// Switch off UHF module
        /// </summary>
        /// <remarks>
        /// Switch off device after using.
        /// </remarks>
        public bool Free()
        {
#if NO_RFID
            return true;
#else
            return uhfApi.Free();
#endif
        }

        /// <summary>
        /// This formula identify tag in single step, return UII for only one time.
        /// </summary>
        /// <remarks>
        /// TODO Consider calling inventorySingleTagEPC_TID_USER to get TID directly.
        /// </remarks>
        /// <returns>
        /// Return UII, null is identified tag failure.
        /// </returns>
        public string InventorySingleTag()
        {
#if NO_RFID
            return "X9999ASDFZZZZZ";
#else
            return uhfApi.InventorySingleTag();
#endif
        }

        /// <summary>
        /// Start the identification tag cycle and then the identified tag number to the buffer.
        /// </summary>
        /// <remarks>
        /// Used for reading one tag data from buffer zone, after starting circular identification, the module will respond to formula only.
        ///
        /// TODO docs recommend calling readUidFromBuffer() instead. 
        /// </remarks>
        /// <param name="flagAnti">Use anti-collision identification function or not，default 0</param>
        /// <param name="q">Initial Q value of anti-collision process, it will be valid if flagAnti is 1.</param>
        /// <returns>Activate is successful or not</returns>
        public bool StartInventoryTag(int flagAnti, int q)
        {
#if NO_RFID
            return true;
#else
            return uhfApi.StartInventoryTag(flagAnti, q);
#endif
        }

        /// <summary>
        /// Stop circular identification
        /// </summary>
        public bool StopInventory()
        {
#if NO_RFID
            return true;
#else
            return uhfApi.StopInventory();
#endif
        }

        /// <summary>
        /// Read the return tag UII in buffer zone.
        /// </summary>
        public string[] ReadTagFromBuffer()
        {
#if NO_RFID
            return new string[] { string.Empty };
# else
            return uhfApi.ReadTagFromBuffer();
#endif
        }

        /// <summary>
        /// Setup scanning filter.
        /// </summary>
        /// <param name="ptr">Filter start address</param>
        /// <param name="cnt">Filter data length</param>
        /// <param name="data">Filter data</param>
        /// <param name="save">Permanent</param>
        /// <returns>True is success, false is failed</returns>
        public bool SetFilter(int ptr, int cnt, string data, bool save)
        {
#if NO_RFID
            return new string[] { string.Empty };
# else
            // TODO BankEnum can't be exposed in the interface as it's Android specific. This option is unlikely to be exposed as a user option so hard code the required value.
            var filterZone = RFIDWithUHF.BankEnum.Uii;

            return uhfApi.SetFilter(filterZone, ptr, cnt, data, save);
#endif
        }

        /// <summary>
        /// UII transform to EPC.
        /// </summary>
        public string ConvertUiiToEpc(string uii)
        {
#if NO_RFID
            return "X9999ASDFZZZZZ9999";
#else
            return uhfApi.ConvertUiiToEPC(uii);
#endif
        }
    }
}
