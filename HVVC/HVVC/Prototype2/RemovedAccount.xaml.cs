using System.Windows;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for RemovingAccount.xaml
    /// </summary>
    public partial class RemovedAccount : ControlBase
    {
        public RemovedAccount()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                Window.GetWindow(this).Close();
            }
        }
    }
}