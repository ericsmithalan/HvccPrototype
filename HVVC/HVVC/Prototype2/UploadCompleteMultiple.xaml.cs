using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for UploadComplete.xaml
    /// </summary>
    public partial class UploadCompleteMultiple : ControlBase
    {
        private Devices devices;

        public UploadCompleteMultiple(Devices d)
        {
            InitializeComponent();
            devices = d;
            Loaded += new RoutedEventHandler(Content_Loaded);
        }

        private void Content_Loaded(object sender, RoutedEventArgs args)
        {
            if (Settings.IsStaticPresentation)
            {
                App.Devices.SetSelectDevice(0);
            }

            if (!Settings.IsStaticPresentation)
            {
                App.Devices.SetSelectDevice(0);

                foreach (Device d in devices)
                {
                    Button btn = new Button();
                    btn.Style = (Style)FindResource("ButtonAction");
                    btn.Width = 300;
                    btn.Margin = new Thickness(0, 0, 0, 10);
                    btn.Content = String.Format("View data from {0}", d.DeviceName);
                    btn.Click += new RoutedEventHandler(Button_Click);
                    Buttons.Children.Add(btn);

                    d.IsHasData = false;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                Process.Start(Strings.AccountURL);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                Process.Start(Strings.AppURL);
            }
        }
    }
}