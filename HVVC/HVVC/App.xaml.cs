using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;

namespace HVCC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, INotifyPropertyChanged
    {
        public static HVCC.Prototype2.WindowMaster MasterWindowTemplate;
        public static HVCC.Prototype2.WindowMaster MasterDialogTemplate;
        public static HVCC.Prototype2.WindowMaster MasterStaticWindowTemplate;
        public static DispatcherTimer DevicePluggInTimer;

        public event PropertyChangedEventHandler PropertyChanged;

        public static HVCC.Prototype2.Devices Devices;

        public static List<HVCC.Prototype2.DeviceMenuItem> DeviceSelectedItems = new List<HVCC.Prototype2.DeviceMenuItem>();

        public static Window OpenWindow()
        {
            if (Settings.IsGhostApp)
            {
                Ghost.Wrapper.Window ghostWndw = new Ghost.Wrapper.Window(App.MasterWindowTemplate);
                ghostWndw.CloseButtonState = Ghost.CloseButtonStates.Close;
                return ghostWndw;
            }
            else
            {
                HVCC.Prototype2.PrototypeWindow wndw = new HVCC.Prototype2.PrototypeWindow(App.MasterWindowTemplate);
                return wndw;
            }
        }

        public static Window OpenDialog()
        {
            if (Settings.IsGhostApp)
            {
                Ghost.Wrapper.Window ghostWndw = new Ghost.Wrapper.Window(App.MasterDialogTemplate);
                ghostWndw.CloseButtonState = Ghost.CloseButtonStates.Close;
                return ghostWndw;
            }
            else
            {
                HVCC.Prototype2.PrototypeWindow wndw = new HVCC.Prototype2.PrototypeWindow(App.MasterDialogTemplate);
                return wndw;
            }
        }

        public static void RenderDialogContent(HVCC.Prototype2.ControlBase ctl)
        {
            MasterDialogTemplate.IsDialog = ctl.IsDialog;
            MasterDialogTemplate.IsDevicesMenusShown = ctl.IsMenusVisible;
            MasterDialogTemplate.WindowContentControl = ctl;
        }

        public static void RenderWindowContent(HVCC.Prototype2.ControlBase ctl)
        {
            if (ctl.IsMenusVisible)
            {
                if (App.Devices.NumberOfDevicesInstalled() > 0)
                {
                    MasterWindowTemplate.IsDevicesMenusShown = true;
                }
                else
                {
                    MasterWindowTemplate.IsDevicesMenusShown = false;
                }
            }
            else
            {
                MasterWindowTemplate.IsDevicesMenusShown = false;
            }

            MasterWindowTemplate.IsDialog = ctl.IsDialog;
            MasterWindowTemplate.WindowContentControl = ctl;
        }

        public static void RenderStaticWindowContent(HVCC.Prototype2.ControlBase ctl)
        {
            Settings.IsStaticPresentation = true;
            MasterStaticWindowTemplate = new HVCC.Prototype2.WindowMaster();
            if (ctl.IsMenusVisible)
            {
                if (App.Devices.NumberOfDevicesInstalled() > 0)
                {
                    MasterStaticWindowTemplate.IsDevicesMenusShown = true;
                }
                else
                {
                    MasterStaticWindowTemplate.IsDevicesMenusShown = false;
                }
            }
            else
            {
                MasterStaticWindowTemplate.IsDevicesMenusShown = false;
            }

            MasterStaticWindowTemplate.IsDialog = ctl.IsDialog;
            MasterStaticWindowTemplate.WindowContentControl = ctl;
        }

        public App()
        {
            DispatcherUnhandledException += App.UnhandledExceptionHandler;
            InitializeComponent();
            BuildDevicesList();
            StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);

            DevicePluggInTimer = new DispatcherTimer();
            DevicePluggInTimer.Tick += new EventHandler(DevicePluggInTimer_Tick);
            DevicePluggInTimer.Interval = new TimeSpan(0, 0, 3);
        }

        private int tic = 0;

        private void DevicePluggInTimer_Tick(object sender, EventArgs e)
        {
            tic++;

            if (tic == 2)
            {
                foreach (HVCC.Prototype2.Device device in App.Devices)
                {
                    if (!device.IsPluggedIn && device.IsInstalled)
                    {
                        if (device.ID > 1 && device.ID != App.Devices.CurrentDevice.ID)
                        {
                            device.IsPluggedIn = true;
                            App.Devices.CurrentDevice = device;
                            break;
                        }
                    }
                }
            }
            else if (tic == 3)
            {
                // DevicePluggInTimer.Stop();
            }
        }

        public static void BuildDevicesList()
        {
            Devices = new HVCC.Prototype2.Devices();
            HVCC.Prototype2.Device empty = new HVCC.Prototype2.Device();
            empty.ID = 0;
            empty.DeviceName = null;
            empty.Image = null;
            empty.IsSelected = false;
            empty.Manufacturer = null;
            empty.IsMultipleRecord = false;
            empty.IsEnabled = false;
            empty.ManufacturerImage = null;
            empty.IsInstalled = false;
            empty.IsInInstallQue = false;
            empty.IsHasData = false;
            empty.IsPluggedIn = false;

            HVCC.Prototype2.Device add = new HVCC.Prototype2.Device();
            add.ID = 1;
            add.DeviceName = "Add new device";
            add.Image = Methods.RenderImage("icn_add");
            add.IsSelected = false;
            add.Manufacturer = null;
            add.IsMultipleRecord = false;
            add.IsEnabled = true;
            add.ManufacturerImage = null;
            add.IsInstalled = true;
            add.IsInInstallQue = true;
            add.IsHasData = false;
            add.IsPluggedIn = false;

            HVCC.Prototype2.Device pedometer = new HVCC.Prototype2.Device();
            pedometer.ID = 2;
            pedometer.DeviceName = "Pedometer 720ITC";
            pedometer.Manufacturer = "Omron";
            pedometer.IsMultipleRecord = false;
            pedometer.IsEnabled = true;
            pedometer.Image = Methods.RenderImage("omron");
            pedometer.ManufacturerImage = Methods.RenderImage("logo_omron");
            pedometer.IsSelected = true;
            pedometer.IsInstalled = true;
            pedometer.IsInInstallQue = false;
            pedometer.IsHasData = true;
            pedometer.IsPluggedIn = true;

            HVCC.Prototype2.Device lifescan = new HVCC.Prototype2.Device();
            lifescan.ID = 3;
            lifescan.DeviceName = "OneTouch Ultra 2";
            lifescan.Manufacturer = "Lifescan";
            lifescan.IsMultipleRecord = false;
            lifescan.IsEnabled = true;
            lifescan.Image = Methods.RenderImage("Lifescan");
            lifescan.ManufacturerImage = Methods.RenderImage("logo_lifescan"); ;
            lifescan.IsSelected = false;
            lifescan.IsInstalled = false;
            lifescan.IsInInstallQue = false;
            lifescan.IsHasData = false;
            lifescan.IsPluggedIn = false;

            HVCC.Prototype2.Device homemedics = new HVCC.Prototype2.Device();
            homemedics.ID = 4;
            homemedics.DeviceName = "Blood Pressure Monitor";
            homemedics.Manufacturer = "HomeMedics";
            homemedics.IsMultipleRecord = true;
            homemedics.IsEnabled = true;
            homemedics.Image = Methods.RenderImage("hm");
            homemedics.ManufacturerImage = Methods.RenderImage("logo_hm"); ;
            homemedics.IsSelected = false;
            homemedics.IsInstalled = false;
            homemedics.IsInInstallQue = false;
            homemedics.IsHasData = false;
            homemedics.IsPluggedIn = false;

            HVCC.Prototype2.Device admedical = new HVCC.Prototype2.Device();
            admedical.ID = 5;
            admedical.DeviceName = "Weight Scale";
            admedical.Manufacturer = "A&D Medical";
            admedical.IsMultipleRecord = true;
            admedical.IsEnabled = true;
            admedical.Image = Methods.RenderImage("ad");
            admedical.ManufacturerImage = Methods.RenderImage("logo_ad"); ;
            admedical.IsSelected = false;
            admedical.IsInstalled = false;
            admedical.IsInInstallQue = false;
            admedical.IsHasData = false;
            admedical.IsPluggedIn = false;

            Devices.Add(empty);
            Devices.Add(add);
            Devices.Add(pedometer);
            Devices.Add(lifescan);
            Devices.Add(homemedics);
            Devices.Add(admedical);
            Devices.SetSelectDevice(2);
        }

        //private void AddDeviceHandlers()
        //{
        //    foreach (HVCC.Prototype2.Device device in App.Devices)
        //    {
        //        if (device.ID > 1)
        //            device.PropertyChanged += new PropertyChangedEventHandler(device_PropertyChanged);
        //    }
        //}
        //private void device_PropertyChanged(object sender, PropertyChangedEventArgs args)
        //{
        //    if (args.PropertyName == "IsPluggedIn")
        //    {
        //        MessageBox.Show("IsPluggedIn");
        //        //this.RenderDeviceMenu();
        //        //this.BuildSecondaryMenuItems();
        //    }
        //}
        private static void UnhandledExceptionHandler(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show(e.Exception.Message + "\n\n" + e.Exception.StackTrace);
            //Application.Current.Shutdown();
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new DispatcherOperationCallback(delegate
            {
                return null;
            }), null);
        }
    }
}