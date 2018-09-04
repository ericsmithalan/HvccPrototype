using System.Windows;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for Error.xaml
    /// </summary>
    public partial class ErrorDeviceDriverDownload : ControlBase
    {
        public ErrorDeviceDriverDownload()
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
            }
        }
    }
}