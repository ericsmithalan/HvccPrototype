using System.Windows;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : ControlBase
    {
        public About()
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