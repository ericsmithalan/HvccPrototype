using System.Windows;
using System.Windows.Controls;

namespace HVCC.Controls
{
    /// <summary>
    /// Interaction logic for Upload_Settings.xaml
    /// </summary>
    public partial class UploadSettings : UserControl
    {
        public UploadSettings()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Windows[1].Close();
        }
    }
}