using System;
using System.Windows;
using System.Windows.Threading;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for Uploading.xaml
    /// </summary>
    public partial class UploadingMultiple : ControlBase
    {
        private int tic = 0;
        private Devices devices;
        private DispatcherTimer dispatcherTimer;

        public UploadingMultiple(Devices d)
        {
            devices = d;
            InitializeComponent();
            Loaded += new RoutedEventHandler(Content_Loaded);
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
            if (!Settings.IsStaticPresentation)
            {
                Unloaded += new RoutedEventHandler(UploadingMultiple_Unloaded);
            }
        }

        private void UploadingMultiple_Unloaded(object sender, RoutedEventArgs args)
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
                App.Devices.SetSelectDevice(0);
                dispatcherTimer.Start();
                UploadStatus.Text = String.Format("Uploading data from {0}", devices[0].DeviceName);
                tb_progress.Text = String.Format("{0}% complete", "0");
            }

            tb_user.Text = String.Format("{0}’s", Strings.recordName);
        }

        private int interval = 0;

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                progress.Maximum = (devices.Count);
                if (tic < devices.Count)
                {
                    if (tic <= devices[interval].ID)
                    {
                        UploadStatus.Text = String.Format("Uploading data from {0}", devices[interval].DeviceName);
                        progress.Value = tic;
                        decimal percent = (decimal)progress.Value * 100 / (decimal)progress.Maximum;

                        tb_progress.Text = String.Format("{0}% complete", percent);
                        interval++;
                    }
                }
                else
                {
                    dispatcherTimer.Stop();
                    interval = 0;

                    if (Settings.IsUploadCompleteError)
                    {
                        Settings.IsUploadCompleteError = false;
                        App.RenderWindowContent(new UploadCompleteError());
                    }
                    else
                    {
                        App.RenderWindowContent(new UploadCompleteMultiple(devices));
                    }
                }

                tic++;

                //else
                //{
                //    if (Settings.IsTriggerErrorOnUpload)
                //    {
                //        this.dispatcherTimer.Stop();
                //        tic = 0;
                //        App.RenderWindowContent(new UploadingError());
                //    }
                //    else
                //    {
                //        this.progress.Value = tic;
                //        this.tb_progress.Text = String.Format("{0}% complete", tic * 50);
                //    }
                //}
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                dispatcherTimer.Stop();
                //if (HVCC.Prototype2.Device.IsMultipleRecord)
                //{
                //    App.RenderWindowContent(new MultipleRecordPicker());
                //}
                //else
                //{
                //    App.RenderWindowContent(new Upload());
                //}
            }
        }
    }
}