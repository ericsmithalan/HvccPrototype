using System.Windows;
using System.Windows.Controls;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for RemoveAccount.xaml
    /// </summary>
    public partial class ConfirmQuit : ControlBase
    {
        public ConfirmQuit()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
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