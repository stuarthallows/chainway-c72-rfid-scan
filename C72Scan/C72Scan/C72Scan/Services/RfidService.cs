
namespace C72Scan.Services
{
    public interface IRfidService
    {
        bool StopInventory();

        bool Init();

        bool Free();

        string InventorySingleTag();

        string ConvertUiiToEpc(string uii);
    }
}
