using System.Collections.Generic;
using System.Linq;
using Android.Bluetooth;
using C72Scan.Droid.Services;
using C72Scan.Models;
using C72Scan.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(BluetoothService))]
namespace C72Scan.Droid.Services
{
    public class BluetoothService : IBluetoothService
    {
        public IEnumerable<BondedDevice> GetBondedDevices()
        {
            return BluetoothAdapter
                    .DefaultAdapter
                    .BondedDevices
                    .Select(d => new BondedDevice
                    {
                        Name = d.Name,
                        Address = d.Address
                    });
        }
    }
}