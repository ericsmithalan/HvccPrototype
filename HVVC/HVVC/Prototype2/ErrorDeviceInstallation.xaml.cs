using System.Windows;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for Error.xaml
    /// </summary>
    public partial class ErrorDeviceInstallation : ControlBase
    {
        public ErrorDeviceInstallation()
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