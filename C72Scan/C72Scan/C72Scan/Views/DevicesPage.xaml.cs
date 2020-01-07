﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using C72Scan.Models;
using C72Scan.Views;
using C72Scan.ViewModels;

namespace C72Scan.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class DevicesPage : ContentPage
    {
        readonly DevicesViewModel viewModel;

        public DevicesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new DevicesViewModel();
        }

        void OnDeviceSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var device = args.SelectedItem as BondedDevice;
            if (device == null)
            {
                return;
            }

            viewModel.SelectedDevice = device;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Devices.Count == 0)
            {
                viewModel.LoadDevicesCommand.Execute(null);
            }
        }
    }
}