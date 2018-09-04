using System;
using System.Windows;
using System.Windows.Threading;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for Uploading.xaml
    /// </summary>
    public partial class InstallingDevice : ControlBase
    {
        private int tic = 0;
        private DispatcherTimer dispatcherTimer;
        private Device device;

        public InstallingDevice(int deviceId)
        {
            InitializeComponent();
            device = App.Devices.GetDeviceById(deviceId);
            img_user.Source = device.ManufacturerImage;
            ManufacturerName.Text = device.Manufacturer;
            Loaded += new RoutedEventHandler(Content_Loaded);
            if (!Settings.IsStaticPresentation)
            {
                Unloaded += new RoutedEventHandler(InstallingDevice_Unloaded);
            }
        }

        private void InstallingDevice_Unloaded(object sender, RoutedEventArgs args)
        {
            if (!Settings.IsStaticPresentation)
            {
                dispatcherTimer.Stop();
            }
        }

        private void Content_Loaded(object sender, RoutedEventArgs args)
        {
            if (Settings.IsStaticPresentation)
            {
                App.Devices.SetSelectDevice(2);
            }

            if (!Settings.IsStaticPresentation)
            {
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Start();
                tb_progress.Text = String.Format("{0}% complete", "0");
            }
        }

        public InstallingDevice()
        {
            InitializeComponent();
            img_user.Source = App.Devices.CurrentDevice.ManufacturerImage;
            ManufacturerName.Text = App.Devices.CurrentDevice.Manufacturer;
            device = App.Devices.CurrentDevice;
            Loaded += new RoutedEventHandler(Content_Loaded);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                if (tic == 2)
                {
                    tic = 0;
                    dispatcherTimer.Stop();
                    device.IsHasData = true;
                    device.IsInstalled = true;
                    device.IsInInstallQue = false;

                    App.Devices.SetSelectDevice(device.ID);

                    if (App.Devices.NumberOfDevicesToInstall() > 0)
                    {
                        App.RenderWindowContent(new DevicesDetected());
                    }
                    else
                    {
                        App.RenderWindowContent(new Upload());
                    }
                }
                else
                {
                    tic++;
                    progress.Value = tic;
                    tb_progress.Text = String.Format("{0}% complete", tic * 50);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                dispatcherTimer.Stop();
                App.RenderWindowContent(new AddDevice());
            }
        }
    }
}