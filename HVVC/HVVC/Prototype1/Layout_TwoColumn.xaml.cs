using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace HVCC.Prototype1
{
    /// <summary>
    /// Interaction logic for Layout_TwoColumn.xaml
    /// </summary>
    public partial class Layout_TwoColumn : UserControl
    {
        private String _status;
        private FrameworkElement _statusElement;
        private FrameworkElement _body;

        public String Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public FrameworkElement StatusElement
        {
            get { return _statusElement; }
            set { _statusElement = value; }
        }

        public FrameworkElement Body
        {
            get { return _body; }
            set { _body = value; }
        }

        public override void OnApplyTemplate()
        {
            if (Body != null)
            {
                grid_main.Children.Add(Body);
                Grid.SetColumn(Body, 0);
                Grid.SetRow(Body, 2);
                Grid.SetColumnSpan(Body, 3);
            }
            if (StatusElement != null)
            {
                sp_info.Children.Add(StatusElement);
            }
            base.OnApplyTemplate();
        }

        public Layout_TwoColumn()
        {
            InitializeComponent();

            String imageurl = String.Concat("pack://application:,,,/images/", Strings.manufacturer, ".png");
            Uri uri = new Uri(imageurl, UriKind.Absolute);
            PngBitmapDecoder decoder = new PngBitmapDecoder(uri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            img_device.Source = decoder.Frames[0];
            tb_deviceName.Text = Strings.deviceTitle;
            tb_manufacturer.Text = Strings.manufacturer;

            if (!String.IsNullOrEmpty(Status))
            {
                tb_status.Text = Status;
            }
            else
            {
                tb_status.Visibility = Visibility.Collapsed;
            }
        }
    }
}