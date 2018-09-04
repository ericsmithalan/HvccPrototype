using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HVCC.Controls
{
    public partial class RecordPicker : UserControl
    {
        public RecordPicker()
        {
            InitializeComponent();
            cmbPeople.ItemsSource = Methods.CreateRecords(true);
            SetSelectPhotoByName();
            Prototype1.Window1.SetWindowHeight(455);
        }

        private void SetSelectPhotoByName()
        {
            Person person;
            for (int i = 0; i < cmbPeople.Items.Count; i++)
            {
                person = (Person)cmbPeople.Items[i];
                if (person.FirstName.ToLower() == Strings.userImageFile.ToLower())
                {
                    cmbPeople.SelectedIndex = i;
                    return;
                }
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            tb_userName.Text = Strings.recordName;
            RenderUserImage();
            base.OnRender(drawingContext);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Person cbi = (Person)cb.SelectedItem;
            if (cb.SelectedIndex == 4)
            {
                Prototype1.Window1.LoadTwoColumnWindow(null, new Controls.RecordPicker2(), null);
            }
            else if (cb.SelectedIndex == 5)
            {
                Prototype1.Window1.LoadTwoColumnWindow(null, null, new Controls.RecordPicker3());
            }
            else
            {
                if (cb.SelectedIndex > 0)
                {
                    Strings.recordName = String.Format("{0} {1}", cbi.FirstName, cbi.LastName);
                    Strings.userImageFile = cbi.FirstName;
                    Strings.userImageFile = cbi.FirstName;
                    tb_userName.Text = Strings.recordName;
                    img_user.Source = Methods.RenderUserImage();
                    cb.SelectedIndex = 0;
                }
            }
        }

        private void RenderUserImage()
        {
            String imageurl = String.Concat("pack://application:,,,/images/", Strings.userImageFile, ".png");
            Uri uri = new Uri(imageurl, UriKind.Absolute);
            PngBitmapDecoder decoder = new PngBitmapDecoder(uri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            img_user.Source = decoder.Frames[0];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Prototype1.Window1.LoadTwoColumnWindow(null, new Uploading(), null);
        }
    }
}