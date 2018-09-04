using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for UploadComplete.xaml
    /// </summary>
    public partial class UploadComplete : ControlBase
    {
        public UploadComplete()
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

            if (!Settings.IsStaticPresentation)
            {
                App.Devices.CurrentDevice.IsHasData = false;
            }

            Button.Content = String.Format("View data in from {0}", App.Devices.CurrentDevice.DeviceName);
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