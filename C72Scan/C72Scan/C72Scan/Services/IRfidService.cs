
namespace C72Scan.Services
{
    public interface IRfidService
    {
        bool Init();

        bool Free();

        string InventorySingleTag();

        bool StartInventoryTag(int flagAnti, int q);

        bool StopInventory();

        string[] ReadTagFromBuffer();

        bool SetFilter(int ptr, int cnt, string data, bool save);

        string ConvertUiiToEpc(string uii);
    }
}
