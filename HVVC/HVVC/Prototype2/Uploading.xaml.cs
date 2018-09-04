using System;
using System.Windows;
using System.Windows.Threading;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for Uploading.xaml
    /// </summary>
    public partial class Uploading : ControlBase
    {
        private int tic = 0;
        private DispatcherTimer dispatcherTimer;

        public Uploading()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Content_Loaded);
            if (!Settings.IsStaticPresentation)
            {
                Unloaded += new RoutedEventHandler(Uploading_Unloaded);
            }
        }

        private void Uploading_Unloaded(object sender, RoutedEventArgs args)
        {
            if (!Settings.IsStaticPresentation)
            {
                dispatcherTimer.Stop();
            }
        }

        private void Content_Loaded(object sender, RoutedEventArgs args)
        {
            if (Settings.IsStaticPresentation)
            {
                App.Devices.SetSelectDevice(2);
            }

            if (!Settings.IsStaticPresentation)
            {
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Start();

                tb_progress.Text = String.Format("{0}% complete", "0");
            }

            tb_user.Text = String.Format("{0}’s", Strings.recordName);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                if (tic == 2)
                {
                    dispatcherTimer.Stop();
                    tic = 0;

                    if (Settings.IsUploadCompleteError)
                    {
                        Settings.IsUploadCompleteError = false;
                        App.RenderWindowContent(new UploadCompleteError());
                    }
                    else
                    {
                        App.RenderWindowContent(new UploadComplete());
                    }
                }
                else
                {
                    if (Settings.IsTriggerErrorOnUpload)
                    {
                        dispatcherTimer.Stop();
                        tic = 0;
                        App.RenderWindowContent(new UploadingError());
                    }
                    else
                    {
                        tic++;
                        progress.Value = tic;
                        tb_progress.Text = String.Format("{0}% complete", tic * 50);
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                dispatcherTimer.Stop();
                if (App.Devices.CurrentDevice.IsMultipleRecord)
                {
                    App.RenderWindowContent(new MultipleRecordPicker());
                }
                else
                {
                    App.RenderWindowContent(new Upload());
                }
            }
        }
    }
}