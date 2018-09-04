using System.Windows;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for Uploading.xaml
    /// </summary>
    public partial class UE_CouldNotErase : ControlBase
    {
        public UE_CouldNotErase()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                Settings.IsTriggerErrorOnUpload = false;
                App.RenderWindowContent(new Upload());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                Settings.IsTriggerErrorOnUpload = false;
                App.RenderWindowContent(new Uploading());
            }
        }
    }
}