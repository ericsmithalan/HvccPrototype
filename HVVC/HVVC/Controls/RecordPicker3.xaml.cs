using System;
using System.Windows;
using System.Windows.Controls;

namespace HVCC.Controls
{
    public partial class RecordPicker3 : UserControl
    {
        public RecordPicker3()
        {
            InitializeComponent();
            cmbPeople_1.ItemsSource = Methods.CreateRecords(true);
            cmbPeople_2.ItemsSource = Methods.CreateRecordsForMultipleUser(true);
            cmbPeople_2.SelectedIndex = 0;
            cmbPeople_3.ItemsSource = Methods.CreateRecordsForMultipleUser(true);
            cmbPeople_3.SelectedIndex = 0;
            cmbPeople_4.ItemsSource = Methods.CreateRecordsForMultipleUser(true);
            cmbPeople_4.SelectedIndex = 0;
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
    }
}