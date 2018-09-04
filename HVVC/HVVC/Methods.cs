using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HVCC
{
    internal class Methods
    {
        public static List<HVCC.Person> CreateRecords(bool showTip)
        {
            List<HVCC.Person> people = new List<HVCC.Person>();

            if (showTip)
            {
                people.Add(new Person("Select", "Record", ""));
            }

            people.Add(new Person("Eric", "Smith", "Self"));
            people.Add(new Person("Bob", "Smith", "Son"));
            people.Add(new Person("Patty", "Smith", "Ball & Chain"));
            return people;
        }

        public static List<HVCC.Person> CreateRecordsForMultipleUser(bool showTip)
        {
            List<HVCC.Person> people = new List<HVCC.Person>();

            if (showTip)
            {
                people.Add(new Person("Do", "not use this slot", "b"));
            }

            people.Add(new Person("Eric", "Smith", "Self"));
            people.Add(new Person("Bob", "Smith", "Son"));
            people.Add(new Person("Patty", "Smith", "Ball & Chain"));
            return people;
        }

        public static List<HVCC.Person> CreateAccounts()
        {
            List<HVCC.Person> people = new List<HVCC.Person>();

            people.Add(new Person("Eric", "Smith", "Self"));
            return people;
        }

        public static void SetSelectPhotoByName(ComboBox cb)
        {
            Person person;
            for (int i = 0; i < cb.Items.Count; i++)
            {
                person = (Person)cb.Items[i];
                if (person.FirstName.ToLower() == Strings.userImageFile.ToLower())
                {
                    cb.SelectedIndex = i;
                    return;
                }
            }
        }

        public static BitmapSource RenderUserImage()
        {
            String imageurl = String.Concat("pack://application:,,,/images/", Strings.userImageFile, ".png");
            Uri uri = new Uri(imageurl, UriKind.Absolute);
            PngBitmapDecoder decoder = new PngBitmapDecoder(uri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            return decoder.Frames[0];
        }

        public static BitmapSource RenderImage(String file)
        {
            String imageurl = String.Concat("pack://application:,,,/images/", file, ".png");
            Uri uri = new Uri(imageurl, UriKind.Absolute);
            PngBitmapDecoder decoder = new PngBitmapDecoder(uri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            return decoder.Frames[0];
        }

        public static DependencyObject staticFindVisualChildByName(DependencyObject parent, string name)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                string controlName = child.GetValue(Control.NameProperty) as string;
                if (controlName == name)
                {
                    return child;
                }
            }
            return null;
        }

        public static System.Drawing.Icon GetIconFromBitmapSource(String file)
        {
            String imageurl = String.Concat("pack://application:,,,/images/", file, ".png");

            System.Windows.Forms.NotifyIcon icon = new System.Windows.Forms.NotifyIcon();
            Stream iconStream = Application.GetResourceStream(new Uri(imageurl)).Stream;
            return new System.Drawing.Icon(iconStream);
        }
    }
}