using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HVCC.Prototype2.RecordSelector
{
    public class DropDown : ComboBox
    {
        public enum SizeOfDropDown
        {
            Small,
            Large,
        }

        public static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size", typeof(SizeOfDropDown), typeof(DropDown), new PropertyMetadata(null));

        static DropDown()
        {
            DropDown.DefaultStyleKeyProperty.OverrideMetadata(typeof(DropDown), new FrameworkPropertyMetadata(typeof(DropDown)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            DropDownRecord cbItem = new DropDownRecord();
            cbItem.PersonName = "Eric Smith";
            cbItem.PersonRelation = "Self";
            cbItem.PersonImage = GetPersonImageSource("Eric");

            DropDownRecord cbItem2 = new DropDownRecord();
            cbItem2.PersonName = "Bob Smith";
            cbItem2.PersonRelation = "Illegitimate Son";
            cbItem2.PersonImage = GetPersonImageSource("Bob");

            DropDownRecord cbItem3 = new DropDownRecord();
            cbItem3.PersonName = "Patty Smith";
            cbItem3.PersonRelation = "Ball & Chain";
            cbItem3.PersonImage = GetPersonImageSource("Patty");

            List<DropDownRecord> records = new List<DropDownRecord>();
            records.Add(cbItem);
            records.Add(cbItem2);
            records.Add(cbItem3);

            ItemsSource = records;
            SelectedIndex = 2;
        }

        private BitmapSource GetPersonImageSource(String file)
        {
            String imageurl = String.Concat("pack://application:,,,/images/", file, ".png");
            Uri uri = new Uri(imageurl, UriKind.Absolute);
            PngBitmapDecoder decoder = new PngBitmapDecoder(uri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            return decoder.Frames[0];
        }

        public SizeOfDropDown Size
        {
            get { return (SizeOfDropDown)GetValue(DropDown.SizeProperty); }
            set { SetValue(DropDown.SizeProperty, value); }
        }
    }

    public class DropDownRecord : ComboBoxItem
    {
        public static readonly DependencyProperty PersonImageProperty = DependencyProperty.Register("PersonImage", typeof(ImageSource), typeof(DropDownRecord), new PropertyMetadata(null));
        public static readonly DependencyProperty PersonNameProperty = DependencyProperty.Register("PersonName", typeof(String), typeof(DropDownRecord), new PropertyMetadata(null));
        public static readonly DependencyProperty PersonRelationProperty = DependencyProperty.Register("PersonRelation", typeof(String), typeof(DropDownRecord), new PropertyMetadata(null));

        static DropDownRecord()
        {
            DropDownRecord.DefaultStyleKeyProperty.OverrideMetadata(typeof(DropDownRecord), new FrameworkPropertyMetadata(typeof(DropDownRecord)));
        }

        public ImageSource PersonImage
        {
            get { return (ImageSource)GetValue(DropDownRecord.PersonImageProperty); }
            set { SetValue(DropDownRecord.PersonImageProperty, value); }
        }

        public String PersonName
        {
            get { return (String)GetValue(DropDownRecord.PersonNameProperty); }
            set { SetValue(DropDownRecord.PersonNameProperty, value); }
        }

        public String PersonRelation
        {
            get { return (String)GetValue(DropDownRecord.PersonRelationProperty); }
            set { SetValue(DropDownRecord.PersonRelationProperty, value); }
        }
    }
}