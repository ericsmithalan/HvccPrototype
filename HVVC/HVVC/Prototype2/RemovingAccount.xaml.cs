using System;
using System.Windows;
using System.Windows.Threading;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for RemovingAccount.xaml
    /// </summary>
    public partial class RemovingAccount : ControlBase
    {
        private int tic = 0;
        private DispatcherTimer dispatcherTimer;

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                if (tic == 3)
                {
                    dispatcherTimer.Stop();
                    tic = 0;
                    App.RenderDialogContent(new RemovedAccount());
                }
                else
                {
                    tic++;
                }
            }
        }

        public RemovingAccount()
        {
            InitializeComponent();
            if (!Settings.IsStaticPresentation)
            {
                Unloaded += new RoutedEventHandler(RemovingAccount_Unloaded);
            }

            Loaded += new RoutedEventHandler(RemovingAccount_Loaded);
        }

        private void RemovingAccount_Loaded(object sender, RoutedEventArgs args)
        {
            if (!Settings.IsStaticPresentation)
            {
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Start();
            }
        }

        private void RemovingAccount_Unloaded(object sender, RoutedEventArgs args)
        {
            if (!Settings.IsStaticPresentation)
            {
                dispatcherTimer.Stop();
            }
        }
    }
}