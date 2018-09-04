using System.Windows;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for Upload.xaml
    /// </summary>
    public partial class SelectPersonForUpload : ControlBase
    {
        public SelectPersonForUpload()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Content_Loaded);
        }

        private void Content_Loaded(object sender, RoutedEventArgs args)
        {
            if (Settings.IsStaticPresentation)
            {
                App.Devices.SetSelectDevice(2);
            }
        }

        private Window GetTopParent()
        {
            DependencyObject dpParent = Parent;
            do
            {
                dpParent = LogicalTreeHelper.GetParent(dpParent);
            }
            while (dpParent.GetType().BaseType != typeof(Window));
            return dpParent as Window;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                App.RenderWindowContent(new Uploading());
            }
        }
    }
}