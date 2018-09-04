using System.ComponentModel;
using System.Diagnostics;
using System.Windows;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for GiveAccountAccess.xaml
    /// </summary>
    public partial class NoPermission : ControlBase
    {
        public NoPermission()
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                Process.Start(Strings.AccountURL);
                App.RenderDialogContent(new Waiting());
                Window wndw = App.OpenDialog();
                wndw.Title = "Wating...";
                wndw.Closing += new CancelEventHandler(wndw_Closing);
                wndw.ShowDialog();
            }
        }

        private void wndw_Closing(object sender, CancelEventArgs args)
        {
            Settings.IsPermision = true;
            App.RenderWindowContent(new Upload());
        }
    }
}