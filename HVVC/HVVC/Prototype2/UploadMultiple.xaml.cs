using System.ComponentModel;
using System.Windows;

namespace HVCC.Prototype2
{
    /// <summary>
    /// Interaction logic for Upload.xaml
    /// </summary>
    public partial class UploadMultiple : ControlBase, INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;

        private int tic;
        private Devices devices = new Devices();
        private int nDevice = 0;
        private Device device = null;

        public UploadMultiple()
        {
            InitializeComponent();
        }

        private void AddDeviceHandlers()
        {
            if (!Settings.IsStaticPresentation)
            {
                foreach (Device device in App.Devices)
                {
                    if (device.ID > 1)
                    {
                        device.PropertyChanged += new PropertyChangedEventHandler(device_PropertyChanged);
                    }
                }
            }
        }

        private void device_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (!Settings.IsStaticPresentation)
            {
                if (args.PropertyName == "IsInUploadQue")
                {
                    //this.NumberOfDevices.Text = App.Devices.NumberOfDevicesInUploadQue().ToString();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                nDevice++;

                if (nDevice < App.Devices.NumberOfDevicesReadyForUpload())
                {
                    device = devices[nDevice];

                    App.Devices.SetSelectDevice(device.ID);

                    if (device.IsMultipleRecord)
                    {
                        SingleRecordPicker.Visibility = Visibility.Collapsed;
                        MultipleRecordPicker.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        SingleRecordPicker.Visibility = Visibility.Visible;
                        MultipleRecordPicker.Visibility = Visibility.Collapsed;
                    }
                }
                else
                {
                    App.RenderWindowContent(new UploadingMultiple(devices));
                }
            }
        }

        private void Window_Upload_Loaded(object sender, RoutedEventArgs e)
        {
            //App.Devices.SetSelectDevice(0);
            //this.NumberOfDevices.Text = App.Devices.NumberOfDevicesInUploadQue().ToString();

            if (HVCC.Settings.IsStaticPresentation)
            {
                App.Devices[2].IsHasData = true;
            }

            if (!HVCC.Settings.IsStaticPresentation)
            {
                AddDeviceHandlers();

                foreach (Device d in App.Devices)
                {
                    if (d.ID > 1 && d.IsHasData)
                    {
                        devices.Add(d);
                    }
                }

                device = devices[nDevice];

                App.Devices.SetSelectDevice(device.ID);

                if (device.IsMultipleRecord)
                {
                    SingleRecordPicker.Visibility = Visibility.Collapsed;
                    MultipleRecordPicker.Visibility = Visibility.Visible;
                }
                else
                {
                    SingleRecordPicker.Visibility = Visibility.Visible;
                    MultipleRecordPicker.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}