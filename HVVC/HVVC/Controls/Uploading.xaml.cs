using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace HVCC.Controls
{
    /// <summary>
    /// Interaction logic for Uploading.xaml
    /// </summary>
    public partial class Uploading : UserControl
    {
        private int tic = 0;
        private DispatcherTimer dispatcherTimer;

        public Uploading()
        {
            InitializeComponent();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                if (tic == 10)
                {
                    dispatcherTimer.Stop();
                    tic = 0;
                    Prototype1.Window1.LoadTwoColumnWindow(null, null, new UploadComplete());
                }
                else
                {
                    tic++;
                    progress.Value = tic;
                    tb_progress.Text = String.Format("{0}% complete", tic * 10);
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

                tb_user.Text = String.Format("{0}’s", Strings.recordName);
                tb_progress.Text = String.Format("{0}% complete", "0");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                dispatcherTimer.Stop();
                Prototype1.Window1.LoadSingleColumnWindow("Something real bad just happened!", null, new Controls.Error());
            }
        }
    }
}