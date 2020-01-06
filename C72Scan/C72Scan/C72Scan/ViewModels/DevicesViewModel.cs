using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

using Xamarin.Forms;

using C72Scan.Models;
using C72Scan.Services;

namespace C72Scan.ViewModels
{
    public class DevicesViewModel : BaseViewModel
    {
        private IBluetoothService bluetoothService;
        public ObservableCollection<BondedDevice> Devices { get; set; }
        public Command LoadDevicesCommand { get; set; }

        public DevicesViewModel()
        {
            Title = "Devices";
            Devices = new ObservableCollection<BondedDevice>();
            LoadDevicesCommand = new Command(ExecuteLoadDevicesCommand);

            bluetoothService = DependencyService.Get<IBluetoothService>();
        }

        private void ExecuteLoadDevicesCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                Devices.Clear();

                var devices = bluetoothService.GetBondedDevices();

                foreach (var item in devices)
                {
                    Devices.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}