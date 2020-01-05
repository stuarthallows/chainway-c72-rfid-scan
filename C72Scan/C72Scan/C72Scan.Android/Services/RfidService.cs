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
            //return true;
            return uhfAPI.StopInventory();
        }

        public bool Init()
        {
        //    return true;
            return uhfAPI.Init();
        }

        public bool Free()
        {
      //      return true;
            return uhfAPI.Free();
        }

        public string InventorySingleTag()
        {
    //        return string.Empty;
            return uhfAPI.InventorySingleTag();
        }

        public string ConvertUiiToEpc(string uii)
        {
  //          return string.Empty;
            return uhfAPI.ConvertUiiToEPC(uii);
        }
    }
}