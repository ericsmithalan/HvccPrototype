using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace HVCC.Controls
{
    /// <summary>
    /// Interaction logic for SelectFromList.xaml
    /// </summary>
    public partial class SelectFromList : UserControl
    {
        public SelectFromList()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sp_brand.Visibility = Visibility.Visible;
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            sp_info.Visibility = Visibility.Visible;
            btn_install.IsEnabled = true;
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Strings.DeviceURL);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Prototype1.Window1.LoadSingleColumnWindow("Connect your device to your computer", "Please allow up to one minute after pluging it in.", new Controls.NothingHappened());
        }

        private void btn_install_Click(object sender, RoutedEventArgs e)
        {
            Prototype1.Window1.LoadSingleColumnWindow("Connect your device to your computer", "Please allow up to one minute after pluging it in.", new Controls.NothingHappened());
        }
    }
}