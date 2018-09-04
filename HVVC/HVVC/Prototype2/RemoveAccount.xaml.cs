using System.Windows;
using System.Windows.Controls;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for RemoveAccount.xaml
    /// </summary>
    public partial class RemoveAccount : ControlBase
    {
        public RemoveAccount()
        {
            InitializeComponent();
            RecordPicker.ItemsSource = Methods.CreateRecords(false);
            RecordPicker.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                ComboBox cb = (ComboBox)sender;
                Person cbi = (Person)cb.SelectedItem;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                App.RenderDialogContent(new RemovingAccount());
            }
        }
    }
}