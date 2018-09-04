using System.Windows;
using System.Windows.Controls;

namespace HVCC.Controls
{
    /// <summary>
    /// Interaction logic for NothingHappened.xaml
    /// </summary>
    public partial class NothingHappened : UserControl
    {
        public NothingHappened()
        {
            InitializeComponent();
        }

        private void hl_deviceList_Click(object sender, RoutedEventArgs e)
        {
            Prototype1.Window1.LoadSingleColumnWindow("Add a device", null, new Controls.SelectFromList());
        }
    }
}