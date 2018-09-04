using System.Windows;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for DeviceInfo.xaml
    /// </summary>
    public partial class DeviceInfo : ControlBase
    {
        public DeviceInfo()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(DeviceInfo_Loaded);
        }

        private void DeviceInfo_Loaded(object sender, RoutedEventArgs args)
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