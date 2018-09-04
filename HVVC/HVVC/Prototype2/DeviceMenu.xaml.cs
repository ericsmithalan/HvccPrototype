using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for DeviceMenu.xaml
    /// </summary>
    public partial class DeviceMenu : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int tic = 0;
        private int tic2 = 0;
        private DispatcherTimer DevicesPluggedInTimer;

        public DeviceMenu()
        {
            InitializeComponent();

            Loaded += new RoutedEventHandler(DeviceMenu_Loaded);
            if (!Settings.IsStaticPresentation)
            {
                Unloaded += new RoutedEventHandler(DeviceMenu_Unloaded);
            }
        }

        private void DeviceMenu_Unloaded(object sender, RoutedEventArgs args)
        {
            //DevicesPluggedInTimer.Stop();
        }

        private void DeviceMenu_Loaded(object sender, RoutedEventArgs args)
        {
            RenderDeviceMenu();
            AddDeviceHandlers();
            if (!Settings.IsStaticPresentation)
            {
                //DevicesPluggedInTimer = new DispatcherTimer();
                //DevicesPluggedInTimer.Tick += new EventHandler(DevicesPluggedInTimer_Tick);
                //DevicesPluggedInTimer.Interval = new TimeSpan(0, 0, 1);
                //DevicesPluggedInTimer.Start();
            }
        }

        //private void DevicesPluggedInTimer_Tick(object sender, EventArgs e)
        //{
        //    if (tic2 == 1)
        //    {
        //        //App.Devices[2].IsHasData = true;
        //        //App.Devices[2].IsPluggedIn = true;

        //        //App.Devices[3].IsInstalled = true;
        //        //App.Devices[3].IsHasData = true;
        //        //App.Devices[3].IsPluggedIn = true;

        //        //App.Devices[4].IsInstalled = true;
        //        //App.Devices[4].IsHasData = true;
        //        //App.Devices[4].IsPluggedIn = true;

        //        //App.Devices[5].IsInstalled = true;
        //        //App.Devices[5].IsHasData = true;
        //        //App.Devices[5].IsPluggedIn = true;

        //        tic2 = 0;
        //        DevicesPluggedInTimer.Stop();

        //        //App.RenderWindowContent(new UploadMultiple());

        //    }
        //    tic2++;
        //}

        private void RenderDeviceMenu()
        {
            if (App.Devices.NumberOfDevicesReadyForUpload() > 0)
            {
                menu_devices.ItemsSource = App.Devices.GetInstalledDevices();
            }
            else
            {
                menu_devices.ItemsSource = App.Devices.GetInstalledDevices();
            }
        }

        private void AddDeviceHandlers()
        {
            foreach (Device device in App.Devices)
            {
                if (device.ID > 1)
                {
                    device.PropertyChanged += new PropertyChangedEventHandler(device_PropertyChanged);
                }
            }
        }

        private void device_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (!Settings.IsStaticPresentation)
            {
                Device d = (Device)sender;

                if (args.PropertyName == "IsSelected")
                {
                    //App.Devices.CurrentDevice =
                    //this.RenderDeviceMenu();
                    BuildSecondaryMenuItems();
                }

                if (args.PropertyName == "IsPluggedIn")
                {
                    // MessageBox.Show(d.DeviceName);

                    //App.Devices.CurrentDevice =

                    //this.RenderDeviceMenu();
                    //this.BuildSecondaryMenuItems();
                }

                if (args.PropertyName == "IsHasData")
                {
                    if (App.Devices.NumberOfDevicesReadyForUpload() > 1)
                    {
                        App.RenderWindowContent(new UploadMultiple());
                    }

                    BuildSecondaryMenuItems();
                }

                if (args.PropertyName == "IsInInstallQue")
                {
                    //this.RenderDeviceMenu();
                    //this.BuildSecondaryMenuItems();
                }

                if (args.PropertyName == "IsInstalled")
                {
                    RenderDeviceMenu();
                    BuildSecondaryMenuItems();
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            App.Devices.PropertyChanged += new PropertyChangedEventHandler(Devices_PropertyChanged);
            BuildSecondaryMenuItems();
        }

        private void Devices_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            RenderDeviceMenu();
            BuildSecondaryMenuItems();
        }

        private void BuildSecondaryMenuItems()
        {
            if (App.Devices.CurrentDevice.ID == 0)
            {
                menu_device_info.IsEnabled = false;
                menu_device_info.Visibility = Visibility.Collapsed;
                return;
            }

            if (App.Devices.CurrentDevice.ID > 1)
            {
                menu_device_info.Visibility = Visibility.Visible;
                HVCC.Prototype2.PixelSnappedImage bm = new HVCC.Prototype2.PixelSnappedImage();
                bm.Source = App.Devices.CurrentDevice.Image;
                bm.Width = 16;
                bm.Height = 16;
                menu_device_info.Header = App.Devices.CurrentDevice.DeviceName;
                menu_device_info.Icon = bm;
                menu_device_info.IsEnabled = true;
            }
        }

        private void menu_devices_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                MenuItem mi = (MenuItem)e.OriginalSource;
                App.Devices.SetSelectDevice(Convert.ToInt32(mi.Uid));

                if (!Settings.IsStaticPresentation)
                {
                    if (App.Devices.CurrentDevice.ID > 1)
                    {
                        if (Settings.IsAccountAvailable)
                        {
                            if (App.Devices.CurrentDevice.IsMultipleRecord)
                            {
                                App.RenderWindowContent(new MultipleRecordPicker());
                            }
                            else
                            {
                                App.RenderWindowContent(new Upload());
                            }
                        }
                        else
                        {
                            App.RenderWindowContent(new NoAccount());
                        }
                    }
                    else
                    {
                        if (App.Devices.NumberOfDevicesReadyForUpload() > 1)
                        {
                            App.RenderWindowContent(new DevicesDetected());
                        }
                        else
                        {
                            App.RenderWindowContent(new AddDevice());
                        }
                    }
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                MenuItem mi = (MenuItem)sender;
                Window wndw;

                switch (mi.Uid)
                {
                    case "0":
                        if (Settings.IsAccountAvailable)
                        {
                            App.RenderWindowContent(new Upload());
                        }
                        else
                        {
                            App.RenderWindowContent(new NoAccount());
                        }

                        break;

                    case "1":
                        App.RenderDialogContent(new UploadSettings());
                        wndw = App.OpenDialog();
                        wndw.Title = "Upload Settings";
                        wndw.ShowDialog();
                        break;

                    case "2":
                        App.RenderDialogContent(new DeviceInfo());
                        wndw = App.OpenDialog();
                        wndw.Title = "Device Info";
                        wndw.ShowDialog();
                        break;

                    case "3":
                        if (Settings.IsAccountAvailable)
                        {
                            Process.Start(Strings.AccountURL);
                        }
                        else
                        {
                            App.RenderWindowContent(new NoAccount());
                        }

                        break;
                }
            }
        }
    }
}