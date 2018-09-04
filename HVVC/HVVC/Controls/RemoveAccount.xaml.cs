using System;
using System.Windows;
using System.Windows.Controls;

namespace HVCC.Controls
{
    /// <summary>
    /// Interaction logic for RemoveAccount.xaml
    /// </summary>
    public partial class RemoveAccount : UserControl
    {
        public RemoveAccount()
        {
            InitializeComponent();
            cmbPeople.ItemsSource = Methods.CreateAccounts();
            SetSelectPhotoByName();
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
                    cb.SelectedIndex = 0;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[1].Close();
        }
    }
}