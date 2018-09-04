using System;
using System.Windows;
using System.Windows.Threading;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for Waiting.xaml
    /// </summary>
    public partial class RefreshingData : ControlBase
    {
        private int tic = 0;
        private DispatcherTimer dispatcherTimer;

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                if (tic == 2)
                {
                    dispatcherTimer.Stop();
                    Window.GetWindow(this).Close();
                }
                else
                {
                    tic++;
                }
            }
        }

        public RefreshingData()
        {
            InitializeComponent();
            if (!Settings.IsStaticPresentation)
            {
                Unloaded += new RoutedEventHandler(RefreshingData_Unloaded);
            }

            Loaded += new RoutedEventHandler(RefreshingData_Loaded);
        }

        private void RefreshingData_Loaded(object sender, RoutedEventArgs args)
        {
            if (!Settings.IsStaticPresentation)
            {
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Start();
            }
        }

        private void RefreshingData_Unloaded(object sender, RoutedEventArgs args)
        {
            if (!Settings.IsStaticPresentation)
            {
                dispatcherTimer.Stop();
            }
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