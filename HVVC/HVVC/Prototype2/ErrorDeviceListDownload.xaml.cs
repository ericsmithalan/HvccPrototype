using System.Windows;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for Error.xaml
    /// </summary>
    public partial class ErrorDeviceListDownload : ControlBase
    {
        public ErrorDeviceListDownload()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
            }
        }
    }
}