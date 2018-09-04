using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for Upload.xaml
    /// </summary>
    public partial class DevicesDetected : ControlBase
    {
        private int DeviceCameFromID = 0;

        public DevicesDetected()
        {
            InitializeComponent();

            if (!Settings.IsStaticPresentation)
            {
                if (App.Devices.NumberOfDevicesInstalled() > 0)
                {
                    sp_buttons.Visibility = Visibility.Visible;
                }
                else
                {
                    sp_buttons.Visibility = Visibility.Collapsed;
                }
            }
            Loaded += new RoutedEventHandler(DevicesDetected_Loaded);
        }

        private void DevicesDetected_Loaded(object sender, RoutedEventArgs args)
        {
            DeviceCameFromID = App.Devices.CurrentDevice.ID;

            if (Settings.IsStaticPresentation)
            {
                App.Devices.SetSelectDevice(1);
            }
            else
            {
                App.Devices.SetSelectDevice(0);
            }

            AddDeviceUI();
        }

        private void AddDeviceUI()
        {
            for (int i = 0; i < App.Devices.Count; i++)
            {
                Device d = App.Devices[i];

                if (!d.IsInstalled && d.IsInInstallQue)
                {
                    Border brdr = new Border();
                    brdr.Width = 150;
                    brdr.SnapsToDevicePixels = true;
                    brdr.Margin = new Thickness(0, 0, 0, 10);
                    brdr.BorderBrush = (Brush)FindResource("StandardBorderColor");
                    brdr.BorderThickness = new Thickness(0, 0, 0, 1);
                    brdr.Padding = new Thickness(0, 10, 0, 10);

                    DockPanel dp = new DockPanel();

                    brdr.Child = dp;

                    PixelSnappedImage pi = new PixelSnappedImage();
                    pi.Width = 65;
                    pi.Height = 33;
                    pi.Source = d.ManufacturerImage;
                    pi.HorizontalAlignment = HorizontalAlignment.Left;

                    Button btn = new Button();
                    btn.Uid = d.ID.ToString();
                    btn.HorizontalAlignment = HorizontalAlignment.Right;
                    btn.Style = (Style)FindResource("ButtonAction");
                    btn.Margin = new Thickness(0, 0, 0, 0);
                    btn.MinWidth = 0;
                    btn.MinHeight = 0;
                    btn.Width = 50;
                    btn.Height = 30;
                    btn.Content = "Add";
                    btn.Click += new RoutedEventHandler(btn_Click);

                    DockPanel.SetDock(btn, Dock.Right);
                    DockPanel.SetDock(pi, Dock.Left);

                    dp.Children.Add(pi);
                    dp.Children.Add(btn);

                    DeviceList.Children.Add(brdr);
                }
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                App.RenderWindowContent(new SelectFromList());
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (!Settings.IsStaticPresentation)
            {
                App.RenderWindowContent(new InstallingDevice(Convert.ToInt32(btn.Uid)));
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                App.RenderWindowContent(new Upload());
            }
        }
    }
}