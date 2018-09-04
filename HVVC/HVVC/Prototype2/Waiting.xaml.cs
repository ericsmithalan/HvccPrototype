using System.Windows;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for Waiting.xaml
    /// </summary>
    public partial class Waiting : ControlBase
    {
        public Waiting()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                App.RenderDialogContent(new RefreshingData());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                Window.GetWindow(this).Close();
            }
        }
    }
}