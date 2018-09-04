using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace HVCC.Prototype2
{
    public class Devices : ObservableCollection<HVCC.Prototype2.Device>, INotifyPropertyChanged
    {
        private Device _currentDevice;

        public event PropertyChangedEventHandler PropertyChanged;

        public Device CurrentDevice
        {
            get { return _currentDevice; }
            set
            {
                _currentDevice = value;
                OnPropertyChanged("CurrentDevice");
            }
        }

        protected void OnPropertyChanged(String isSelected)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(isSelected));
            }
        }

        public Devices()
        {
        }

        public void SetDefaultDevice()
        {
            if (CurrentDevice.ID < 1)
            {
                foreach (Device d in this)
                {
                    if (d.IsInstalled)
                    {
                        if (d.ID > 1)
                        {
                            SetSelectDevice(d.ID);
                            break;
                        }
                    }
                }
            }
        }

        public int NumberOfDevicesPluggedIn()
        {
            int i = 0;
            foreach (Device d in this)
            {
                if (d.IsInstalled && d.IsPluggedIn)
                {
                    i++;
                }
            }
            return i;
        }

        public int NumberOfDevicesReadyForUpload()
        {
            int i = 0;
            foreach (Device d in this)
            {
                if (d.IsInstalled && d.IsHasData && d.IsPluggedIn)
                {
                    i++;
                }
            }
            return i;
        }

        public int NumberOfDevicesInstalled()
        {
            int i = 0;
            foreach (Device d in this)
            {
                if (d.IsInstalled && !d.IsInInstallQue)
                {
                    i++;
                }
            }
            return i;
        }

        public int NumberOfDevicesToInstall()
        {
            int i = 0;
            foreach (Device d in this)
            {
                if (!d.IsInstalled && d.IsInInstallQue)
                {
                    i++;
                }
            }
            return i;
        }

        public void PluggInDevice(int i)
        {
            foreach (Device d in this)
            {
                if (d.ID == i)
                {
                    if (d.IsInstalled)
                    {
                        d.IsPluggedIn = true;
                    }
                }
            }
        }

        public void AddDataToDevice(int i)
        {
            foreach (Device d in this)
            {
                if (d.ID == i)
                {
                    d.IsHasData = true;
                }
            }
        }

        public void SetInstalledDevice(int i)
        {
            foreach (Device d in this)
            {
                d.IsSelected = false;
            }

            if (i <= Items.Count)
            {
                Items[i].IsSelected = true;
                Items[i].IsInstalled = true;
                CurrentDevice = Items[i];
            }
        }

        public void SetSelectDevice(int i)
        {
            foreach (HVCC.Prototype2.Device d in this)
            {
                d.IsSelected = false;
            }

            if (i <= Items.Count)
            {
                Items[i].IsSelected = true;
                CurrentDevice = Items[i];
            }
        }

        public Device GetDeviceById(int id)
        {
            foreach (Device d in this)
            {
                if (d.ID == id)
                {
                    return d;
                }
            }
            return null;
        }

        public ObservableCollection<Device> GetInstalledDevices()
        {
            ObservableCollection<Device> devices = new ObservableCollection<Device>();
            foreach (Device d in this)
            {
                if (d.IsInstalled)
                {
                    devices.Add(d);
                }
            }
            return devices;
        }

        public Device GetSelectDevice()
        {
            foreach (Device d in this)
            {
                if (d.IsSelected)
                {
                    CurrentDevice = d;
                    return d;
                }
            }
            return null;
        }

        public Devices(List<HVCC.Prototype2.Device> devices)
        {
            foreach (Device d in devices)
            {
                if (d.IsInstalled)
                {
                    Add(d);
                }

                if (d.IsSelected)
                {
                    CurrentDevice = d;
                }
            }
        }
    }

    public class Device : UserControl, INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;

        private String _manufacturer;
        private String _name;
        private int _id;
        private bool _isMultipleRecord;
        private BitmapSource _image;
        private BitmapSource _manufacturerImage;
        private bool _isSelected;
        private bool _isInstalled;
        private bool _isInInstallQue;
        private bool _isHasData;
        private bool _isPluggedIn;

        protected void OnPropertyChanged(String isSelected)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(isSelected));
            }
        }

        public bool IsPluggedIn
        {
            get { return _isPluggedIn; }
            set
            {
                _isPluggedIn = value;
                if (_isPluggedIn)
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("IsPluggedIn"));
                    }
                }

                //OnPropertyChanged("IsPluggedIn");
            }
        }

        public bool IsHasData
        {
            get { return _isHasData; }
            set
            {
                _isHasData = value;
                if (_isHasData)
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("IsHasData"));
                    }

                    //OnPropertyChanged("IsHasData");
                }
            }
        }

        public bool IsInInstallQue
        {
            get { return _isInInstallQue; }
            set
            {
                _isInInstallQue = value;

                if (_isInInstallQue)
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("IsInInstallQue"));
                    }

                    //OnPropertyChanged("IsInInstallQue");
                }
            }
        }

        public bool IsInstalled
        {
            get { return _isInstalled; }
            set
            {
                _isInstalled = value;

                if (_isInstalled)
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("IsInstalled"));
                    }

                    //OnPropertyChanged("IsInstalled");
                }
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                if (_isSelected)
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("IsSelected"));
                    }
                }
            }
        }

        public String Manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value; }
        }

        public String DeviceName
        {
            get { return _name; }
            set { _name = value; }
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public bool IsMultipleRecord
        {
            get { return _isMultipleRecord; }
            set { _isMultipleRecord = value; }
        }

        public BitmapSource Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public BitmapSource ManufacturerImage
        {
            get { return _manufacturerImage; }
            set { _manufacturerImage = value; }
        }
    }
}