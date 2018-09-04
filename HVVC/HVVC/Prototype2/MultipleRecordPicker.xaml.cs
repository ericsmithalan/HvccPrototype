using System;
using System.Windows;
using System.Windows.Controls;

namespace HVCC.Prototype2
{
    public partial class MultipleRecordPicker : ControlBase
    {
        public MultipleRecordPicker()
        {
            InitializeComponent();

            Loaded += new RoutedEventHandler(Content_Loaded);
        }

        private void Content_Loaded(object sender, RoutedEventArgs args)
        {
            if (Settings.IsStaticPresentation)
            {
                App.Devices.SetSelectDevice(2);
            }

            if (!Settings.IsStaticPresentation)
            {
                if (!App.Devices.CurrentDevice.IsHasData)
                {
                    App.RenderWindowContent(new NoNewDataOnDevice());
                }
                else
                {
                    if (Settings.IsAccountAvailable && Settings.IsSignedIn)
                    {
                        if (!Settings.IsPermision)
                        {
                            App.RenderWindowContent(new NoPermission());
                        }
                    }
                    else
                    {
                        if (!Settings.IsAccountAvailable)
                        {
                            App.RenderWindowContent(new NoAccount());
                        }
                        else
                        {
                            if (!Settings.IsPermision)
                            {
                                App.RenderWindowContent(new NoPermission());
                            }
                        }
                    }
                }
            }
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
            if (!Settings.IsStaticPresentation)
            {
                ComboBox cb = (ComboBox)sender;
                Person cbi = (Person)cb.SelectedItem;
                Strings.recordName = String.Format("{0} {1}", cbi.FirstName, cbi.LastName);
                Strings.userImageFile = cbi.FirstName;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                App.RenderWindowContent(new Uploading());
            }
        }
    }
}