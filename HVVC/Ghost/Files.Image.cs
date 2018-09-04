using System;
using System.Windows.Media.Imaging;

namespace Ghost.Files
{
    public class Image
    {
        public Image(string path)
        {
            try
            {
                _path = path;
                _source = new Uri(path);
                _fileName = System.IO.Path.GetFileName(path);
                BitmapDecoder uriBitmap;

                if (_path.IndexOf(".png") != -1)
                {
                    uriBitmap = BitmapDecoder.Create(_source, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                }
                else if (_path.IndexOf(".gif") != -1)
                {
                    uriBitmap = BitmapDecoder.Create(_source, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                }
                else if (_path.IndexOf(".jpg") != -1)
                {
                    uriBitmap = BitmapDecoder.Create(_source, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                }
                else
                {
                    uriBitmap = BitmapDecoder.Create(_source, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                }

                _imagebitmapframe = BitmapFrame.Create(uriBitmap.Frames[0]);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.StackTrace);
            }
        }

        public override string ToString()
        {
            return _source.ToString();
        }

        public string FileName
        {
            set { _fileName = value; }
            get { return _fileName; }
        }

        private string _path;
        private string _fileName;
        private Uri _source;
        public string Source { get { return _path; } }
        private BitmapFrame _imagebitmapframe;
        public BitmapFrame ImageBitMapFrame { get { return _imagebitmapframe; } set { _imagebitmapframe = value; } }
    }
}