using System.Windows;
using System.Windows.Controls;

namespace HVCC.Controls
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                Application.Current.Windows[1].Close();
            }
        }
    }
}