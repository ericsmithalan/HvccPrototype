using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace HVCC.Setup
{
    /// <summary>
    /// Interaction logic for TOS.xaml
    /// </summary>
    public partial class Installing : UserControl
    {
        private int tic = 0;
        private DispatcherTimer dispatcherTimer;

        public Installing()
        {
            InitializeComponent();
            if (!Settings.IsStaticPresentation)
            {
                Unloaded += new RoutedEventHandler(Installing_Unloaded);
            }

            Loaded += new RoutedEventHandler(Installing_Loaded);
        }

        private void Installing_Unloaded(object sender, RoutedEventArgs args)
        {
            if (!Settings.IsStaticPresentation)
            {
                dispatcherTimer.Stop();
            }
        }

        private void Installing_Loaded(object sender, RoutedEventArgs args)
        {
            if (!Settings.IsStaticPresentation)
            {
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Start();

                tb_progress.Text = String.Format("{0}% complete", "0");
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                if (tic == 2)
                {
                    dispatcherTimer.Stop();
                    tic = 0;
                    Window.GetWindow(this).Close();
                }
                else
                {
                    tic++;
                    progress.Value = tic;
                    tb_progress.Text = String.Format("{0}% complete", tic * 50);
                }
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