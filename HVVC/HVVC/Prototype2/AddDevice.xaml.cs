using System;
using System.Windows;
using System.Windows.Threading;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for NothingHappened.xaml
    /// </summary>
    public partial class AddDevice : ControlBase
    {
        private int tic = 0;
        private DispatcherTimer dispatcherTimer;

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                if (tic == 2)
                {
                    dispatcherTimer.Stop();
                    Device d = App.Devices.GetDeviceById(2);
                    if (!d.IsInstalled)
                    {
                        d.IsInInstallQue = true;
                    }

                    if (App.Devices.NumberOfDevicesToInstall() > 0)
                    {
                        App.RenderWindowContent(new DevicesDetected());
                    }
                }
                else
                {
                    tic++;
                }
            }
        }

        public AddDevice()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Content_Loaded);
            if (!Settings.IsStaticPresentation)
            {
                Unloaded += new RoutedEventHandler(AddDevice_Unloaded);
            }
        }

        private void AddDevice_Unloaded(object sender, RoutedEventArgs args)
        {
            if (!Settings.IsStaticPresentation)
            {
                //dispatcherTimer.Stop();
            }
        }

        private void Content_Loaded(object sender, RoutedEventArgs args)
        {
            if (Settings.IsStaticPresentation)
            {
                App.Devices.SetSelectDevice(1);
            }

            if (!Settings.IsStaticPresentation)
            {
                App.Devices.SetSelectDevice(0);

                if (Settings.IsAutoDetectOn)
                {
                    dispatcherTimer = new DispatcherTimer();
                    dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                    dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                    dispatcherTimer.Start();
                }

                if (App.Devices.NumberOfDevicesInstalled() > 0)
                {
                    sp_buttons.Visibility = Visibility.Visible;
                }
                else
                {
                    sp_buttons.Visibility = Visibility.Collapsed;
                }

                if (App.Devices.NumberOfDevicesToInstall() > 0)
                {
                    App.RenderWindowContent(new DevicesDetected());
                }
            }
        }

        private void hl_deviceList_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                if (Settings.IsAutoDetectOn)
                {
                    if (dispatcherTimer.IsEnabled)
                    {
                        dispatcherTimer.Stop();
                    }
                }
                App.RenderWindowContent(new SelectFromList());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                if (Settings.IsAutoDetectOn)
                {
                    if (dispatcherTimer.IsEnabled)
                    {
                        dispatcherTimer.Stop();
                    }
                }
                App.RenderWindowContent(new Upload());
            }
        }
    }
}