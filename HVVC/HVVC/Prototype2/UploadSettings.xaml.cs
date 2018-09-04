using System.Windows;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for Upload_Settings.xaml
    /// </summary>
    public partial class UploadSettings : ControlBase
    {
        public UploadSettings()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(UploadSettings_Loaded);
        }

        private void UploadSettings_Loaded(object sender, RoutedEventArgs args)
        {
            img_user.Source = App.Devices.CurrentDevice.Image;
            tb_device.Text = App.Devices.CurrentDevice.DeviceName;
            img_manufacturer.Source = App.Devices.CurrentDevice.ManufacturerImage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                Window.GetWindow(this).Close();
            }
        }
    }
}