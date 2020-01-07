using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;

using C72Scan.Models;
using C72Scan.Services;

namespace C72Scan.ViewModels
{
    public class DevicesViewModel : BaseViewModel
    {
        private readonly IBluetoothService bluetoothService;
        private readonly IMessage messageService;

        public ObservableCollection<BondedDevice> Devices { get; set; }
        public Command LoadDevicesCommand { get; set; }
        public Command ConnectCommand { get; set; }

        private BondedDevice selectedDevice;
        public BondedDevice SelectedDevice
        {
            get => selectedDevice;
            set
            {
                selectedDevice = value;
                ConnectCommand.ChangeCanExecute();
            }
        }

        public DevicesViewModel()
        {
            Title = "Devices";
            Devices = new ObservableCollection<BondedDevice>();
            LoadDevicesCommand = new Command(ExecuteLoadDevicesCommand);
            ConnectCommand = new Command(ExecuteConnectToDeviceCommand, () => SelectedDevice != null);

            bluetoothService = DependencyService.Get<IBluetoothService>();
            messageService = DependencyService.Get<IMessage>();
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
                messageService.LongAlert(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void ExecuteConnectToDeviceCommand()
        {
            try
            {
                bluetoothService.Connect(SelectedDevice);

                messageService.LongAlert("Connected 👍🏼");
            }
            catch (Exception e)
            {
                messageService.LongAlert(e.Message);
            }
        }
    }
}