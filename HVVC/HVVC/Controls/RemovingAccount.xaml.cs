using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace HVCC.Controls
{
    /// <summary>
    /// Interaction logic for RemovingAccount.xaml
    /// </summary>
    public partial class RemovingAccount : UserControl
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
                    Prototype1.Window1.LoadSingleColumnWindow(null, null, new Controls.GiveAccountAccess());
                }
                else
                {
                    tic++;
                }
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (!Settings.IsStaticPresentation)
            {
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Start();
            }
        }

        public RemovingAccount()
        {
            InitializeComponent();
        }
    }
}