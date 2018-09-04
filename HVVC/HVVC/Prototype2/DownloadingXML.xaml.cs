using System;
using System.Windows;
using System.Windows.Threading;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for Uploading.xaml
    /// </summary>
    public partial class DownloadingXML : ControlBase
    {
        private int tic = 0;
        private DispatcherTimer dispatcherTimer;

        public DownloadingXML()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(DownloadingXML_Loaded);
            if (!Settings.IsStaticPresentation)
            {
                Unloaded += new RoutedEventHandler(DownloadingXML_Unloaded);
            }
        }

        private void DownloadingXML_Loaded(object sender, RoutedEventArgs args)
        {
            if (!Settings.IsStaticPresentation)
            {
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Start();
            }
        }

        private void DownloadingXML_Unloaded(object sender, RoutedEventArgs args)
        {
            dispatcherTimer.Stop();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                if (tic == 2)
                {
                    dispatcherTimer.Stop();
                    tic = 0;
                    App.RenderWindowContent(new Upload());
                }
                else
                {
                    tic++;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                dispatcherTimer.Stop();
                App.RenderDialogContent(new ConfirmQuit());
                Window wndw = App.OpenDialog();
                wndw.ShowDialog();
            }
        }
    }
}