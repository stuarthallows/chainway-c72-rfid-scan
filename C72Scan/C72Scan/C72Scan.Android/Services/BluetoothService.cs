using System.Collections.Generic;
using C72Scan.Droid.Services;
using C72Scan.Models;
using C72Scan.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(BluetoothService))]
namespace C72Scan.Droid.Services
{
    public class BluetoothService : IBluetoothService
    {
        public IEnumerable<BluetoothDevice> GetDevices()
        {
            return new[]
            {
                new BluetoothDevice{ Name = "Device-01", Address = "11-11-11-11" },
                new BluetoothDevice{ Name = "Device-02", Address = "22-22-22-22" },
                new BluetoothDevice{ Name = "Device-03", Address = "33-33-33-33" },
                new BluetoothDevice{ Name = "Device-04", Address = "44-44-44-44" }
            };
        }
    }
}