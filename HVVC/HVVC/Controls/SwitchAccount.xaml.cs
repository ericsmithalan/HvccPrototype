using System.Windows;
using System.Windows.Controls;

namespace HVCC.Controls
{
    /// <summary>
    /// Interaction logic for SwitchAccount.xaml
    /// </summary>
    public partial class SwitchAccount : UserControl
    {
        public SwitchAccount()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            btn_action.IsEnabled = true;
        }

        private void btn_action_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[1].Close();
        }
    }
}