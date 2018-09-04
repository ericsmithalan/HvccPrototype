using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HVCC.Controls
{
    public partial class RecordPicker2 : UserControl
    {
        public RecordPicker2()
        {
            InitializeComponent();
            cmbPeople.ItemsSource = Methods.CreateRecords(false);
            Methods.SetSelectPhotoByName(cmbPeople);
            Prototype1.Window1.SetWindowHeight(455);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            Methods.RenderUserImage();
            base.OnRender(drawingContext);
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
            if (cb.SelectedIndex == 3)
            {
                SetSelectPhotoByName(cb);
                Process.Start(Strings.AccountURL);
                return;
            }
            else
            {
                if (cb.SelectedIndex >= 0)
                {
                    Strings.recordName = String.Format("{0} {1}", cbi.FirstName, cbi.LastName);
                    Strings.userImageFile = cbi.FirstName;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Prototype1.Window1.LoadTwoColumnWindow(null, new Uploading(), null);
        }
    }
}