using System;
using System.Windows.Media.Imaging;

namespace HVCC.Prototype2
{
    public class DeviceMenuItem
    {
        private String _title;
        private BitmapSource _deviceImage;
        private String _id;

        public String ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public BitmapSource Image
        {
            get { return _deviceImage; }
            set { _deviceImage = value; }
        }

        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public DeviceMenuItem()
        {
        }
    }
}