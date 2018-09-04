using System.Windows;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for Uploading.xaml
    /// </summary>
    public partial class DeviceInstalledNotConnected : ControlBase
    {
        public DeviceInstalledNotConnected()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Content_Loaded);
        }

        private void Content_Loaded(object sender, RoutedEventArgs args)
        {
            if (Settings.IsStaticPresentation)
            {
                App.Devices.SetSelectDevice(2);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                Settings.IsTriggerErrorOnUpload = false;
                App.RenderWindowContent(new Upload());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                Settings.IsTriggerErrorOnUpload = false;
                App.RenderWindowContent(new Uploading());
            }
        }
    }
}