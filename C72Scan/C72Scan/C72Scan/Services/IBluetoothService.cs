using System.Collections.Generic;
using C72Scan.Models;

namespace C72Scan.Services
{
    public interface IBluetoothService
    {
        IEnumerable<BondedDevice> GetBondedDevices();

        void Connect(BondedDevice device);

        void Write(string message);

        void Close();
    }
}