using System.Windows;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for Upload.xaml
    /// </summary>
    public partial class Upload : ControlBase
    {
        public Upload()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                App.RenderWindowContent(new Uploading());
            }
        }

        private void Window_Upload_Loaded(object sender, RoutedEventArgs e)
        {
            if (Settings.IsStaticPresentation)
            {
                App.Devices.SetSelectDevice(2);
            }

            if (!HVCC.Settings.IsStaticPresentation)
            {
                if (App.Devices.NumberOfDevicesInstalled() > 0)
                {
                    App.Devices.SetDefaultDevice();

                    if (!Settings.IsAccountAvailable)
                    {
                        App.RenderWindowContent(new NoAccount());
                    }
                    else
                    {
                        if (!Settings.IsPermision)
                        {
                            App.RenderWindowContent(new NoPermission());
                        }
                        else
                        {
                            if (!App.Devices.CurrentDevice.IsHasData)
                            {
                                App.RenderWindowContent(new NoNewDataOnDevice());
                            }
                            else
                            {
                                if (App.Devices.CurrentDevice.IsMultipleRecord)
                                {
                                    App.RenderWindowContent(new MultipleRecordPicker());
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (App.Devices.NumberOfDevicesToInstall() > 0)
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
}