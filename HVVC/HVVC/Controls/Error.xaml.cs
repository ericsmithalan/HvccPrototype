using System.Windows;
using System.Windows.Controls;

namespace HVCC.Controls
{
    /// <summary>
    /// Interaction logic for Error.xaml
    /// </summary>
    public partial class Error : UserControl
    {
        public Error()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Prototype1.Window1.LoadTwoColumnWindow(null, new Controls.RecordPicker2(), null);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Prototype1.Window1.LoadTwoColumnWindow(null, new Controls.Uploading(), null);
        }
    }
}