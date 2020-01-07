using System.Collections.Generic;
using System.Linq;
using Android.Bluetooth;
using C72Scan.Droid.Services;
using C72Scan.Models;
using C72Scan.Services;
using Java.Util;
using Xamarin.Forms;

[assembly: Dependency(typeof(BluetoothService))]
namespace C72Scan.Droid.Services
{
    public class BluetoothService : IBluetoothService
    {
        private readonly UUID MyUuid = UUID.FromString("8ce255c0-200a-11e0-ac64-0800200c9a66");

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

        public void Connect(BondedDevice device)
        {
            // Cancel discovery because it will slow down a connection.
            BluetoothAdapter.DefaultAdapter.CancelDiscovery();

            BluetoothDevice remoteDevice = BluetoothAdapter.DefaultAdapter.GetRemoteDevice(device.Address);

            BluetoothSocket socket = remoteDevice.CreateInsecureRfcommSocketToServiceRecord(MyUuid);

            socket.Connect();

            var bs = System.Text.Encoding.UTF8.GetBytes("E01189999999999999999");

            socket.OutputStream.Write(bs);

            // TODO
            socket.Close();
        }
    }
}
