using System.Diagnostics;
using System.Windows;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for UploadComplete.xaml
    /// </summary>
    public partial class NoNewDataOnDevice : ControlBase
    {
        public NoNewDataOnDevice()
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
                Process.Start(Strings.AccountURL);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                Process.Start(Strings.AppURL);
            }
        }
    }
}