using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HVCC.Controls
{
    public partial class RecordPicker4 : UserControl
    {
        public RecordPicker4()
        {
            InitializeComponent();
            cmbPeople_1.ItemsSource = Methods.CreateRecords(true);

            SetSelectPhotoByName(cmbPeople_1);
            Prototype1.Window1.SetWindowHeight(520);
        }

        private void SetSelectPhotoByName(ComboBox cmbobx)
        {
            Person person;
            for (int i = 0; i < cmbobx.Items.Count; i++)
            {
                person = (Person)cmbobx.Items[i];
                if (person.FirstName.ToLower() == Strings.userImageFile.ToLower())
                {
                    cmbobx.SelectedIndex = i;
                    return;
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            Person cbi = (Person)cb.SelectedItem;
            Strings.recordName = String.Format("{0} {1}", cbi.FirstName, cbi.LastName);
            Strings.userImageFile = cbi.FirstName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Prototype1.Window1.LoadTwoColumnWindow(null, new Uploading(), null);
        }

        private void Bitmap_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Bitmap bm = (Bitmap)sender;
            StackPanel sp = (StackPanel)bm.Parent;
            if (sp.Visibility == Visibility.Visible)
            {
                sp.Visibility = Visibility.Collapsed;
            }
        }

        private void RenderSlots()
        {
        }

        private int nSlotsVisible = 1;
        private int nMaxSlots = 4;

        private StackPanel RenderSlot(bool isAdd)
        {
            nSlotsVisible++;

            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;
            sp.Margin = new Thickness(0, 0, 0, 10);

            TextBlock tb = new TextBlock();
            tb.Text = String.Format("Slot {0}", nSlotsVisible.ToString());
            tb.Margin = new Thickness(0, 8, 15, 0);
            tb.Width = 60;

            Bitmap bm_add = new Bitmap();

            Bitmap bm_remove = new Bitmap();
            bm_remove.Source = Methods.RenderImage("icn_remove");
            bm_remove.MouseLeftButtonDown += new MouseButtonEventHandler(RemoveSlot);
            bm_remove.VerticalAlignment = VerticalAlignment.Center;

            ComboBox cb = new ComboBox();
            cb.Width = 200;
            cb.HorizontalAlignment = HorizontalAlignment.Left;
            cb.VerticalAlignment = VerticalAlignment.Top;
            cb.Background = System.Windows.Media.Brushes.White;
            cb.BorderBrush = System.Windows.Media.Brushes.LightGray;
            cb.Padding = new Thickness(0, 0, 6, 0);

            cb.ItemsSource = Methods.CreateRecordsForMultipleUser(true);
            DataTemplate dt = (DataTemplate)base.FindResource("ComboTemplate");
            cb.SelectedIndex = 1;

            cb.ItemTemplate = dt;

            sp.Children.Add(tb);
            sp.Children.Add(cb);

            sp.Children.Add(bm_remove);

            return sp;
        }

        private void AddSlot()
        {
            if (nSlotsVisible < nMaxSlots)
            {
                if (nSlotsVisible > 1)
                {
                    sp_main.Children.Insert((nSlotsVisible + 2) - 1, RenderSlot(true));
                }
                else
                {
                    sp_main.Children.Insert(sp_main.Children.Count - 2, RenderSlot(true));
                }
            }
            if (nSlotsVisible == nMaxSlots)
            {
                lnk_add.Visibility = Visibility.Collapsed;
            }
        }

        private void RemoveSlot(object sender, MouseButtonEventArgs e)
        {
            Bitmap bm = (Bitmap)sender;
            StackPanel sp = (StackPanel)bm.Parent;
            sp_main.Children.Remove(sp);

            nSlotsVisible -= 2;

            if (lnk_add.Visibility == Visibility.Collapsed)
            {
                lnk_add.Visibility = Visibility.Visible;
            }
        }

        private void Bitmap_MouseLeftButtonDown2(object sender, MouseButtonEventArgs e)
        {
            AddSlot();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            AddSlot();
        }
    }
}